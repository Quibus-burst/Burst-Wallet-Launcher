Public Class frmConsole


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConsoleSelect.SelectedIndexChanged
        ' 0 = Maria console
        ' 1 = NRS Console

        Try
            txtConsole.Text = frmMain.Console(cmbConsoleSelect.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtConsole.Text = frmMain.Console(0)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub RefreshConsole()

        Try
            txtConsole.Text = frmMain.Console(cmbConsoleSelect.SelectedIndex)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtConsole_TextChanged(sender As Object, e As EventArgs) Handles txtConsole.TextChanged

    End Sub
End Class