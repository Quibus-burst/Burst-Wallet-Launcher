<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsole
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
        Me.cmbConsoleSelect = New System.Windows.Forms.ComboBox()
        Me.txtConsole = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmbConsoleSelect
        '
        Me.cmbConsoleSelect.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbConsoleSelect.FormattingEnabled = True
        Me.cmbConsoleSelect.Items.AddRange(New Object() {"Maria DB Console", "NRS Console"})
        Me.cmbConsoleSelect.Location = New System.Drawing.Point(0, 0)
        Me.cmbConsoleSelect.Name = "cmbConsoleSelect"
        Me.cmbConsoleSelect.Size = New System.Drawing.Size(717, 21)
        Me.cmbConsoleSelect.TabIndex = 0
        Me.cmbConsoleSelect.Text = "Maria DB Console"
        '
        'txtConsole
        '
        Me.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConsole.Location = New System.Drawing.Point(0, 21)
        Me.txtConsole.Multiline = True
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.ReadOnly = True
        Me.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtConsole.Size = New System.Drawing.Size(717, 374)
        Me.txtConsole.TabIndex = 1
        Me.txtConsole.WordWrap = False
        '
        'frmConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(717, 395)
        Me.Controls.Add(Me.txtConsole)
        Me.Controls.Add(Me.cmbConsoleSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsole"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Console view"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbConsoleSelect As ComboBox
    Friend WithEvents txtConsole As TextBox
End Class
