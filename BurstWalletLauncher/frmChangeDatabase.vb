﻿Public Class frmChangeDatabase
    Private Running As Boolean
    Private WithEvents WaitTimer As Timer
    Private Delegate Sub DProcEvents(ByVal [AppId] As Integer, ByVal [Operation] As Integer, ByVal [data] As String)
    Private Delegate Sub DStarting(ByVal [AppId] As Integer)
    Private Delegate Sub DStoped(ByVal [AppId] As Integer)
    Private Delegate Sub DAborted(ByVal [AppId] As Integer, ByVal [data] As String)
    Private StartTime As Date

    Private SelDB As Integer
    Private OP As Integer '0=copy 1=Fresh
#Region " Setup and form Events "

    Private Sub frmChangeDatabase_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
        Try
            If Running Then
                MsgBox("You must wait until the convertion is compleated.", MsgBoxStyle.OkOnly, "Close")
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmChangeDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SelDB = My.Settings.DbType

        'check if mariadbp is installed
        Select Case SelDB
            Case DbType.H2
                rDB1.Enabled = False
                rDB1.Text = rDB1.Text & " (Currently used)"
            Case DbType.FireBird
                rDB2.Enabled = False
                rDB2.Text = rDB2.Text & " (Currently used)"
            Case DbType.pMariaDB
                rDB3.Enabled = False
                rDB3.Text = rDB3.Text & " (Currently used)"
            Case DbType.MariaDB
                rDB4.Enabled = False
                rDB4.Text = rDB4.Text & " (Currently used)"
                pnlMariaSettings.Enabled = True
        End Select
        If Not App.isInstalled(AppNames.MariaPortable) Then
            rDB3.Enabled = False
            rDB3.Text = rDB3.Text & " (Not installed)"
        End If
        lblCurDB.Text = App.GetDbNameFromType(My.Settings.DbType)
        If Not My.Settings.DbType = DbType.H2 Then
            setdb(DbType.H2)
        Else
            setdb(DbType.FireBird)
        End If

        OP = 0

        Me.Width = 501
        Me.Height = 436

    End Sub

    Private Sub setdb(ByVal id As Integer)
        rDB1.Checked = False
        rDB2.Checked = False
        rDB3.Checked = False
        rDB4.Checked = False
        pnlMariaSettings.Enabled = False
        SelDB = id
        Select Case SelDB
            Case DbType.H2
                rDB1.Checked = True
                lblFromTo.Text = App.GetDbNameFromType(My.Settings.DbType) & " to " & App.GetDbNameFromType(DbType.H2)
            Case DbType.FireBird
                rDB2.Checked = True
                lblFromTo.Text = App.GetDbNameFromType(My.Settings.DbType) & " to " & App.GetDbNameFromType(DbType.FireBird)
            Case DbType.pMariaDB
                rDB3.Checked = True
                lblFromTo.Text = App.GetDbNameFromType(My.Settings.DbType) & " to " & App.GetDbNameFromType(DbType.pMariaDB)
            Case DbType.MariaDB
                rDB4.Checked = True
                lblFromTo.Text = App.GetDbNameFromType(My.Settings.DbType) & " to " & App.GetDbNameFromType(DbType.MariaDB)
                pnlMariaSettings.Enabled = True
        End Select
    End Sub

    Private Sub rDB1_Click(sender As Object, e As EventArgs) Handles rDB1.Click
        setdb(DbType.H2)
    End Sub
    Private Sub rDB2_Click(sender As Object, e As EventArgs) Handles rDB2.Click
        setdb(DbType.FireBird)
    End Sub
    Private Sub rDB3_Click(sender As Object, e As EventArgs) Handles rDB3.Click
        setdb(DbType.pMariaDB)
    End Sub
    Private Sub rDB4_Click(sender As Object, e As EventArgs) Handles rDB4.Click
        setdb(DbType.MariaDB)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        pnlWiz1.Hide()
        pnlWiz2.Show()
        pnlWiz2.Top = pnlWiz1.Top
        pnlWiz2.Left = pnlWiz1.Left

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        pnlWiz2.Hide()
        pnlWiz1.Show()
    End Sub

    Private Sub rOP1_CheckedChanged(sender As Object, e As EventArgs) Handles rOP1.Click
        OP = 0
        btnStart.Text = "Start Copy"
    End Sub

    Private Sub rOP2_CheckedChanged(sender As Object, e As EventArgs) Handles rOP2.CheckedChanged
        OP = 1
        btnStart.Text = "Save and close"
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        If btnStart.Text = "Close" Then
            Me.Close()
        End If
        If OP = 0 Then
            StartExport()
        Else
            My.Settings.DbType = SelDB
            My.Settings.Save()
            frmMain.WriteNRSConfig()
            frmMain.SetDbInfo()
            Me.Close()
        End If

    End Sub
