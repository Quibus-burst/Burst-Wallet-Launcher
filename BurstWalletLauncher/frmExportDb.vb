﻿Public Class frmExportDb
    Private Running As Boolean
    Private WithEvents WaitTimer As Timer
    Private Delegate Sub DProcEvents(ByVal [AppId] As Integer, ByVal [Operation] As Integer, ByVal [data] As String)
    Private Delegate Sub DStarting(ByVal [AppId] As Integer)
    Private Delegate Sub DStoped(ByVal [AppId] As Integer)
    Private Delegate Sub DAborted(ByVal [AppId] As Integer, ByVal [data] As String)
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Burst Binary Database (*.bbd)|*.bbd|All Files (*.*)|*.*"
        If sfd.ShowDialog = DialogResult.OK Then
            txtFilename.Text = sfd.FileName
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnBrowse.Enabled = False
        txtFilename.Enabled = False
        btnStart.Enabled = False


        'try create file to check write permisions
        Try
            IO.File.WriteAllText(txtFilename.Text, "")
        Catch ex As Exception
            MsgBox("You do not have permission to write the database here." & vbCrLf & " Try another location to store the database.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "No permissions")
            Exit Sub
        End Try
        Try 'delete the file so nothing is there when exporting
            IO.File.Delete(txtFilename.Text)
        Catch ex As Exception
            MsgBox("You do not have permission to write the database here." & vbCrLf & " Try another filename or location to store the database.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "No permissions")
            Exit Sub
        End Try

        'if wallet is running shut it down
        If frmMain.Running Then
            If MsgBox("The wallet must be stopped to export the database." & vbCrLf & " Would you like to stop it now?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Stop wallet?") Then
                lblStatus.Text = "Waiting for wallet to stop."
                frmMain.StopWallet()
                WaitTimer = New Timer
                WaitTimer.Interval = 500
                WaitTimer.Enabled = True
                WaitTimer.Start()
                Exit Sub
            End If
        End If


        StartExport()
        'start process


    End Sub
    Sub StartExport()
        Dim Basedir As String = Application.StartupPath
        If Not Basedir.EndsWith("\") Then Basedir &= "\"

        AddHandler ProcHandler.Aborting, AddressOf Aborted
        AddHandler ProcHandler.Started, AddressOf Starting
        AddHandler ProcHandler.Stopped, AddressOf Stopped
        AddHandler ProcHandler.Update, AddressOf ProcEvents

        Dim Pset As New clsProcessHandler.pSettings
        Pset.AppId = AppNames.ExportImport
        If My.Settings.JavaType = AppNames.JavaInstalled Then
            Pset.AppPath = "java"
        Else
            Pset.AppPath = BaseDir & "Java\bin\java.exe"
        End If
        Pset.Cores = My.Settings.Cpulimit
        Pset.Params = "-cp burst.jar;lib\*;conf nxt.db.quicksync.CreateBinDump " & txtFilename.Text
        Pset.StartSignal = ""
        Pset.StartsignalMaxTime = 1
        Pset.WorkingDirectory = Basedir
        ProcHandler.StartProcess(Pset)

        Running = True
    End Sub
    Private Sub frmExportDb_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
        Try
            If Running Then
                MsgBox("You must wait until the export is finished.", MsgBoxStyle.OkOnly, "Close")
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try

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
            Case AppNames.ExportImport
                lblStatus.Text = "Starting to export"
                pb1.Value = 0
        End Select

    End Sub

    Private Sub Stopped(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DStoped(AddressOf Stopped)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If

        If AppId = AppNames.ExportImport Then
            btnBrowse.Enabled = True
            txtFilename.Enabled = True
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
        'threadsafe here
        Dim darray() As String = Nothing
        Dim percent As Integer = 0
        If AppId = AppNames.ExportImport Then 'we need to filter messages
            Select Case Operation
                Case ProcOp.Stopped
                Case ProcOp.FoundSignal
                Case ProcOp.Stopping
                Case ProcOp.ConsoleOut And ProcOp.ConsoleErr
                    ' txtDebug.AppendText(data & vbCrLf)
                    'collect all messages here
                    'the data we collect looks something like this
                    '[INFO] 2017-09-19 11:41:13 CreateBinDump - Block: 373000 / 404480
                    Try
                        darray = Split(data, " ")
                        'we should have ubound 8
                        If UBound(darray) = 8 Then
                            'correct length
                            If darray(3) = "CreateBinDump" And darray(7) = "/" Then
                                'we can now asume we have something to parse
                                'lets create percent
                                If Not darray(6) = "0" And Not darray(8) = "0" Then
                                    percent = Math.Round(Val(darray(6)) / Val(darray(8)) * 100, 0)
                                Else
                                    percent = 100
                                End If
                                lblStatus.Text = "Exporting " & darray(5).Replace(":", "") & " " & darray(6) & " of " & darray(8)
                                pb1.Value = percent
                            End If
                                If darray(5) = "Dump" And darray(6) = "created" Then
                                'we are done
                                Dim ts As New TimeSpan(0, 0, Val(darray(8).Replace("seconds", "")))
                                lblStatus.Text = "Done! Export completed in " & ts.Hours & ":" & ts.Minutes & ":" & ts.Seconds
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

        If AppId = AppNames.ExportImport Then
            MsgBox(Data)
        End If

    End Sub

    Private Sub frmExportDb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 316
    End Sub
End Class