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
        lc_Restore.InnerCircleRadius = 12
        lc_Restore.OuterCircleRadius = 15
        lc_Restore.SpokeThickness = 3
        lc_Restore.NumberSpoke = 25

        'in the future the following line need to be added to make 
        'the loading circle visible again => (the one commented with '')
        ''lc_Restore.Visible = True
        'activate the "turning" of the circle
        lc_Restore.Active = True

        'call everything which consumes times within a seperate thread (Background worker)
        ' Reload_Settings() '(The function calls the backgroundworker which reloads the settings async)

        'disable the turning again of the "doing something"-indicator
        ' lc_Restore.Active = False
        '   lc_Restore.Visible = False

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

#Region "Workers"
    '*-----------------*'
    '*-----Workers-----*'
    '*-----------------*'

    ' BackgroundWorker Writes settings into XML File
    'This bw_writer is called by the save button directly (no "real" code in the save button sub!)
    Private Sub bw_reload_settings_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_Reload_Settings.DoWork
        'reload settings here - a second worker will do the actual restore

        'first, loop through the backuplist file
        'then if at all needed, loop through the main backupdir. 

        Dim xmlReader As XmlReader = New XmlTextReader(home.getexedir() & home.Settings_Directory & "AvailableRestores.xml")
        ' Loop through XML File
        While (xmlReader.Read())
            Dim type = xmlReader.NodeType
            Dim depth = xmlReader.Depth

            ' Find selected Paths in XML File and write them into Var
            If (type = XmlNodeType.Element) Then
                If (depth = 0) Then ' top level element

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


                End If
            End If

        End While

    End Sub

#End Region


End Class