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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(home))
        Me.l_title = New System.Windows.Forms.Label()
        Me.l_sourcePath = New System.Windows.Forms.Label()
        Me.l_backupPath = New System.Windows.Forms.Label()
        Me.b_start = New System.Windows.Forms.Button()
        Me.b_settings = New System.Windows.Forms.Button()
        Me.fbd_searchSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.fbd_searchBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.b_update = New System.Windows.Forms.Button()
        Me.l_version = New System.Windows.Forms.Label()
        Me.bw_versionControll = New System.ComponentModel.BackgroundWorker()
        Me.RTB_Sourcepath = New System.Windows.Forms.RichTextBox()
        Me.RTB_Backuppath = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'l_title
        '
        Me.l_title.AutoSize = True
        Me.l_title.BackColor = System.Drawing.Color.Transparent
        Me.l_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_title.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_title.Location = New System.Drawing.Point(132, 23)
        Me.l_title.Name = "l_title"
        Me.l_title.Size = New System.Drawing.Size(208, 25)
        Me.l_title.TabIndex = 0
        Me.l_title.Text = "Windows Backupper"
        '
        'l_sourcePath
        '
        Me.l_sourcePath.AutoSize = True
        Me.l_sourcePath.BackColor = System.Drawing.Color.Transparent
        Me.l_sourcePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_sourcePath.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_sourcePath.Location = New System.Drawing.Point(71, 62)
        Me.l_sourcePath.Name = "l_sourcePath"
        Me.l_sourcePath.Size = New System.Drawing.Size(90, 17)
        Me.l_sourcePath.TabIndex = 1
        Me.l_sourcePath.Text = "Source Path:"
        '
        'l_backupPath
        '
        Me.l_backupPath.AutoSize = True
        Me.l_backupPath.BackColor = System.Drawing.Color.Transparent
        Me.l_backupPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_backupPath.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_backupPath.Location = New System.Drawing.Point(294, 62)
        Me.l_backupPath.Name = "l_backupPath"
        Me.l_backupPath.Size = New System.Drawing.Size(92, 17)
        Me.l_backupPath.TabIndex = 2
        Me.l_backupPath.Text = "Backup Path:"
        '
        'b_start
        '
        Me.b_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_start.Location = New System.Drawing.Point(12, 230)
        Me.b_start.Name = "b_start"
        Me.b_start.Size = New System.Drawing.Size(430, 35)
        Me.b_start.TabIndex = 7
        Me.b_start.Text = "Start Backup"
        Me.b_start.UseVisualStyleBackColor = True
        '
        'b_settings
        '
        Me.b_settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_settings.Location = New System.Drawing.Point(12, 267)
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
        Me.b_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_update.Location = New System.Drawing.Point(153, 267)
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
        Me.l_version.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_version.Location = New System.Drawing.Point(363, 278)
        Me.l_version.Name = "l_version"
        Me.l_version.Size = New System.Drawing.Size(77, 13)
        Me.l_version.TabIndex = 11
        Me.l_version.Text = "Version: x.x.x.x"
        '
        'bw_versionControll
        '
        '
        'RTB_Sourcepath
        '
        Me.RTB_Sourcepath.Location = New System.Drawing.Point(15, 82)
        Me.RTB_Sourcepath.Name = "RTB_Sourcepath"
        Me.RTB_Sourcepath.Size = New System.Drawing.Size(198, 142)
        Me.RTB_Sourcepath.TabIndex = 12
        Me.RTB_Sourcepath.Text = ""
        '
        'RTB_Backuppath
        '
        Me.RTB_Backuppath.Location = New System.Drawing.Point(228, 82)
        Me.RTB_Backuppath.Name = "RTB_Backuppath"
        Me.RTB_Backuppath.Size = New System.Drawing.Size(214, 142)
        Me.RTB_Backuppath.TabIndex = 13
        Me.RTB_Backuppath.Text = ""
        '
        'home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImage = Global.WinBackupper.My.Resources.Resources.gray_background_3
        Me.ClientSize = New System.Drawing.Size(454, 321)
        Me.Controls.Add(Me.RTB_Backuppath)
        Me.Controls.Add(Me.RTB_Sourcepath)
        Me.Controls.Add(Me.l_version)
        Me.Controls.Add(Me.b_update)
        Me.Controls.Add(Me.b_settings)
        Me.Controls.Add(Me.b_start)
        Me.Controls.Add(Me.l_backupPath)
        Me.Controls.Add(Me.l_sourcePath)
        Me.Controls.Add(Me.l_title)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "home"
        Me.Text = "WinBackupper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents l_title As System.Windows.Forms.Label
    Friend WithEvents l_sourcePath As System.Windows.Forms.Label
    Friend WithEvents l_backupPath As System.Windows.Forms.Label
    Friend WithEvents b_start As System.Windows.Forms.Button
    Friend WithEvents b_settings As System.Windows.Forms.Button
    Friend WithEvents fbd_searchSource As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents fbd_searchBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents b_update As System.Windows.Forms.Button
    Friend WithEvents l_version As System.Windows.Forms.Label
    Friend WithEvents bw_versionControll As System.ComponentModel.BackgroundWorker
    Friend WithEvents RTB_Sourcepath As System.Windows.Forms.RichTextBox
    Friend WithEvents RTB_Backuppath As System.Windows.Forms.RichTextBox

End Class
