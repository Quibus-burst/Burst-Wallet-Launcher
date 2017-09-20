﻿Imports System.Management

Public Class frmMain
    Private Delegate Sub DUpdate(ByVal [AppId] As Integer, ByVal [Operation] As Integer, ByVal [data] As String)
    Private Delegate Sub DStarting(ByVal [AppId] As Integer)
    Private Delegate Sub DStoped(ByVal [AppId] As Integer)
    Private Delegate Sub DAborted(ByVal [AppId] As Integer, ByVal [data] As String)
    Private Delegate Sub DNewUpdatesAvilable()


    Public Console(1) As String
    Public Running As Boolean
    Public Updateinfo As String
    Public BaseDir As String
    Public Repositories() As String

#Region " Form Events "
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BaseDir = Application.StartupPath
        If Not BaseDir.EndsWith("\") Then BaseDir &= "\"

        '################################
        'Start classes
        '################################
        App = New clsApp
        App.SetLocalInfo()

        If My.Settings.FirstRun Then
            frmFirstTime.ShowDialog()
        End If
        If My.Settings.FirstRun Then
            End
        End If

        CheckUpgrade() 'if there is any upgradescenarios

        If My.Settings.CheckForUpdates Then
            App.StartUpdateNotifications()
            AddHandler App.UpdateAvailable, AddressOf NewUpdatesAvilable
        End If
        SetDbInfo()
        lblWallet.Text = "Burst wallet v" & App.GetLocalVersion(AppNames.NRS)

        If My.Settings.Cpulimit = 0 Or My.Settings.Cpulimit > Environment.ProcessorCount Then 'need to set correct cpu
            Select Case Environment.ProcessorCount
                Case 1
                    My.Settings.Cpulimit = 1
                Case 2
                    My.Settings.Cpulimit = 1
                Case 4
                    My.Settings.Cpulimit = 3
                Case Else
                    My.Settings.Cpulimit = Environment.ProcessorCount - 2
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
            If Not SanityCheck() Then Exit Sub
            WriteNRSConfig()
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
        Process.Start("http://localhost:8125")
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
        If My.Settings.DbType = DbType.pMariaDB Then
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
                    Console(0) &= data & vbCrLf
                End If
                If AppId = AppNames.NRS Then
                    Console(1) &= data & vbCrLf
                End If
            Case ProcOp.ConsoleErr
                If AppId = AppNames.MariaPortable Then
                    Console(0) &= data & vbCrLf
                End If
                If AppId = AppNames.NRS Then
                    Console(1) &= data & vbCrLf
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
        If My.Settings.DbType = DbType.pMariaDB Then
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

        If My.Settings.DbType = DbType.pMariaDB Then 'send startsequence
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

            pset(1).AppId = AppNames.NRS
            If My.Settings.JavaType = AppNames.JavaInstalled Then
                pset(1).AppPath = "java"
            Else
                pset(1).AppPath = BaseDir & "Java\bin\java.exe"
            End If
            pset(1).Cores = My.Settings.Cpulimit
            pset(1).Params = "-cp burst.jar;lib\*;conf nxt.Nxt"
            pset(1).StartSignal = "Started API server at"
            pset(1).StartsignalMaxTime = 300
            pset(1).WorkingDirectory = BaseDir

            ProcHandler.StartProcessSquence(pset)


        Else 'normal start
            Dim Pset As New clsProcessHandler.pSettings
            Pset.AppId = AppNames.NRS
            If My.Settings.JavaType = AppNames.JavaInstalled Then
                Pset.AppPath = "java"
            Else
                Pset.AppPath = BaseDir & "Java\bin\java.exe"
            End If
            Pset.Cores = My.Settings.Cpulimit
            Pset.Params = "-cp burst.jar;lib\*;conf nxt.Nxt"
            Pset.StartSignal = "Started API server at"
            Pset.StartsignalMaxTime = 300
            Pset.WorkingDirectory = BaseDir

            ProcHandler.StartProcess(Pset)

        End If
    End Sub
    Public Sub StopWallet()
        If My.Settings.DbType = DbType.pMariaDB Then 'send startsequence
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
                Data &= "nxt.dbPassword=" & vbCrLf
            Case DbType.pMariaDB
                Data = "#Using MariaDb Portable" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:mariadb://localhost:3306/burstwallet" & vbCrLf
                Data &= "nxt.dbUsername=burstwallet" & vbCrLf
                Data &= "nxt.dbPassword=burstwallet" & vbCrLf
            Case DbType.MariaDB
                Data = "#Using installed MariaDb" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:mariadb://" & My.Settings.DbServer & "/" & My.Settings.DbName & vbCrLf
                Data &= "nxt.dbUsername=" & My.Settings.DbUser & vbCrLf
                Data &= "nxt.dbPassword=" & My.Settings.DbPass & vbCrLf
            Case DbType.H2
                Data = "#Using H2" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:h2:./burst_db/burst;DB_CLOSE_ON_EXIT=False" & vbCrLf
                Data &= "nxt.dbUsername=" & vbCrLf
                Data &= "nxt.dbPassword=" & vbCrLf
        End Select

        If My.Settings.useOpenCL Then
            Data &= "burst.oclAuto = True" & vbCrLf
            Data &= "burst.oclVerify = True" & vbCrLf
        Else
            Data &= "burst.oclAuto = True" & vbCrLf
            Data &= "burst.oclVerify = False" & vbCrLf
        End If


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

        End Try
    End Sub

    Private Sub ExportDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportDatabaseToolStripMenuItem.Click
        frmExportDb.Show()

    End Sub

    Private Sub ImportDatabaseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImportDatabaseToolStripMenuItem1.Click
        frmImport.Show()

    End Sub
#End Region

    Private Function SanityCheck() As Boolean

        Dim Ok As Boolean = True
        Dim searcher As ManagementObjectSearcher
        Dim cmdline As String = ""
        Dim Msg As String = ""
        Dim res As MsgBoxResult = Nothing
        'Check if Java is running another burst.jar
        searcher = New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Process WHERE Name='java.exe'")
        For Each p As ManagementObject In searcher.[Get]()
            cmdline = p("CommandLine")
            If cmdline.ToLower.Contains("burst.jar") Then
                Msg = "The launcher has detected that another burst wallet is running." & vbCrLf
                Msg &= "If the other wallet use the same setting as this one. it will not work." & vbCrLf
                Msg &= "Would you like to stop the other wallet?" & vbCrLf & vbCrLf
                Msg &= "Yes = Stop the other wallet and start this one." & vbCrLf
                Msg &= "No = Start this wallet despite the other wallet." & vbCrLf
                Msg &= "Cancel = Do not start this one." & vbCrLf
                res = MsgBox(Msg, MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel, "Another wallet is running")
                If res = MsgBoxResult.Yes Then
                    Dim proc As Process = Process.GetProcessById(Integer.Parse(p("ProcessId").ToString))
                    proc.Kill()

                ElseIf res = MsgBoxResult.No Then
                    'do nothing 
                Else
                    Ok = False
                End If
            End If
        Next



        If My.Settings.DbType = DbType.pMariaDB And Ok = True Then
            cmdline = ""
            Msg = ""
            searcher = New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Process WHERE Name='mysqld.exe'")
            For Each p As ManagementObject In searcher.[Get]()
                ' cmdline = p("CommandLine")
                Msg = "The launcher has detected that another Mysql/MariaDB is running." & vbCrLf
                Msg &= "If the other database use the same setting as this one. it will not work." & vbCrLf
                Msg &= "Would you like to stop the other database?" & vbCrLf & vbCrLf
                Msg &= "Yes = Stop the other database and start this one." & vbCrLf
                Msg &= "No = Start this database despite the other database." & vbCrLf
                Msg &= "Cancel = Do not start this one." & vbCrLf
                res = MsgBox(Msg, MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel, "Another database is running")
                If res = MsgBoxResult.Yes Then
                    Dim proc As Process = Process.GetProcessById(Integer.Parse(p("ProcessId").ToString))
                    proc.Kill()
                ElseIf res = MsgBoxResult.No Then
                    'do nothing 
                Else
                    Ok = False
                End If
            Next
        End If





        Return Ok
    End Function





End Class
