﻿Public Class frmMain
    Private Delegate Sub DUpdate(ByVal [AppId] As Integer, ByVal [Operation] As Integer, ByVal [data] As String)
    Private Delegate Sub DStarting(ByVal [AppId] As Integer)
    Private Delegate Sub DStoped(ByVal [AppId] As Integer)
    Private Delegate Sub DAborted(ByVal [AppId] As Integer, ByVal [data] As String)
    Private Delegate Sub DNewUpdatesAvilable()
    Public Console(1) As List(Of String)
    Public Running As Boolean
    Public Updateinfo As String
    Public Repositories() As String
    Private LastException As Date
#Region " Form Events "
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDir = Application.StartupPath
        If Not BaseDir.EndsWith("\") Then BaseDir &= "\"
        settings = New clsSettings
        settings.LoadSettings()
        BWL.Generic.CheckCommandArgs()
        If settings.AlwaysAdmin And Not BWL.Generic.IsAdmin Then
            'restartme as admin
            BWL.Generic.RestartAsAdmin()
            End
        End If
        If BWL.Generic.DebugMe Then Me.Text = Me.Text & " (DebugMode)"
        LastException = Now

        If Not BWL.Generic.CheckWritePermission Then
            MsgBox("Burst Wallet launcher do not have writepermission to it's own folder. Please move to another location or change the permissions.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Permissions")
            End
        End If
        '################################
        'Start classes
        '################################
        App = New clsApp
        App.SetLocalInfo()
        For i As Integer = 0 To UBound(Console)
            Console(i) = New List(Of String)
        Next
        If BWL.settings.FirstRun Then
            frmFirstTime.ShowDialog()
        End If
        If BWL.settings.FirstRun Then
            End
        End If

        BWL.Generic.CheckUpgrade() 'if there is any upgradescenarios

        If BWL.settings.CheckForUpdates Then
            App.StartUpdateNotifications()
            AddHandler App.UpdateAvailable, AddressOf NewUpdatesAvilable
        End If
        SetDbInfo()
        lblWallet.Text = "Burst wallet v" & App.GetLocalVersion(AppNames.NRS)

        If BWL.settings.Cpulimit = 0 Or BWL.settings.Cpulimit > Environment.ProcessorCount Then 'need to set correct cpu
            Select Case Environment.ProcessorCount
                Case 1
                    BWL.settings.Cpulimit = 1
                Case 2
                    BWL.settings.Cpulimit = 1
                Case 4
                    BWL.settings.Cpulimit = 3
                Case Else
                    BWL.settings.Cpulimit = Environment.ProcessorCount - 2
            End Select
        End If

        ProcHandler = New clsProcessHandler
        AddHandler ProcHandler.Started, AddressOf Starting
        AddHandler ProcHandler.Stopped, AddressOf Stopped
        AddHandler ProcHandler.Update, AddressOf ProcEvents
        AddHandler ProcHandler.Aborting, AddressOf Aborted

    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Running Then
                MsgBox("You must stop the wallet before you can close the launcher", MsgBoxStyle.OkOnly, "Exit")
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception
            If BWL.Generic.DebugMe Then BWL.Generic.WriteDebug(29, ex.Message)
        End Try

    End Sub
#End Region

#Region " Clickabe Objects "
    'buttons
    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click

        If Running Then
            lblGotoWallet.Visible = False
            btnStartStop.Text = "Stopping"
            btnStartStop.Enabled = False
            StopWallet()
            'stopsequence
            '0 NRS
            '1 Mariap if needed

        Else
            If Not BWL.Generic.SanityCheck() Then Exit Sub
            BWL.Generic.WriteNRSConfig()
            StartWallet()
            Running = True
            btnStartStop.Enabled = False
            btnStartStop.Text = "Starting"
        End If

    End Sub
    Private Sub btnConsole_Click(sender As Object, e As EventArgs) Handles btnConsole.Click
        frmConsole.Show()
    End Sub

    'labels
    Private Sub lblGotoWallet_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGotoWallet.LinkClicked

        Dim s() As String = Split(BWL.settings.ListenIf, ";")
        Dim url As String = Nothing
        If s(0) = "0.0.0.0" Then
            url = "http://127.0.0.1:" & s(1)
        Else
            url = "http://" & s(0) & ":" & s(1)
        End If
        Process.Start(url)
    End Sub
    Private Sub lblShowUpdateNotification_Click_1(sender As Object, e As EventArgs) Handles lblShowUpdateNotification.Click
        frmUpdate.Show()
    End Sub

    'toolstrips
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
    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        frmUpdate.Show()
    End Sub
    Private Sub ChangeDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeDatabaseToolStripMenuItem.Click
        frmChangeDatabase.Show()
    End Sub
    Private Sub ExportDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportDatabaseToolStripMenuItem.Click
        frmExportDb.Show()
    End Sub
    Private Sub ImportDatabaseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImportDatabaseToolStripMenuItem1.Click
        frmImport.Show()
    End Sub
    Private Sub DeveloperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeveloperToolStripMenuItem.Click
        frmDeveloper.Show()
    End Sub
#End Region

#Region " Wallet Events "
    Private Sub Starting(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DStarting(AddressOf Starting)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If

        Select Case AppId
            Case AppNames.NRS
                lblNrsStatus.Text = "Starting"
                lblNrsStatus.ForeColor = Color.DarkOrange
            Case AppNames.MariaPortable
                LblDbStatus.Text = "Starting"
                LblDbStatus.ForeColor = Color.DarkOrange
        End Select


    End Sub
    Private Sub Stopped(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DStoped(AddressOf Stopped)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If

        If AppId = AppNames.NRS Then
            lblNrsStatus.Text = "Stopped"
            lblNrsStatus.ForeColor = Color.Red
        End If
        If BWL.settings.DbType = DbType.pMariaDB Then
            If AppId = AppNames.MariaPortable Then
                LblDbStatus.Text = "Stopped"
                LblDbStatus.ForeColor = Color.Red
                btnStartStop.Text = "Start Wallet"
                btnStartStop.Enabled = True
                Running = False
            End If
        Else
            btnStartStop.Text = "Start Wallet"
            btnStartStop.Enabled = True
            Running = False
        End If

    End Sub
    Private Sub ProcEvents(ByVal AppId As Integer, ByVal Operation As Integer, ByVal data As String)
        If Me.InvokeRequired Then
            Dim d As New DUpdate(AddressOf ProcEvents)
            Me.Invoke(d, New Object() {AppId, Operation, data})
            Return
        End If
        'threadsafe here
        Select Case Operation
            Case ProcOp.Stopped  'Stoped
                If AppId = AppNames.NRS Then
                    LblDbStatus.Text = "Stopped"
                    LblDbStatus.ForeColor = Color.Red
                End If
                If AppId = AppNames.MariaPortable Then
                    lblNrsStatus.Text = "Stopped"
                    lblNrsStatus.ForeColor = Color.Red
                End If
            Case ProcOp.FoundSignal
                If AppId = AppNames.MariaPortable Then
                    LblDbStatus.Text = "Running"
                    LblDbStatus.ForeColor = Color.DarkGreen
                End If
                If AppId = AppNames.NRS Then
                    lblNrsStatus.Text = "Running"
                    lblNrsStatus.ForeColor = Color.DarkGreen
                    btnStartStop.Text = "Stop Wallet"
                    Running = True
                    btnStartStop.Enabled = True
                    lblGotoWallet.Visible = True
                End If
            Case ProcOp.Stopping
                If AppId = AppNames.MariaPortable Then
                    LblDbStatus.Text = "Stopping"
                    LblDbStatus.ForeColor = Color.DarkOrange
                End If
                If AppId = AppNames.NRS Then
                    lblNrsStatus.Text = "Stopping"
                    lblNrsStatus.ForeColor = Color.DarkOrange
                End If
            Case ProcOp.ConsoleOut
                If AppId = AppNames.MariaPortable Then
                    Console(1).Add(data)
                    If Console(1).Count = 3001 Then Console(1).RemoveAt(0)
                End If
                If AppId = AppNames.NRS Then
                    Console(0).Add(data)
                    'here we can do error detection
                    If BWL.settings.WalletException And LastException.AddHours(1) < Now Then
                        If data.StartsWith("Exception in") Then
                            LastException = Now
                            ProcHandler.ReStartProcess(AppNames.NRS)
                        End If
                    End If

                    If Console(0).Count = 3001 Then Console(0).RemoveAt(0)
                End If
            Case ProcOp.ConsoleErr
                If AppId = AppNames.MariaPortable Then
                    Console(1).Add(data)
                    If Console(1).Count = 3001 Then Console(1).RemoveAt(0)
                End If
                If AppId = AppNames.NRS Then
                    Console(0).Add(data)
                    'here we can do error detection
                    If BWL.settings.WalletException And LastException.AddHours(1) < Now Then
                        If data.StartsWith("Exception in") Then
                            LastException = Now
                            ProcHandler.ReStartProcess(AppNames.NRS)
                        End If
                    End If

                    If Console(0).Count = 3001 Then Console(0).RemoveAt(0)
                End If
            Case ProcOp.Err  'Error
                MsgBox("A Unhandled error happend when services tried to start. Console view might give clue to what is wrong. Some services might still be running.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
                Running = False
        End Select

    End Sub
    Private Sub Aborted(ByVal AppId As Integer, ByVal Data As String)
        If Me.InvokeRequired Then
            Dim d As New DAborted(AddressOf Aborted)
            Me.Invoke(d, New Object() {AppId, Data})
            Return
        End If
        MsgBox(Data)
        If AppId = AppNames.NRS Then
            lblNrsStatus.Text = "Stopped"
            lblNrsStatus.ForeColor = Color.Red
        End If
        If BWL.settings.DbType = DbType.pMariaDB Then
            If AppId = AppNames.MariaPortable Then
                LblDbStatus.Text = "Stopped"
                LblDbStatus.ForeColor = Color.Red
                btnStartStop.Text = "Start Wallet"
                btnStartStop.Enabled = True
                Running = False
            End If
        Else
            btnStartStop.Text = "Start Wallet"
            btnStartStop.Enabled = True
            Running = False
        End If

    End Sub
    Private Sub StartWallet()

        If BWL.settings.DbType = DbType.pMariaDB Then 'send startsequence
            Dim pset(1) As clsProcessHandler.pSettings
            pset(0) = New clsProcessHandler.pSettings
            'mariadb
            pset(0).AppId = AppNames.MariaPortable
            pset(0).AppPath = BaseDir & "MariaDb\bin\mysqld.exe"
            pset(0).Cores = 0
            pset(0).Params = "--console"
            pset(0).WorkingDirectory = BaseDir & "MariaDb\bin\"
            pset(0).StartSignal = "ready for connections"
            pset(0).StartsignalMaxTime = 60

            pset(1) = New clsProcessHandler.pSettings
            pset(1).AppId = AppNames.NRS
            If BWL.settings.JavaType = AppNames.JavaInstalled Then
                pset(1).AppPath = "java"
            Else
                pset(1).AppPath = BaseDir & "Java\bin\java.exe"
            End If
            pset(1).Cores = BWL.settings.Cpulimit
            pset(1).Params = "-cp burst.jar;lib\*;conf nxt.Nxt"
            pset(1).StartSignal = "Started API server at"
            pset(1).StartsignalMaxTime = 300
            pset(1).WorkingDirectory = BaseDir

            ProcHandler.StartProcessSquence(pset)


        Else 'normal start
            Dim Pset As New clsProcessHandler.pSettings
            Pset.AppId = AppNames.NRS
            If BWL.settings.JavaType = AppNames.JavaInstalled Then
                Pset.AppPath = "java"
            Else
                Pset.AppPath = BaseDir & "Java\bin\java.exe"
            End If
            Pset.Cores = BWL.settings.Cpulimit
            Pset.Params = "-cp burst.jar;lib\*;conf nxt.Nxt"
            Pset.StartSignal = "Started API server at"
            Pset.StartsignalMaxTime = 300
            Pset.WorkingDirectory = BaseDir

            ProcHandler.StartProcess(Pset)

        End If
    End Sub
    Public Sub StopWallet()
        If BWL.settings.DbType = DbType.pMariaDB Then 'send startsequence
            Dim Pid(1) As Object
            Pid(0) = AppNames.NRS
            Pid(1) = AppNames.MariaPortable
            ProcHandler.StopProcessSquence(Pid)
        Else
            ProcHandler.StopProcess(AppNames.NRS)
        End If
    End Sub
#End Region

#Region " Misc "
    Public Sub SetDbInfo()

        Select Case BWL.settings.DbType
            Case DbType.FireBird
                lblDbName.Text = App.GetDbNameFromType(DbType.FireBird)
                LblDbStatus.Text = "Embeded"
                LblDbStatus.ForeColor = Color.DarkGreen
            Case DbType.pMariaDB
                lblDbName.Text = App.GetDbNameFromType(DbType.pMariaDB)
                LblDbStatus.Text = "Stopped"
                LblDbStatus.ForeColor = Color.Red
            Case DbType.MariaDB
                lblDbName.Text = App.GetDbNameFromType(DbType.MariaDB)
                LblDbStatus.Text = "Unknown"
                LblDbStatus.ForeColor = Color.DarkOrange
            Case DbType.H2
                lblDbName.Text = App.GetDbNameFromType(DbType.H2)
                LblDbStatus.Text = "Embeded"
                LblDbStatus.ForeColor = Color.DarkGreen
        End Select

    End Sub
    Private Sub NewUpdatesAvilable()
        If Me.InvokeRequired Then
            Dim d As New DNewUpdatesAvilable(AddressOf NewUpdatesAvilable)
            Me.Invoke(d, New Object() {})
            Return
        End If
        Try

            lblShowUpdateNotification.Visible = True
        Catch ex As Exception
            If BWL.Generic.DebugMe Then BWL.Generic.WriteDebug(30, ex.Message)
        End Try
    End Sub
    Private Sub ConfigureWindowsFirewallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigureWindowsFirewallToolStripMenuItem.Click

        Dim msg As String = "Would you like to autmatically configure windows firewall with your wallet connection settings?" & vbCrLf
        msg &= "This will require Administrative priveleges."

        If MsgBox(msg, MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Windows firewall") = MsgBoxResult.Yes Then

            BWL.Generic.SetFirewallFromSettings()

        End If
    End Sub


#End Region







End Class
