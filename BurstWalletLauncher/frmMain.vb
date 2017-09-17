Public Class frmMain
    Private Delegate Sub DUpdate(ByVal [Pid] As Integer, ByVal [Status] As Integer, ByVal [data] As String)
    Private Delegate Sub DNewUpdatesAvilable(ByVal [data] As String)
    Private Delegate Sub DStarting()
    Private Delegate Sub DStoped()
    Private WithEvents UpdateNotifer As clsUpdateNotifier
    Public Console(1) As String
    Public WithEvents Pworker As ProcessWorker
    Public Running As Boolean
    Public Updateinfo As String
    Public BaseDir As String
    Public Repositories() As String
    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click

        If Running Then
            lblGotoWallet.Visible = False
            btnStartStop.Text = "Stoping"
            btnStartStop.Enabled = False
            Pworker.Quit()
        Else

            '           Dim systemcheck As New clsSystemCheck
            '           systemcheck.CheckSystem()
            '            If Not systemcheck.AllServicesOk Then
            '            For t As Integer = 2 To UBound(systemcheck.Service)
            '            If systemcheck.Service(t).Status = False Then Msg &= systemcheck.Service(t).Note & vbCrLf
            '            Next
            '            MsgBox(Msg, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Cannot start.")
            '            Exit Sub
            '        End If

            Dim Mylocation = Application.StartupPath
            If Not Mylocation.EndsWith("\") Then Mylocation &= "\"
            Pworker = New ProcessWorker
            Pworker.MyLocation = Mylocation
            If My.Settings.DbType = 1 Then
                Pworker.UseMaria = True
            Else
                Pworker.UseMaria = False
            End If
            If My.Settings.JavaType = 1 Then
                Pworker.UseJavaP = True
            Else
                Pworker.UseJavaP = False
            End If

            Running = True

            btnStartStop.Enabled = False
            Pworker.Start()
            btnStartStop.Text = "Starting"
        End If

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDir = Application.StartupPath
        If Not BaseDir.EndsWith("\") Then BaseDir &= "\"

        '################################
        'Start classes
        '################################
        App = New clsApp
        App.FindAllLocal()

        If My.Settings.FirstRun Then
            frmFirstTime.ShowDialog()
        End If
        If My.Settings.FirstRun Then
            End
        End If

        CheckUpgrade()

        UpdateNotifer = New clsUpdateNotifier
        If My.Settings.CheckForUpdates Then
            UpdateNotifer.Start()
        End If

        SetDbInfo()


    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Running Then
                MsgBox("You must stop the wallet before you can close the launcher", MsgBoxStyle.OkOnly, "Exit")
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Starting() Handles Pworker.Starting
        If Me.InvokeRequired Then
            Dim d As New DStarting(AddressOf Starting)
            Me.Invoke(d, New Object() {})
            Return
        End If
        'threadsafe here

    End Sub

    Private Sub Stoped() Handles Pworker.Stoped
        If Me.InvokeRequired Then
            Dim d As New DStoped(AddressOf Stoped)
            Me.Invoke(d, New Object() {})
            Return
        End If
        'threadsafe here
        If My.Settings.DbType = 1 Then
            LblDbStatus.Text = "Stopped"
            LblDbStatus.ForeColor = Color.Red
        End If
        lblNrsStatus.Text = "Stopped"
        lblNrsStatus.ForeColor = Color.Red
        btnStartStop.Text = "Start Wallet"
        btnStartStop.Enabled = True
        Running = False
    End Sub

    Private Sub Updates(ByVal Pid As Integer, ByVal Status As Integer, ByVal data As String) Handles Pworker.Update
        If Me.InvokeRequired Then
            Dim d As New DUpdate(AddressOf Updates)
            Me.Invoke(d, New Object() {Pid, Status, data})
            Return
        End If
        'threadsafe here


        Select Case Status
            Case 0 'Stoped
                If Pid = 0 Then
                    LblDbStatus.Text = "Stopped"
                    LblDbStatus.ForeColor = Color.Red
                End If
                If Pid = 1 Then
                    lblNrsStatus.Text = "Stopped"
                    lblNrsStatus.ForeColor = Color.Red
                End If
            Case 1 'Starting
                If Pid = 0 Then
                    LblDbStatus.Text = "Starting"
                    LblDbStatus.ForeColor = Color.DarkOrange
                End If
                If Pid = 1 Then
                    lblNrsStatus.Text = "Starting"
                    lblNrsStatus.ForeColor = Color.DarkOrange
                End If
            Case 2 'Running
                If Pid = 0 Then
                    LblDbStatus.Text = "Running"
                    LblDbStatus.ForeColor = Color.DarkGreen
                End If
                If Pid = 1 Then
                    lblNrsStatus.Text = "Running"
                    lblNrsStatus.ForeColor = Color.DarkGreen
                    btnStartStop.Text = "Stop Wallet"
                    Running = True
                    btnStartStop.Enabled = True
                    lblGotoWallet.Visible = True
                End If
            Case 3 'Stopping
                If Pid = 0 Then
                    LblDbStatus.Text = "Stopping"
                    LblDbStatus.ForeColor = Color.DarkOrange
                End If
                If Pid = 1 Then
                    lblNrsStatus.Text = "Stopping"
                    lblNrsStatus.ForeColor = Color.DarkOrange
                End If
            Case 4 'Console Update
                If Pid = 0 Then
                    Console(0) &= data & vbCrLf
                End If
                If Pid = 1 Then
                    Console(1) &= data & vbCrLf
                End If
            Case 5 'Error Update
                If Pid = 0 Then
                    Console(0) &= data & vbCrLf
                End If
                If Pid = 1 Then
                    Console(1) &= data & vbCrLf
                End If
            Case 10 'Error
                MsgBox("A Unhandled error happend when services tried to start. Console view might give clue to what is wrong. Some services might still be running.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
                Running = False
        End Select

    End Sub

    Private Sub btnConsole_Click(sender As Object, e As EventArgs) Handles btnConsole.Click
        frmConsole.Show()
    End Sub

    Private Sub lblGotoWallet_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGotoWallet.LinkClicked
        Process.Start("http://localhost:8125")
    End Sub

    Private Sub NewUpdatesAvilable(ByVal data As String) Handles UpdateNotifer.GetCompleate
        If Me.InvokeRequired Then
            Dim d As New DNewUpdatesAvilable(AddressOf NewUpdatesAvilable)
            Me.Invoke(d, New Object() {data})
            Return
        End If
        Try
            'we have updates
            lblShowUpdateNotification.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        frmUpdate.Show()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim s As New frmSettings

        s.ShowDialog()

    End Sub

    Private Sub ContributorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContributorsToolStripMenuItem.Click
        frmContributors.Show()
    End Sub

    Private Sub lblShowUpdateNotification_Click_1(sender As Object, e As EventArgs) Handles lblShowUpdateNotification.Click
        frmUpdate.Show()
    End Sub

    Private Sub CheckUpgrade()

        Dim CurVer As Integer = Reflection.Assembly.GetExecutingAssembly.GetName.Version.Major * 10
        CurVer += Reflection.Assembly.GetExecutingAssembly.GetName.Version.Minor

        Dim OldVer As Integer = My.Settings.Upgradev
        If CurVer <= OldVer Then Exit Sub

        Do
            Select Case OldVer
                Case 11 'upgrade from 11 to 12
                    'write a config file if missing



            End Select
            OldVer += 1
            If CurVer = OldVer Then Exit Do
        Loop

        My.Settings.Upgradev = CurVer
        My.Settings.Save()

    End Sub

    Public Sub WriteNRSConfig()

        'writing nxt.properties
        Dim Data As String = ""
        Select Case My.Settings.DbType
            Case DbType.FireBird
                Data = "#Using Firebird" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:firebirdsql:embedded:./burst_db/burst.firebirxd.db" & vbCrLf
                Data &= "nxt.dbUsername=" & vbCrLf
                Data &= "nxt.dbPassword="
            Case DbType.pMariaDB
                Data = "#Using MariaDb Portable" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:mariadb://localhost:3306/burstwallet" & vbCrLf
                Data &= "nxt.dbUsername=burstwallet" & vbCrLf
                Data &= "nxt.dbPassword=burstwallet"
            Case DbType.MariaDB
                Data = "#Using installed MariaDb" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:mariadb://" & My.Settings.DbServer & "/" & My.Settings.DbName & vbCrLf
                Data &= "nxt.dbUsername=" & My.Settings.DbUser & vbCrLf
                Data &= "nxt.dbPassword=" & My.Settings.DbPass
            Case DbType.H2
                Data = "#Using H2" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:h2:./burst_db/burst;DB_CLOSE_ON_EXIT=False" & vbCrLf
                Data &= "nxt.dbUsername=" & vbCrLf
                Data &= "nxt.dbPassword="
        End Select
        Try
            Dim basedir As String = Application.StartupPath
            If Not basedir.EndsWith("\") Then basedir &= "\"
            IO.File.WriteAllText(basedir & "conf\nxt.properties", Data)
        Catch ex As Exception

        End Try



    End Sub
    Public Sub SetDbInfo()
        Select Case My.Settings.DbType
            Case DbType.FireBird
                lblDbName.Text = "Firebird"
                LblDbStatus.Text = "Embeded"
                LblDbStatus.ForeColor = Color.DarkGreen
            Case DbType.pMariaDB
                lblDbName.Text = "MariaDb"
                LblDbStatus.Text = "Stopped"
                LblDbStatus.ForeColor = Color.Red
            Case DbType.MariaDB
                lblDbName.Text = "MariaDb"
                LblDbStatus.Text = "Unknown"
                LblDbStatus.ForeColor = Color.DarkOrange
            Case DbType.H2
                lblDbName.Text = "H2"
                LblDbStatus.Text = "Embeded"
                LblDbStatus.ForeColor = Color.DarkGreen
        End Select
    End Sub

End Class
