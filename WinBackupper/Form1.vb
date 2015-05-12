Public Class home

    '*-----------------*'
    '*----Variables----*'
    '*-----------------*'
    Dim sourcePath As String
    Dim backupPath As String
    Dim defaultSourcePath As String
    Dim defaultBackupPath As String

    '*-----------------*'
    '*----Main Code----*'
    '*-----------------*'

    ' Main Form
    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' TextBox for Source Path
    Private Sub tb_sourcePath_TextChanged(sender As Object, e As EventArgs) Handles tb_sourcePath.TextChanged

    End Sub

    ' Button Search Source Path
    Private Sub b_searchSource_Click(sender As Object, e As EventArgs) Handles b_searchSource.Click
        ' Dialog to select Backup Path
        fbd_searchSource.Description = "Select Folder"
        fbd_searchSource.RootFolder = Environment.SpecialFolder.LocalizedResources
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

        ' Show Path in TextBox
        Do
            tb_backupPath.Text = fbd_searchBackup.SelectedPath.ToString
            backupPath = tb_backupPath.Text
        Loop While backupPath = Nothing
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
