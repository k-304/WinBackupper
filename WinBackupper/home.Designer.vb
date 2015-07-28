<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class home
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(home))
        Me.l_title = New System.Windows.Forms.Label()
        Me.b_start = New System.Windows.Forms.Button()
        Me.b_settings = New System.Windows.Forms.Button()
        Me.fbd_searchSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.fbd_searchBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.b_update = New System.Windows.Forms.Button()
        Me.l_version = New System.Windows.Forms.Label()
        Me.bw_versionControll = New System.ComponentModel.BackgroundWorker()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_per_Minute = New System.Windows.Forms.Timer(Me.components)
        Me.rtb_log = New System.Windows.Forms.RichTextBox()
        Me.l_log = New System.Windows.Forms.Label()
        Me.lv_overview = New System.Windows.Forms.ListView()
        Me.ch_index = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ch_source = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ch_backup = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ch_nextstarttime = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.cb_defaultmanualbackup = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'l_title
        '
        Me.l_title.AutoSize = True
        Me.l_title.BackColor = System.Drawing.Color.Transparent
        Me.l_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_title.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_title.Location = New System.Drawing.Point(133, 14)
        Me.l_title.Name = "l_title"
        Me.l_title.Size = New System.Drawing.Size(208, 25)
        Me.l_title.TabIndex = 0
        Me.l_title.Text = "Windows Backupper"
        '
        'b_start
        '
        Me.b_start.BackColor = System.Drawing.SystemColors.ControlLight
        Me.b_start.Cursor = System.Windows.Forms.Cursors.Default
        Me.b_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_start.Location = New System.Drawing.Point(12, 256)
        Me.b_start.Name = "b_start"
        Me.b_start.Size = New System.Drawing.Size(430, 35)
        Me.b_start.TabIndex = 7
        Me.b_start.Text = "Start Backup"
        Me.b_start.UseVisualStyleBackColor = True
        '
        'b_settings
        '
        Me.b_settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_settings.Location = New System.Drawing.Point(12, 297)
        Me.b_settings.Name = "b_settings"
        Me.b_settings.Size = New System.Drawing.Size(135, 35)
        Me.b_settings.TabIndex = 8
        Me.b_settings.Text = "Configuration"
        Me.b_settings.UseVisualStyleBackColor = True
        '
        'fbd_searchSource
        '
        '
        'fbd_searchBackup
        '
        '
        'b_update
        '
        Me.b_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_update.Location = New System.Drawing.Point(153, 297)
        Me.b_update.Name = "b_update"
        Me.b_update.Size = New System.Drawing.Size(136, 35)
        Me.b_update.TabIndex = 10
        Me.b_update.Text = "Update"
        Me.b_update.UseVisualStyleBackColor = True
        '
        'l_version
        '
        Me.l_version.AutoSize = True
        Me.l_version.BackColor = System.Drawing.Color.Transparent
        Me.l_version.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_version.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_version.Location = New System.Drawing.Point(342, 308)
        Me.l_version.Name = "l_version"
        Me.l_version.Size = New System.Drawing.Size(100, 17)
        Me.l_version.TabIndex = 11
        Me.l_version.Text = "Version: x.x.x.x"
        '
        'bw_versionControll
        '
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "WinBackupper"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(104, 48)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Timer_per_Minute
        '
        Me.Timer_per_Minute.Enabled = True
        Me.Timer_per_Minute.Interval = 60000
        Me.Timer_per_Minute.Tag = ""
        '
        'rtb_log
        '
        Me.rtb_log.BackColor = System.Drawing.SystemColors.Window
        Me.rtb_log.Location = New System.Drawing.Point(12, 362)
        Me.rtb_log.Name = "rtb_log"
        Me.rtb_log.ReadOnly = True
        Me.rtb_log.Size = New System.Drawing.Size(430, 55)
        Me.rtb_log.TabIndex = 14
        Me.rtb_log.Text = ""
        '
        'l_log
        '
        Me.l_log.AutoSize = True
        Me.l_log.BackColor = System.Drawing.Color.Transparent
        Me.l_log.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_log.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_log.Location = New System.Drawing.Point(199, 335)
        Me.l_log.Name = "l_log"
        Me.l_log.Size = New System.Drawing.Size(47, 24)
        Me.l_log.TabIndex = 15
        Me.l_log.Text = "Log:"
        '
        'lv_overview
        '
        Me.lv_overview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_index, Me.ch_source, Me.ch_backup, Me.ch_nextstarttime})
        Me.lv_overview.FullRowSelect = True
        Me.lv_overview.Location = New System.Drawing.Point(12, 45)
        Me.lv_overview.Name = "lv_overview"
        Me.lv_overview.Size = New System.Drawing.Size(430, 179)
        Me.lv_overview.TabIndex = 16
        Me.lv_overview.UseCompatibleStateImageBehavior = False
        Me.lv_overview.View = System.Windows.Forms.View.Details
        '
        'ch_index
        '
        Me.ch_index.Text = "#"
        Me.ch_index.Width = 25
        '
        'ch_source
        '
        Me.ch_source.Text = "Sourcepath:"
        Me.ch_source.Width = 156
        '
        'ch_backup
        '
        Me.ch_backup.Text = "Backuppath:"
        Me.ch_backup.Width = 156
        '
        'ch_nextstarttime
        '
        Me.ch_nextstarttime.Text = "Next start time:"
        Me.ch_nextstarttime.Width = 89
        '
        'cb_defaultmanualbackup
        '
        Me.cb_defaultmanualbackup.AutoSize = True
        Me.cb_defaultmanualbackup.BackColor = System.Drawing.Color.Transparent
        Me.cb_defaultmanualbackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_defaultmanualbackup.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cb_defaultmanualbackup.Location = New System.Drawing.Point(12, 230)
        Me.cb_defaultmanualbackup.Name = "cb_defaultmanualbackup"
        Me.cb_defaultmanualbackup.Size = New System.Drawing.Size(336, 21)
        Me.cb_defaultmanualbackup.TabIndex = 32
        Me.cb_defaultmanualbackup.Text = "Start Default Full backup for selected Folderpair?"
        Me.cb_defaultmanualbackup.UseVisualStyleBackColor = False
        '
        'home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImage = Global.WinBackupper.My.Resources.Resources.gray_background_3
        Me.ClientSize = New System.Drawing.Size(454, 429)
        Me.Controls.Add(Me.cb_defaultmanualbackup)
        Me.Controls.Add(Me.lv_overview)
        Me.Controls.Add(Me.l_log)
        Me.Controls.Add(Me.rtb_log)
        Me.Controls.Add(Me.l_version)
        Me.Controls.Add(Me.b_update)
        Me.Controls.Add(Me.b_settings)
        Me.Controls.Add(Me.b_start)
        Me.Controls.Add(Me.l_title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "home"
        Me.Text = "WinBackupper"
        Me.ContextMenuStrip1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents l_title As System.Windows.Forms.Label
    Friend WithEvents b_start As System.Windows.Forms.Button
    Friend WithEvents b_settings As System.Windows.Forms.Button
    Friend WithEvents fbd_searchSource As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents fbd_searchBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents b_update As System.Windows.Forms.Button
    Friend WithEvents l_version As System.Windows.Forms.Label
    Friend WithEvents bw_versionControll As System.ComponentModel.BackgroundWorker
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_per_Minute As System.Windows.Forms.Timer
    Friend WithEvents rtb_log As System.Windows.Forms.RichTextBox
    Friend WithEvents l_log As System.Windows.Forms.Label
    Friend WithEvents lv_overview As System.Windows.Forms.ListView
    Friend WithEvents ch_index As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_source As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_backup As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_nextstarttime As System.Windows.Forms.ColumnHeader
    Friend WithEvents cb_defaultmanualbackup As System.Windows.Forms.CheckBox

End Class
