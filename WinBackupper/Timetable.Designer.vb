<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Timetable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Timetable))
        Me.b_stopediting = New System.Windows.Forms.Button()
        Me.l_settings = New System.Windows.Forms.Label()
        Me.l_source = New System.Windows.Forms.Label()
        Me.l_backup = New System.Windows.Forms.Label()
        Me.b_editSource = New System.Windows.Forms.Button()
        Me.tb_showSource = New System.Windows.Forms.TextBox()
        Me.tb_showBackup = New System.Windows.Forms.TextBox()
        Me.b_editBackup = New System.Windows.Forms.Button()
        Me.b_add = New System.Windows.Forms.Button()
        Me.b_remove = New System.Windows.Forms.Button()
        Me.b_reset = New System.Windows.Forms.Button()
        Me.cb_intervall = New System.Windows.Forms.CheckBox()
        Me.b_changebackuptype = New System.Windows.Forms.Button()
        Me.tb_intervall = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lv_timetable = New System.Windows.Forms.ListView()
        Me.ch_starttime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_backuptype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dd_Day = New System.Windows.Forms.ComboBox()
        Me.dtp = New System.Windows.Forms.DateTimePicker()
        Me.l_sourcePath = New System.Windows.Forms.Label()
        Me.gb_paths = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fbd_editsource = New System.Windows.Forms.FolderBrowserDialog()
        Me.fbd_editbackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.gb_paths.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'b_stopediting
        '
        Me.b_stopediting.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_stopediting.Location = New System.Drawing.Point(104, 435)
        Me.b_stopediting.Name = "b_stopediting"
        Me.b_stopediting.Size = New System.Drawing.Size(239, 36)
        Me.b_stopediting.TabIndex = 22
        Me.b_stopediting.Text = "Apply Times"
        Me.b_stopediting.UseVisualStyleBackColor = True
        '
        'l_settings
        '
        Me.l_settings.AutoSize = True
        Me.l_settings.BackColor = System.Drawing.Color.Transparent
        Me.l_settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_settings.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_settings.Location = New System.Drawing.Point(136, 9)
        Me.l_settings.Name = "l_settings"
        Me.l_settings.Size = New System.Drawing.Size(197, 31)
        Me.l_settings.TabIndex = 34
        Me.l_settings.Text = "Folder Settings"
        '
        'l_source
        '
        Me.l_source.AutoSize = True
        Me.l_source.BackColor = System.Drawing.Color.Transparent
        Me.l_source.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_source.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_source.Location = New System.Drawing.Point(6, 17)
        Me.l_source.Name = "l_source"
        Me.l_source.Size = New System.Drawing.Size(101, 20)
        Me.l_source.TabIndex = 35
        Me.l_source.Text = "Source Path:"
        '
        'l_backup
        '
        Me.l_backup.AutoSize = True
        Me.l_backup.BackColor = System.Drawing.Color.Transparent
        Me.l_backup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_backup.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_backup.Location = New System.Drawing.Point(6, 46)
        Me.l_backup.Name = "l_backup"
        Me.l_backup.Size = New System.Drawing.Size(104, 20)
        Me.l_backup.TabIndex = 36
        Me.l_backup.Text = "Backup Path:"
        '
        'b_editSource
        '
        Me.b_editSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_editSource.Location = New System.Drawing.Point(349, 43)
        Me.b_editSource.Name = "b_editSource"
        Me.b_editSource.Size = New System.Drawing.Size(75, 23)
        Me.b_editSource.TabIndex = 37
        Me.b_editSource.Text = "Edit"
        Me.b_editSource.UseVisualStyleBackColor = True
        '
        'tb_showSource
        '
        Me.tb_showSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_showSource.Location = New System.Drawing.Point(116, 14)
        Me.tb_showSource.Name = "tb_showSource"
        Me.tb_showSource.ReadOnly = True
        Me.tb_showSource.Size = New System.Drawing.Size(227, 23)
        Me.tb_showSource.TabIndex = 38
        '
        'tb_showBackup
        '
        Me.tb_showBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_showBackup.Location = New System.Drawing.Point(116, 43)
        Me.tb_showBackup.Name = "tb_showBackup"
        Me.tb_showBackup.ReadOnly = True
        Me.tb_showBackup.Size = New System.Drawing.Size(227, 23)
        Me.tb_showBackup.TabIndex = 39
        '
        'b_editBackup
        '
        Me.b_editBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_editBackup.Location = New System.Drawing.Point(349, 13)
        Me.b_editBackup.Name = "b_editBackup"
        Me.b_editBackup.Size = New System.Drawing.Size(75, 23)
        Me.b_editBackup.TabIndex = 40
        Me.b_editBackup.Text = "Edit"
        Me.b_editBackup.UseVisualStyleBackColor = True
        '
        'b_add
        '
        Me.b_add.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_add.Location = New System.Drawing.Point(104, 307)
        Me.b_add.Name = "b_add"
        Me.b_add.Size = New System.Drawing.Size(112, 36)
        Me.b_add.TabIndex = 20
        Me.b_add.Text = "Add"
        Me.b_add.UseVisualStyleBackColor = True
        '
        'b_remove
        '
        Me.b_remove.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_remove.Location = New System.Drawing.Point(231, 307)
        Me.b_remove.Name = "b_remove"
        Me.b_remove.Size = New System.Drawing.Size(112, 36)
        Me.b_remove.TabIndex = 23
        Me.b_remove.Text = "Remove"
        Me.b_remove.UseVisualStyleBackColor = True
        '
        'b_reset
        '
        Me.b_reset.BackColor = System.Drawing.Color.LightCoral
        Me.b_reset.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_reset.Location = New System.Drawing.Point(165, 391)
        Me.b_reset.Name = "b_reset"
        Me.b_reset.Size = New System.Drawing.Size(112, 38)
        Me.b_reset.TabIndex = 30
        Me.b_reset.Text = "Reset Times"
        Me.b_reset.UseVisualStyleBackColor = False
        '
        'cb_intervall
        '
        Me.cb_intervall.AutoSize = True
        Me.cb_intervall.BackColor = System.Drawing.Color.Transparent
        Me.cb_intervall.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_intervall.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cb_intervall.Location = New System.Drawing.Point(104, 280)
        Me.cb_intervall.Name = "cb_intervall"
        Me.cb_intervall.Size = New System.Drawing.Size(160, 21)
        Me.cb_intervall.TabIndex = 31
        Me.cb_intervall.Text = "Add intervall entries?"
        Me.cb_intervall.UseVisualStyleBackColor = False
        '
        'b_changebackuptype
        '
        Me.b_changebackuptype.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_changebackuptype.Location = New System.Drawing.Point(104, 349)
        Me.b_changebackuptype.Name = "b_changebackuptype"
        Me.b_changebackuptype.Size = New System.Drawing.Size(239, 36)
        Me.b_changebackuptype.TabIndex = 33
        Me.b_changebackuptype.Text = "Change Backuptype"
        Me.b_changebackuptype.UseVisualStyleBackColor = True
        '
        'tb_intervall
        '
        Me.tb_intervall.Location = New System.Drawing.Point(209, 68)
        Me.tb_intervall.Name = "tb_intervall"
        Me.tb_intervall.Size = New System.Drawing.Size(134, 20)
        Me.tb_intervall.TabIndex = 29
        Me.tb_intervall.Text = "24"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(101, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Intervall (in h):"
        '
        'lv_timetable
        '
        Me.lv_timetable.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_starttime, Me.ch_backuptype})
        Me.lv_timetable.Location = New System.Drawing.Point(104, 94)
        Me.lv_timetable.Name = "lv_timetable"
        Me.lv_timetable.Size = New System.Drawing.Size(239, 180)
        Me.lv_timetable.TabIndex = 32
        Me.lv_timetable.UseCompatibleStateImageBehavior = False
        Me.lv_timetable.View = System.Windows.Forms.View.Details
        '
        'ch_starttime
        '
        Me.ch_starttime.Text = "Starttime"
        Me.ch_starttime.Width = 117
        '
        'ch_backuptype
        '
        Me.ch_backuptype.Text = "Backup type"
        Me.ch_backuptype.Width = 117
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(101, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 20)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Starttime:"
        '
        'dd_Day
        '
        Me.dd_Day.FormattingEnabled = True
        Me.dd_Day.Items.AddRange(New Object() {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"})
        Me.dd_Day.Location = New System.Drawing.Point(209, 15)
        Me.dd_Day.Name = "dd_Day"
        Me.dd_Day.Size = New System.Drawing.Size(134, 21)
        Me.dd_Day.TabIndex = 25
        Me.dd_Day.Text = "Monday"
        '
        'dtp
        '
        Me.dtp.CustomFormat = "HH:mm"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(209, 42)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(134, 20)
        Me.dtp.TabIndex = 0
        '
        'l_sourcePath
        '
        Me.l_sourcePath.AutoSize = True
        Me.l_sourcePath.BackColor = System.Drawing.Color.Transparent
        Me.l_sourcePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_sourcePath.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_sourcePath.Location = New System.Drawing.Point(101, 16)
        Me.l_sourcePath.Name = "l_sourcePath"
        Me.l_sourcePath.Size = New System.Drawing.Size(41, 20)
        Me.l_sourcePath.TabIndex = 26
        Me.l_sourcePath.Text = "Day:"
        '
        'gb_paths
        '
        Me.gb_paths.BackColor = System.Drawing.Color.Transparent
        Me.gb_paths.Controls.Add(Me.tb_showBackup)
        Me.gb_paths.Controls.Add(Me.l_backup)
        Me.gb_paths.Controls.Add(Me.l_source)
        Me.gb_paths.Controls.Add(Me.tb_showSource)
        Me.gb_paths.Controls.Add(Me.b_editBackup)
        Me.gb_paths.Controls.Add(Me.b_editSource)
        Me.gb_paths.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_paths.Location = New System.Drawing.Point(12, 45)
        Me.gb_paths.Name = "gb_paths"
        Me.gb_paths.Size = New System.Drawing.Size(430, 75)
        Me.gb_paths.TabIndex = 41
        Me.gb_paths.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lv_timetable)
        Me.GroupBox1.Controls.Add(Me.l_sourcePath)
        Me.GroupBox1.Controls.Add(Me.dtp)
        Me.GroupBox1.Controls.Add(Me.b_stopediting)
        Me.GroupBox1.Controls.Add(Me.dd_Day)
        Me.GroupBox1.Controls.Add(Me.b_reset)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tb_intervall)
        Me.GroupBox1.Controls.Add(Me.b_changebackuptype)
        Me.GroupBox1.Controls.Add(Me.cb_intervall)
        Me.GroupBox1.Controls.Add(Me.b_remove)
        Me.GroupBox1.Controls.Add(Me.b_add)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 477)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'fbd_editsource
        '
        '
        'fbd_editbackup
        '
        '
        'Timetable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WinBackupper.My.Resources.Resources.gray_background_3
        Me.ClientSize = New System.Drawing.Size(454, 629)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gb_paths)
        Me.Controls.Add(Me.l_settings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Timetable"
        Me.Text = "Folder-Pair Settings"
        Me.gb_paths.ResumeLayout(False)
        Me.gb_paths.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_stopediting As System.Windows.Forms.Button
    Friend WithEvents l_settings As System.Windows.Forms.Label
    Friend WithEvents l_source As System.Windows.Forms.Label
    Friend WithEvents l_backup As System.Windows.Forms.Label
    Friend WithEvents b_editSource As System.Windows.Forms.Button
    Friend WithEvents tb_showSource As System.Windows.Forms.TextBox
    Friend WithEvents tb_showBackup As System.Windows.Forms.TextBox
    Friend WithEvents b_editBackup As System.Windows.Forms.Button
    Friend WithEvents b_add As System.Windows.Forms.Button
    Friend WithEvents b_remove As System.Windows.Forms.Button
    Friend WithEvents b_reset As System.Windows.Forms.Button
    Friend WithEvents cb_intervall As System.Windows.Forms.CheckBox
    Friend WithEvents b_changebackuptype As System.Windows.Forms.Button
    Friend WithEvents tb_intervall As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lv_timetable As System.Windows.Forms.ListView
    Friend WithEvents ch_starttime As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_backuptype As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dd_Day As System.Windows.Forms.ComboBox
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents l_sourcePath As System.Windows.Forms.Label
    Friend WithEvents gb_paths As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents fbd_editsource As FolderBrowserDialog
    Friend WithEvents fbd_editbackup As FolderBrowserDialog
End Class
