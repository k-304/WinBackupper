Imports System.Xml
Imports System.IO

Public Class Restore
#Region "Global Var's"
    '*-----------------*'
    '*----Global Var's----*'
    '*-----------------*'

    Dim alreadyloadednodes As New ArrayList

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


    Private Sub b_startrestore_Click(sender As Object, e As EventArgs) Handles b_startrestore.Click
        'get selected node.

        'calculate fullpath for sourcefile

        'use "restore_Directory" function to restore files (Copy&paste of backup dir function)

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