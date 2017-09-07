<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.LblMariaStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnStartStop = New System.Windows.Forms.Button()
        Me.btnConsole = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblGotoWallet)
        Me.GroupBox1.Controls.Add(Me.lblNrsStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LblMariaStatus)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(303, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Wallet status"
        '
        'lblGotoWallet
        '
        Me.lblGotoWallet.AutoSize = True
        Me.lblGotoWallet.Location = New System.Drawing.Point(35, 67)
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
        Me.lblNrsStatus.Location = New System.Drawing.Point(79, 47)
        Me.lblNrsStatus.Name = "lblNrsStatus"
        Me.lblNrsStatus.Size = New System.Drawing.Size(47, 13)
        Me.lblNrsStatus.TabIndex = 3
        Me.lblNrsStatus.Text = "Stoped"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "NRS:"
        '
        'LblMariaStatus
        '
        Me.LblMariaStatus.AutoSize = True
        Me.LblMariaStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMariaStatus.ForeColor = System.Drawing.Color.Red
        Me.LblMariaStatus.Location = New System.Drawing.Point(79, 30)
        Me.LblMariaStatus.Name = "LblMariaStatus"
        Me.LblMariaStatus.Size = New System.Drawing.Size(47, 13)
        Me.LblMariaStatus.TabIndex = 1
        Me.LblMariaStatus.Text = "Stoped"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Maria db:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Rockwell", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(254, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Burstcoin CG wallet bundle"
        '
        'btnStartStop
        '
        Me.btnStartStop.Location = New System.Drawing.Point(25, 58)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.Size = New System.Drawing.Size(123, 30)
        Me.btnStartStop.TabIndex = 2
        Me.btnStartStop.Text = "Start Wallet"
        Me.btnStartStop.UseVisualStyleBackColor = True
        '
        'btnConsole
        '
        Me.btnConsole.Location = New System.Drawing.Point(149, 58)
        Me.btnConsole.Name = "btnConsole"
        Me.btnConsole.Size = New System.Drawing.Size(123, 30)
        Me.btnConsole.TabIndex = 3
        Me.btnConsole.Text = "View console log"
        Me.btnConsole.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(489, 115)
        Me.Controls.Add(Me.btnConsole)
        Me.Controls.Add(Me.btnStartStop)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Burstcoin CG wallet launcher v1.0"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblNrsStatus As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblMariaStatus As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnStartStop As Button
    Friend WithEvents btnConsole As Button
    Friend WithEvents lblGotoWallet As LinkLabel
End Class
