Imports System.Xml
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Restore
#Region "Global Var's"
    '*-----------------*'
    '*----Global Var's----*'
    '*-----------------*'

    Dim alreadyloadednodes As New ArrayList
    Dim currentlyselectedtreenode_Fullsourcepath As String 'filled later in the load dataset function
    Dim currentlyselectedtreenode_Fulltargetpath As String 'loaded there to prevent double caluclation.
    Dim currentlyselectedtreenode_FolderpairID As Integer 'dataset has to be loaded anyway to restore it - so I save the calculated paths there already.
    Dim AlltimenodesinTreeviewarray As New ArrayList
    'so those "Currentlyselectedtreenode" vars are fille later in the add dataset function

#End Region

#Region "MainCode"
    '*-----------------*'
    '*----Main Code----*'
    '*-----------------*'

    'executed when form loads
    Private Sub Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dont do heavy coding here
        'load icon wouldnt be displayed!
        tv_restore.Nodes.Clear()
    End Sub

    'executed when settingsform is fully loaded (and therefore shown to the user)
    Private Sub Restore_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'make the loading circle bigger - seems like gui is bugged (stays small if changed by gui)
        lc_loading_datasets.InnerCircleRadius = 12
        lc_loading_datasets.OuterCircleRadius = 15
        lc_loading_datasets.SpokeThickness = 3
        lc_loading_datasets.NumberSpoke = 50

        lc_restore_active.InnerCircleRadius = 12
        lc_restore_active.OuterCircleRadius = 15
        lc_restore_active.SpokeThickness = 3
        lc_restore_active.NumberSpoke = 50


        'everything else about the loading circle is handlet within the background worker
        'call everything which consumes times within a seperate thread (Background worker)
        bw_Reload_Settings.RunWorkerAsync()
        While bw_Reload_Settings.IsBusy
            Application.DoEvents()
        End While


    End Sub

    Private Function RestoreDirectory(ByRef selectednode As TreeNode, ByVal sourcepath As String, ByVal targetpath As String, ByVal backuptype As String, Optional simulate_mode_active As Boolean = True)

        Try
            For Each filepath In Directory.GetFiles(sourcepath)

                Try
                    Dim processname As String = "robocopy.exe"
                    Dim filestocopy As String = Path.GetFileName(filepath) 'used in the robocopy command to only copy that file
                    ' Dim ARGFull As String = "/A-:A"
                    Dim Proc As New Process
                    Proc.StartInfo = New ProcessStartInfo("C:\Windows\System32\cmd.exe")
                    Proc.StartInfo.UseShellExecute = False
                    Proc.StartInfo.CreateNoWindow = True

                    Proc.StartInfo.Arguments = "/C " & processname & " " & currentlyselectedtreenode_Fullsourcepath & " " _
                                                    & targetpath & " " & filestocopy & " /Z" '& ARGFull



                    Proc.Start() 'after defining everythig start the process
                    'then wait for it to exit to continue with the next file
                    Proc.WaitForExit()
                    'getting errorcode - the catch block wouldn't get a file error.
                    '(the code isn't failing - the cmd would. so get code from cmd)
                    Dim exitcode = Proc.ExitCode
                    If exitcode = "0" Or exitcode = "1" Then 'no files were copied (becuase no need for it) or all copied succesfully!
                        'assume success
                    Else
                        'assume problem
                        Dim Logentry = "The following File could not be restored - is it opened? Errorcode:" & exitcode & vbNewLine & filepath & vbNewLine & Proc.StartInfo.Arguments.ToString & vbNewLine
                        Me.Invoke(Ldel, Logentry)
                    End If
                Catch ex As Exception
                    'if single files fail - maybe make a list? How do we log?
                    Dim Logentry = "There was some Issue within the RestoreDirectory() Function. See Information below:" & vbNewLine & ex.StackTrace & vbNewLine
                    Me.Invoke(Ldel, Logentry)
                End Try
            Next


            'get Subdirectories and repeat process
            For Each dir As String In Directory.GetDirectories(sourcepath)
                'calculate the relative path
                Dim relpath As String = dir.Substring(sourcepath.Length, dir.Length - sourcepath.Length)
                'call routine to delete subfiles
                If simulate_mode_active = True Then
                    RestoreDirectory(selectednode, dir, targetpath & relpath, backuptype, True)
                Else
                    RestoreDirectory(selectednode, dir, targetpath & relpath, backuptype, False)
                End If
            Next

            Return (0) 'return code "0" if everything went ok - without breaking code anywhere
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Above Error occured in Restore_Directory Function", "Error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1 'return code "-1" to indicate an unknown/unhandlet error 
        End Try

    End Function

    Function loaddatasetintotreeview(passednode As TreeNode, folderpairIDtoedit As Integer, Optional Passed_Directory As String = Nothing)
        Dim originalsourcedirectory As String = home.sourcepatharray(folderpairIDtoedit) 'dir where file was originally.
        Dim currentnsourcedirectory As String = home.backupPatharray(folderpairIDtoedit) 'dir where those source files are now. 
        'used to load  aspecific dataset (including all available files) into treeview
        'get fulldir only valid if first time call!
        If alreadyloadednodes.Contains(passednode) Then
            Return 1 'already loaded - quit the function - prevent double adding
        End If

        Dim fullpath As String = ""
        Dim originalpassednode As TreeNode = passednode

        If Passed_Directory = Nothing Then
            fullpath = currentnsourcedirectory & "\"
            For i = 0 To 255
                fullpath = fullpath & passednode.Text & "\"
                If passednode.Parent Is Nothing Then
                    Exit For
                End If
                passednode = passednode.Parent
            Next
            'after that the treenodes are wrong way around (last 3 dirs inf ullpath)

            'so switch last 3 dirs right way
            Dim tmparray As New ArrayList
            tmparray = home.StringtoArray(fullpath, "\")
            Dim str1 As String
            Dim str3 As String
            Dim arraycounter = tmparray.Count
            str1 = tmparray(arraycounter - 1)
            str1 = str1.Substring(1, str1.Length - 1)
            str3 = tmparray(arraycounter - 3)
            tmparray(arraycounter - 3) = str1
            tmparray(arraycounter - 1) = str3
            Dim finalfullpath = ""
            For Each str As String In tmparray
                finalfullpath = finalfullpath & str & "\"
            Next
            fullpath = finalfullpath
        Else
            fullpath = Passed_Directory
        End If

        'adding files
        For Each filepath As String In Directory.GetFiles(fullpath)
            Dim filename As String = Path.GetFileName(filepath)
            originalpassednode.Nodes.Add(filename, filename)
        Next

        'now call itself with newly created node as reference, and the working dir
        'adding dirs
        For Each folderpath As String In Directory.GetDirectories(fullpath)
            '"loop" thorugh all dirs from right to left to get dirname (how I love the stringtoarray function :3 )
            Dim tmparray As New ArrayList
            tmparray = home.StringtoArray(folderpath & "\", "\") '& "\" needed to get array correctly
            Dim Fodlername As String = tmparray(tmparray.Count - 1)
            Dim addednode = originalpassednode.Nodes.Add(Fodlername, Fodlername)

            'call function itself with added node
            loaddatasetintotreeview(addednode, folderpairIDtoedit, folderpath)
        Next

        'add node to array to prevent loading again
        alreadyloadednodes.Add(originalpassednode)

        'fill global vars - to use in restore function later 
        currentlyselectedtreenode_Fullsourcepath = fullpath
        currentlyselectedtreenode_Fulltargetpath = tb_targetdir.Text
        currentlyselectedtreenode_FolderpairID = folderpairIDtoedit


    End Function

    Sub tv_restore_NodeMouseClick(ByVal sender As Object,
    ByVal e As TreeNodeMouseClickEventArgs) _
    Handles tv_restore.NodeMouseClick

        Dim currnodeistimenode As Boolean
        Dim currnodename = e.Node.Text

        For i = 0 To home.lv_overview.Items.Count - 1
            'reset varaibles
            currnodeistimenode = False
            'check if the name of current node is matching any folderpairnode name "_FPID" (f.E _0)

            If currnodename.Length >= 5 Then
                'calculate substring to check if time is valid (if only 4 numbers)
                Dim timestring As String = currnodename.Substring(1, 4)
                If IsNumeric(timestring) And currnodename.Length = 5 Then
                    currnodeistimenode = True
                End If
            End If

        Next
        If currnodeistimenode Then
            'calculate directory based on FPID
            Dim folderpairIDtoedit = e.Node.Parent.Text.Substring(1, 1)
            Dim originalsourcedirectory As String = home.sourcepatharray(folderpairIDtoedit) 'dir where file was originally.
            Dim currentnsourcedirectory As String = home.backupPatharray(folderpairIDtoedit) 'dir where those source files are now. 
            Dim Directory_additions As String = "\" & e.Node.Parent.Parent.Text.Substring(1, e.Node.Parent.Parent.Text.Length - 1) & "\" & e.Node.Parent.Text & "\" & e.Node.Text
            Dim fulldir As String = currentnsourcedirectory & Directory_additions
            Try
                If home.DebugmodeOn = True Then
                    Logaddentry(home.GetDate & "Start loading of available Datasets of the following path:" & fulldir & vbNewLine)
                End If
                loaddatasetintotreeview(e.Node, folderpairIDtoedit)
                If home.DebugmodeOn = True Then
                    Logaddentry(home.GetDate & "Finished loading of available Datasets of the following path:" & fulldir & vbNewLine)
                End If
                home.Treenode_Already_Filled_Datasets.Add(fulldir)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub


    Private Sub b_startrestore_Click(sender As Object, e As EventArgs) Handles btn_startrestore.Click
        Dim relevantsrcarray As New ArrayList
        Dim relevantbckarray As New ArrayList
        Dim relevanttypearray As New ArrayList
        Dim currsrcarray As New ArrayList
        Dim currbckarray As New ArrayList
        Dim currtypearray As New ArrayList
        Dim tmpbck As String = "" ' later used to restore files
        Dim timenodectr As Long = 0

        Dim timenodefound As Boolean = False
        For Each tvn As TreeNode In tv_restore.Nodes
            GetallTimenodesoftreeview(tvn)
        Next

        If tv_restore.SelectedNode Is Nothing Then
            MsgBox("No node selected")
            Exit Sub
        End If
        If tb_targetdir.Text = "" Then
            'ask user to provide targetpath. (ask with dialogbox instead of aborting) 
            MsgBox("No targetpath selected - Please select one in the upcoming Dialog:")
            ' Dialog to select Source Path
            fbd_searchRestoretargetpath.Description = "Select Target Folder for Restore!"
            fbd_searchRestoretargetpath.RootFolder = Environment.SpecialFolder.MyComputer
            DialogResult = fbd_searchRestoretargetpath.ShowDialog
            Dim SourcePathresult As String = fbd_searchRestoretargetpath.SelectedPath.ToString 'maybe get multiple paths? (ad ask user if he wants to backup them to same place)
            'do sanity check before adding (check if already existing?)
            If Not DialogResult = Windows.Forms.DialogResult.OK Then ' makes sure the user clicked on "ok" if not it exists the function
                MessageBox.Show("Restore aborted!")
                Exit Sub
            Else
                'add text to var
                tb_targetdir.Text = fbd_searchRestoretargetpath.SelectedPath.ToString ' later used to restore files

            End If
        End If


        'get selected node
        Dim selectednode As TreeNode = tv_restore.SelectedNode


        'define array used to store all relevant information
        Dim folderIDnodearray As New ArrayList
        Dim datenodearray As New ArrayList
        'calculate according values for each of the read timenodes. (yes VERY ressource intensive)
        For i = 0 To AlltimenodesinTreeviewarray.Count - 1

            Dim timenode As TreeNode
            timenode = AlltimenodesinTreeviewarray(i) '
            'when timenode is known, get the ID (parent node ) 
            folderIDnodearray.Add(timenode.Parent)
            datenodearray.Add(folderIDnodearray(folderIDnodearray.Count - 1).Parent) 'the middle parenthes are to get newly added member of that array (part added last line) 

        Next

        Dim xmlloopctr = 0
        'load xml doc and loop through all nodes
        'store important nodes in an array - later access information out of array. (Needed to calc full paths of all needed files)
        Dim ROXMLDoc As XmlDocument = New XmlDocument()
        ROXMLDoc.Load(home.getexedir() & "\" & "RestoreOverview.xml")
        Dim node As XmlNode
        'descriptionndoe
        node = ROXMLDoc.DocumentElement
        'descriptionndoe
        Dim virtnodelvl0 As XmlNode 'Used for internal loop.
        For Each virtnodelvl0 In node.ChildNodes
            'descriptionndoe
            For Each virtnodelvl1 In virtnodelvl0.ChildNodes
                'dateenode
                For Each virtnodelvl2 As XmlNode In virtnodelvl1.ChildNodes
                    'descriptionndoe

                    For Each virtnodelvl3 As XmlNode In virtnodelvl2.ChildNodes
                        'fpid node

                        For Each virtnodelvl4 As XmlNode In virtnodelvl3.ChildNodes

                            'timenode 
                            'contentnode (all nodes under "time" node


                            'this is the xml node, which contains all data for this dataset
                            For Each infonode As XmlNode In virtnodelvl4.ChildNodes
                                Dim tmpsrc
                                Dim tmptype
                                Select Case infonode.Name
                                    Case "Backup"
                                        tmpsrc = infonode.InnerText 'take backuppath of xml (where files are backed up to) as restore source!
                                        tmpbck = tb_targetdir.Text
                                    Case "Type"

                                        'put time array entry at the ned?

                                        'calculate the part of the treeview path and indrement counter
                                        'forgive me that horroble looking declaration - quick and dirty
                                        Dim fullpath_Treeviewpart = "\" & datenodearray(datenodearray.Count - xmlloopctr - 1).text.substring(1, datenodearray(datenodearray.Count - xmlloopctr - 1).text.length - 1) & "\" & folderIDnodearray(folderIDnodearray.Count - xmlloopctr - 1).text & "\" & AlltimenodesinTreeviewarray(datenodearray.Count - xmlloopctr - 1).text
                                        xmlloopctr += 1


                                        tmptype = infonode.InnerText
                                        If tmptype = "Full" Then 'if It s a full backup, clear the array- currently ALL (Exapnded?) nodes are filled into the array, and then it's cleared each time a "full" backup is detected.
                                            'full backup, no other backups needed, clear arrays and only fill in current entry
                                            relevantsrcarray.Clear()
                                            relevantbckarray.Clear()
                                            relevanttypearray.Clear()

                                            'add the real sourcepath - take  aparth from it of the treeview, and the begginin of the xml
                                            relevantsrcarray.Add(tmpsrc & fullpath_Treeviewpart)
                                            relevantbckarray.Add(tmpbck)
                                            relevanttypearray.Add(tmptype)
                                        Else
                                            'add member to array without reseting it - may be incr(diff so we need to restore them too (the according full backup will already be added to the array)
                                            relevantsrcarray.Add(tmpsrc & fullpath_Treeviewpart)
                                            relevantbckarray.Add(tmpbck)
                                            relevanttypearray.Add(tmptype)
                                            xmlloopctr = 0
                                        End If
                                End Select

                            Next
                        Next
                    Next
                Next
            Next
        Next





        If home.DebugmodeOn = True Then
            Dim logentry1 = "The following Files are restored:"
            Me.Invoke(Ldel, logentry1)

            For i = 0 To relevantsrcarray.Count - 1
                Dim Logentry = ("Src: " & relevantsrcarray(i) & vbNewLine _
                   & "Target: " & relevantbckarray(i) & vbNewLine _
                                & "Type: " & relevanttypearray(i))
                Me.Invoke(Ldel, Logentry)
            Next
        End If
        For i = 0 To relevantsrcarray.Count - 1
            RestoreDirectory(selectednode, relevantsrcarray(i), relevantbckarray(i), relevanttypearray(i), False)

        Next

        MessageBox.Show("Restore completed!", "Restore completed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        home.WriteLogfile(home.getexedir() & home.LogfileFolder & home.Logfilename_Prefix & home.GetDate() & "_" & home.GetTime() & "_Restore.txt", rtb_log, True) 'writes logfile and overwrites axisting ones with the same name

    End Sub


    Public Sub GetallTimenodesoftreeview(ByVal tvn As TreeNode)

        Dim rgx As New Regex("[0-9]{4,4}")
        If tvn.Text.Length >= 4 Then
            If rgx.IsMatch(tvn.Text.Substring(1, 4)) And tvn.Level = 2 Then
                AlltimenodesinTreeviewarray.Add(tvn)
            End If
        End If

        Dim tvNode As TreeNode
        For Each tvNode In tvn.Nodes
            GetallTimenodesoftreeview(tvNode)
        Next
    End Sub

#End Region

#Region "Delegates"
    '*-----------------*'
    '*-----Delegates---*'
    '*-----------------*'

    Private Delegate Sub tvaddmainnodesDelegate(ByVal mainnodename As String)
    Dim Pdel As tvaddmainnodesDelegate = AddressOf addmainnode

    ' declare an implmentation with matching signature
    Private Sub addmainnode(ByVal mainnodename As String)
        Dim Nodetoadd As TreeNode
        Nodetoadd = tv_restore.Nodes.Add(mainnodename, mainnodename)
    End Sub

    Private Delegate Sub tvaddchildnodeDelegate(ByVal Mainnodekey As String, ByVal Childnodename As String)
    Dim Cdel As tvaddchildnodeDelegate = AddressOf addchildnode
    ' declare an implmentation with matching signature
    Private Sub addchildnode(ByVal Mainnodekey As String, ByVal Childnodename As String)
        Dim Nodetomanipulate() As TreeNode
        Nodetomanipulate = tv_restore.Nodes.Find(Mainnodekey, True)
        Nodetomanipulate(0).Nodes.Add(Mainnodekey & Childnodename, Childnodename)
    End Sub

    Private Delegate Sub LogaddEntryDelegate(ByVal Linecontent As String)
    Dim Ldel As LogaddEntryDelegate = AddressOf Logaddentry

    ' declare an implmentation with matching signature
    Private Sub Logaddentry(ByVal Linecontent As String)
        rtb_log.AppendText(Linecontent)
    End Sub

    Private Delegate Sub Toggleloadingcirclestatedelegate(ByVal enabled As Boolean)
    Dim logdel As Toggleloadingcirclestatedelegate = AddressOf Toggleloadingcirclestate

    ' declare an implmentation with matching signature
    Private Sub Toggleloadingcirclestate(ByVal enabled As Boolean)
        If enabled = True Then
            'enable loading circle
            lc_loading_datasets.Visible = True
            lc_loading_datasets.Active = True
            L_status.Text = "Status: Loading Datasets"
            If home.DebugmodeOn = True Then
                rtb_log.AppendText("Started loading available Datasets in background Thread." & vbNewLine)
            End If
        Else
            'disable it
            lc_loading_datasets.Visible = False
            lc_loading_datasets.Active = False
            L_status.Text = "Status: Idle"
            If home.DebugmodeOn = True Then
                rtb_log.AppendText("Finished loading available Datasets in background Thread." & vbNewLine)
            End If
        End If
    End Sub


#End Region

#Region "Workers"
    '*-----------------*'
    '*-----Workers-----*'
    '*-----------------*'

    ' BackgroundWorker Writes settings into XML File
    'This bw_writer is called by the save button directly (no "real" code in the save button sub!)
    Private Sub bw_reload_settings_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_Reload_Settings.DoWork
        'reload settings here - a second worker will do the actual restore

        'incoke gui function to show that SW is doing something
        Me.Invoke(logdel, True)

        'load entries from restoreoverview.xml
        If File.Exists(home.getexedir() & "\RestoreOverview.xml") Then
            Dim myXmlDocument As XmlDocument = New XmlDocument()
            myXmlDocument.Load(home.getexedir() & "\RestoreOverview.xml")

            Dim xmlDatedescnodeNode = myXmlDocument.SelectSingleNode("/Overview/Date")

            'loop through all dates - dispaly them as available dataset

            'each date (the _%date% one )
            For Each datenode As XmlNode In xmlDatedescnodeNode
                Dim datenode_PName = datenode.Name
                Me.Invoke(Pdel, datenode_PName)

                'each Folderpair of that date (_%FPID%)
                For Each fpnode As XmlNode In myXmlDocument.SelectSingleNode("/Overview/Date/" & datenode_PName & "/Folderpair")

                    Dim addeddatenode = fpnode.ParentNode.ParentNode.Name
                    Dim fpnode_Cname = fpnode.Name
                    Me.Invoke(Cdel, addeddatenode, fpnode_Cname)

                    'each time of that folderpair, again the _%time% one
                    For Each fptimenode As XmlNode In myXmlDocument.SelectSingleNode("/Overview/Date/" & datenode_PName & "/Folderpair/" & fpnode_Cname)

                        Dim addedfpnode = fptimenode.ParentNode.Name
                        Dim fptimenode_Cname2 = fptimenode.Name
                        'call delegate with the key of its parent node and its name
                        Me.Invoke(Cdel, addeddatenode & addedfpnode, fptimenode_Cname2)
                    Next

                    'testing only to test if GUI hangs under load
                    Threading.Thread.Sleep(200)

                Next
            Next

        End If

        'incoke gui function to show that SW is doing something
        Me.Invoke(logdel, False)

    End Sub

    Private Sub b_editSource_Click(sender As Object, e As EventArgs) Handles b_editSource.Click

        'Dialog select other Backup Path (Same as in Settings.vb by adding new Folderpair!)
        fbd_edittargetpath.Description = "Change Backup Folder!"
        fbd_edittargetpath.RootFolder = Environment.SpecialFolder.MyComputer
        'do sanity check before adding (check if already existing?)
        If Not fbd_edittargetpath.ShowDialog() = DialogResult.OK Then
            MessageBox.Show("Adding of Folderpair aborted!")
            Exit Sub
        End If

        tb_targetdir.Text = fbd_edittargetpath.SelectedPath.ToString

    End Sub



#End Region


End Class