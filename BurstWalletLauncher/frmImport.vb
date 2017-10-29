﻿Public Class frmImport
    Private Running As Boolean
    Private WithEvents WaitTimer As Timer
    Private Delegate Sub DProcEvents(ByVal [AppId] As Integer, ByVal [Operation] As Integer, ByVal [data] As String)
    Private Delegate Sub DStarting(ByVal [AppId] As Integer)
    Private Delegate Sub DStoped(ByVal [AppId] As Integer)
    Private Delegate Sub DAborted(ByVal [AppId] As Integer, ByVal [data] As String)
    Private Delegate Sub DDownloadDone(ByVal [AppId] As Integer)
    Private Delegate Sub DProgress(ByVal [JobType] As Integer, ByVal [AppId] As Integer, ByVal [Percernt] As Integer, ByVal [Speed] As Integer, ByVal [lRead] As Long, ByVal [lLength] As Long)
    Private Delegate Sub DDLAborted(ByVal [AppId] As Integer)
    Private RepoDBUrls() As String
    Private SelectedType As Integer
    Private StartTime As Date
    Private IsAborted As Boolean
    Private Sub frmImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Running = False
        cmbRepo.Items.Clear()
        ReDim RepoDBUrls(0)
        RepoDBUrls(0) = "http://package.cryptoguru.org/dumps/latest.bbd"
        cmbRepo.Items.Add("Cryptoguru repository")
        cmbRepo.SelectedIndex = 0
        'r1.Checked = False
        'r2.Checked = True

        'r1.Enabled = False

        'cmbRepo.Enabled = False

    End Sub
    Private Sub frmImport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Running Then
                MsgBox("You cannot close the import form while importing.", MsgBoxStyle.OkOnly, "Exit")
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception
            If BWL.Generic.DebugMe Then BWL.Generic.WriteDebug(ex.StackTrace, ex.Message)
        End Try

    End Sub
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If btnStart.Text = "Close" Then
            Me.Close()
            Exit Sub
        End If

        If Not MsgBox("Warning!" & vbCrLf & vbCrLf & "All existing data in your database will be erased." & vbCrLf & "Do you want to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel, "All existing data removed") = MsgBoxResult.Yes Then
            Exit Sub
        End If

        r1.Enabled = False
        r2.Enabled = False
        r3.Enabled = False
        cmbRepo.Enabled = False
        txtUrl.Enabled = False
        txtFile.Enabled = False
        btnBrowse.Enabled = False
        btnStart.Enabled = False

        'PreCheck
        'Repo is ok!
        If SelectedType = 2 Then
            Try
                Dim url As Uri = New Uri(txtUrl.Text)
            Catch ex As Exception
                'if not interpreted as url it will fail
                MsgBox("The url you have entered is not a valid url.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Url error")
                Exit Sub
            End Try
        End If
        If SelectedType = 3 Then
            Try
                If Not IO.File.Exists(txtFile.Text) Then
                    MsgBox("The file you have selected does not exist. Please select a valid file.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "File not exist.")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("The file you have selected does not exist. Please select a valid file.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "File not exist.")
            End Try
        End If

        StartTime = Now
        Running = True
        'if wallet is running shut it down
        If frmMain.Running Then
            If MsgBox("The wallet must be stopped to import the database." & vbCrLf & " Would you like to stop it now?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Stop wallet?") Then
                lblStatus.Text = "Waiting for wallet to stop."
                frmMain.StopWallet()
                WaitTimer = New Timer
                WaitTimer.Interval = 500
                WaitTimer.Enabled = True
                WaitTimer.Start()
                Exit Sub
            End If
        End If
        AddHandler ProcHandler.Aborting, AddressOf Aborted
        AddHandler ProcHandler.Started, AddressOf Starting
        AddHandler ProcHandler.Stopped, AddressOf Stopped
        AddHandler ProcHandler.Update, AddressOf ProcEvents
        If BWL.settings.DbType = DbType.pMariaDB Then
            StartMaria()
        Else
            StartImport()
        End If


    End Sub
    Sub StartImport()
        IsAborted = False
        Select Case SelectedType
            Case 1
                ImportFromUrl(RepoDBUrls(cmbRepo.SelectedIndex))
            Case 2
                ImportFromUrl(txtUrl.Text)
            Case 3
                ImportFromFile(txtFile.Text)
        End Select

    End Sub
    Private Sub ImportFromFile(ByVal FileName As String)

        Dim Pset As New clsProcessHandler.pSettings
        Pset.AppId = AppNames.Import
        If BWL.settings.JavaType = AppNames.JavaInstalled Then
            Pset.AppPath = "java"
        Else
            Pset.AppPath = BaseDir & "Java\bin\java.exe"
        End If
        Pset.Cores = BWL.settings.Cpulimit
        Pset.Params = "-cp burst.jar;conf nxt.db.quicksync.LoadBinDump " & FileName & " -y"
        Pset.StartSignal = ""
        Pset.StartsignalMaxTime = 1
        Pset.WorkingDirectory = BaseDir
        ProcHandler.StartProcess(Pset)


    End Sub
    Private Sub ImportFromUrl(ByVal Url As String)
        Dim S As frmDownloadExtract
        S = New frmDownloadExtract
        S.Url = Url
        If S.ShowDialog = DialogResult.OK Then
            ImportFromFile(BaseDir & IO.Path.GetFileName(Url))
            Exit Sub
        End If
        'we have aborted return to download again
        IsAborted = True
        If DbType.pMariaDB Then StopMaria()

        Running = False
        r1.Enabled = True
        r2.Enabled = True
        r3.Enabled = True
        cmbRepo.Enabled = True
        txtUrl.Enabled = True
        txtFile.Enabled = True
        btnBrowse.Enabled = True
        btnStart.Enabled = True
        SetSelect(SelectedType)
        lblStatus.Text = "Aborted"
    End Sub

    Private Sub SetSelect(ByVal id As Integer)
        r1.Checked = False
        r2.Checked = False
        r3.Checked = False
        cmbRepo.Enabled = False
        txtUrl.Enabled = False
        txtFile.Enabled = False
        btnBrowse.Enabled = False
        SelectedType = id
        Select Case id
            Case 1
                r1.Checked = True
                cmbRepo.Enabled = True
            Case 2
                r2.Checked = True
                txtUrl.Enabled = True
            Case 3
                r3.Checked = True
                txtFile.Enabled = True
                btnBrowse.Enabled = True
        End Select
    End Sub
    Private Sub r1_Click(sender As Object, e As EventArgs) Handles r1.Click
        SetSelect(1)
    End Sub
    Private Sub r2_Click(sender As Object, e As EventArgs) Handles r2.Click
        SetSelect(2)
    End Sub
    Private Sub r3_Click(sender As Object, e As EventArgs) Handles r3.Click
        SetSelect(3)
    End Sub
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Burst Binary Database (*.bbd)|*.bbd|All Files (*.*)|*.*"
        If ofd.ShowDialog = DialogResult.OK Then
            txtFile.Text = ofd.FileName
        End If
    End Sub


#Region " Proc Events "
    Private Sub Starting(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DStarting(AddressOf Starting)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If

        Select Case AppId
            Case AppNames.Import
                lblStatus.Text = "Starting to import."
                pb1.Value = 0
        End Select

    End Sub
    Private Sub Stopped(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DStoped(AddressOf Stopped)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If

        If AppId = AppNames.Import Then
            If BWL.settings.DbType = DbType.pMariaDB Then
                StopMaria()
            Else
                Complete()
            End If
        End If
        If AppId = AppNames.MariaPortable Then
            Complete()
        End If
    End Sub
    Private Sub Complete()
        If IsAborted = False Then
            Dim ElapsedTime As TimeSpan = Now.Subtract(StartTime)
            lblStatus.Text = "Done! Import completed in " & ElapsedTime.Hours & ":" & ElapsedTime.Minutes & ":" & ElapsedTime.Seconds
            SetSelect(SelectedType)
            btnStart.Text = "Close"
            btnStart.Enabled = True
            pb1.Value = 100
            Running = False
        Else
            SetSelect(SelectedType)
            '            btnStart.Text = "Close"
            btnStart.Enabled = True
            pb1.Value = 100
            Running = False
        End If


        RemoveHandler ProcHandler.Aborting, AddressOf Aborted
        RemoveHandler ProcHandler.Started, AddressOf Starting
        RemoveHandler ProcHandler.Stopped, AddressOf Stopped
        RemoveHandler ProcHandler.Update, AddressOf ProcEvents
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
        If AppId = AppNames.Import Then 'we need to filter messages
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
                            If darray(3) = "LoadBinDump" And darray(7) = "/" Then
                                'we can now asume we have something to parse
                                'lets create percent
                                If Not darray(6) = "0" And Not darray(8) = "0" Then
                                    percent = Math.Round(Val(darray(6)) / Val(darray(8)) * 100, 0)
                                Else
                                    percent = 100
                                End If
                                lblStatus.Text = "Importing " & darray(5).Replace(":", "") & " " & darray(6) & " of " & darray(8)
                                pb1.Value = percent
                            End If
                            If darray(5) = "Dump" And darray(6) = "loaded" Then
                                'we are done

                                Dim ts As New TimeSpan(0, 0, Val(darray(8).Replace("seconds", "")))

                                lblStatus.Text = "Done! Export completed in " & ts.Hours & ":" & ts.Minutes & ":" & ts.Seconds
                            End If
                            'Compacting database - this may take a while

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
        If AppId = AppNames.MariaPortable Then
            If Operation = ProcOp.FoundSignal Then
                StartImport()
            End If
        End If
    End Sub
    Private Sub Aborted(ByVal AppId As Integer, ByVal Data As String)
        If Me.InvokeRequired Then
            Dim d As New DAborted(AddressOf Aborted)
            Me.Invoke(d, New Object() {AppId, Data})
            Return
        End If

        If AppId = AppNames.Import Then
            MsgBox(Data)
        End If

    End Sub
#End Region


    Private Sub WaitTimer_tick() Handles WaitTimer.Tick
        If frmMain.Running = False Then
            WaitTimer.Stop()
            WaitTimer.Enabled = False
            AddHandler ProcHandler.Aborting, AddressOf Aborted
            AddHandler ProcHandler.Started, AddressOf Starting
            AddHandler ProcHandler.Stopped, AddressOf Stopped
            AddHandler ProcHandler.Update, AddressOf ProcEvents
            If BWL.settings.DbType = DbType.pMariaDB Then
                StartMaria()
            Else
                StartImport()
            End If
        End If
    End Sub


    Private Sub StartMaria()
        Try
            If BWL.Generic.SanityCheck Then
                lblStatus.Text = "Starting MariaDB"
                Dim pr As New clsProcessHandler.pSettings
                pr.AppId = AppNames.MariaPortable
                pr.AppPath = BaseDir & "MariaDb\bin\mysqld.exe"
                pr.Cores = 0
                pr.Params = "--console"
                pr.WorkingDirectory = BaseDir & "MariaDb\bin\"
                pr.StartSignal = "ready for connections"
                pr.StartsignalMaxTime = 60
                ProcHandler.StartProcess(pr)
            Else

            End If
        Catch ex As Exception
            MsgBox("Unable to start Maria Portable.")
        End Try

    End Sub
    Private Sub StopMaria()
        lblStatus.Text = "Stopping MariaDB"
        ProcHandler.StopProcess(AppNames.MariaPortable)
    End Sub



End Class