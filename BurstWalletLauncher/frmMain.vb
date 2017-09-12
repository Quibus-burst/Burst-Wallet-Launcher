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

            Dim systemcheck As New clsSystemCheck
            systemcheck.CheckSystem()
            If Not systemcheck.AllServicesOk Then
                Dim Msg As String = ""
                For t As Integer = 0 To UBound(systemcheck.Service)
                    If systemcheck.Service(t).Status = False Then Msg &= systemcheck.Service(t).Note & vbCrLf
                Next
                MsgBox(Msg, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Cannot start.")
                Exit Sub
            End If

            Dim Mylocation = Application.StartupPath
            If Not Mylocation.EndsWith("\") Then Mylocation &= "\"
            Pworker = New ProcessWorker
            Pworker.MyLocation = Mylocation
            Running = True

            btnStartStop.Enabled = False
            Pworker.Start()
            btnStartStop.Text = "Starting"
        End If

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDir = Application.StartupPath
        If Not BaseDir.EndsWith("\") Then BaseDir &= "\"


        '   frmFirstTime.Show() only for debug
        If My.Settings.FirstRun Then
            If MsgBox("Would you like to turn on the feature to notify you of new updates?" & vbCrLf & " You will have the option to change this in settings later.", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Settings") = MsgBoxResult.Yes Then
                My.Settings.CheckForUpdates = True
                My.Settings.FirstRun = False
            Else
                My.Settings.CheckForUpdates = False
                My.Settings.FirstRun = False
            End If
            My.Settings.Save()
        End If

        UpdateNotifer = New clsUpdateNotifier
        If My.Settings.CheckForUpdates Then
            UpdateNotifer.Start()
        End If




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

        LblMariaStatus.Text = "Stopped"
        LblMariaStatus.ForeColor = Color.Red
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
                    LblMariaStatus.Text = "Stopped"
                    LblMariaStatus.ForeColor = Color.Red

                End If
                If Pid = 1 Then
                    lblNrsStatus.Text = "Stopped"
                    lblNrsStatus.ForeColor = Color.Red
                End If
            Case 1 'Starting
                If Pid = 0 Then
                    LblMariaStatus.Text = "Starting"
                    LblMariaStatus.ForeColor = Color.DarkOrange
                End If
                If Pid = 1 Then
                    lblNrsStatus.Text = "Starting"
                    lblNrsStatus.ForeColor = Color.DarkOrange
                End If
            Case 2 'Running
                If Pid = 0 Then
                    LblMariaStatus.Text = "Running"
                    LblMariaStatus.ForeColor = Color.Green
                End If
                If Pid = 1 Then
                    lblNrsStatus.Text = "Running"
                    lblNrsStatus.ForeColor = Color.Green
                    btnStartStop.Text = "Stop Wallet"
                    Running = True
                    btnStartStop.Enabled = True
                    lblGotoWallet.Visible = True
                End If
            Case 3 'Stopping
                If Pid = 0 Then
                    LblMariaStatus.Text = "Stopping"
                    LblMariaStatus.ForeColor = Color.DarkOrange

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

    Private Sub lblShowUpdateNotification_Click(sender As Object, e As EventArgs) Handles lblShowUpdateNotification.Click
        frmUpdate.Show()
    End Sub

    Private Sub CheckForUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdateToolStripMenuItem.Click
        frmUpdate.Show()
    End Sub

    Private Sub WalletLauncherSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WalletLauncherSettingsToolStripMenuItem.Click
        frmSettings.Show()

    End Sub
End Class
