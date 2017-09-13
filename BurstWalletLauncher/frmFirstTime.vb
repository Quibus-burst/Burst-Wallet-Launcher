Public Class frmFirstTime
    Private Delegate Sub DProgress(ByVal [Pid] As Integer, ByVal [Msg] As String, ByVal [percent] As Integer)
    Private Delegate Sub DDldone()

    Private WithEvents Scheck As clsSystemCheck
    Private WithEvents Dl As clsUpdater
    Private SelectedDBType As Integer = 0
    Private JavaOk As Boolean = False
    Private DbOk As Boolean = False
#Region " DB Selection "

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
                pnlMaria.Visible = False
                SelectedDBType = 0
            Case 2
                r1.Checked = False
                P1.BackColor = Color.White
                r2.Checked = True
                P2.BackColor = SystemColors.GradientInactiveCaption
                r3.Checked = False
                P3.BackColor = Color.White
                pnlMariaSettings.Visible = False
                pnlMaria.Visible = True
                If Scheck.Service(1).Status = True Then
                    pnlMariaSettings.BackColor = Color.PaleGreen
                    lblMariaStatus.Text = Scheck.Service(1).Note
                Else
                    pnlMariaSettings.BackColor = Color.LightCoral
                    lblMariaStatus.Text = Scheck.Service(1).Note
                End If
                SelectedDBType = 1
            Case 3
                r1.Checked = False
                P1.BackColor = Color.White
                r2.Checked = False
                P2.BackColor = Color.White
                r3.Checked = True
                P3.BackColor = SystemColors.GradientInactiveCaption
                pnlMariaSettings.Visible = True
                pnlMaria.Visible = True
                pnlMariaSettings.BackColor = Color.LightCoral
                SelectedDBType = 2
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

#End Region

    Private Sub frmFirstTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 674
        Me.Height = 405
        Try
            Scheck = New clsSystemCheck
            Scheck.CheckInstall()
            If Scheck.Service(0).Status = True Then
                pnlJava.BackColor = Color.PaleGreen
                lblJavaStatus.Text = Scheck.Service(0).Note
            Else
                pnlJava.BackColor = Color.LightCoral
                lblJavaStatus.Text = Scheck.Service(0).Note
            End If

            If Scheck.Service(1).Status = True Then
                pnlMaria.BackColor = Color.PaleGreen
                lblMariaStatus.Text = Scheck.Service(1).Note
            Else
                pnlMaria.BackColor = Color.LightCoral
                lblMariaStatus.Text = Scheck.Service(1).Note
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        Dim Ok As Boolean = True
        Select Case SelectedDBType
            Case 0
                If Scheck.Service(0).Status = True Then
                    btnDone.Enabled = True
                    btnDownload.Enabled = False
                Else
                    btnDone.Enabled = False
                    btnDownload.Enabled = True
                End If
            Case 1
                Ok = True
                If Scheck.Service(0).Status = False Then
                    Ok = False
                End If
                If Scheck.Service(1).Status = False Then
                    Ok = False
                End If
                If Ok Then
                    btnDone.Enabled = True
                    btnDownload.Enabled = False
                Else
                    btnDone.Enabled = False
                    btnDownload.Enabled = True
                End If
            Case 2
                If Scheck.Service(0).Status = False Then
                    Ok = False
                End If
                If Ok Then
                    btnDownload.Enabled = False
                Else
                    btnDownload.Enabled = True
                End If
                btnDone.Enabled = False
        End Select
        pnlWiz1.Visible = False
        PnlWiz2.Top = pnlWiz1.Top
        PnlWiz2.Left = pnlWiz1.Left
        PnlWiz2.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        PnlWiz2.Visible = False
        pnlWiz1.Visible = True
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click

        lblStatusInfo.Text = ""
        Pb1.Minimum = 0
        Pb1.Maximum = 100
        Pb1.Value = 0

        lblStatus.Visible = True
        lblStatusInfo.Visible = True
        Pb1.Visible = True
        btnDownload.Enabled = False
        btnBack.Enabled = False
        Dl = New clsUpdater
        Dl.GetNewVersions()
        DlDone() 'we can init from done sub that loops over all needed

    End Sub

    Public Sub DlDone() Handles Dl.ComponentDone
        If Me.InvokeRequired Then
            Dim d As New DDldone(AddressOf DlDone)
            Me.Invoke(d, New Object() {})
            Return
        End If
        'if java is missing in syscheck then dl java with id 2
        Scheck.CheckInstall()
        Pb1.Value = 0
        If Scheck.Service(0).Status = False Then
            Dl.cId = 2 'java is line 3 in versions
            Dl.UpdateComponent() 'startdownlodad and wait untill we comeback
            Exit Sub
        Else
            pnlJava.BackColor = Color.PaleGreen
            lblJavaStatus.Text = "A portable version of Java is found"
            JavaOk = True
        End If
        If SelectedDBType = 1 Then
            If Scheck.Service(1).Status = False Then
                Dl.cId = 3 'MariaDB is line 3 in versions
                Dl.UpdateComponent() 'startdownlodad and wait untill we comeback
                Exit Sub
            Else
                pnlMaria.BackColor = Color.PaleGreen
                lblMariaStatus.Text = "A portable version of MariaDB is found"
                DbOk = True
            End If
        End If
        If SelectedDBType = 2 Then
            If DbOk = True Then
                btnDone.Visible = True
            End If
        End If

        Pb1.Visible = False
        lblStatusInfo.Text = "All components are downloaded."
        btnBack.Enabled = True


    End Sub
    Public Sub Progress(ByVal i As Integer, ByVal msg As String, percent As Integer) Handles Dl.Progress
        If Me.InvokeRequired Then
            Dim d As New DProgress(AddressOf Progress)
            Me.Invoke(d, New Object() {i, msg, percent})
            Return
        End If
        lblStatusInfo.Text = msg
        Pb1.Value = percent

    End Sub

End Class