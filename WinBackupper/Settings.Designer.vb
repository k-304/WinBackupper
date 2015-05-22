<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.l_BackupPath = New System.Windows.Forms.Label()
        Me.l_SourcePath = New System.Windows.Forms.Label()
        Me.b_save = New System.Windows.Forms.Button()
        Me.bw_writer = New System.ComponentModel.BackgroundWorker()
        Me.fbd_searchDefaultSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.fbd_searchDefaultBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.b_addfolderpair = New System.Windows.Forms.Button()
        Me.l_settings = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.RTB_Backuppath = New System.Windows.Forms.RichTextBox()
        Me.RTB_Sourcepath = New System.Windows.Forms.RichTextBox()
        Me.b_reset = New System.Windows.Forms.Button()
        Me.b_editfolderpair = New System.Windows.Forms.Button()
        Me.rtb_backupstarttimes = New System.Windows.Forms.RichTextBox()
        Me.l_backuptimes = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'l_BackupPath
        '
        Me.l_BackupPath.AutoSize = True
        Me.l_BackupPath.BackColor = System.Drawing.Color.Transparent
        Me.l_BackupPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_BackupPath.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_BackupPath.Location = New System.Drawing.Point(277, 59)
        Me.l_BackupPath.Name = "l_BackupPath"
        Me.l_BackupPath.Size = New System.Drawing.Size(92, 17)
        Me.l_BackupPath.TabIndex = 12
        Me.l_BackupPath.Text = "Backup Path:"
        '
        'l_SourcePath
        '
        Me.l_SourcePath.AutoSize = True
        Me.l_SourcePath.BackColor = System.Drawing.Color.Transparent
        Me.l_SourcePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_SourcePath.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_SourcePath.Location = New System.Drawing.Point(63, 59)
        Me.l_SourcePath.Name = "l_SourcePath"
        Me.l_SourcePath.Size = New System.Drawing.Size(90, 17)
        Me.l_SourcePath.TabIndex = 11
        Me.l_SourcePath.Text = "Source Path:"
        '
        'b_save
        '
        Me.b_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_save.Location = New System.Drawing.Point(11, 353)
        Me.b_save.Name = "b_save"
        Me.b_save.Size = New System.Drawing.Size(431, 35)
        Me.b_save.TabIndex = 18
        Me.b_save.Text = "Save"
        Me.b_save.UseVisualStyleBackColor = True
        '
        'bw_writer
        '
        '
        'fbd_searchDefaultSource
        '
        '
        'fbd_searchDefaultBackup
        '
        '
        'b_addfolderpair
        '
        Me.b_addfolderpair.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_addfolderpair.Location = New System.Drawing.Point(11, 320)
        Me.b_addfolderpair.Name = "b_addfolderpair"
        Me.b_addfolderpair.Size = New System.Drawing.Size(202, 35)
        Me.b_addfolderpair.TabIndex = 19
        Me.b_addfolderpair.Text = "Add new Entry"
        Me.b_addfolderpair.UseVisualStyleBackColor = True
        '
        'l_settings
        '
        Me.l_settings.AutoSize = True
        Me.l_settings.BackColor = System.Drawing.Color.Transparent
        Me.l_settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_settings.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_settings.Location = New System.Drawing.Point(168, 23)
        Me.l_settings.Name = "l_settings"
        Me.l_settings.Size = New System.Drawing.Size(90, 25)
        Me.l_settings.TabIndex = 10
        Me.l_settings.Text = "Settings"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(293, 116)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(8, 8)
        Me.RichTextBox1.TabIndex = 20
        Me.RichTextBox1.Text = ""
        '
        'RTB_Backuppath
        '
        Me.RTB_Backuppath.Location = New System.Drawing.Point(225, 79)
        Me.RTB_Backuppath.Name = "RTB_Backuppath"
        Me.RTB_Backuppath.ShowSelectionMargin = True
        Me.RTB_Backuppath.Size = New System.Drawing.Size(214, 142)
        Me.RTB_Backuppath.TabIndex = 22
        Me.RTB_Backuppath.Text = ""
        '
        'RTB_Sourcepath
        '
        Me.RTB_Sourcepath.Location = New System.Drawing.Point(12, 79)
        Me.RTB_Sourcepath.Name = "RTB_Sourcepath"
        Me.RTB_Sourcepath.ShowSelectionMargin = True
        Me.RTB_Sourcepath.Size = New System.Drawing.Size(198, 142)
        Me.RTB_Sourcepath.TabIndex = 21
        Me.RTB_Sourcepath.Text = ""
        '
        'b_reset
        '
        Me.b_reset.BackColor = System.Drawing.Color.LightCoral
        Me.b_reset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_reset.Location = New System.Drawing.Point(11, 19)
        Me.b_reset.Name = "b_reset"
        Me.b_reset.Size = New System.Drawing.Size(100, 36)
        Me.b_reset.TabIndex = 23
        Me.b_reset.Text = "Reset!"
        Me.b_reset.UseVisualStyleBackColor = False
        '
        'b_editfolderpair
        '
        Me.b_editfolderpair.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_editfolderpair.Location = New System.Drawing.Point(228, 320)
        Me.b_editfolderpair.Name = "b_editfolderpair"
        Me.b_editfolderpair.Size = New System.Drawing.Size(214, 35)
        Me.b_editfolderpair.TabIndex = 24
        Me.b_editfolderpair.Text = "Edit Entry"
        Me.b_editfolderpair.UseVisualStyleBackColor = True
        '
        'rtb_backupstarttimes
        '
        Me.rtb_backupstarttimes.Location = New System.Drawing.Point(11, 255)
        Me.rtb_backupstarttimes.Name = "rtb_backupstarttimes"
        Me.rtb_backupstarttimes.ShowSelectionMargin = True
        Me.rtb_backupstarttimes.Size = New System.Drawing.Size(427, 59)
        Me.rtb_backupstarttimes.TabIndex = 25
        Me.rtb_backupstarttimes.Text = ""
        '
        'l_backuptimes
        '
        Me.l_backuptimes.AutoSize = True
        Me.l_backuptimes.BackColor = System.Drawing.Color.Transparent
        Me.l_backuptimes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_backuptimes.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_backuptimes.Location = New System.Drawing.Point(107, 235)
        Me.l_backuptimes.Name = "l_backuptimes"
        Me.l_backuptimes.Size = New System.Drawing.Size(238, 17)
        Me.l_backuptimes.TabIndex = 26
        Me.l_backuptimes.Text = "Backup start times of selected Entry:"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImage = Global.WinBackupper.My.Resources.Resources.gray_background_3
        Me.ClientSize = New System.Drawing.Size(454, 395)
        Me.Controls.Add(Me.l_backuptimes)
        Me.Controls.Add(Me.rtb_backupstarttimes)
        Me.Controls.Add(Me.b_editfolderpair)
        Me.Controls.Add(Me.b_reset)
        Me.Controls.Add(Me.RTB_Backuppath)
        Me.Controls.Add(Me.RTB_Sourcepath)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.b_addfolderpair)
        Me.Controls.Add(Me.b_save)
        Me.Controls.Add(Me.l_BackupPath)
        Me.Controls.Add(Me.l_SourcePath)
        Me.Controls.Add(Me.l_settings)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents l_BackupPath As System.Windows.Forms.Label
    Friend WithEvents l_SourcePath As System.Windows.Forms.Label
    Friend WithEvents b_save As System.Windows.Forms.Button
    Friend WithEvents bw_writer As System.ComponentModel.BackgroundWorker
    Friend WithEvents fbd_searchDefaultSource As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents fbd_searchDefaultBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents b_addfolderpair As System.Windows.Forms.Button
    Friend WithEvents l_settings As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents RTB_Backuppath As System.Windows.Forms.RichTextBox
    Friend WithEvents RTB_Sourcepath As System.Windows.Forms.RichTextBox
    Friend WithEvents b_reset As System.Windows.Forms.Button
    Friend WithEvents b_editfolderpair As System.Windows.Forms.Button
    Friend WithEvents rtb_backupstarttimes As System.Windows.Forms.RichTextBox
    Friend WithEvents l_backuptimes As System.Windows.Forms.Label
End Class
