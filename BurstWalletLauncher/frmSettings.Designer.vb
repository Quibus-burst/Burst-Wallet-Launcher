<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkCheckForUpdates = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMaxCores = New System.Windows.Forms.Label()
        Me.lblRecommendedCPU = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.nrCores = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkAutoIP = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblDb = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlMaria = New System.Windows.Forms.Panel()
        Me.pnlDbSettings = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDbPass = New System.Windows.Forms.TextBox()
        Me.txtDbUser = New System.Windows.Forms.TextBox()
        Me.txtDbName = New System.Windows.Forms.TextBox()
        Me.txtDbServer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rJava1 = New System.Windows.Forms.RadioButton()
        Me.rJava0 = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkOpenCL = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.nrCores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnlMaria.SuspendLayout()
        Me.pnlDbSettings.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(358, 352)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkCheckForUpdates
        '
        Me.chkCheckForUpdates.AutoSize = True
        Me.chkCheckForUpdates.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkCheckForUpdates.Checked = True
        Me.chkCheckForUpdates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCheckForUpdates.Location = New System.Drawing.Point(12, 33)
        Me.chkCheckForUpdates.Name = "chkCheckForUpdates"
        Me.chkCheckForUpdates.Size = New System.Drawing.Size(202, 17)
        Me.chkCheckForUpdates.TabIndex = 1
        Me.chkCheckForUpdates.Text = "Turn on software update notification. "
        Me.chkCheckForUpdates.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.ItemSize = New System.Drawing.Size(35, 100)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(574, 399)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Location = New System.Drawing.Point(104, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(466, 391)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Launcher"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.chkOpenCL)
        Me.Panel1.Controls.Add(Me.lblMaxCores)
        Me.Panel1.Controls.Add(Me.lblRecommendedCPU)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.nrCores)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Location = New System.Drawing.Point(24, 156)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 190)
        Me.Panel1.TabIndex = 9
        '
        'lblMaxCores
        '
        Me.lblMaxCores.AutoSize = True
        Me.lblMaxCores.Location = New System.Drawing.Point(143, 69)
        Me.lblMaxCores.Name = "lblMaxCores"
        Me.lblMaxCores.Size = New System.Drawing.Size(42, 13)
        Me.lblMaxCores.TabIndex = 7
        Me.lblMaxCores.Text = "6 cores"
        '
        'lblRecommendedCPU
        '
        Me.lblRecommendedCPU.AutoSize = True
        Me.lblRecommendedCPU.Location = New System.Drawing.Point(220, 45)
        Me.lblRecommendedCPU.Name = "lblRecommendedCPU"
        Me.lblRecommendedCPU.Size = New System.Drawing.Size(42, 13)
        Me.lblRecommendedCPU.TabIndex = 6
        Me.lblRecommendedCPU.Text = "6 cores"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(29, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(195, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Recomended value for your computer is" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(109, 69)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "of max "
        '
        'nrCores
        '
        Me.nrCores.Location = New System.Drawing.Point(64, 67)
        Me.nrCores.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nrCores.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nrCores.Name = "nrCores"
        Me.nrCores.Size = New System.Drawing.Size(40, 20)
        Me.nrCores.TabIndex = 3
        Me.nrCores.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(29, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Use:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(29, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(295, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Note: During sync of blockchain cpu usage can be massive. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "NRS Settings"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.chkAutoIP)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.chkCheckForUpdates)
        Me.Panel2.Location = New System.Drawing.Point(24, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(417, 106)
        Me.Panel2.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(29, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(263, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "This will not download and install any updates by itself."
        '
        'chkAutoIP
        '
        Me.chkAutoIP.AutoSize = True
        Me.chkAutoIP.Checked = True
        Me.chkAutoIP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoIP.Location = New System.Drawing.Point(11, 73)
        Me.chkAutoIP.Name = "chkAutoIP"
        Me.chkAutoIP.Size = New System.Drawing.Size(307, 17)
        Me.chkAutoIP.TabIndex = 2
        Me.chkAutoIP.Text = "Automatically find your ip and configure NRS on wallet start."
        Me.chkAutoIP.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(190, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Updates and configuration"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Rockwell", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "General settings"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblDb)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.pnlMaria)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(104, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(466, 391)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Database"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblDb
        '
        Me.lblDb.AutoSize = True
        Me.lblDb.Location = New System.Drawing.Point(139, 44)
        Me.lblDb.Name = "lblDb"
        Me.lblDb.Size = New System.Drawing.Size(0, 13)
        Me.lblDb.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(21, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "You are currently using: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(375, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "If you want to change database please use ""change database"" in tools menu."
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(358, 352)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 33)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'pnlMaria
        '
        Me.pnlMaria.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pnlMaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMaria.Controls.Add(Me.pnlDbSettings)
        Me.pnlMaria.Controls.Add(Me.Label4)
        Me.pnlMaria.Enabled = False
        Me.pnlMaria.Location = New System.Drawing.Point(24, 81)
        Me.pnlMaria.Name = "pnlMaria"
        Me.pnlMaria.Size = New System.Drawing.Size(417, 161)
        Me.pnlMaria.TabIndex = 10
        '
        'pnlDbSettings
        '
        Me.pnlDbSettings.Controls.Add(Me.Label19)
        Me.pnlDbSettings.Controls.Add(Me.Label8)
        Me.pnlDbSettings.Controls.Add(Me.Label7)
        Me.pnlDbSettings.Controls.Add(Me.Label6)
        Me.pnlDbSettings.Controls.Add(Me.txtDbPass)
        Me.pnlDbSettings.Controls.Add(Me.txtDbUser)
        Me.pnlDbSettings.Controls.Add(Me.txtDbName)
        Me.pnlDbSettings.Controls.Add(Me.txtDbServer)
        Me.pnlDbSettings.Controls.Add(Me.Label5)
        Me.pnlDbSettings.Enabled = False
        Me.pnlDbSettings.Location = New System.Drawing.Point(3, 29)
        Me.pnlDbSettings.Name = "pnlDbSettings"
        Me.pnlDbSettings.Size = New System.Drawing.Size(411, 126)
        Me.pnlDbSettings.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(87, 92)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(193, 13)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "note: Database and schema must exist."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Password:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Username:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Database:"
        '
        'txtDbPass
        '
        Me.txtDbPass.Location = New System.Drawing.Point(90, 69)
        Me.txtDbPass.Name = "txtDbPass"
        Me.txtDbPass.Size = New System.Drawing.Size(303, 20)
        Me.txtDbPass.TabIndex = 4
        '
        'txtDbUser
        '
        Me.txtDbUser.Location = New System.Drawing.Point(90, 48)
        Me.txtDbUser.Name = "txtDbUser"
        Me.txtDbUser.Size = New System.Drawing.Size(303, 20)
        Me.txtDbUser.TabIndex = 3
        '
        'txtDbName
        '
        Me.txtDbName.Location = New System.Drawing.Point(90, 27)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.Size = New System.Drawing.Size(303, 20)
        Me.txtDbName.TabIndex = 2
        '
        'txtDbServer
        '
        Me.txtDbServer.Location = New System.Drawing.Point(90, 6)
        Me.txtDbServer.Name = "txtDbServer"
        Me.txtDbServer.Size = New System.Drawing.Size(303, 20)
        Me.txtDbServer.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "ServerAddress:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Own MariaDB / MySql Settings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Rockwell", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Database settings"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Location = New System.Drawing.Point(104, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(466, 391)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Java"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(358, 352)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(100, 33)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Save"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.rJava1)
        Me.Panel3.Controls.Add(Me.rJava0)
        Me.Panel3.Location = New System.Drawing.Point(24, 44)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(417, 93)
        Me.Panel3.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 16)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Java Types"
        '
        'rJava1
        '
        Me.rJava1.AutoSize = True
        Me.rJava1.Location = New System.Drawing.Point(11, 53)
        Me.rJava1.Name = "rJava1"
        Me.rJava1.Size = New System.Drawing.Size(109, 17)
        Me.rJava1.TabIndex = 2
        Me.rJava1.TabStop = True
        Me.rJava1.Text = "Use Portable java"
        Me.rJava1.UseVisualStyleBackColor = True
        '
        'rJava0
        '
        Me.rJava0.AutoSize = True
        Me.rJava0.Location = New System.Drawing.Point(11, 30)
        Me.rJava0.Name = "rJava0"
        Me.rJava0.Size = New System.Drawing.Size(146, 17)
        Me.rJava0.TabIndex = 1
        Me.rJava0.TabStop = True
        Me.rJava0.Text = "Use system installed java."
        Me.rJava0.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Rockwell", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(19, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(142, 25)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Java settings"
        '
        'chkOpenCL
        '
        Me.chkOpenCL.AutoSize = True
        Me.chkOpenCL.Location = New System.Drawing.Point(32, 108)
        Me.chkOpenCL.Name = "chkOpenCL"
        Me.chkOpenCL.Size = New System.Drawing.Size(283, 17)
        Me.chkOpenCL.TabIndex = 8
        Me.chkOpenCL.Text = "Use Graphic card to verify blocks in chain during sync."
        Me.chkOpenCL.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(50, 128)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(275, 13)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "This will offload the cpu. (Requires opencl to be installed)"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(574, 399)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nrCores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.pnlMaria.ResumeLayout(False)
        Me.pnlMaria.PerformLayout()
        Me.pnlDbSettings.ResumeLayout(False)
        Me.pnlDbSettings.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents chkCheckForUpdates As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlMaria As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlDbSettings As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDbPass As TextBox
    Friend WithEvents txtDbUser As TextBox
    Friend WithEvents txtDbName As TextBox
    Friend WithEvents txtDbServer As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents chkAutoIP As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rJava1 As RadioButton
    Friend WithEvents rJava0 As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblDb As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents nrCores As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblMaxCores As Label
    Friend WithEvents lblRecommendedCPU As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents chkOpenCL As CheckBox
End Class
