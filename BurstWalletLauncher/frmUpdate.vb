Public Class frmUpdate

    Private Delegate Sub DDLDone(ByVal [AppId] As Integer)
    Private Delegate Sub DProgress(ByVal [Job] As Integer, ByVal [AppId] As Integer, ByVal [percent] As Integer, ByVal [Speed] As Integer, ByVal [lRead] As Long, ByVal [lLength] As Long)
    Private Delegate Sub DDLError(ByVal [AppId] As Integer)
    Private WithEvents tmr As New Timer
    Private Sub frmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not App.SetRemoteInfo() Then
            MsgBox("There was an error getting update info. Check internet connection and try again.")
            Me.Close()
        End If

        If CheckAndUpdateLW() Then
            btnUpdate.Enabled = True
        Else
            btnUpdate.Enabled = False
        End If


    End Sub

    Private Sub DLDone(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DDLDone(AddressOf DLDone)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If
        CheckAndUpdateLW()
        Dim AppCount As Integer = UBound([Enum].GetNames(GetType(AppNames)))
        For t As Integer = 0 To AppCount
            If App.ShouldUpdate(t) Then
                App.DownloadApp(t)
                Exit Sub
            End If
        Next

        If App.isUpdated(AppNames.Launcher) Then
            'we should restart now since we have updates pending on ourselfs
            Dim wdir As String = Application.StartupPath
            If Not wdir.EndsWith("\") Then wdir &= "\"
            If IO.File.Exists(wdir & "Restarter.exe") Then
                Dim p As Process = New Process
                p.StartInfo.WorkingDirectory = wdir
                p.StartInfo.Arguments = "BWLUpdate" & " " & IO.Path.GetFileName(Application.ExecutablePath)
                p.StartInfo.UseShellExecute = True
                p.StartInfo.FileName = wdir & "Restarter.exe"
                p.Start()
                End
            End If
        End If

        RemoveHandler App.DownloadDone, AddressOf DLDone
        RemoveHandler App.Progress, AddressOf Progress
        RemoveHandler App.Aborted, AddressOf DlError
        frmMain.lblShowUpdateNotification.Visible = False
        pb1.Visible = False
        lblStatus.Text = "Update complete."

    End Sub

    Private Sub Progress(ByVal Job As Integer, ByVal AppId As Integer, ByVal percent As Integer, ByVal Speed As Integer, ByVal lRead As Long, ByVal lLength As Long)
        If Me.InvokeRequired Then
            Dim d As New DProgress(AddressOf Progress)
            Me.Invoke(d, New Object() {Job, AppId, percent, Speed, lRead, lLength})
            Return
        End If
        'threadsafe

        pb1.Value = percent
        Select Case Job
            Case 0

                lblStatus.Text = "Downloading: " & App.GetAppNameFromId(AppId) & " " & "Speed: " & BWL.Generic.CalculateBytes(Speed, 2, 1) & " " & "Read: " & BWL.Generic.CalculateBytes(lRead, 2, 0) & " / " & BWL.Generic.CalculateBytes(lLength, 2, 0) & " (" & CStr(percent) & "%)"
            Case 1
                lblStatus.Text = "Extracting: " & App.GetAppNameFromId(AppId)
        End Select



    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If frmMain.Running Then
            If MsgBox("Do you want to stop the wallet?" & vbCrLf & " It must be stopped before updating the components.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If App.ShouldUpdate(AppNames.Launcher) Then
            If MsgBox("Burst wallet launcher will automatically restart after update." & vbCrLf & " Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        btnUpdate.Enabled = False

        AddHandler App.DownloadDone, AddressOf DLDone
        AddHandler App.Progress, AddressOf Progress
        AddHandler App.Aborted, AddressOf DlError


        If frmMain.Running Then
            lblStatus.Text = "Waiting for wallet to stop"

            If My.Settings.DbType = DbType.pMariaDB Then 'send startsequence
                Dim Pid(1) As Object
                Pid(0) = AppNames.NRS
                Pid(1) = AppNames.MariaPortable
                ProcHandler.StopProcessSquence(Pid)
            Else
                ProcHandler.StopProcess(AppNames.NRS)
            End If

            tmr.Interval = 500
            tmr.Start()
            tmr.Enabled = True
        Else
            DLDone(0)
        End If

    End Sub

    Public Sub tmr_tick() Handles tmr.Tick

        If frmMain.Running = False Then
            tmr.Stop()
            tmr.Enabled = False
            DLDone(0)
        End If

    End Sub

    Private Function CheckAndUpdateLW() As Boolean

        Dim StrApp As String() = [Enum].GetNames(GetType(AppNames)) 'only used to count
        Dim L(2) As String
        Dim AnyUpdates As Boolean = False
        Lw1.Items.Clear()
        For t As Integer = 0 To UBound(StrApp)
            If App.isInstalled(t) Then 'no reason to test non installed
                If App.HasRepository(t) Then 'Is it available at repo?
                    L(0) = App.GetAppNameFromId(t)
                    L(1) = App.GetLocalVersion(t)
                    L(2) = App.GetRemoteVersion(t)
                    Dim itm As New ListViewItem(L)

                    If App.ShouldUpdate(t) Then
                        itm.SubItems(1).ForeColor = Color.DarkRed
                        AnyUpdates = True
                    Else
                        itm.SubItems(1).ForeColor = Color.DarkGreen
                    End If

                    itm.UseItemStyleForSubItems = False
                    Lw1.Items.Add(itm)
                End If
            End If
        Next

        Return AnyUpdates


    End Function
    Private Sub DlError(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DDLError(AddressOf DlError)
            Me.Invoke(d, New Object() {})
            Return
        End If
        Try
            MsgBox("Something went wrong. Burst wallet launcher needs internet connection to download components. Please check internet connection and your firewalls.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            RemoveHandler App.Progress, AddressOf Progress
            RemoveHandler App.DownloadDone, AddressOf DLDone
            RemoveHandler App.Aborted, AddressOf DlError
        Catch ex As Exception

        End Try
    End Sub

End Class