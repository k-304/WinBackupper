Imports System.Xml

Public Class Settings

    '*-----------------*'
    '*----Variables----*'
    '*-----------------*'

    Dim defaultSourcePath As String
    Dim defaultBackupPath As String
    Dim tempSourcePath As String
    Dim tempBackupPath As String

    '*-----------------*'
    '*----Main Code----*'
    '*-----------------*'

    ' Settings Form
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' TextBox for default Source Path
    Private Sub tb_defaultSourcePath_TextChanged(sender As Object, e As EventArgs) Handles tb_defaultSourcePath.TextChanged

    End Sub

    ' Button Search default Source Path
    Private Sub b_searchDefaultSource_Click(sender As Object, e As EventArgs) Handles b_searchDefaultSource.Click
        ' Dialog to select Backup Path
        fbd_searchDefaultSource.Description = "Select Folder"
        fbd_searchDefaultSource.RootFolder = Environment.SpecialFolder.LocalizedResources
        DialogResult = fbd_searchDefaultSource.ShowDialog
        defaultSourcePath = fbd_searchDefaultSource.SelectedPath.ToString

        ' Show Path in TextBox
        Do
            tb_defaultSourcePath.Text = defaultSourcePath
        Loop While Not tb_defaultSourcePath.Text = defaultSourcePath
    End Sub

    ' FolderBrowserDialog to select default Source Path
    Private Sub fbd_searchDefaultSource_HelpRequest(sender As Object, e As EventArgs) Handles fbd_searchDefaultSource.HelpRequest

    End Sub

    ' TextBox for default Backup Path
    Private Sub tb_defaultBackupPath_TextChanged(sender As Object, e As EventArgs) Handles tb_defaultBackupPath.TextChanged

    End Sub

    ' Button Search default Backup Path
    Private Sub b_searchDefaultBackup_Click(sender As Object, e As EventArgs) Handles b_searchDefaultBackup.Click
        ' Dialog to select Backup Path
        fbd_searchDefaultBackup.Description = "Select Folder"
        fbd_searchDefaultBackup.RootFolder = Environment.SpecialFolder.LocalizedResources
        DialogResult = fbd_searchDefaultBackup.ShowDialog
        defaultBackupPath = fbd_searchDefaultBackup.SelectedPath.ToString

        ' Show Path in TextBox
        Do
            tb_defaultBackupPath.Text = defaultBackupPath
        Loop While Not tb_defaultBackupPath.Text = defaultBackupPath
    End Sub

    ' FolderBrowserDialog to select default Backup Path
    Private Sub fbd_searchDefaultBackup_HelpRequest(sender As Object, e As EventArgs) Handles fbd_searchDefaultBackup.HelpRequest

    End Sub

    ' Button Save defaults to own XML File
    Private Sub b_save_Click(sender As Object, e As EventArgs) Handles b_save.Click
        bw_writer.RunWorkerAsync()
    End Sub

    '*-----------------*'
    '*-----Workers-----*'
    '*-----------------*'

    ' BackgroundWorker Writes settings into XML File
    Private Sub bw_writer_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_writer.DoWork
        ' Create XML Writer
        Dim writerOption As New XmlWriterSettings
        writerOption.Indent = True
        Dim writerSettings As XmlWriter = XmlWriter.Create("default.xml", writerOption)

        With writerSettings
            .WriteStartDocument()
            .WriteStartElement("defaults")

            .WriteStartElement("Source")
            .WriteString(defaultSourcePath)
            .WriteEndElement()

            .WriteStartElement("Backup")
            .WriteString(defaultBackupPath)
            .WriteEndElement()

            .WriteEndElement()
            .WriteEndDocument()

            .Close()
        End With

        ' Read XML File to check if it was written
        Dim xmlReader As XmlReader = New XmlTextReader("default.xml")

        ' Loop through XML File
        While (xmlReader.Read())
            Dim type = xmlReader.NodeType

            ' Find selected Paths in XML File and write them into Var
            If (type = XmlNodeType.Element) Then
                ' Looking for "Source" Path
                If (xmlReader.Name = "Source") Then
                    tempSourcePath = xmlReader.ReadInnerXml.ToString
                End If
                'Looking for "Backup" Path
                If (xmlReader.Name = "Backup") Then
                    tempBackupPath = xmlReader.ReadInnerXml.ToString
                End If
            End If

        End While
        
        If (defaultSourcePath = tempSourcePath) And (defaultBackupPath = tempBackupPath) Then
            MessageBox.Show("Paths saved!")
        Else
            MessageBox.Show("Unable to save Paths!", "Error")
        End If
    End Sub
End Class