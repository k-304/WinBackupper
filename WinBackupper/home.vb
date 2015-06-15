Imports System.IO
Imports System.IO.Compression
Imports System.Xml

Public Class home

#Region "Variables"
    '*------------------------*'
    '*----Global Variables----*'
    '*------------------------*'
    Public Shared sourcepatharray As New ArrayList 'public array so other form can access it too
    Public Shared backupPatharray As New ArrayList 'public array so other form can access it too
    Public Shared timesettingsarray As New ArrayList 'public array filled by timetable.vb on formclosed event...
    ' use this (timesettingsarray) to save the data or use it. (also populate in in the home form in the load event)
    Dim version As String
    Public GlobalSeperator As String = ";" 'used to seperate strings if ever needed
    Public starttime As String 'used later to store datetime of start event (currently in the click function - if automated we 
    Public silent As Boolean = False
#End Region

#Region "MainCode"
    '*-----------------*'
    '*----Main Code----*'
    '*-----------------*'

    ' Main Form
    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'attention! "count" gives a locigal "human" value, but info is stored in an array which begins from 0
        Try
            If Environment.GetCommandLineArgs.Count <> 1 Then
                If Environment.GetCommandLineArgs.Count = 2 Then
                    'check if second argument is "-silent" "/silent", "/s" or "-s"
                    'if argument is supplied -hide forms!
                    Dim var = Environment.GetCommandLineArgs(1)
                    If var = "-silent" Or var = "-s" Or var = "/s" Or var = "/silent" Then
                        'not sure how to hide correctly yet - just testing. (this is to run silent at each startup - so user is not annoyed by he form popping up all the time
                        silent = True
                        ' Me.Visible = False
                        'Settings.Visible = False
                    End If
                End If
            End If

            ' Shows actual Version-Number from "Prokect -> Properties... -> Application -> Assambly Information..."
            l_version.Text = "Version: " + My.Application.Info.Version.ToString()
            version = My.Application.Info.Version.ToString()
            bw_versionControll.RunWorkerAsync() ' Start BW to write Version into XML File, see #Workers

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
                            sourcepatharray.Add(xmlReader2.ReadInnerXml.ToString)
                        End If
                        'Looking for "Backup" Path
                        If (xmlReader2.Name = "Backup") Then
                            backupPatharray.Add(xmlReader2.ReadInnerXml.ToString)
                        End If
                        If (xmlReader2.Name = "StartTimes") Then
                            home.timesettingsarray.Add(xmlReader2.ReadInnerXml.ToString)
                        End If
                    End If

                End While
                'close reader to prevent file IO Exceptions
                xmlReader2.Close()
                xmlReader2.Dispose()

                'show settings in GUI
                Reload_settings()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function Reload_settings()
        'loop through all source/dest. path's (Display in form Richtextbox)
        For i = 0 To sourcepatharray.Count - 1 Step 1
            'also fill RTB_Source! (richtextbox)
            Me.RTB_Sourcepath.AppendText(sourcepatharray(i) & vbNewLine)
            'also fill RTB_Backup! (richtextbox)
            Me.RTB_Backuppath.AppendText(backupPatharray(i) & vbNewLine)
        Next
    End Function

    'copy of settings function - no way found to ference it =(
    Public Function RTB_SP_Clicked(sender As Object, e As MouseEventArgs)
        Try
            If home.sourcepatharray.Count = 0 Then
                Return -1
            End If
            'get mouseposition
            Dim rtb = DirectCast(sender, RichTextBox)
            'then get the char where the mouse is
            Dim index = rtb.GetCharIndexFromPosition(e.Location)
            'get the line where this char is (with it's index in the char array of the rtb)
            Dim line = rtb.GetLineFromCharIndex(index)
            'define the first char of line
            Dim lineStart = rtb.GetFirstCharIndexFromLine(line)
            'define the last one
            Dim lineEnd = rtb.GetFirstCharIndexFromLine(line + 1) - 1
            'start selection
            rtb.SelectionStart = lineStart
            'define the length of it
            rtb.SelectionLength = lineEnd - lineStart
            'define color to set
            Dim tempselectionfont
            If (rtb.SelectionFont.Style = FontStyle.Regular) Then
                tempselectionfont = New Font(rtb.SelectionFont, FontStyle.Bold)
            Else
                tempselectionfont = New Font(rtb.SelectionFont, FontStyle.Regular)
            End If
            rtb.SelectionFont = tempselectionfont
            'after that,make shure to make same with other rtb's to select similar entries! (at least in backuppathrtb too - time rtb can be ignored)
            Dim Backuppathrtb = DirectCast(RTB_Backuppath, RichTextBox)
            'repeat above steps for other rtbox...
            Dim backupline = Backuppathrtb.GetLineFromCharIndex(index)
            'define the first char of line
            Dim sourcelineStart = Backuppathrtb.GetFirstCharIndexFromLine(backupline)
            'define the last one
            Dim sourcelineEnd = Backuppathrtb.GetFirstCharIndexFromLine(backupline + 1) - 1
            'start selection => seems not to work well with 2 boxes at the same time (only marks blue in one)
            'now try to make it bold - maybe it0s enough
            Backuppathrtb.SelectionStart = sourcelineStart
            'define the length of it
            Backuppathrtb.SelectionLength = sourcelineEnd - sourcelineStart
            'define color to set
            If (Backuppathrtb.SelectionFont.Style = FontStyle.Regular) Then
                tempselectionfont = New Font(Backuppathrtb.SelectionFont, FontStyle.Bold)
            Else
                tempselectionfont = New Font(Backuppathrtb.SelectionFont, FontStyle.Regular)
            End If
            Backuppathrtb.SelectionFont = tempselectionfont
            'after setting bold font in both boxes, select "nothing" so no text is blue.
            rtb.SelectionStart = 0
            rtb.SelectionLength = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function
    'copy of settings function - no way ti just reference it yet =(
    Public Function RTB_BP_Clicked(sender As Object, e As MouseEventArgs)
        Try
            If home.backupPatharray.Count = 0 Then
                Return -1
            End If
            'get mouseposition
            Dim rtb = DirectCast(sender, RichTextBox)
            'then get the char where the mouse is
            Dim index = rtb.GetCharIndexFromPosition(e.Location)
            'get the line where this char is (with it's index in the char array of the rtb)
            Dim line = rtb.GetLineFromCharIndex(index)
            'define the first char of line
            Dim lineStart = rtb.GetFirstCharIndexFromLine(line)
            'define the last one
            Dim lineEnd = rtb.GetFirstCharIndexFromLine(line + 1) - 1
            'start selection
            rtb.SelectionStart = lineStart
            'define the length of it
            rtb.SelectionLength = lineEnd - lineStart
            'define color to set
            Dim tempselectionfont
            If (rtb.SelectionFont.Style = FontStyle.Regular) Then
                tempselectionfont = New Font(rtb.SelectionFont, FontStyle.Bold)
            Else
                tempselectionfont = New Font(rtb.SelectionFont, FontStyle.Regular)
            End If
            rtb.SelectionFont = tempselectionfont
            'after that,make shure to make same with other rtb's to select similar entries! (at least in backuppathrtb too - time rtb can be ignored)
            Dim sourcepathrtb = DirectCast(RTB_Sourcepath, RichTextBox)
            'repeat above steps for other rtbox...
            Dim sourceline = sourcepathrtb.GetLineFromCharIndex(index)
            'define the first char of line
            Dim sourcelineStart = sourcepathrtb.GetFirstCharIndexFromLine(sourceline)
            'define the last one
            Dim sourcelineEnd = sourcepathrtb.GetFirstCharIndexFromLine(sourceline + 1) - 1
            'start selection => seems not to work well with 2 boxes at the same time (only marks blue in one)
            'now try to make it bold - maybe it0s enough
            sourcepathrtb.SelectionStart = sourcelineStart
            'define the length of it
            sourcepathrtb.SelectionLength = sourcelineEnd - sourcelineStart
            'define color to set
            If (sourcepathrtb.SelectionFont.Style = FontStyle.Regular) Then
                tempselectionfont = New Font(sourcepathrtb.SelectionFont, FontStyle.Bold)
            Else
                tempselectionfont = New Font(sourcepathrtb.SelectionFont, FontStyle.Regular)
            End If
            sourcepathrtb.SelectionFont = tempselectionfont
            'after setting bold font in both boxes, select "nothing" so no text is blue.
            rtb.SelectionStart = 0
            rtb.SelectionLength = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return 0
    End Function

    '
    Public Sub RTB_Backuppath_MouseDown(sender As Object, e As MouseEventArgs) Handles RTB_Backuppath.MouseDown
        RTB_BP_Clicked(sender, e)
    End Sub

    Public Sub RTB_Sourcepath_MouseDown(sender As Object, e As MouseEventArgs) Handles RTB_Sourcepath.MouseDown
        RTB_SP_Clicked(sender, e)
    End Sub
    ' TextBox for Source Path
    Private Sub tb_sourcePath_TextChanged(sender As Object, e As EventArgs)
        'maybe check for max. character count to prevent possible overflow's? (if there are any)
    End Sub

    ' FolderBrowserDialog to select Source Path
    Private Sub fbd_searchSource_HelpRequest(sender As Object, e As EventArgs) Handles fbd_searchSource.HelpRequest

    End Sub

    ' TextBox for Backup Path
    Private Sub tb_backupPath_TextChanged(sender As Object, e As EventArgs)

    End Sub

    ' FolderBrowserDialog to select Backup Path
    Private Sub fbd_searchBackup_HelpRequest(sender As Object, e As EventArgs) Handles fbd_searchBackup.HelpRequest

    End Sub

    ' Button Start Backup
    Private Sub b_start_Click(sender As Object, e As EventArgs) Handles b_start.Click
        'Confirm & Start Backup-Progress
        ' Dim startResult = MessageBox.Show("Backingup from " + sourcePath + " to " + backupPath + " ? ", "Continue?", MessageBoxButtons.YesNo)
        'think it's better to keep such msg in loop...
        Dim startResult
        If silent Then 'if silent start directly - if not ask user
            startResult = Windows.Forms.DialogResult.Yes 'directly set var to yes without asking user
        Else
            startResult = MessageBox.Show("Starting Backup? ", "Continue?", MessageBoxButtons.YesNo)
        End If
        If startResult = Windows.Forms.DialogResult.Yes Then
            start_backup()
        ElseIf startResult = Windows.Forms.DialogResult.No Then
            MessageBox.Show("Cancled Backup!")
        End If
    End Sub

    'function to encapsulate the actual backup process
    Function start_backup()
        Try
            'start backup processes
            'first define the starttime - and therefore the subfolder name for the backup
            starttime = GetDate()
            'log it
            rtb_log.AppendText(DateTime.Now.ToString & ": Starting Backup Process" & vbNewLine)
            'for each entry in source array => Need a corresponding entry in backuppatharray!!! (even if same backupdir 100 times)
            For i = 0 To sourcepatharray.Count - 1 Step 1
                'define current directories if needed/wanted (will unecessaraly need calc power)
                Dim currsourcepath As String = sourcepatharray(i)
                Dim currbackuppath As String = backupPatharray(i)
                Dim tempstartResult
                If silent Then 'if silent start directly - if not ask user
                    tempstartResult = Windows.Forms.DialogResult.Yes 'directly set var to yes without asking user
                Else
                    tempstartResult = MessageBox.Show("Backingup from " + currsourcepath + " to " + currbackuppath + " ? ", "Continue?", MessageBoxButtons.YesNo)
                End If
                If tempstartResult = Windows.Forms.DialogResult.Yes Then
                    'log start of specific folderpair
                    rtb_log.AppendText(DateTime.Now.ToString & ": Starting Backup from: '" & sourcepatharray(i) & "' to: '" & backupPatharray(i) & vbNewLine)
                    BackupDirectory(sourcepatharray(i), backupPatharray(i), False) 'more arguments can be added like incremental/not etc...
                    'log success
                    rtb_log.AppendText(DateTime.Now.ToString & ": Finished Backup of Folderpair: '" & sourcepatharray(i) & "' - '" & backupPatharray(i) & vbNewLine)
                End If
            Next


        Catch ex As Exception

        End Try
    End Function
    'executed when the minutely timer ticks+
    Private Sub Timer_per_Minute_Tick(sender As Object, e As EventArgs) Handles Timer_per_Minute.Tick
        Try
            'check if no folderpairs exist - if so abort
            If sourcepatharray.Count = 0 Then
                Exit Try
            End If
            'get current values
            'get current day
            Dim currday = GetDate()
            'define current time in hours
            Dim currhour = GetHour()
            'define current time in minutes
            Dim currmin = GetMinutes()

            'start to test values of all folderpairs => loop through all folderpairs
            For i = 0 To sourcepatharray.Count - 1
                'now check the timesettingsarray for all timevalues for the current day =>
                'define the member for current folderpair
                Dim currpairsettings As String = timesettingsarray(i)
                'get string out of the array 
                Dim TSArraystring = Timetable.settings_of_dayn(getday, currpairsettings)
                Dim TSArray As New ArrayList 'TS for Time Settings
                TSArray = StringtoArray(TSArraystring, ";")
                For Each time As String In timesettingsarray(i)
                    'time is written like HH:MM
                    'so get hours and minutes
                    Dim checkhour = time.Substring(0, 2) 'gets first 2 chars so the HH
                    Dim checkMinute = time.Substring(3, 2) 'get s the last two chars MM (: not needed)
                    If checkhour = currhour Then
                        If checkMinute = currmin Then
                            'log the auto start
                            rtb_log.AppendText("The Following Backup Process was autostarted:")
                            'hours AND Minutes are the same - start backup 
                            start_backup()
                        End If
                    End If

                Next
            Next

        Catch ex As Exception

        End Try
    End Sub

    'backup function - accepting different arguments - called in "backup start button"
    'If 'simulate_mode' is true it will not backup anything! can be used to only log.
    Private Function BackupDirectory(sourcepath As String, targetpath As String, Optional simulate_mode_active As Boolean = True)
        'check if targetpath already contains date information . if not add it
        If Not targetpath.Contains(starttime) Then
            'add the date as a subfolder to the targetpath - and check if it exists (and create it if neded)
            targetpath = targetpath & "\" & starttime
        End If

        'check if Source dir exists
        If Not Directory.Exists(targetpath) Then
            Directory.CreateDirectory(targetpath)
        End If

        'get exeption lists
        Dim exelist As New ArrayList
        'Set #Exeptions
        Dim execount = exelist.Count

        Try
            If (exelist.Contains(sourcepath)) Then
                'LOGGING file is on exe list!
                'If Loginfocheckbox.Checked = True Then
                'LogRichTextBox.AppendText("INFO: Directory: " & path & " wasnot saved because of exeption list" & vbNewLine)
                ' End If
            Else
                'LOGGIGN file is processed
                '   If Logdetailedinfocheckbox.Checked = True Then
                'LogRichTextBox.AppendText("DETINFO: Directory: " & path & " is being processed..." & vbNewLine)
                ' End If
                If Directory.Exists(sourcepath) Then
                    'backup all files from the Directory      
                    'for zipping see https://msdn.microsoft.com/en-us/library/ms404280(v=vs.100).aspx
                    'without .net 4.5/6 a damn pain in the arse >.<
                    For Each filepath As String In Directory.GetFiles(sourcepath)
                        Try
                            If simulate_mode_active = False Then
                                'define name of file
                                Dim filename As String = Path.GetFileName(filepath)

                                'if simulate mode is on, only log!!! Dont copy!
                                'check if targetfile already exists
                                If Not File.Exists(targetpath & "\" & filename) Then
                                    File.Copy(filepath, targetpath & "\" & filename)
                                Else
                                    'log it already exists or overwrite if timestamp changed
                                End If
                            End If
                        Catch ex As Exception
                            'if single files fail - maybe make a list? How do we log?
                            rtb_log.AppendText("The following File could not be backed-up - is it opened?" & vbNewLine & filepath)
                        End Try
                    Next 'for each filepath end

                    'get Subdirectories and repeat process
                    For Each dir As String In Directory.GetDirectories(sourcepath)
                        'calculate the relative path
                        Dim relpath As String = dir.Substring(sourcepath.Length, dir.Length - sourcepath.Length)
                        'call routine to delete subfiles
                        If simulate_mode_active = True Then
                            BackupDirectory(dir, targetpath & relpath, True)
                        Else
                            BackupDirectory(dir, targetpath & relpath, False)
                        End If
                    Next
                End If
            End If

            Return (0) 'return code "0" if everything went ok - without breaking code anywhere
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Above Error occured in Backup_Directory Function", "Error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1 'return code "-1" to indicate an unknown/unhandlet error 
        End Try
    End Function

    ' Button open Settings
    Private Sub b_settings_Click(sender As Object, e As EventArgs) Handles b_settings.Click
        'Show Settings Form and block home Form
        Settings.ShowDialog()
    End Sub

    'Button Update - executed on click
    Private Sub b_update_Click(sender As Object, e As EventArgs) Handles b_update.Click
        'enter "try" to stop application from breaking totaly if an error occurs. (most of the times)
        Try
            'try to start the updater | Version informations: See bw_versionControll
            Diagnostics.Process.Start(getexedir() & "/THC_Updater.exe") 'assumes that updater exe is in same path as calling exe
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Above Error occured in b_update Sub", "Error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function GetDate() As String
        Dim day = getday()
        Dim month = DateTime.Now.ToString("MM")
        Dim year = DateTime.Now.ToString("yyyy")
        Dim time = GetTime()
        Return (year & month & day & time)
    End Function
    Function getday() As String
        Dim day = DateTime.Now.ToString("dd")
        Return day
    End Function
    Function GetTime() As String
        Dim hour = GetHour()
        Dim min = GetMinutes()
        Return (hour & min)
    End Function
    Function GetHour() As String
        Dim hour = DateTime.Now.ToString("HH")
        Return hour
    End Function
    Function GetMinutes() As String
        Dim min = DateTime.Now.ToString("mm")
        Return min
    End Function
    'function to get an array out of long seperated string like "nr1;nr2;nr3;nr4...."
    'use like "  dim array1  as arraylist = stringtoarray("nr1;nr2;nr3",";")     "
    Function StringtoArray(seperatedmultistring As String, seperator As String) As ArrayList
        'reset returnarray if it s not null (redim it with 0 members)
        Dim returnarray As New ArrayList
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
            'check if current char is the seperator sign
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
    Public Function getexedir() As String
        Dim path As String
        path = System.IO.Path.GetDirectoryName( _
           System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Return path.Substring(6, path.Length - 6)
    End Function
#End Region

#Region "System-Tray"
    '*-----------------*'
    '*---System-Tray---*'
    '*-----------------*'

    'Minimize and Maximize Application
    'Minimize to System-Tray
    Private Sub home_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Visible = False
                NotifyIcon1.Visible = True
                NotifyIcon1.ShowBalloonTip(500, "WinBackupper", "Running in backgound", ToolTipIcon.Info)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Above Error occured in home_Resize Function", "Error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Maximize from System-Tray on DoubleClick
    'Maybe Notify_MouseDoubleClick could be removed
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            NotifyIcon1.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Above Error occured in Notify Icon Sub", "Error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Maximize from System-Tray menu -> Open
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            NotifyIcon1.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Above Error occured in OpenToolStripMenu Sub", "Error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Close Application from System-Tray menu -> Close
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'Close
        Me.Close()
    End Sub
#End Region

#Region "Workers"
    '*-----------------*'
    '*-----Workers-----*'
    '*-----------------*'

    ' Writes Version to XML File to get the actual Version in "THC_Updater.exe"
    Private Sub bw_versionControll_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw_versionControll.DoWork
        ' Create XML Writer
        Dim writerOption As New XmlWriterSettings
        writerOption.Indent = True
        Dim writerSettings As XmlWriter = XmlWriter.Create("version.xml", writerOption)

        With writerSettings
            .WriteStartDocument()
            .WriteStartElement("Version")
            .WriteString(version)
            .WriteEndElement()

            .WriteEndDocument()

            .Close()
        End With
        writerSettings.Close()
        writerSettings.Dispose()
    End Sub
#End Region


End Class
