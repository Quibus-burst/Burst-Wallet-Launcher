﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblGotoWallet = New System.Windows.Forms.LinkLabel()
        Me.lblNrsStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDbStatus = New System.Windows.Forms.Label()
        Me.lblDbName = New System.Windows.Forms.Label()
        Me.btnStartStop = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportDatabaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigureWindowsFirewallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewConsolesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContributorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeveloperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WalletLauncherSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblBlockInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblWallet = New System.Windows.Forms.Label()
        Me.lblUpdates = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblGotoWallet)
        Me.GroupBox1.Controls.Add(Me.lblNrsStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LblDbStatus)
        Me.GroupBox1.Controls.Add(Me.lblDbName)
        Me.GroupBox1.Location = New System.Drawing.Point(252, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 90)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Wallet status"
        '
        'lblGotoWallet
        '
        Me.lblGotoWallet.AutoSize = True
        Me.lblGotoWallet.Location = New System.Drawing.Point(35, 61)
        Me.lblGotoWallet.Name = "lblGotoWallet"
        Me.lblGotoWallet.Size = New System.Drawing.Size(91, 13)
        Me.lblGotoWallet.TabIndex = 4
        Me.lblGotoWallet.TabStop = True
        Me.lblGotoWallet.Text = "Click here to login"
        Me.lblGotoWallet.Visible = False
        '
        'lblNrsStatus
        '
        Me.lblNrsStatus.AutoSize = True
        Me.lblNrsStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNrsStatus.ForeColor = System.Drawing.Color.Red
        Me.lblNrsStatus.Location = New System.Drawing.Point(79, 41)
        Me.lblNrsStatus.Name = "lblNrsStatus"
        Me.lblNrsStatus.Size = New System.Drawing.Size(54, 13)
        Me.lblNrsStatus.TabIndex = 3
        Me.lblNrsStatus.Text = "Stopped"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "NRS:"
        '
        'LblDbStatus
        '
        Me.LblDbStatus.AutoSize = True
        Me.LblDbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDbStatus.ForeColor = System.Drawing.Color.Green
        Me.LblDbStatus.Location = New System.Drawing.Point(79, 24)
        Me.LblDbStatus.Name = "LblDbStatus"
        Me.LblDbStatus.Size = New System.Drawing.Size(59, 13)
        Me.LblDbStatus.TabIndex = 1
        Me.LblDbStatus.Text = "Embeded"
        '
        'lblDbName
        '
        Me.lblDbName.AutoSize = True
        Me.lblDbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDbName.Location = New System.Drawing.Point(17, 24)
        Me.lblDbName.Name = "lblDbName"
        Me.lblDbName.Size = New System.Drawing.Size(44, 13)
        Me.lblDbName.TabIndex = 0
        Me.lblDbName.Text = "Firebird:"
        '
        'btnStartStop
        '
        Me.btnStartStop.Location = New System.Drawing.Point(29, 87)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.Size = New System.Drawing.Size(202, 30)
        Me.btnStartStop.TabIndex = 2
        Me.btnStartStop.Text = "Start Wallet"
        Me.btnStartStop.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ToolsToolStripMenuItem1, Me.AboutToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(448, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForUpdatesToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check for updates"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(167, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(170, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportDatabaseToolStripMenuItem, Me.ImportDatabaseToolStripMenuItem1, Me.ToolStripMenuItem3, Me.ChangeDatabaseToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.ToolsToolStripMenuItem.Text = "Database"
        '
        'ExportDatabaseToolStripMenuItem
        '
        Me.ExportDatabaseToolStripMenuItem.Name = "ExportDatabaseToolStripMenuItem"
        Me.ExportDatabaseToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ExportDatabaseToolStripMenuItem.Text = "Export Database"
        '
        'ImportDatabaseToolStripMenuItem1
        '
        Me.ImportDatabaseToolStripMenuItem1.Name = "ImportDatabaseToolStripMenuItem1"
        Me.ImportDatabaseToolStripMenuItem1.Size = New System.Drawing.Size(166, 22)
        Me.ImportDatabaseToolStripMenuItem1.Text = "Import Database"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(163, 6)
        '
        'ChangeDatabaseToolStripMenuItem
        '
        Me.ChangeDatabaseToolStripMenuItem.Name = "ChangeDatabaseToolStripMenuItem"
        Me.ChangeDatabaseToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ChangeDatabaseToolStripMenuItem.Text = "Change Database"
        '
        'ToolsToolStripMenuItem1
        '
        Me.ToolsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigureWindowsFirewallToolStripMenuItem, Me.ViewConsolesToolStripMenuItem})
        Me.ToolsToolStripMenuItem1.Name = "ToolsToolStripMenuItem1"
        Me.ToolsToolStripMenuItem1.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem1.Text = "Tools"
        '
        'ConfigureWindowsFirewallToolStripMenuItem
        '
        Me.ConfigureWindowsFirewallToolStripMenuItem.Name = "ConfigureWindowsFirewallToolStripMenuItem"
        Me.ConfigureWindowsFirewallToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ConfigureWindowsFirewallToolStripMenuItem.Text = "Configure Windows Firewall"
        '
        'ViewConsolesToolStripMenuItem
        '
        Me.ViewConsolesToolStripMenuItem.Name = "ViewConsolesToolStripMenuItem"
        Me.ViewConsolesToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.ViewConsolesToolStripMenuItem.Text = "View Consoles"
        '
        'AboutToolStripMenuItem2
        '
        Me.AboutToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContributorsToolStripMenuItem, Me.DeveloperToolStripMenuItem})
        Me.AboutToolStripMenuItem2.Name = "AboutToolStripMenuItem2"
        Me.AboutToolStripMenuItem2.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem2.Text = "About"
        '
        'ContributorsToolStripMenuItem
        '
        Me.ContributorsToolStripMenuItem.Name = "ContributorsToolStripMenuItem"
        Me.ContributorsToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ContributorsToolStripMenuItem.Text = "Contributors"
        '
        'DeveloperToolStripMenuItem
        '
        Me.DeveloperToolStripMenuItem.Name = "DeveloperToolStripMenuItem"
        Me.DeveloperToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DeveloperToolStripMenuItem.Text = "Developer"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForUpdateToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CheckForUpdateToolStripMenuItem
        '
        Me.CheckForUpdateToolStripMenuItem.Name = "CheckForUpdateToolStripMenuItem"
        Me.CheckForUpdateToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.CheckForUpdateToolStripMenuItem.Text = "Check for update"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(162, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem1
        '
        Me.SettingsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WalletLauncherSettingsToolStripMenuItem})
        Me.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1"
        Me.SettingsToolStripMenuItem1.Size = New System.Drawing.Size(39, 20)
        Me.SettingsToolStripMenuItem1.Text = "Edit"
        '
        'WalletLauncherSettingsToolStripMenuItem
        '
        Me.WalletLauncherSettingsToolStripMenuItem.Name = "WalletLauncherSettingsToolStripMenuItem"
        Me.WalletLauncherSettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.WalletLauncherSettingsToolStripMenuItem.Text = "Settings"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem1.Text = "Contributors"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblBlockInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 120)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(448, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(112, 17)
        Me.ToolStripStatusLabel1.Text = "Wallet block height:"
        '
        'lblBlockInfo
        '
        Me.lblBlockInfo.Name = "lblBlockInfo"
        Me.lblBlockInfo.Size = New System.Drawing.Size(12, 17)
        Me.lblBlockInfo.Text = "-"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'lblWallet
        '
        Me.lblWallet.AutoSize = True
        Me.lblWallet.Font = New System.Drawing.Font("Rockwell", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWallet.Location = New System.Drawing.Point(25, 30)
        Me.lblWallet.Name = "lblWallet"
        Me.lblWallet.Size = New System.Drawing.Size(206, 23)
        Me.lblWallet.TabIndex = 7
        Me.lblWallet.Text = "Burst wallet v1.3.6cg"
        '
        'lblUpdates
        '
        Me.lblUpdates.AutoSize = True
        Me.lblUpdates.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblUpdates.ForeColor = System.Drawing.Color.Red
        Me.lblUpdates.Location = New System.Drawing.Point(26, 60)
        Me.lblUpdates.Name = "lblUpdates"
        Me.lblUpdates.Size = New System.Drawing.Size(206, 13)
        Me.lblUpdates.TabIndex = 8
        Me.lblUpdates.Text = "Updates available. Click here for more info"
        Me.lblUpdates.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(448, 142)
        Me.Controls.Add(Me.lblUpdates)
        Me.Controls.Add(Me.lblWallet)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnStartStop)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Burstcoin wallet launcher v1.2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblNrsStatus As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblDbStatus As Label
    Friend WithEvents lblDbName As Label
    Friend WithEvents btnStartStop As Button
    Friend WithEvents lblGotoWallet As LinkLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents CheckForUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents WalletLauncherSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents lblWallet As Label
    Friend WithEvents FileToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ContributorsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportDatabaseToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ChangeDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents ToolsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ConfigureWindowsFirewallToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeveloperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblUpdates As Label
    Friend WithEvents ViewConsolesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblBlockInfo As ToolStripStatusLabel
End Class
