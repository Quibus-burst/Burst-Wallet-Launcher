<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFirstTime
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
        Dim Panel1 As System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.P3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.r3 = New System.Windows.Forms.RadioButton()
        Me.P2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.r2 = New System.Windows.Forms.RadioButton()
        Me.P1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.r1 = New System.Windows.Forms.RadioButton()
        Me.frmHeader = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlMariaSettings = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblMariaStatus = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblJavaStatus = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Panel1 = New System.Windows.Forms.Panel()
        Panel1.SuspendLayout()
        Me.P3.SuspendLayout()
        Me.P2.SuspendLayout()
        Me.P1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlMariaSettings.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Panel1.Controls.Add(Me.Button1)
        Panel1.Controls.Add(Me.CheckBox1)
        Panel1.Controls.Add(Me.P3)
        Panel1.Controls.Add(Me.P2)
        Panel1.Controls.Add(Me.P1)
        Panel1.Controls.Add(Me.frmHeader)
        Panel1.Location = New System.Drawing.Point(238, -1)
        Panel1.Name = "Panel1"
        Panel1.Size = New System.Drawing.Size(420, 367)
        Panel1.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(308, 325)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 31)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Continue >>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(16, 333)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(173, 17)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Turn on notification of updates."
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'P3
        '
        Me.P3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P3.Controls.Add(Me.Label6)
        Me.P3.Controls.Add(Me.Label5)
        Me.P3.Controls.Add(Me.r3)
        Me.P3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.P3.Location = New System.Drawing.Point(9, 231)
        Me.P3.Name = "P3"
        Me.P3.Size = New System.Drawing.Size(403, 90)
        Me.P3.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(258, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "You will have to enter connection details in next step."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(238, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Use installed MariaDB / MySql Database"
        '
        'r3
        '
        Me.r3.AutoSize = True
        Me.r3.Location = New System.Drawing.Point(18, 12)
        Me.r3.Name = "r3"
        Me.r3.Size = New System.Drawing.Size(14, 13)
        Me.r3.TabIndex = 0
        Me.r3.TabStop = True
        Me.r3.UseVisualStyleBackColor = True
        '
        'P2
        '
        Me.P2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P2.Controls.Add(Me.Label4)
        Me.P2.Controls.Add(Me.Label3)
        Me.P2.Controls.Add(Me.r2)
        Me.P2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.P2.Location = New System.Drawing.Point(9, 137)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(403, 90)
        Me.P2.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(292, 39)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MariaDB is used for more experienced users." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Wallet launcher will download, setup" &
    " and control this for you." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Additional footprint required is about 600Mb."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Use a portable version of MariaDB"
        '
        'r2
        '
        Me.r2.AutoSize = True
        Me.r2.Location = New System.Drawing.Point(18, 12)
        Me.r2.Name = "r2"
        Me.r2.Size = New System.Drawing.Size(14, 13)
        Me.r2.TabIndex = 0
        Me.r2.TabStop = True
        Me.r2.UseVisualStyleBackColor = True
        '
        'P1
        '
        Me.P1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.P1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P1.Controls.Add(Me.Label2)
        Me.P1.Controls.Add(Me.Label1)
        Me.P1.Controls.Add(Me.r1)
        Me.P1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.P1.Location = New System.Drawing.Point(9, 46)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(403, 87)
        Me.P1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "The Firebird database is suitable for most users." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This type also provide the sma" &
    "llest footprint."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Use Firebird database"
        '
        'r1
        '
        Me.r1.AutoSize = True
        Me.r1.Checked = True
        Me.r1.Location = New System.Drawing.Point(18, 12)
        Me.r1.Name = "r1"
        Me.r1.Size = New System.Drawing.Size(14, 13)
        Me.r1.TabIndex = 0
        Me.r1.TabStop = True
        Me.r1.UseVisualStyleBackColor = True
        '
        'frmHeader
        '
        Me.frmHeader.AutoSize = True
        Me.frmHeader.Font = New System.Drawing.Font("Rockwell", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmHeader.Location = New System.Drawing.Point(11, 11)
        Me.frmHeader.Name = "frmHeader"
        Me.frmHeader.Size = New System.Drawing.Size(397, 27)
        Me.frmHeader.TabIndex = 7
        Me.frmHeader.Text = "Please select your default settings."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(239, 368)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox2.Image = Global.BurstWalletLauncher.My.Resources.Resources.BurstLogo
        Me.PictureBox2.Location = New System.Drawing.Point(42, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(135, 135)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.Font = New System.Drawing.Font("Rockwell", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 222)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(185, 19)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Burst Wallet Launcher"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label8.Location = New System.Drawing.Point(19, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(193, 39)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Please choose your initial settings." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The default settings will get you started." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The settings can be changed later."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label9.Font = New System.Drawing.Font("Rockwell", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(182, 19)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Welcome to Burstcoin"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Location = New System.Drawing.Point(664, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(420, 367)
        Me.Panel2.TabIndex = 12
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(244, 325)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(81, 31)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "<< Back"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(244, 288)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(168, 31)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Download Missing components"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightCoral
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.pnlMariaSettings)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.lblMariaStatus)
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel4.Location = New System.Drawing.Point(9, 117)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(403, 157)
        Me.Panel4.TabIndex = 15
        '
        'pnlMariaSettings
        '
        Me.pnlMariaSettings.Controls.Add(Me.Button5)
        Me.pnlMariaSettings.Controls.Add(Me.TextBox4)
        Me.pnlMariaSettings.Controls.Add(Me.CheckBox2)
        Me.pnlMariaSettings.Controls.Add(Me.Label17)
        Me.pnlMariaSettings.Controls.Add(Me.TextBox3)
        Me.pnlMariaSettings.Controls.Add(Me.Label16)
        Me.pnlMariaSettings.Controls.Add(Me.TextBox2)
        Me.pnlMariaSettings.Controls.Add(Me.Label15)
        Me.pnlMariaSettings.Controls.Add(Me.TextBox1)
        Me.pnlMariaSettings.Controls.Add(Me.Label13)
        Me.pnlMariaSettings.Location = New System.Drawing.Point(10, 28)
        Me.pnlMariaSettings.Name = "pnlMariaSettings"
        Me.pnlMariaSettings.Size = New System.Drawing.Size(377, 126)
        Me.pnlMariaSettings.TabIndex = 3
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(257, 93)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(117, 24)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Test connection"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(96, 69)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(231, 20)
        Me.TextBox4.TabIndex = 7
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(12, 98)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(239, 17)
        Me.CheckBox2.TabIndex = 5
        Me.CheckBox2.Text = "Create database and install schema if missing"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Password:"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(96, 48)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(231, 20)
        Me.TextBox3.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Database:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(96, 27)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(231, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "burstwallet"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Username:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(96, 6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(231, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "127.0.0.1:3306"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Server address:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "MariaDB"
        '
        'lblMariaStatus
        '
        Me.lblMariaStatus.AutoSize = True
        Me.lblMariaStatus.Location = New System.Drawing.Point(7, 32)
        Me.lblMariaStatus.Name = "lblMariaStatus"
        Me.lblMariaStatus.Size = New System.Drawing.Size(157, 13)
        Me.lblMariaStatus.TabIndex = 4
        Me.lblMariaStatus.Text = "MariaDB is not yet downloaded."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Rockwell", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(216, 27)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Verifying settings."
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblJavaStatus)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel3.Location = New System.Drawing.Point(9, 46)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(403, 65)
        Me.Panel3.TabIndex = 13
        '
        'lblJavaStatus
        '
        Me.lblJavaStatus.AutoSize = True
        Me.lblJavaStatus.Location = New System.Drawing.Point(7, 28)
        Me.lblJavaStatus.Name = "lblJavaStatus"
        Me.lblJavaStatus.Size = New System.Drawing.Size(199, 13)
        Me.lblJavaStatus.TabIndex = 3
        Me.lblJavaStatus.Text = "Java was found installed on your system."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Java"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(331, 325)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 31)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Done"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmFirstTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(658, 367)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmFirstTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "First Time"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Me.P3.ResumeLayout(False)
        Me.P3.PerformLayout()
        Me.P2.ResumeLayout(False)
        Me.P2.PerformLayout()
        Me.P1.ResumeLayout(False)
        Me.P1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlMariaSettings.ResumeLayout(False)
        Me.pnlMariaSettings.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents P3 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents r3 As RadioButton
    Friend WithEvents P2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents r2 As RadioButton
    Friend WithEvents P1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents r1 As RadioButton
    Friend WithEvents frmHeader As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents pnlMariaSettings As Panel
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblJavaStatus As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents lblMariaStatus As Label
End Class
