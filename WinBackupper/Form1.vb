Imports System.Xml
Imports System.IO

Public Class home

#Region "Variables"
    '*-----------------*'
    '*----Variables----*'
    '*-----------------*'
    Dim sourcePath As String
    Dim backupPath As String
    Dim defaultSourcePath As String
    Dim defaultBackupPath As String
#End Region

#Region "MainCode"
    '*-----------------*'
    '*----Main Code----*'
    '*-----------------*'

    ' Main Form
    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check if there is a "default.xml" File
        If Not Dir("default.xml") = "" Then
            ' Read XML File to load defaults
            Dim xmlReader2 As XmlReader = New XmlTextReader("default.xml")

            ' Loop through XML File
            While (xmlReader2.Read())
                Dim type = xmlReader2.NodeType

                ' Find selected Paths in XML File and write them into Var
                If (type = XmlNodeType.Element) Then
                    ' Looking for "Source" Path
                    If (xmlReader2.Name = "Source") Then
                        sourcePath = xmlReader2.ReadInnerXml.ToString
                        tb_sourcePath.Text = sourcePath.ToString
                    End If
                    'Looking for "Backup" Path
                    If (xmlReader2.Name = "Backup") Then
                        backupPath = xmlReader2.ReadInnerXml.ToString
                        tb_backupPath.Text = backupPath.ToString
                    End If
                End If

            End While
            xmlReader2.Close()
        End If
    End Sub

    ' TextBox for Source Path
    Private Sub tb_sourcePath_TextChanged(sender As Object, e As EventArgs) Handles tb_sourcePath.TextChanged
        'maybe check for max. character count to prevent possible overflow's? (if there are any)
    End Sub

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
            '  MessageBox.Show("Starting Backup!")

            ' Backup 
            ' Code
            ' here
            BackupDirectory("Sourcepath", "targetpath", False) 'more arguments can be added like incremental/not etc...

        ElseIf startResult = Windows.Forms.DialogResult.No Then
            '  MessageBox.Show("Cancled Backup!")
        End If
    End Sub

    'backup function - accepting different arguments - called in "backup start button"
    Private Function BackupDirectory(sourcepath As String, targetpath As String, simulate_mode_active As Boolean)
        'check if "path" is contained in exeptions, if so abort!
        '(Subdirs will be deleted with the same function, so this check will include them!)

        'get exeption lists
        Dim exelist As New ArrayList
        'Set #Exeptions
        Dim execount = exelist.Count

        Try
            If (exelist.Contains(sourcepath)) Then
                'LOGGING file is on exe list!
                'If Loginfocheckbox.Checked = True Then
                'LogRichTextBox.AppendText("INFO: Directory: " & path & " wasnot deleted because of exeption list" & vbNewLine)
                ' End If
            Else
                'LOGGIGN file is processed
                '   If Logdetailedinfocheckbox.Checked = True Then
                'LogRichTextBox.AppendText("DETINFO: Directory: " & path & " is being processed..." & vbNewLine)
                ' End If
                If Directory.Exists(sourcepath) Then

                    'Delete all files from the Directory
                    For Each filepath As String In Directory.GetFiles(sourcepath)

                        'implemented a counter to fix Bug ->
                        'Files got deleted on root folder, but not on excluded subfolders.
                        'they even got deleted, if excluded because of this bug!
                        'yeah... this happens when you code late at night, i should have seen this in the beggining
                        '
                        'check with counter if for-each is checking last Exception 

                        ''''IMPORTANT''''
                            Dim deskctr = 0
                        For Each exe As String In exelist
                            deskctr = deskctr + 1
                            If filepath.Contains(exe) Then
                                'File is within excluded folder DONT DELETE!
                                '  If Loginfocheckbox.Checked = True Then
                                'LogRichTextBox.AppendText("INFO: File: " & filepath & " wasnot deleted because of exeption list" & vbNewLine)
                                ' End If
                            Else
                                'file is not in excluded folder, delete!
                                ' If Logdetailedinfocheckbox.Checked = True Then
                                'LogRichTextBox.AppendText("DETINFO: File: " & filepath & " is being processed..." & vbNewLine)
                            End If
                            Try
                                If (deskctr = execount) Then
                                    If simulate_mode_active = False Then
                                        'if simulate mode is on, only log!!! DONT DELETE!
                                        File.Delete(filepath)
                                    End If
                                End If
                            Catch ex As Exception
                                'if single files fail - maybe make a list? How do we log?
                            End Try

                        Next 'Desk clean "for each" end

                    Next 'for each filepath end

                    'BAckup all child Directories
                    For Each dir As String In Directory.GetDirectories(sourcepath)
                        'calculate the relative path
                        Dim relpath As String = dir.Substring(sourcepath.Length, dir.Length - sourcepath.Length)
                        MessageBox.Show("DEBUG relpath:" & relpath)
                        'call routine to delete subfiles
                        If simulate_mode_active = True Then
                            BackupDirectory(dir, targetpath & relpath, True)
                        Else
                            BackupDirectory(dir, targetpath & relpath, False)
                        End If
                        If simulate_mode_active = False Then
                            '
                            'Copy/Backup the current file here!
                            '
                            For Each filepath As String In Directory.GetFiles(dir)
                                'copy to "targetpath & relpath" => to keep folder structure
                            Next
                        End If
                    Next
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("WARNING: Critical error while 'BackupDirectory'-function")
        End Try
    End Function

    ' Button open Settings
    Private Sub b_settings_Click(sender As Object, e As EventArgs) Handles b_settings.Click
        Settings.Show()
    End Sub

    'Button Update - executed on click
    Private Sub b_update_Click(sender As Object, e As EventArgs) Handles b_update.Click
        'enter "try" to stop application from breaking totaly if an error occurs. (most of the times)
        Try
            'try to start the updater
            Diagnostics.Process.Start(getexedir() & "/THC_Updater.exe") 'assumes that updater exe is in same path as calling exe
        Catch ex As Exception

        End Try
    End Sub

    Function GetDate() As String
        Dim day = DateTime.Today.ToString("dd")
        Dim month = DateTime.Today.ToString("MM")
        Dim year = DateTime.Today.ToString("yyyy")
        Return (year & month & day)
    End Function

    'function to get an array out of long seperated string like "nr1;nr2;nr3;nr4...."
    'use like "  dim array nrarray = stringtoarray("nr1;nr2;nr3",";")     "
    Function StringtoArray(seperatedmultistring As String, seperator As String) As ArrayList
        'reset returnarray if it s not null (redim it with 0 members)
        Dim returnarray As New ArrayList
        '  ReDim returnarray(-1)
        ' ReDim returnarray(0)
        'set counter
        Dim Charsalreadyscanned = 0
        'make temp var to not change original input var
        Dim tempstring = seperatedmultistring

        Dim foundwords = 0
        For i = 0 To seperatedmultistring.ToString.Length Step 1
            If (seperatedmultistring.ToString.Length = 0) Then
                'empty string was given, reutrn null
                Throw New ArgumentException("Array is null (not set yet)")
            End If
            If (i = seperatedmultistring.ToString.Length) Then
                Exit For
            End If

            'check if current char is ";"
            If (seperatedmultistring.ToString.Substring(i, 1) = seperator) Then
                'seperator sign found
                Dim scannedtext = tempstring.ToString.Substring(Charsalreadyscanned, i - Charsalreadyscanned)
                Dim temparraymember = scannedtext.Substring(0, scannedtext.Length)
                Charsalreadyscanned = Charsalreadyscanned + scannedtext.Length + 1
                returnarray.Add(temparraymember)
                foundwords = foundwords + 1
            End If
        Next
        Return returnarray
    End Function

    'Function to get Directory of current .exe-file
    Private Function getexedir()
        Dim path As String
        path = System.IO.Path.GetDirectoryName( _
           System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Return path.Substring(6, path.Length - 6)
    End Function

#End Region

#Region "Workers"
    '*-----------------*'
    '*-----Workers-----*'
    '*-----------------*'
#End Region

End Class
