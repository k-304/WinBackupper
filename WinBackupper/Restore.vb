Imports System.Xml
Imports System.IO

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
            While bw_Reload_Settings.IsBusy
                Application.DoEvents()
            End While
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

        Dim Logentrystart = "Started loading available Datasets in background Thread." & vbNewLine
        Me.Invoke(Ldel, Logentrystart)


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
                Next
            Next

        End If

        Dim Logentryfinished = "Finished loading available Datasets in background Thread." & vbNewLine
        Me.Invoke(Ldel, Logentryfinished)



    End Sub


#End Region


End Class