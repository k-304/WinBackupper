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
        Me.l_title = New System.Windows.Forms.Label()
        Me.l_sourcePath = New System.Windows.Forms.Label()
        Me.l_backupPath = New System.Windows.Forms.Label()
        Me.tb_sourcePath = New System.Windows.Forms.TextBox()
        Me.tb_backupPath = New System.Windows.Forms.TextBox()
        Me.b_searchSource = New System.Windows.Forms.Button()
        Me.b_searchBackup = New System.Windows.Forms.Button()
        Me.b_start = New System.Windows.Forms.Button()
        Me.b_settings = New System.Windows.Forms.Button()
        Me.l_version = New System.Windows.Forms.Label()
        Me.fbd_searchSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.fbd_searchBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'l_title
        '
        Me.l_title.AutoSize = True
        Me.l_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_title.Location = New System.Drawing.Point(132, 23)
        Me.l_title.Name = "l_title"
        Me.l_title.Size = New System.Drawing.Size(208, 25)
        Me.l_title.TabIndex = 0
        Me.l_title.Text = "Windows Backupper"
        '
        'l_sourcePath
        '
        Me.l_sourcePath.AutoSize = True
        Me.l_sourcePath.Location = New System.Drawing.Point(12, 66)
        Me.l_sourcePath.Name = "l_sourcePath"
        Me.l_sourcePath.Size = New System.Drawing.Size(69, 13)
        Me.l_sourcePath.TabIndex = 1
        Me.l_sourcePath.Text = "Source Path:"
        '
        'l_backupPath
        '
        Me.l_backupPath.AutoSize = True
        Me.l_backupPath.Location = New System.Drawing.Point(12, 130)
        Me.l_backupPath.Name = "l_backupPath"
        Me.l_backupPath.Size = New System.Drawing.Size(72, 13)
        Me.l_backupPath.TabIndex = 2
        Me.l_backupPath.Text = "Backup Path:"
        '
        'tb_sourcePath
        '
        Me.tb_sourcePath.Location = New System.Drawing.Point(15, 80)
        Me.tb_sourcePath.Name = "tb_sourcePath"
        Me.tb_sourcePath.ReadOnly = True
        Me.tb_sourcePath.Size = New System.Drawing.Size(325, 20)
        Me.tb_sourcePath.TabIndex = 3
        '
        'tb_backupPath
        '
        Me.tb_backupPath.Location = New System.Drawing.Point(15, 143)
        Me.tb_backupPath.Name = "tb_backupPath"
        Me.tb_backupPath.ReadOnly = True
        Me.tb_backupPath.Size = New System.Drawing.Size(325, 20)
        Me.tb_backupPath.TabIndex = 4
        '
        'b_searchSource
        '
        Me.b_searchSource.Location = New System.Drawing.Point(366, 78)
        Me.b_searchSource.Name = "b_searchSource"
        Me.b_searchSource.Size = New System.Drawing.Size(75, 23)
        Me.b_searchSource.TabIndex = 5
        Me.b_searchSource.Text = "Search"
        Me.b_searchSource.UseVisualStyleBackColor = True
        '
        'b_searchBackup
        '
        Me.b_searchBackup.Location = New System.Drawing.Point(366, 141)
        Me.b_searchBackup.Name = "b_searchBackup"
        Me.b_searchBackup.Size = New System.Drawing.Size(75, 23)
        Me.b_searchBackup.TabIndex = 6
        Me.b_searchBackup.Text = "Search"
        Me.b_searchBackup.UseVisualStyleBackColor = True
        '
        'b_start
        '
        Me.b_start.Location = New System.Drawing.Point(15, 192)
        Me.b_start.Name = "b_start"
        Me.b_start.Size = New System.Drawing.Size(426, 35)
        Me.b_start.TabIndex = 7
        Me.b_start.Text = "Start Backup"
        Me.b_start.UseVisualStyleBackColor = True
        '
        'b_settings
        '
        Me.b_settings.Location = New System.Drawing.Point(15, 274)
        Me.b_settings.Name = "b_settings"
        Me.b_settings.Size = New System.Drawing.Size(118, 23)
        Me.b_settings.TabIndex = 8
        Me.b_settings.Text = "Settings"
        Me.b_settings.UseVisualStyleBackColor = True
        '
        'l_version
        '
        Me.l_version.AutoSize = True
        Me.l_version.Location = New System.Drawing.Point(363, 284)
        Me.l_version.Name = "l_version"
        Me.l_version.Size = New System.Drawing.Size(69, 13)
        Me.l_version.TabIndex = 9
        Me.l_version.Text = "Version: beta"
        '
        'fbd_searchSource
        '
        '
        'fbd_searchBackup
        '
        '
        'home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(454, 321)
        Me.Controls.Add(Me.l_version)
        Me.Controls.Add(Me.b_settings)
        Me.Controls.Add(Me.b_start)
        Me.Controls.Add(Me.b_searchBackup)
        Me.Controls.Add(Me.b_searchSource)
        Me.Controls.Add(Me.tb_backupPath)
        Me.Controls.Add(Me.tb_sourcePath)
        Me.Controls.Add(Me.l_backupPath)
        Me.Controls.Add(Me.l_sourcePath)
        Me.Controls.Add(Me.l_title)
        Me.Name = "home"
        Me.Text = "WinBackupper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents l_title As System.Windows.Forms.Label
    Friend WithEvents l_sourcePath As System.Windows.Forms.Label
    Friend WithEvents l_backupPath As System.Windows.Forms.Label
    Friend WithEvents tb_sourcePath As System.Windows.Forms.TextBox
    Friend WithEvents tb_backupPath As System.Windows.Forms.TextBox
    Friend WithEvents b_searchSource As System.Windows.Forms.Button
    Friend WithEvents b_searchBackup As System.Windows.Forms.Button
    Friend WithEvents b_start As System.Windows.Forms.Button
    Friend WithEvents b_settings As System.Windows.Forms.Button
    Friend WithEvents l_version As System.Windows.Forms.Label
    Friend WithEvents fbd_searchSource As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents fbd_searchBackup As System.Windows.Forms.FolderBrowserDialog

End Class
