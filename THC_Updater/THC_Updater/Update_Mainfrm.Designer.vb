<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Update_Mainfrm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Update_Mainfrm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.speedlbl = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.changelogtxtbox = New System.Windows.Forms.RichTextBox()
        Me.loglbl = New System.Windows.Forms.Label()
        Me.btn_closefrm = New System.Windows.Forms.Button()
        Me.lbl_Downloadrate = New System.Windows.Forms.Label()
        Me.lbl_alreadydownloaded = New System.Windows.Forms.Label()
        Me.bw_getProgVersion = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(18, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(542, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please wait while your program is beeing updated!"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(23, 515)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(537, 36)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 1
        '
        'speedlbl
        '
        Me.speedlbl.AutoSize = True
        Me.speedlbl.BackColor = System.Drawing.Color.Transparent
        Me.speedlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.speedlbl.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.speedlbl.Location = New System.Drawing.Point(19, 490)
        Me.speedlbl.Name = "speedlbl"
        Me.speedlbl.Size = New System.Drawing.Size(167, 22)
        Me.speedlbl.TabIndex = 3
        Me.speedlbl.Text = "Downloading Rate: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(281, 490)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Allready downloaded: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(221, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Changelog:"
        '
        'changelogtxtbox
        '
        Me.changelogtxtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changelogtxtbox.Location = New System.Drawing.Point(23, 75)
        Me.changelogtxtbox.Name = "changelogtxtbox"
        Me.changelogtxtbox.Size = New System.Drawing.Size(537, 403)
        Me.changelogtxtbox.TabIndex = 6
        Me.changelogtxtbox.Text = ""
        '
        'loglbl
        '
        Me.loglbl.AutoSize = True
        Me.loglbl.BackColor = System.Drawing.Color.Transparent
        Me.loglbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loglbl.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.loglbl.Location = New System.Drawing.Point(176, 571)
        Me.loglbl.Name = "loglbl"
        Me.loglbl.Size = New System.Drawing.Size(0, 24)
        Me.loglbl.TabIndex = 8
        '
        'btn_closefrm
        '
        Me.btn_closefrm.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btn_closefrm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_closefrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_closefrm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_closefrm.Location = New System.Drawing.Point(23, 557)
        Me.btn_closefrm.Name = "btn_closefrm"
        Me.btn_closefrm.Size = New System.Drawing.Size(537, 38)
        Me.btn_closefrm.TabIndex = 15
        Me.btn_closefrm.Text = "Close Updater"
        Me.btn_closefrm.UseVisualStyleBackColor = False
        '
        'lbl_Downloadrate
        '
        Me.lbl_Downloadrate.AutoSize = True
        Me.lbl_Downloadrate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Downloadrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Downloadrate.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lbl_Downloadrate.Location = New System.Drawing.Point(185, 490)
        Me.lbl_Downloadrate.Name = "lbl_Downloadrate"
        Me.lbl_Downloadrate.Size = New System.Drawing.Size(40, 22)
        Me.lbl_Downloadrate.TabIndex = 16
        Me.lbl_Downloadrate.Text = "N/A"
        '
        'lbl_alreadydownloaded
        '
        Me.lbl_alreadydownloaded.AutoSize = True
        Me.lbl_alreadydownloaded.BackColor = System.Drawing.Color.Transparent
        Me.lbl_alreadydownloaded.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_alreadydownloaded.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lbl_alreadydownloaded.Location = New System.Drawing.Point(475, 490)
        Me.lbl_alreadydownloaded.Name = "lbl_alreadydownloaded"
        Me.lbl_alreadydownloaded.Size = New System.Drawing.Size(40, 22)
        Me.lbl_alreadydownloaded.TabIndex = 17
        Me.lbl_alreadydownloaded.Text = "N/A"
        '
        'bw_getProgVersion
        '
        '
        'Update_Mainfrm
        '
        Me.AcceptButton = Me.btn_closefrm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.THC_Updater.My.Resources.Resources.gray_background_3
        Me.CancelButton = Me.btn_closefrm
        Me.ClientSize = New System.Drawing.Size(580, 607)
        Me.Controls.Add(Me.lbl_alreadydownloaded)
        Me.Controls.Add(Me.lbl_Downloadrate)
        Me.Controls.Add(Me.btn_closefrm)
        Me.Controls.Add(Me.loglbl)
        Me.Controls.Add(Me.changelogtxtbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.speedlbl)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Update_Mainfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "THCode Updater"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents speedlbl As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents changelogtxtbox As System.Windows.Forms.RichTextBox
    Friend WithEvents loglbl As System.Windows.Forms.Label
    Friend WithEvents btn_closefrm As System.Windows.Forms.Button
    Friend WithEvents lbl_Downloadrate As System.Windows.Forms.Label
    Friend WithEvents lbl_alreadydownloaded As System.Windows.Forms.Label
    Friend WithEvents bw_getProgVersion As System.ComponentModel.BackgroundWorker

End Class
