Imports System.Xml

Public Class Restore

#Region "MainCode"
    '*-----------------*'
    '*----Main Code----*'
    '*-----------------*'

    'executed when form loads
    Private Sub Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dont do heavy coding here
        'load icon wouldnt be displayed!
    End Sub

    'executed when settingsform is fully loaded (and therefore shown to the user)
    Private Sub Restore_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'make the loading circle bigger - seems like gui is bugged (stays small if changed by gui)
        lc_loading_datasets.InnerCircleRadius = 12
        lc_loading_datasets.OuterCircleRadius = 15
        lc_loading_datasets.SpokeThickness = 3
        lc_loading_datasets.NumberSpoke = 25
        'everything else about the loading circle is handlet within the background worker
        'call everything which consumes times within a seperate thread (Background worker)
        Reload_Settings() '(The function calls the backgroundworker which reloads the settings async)


    End Sub


    Function Reload_Settings()
        Try
            bw_Reload_Settings.RunWorkerAsync()
            Return 0
        Catch ex As Exception
            Return -1
        End Try
    End Function



#End Region

#Region "Delegates"
    '*-----------------*'
    '*-----Delegates---*'
    '*-----------------*'
    Private Delegate Sub tvaddmainnodesDelegate(ByVal mainnodename As String)

    ' declare an implmentation with matching signature
    Private Sub addmainnode(ByVal mainnodename As String)
        Dim Nodetoadd As TreeNode
        Nodetoadd = tv_restore.Nodes.Add(mainnodename, mainnodename)
    End Sub

    Private Delegate Sub tvaddchildnodeDelegate(ByVal Mainnodename As String, ByVal Childnodename As String)
    ' declare an implmentation with matching signature
    Private Sub addchildnode(ByVal Mainnodename As String, ByVal Childnodename As String)
        Dim Nodetomanipulate() As TreeNode
        Nodetomanipulate = tv_restore.Nodes.Find(Mainnodename, True)
        Nodetomanipulate(0).Nodes.Add(Childnodename)
    End Sub

    Private Delegate Sub LogaddEntryDelegate(ByVal Linecontent As String)

    ' declare an implmentation with matching signature
    Private Sub Logaddentry(ByVal Linecontent As String)
        rtb_log.AppendText(Linecontent)
    End Sub

    Private Delegate Sub Toggleloadingcirclestatedelegate(ByVal enabled As Boolean)

    ' declare an implmentation with matching signature
    Private Sub Toggleloadingcirclestate(ByVal enabled As Boolean)
        If enabled = True Then
            'enable loading circle
            lc_loading_datasets.Visible = True
            lc_loading_datasets.Active = True
            L_status.Text = "Status: Loading Datasets"
        Else
            'disable it
            lc_loading_datasets.Visible = False
            lc_loading_datasets.Active = False
            L_status.Text = "Status: Idle"
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

        'for now generate dummy entries
        'use delegates to update GUI or program will crash

        'first set loading indicator active
        Dim loadingenabled = True
        Dim logdel As Toggleloadingcirclestatedelegate = AddressOf Toggleloadingcirclestate
        Me.Invoke(logdel, loadingenabled)


        Dim Parentnodename = "2015-01-30"
        Dim Pdel As tvaddmainnodesDelegate = AddressOf addmainnode
        Me.Invoke(Pdel, Parentnodename)

        Dim chilnodename = "Sourcefolder1"
        Dim Cdel As tvaddchildnodeDelegate = AddressOf addchildnode
        Me.Invoke(Cdel, Parentnodename, chilnodename)

        Dim Logentry = "Dummyentry 1 added successfully" & vbNewLine
        Dim Ldel As LogaddEntryDelegate = AddressOf Logaddentry
        Me.Invoke(Ldel, Logentry)


        System.Threading.Thread.Sleep(15000)


        Parentnodename = "2014-06-30"
        Me.Invoke(Pdel, Parentnodename)

        chilnodename = "Sourcefolder2"
        Me.Invoke(Cdel, Parentnodename, chilnodename)
        Logentry = "Dummyentry 2 added successfully" & vbNewLine
        Me.Invoke(Ldel, Logentry)


        System.Threading.Thread.Sleep(15000)


        Parentnodename = "2013-06-16"
        Me.Invoke(Pdel, Parentnodename)

        chilnodename = "Sourcefolder1"
        Me.Invoke(Cdel, Parentnodename, chilnodename)
        Logentry = "Dummyentry 3 added successfully" & vbNewLine
        Me.Invoke(Ldel, Logentry)

        'inactive loading circle again
        loadingenabled = False
        Me.Invoke(logdel, loadingenabled)


        'first, loop through the backuplist file
        'then if at all needed, loop through the main backupdir. 

        '' Dim xmlReader As XmlReader = New XmlTextReader(home.getexedir() & home.Settings_Directory & "AvailableRestores.xml")
        ' Loop through XML File
        ''  While (xmlReader.Read())
        '' Dim type = xmlReader.NodeType
        '' Dim depth = xmlReader.Depth

        ' Find selected Paths in XML File and write them into Var
        ''If (type = XmlNodeType.Element) Then
        ''If (depth = 0) Then ' top level element

        'i thought a bit and i think - 

        ' we would need to store MAC+Sourcepath in a File.
        'basically keep a list of all backups ever made.
        'But I guess it makes more sense, to only store it in the backupdir.
        'keep a list of all backups within that directory and update it accordingly.
        'Also folders will be named criptically (with short numbers)
        'too keep the char count short. 
        '(then it will be written in the availablerestore.xml where to get the restore from
        'we just need tos tore the original source/Destination/sourcepc and the current source to restore it from)
        'If we store a List of all backups made in a list - we laso don't need an ID I guess. we can just store as much information as we want in the xml
        'we can loop through the file to get the information back.


        ''   End If
        '' End If

        ''  End While

    End Sub


#End Region


End Class