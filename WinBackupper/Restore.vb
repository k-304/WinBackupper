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
        lc_loading_datasets.NumberSpoke = 35

        lc_restore_active.InnerCircleRadius = 12
        lc_restore_active.OuterCircleRadius = 15
        lc_restore_active.SpokeThickness = 3
        lc_restore_active.NumberSpoke = 35

        'everything else about the loading circle is handlet within the background worker
        'call everything which consumes times within a seperate thread (Background worker)
        bw_Reload_Settings.RunWorkerAsync()
        While bw_Reload_Settings.IsBusy
            Application.DoEvents()
        End While


    End Sub

    Private Function RestoreDirectory(ByRef selectednode As TreeNode, ByVal sourcepath As String, ByVal targetpath As String, ByVal FPID As String, ByVal backuptype As String, Optional simulate_mode_active As Boolean = True)

        Try
            For Each filepath In Directory.GetFiles(sourcepath)

                Try
                    Dim processname As String = "robocopy.exe"
                    Dim filestocopy As String = "*.*" 'used in the robocopy command to only copy that file
                    Dim ARGFull As String = "/A-:A"
                    Dim ARGdifferential As String = "/A"
                    Dim ARGincremental As String = "/M"

                    Dim Proc As New System.Diagnostics.Process
                    Proc.StartInfo = New ProcessStartInfo("C:\Windows\System32\cmd.exe")
                    Proc.StartInfo.UseShellExecute = False
                    Proc.StartInfo.CreateNoWindow = True

                    Select Case backuptype
                        Case "full"
                            'do backup logic for full backup
                            'no need to restore multiple datasets
                            'only copy all files of this source to the target dir
                            Proc.StartInfo.Arguments = "/C " & processname & " " & currentlyselectedtreenode_Fullsourcepath & " " _
                                                        & currentlyselectedtreenode_Fulltargetpath & " " & filestocopy & " " & ARGFull

                        Case "Incr"

                            'copy all files of this incremental, and all last incremental backups (up to the last full backup)
                            ' - maybe check which backup Is the full first - And then copy full backup first. (reverse order - to overwrite files ocrrectly

                            'get all time nodes -get a backuptype node (name) first - then take the parent of it. 
                            'take parent again and its the "_0" node (FOID NodE) - from there, select the last available time, check the backuptype.
                            'repeat until all needed Nodes are found.
                            For Each tnode As TreeNode In selectednode.Parent.Nodes
                                If tnode.Name = "backuptype" Then
                                    'get parent parent node
                                    Dim overviewnode = tnode.Parent.Parent
                                    Dim timenode = tnode.Parent
                                    Dim nextnode = timenode.NextNode
                                    For Each tnode2 As TreeNode In nextnode.Nodes
                                        If tnode2.Name = "backuptype" Then
                                            If tnode2.Text = "Full" Then
                                                'full backup found - if not repeat until found. 

                                            End If
                                        End If
                                    Next

                                End If
                            Next
                        Case "Diff"
                            'copy all files of this differential, and ONLY the files of the last Full!
                    End Select

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
                        Dim Logentry = "The following File could not be backed-up - is it opened? Errorcode:" & exitcode & vbNewLine & filepath & vbNewLine
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
                    RestoreDirectory(selectednode, dir, targetpath & relpath, FPID, True, backuptype)
                Else
                    RestoreDirectory(selectednode, dir, targetpath & relpath, FPID, False, backuptype)
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
                Logaddentry(home.GetDate & "Start loading of available Datasets of the following path:" & fulldir & vbNewLine)
                loaddatasetintotreeview(e.Node, folderpairIDtoedit)
                Logaddentry(home.GetDate & "Finished loading of available Datasets of the following path:" & fulldir & vbNewLine)
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

        If tv_restore.SelectedNode Is Nothing Then
            MsgBox("No node selected")
            Exit Sub
        End If
        If tb_targetdir.Text = "" Then
            'ask user to provide targetpath. (ask with dialogbox instead of aborting) 
            MsgBox("No targetpath selected")
            Exit Sub
        End If
        'get backuptype - therefore get Parent time node     
        Dim selectednode As TreeNode = tv_restore.SelectedNode
        Dim timeparentnode As TreeNode

        'get timenode
        Dim timenodefound As Boolean = False
        Dim virtualloopnode As TreeNode = selectednode
        Dim timenode As TreeNode
        While timenodefound = False

            'loop thorugh all parent nodes to find the timenode
            'this is the node clicked on, when loading the dataset
            'it's a known refernece point to navigate further
            'utilize the level property of nodes to determin if it's a usercreated folder or ours.
            'not htat the user has a "_####" folder too. (where #### stands for random numbers)          
            Dim rgx As New Regex("[0-9]{4,4}")
            If virtualloopnode.Text.Length >= 4 Then
                If rgx.IsMatch(virtualloopnode.Text.Substring(1, 4)) And virtualloopnode.Level = 2 Then
                    'check with regex expression and node level if its our time node
                    timenode = virtualloopnode
                    timenodefound = True
                End If
            End If

            virtualloopnode = virtualloopnode.Parent
        End While

        'when timenode is known, get the ID (parent node ) 
        Dim folderidnode = timenode.Parent
        Dim datenode = folderidnode.Parent
        'then get the needed information out of restoreoverview.xml
        'fill according overview variables if mutiple backups are needed




        Dim ROXMLDoc As XmlDocument = New XmlDocument()
        ROXMLDoc.Load(home.getexedir() & "\" & "RestoreOverview.xml")
        Dim node As XmlNode
        node = ROXMLDoc.DocumentElement
        'descriptionndoe
        Dim virtnodelvl0 As XmlNode 'Used for internal loop.
        'descriptionndoe
        For Each virtnodelvl0 In node.ChildNodes
            'descriptionndoe
            For Each virtnodelvl1 In virtnodelvl0.ChildNodes
                'descriptionndoe
                For Each virtnodelvl2 As XmlNode In virtnodelvl1.ChildNodes
                    'dateenode
                    For Each virtnodelvl3 As XmlNode In virtnodelvl2.ChildNodes
                        'descriptionndoe
                        For Each virtnodelvl4 As XmlNode In virtnodelvl3.ChildNodes
                            'fpid node

                            If virtnodelvl4.Name = timenode.Text Then
                                'timenode

                                'this is the xml node, which contains all data for this dataset
                                For Each infonode As XmlNode In virtnodelvl4.ChildNodes
                                    Dim tmpsrc
                                    Dim tmpbck
                                    Dim tmptype
                                    Select Case infonode.Name
                                        Case "Source"
                                            tmpsrc = infonode.InnerText
                                        Case "Backup"
                                            tmpbck = infonode.InnerText
                                        Case "Type"
                                            tmptype = infonode.InnerText
                                            If tmptype = "Full" Then
                                                'full backup, no other backups needed, clear arrays and only fill in current entry
                                                relevantsrcarray.Clear()
                                                relevantbckarray.Clear()
                                                relevanttypearray.Clear()
                                                relevantsrcarray.Add(tmpsrc)
                                                relevantbckarray.Add(tmpbck)
                                                relevanttypearray.Add(tmptype)
                                            Else
                                                'add member to array without reseting it
                                                relevantsrcarray.Add(tmpsrc)
                                                relevantbckarray.Add(tmpbck)
                                                relevanttypearray.Add(tmptype)
                                            End If
                                    End Select

                                Next
                            Else
                                'is not current timenode, but maybe a relevant one (backup before the selected one -save if in array
                                'reset array everytime a "full" backup is reached - only backups since last full until selected are store din array
                                For Each infonode2 As XmlNode In virtnodelvl4.ChildNodes
                                    Select Case infonode2.Name
                                        Case "Source"
                                            relevantsrcarray.Add(infonode2.InnerText)
                                        Case "Backup"
                                            relevantbckarray.Add(infonode2.InnerText)
                                        Case "Type"
                                            'if full reset array and only store current entry (full has to be ina rray to)
                                            If infonode2.InnerText = "Full" Then
                                                Dim currentsrcentry = relevantsrcarray(relevantsrcarray.Count - 1) 'last member
                                                Dim currentbckentry = relevantbckarray(relevantsrcarray.Count - 1) 'last member
                                                relevantsrcarray.Clear()
                                                relevantbckarray.Clear()
                                                relevanttypearray.Clear()
                                                relevantsrcarray.Add(currentsrcentry)
                                                relevantbckarray.Add(currentbckentry)
                                                relevanttypearray.Add(infonode2.InnerText)
                                            Else
                                                'add member to array without reseting it
                                                relevanttypearray.Add(infonode2.InnerText)
                                            End If

                                    End Select
                                Next
                            End If

                        Next
                    Next
                Next
            Next
        Next


        For i = 0 To relevantsrcarray.Count - 1
            MessageBox.Show("Src: " & relevantsrcarray(i) & vbNewLine _
                            & "Type: " & relevanttypearray(i))
        Next

        '    RestoreDirectory(selectednode, currentlyselectedtreenode_Fullsourcepath, currentlyselectedtreenode_Fulltargetpath, currentlyselectedtreenode_FolderpairID, backuptype, False)
        'backuptype, full source and targetpath needed
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
            rtb_log.AppendText("Started loading available Datasets in background Thread." & vbNewLine)
        Else
            'disable it
            lc_loading_datasets.Visible = False
            lc_loading_datasets.Active = False
            L_status.Text = "Status: Idle"
            rtb_log.AppendText("Finished loading available Datasets in background Thread." & vbNewLine)
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



#End Region


End Class