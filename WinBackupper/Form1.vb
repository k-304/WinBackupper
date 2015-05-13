Public Class home

#Region "Variables"  'maybe wanted?
    '*-----------------*'
    '*----Variables----*'
    '*-----------------*'
    Dim sourcePath As String
    Dim backupPath As String
    Dim defaultSourcePath As String
    Dim defaultBackupPath As String
#End Region

    '*-----------------*'
    '*----Main Code----*'
    '*-----------------*'

    ' Main Form
    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' TextBox for Source Path
    Private Sub tb_sourcePath_TextChanged(sender As Object, e As EventArgs) Handles tb_sourcePath.TextChanged
        'maybe check for max. character count to prevent possible overflow's? (if there are any)
    End Sub

    'Button 'update' - executed on click
    Private Sub b_update_Click(sender As Object, e As EventArgs) Handles b_update.Click
        'enter "try" to stop application from breaking totaly if an error occurs. (most of the times)
        Try
            'try to start the updater
            Diagnostics.Process.Start(getexedir() & "/THC_Updater.exe") 'assumes that updater exe is in same path as calling exe
        Catch ex As Exception

        End Try
    End Sub

    'Function to get Directory of current .exe-file
    Private Function getexedir()
        Dim path As String
        path = System.IO.Path.GetDirectoryName( _
           System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Return path.Substring(6, path.Length - 6)
    End Function

    ' Button Search Source Path
    Private Sub b_searchSource_Click(sender As Object, e As EventArgs) Handles b_searchSource.Click
        ' Dialog to select Backup Path
        fbd_searchSource.Description = "Select Folder"
        fbd_searchSource.RootFolder = Environment.SpecialFolder.LocalizedResources 'maybe start in "computers" directly, so user can choose partitions directly (1 click less)
        DialogResult = fbd_searchSource.ShowDialog
        sourcePath = fbd_searchSource.SelectedPath.ToString

        ' Show Path in TextBox
        Do
            tb_sourcePath.Text = sourcePath
        Loop While Not tb_sourcePath.Text = sourcePath
    End Sub

    ' FolderBrowserDialog to select Source Path
    Private Sub fbd_searchSource_HelpRequest(sender As Object, e As EventArgs) Handles fbd_searchSource.HelpRequest

    End Sub

    ' TextBox for Backup Path
    Private Sub tb_backupPath_TextChanged(sender As Object, e As EventArgs) Handles tb_backupPath.TextChanged

    End Sub

    ' Button Search Backup Path
    Private Sub b_searchBackup_Click(sender As Object, e As EventArgs) Handles b_searchBackup.Click
        ' Dialog to select Backup Path
        fbd_searchBackup.Description = "Select Folder"
        fbd_searchBackup.RootFolder = Environment.SpecialFolder.LocalizedResources
        DialogResult = fbd_searchBackup.ShowDialog
        backupPath = fbd_searchBackup.SelectedPath.ToString

        ' Show Path in TextBox
        Do
            tb_backupPath.Text = backupPath
        Loop While Not tb_backupPath.Text = backupPath
    End Sub

    ' FolderBrowserDialog to select Backup Path
    Private Sub fbd_searchBackup_HelpRequest(sender As Object, e As EventArgs) Handles fbd_searchBackup.HelpRequest

    End Sub

    ' Button Start Backup
    Private Sub b_start_Click(sender As Object, e As EventArgs) Handles b_start.Click
        'Confirm & Start Backup-Progress
        Dim startResult = MessageBox.Show("Backingup from " + sourcePath + " to " + backupPath + " ? ", "Continue?", MessageBoxButtons.YesNo)
        If startResult = Windows.Forms.DialogResult.Yes Then
            MessageBox.Show("Starting Backup!")
            ' Backup 
            ' Code
            ' here
        ElseIf startResult = Windows.Forms.DialogResult.No Then
            MessageBox.Show("Cancled Backup!")
        End If
    End Sub

    ' Button open Settings
    Private Sub b_settings_Click(sender As Object, e As EventArgs) Handles b_settings.Click
        Settings.Show()
    End Sub

    '*-----------------*'
    '*-----Workers-----*'
    '*-----------------*'

End Class
