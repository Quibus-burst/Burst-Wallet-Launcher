﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFirstTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFirstTime))
        Me.pnlWiz1 = New System.Windows.Forms.Panel()
        Me.P1 = New System.Windows.Forms.Panel()
        Me.lblFireBirdDesc = New System.Windows.Forms.Label()
        Me.lblFireBirdHeader = New System.Windows.Forms.Label()
        Me.r1 = New System.Windows.Forms.RadioButton()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.chkUpdates = New System.Windows.Forms.CheckBox()
        Me.P3 = New System.Windows.Forms.Panel()
        Me.lblOwnDesc = New System.Windows.Forms.Label()
        Me.lblOwnHeader = New System.Windows.Forms.Label()
        Me.r3 = New System.Windows.Forms.RadioButton()
        Me.P2 = New System.Windows.Forms.Panel()
        Me.lblPMariaDesc = New System.Windows.Forms.Label()
        Me.lblPMariaHeader = New System.Windows.Forms.Label()
        Me.r2 = New System.Windows.Forms.RadioButton()
        Me.P0 = New System.Windows.Forms.Panel()
        Me.lblH2Desc = New System.Windows.Forms.Label()
        Me.lblH2Header = New System.Windows.Forms.Label()
        Me.r0 = New System.Windows.Forms.RadioButton()
        Me.frmHeader = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PnlWiz2 = New System.Windows.Forms.Panel()
        Me.pnlDb = New System.Windows.Forms.Panel()
        Me.pnlMariaSettings = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDbPass = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDbUser = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDbName = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDbAddress = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblDbHeader = New System.Windows.Forms.Label()
        Me.lblDBstatus = New System.Windows.Forms.Label()
        Me.lblStatusInfo = New System.Windows.Forms.Label()
        Me.Pb1 = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlJava = New System.Windows.Forms.Panel()
        Me.lblJavaStatus = New System.Windows.Forms.Label()
        Me.lblJavaHeader = New System.Windows.Forms.Label()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlWiz1.SuspendLayout()
        Me.P1.SuspendLayout()
        Me.P3.SuspendLayout()
        Me.P2.SuspendLayout()
        Me.P0.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlWiz2.SuspendLayout()
        Me.pnlDb.SuspendLayout()
        Me.pnlMariaSettings.SuspendLayout()
        Me.pnlJava.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlWiz1
        '
        Me.pnlWiz1.Controls.Add(Me.P1)
        Me.pnlWiz1.Controls.Add(Me.btnNext)
        Me.pnlWiz1.Controls.Add(Me.chkUpdates)
        Me.pnlWiz1.Controls.Add(Me.P3)
        Me.pnlWiz1.Controls.Add(Me.P2)
        Me.pnlWiz1.Controls.Add(Me.P0)
        Me.pnlWiz1.Controls.Add(Me.frmHeader)
        Me.pnlWiz1.Location = New System.Drawing.Point(238, -1)
        Me.pnlWiz1.Name = "pnlWiz1"
        Me.pnlWiz1.Size = New System.Drawing.Size(420, 380)
        Me.pnlWiz1.TabIndex = 11
        '
        'P1
        '
        Me.P1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P1.Controls.Add(Me.lblFireBirdDesc)
        Me.P1.Controls.Add(Me.lblFireBirdHeader)
        Me.P1.Controls.Add(Me.r1)
        Me.P1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.P1.Location = New System.Drawing.Point(9, 120)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(403, 73)
        Me.P1.TabIndex = 13
        '
        'lblFireBirdDesc
        '
        Me.lblFireBirdDesc.AutoSize = True
        Me.lblFireBirdDesc.Location = New System.Drawing.Point(38, 27)
        Me.lblFireBirdDesc.Name = "lblFireBirdDesc"
        Me.lblFireBirdDesc.Size = New System.Drawing.Size(230, 13)
        Me.lblFireBirdDesc.TabIndex = 5
        Me.lblFireBirdDesc.Text = "The Firebird database is suitable for most users."
        '
        'lblFireBirdHeader
        '
        Me.lblFireBirdHeader.AutoSize = True
        Me.lblFireBirdHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFireBirdHeader.Location = New System.Drawing.Point(38, 11)
        Me.lblFireBirdHeader.Name = "lblFireBirdHeader"
        Me.lblFireBirdHeader.Size = New System.Drawing.Size(131, 13)
        Me.lblFireBirdHeader.TabIndex = 4
        Me.lblFireBirdHeader.Text = "Use Firebird database"
        '
        'r1
        '
        Me.r1.AutoSize = True
        Me.r1.Checked = True
        Me.r1.Location = New System.Drawing.Point(18, 11)
        Me.r1.Name = "r1"
        Me.r1.Size = New System.Drawing.Size(14, 13)
        Me.r1.TabIndex = 3
        Me.r1.TabStop = True
        Me.r1.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(308, 343)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(104, 31)
        Me.btnNext.TabIndex = 12
        Me.btnNext.Text = "Continue >>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'chkUpdates
        '
        Me.chkUpdates.AutoSize = True
        Me.chkUpdates.Checked = True
        Me.chkUpdates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpdates.Location = New System.Drawing.Point(28, 350)
        Me.chkUpdates.Name = "chkUpdates"
        Me.chkUpdates.Size = New System.Drawing.Size(199, 17)
        Me.chkUpdates.TabIndex = 11
        Me.chkUpdates.Text = "Turn on software update notification."
        Me.chkUpdates.UseVisualStyleBackColor = True
        '
        'P3
        '
        Me.P3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P3.Controls.Add(Me.lblOwnDesc)
        Me.P3.Controls.Add(Me.lblOwnHeader)
        Me.P3.Controls.Add(Me.r3)
        Me.P3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.P3.Location = New System.Drawing.Point(9, 268)
        Me.P3.Name = "P3"
        Me.P3.Size = New System.Drawing.Size(403, 73)
        Me.P3.TabIndex = 10
        '
        'lblOwnDesc
        '
        Me.lblOwnDesc.AutoSize = True
        Me.lblOwnDesc.Location = New System.Drawing.Point(38, 29)
        Me.lblOwnDesc.Name = "lblOwnDesc"
        Me.lblOwnDesc.Size = New System.Drawing.Size(258, 13)
        Me.lblOwnDesc.TabIndex = 4
        Me.lblOwnDesc.Text = "You will have to enter connection details in next step."
        '
        'lblOwnHeader
        '
        Me.lblOwnHeader.AutoSize = True
        Me.lblOwnHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOwnHeader.Location = New System.Drawing.Point(38, 12)
        Me.lblOwnHeader.Name = "lblOwnHeader"
        Me.lblOwnHeader.Size = New System.Drawing.Size(238, 13)
        Me.lblOwnHeader.TabIndex = 3
        Me.lblOwnHeader.Text = "Use installed MariaDB / MySql Database"
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
        Me.P2.Controls.Add(Me.lblPMariaDesc)
        Me.P2.Controls.Add(Me.lblPMariaHeader)
        Me.P2.Controls.Add(Me.r2)
        Me.P2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.P2.Location = New System.Drawing.Point(9, 194)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(403, 73)
        Me.P2.TabIndex = 9
        '
        'lblPMariaDesc
        '
        Me.lblPMariaDesc.AutoSize = True
        Me.lblPMariaDesc.Location = New System.Drawing.Point(38, 30)
        Me.lblPMariaDesc.Name = "lblPMariaDesc"
        Me.lblPMariaDesc.Size = New System.Drawing.Size(292, 26)
        Me.lblPMariaDesc.TabIndex = 3
        Me.lblPMariaDesc.Text = "MariaDB is used for more experienced users." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Wallet launcher will download, setup" &
    " and control this for you."
        '
        'lblPMariaHeader
        '
        Me.lblPMariaHeader.AutoSize = True
        Me.lblPMariaHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPMariaHeader.Location = New System.Drawing.Point(38, 12)
        Me.lblPMariaHeader.Name = "lblPMariaHeader"
        Me.lblPMariaHeader.Size = New System.Drawing.Size(202, 13)
        Me.lblPMariaHeader.TabIndex = 2
        Me.lblPMariaHeader.Text = "Use a portable version of MariaDB"
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
        'P0
        '
        Me.P0.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.P0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P0.Controls.Add(Me.lblH2Desc)
        Me.P0.Controls.Add(Me.lblH2Header)
        Me.P0.Controls.Add(Me.r0)
        Me.P0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.P0.Location = New System.Drawing.Point(9, 46)
        Me.P0.Name = "P0"
        Me.P0.Size = New System.Drawing.Size(403, 73)
        Me.P0.TabIndex = 8
        '
        'lblH2Desc
        '
        Me.lblH2Desc.AutoSize = True
        Me.lblH2Desc.CausesValidation = False
        Me.lblH2Desc.ForeColor = System.Drawing.Color.Black
        Me.lblH2Desc.Location = New System.Drawing.Point(38, 27)
        Me.lblH2Desc.Name = "lblH2Desc"
        Me.lblH2Desc.Size = New System.Drawing.Size(202, 13)
        Me.lblH2Desc.TabIndex = 5
        Me.lblH2Desc.Text = "Compatible with older and non cg wallets."
        '
        'lblH2Header
        '
        Me.lblH2Header.AutoSize = True
        Me.lblH2Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblH2Header.Location = New System.Drawing.Point(38, 12)
        Me.lblH2Header.Name = "lblH2Header"
        Me.lblH2Header.Size = New System.Drawing.Size(105, 13)
        Me.lblH2Header.TabIndex = 4
        Me.lblH2Header.Text = "Use H2 database"
        '
        'r0
        '
        Me.r0.AutoSize = True
        Me.r0.Location = New System.Drawing.Point(18, 12)
        Me.r0.Name = "r0"
        Me.r0.Size = New System.Drawing.Size(14, 13)
        Me.r0.TabIndex = 3
        Me.r0.TabStop = True
        Me.r0.UseVisualStyleBackColor = True
        '
        'frmHeader
        '
        Me.frmHeader.AutoSize = True
        Me.frmHeader.Font = New System.Drawing.Font("Rockwell", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmHeader.Location = New System.Drawing.Point(6, 11)
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
        Me.PictureBox1.Size = New System.Drawing.Size(239, 381)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.Font = New System.Drawing.Font("Rockwell", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 276)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(185, 19)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Burst Wallet Launcher"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label8.Location = New System.Drawing.Point(19, 298)
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
        'PnlWiz2
        '
        Me.PnlWiz2.Controls.Add(Me.pnlDb)
        Me.PnlWiz2.Controls.Add(Me.lblStatusInfo)
        Me.PnlWiz2.Controls.Add(Me.Pb1)
        Me.PnlWiz2.Controls.Add(Me.lblStatus)
        Me.PnlWiz2.Controls.Add(Me.btnBack)
        Me.PnlWiz2.Controls.Add(Me.btnDownload)
        Me.PnlWiz2.Controls.Add(Me.Label12)
        Me.PnlWiz2.Controls.Add(Me.pnlJava)
        Me.PnlWiz2.Controls.Add(Me.btnDone)
        Me.PnlWiz2.Location = New System.Drawing.Point(664, -1)
        Me.PnlWiz2.Name = "PnlWiz2"
        Me.PnlWiz2.Size = New System.Drawing.Size(420, 380)
        Me.PnlWiz2.TabIndex = 12
        '
        'pnlDb
        '
        Me.pnlDb.BackColor = System.Drawing.Color.LightCoral
        Me.pnlDb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDb.Controls.Add(Me.pnlMariaSettings)
        Me.pnlDb.Controls.Add(Me.lblDbHeader)
        Me.pnlDb.Controls.Add(Me.lblDBstatus)
        Me.pnlDb.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlDb.Location = New System.Drawing.Point(9, 117)
        Me.pnlDb.Name = "pnlDb"
        Me.pnlDb.Size = New System.Drawing.Size(403, 180)
        Me.pnlDb.TabIndex = 15
        '
        'pnlMariaSettings
        '
        Me.pnlMariaSettings.BackColor = System.Drawing.Color.Transparent
        Me.pnlMariaSettings.Controls.Add(Me.Label5)
        Me.pnlMariaSettings.Controls.Add(Me.txtDbPass)
        Me.pnlMariaSettings.Controls.Add(Me.Label17)
        Me.pnlMariaSettings.Controls.Add(Me.txtDbUser)
        Me.pnlMariaSettings.Controls.Add(Me.Label16)
        Me.pnlMariaSettings.Controls.Add(Me.txtDbName)
        Me.pnlMariaSettings.Controls.Add(Me.Label15)
        Me.pnlMariaSettings.Controls.Add(Me.txtDbAddress)
        Me.pnlMariaSettings.Controls.Add(Me.Label13)
        Me.pnlMariaSettings.Location = New System.Drawing.Point(10, 46)
        Me.pnlMariaSettings.Name = "pnlMariaSettings"
        Me.pnlMariaSettings.Size = New System.Drawing.Size(387, 126)
        Me.pnlMariaSettings.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(99, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "note: Database and schema must exist."
        '
        'txtDbPass
        '
        Me.txtDbPass.Location = New System.Drawing.Point(102, 67)
        Me.txtDbPass.Name = "txtDbPass"
        Me.txtDbPass.Size = New System.Drawing.Size(270, 20)
        Me.txtDbPass.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(15, 70)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Password:"
        '
        'txtDbUser
        '
        Me.txtDbUser.Location = New System.Drawing.Point(102, 46)
        Me.txtDbUser.Name = "txtDbUser"
        Me.txtDbUser.Size = New System.Drawing.Size(270, 20)
        Me.txtDbUser.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Database:"
        '
        'txtDbName
        '
        Me.txtDbName.Location = New System.Drawing.Point(102, 25)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.Size = New System.Drawing.Size(270, 20)
        Me.txtDbName.TabIndex = 3
        Me.txtDbName.Text = "burstwallet"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Username:"
        '
        'txtDbAddress
        '
        Me.txtDbAddress.Location = New System.Drawing.Point(102, 4)
        Me.txtDbAddress.Name = "txtDbAddress"
        Me.txtDbAddress.Size = New System.Drawing.Size(270, 20)
        Me.txtDbAddress.TabIndex = 1
        Me.txtDbAddress.Text = "127.0.0.1:3306"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Server address:"
        '
        'lblDbHeader
        '
        Me.lblDbHeader.AutoSize = True
        Me.lblDbHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDbHeader.Location = New System.Drawing.Point(7, 12)
        Me.lblDbHeader.Name = "lblDbHeader"
        Me.lblDbHeader.Size = New System.Drawing.Size(61, 13)
        Me.lblDbHeader.TabIndex = 2
        Me.lblDbHeader.Text = "Database"
        '
        'lblDBstatus
        '
        Me.lblDBstatus.AutoSize = True
        Me.lblDBstatus.Location = New System.Drawing.Point(25, 30)
        Me.lblDBstatus.Name = "lblDBstatus"
        Me.lblDBstatus.Size = New System.Drawing.Size(157, 13)
        Me.lblDBstatus.TabIndex = 4
        Me.lblDBstatus.Text = "MariaDB is not yet downloaded."
        '
        'lblStatusInfo
        '
        Me.lblStatusInfo.AutoSize = True
        Me.lblStatusInfo.Location = New System.Drawing.Point(53, 340)
        Me.lblStatusInfo.Name = "lblStatusInfo"
        Me.lblStatusInfo.Size = New System.Drawing.Size(116, 13)
        Me.lblStatusInfo.TabIndex = 20
        Me.lblStatusInfo.Text = "Extracting Java Portble"
        Me.lblStatusInfo.Visible = False
        '
        'Pb1
        '
        Me.Pb1.Location = New System.Drawing.Point(20, 356)
        Me.Pb1.Name = "Pb1"
        Me.Pb1.Size = New System.Drawing.Size(205, 15)
        Me.Pb1.TabIndex = 19
        Me.Pb1.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(17, 340)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "Status:"
        Me.lblStatus.Visible = False
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(244, 340)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(81, 31)
        Me.btnBack.TabIndex = 17
        Me.btnBack.Text = "<< Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(244, 303)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(168, 31)
        Me.btnDownload.TabIndex = 16
        Me.btnDownload.Text = "Download missing components"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Rockwell", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(276, 27)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Checking environment."
        '
        'pnlJava
        '
        Me.pnlJava.BackColor = System.Drawing.Color.PaleGreen
        Me.pnlJava.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlJava.Controls.Add(Me.lblJavaStatus)
        Me.pnlJava.Controls.Add(Me.lblJavaHeader)
        Me.pnlJava.Cursor = System.Windows.Forms.Cursors.Default
        Me.pnlJava.Location = New System.Drawing.Point(9, 46)
        Me.pnlJava.Name = "pnlJava"
        Me.pnlJava.Size = New System.Drawing.Size(403, 65)
        Me.pnlJava.TabIndex = 13
        '
        'lblJavaStatus
        '
        Me.lblJavaStatus.AutoSize = True
        Me.lblJavaStatus.Location = New System.Drawing.Point(25, 27)
        Me.lblJavaStatus.Name = "lblJavaStatus"
        Me.lblJavaStatus.Size = New System.Drawing.Size(199, 13)
        Me.lblJavaStatus.TabIndex = 3
        Me.lblJavaStatus.Text = "Java was found installed on your system."
        '
        'lblJavaHeader
        '
        Me.lblJavaHeader.AutoSize = True
        Me.lblJavaHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJavaHeader.Location = New System.Drawing.Point(7, 12)
        Me.lblJavaHeader.Name = "lblJavaHeader"
        Me.lblJavaHeader.Size = New System.Drawing.Size(34, 13)
        Me.lblJavaHeader.TabIndex = 2
        Me.lblJavaHeader.Text = "Java"
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(331, 340)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(81, 31)
        Me.btnDone.TabIndex = 12
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(40, 58)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(143, 202)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'frmFirstTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1083, 403)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PnlWiz2)
        Me.Controls.Add(Me.pnlWiz1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmFirstTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "First Time"
        Me.pnlWiz1.ResumeLayout(False)
        Me.pnlWiz1.PerformLayout()
        Me.P1.ResumeLayout(False)
        Me.P1.PerformLayout()
        Me.P3.ResumeLayout(False)
        Me.P3.PerformLayout()
        Me.P2.ResumeLayout(False)
        Me.P2.PerformLayout()
        Me.P0.ResumeLayout(False)
        Me.P0.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlWiz2.ResumeLayout(False)
        Me.PnlWiz2.PerformLayout()
        Me.pnlDb.ResumeLayout(False)
        Me.pnlDb.PerformLayout()
        Me.pnlMariaSettings.ResumeLayout(False)
        Me.pnlMariaSettings.PerformLayout()
        Me.pnlJava.ResumeLayout(False)
        Me.pnlJava.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnNext As Button
    Friend WithEvents chkUpdates As CheckBox
    Friend WithEvents P3 As Panel
    Friend WithEvents lblOwnDesc As Label
    Friend WithEvents lblOwnHeader As Label
    Friend WithEvents r3 As RadioButton
    Friend WithEvents P2 As Panel
    Friend WithEvents lblPMariaDesc As Label
    Friend WithEvents lblPMariaHeader As Label
    Friend WithEvents r2 As RadioButton
    Friend WithEvents P0 As Panel
    Friend WithEvents frmHeader As Label
    Friend WithEvents PnlWiz2 As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents btnDownload As Button
    Friend WithEvents pnlDb As Panel
    Friend WithEvents lblDbHeader As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents pnlJava As Panel
    Friend WithEvents lblJavaStatus As Label
    Friend WithEvents lblJavaHeader As Label
    Friend WithEvents btnDone As Button
    Friend WithEvents lblDBstatus As Label
    Friend WithEvents pnlWiz1 As Panel
    Friend WithEvents lblStatusInfo As Label
    Friend WithEvents Pb1 As ProgressBar
    Friend WithEvents lblStatus As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblH2Header As Label
    Friend WithEvents r0 As RadioButton
    Friend WithEvents P1 As Panel
    Friend WithEvents lblFireBirdDesc As Label
    Friend WithEvents lblFireBirdHeader As Label
    Friend WithEvents r1 As RadioButton
    Friend WithEvents lblH2Desc As Label
    Friend WithEvents pnlMariaSettings As Panel
    Friend WithEvents txtDbPass As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtDbUser As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDbName As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtDbAddress As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label5 As Label
End Class