#End Region


    Private Sub StartExport()
        btnBack.Enabled = False
        btnStart.Enabled = False
        rOP1.Enabled = False
        rOP2.Enabled = False

        Dim Basedir As String = Application.StartupPath
        If Not Basedir.EndsWith("\") Then Basedir &= "\"

        AddHandler ProcHandler.Aborting, AddressOf Aborted
        AddHandler ProcHandler.Started, AddressOf Starting
        AddHandler ProcHandler.Stopped, AddressOf Stopped
        AddHandler ProcHandler.Update, AddressOf ProcEvents

        StartTime = Now
        Dim Pset As New clsProcessHandler.pSettings
        Pset.AppId = AppNames.Export
        If My.Settings.JavaType = AppNames.JavaInstalled Then
            Pset.AppPath = "java"
        Else
            Pset.AppPath = Basedir & "Java\bin\java.exe"
        End If
        Pset.Cores = My.Settings.Cpulimit
        Pset.Params = "-cp burst.jar;lib\*;conf nxt.db.quicksync.CreateBinDump " & Basedir & "Convertion.bbd"
        Pset.StartSignal = ""
        Pset.StartsignalMaxTime = 1
        Pset.WorkingDirectory = Basedir
        ProcHandler.StartProcess(Pset)

        Running = True




    End Sub
    Private Sub WaitTimer_tick() Handles WaitTimer.Tick
        If frmMain.Running = False Then
            WaitTimer.Stop()
            WaitTimer.Enabled = False
            StartExport()
        End If
    End Sub

    Private Sub Starting(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DStarting(AddressOf Starting)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If

        Select Case AppId
            Case AppNames.Export
                lblStatus.Text = "Starting to export"
                pb1.Value = 0
            Case AppNames.Import
                lblStatus.Text = "Starting to Import"
                pb1.Value = 0
        End Select

    End Sub

    Private Sub Stopped(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DStoped(AddressOf Stopped)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If
        If AppId = AppNames.Export Then
            StartImport()
        End If
        If AppId = AppNames.Import Then
            Dim ElapsedTime As TimeSpan = Now.Subtract(StartTime)
            lblStatus.Text = "Done! Convertion completed in " & ElapsedTime.Hours & ":" & ElapsedTime.Minutes & ":" & ElapsedTime.Seconds
            btnStart.Text = "Close"
            btnStart.Enabled = True
            pb1.Value = 100
            Running = False
            RemoveHandler ProcHandler.Aborting, AddressOf Aborted
            RemoveHandler ProcHandler.Started, AddressOf Starting
            RemoveHandler ProcHandler.Stopped, AddressOf Stopped
            RemoveHandler ProcHandler.Update, AddressOf ProcEvents
        End If

    End Sub

    Private Sub ProcEvents(ByVal AppId As Integer, ByVal Operation As Integer, ByVal data As String)
        If Me.InvokeRequired Then
            Dim d As New DProcEvents(AddressOf ProcEvents)
            Me.Invoke(d, New Object() {AppId, Operation, data})
            Return
        End If

        Dim darray() As String = Nothing
        Dim percent As Integer = 0
        If AppId = AppNames.Export Then
            Select Case Operation

                Case ProcOp.ConsoleOut And ProcOp.ConsoleErr
                    Try
                        darray = Split(data, " ")
                        If UBound(darray) = 8 Then
                            If darray(3) = "CreateBinDump" And darray(7) = "/" Then
                                If Not darray(6) = "0" And Not darray(8) = "0" Then
                                    percent = Math.Round(Val(darray(6)) / Val(darray(8)) * 100, 0)
                                Else
                                    percent = 100
                                End If
                                lblStatus.Text = "Exporting " & darray(5).Replace(":", "") & " " & darray(6) & " of " & darray(8)
                                pb1.Value = percent
                            End If
                        End If
                    Catch ex As Exception
                        lblStatus.Text = "Error parsing data. Job still continues."
                    End Try
                Case ProcOp.Err
                    Running = False
            End Select
        End If

        If AppId = AppNames.Import Then 'we need to filter messages
            Select Case Operation
                Case ProcOp.ConsoleOut And ProcOp.ConsoleErr
                    Try
                        darray = Split(data, " ")
                        If UBound(darray) = 8 Then
                            If darray(3) = "LoadBinDump" And darray(7) = "/" Then
                                If Not darray(6) = "0" And Not darray(8) = "0" Then
                                    percent = Math.Round(Val(darray(6)) / Val(darray(8)) * 100, 0)
                                Else
                                    percent = 100
                                End If
                                lblStatus.Text = "Importing " & darray(5).Replace(":", "") & " " & darray(6) & " of " & darray(8)
                                pb1.Value = percent
                            End If
                        End If
                        If UBound(darray) > 5 Then
                            If darray(5) = "Compacting" And darray(6) = "database" Then
                                lblStatus.Text = "Compacting database. Please wait."
                                pb1.Value = 0
                            End If
                        End If
                    Catch ex As Exception
                        lblStatus.Text = "Error parsing data. Job still continues."
                    End Try
                Case ProcOp.Err
                    Running = False
            End Select
        End If
    End Sub

    Private Sub Aborted(ByVal AppId As Integer, ByVal Data As String)
        If Me.InvokeRequired Then
            Dim d As New DAborted(AddressOf Aborted)
            Me.Invoke(d, New Object() {AppId, Data})
            Return
        End If

        If AppId = AppNames.Export Or AppId = AppNames.Import Then
            MsgBox(Data)
        End If

    End Sub

    Private Sub StartImport()
        Dim Basedir As String = Application.StartupPath
        If Not Basedir.EndsWith("\") Then Basedir &= "\"
        Dim Pset As New clsProcessHandler.pSettings
        Pset.AppId = AppNames.Import
        If My.Settings.JavaType = AppNames.JavaInstalled Then
            Pset.AppPath = "java"
        Else
            Pset.AppPath = Basedir & "Java\bin\java.exe"
        End If
        Pset.Cores = My.Settings.Cpulimit
        Pset.Params = "-cp burst.jar;lib\*;conf nxt.db.quicksync.LoadBinDump " & Basedir & "Convertion.bbd -y"
        Pset.StartSignal = ""
        Pset.StartsignalMaxTime = 1
        Pset.WorkingDirectory = Basedir
        ProcHandler.StartProcess(Pset)
    End Sub

End Class