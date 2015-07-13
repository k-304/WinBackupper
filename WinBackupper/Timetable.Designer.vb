<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Timetable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Timetable))
        Me.dtp = New System.Windows.Forms.DateTimePicker()
        Me.b_add = New System.Windows.Forms.Button()
        Me.b_stopediting = New System.Windows.Forms.Button()
        Me.b_remove = New System.Windows.Forms.Button()
        Me.dd_Day = New System.Windows.Forms.ComboBox()
        Me.l_sourcePath = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_intervall = New System.Windows.Forms.TextBox()
        Me.b_reset = New System.Windows.Forms.Button()
        Me.cb_intervall = New System.Windows.Forms.CheckBox()
        Me.lv_timetable = New System.Windows.Forms.ListView()
        Me.ch_starttime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_backuptype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.b_changebackuptype = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dtp
        '
        Me.dtp.CustomFormat = "HH:mm"
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(132, 40)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(126, 20)
        Me.dtp.TabIndex = 0
        '
        'b_add
        '
        Me.b_add.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_add.Location = New System.Drawing.Point(9, 404)
        Me.b_add.Name = "b_add"
        Me.b_add.Size = New System.Drawing.Size(247, 36)
        Me.b_add.TabIndex = 20
        Me.b_add.Text = "Add"
        Me.b_add.UseVisualStyleBackColor = True
        '
        'b_stopediting
        '
        Me.b_stopediting.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_stopediting.Location = New System.Drawing.Point(9, 446)
        Me.b_stopediting.Name = "b_stopediting"
        Me.b_stopediting.Size = New System.Drawing.Size(247, 36)
        Me.b_stopediting.TabIndex = 22
        Me.b_stopediting.Text = "Finish"
        Me.b_stopediting.UseVisualStyleBackColor = True
        '
        'b_remove
        '
        Me.b_remove.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_remove.Location = New System.Drawing.Point(10, 362)
        Me.b_remove.Name = "b_remove"
        Me.b_remove.Size = New System.Drawing.Size(112, 36)
        Me.b_remove.TabIndex = 23
        Me.b_remove.Text = "Remove"
        Me.b_remove.UseVisualStyleBackColor = True
        '
        'dd_Day
        '
        Me.dd_Day.FormattingEnabled = True
        Me.dd_Day.Items.AddRange(New Object() {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"})
        Me.dd_Day.Location = New System.Drawing.Point(133, 13)
        Me.dd_Day.Name = "dd_Day"
        Me.dd_Day.Size = New System.Drawing.Size(125, 21)
        Me.dd_Day.TabIndex = 25
        Me.dd_Day.Text = "Monday"
        '
        'l_sourcePath
        '
        Me.l_sourcePath.AutoSize = True
        Me.l_sourcePath.BackColor = System.Drawing.Color.Transparent
        Me.l_sourcePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l_sourcePath.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.l_sourcePath.Location = New System.Drawing.Point(12, 13)
        Me.l_sourcePath.Name = "l_sourcePath"
        Me.l_sourcePath.Size = New System.Drawing.Size(37, 17)
        Me.l_sourcePath.TabIndex = 26
        Me.l_sourcePath.Text = "Day:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(10, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Starttime:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(10, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Intervall (in h):"
        '
        'tb_intervall
        '
        Me.tb_intervall.Location = New System.Drawing.Point(132, 68)
        Me.tb_intervall.Name = "tb_intervall"
        Me.tb_intervall.Size = New System.Drawing.Size(126, 20)
        Me.tb_intervall.TabIndex = 29
        Me.tb_intervall.Text = "24"
        '
        'b_reset
        '
        Me.b_reset.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_reset.Location = New System.Drawing.Point(131, 362)
        Me.b_reset.Name = "b_reset"
        Me.b_reset.Size = New System.Drawing.Size(125, 36)
        Me.b_reset.TabIndex = 30
        Me.b_reset.Text = "Reset"
        Me.b_reset.UseVisualStyleBackColor = True
        '
        'cb_intervall
        '
        Me.cb_intervall.AutoSize = True
        Me.cb_intervall.BackColor = System.Drawing.Color.Transparent
        Me.cb_intervall.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_intervall.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cb_intervall.Location = New System.Drawing.Point(12, 293)
        Me.cb_intervall.Name = "cb_intervall"
        Me.cb_intervall.Size = New System.Drawing.Size(160, 21)
        Me.cb_intervall.TabIndex = 31
        Me.cb_intervall.Text = "Add intervall entries?"
        Me.cb_intervall.UseVisualStyleBackColor = False
        '
        'lv_timetable
        '
        Me.lv_timetable.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_starttime, Me.ch_backuptype})
        Me.lv_timetable.Location = New System.Drawing.Point(10, 105)
        Me.lv_timetable.Name = "lv_timetable"
        Me.lv_timetable.Size = New System.Drawing.Size(248, 182)
        Me.lv_timetable.TabIndex = 32
        Me.lv_timetable.UseCompatibleStateImageBehavior = False
        Me.lv_timetable.View = System.Windows.Forms.View.Details
        '
        'ch_starttime
        '
        Me.ch_starttime.Text = "Starttime"
        Me.ch_starttime.Width = 67
        '
        'ch_backuptype
        '
        Me.ch_backuptype.Text = "Backup type"
        Me.ch_backuptype.Width = 76
        '
        'b_changebackuptype
        '
        Me.b_changebackuptype.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b_changebackuptype.Location = New System.Drawing.Point(9, 320)
        Me.b_changebackuptype.Name = "b_changebackuptype"
        Me.b_changebackuptype.Size = New System.Drawing.Size(246, 36)
        Me.b_changebackuptype.TabIndex = 33
        Me.b_changebackuptype.Text = "Change Backuptype"
        Me.b_changebackuptype.UseVisualStyleBackColor = True
        '
        'Timetable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WinBackupper.My.Resources.Resources.gray_background_3
        Me.ClientSize = New System.Drawing.Size(267, 494)
        Me.Controls.Add(Me.b_changebackuptype)
        Me.Controls.Add(Me.lv_timetable)
        Me.Controls.Add(Me.cb_intervall)
        Me.Controls.Add(Me.b_reset)
        Me.Controls.Add(Me.tb_intervall)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.l_sourcePath)
        Me.Controls.Add(Me.dd_Day)
        Me.Controls.Add(Me.b_remove)
        Me.Controls.Add(Me.b_stopediting)
        Me.Controls.Add(Me.b_add)
        Me.Controls.Add(Me.dtp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Timetable"
        Me.Text = "Choose Backup Start Times!"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents b_add As System.Windows.Forms.Button
    Friend WithEvents b_stopediting As System.Windows.Forms.Button
    Friend WithEvents b_remove As System.Windows.Forms.Button
    Friend WithEvents dd_Day As System.Windows.Forms.ComboBox
    Friend WithEvents l_sourcePath As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_intervall As System.Windows.Forms.TextBox
    Friend WithEvents b_reset As System.Windows.Forms.Button
    Friend WithEvents cb_intervall As System.Windows.Forms.CheckBox
    Friend WithEvents lv_timetable As System.Windows.Forms.ListView
    Friend WithEvents ch_starttime As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_backuptype As System.Windows.Forms.ColumnHeader
    Friend WithEvents b_changebackuptype As System.Windows.Forms.Button
End Class
