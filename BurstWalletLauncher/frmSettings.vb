Public Class frmSettings

    Private JavaType As Integer

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not App.isInstalled(AppNames.JavaInstalled) Then rJava0.Enabled = False
        If Not App.isInstalled(AppNames.JavaPortable) Then rJava1.Enabled = False
        If My.Settings.DbType = DbType.MariaDB Then pnlMaria.Enabled = True
        lblDb.Text = App.GetDbNameFromType(My.Settings.DbType)
        chkCheckForUpdates.Checked = My.Settings.CheckForUpdates
        chkAutoIP.Checked = My.Settings.CheckForUpdates
        pnlDbSettings.Enabled = False
        txtDbServer.Text = My.Settings.DbServer
        txtDbName.Text = My.Settings.DbName
        txtDbUser.Text = My.Settings.DbUser
        txtDbPass.Text = My.Settings.DbPass
        ChangeJavaType(My.Settings.JavaType)
        If App.CheckOpenCL() Then
            chkOpenCL.Checked = My.Settings.useOpenCL
        Else
            chkOpenCL.Enabled = False
            chkOpenCL.Checked = False
        End If


        nrCores.Maximum = Environment.ProcessorCount
        nrCores.Value = My.Settings.Cpulimit
        lblMaxCores.Text = CStr(Environment.ProcessorCount) & " cores."
        Select Case Environment.ProcessorCount
            Case 1
                lblRecommendedCPU.Text = CStr(1) & " cores."
            Case 2
                lblRecommendedCPU.Text = CStr(1) & " cores."
            Case 4
                lblRecommendedCPU.Text = CStr(3) & " cores."
            Case Else
                lblRecommendedCPU.Text = CStr(Environment.ProcessorCount - 2) & " cores."
        End Select

    End Sub

    Private Sub ChangeJavaType(ByVal id As Integer)
        rJava0.Checked = False
        rJava1.Checked = False
        Select Case id
            Case AppNames.JavaInstalled
                rJava0.Checked = True
            Case AppNames.JavaPortable
                rJava1.Checked = True
            Case Else
                rJava1.Checked = True
                id = AppNames.JavaPortable
        End Select
        JavaType = id
    End Sub

    Private Sub rJava0_Click(sender As Object, e As EventArgs) Handles rJava0.Click
        ChangeJavaType(AppNames.JavaInstalled)
    End Sub
    Private Sub rJava1_Click(sender As Object, e As EventArgs) Handles rJava1.Click
        ChangeJavaType(AppNames.JavaPortable)
    End Sub


    Public Sub SaveSettings()

        My.Settings.CheckForUpdates = chkCheckForUpdates.Checked
        My.Settings.AutoIP = chkAutoIP.Checked

        My.Settings.DbServer = txtDbServer.Text
        My.Settings.DbName = txtDbName.Text
        My.Settings.DbUser = txtDbUser.Text
        My.Settings.DbPass = txtDbPass.Text
        My.Settings.JavaType = JavaType
        My.Settings.useOpenCL = chkOpenCL.Checked
        My.Settings.Save()

        Me.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveSettings()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveSettings()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SaveSettings()
    End Sub

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics = e.Graphics
        Dim _TB As Brush
        Dim _TP As TabPage = TabControl1.TabPages(e.Index)
        Dim _TA As Rectangle = TabControl1.GetTabRect(e.Index)
        If (e.State = DrawItemState.Selected) Then
            _TB = New SolidBrush(Color.Black)
            g.FillRectangle(Brushes.SkyBlue, e.Bounds)
        Else
            _TB = New SolidBrush(e.ForeColor)
            e.DrawBackground()
        End If
        Dim _TF As New Font("Arial", 12.0, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim _strFlags As New StringFormat()
        _strFlags.Alignment = StringAlignment.Center
        _strFlags.LineAlignment = StringAlignment.Center
        g.DrawString(_TP.Text, _TF, _TB, _TA, New StringFormat(_strFlags))
    End Sub

    Private Sub nrCores_ValueChanged(sender As Object, e As EventArgs) Handles nrCores.TextChanged
        If nrCores.Value > Environment.ProcessorCount Then nrCores.Value = Environment.ProcessorCount
        If nrCores.Value < 1 Then nrCores.Value = 1

    End Sub
End Class