Public Class frmSettings
    Private DbType As Integer
    Private JavaType As Integer

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkCheckForUpdates.Checked = My.Settings.CheckForUpdates
        chkAutoIP.Checked = My.Settings.CheckForUpdates
        ' Dim bStr() As String = Split(My.Settings.Repo, ";")
        '  For Each Repo As String In bStr
        '  If Repo.Length <> 0 Then
        '  txtRepo.AppendText(Repo & vbCrLf)
        '  End If
        '   Next
        pnlDbSettings.Enabled = False
        ChangeDbType(My.Settings.DbType)
        txtDbServer.Text = My.Settings.DbServer
        txtDbName.Text = My.Settings.DbName
        txtDbUser.Text = My.Settings.DbUser
        txtDbPass.Text = My.Settings.DbPass
        ChangeJavaType(My.Settings.JavaType)
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
    Private Sub rDB3_CheckedChanged(sender As Object, e As EventArgs) Handles rDB3.Click
        ChangeDbType(3)
    End Sub
    Private Sub rDB0_CheckedChanged(sender As Object, e As EventArgs) Handles rDB0.Click
        ChangeDbType(0)

    End Sub
    Private Sub rDB1_CheckedChanged(sender As Object, e As EventArgs) Handles rDB1.Click
        ChangeDbType(1)

    End Sub
    Private Sub rDB2_CheckedChanged(sender As Object, e As EventArgs) Handles rDB2.Click
        ChangeDbType(2)
    End Sub
    Private Sub ChangeDbType(ByVal id As Integer)
        rDB0.Checked = False
        rDB1.Checked = False
        rDB2.Checked = False
        rDB3.Checked = False
        pnlDbSettings.Enabled = False
        Select Case id
            Case 0
                rDB0.Checked = True
            Case 1
                rDB1.Checked = True
            Case 2
                rDB2.Checked = True
                pnlDbSettings.Enabled = True
            Case 3
                rDB3.Checked = True
        End Select
        DbType = id
    End Sub
    Private Sub ChangeJavaType(ByVal id As Integer)
        rJava0.Checked = False
        rJava1.Checked = False
        Select Case id
            Case 0
                rJava0.Checked = True
            Case 1
                rJava1.Checked = True
        End Select
        JavaType = id
    End Sub
    Private Sub rJava0_CheckedChanged(sender As Object, e As EventArgs) Handles rJava0.Click
        ChangeJavaType(0)
    End Sub
    Private Sub rJava1_CheckedChanged(sender As Object, e As EventArgs) Handles rJava1.Click
        ChangeJavaType(1)
    End Sub


    Public Sub SaveSettings()

        My.Settings.CheckForUpdates = chkCheckForUpdates.Checked
        My.Settings.AutoIP = chkAutoIP.Checked
        My.Settings.Repo = ""
        ' Dim Lines() As String = Split(txtRepo.Text, vbCrLf)
        Dim Result As String = ""
        '   For Each Repo As String In Lines
        '  If Trim(Repo).Length <> 0 Then Result &= Repo & ";"
        '   Next
        My.Settings.Repo = Result
        My.Settings.DbType = DbType
        My.Settings.DbServer = txtDbServer.Text
        My.Settings.DbName = txtDbName.Text
        My.Settings.DbUser = txtDbUser.Text
        My.Settings.DbPass = txtDbPass.Text
        My.Settings.JavaType = JavaType
        My.Settings.Save()

        'should we offer automatic database export / import feature

        'now write nxt.properties
        Dim data As String = ""
        Select Case DbType
            Case 0
                Data = "#Using Firebird" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:firebirdsql:embedded:./burst_db/database.fdb" & vbCrLf
                Data &= "nxt.dbUsername=" & vbCrLf
                Data &= "nxt.dbPassword="
            Case 1
                Data = "#Using MariaDb Portable" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:mariadb://localhost:3306/burstwallet" & vbCrLf
                Data &= "nxt.dbUsername=burstwallet" & vbCrLf
                Data &= "nxt.dbPassword=burstwallet"
            Case 2
                Data = "#Using installed MariaDb" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:mariadb://" & My.Settings.DbServer & "/" & My.Settings.DbName & vbCrLf
                Data &= "nxt.dbUsername=" & My.Settings.DbUser & vbCrLf
                Data &= "nxt.dbPassword=" & My.Settings.DbPass
            Case 3
                data = "#Using H2" & vbCrLf
                data &= "nxt.dbUrl=jdbc:h2:./burst_db/burst;DB_CLOSE_ON_EXIT=False" & vbCrLf
                data &= "nxt.dbUsername=" & vbCrLf
                Data &= "nxt.dbPassword="
        End Select

        Try
            Dim basedir As String = Application.StartupPath
            If Not basedir.EndsWith("\") Then basedir &= "\"
            IO.File.WriteAllText(basedir & "conf\nxt.properties", data)
        Catch ex As Exception

        End Try


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
End Class