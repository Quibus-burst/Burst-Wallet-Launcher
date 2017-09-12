Public Class frmFirstTime

    Private WithEvents Scheck As clsSystemCheck
    Private Sub ChangeButton(ByVal btn As Integer)

        Select Case btn
            Case 1
                r1.Checked = True
                P1.BackColor = SystemColors.GradientInactiveCaption
                r2.Checked = False
                P2.BackColor = Color.White
                r3.Checked = False
                P3.BackColor = Color.White

                pnlMariaSettings.Visible = False

            Case 2
                r1.Checked = False
                P1.BackColor = Color.White
                r2.Checked = True
                P2.BackColor = SystemColors.GradientInactiveCaption
                r3.Checked = False
                P3.BackColor = Color.White

                pnlMariaSettings.Visible = False
            Case 3
                r1.Checked = False
                P1.BackColor = Color.White
                r2.Checked = False
                P2.BackColor = Color.White
                r3.Checked = True
                P3.BackColor = SystemColors.GradientInactiveCaption

                pnlMariaSettings.Visible = True


        End Select




    End Sub
    Private Sub P1_Click(sender As Object, e As EventArgs) Handles P1.Click
        ChangeButton(1)
    End Sub
    Private Sub P2_Click(sender As Object, e As EventArgs) Handles P2.Click
        ChangeButton(2)
    End Sub

    Private Sub P3_Click(sender As Object, e As EventArgs) Handles P3.Click
        ChangeButton(3)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ChangeButton(1)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ChangeButton(1)
    End Sub

    Private Sub r1_Click(sender As Object, e As EventArgs) Handles r1.Click
        ChangeButton(1)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        ChangeButton(2)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        ChangeButton(2)
    End Sub

    Private Sub r2_click(sender As Object, e As EventArgs) Handles r2.Click
        ChangeButton(2)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        ChangeButton(3)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        ChangeButton(3)
    End Sub

    Private Sub r3_Click(sender As Object, e As EventArgs) Handles r3.Click
        ChangeButton(3)
    End Sub

    Private Sub frmFirstTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'when launched find java and maria if possible
        Try
            Scheck = New clsSystemCheck

            'work in progress



        Catch ex As Exception

        End Try
    End Sub
End Class