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
        Me.b_searchDefaultBackup = New System.Windows.Forms.Button()
        Me.b_searchDefaultSource = New System.Windows.Forms.Button()
        Me.tb_defaultBackupPath = New System.Windows.Forms.TextBox()
        Me.tb_defaultSourcePath = New System.Windows.Forms.TextBox()
        Me.l_defaultBackupPath = New System.Windows.Forms.Label()
        Me.l_defaultSourcePath = New System.Windows.Forms.Label()
        Me.l_settings = New System.Windows.Forms.Label()
        Me.b_save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'b_searchDefaultBackup
        '
        Me.b_searchDefaultBackup.Location = New System.Drawing.Point(366, 141)
        Me.b_searchDefaultBackup.Name = "b_searchDefaultBackup"
        Me.b_searchDefaultBackup.Size = New System.Drawing.Size(75, 23)
        Me.b_searchDefaultBackup.TabIndex = 16
        Me.b_searchDefaultBackup.Text = "Search"
        Me.b_searchDefaultBackup.UseVisualStyleBackColor = True
        '
        'b_searchDefaultSource
        '
        Me.b_searchDefaultSource.Location = New System.Drawing.Point(366, 78)
        Me.b_searchDefaultSource.Name = "b_searchDefaultSource"
        Me.b_searchDefaultSource.Size = New System.Drawing.Size(75, 23)
        Me.b_searchDefaultSource.TabIndex = 15
        Me.b_searchDefaultSource.Text = "Search"
        Me.b_searchDefaultSource.UseVisualStyleBackColor = True
        '
        'tb_defaultBackupPath
        '
        Me.tb_defaultBackupPath.Location = New System.Drawing.Point(15, 143)
        Me.tb_defaultBackupPath.Name = "tb_defaultBackupPath"
        Me.tb_defaultBackupPath.ReadOnly = True
        Me.tb_defaultBackupPath.Size = New System.Drawing.Size(325, 20)
        Me.tb_defaultBackupPath.TabIndex = 14
        '
        'tb_defaultSourcePath
        '
        Me.tb_defaultSourcePath.Location = New System.Drawing.Point(15, 80)
        Me.tb_defaultSourcePath.Name = "tb_defaultSourcePath"
        Me.tb_defaultSourcePath.ReadOnly = True
        Me.tb_defaultSourcePath.Size = New System.Drawing.Size(325, 20)
        Me.tb_defaultSourcePath.TabIndex = 13
        '
        'l_defaultBackupPath
        '
        Me.l_defaultBackupPath.AutoSize = True
        Me.l_defaultBackupPath.Location = New System.Drawing.Point(12, 130)
        Me.l_defaultBackupPath.Name = "l_defaultBackupPath"
        Me.l_defaultBackupPath.Size = New System.Drawing.Size(109, 13)
        Me.l_defaultBackupPath.TabIndex = 12
        Me.l_defaultBackupPath.Text = "Default Backup Path:"
        '
        'l_defaultSourcePath
        '
        Me.l_defaultSourcePath.AutoSize = True
        Me.l_defaultSourcePath.Location = New System.Drawing.Point(12, 66)
        Me.l_defaultSourcePath.Name = "l_defaultSourcePath"
        Me.l_defaultSourcePath.Size = New System.Drawing.Size(106, 13)
        Me.l_defaultSourcePath.TabIndex = 11
        Me.l_defaultSourcePath.Text = "Default Source Path:"
        '
        'l_settings
        '
        Me.l_settings.AutoSize = True
        Me.l_settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_settings.Location = New System.Drawing.Point(168, 23)
        Me.l_settings.Name = "l_settings"
        Me.l_settings.Size = New System.Drawing.Size(90, 25)
        Me.l_settings.TabIndex = 10
        Me.l_settings.Text = "Settings"
        '
        'b_save
        '
        Me.b_save.Location = New System.Drawing.Point(15, 192)
        Me.b_save.Name = "b_save"
        Me.b_save.Size = New System.Drawing.Size(426, 35)
        Me.b_save.TabIndex = 18
        Me.b_save.Text = "Save"
        Me.b_save.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(454, 248)
        Me.Controls.Add(Me.b_save)
        Me.Controls.Add(Me.b_searchDefaultBackup)
        Me.Controls.Add(Me.b_searchDefaultSource)
        Me.Controls.Add(Me.tb_defaultBackupPath)
        Me.Controls.Add(Me.tb_defaultSourcePath)
        Me.Controls.Add(Me.l_defaultBackupPath)
        Me.Controls.Add(Me.l_defaultSourcePath)
        Me.Controls.Add(Me.l_settings)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_searchDefaultBackup As System.Windows.Forms.Button
    Friend WithEvents b_searchDefaultSource As System.Windows.Forms.Button
    Friend WithEvents tb_defaultBackupPath As System.Windows.Forms.TextBox
    Friend WithEvents tb_defaultSourcePath As System.Windows.Forms.TextBox
    Friend WithEvents l_defaultBackupPath As System.Windows.Forms.Label
    Friend WithEvents l_defaultSourcePath As System.Windows.Forms.Label
    Friend WithEvents l_settings As System.Windows.Forms.Label
    Friend WithEvents b_save As System.Windows.Forms.Button
End Class
