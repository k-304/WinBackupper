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
        Me.b_save = New System.Windows.Forms.Button()
        Me.bw_writer = New System.ComponentModel.BackgroundWorker()
        Me.fbd_searchDefaultSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.fbd_searchDefaultBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.b_addfolderpair = New System.Windows.Forms.Button()
        Me.l_settings = New System.Windows.Forms.Label()
        Me.b_reset = New System.Windows.Forms.Button()
        Me.b_editfolderpair = New System.Windows.Forms.Button()
        Me.RTB_timesettings = New System.Windows.Forms.RichTextBox()
        Me.l_backuptimes = New System.Windows.Forms.Label()
        Me.cb_Autostart = New System.Windows.Forms.CheckBox()
        Me.b_showtimetable = New System.Windows.Forms.Button()
        Me.b_Remove_Folderpair = New System.Windows.Forms.Button()
        Me.lv_settings = New System.Windows.Forms.ListView()
        Me.ch_index = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_source = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_backup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'b_save
        '
        Me.b_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_save.Location = New System.Drawing.Point(345, 441)
        Me.b_save.Name = "b_save"
        Me.b_save.Size = New System.Drawing.Size(97, 35)
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
        Me.b_addfolderpair.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_addfolderpair.Location = New System.Drawing.Point(12, 401)
        Me.b_addfolderpair.Name = "b_addfolderpair"
        Me.b_addfolderpair.Size = New System.Drawing.Size(202, 35)
        Me.b_addfolderpair.TabIndex = 19
        Me.b_addfolderpair.Text = "Add new Directory"
        Me.b_addfolderpair.UseVisualStyleBackColor = True
        '
        'l_settings
        '
        Me.l_settings.AutoSize = True
        Me.l_settings.BackColor = System.Drawing.Color.Transparent
        Me.l_settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_settings.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_settings.Location = New System.Drawing.Point(160, 9)
        Me.l_settings.Name = "l_settings"
        Me.l_settings.Size = New System.Drawing.Size(113, 31)
        Me.l_settings.TabIndex = 10
        Me.l_settings.Text = "Settings"
        '
        'b_reset
        '
        Me.b_reset.BackColor = System.Drawing.Color.LightCoral
        Me.b_reset.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_reset.Location = New System.Drawing.Point(12, 441)
        Me.b_reset.Name = "b_reset"
        Me.b_reset.Size = New System.Drawing.Size(103, 36)
        Me.b_reset.TabIndex = 23
        Me.b_reset.Text = "Reset!"
        Me.b_reset.UseVisualStyleBackColor = False
        '
        'b_editfolderpair
        '
        Me.b_editfolderpair.Enabled = False
        Me.b_editfolderpair.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_editfolderpair.Location = New System.Drawing.Point(240, 401)
        Me.b_editfolderpair.Name = "b_editfolderpair"
        Me.b_editfolderpair.Size = New System.Drawing.Size(202, 35)
        Me.b_editfolderpair.TabIndex = 24
        Me.b_editfolderpair.Text = "Edit Directory"
        Me.b_editfolderpair.UseVisualStyleBackColor = True
        '
        'RTB_timesettings
        '
        Me.RTB_timesettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB_timesettings.Location = New System.Drawing.Point(12, 253)
        Me.RTB_timesettings.Name = "RTB_timesettings"
        Me.RTB_timesettings.ShowSelectionMargin = True
        Me.RTB_timesettings.Size = New System.Drawing.Size(430, 59)
        Me.RTB_timesettings.TabIndex = 25
        Me.RTB_timesettings.Text = ""
        '
        'l_backuptimes
        '
        Me.l_backuptimes.AutoSize = True
        Me.l_backuptimes.BackColor = System.Drawing.Color.Transparent
        Me.l_backuptimes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_backuptimes.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_backuptimes.Location = New System.Drawing.Point(45, 226)
        Me.l_backuptimes.Name = "l_backuptimes"
        Me.l_backuptimes.Size = New System.Drawing.Size(345, 24)
        Me.l_backuptimes.TabIndex = 26
        Me.l_backuptimes.Text = "Todays Startimes of selected Folderpair:"
        '
        'cb_Autostart
        '
        Me.cb_Autostart.AutoSize = True
        Me.cb_Autostart.BackColor = System.Drawing.Color.Transparent
        Me.cb_Autostart.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Autostart.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cb_Autostart.Location = New System.Drawing.Point(12, 359)
        Me.cb_Autostart.Name = "cb_Autostart"
        Me.cb_Autostart.Size = New System.Drawing.Size(400, 28)
        Me.cb_Autostart.TabIndex = 27
        Me.cb_Autostart.Text = "Start Application on Startup (only this user!) ?"
        Me.cb_Autostart.UseVisualStyleBackColor = False
        '
        'b_showtimetable
        '
        Me.b_showtimetable.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_showtimetable.Location = New System.Drawing.Point(95, 318)
        Me.b_showtimetable.Name = "b_showtimetable"
        Me.b_showtimetable.Size = New System.Drawing.Size(265, 35)
        Me.b_showtimetable.TabIndex = 28
        Me.b_showtimetable.Text = "Edit Time Confgiuration"
        Me.b_showtimetable.UseVisualStyleBackColor = True
        '
        'b_Remove_Folderpair
        '
        Me.b_Remove_Folderpair.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_Remove_Folderpair.Location = New System.Drawing.Point(121, 441)
        Me.b_Remove_Folderpair.Name = "b_Remove_Folderpair"
        Me.b_Remove_Folderpair.Size = New System.Drawing.Size(218, 35)
        Me.b_Remove_Folderpair.TabIndex = 29
        Me.b_Remove_Folderpair.Text = "Remove Directory"
        Me.b_Remove_Folderpair.UseVisualStyleBackColor = True
        '
        'lv_settings
        '
        Me.lv_settings.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_index, Me.ch_source, Me.ch_backup})
        Me.lv_settings.FullRowSelect = True
        Me.lv_settings.Location = New System.Drawing.Point(12, 44)
        Me.lv_settings.Name = "lv_settings"
        Me.lv_settings.Size = New System.Drawing.Size(430, 179)
        Me.lv_settings.TabIndex = 30
        Me.lv_settings.UseCompatibleStateImageBehavior = False
        Me.lv_settings.View = System.Windows.Forms.View.Details
        '
        'ch_index
        '
        Me.ch_index.Text = "#"
        Me.ch_index.Width = 25
        '
        'ch_source
        '
        Me.ch_source.Text = "Sourcepath:"
        Me.ch_source.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ch_source.Width = 185
        '
        'ch_backup
        '
        Me.ch_backup.Text = "Backuppath:"
        Me.ch_backup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ch_backup.Width = 188
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImage = Global.WinBackupper.My.Resources.Resources.gray_background_3
        Me.ClientSize = New System.Drawing.Size(454, 489)
        Me.Controls.Add(Me.lv_settings)
        Me.Controls.Add(Me.b_Remove_Folderpair)
        Me.Controls.Add(Me.b_showtimetable)
        Me.Controls.Add(Me.cb_Autostart)
        Me.Controls.Add(Me.l_backuptimes)
        Me.Controls.Add(Me.RTB_timesettings)
        Me.Controls.Add(Me.b_editfolderpair)
        Me.Controls.Add(Me.b_reset)
        Me.Controls.Add(Me.b_addfolderpair)
        Me.Controls.Add(Me.b_save)
        Me.Controls.Add(Me.l_settings)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_save As System.Windows.Forms.Button
    Friend WithEvents bw_writer As System.ComponentModel.BackgroundWorker
    Friend WithEvents fbd_searchDefaultSource As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents fbd_searchDefaultBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents b_addfolderpair As System.Windows.Forms.Button
    Friend WithEvents l_settings As System.Windows.Forms.Label
    Friend WithEvents b_reset As System.Windows.Forms.Button
    Friend WithEvents b_editfolderpair As System.Windows.Forms.Button
    Friend WithEvents RTB_timesettings As System.Windows.Forms.RichTextBox
    Friend WithEvents l_backuptimes As System.Windows.Forms.Label
    Friend WithEvents cb_Autostart As System.Windows.Forms.CheckBox
    Friend WithEvents b_showtimetable As System.Windows.Forms.Button
    Friend WithEvents b_Remove_Folderpair As System.Windows.Forms.Button
    Friend WithEvents lv_settings As System.Windows.Forms.ListView
    Friend WithEvents ch_index As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_source As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_backup As System.Windows.Forms.ColumnHeader
End Class
