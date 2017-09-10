Public Class frmSettings
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.CheckForUpdates = chkCheckForUpdates.Checked
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkCheckForUpdates.Checked = My.Settings.CheckForUpdates
    End Sub
End Class