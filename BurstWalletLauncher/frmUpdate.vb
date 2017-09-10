Public Class frmUpdate

    Private WithEvents Upd As clsUpdater
    Private Delegate Sub DNewVersionsDone()
    Private Delegate Sub DUpdateDone()
    Private Delegate Sub DProgress(ByVal [ptype] As Integer, ByVal [Msg] As String, ByVal [percent] As Integer)
    Private WithEvents tmr As New Timer
    Private Sub frmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Upd = New clsUpdater
        Upd.ThreadNewVersions()
    End Sub

    Private Sub NewVersionsDone() Handles Upd.LoadDone
        If Me.InvokeRequired Then
            Dim d As New DNewVersionsDone(AddressOf NewVersionsDone)
            Me.Invoke(d, New Object() {})
            Return
        End If
        Dim needupdate As Boolean = False
        lblcLauncher.Text = "v" & Upd.Updates(0).sCurVer
        lblNLauncher.Text = "v" & Upd.Updates(0).sNewVer
        If Upd.Updates(0).sCurVer = Upd.Updates(0).sNewVer Then
            lblcLauncher.ForeColor = Color.DarkGreen
        Else
            lblcLauncher.ForeColor = Color.Red
            needupdate = True
        End If


        lblcNRS.Text = "v" & Upd.Updates(1).sCurVer
        lblnNRS.Text = "v" & Upd.Updates(1).sNewVer
        If Upd.Updates(1).sCurVer = Upd.Updates(1).sNewVer Then
            lblcNRS.ForeColor = Color.DarkGreen
        Else
            lblcNRS.ForeColor = Color.Red
            needupdate = True
        End If

        lblStatus.Text = "Done"

        If needupdate Then btnUpdate.Enabled = True

    End Sub

    Private Sub Progress(ByVal ptype As Integer, ByVal Msg As String, ByVal percent As Integer) Handles Upd.Progress
        If Me.InvokeRequired Then
            Dim d As New DProgress(AddressOf Progress)
            Me.Invoke(d, New Object() {ptype, Msg, percent})
            Return
        End If
        'threadsafe

        Select Case ptype
            Case 0 'wainting for wallet
                pb1.Visible = False
                lblStatus.Text = Msg
            Case 1
                pb1.Visible = True
                lblStatus.Text = Msg
                pb1.Value = percent
            Case 2
                pb1.Visible = True
                pb1.Value = percent
                lblStatus.Text = Msg
        End Select




    End Sub
    Private Sub UpdateDone() Handles Upd.UpdateDone
        If Me.InvokeRequired Then
            Dim d As New DUpdateDone(AddressOf UpdateDone)
            Me.Invoke(d, New Object() {})
            Return
        End If

        If Upd.Updates(0).CurVer <> Upd.Updates(0).NewVer Then
            Dim wdir As String = Application.StartupPath
            If Not wdir.EndsWith("\") Then wdir &= "\"
            If IO.File.Exists(wdir & "Restarter.exe") Then
                Dim p As Process = New Process
                p.StartInfo.WorkingDirectory = wdir
                p.StartInfo.Arguments = Upd.LauncherUpdateFile & " " & IO.Path.GetFileName(Application.ExecutablePath)
                p.StartInfo.UseShellExecute = True
                p.StartInfo.FileName = wdir & "Restarter.exe"
                p.Start()
                End
            Else
                Dim msg As String = "The file restarter.exe is missing." & vbCrLf & vbCrLf
                msg &= "To continue update you must do the following:" & vbCrLf
                msg &= "1. Close the wallet launcher" & vbCrLf
                msg &= "2. Delete the file BurstWalletLauncher.exe" & vbCrLf
                msg &= "3. Rename the file BWLUpdate to BurstWalletLauncher.exe" & vbCrLf

                MsgBox(msg, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Update")
            End If
        Else
                frmMain.lblShowUpdateNotification.Visible = False
            pb1.Visible = False
            lblStatus.Text = "Checking for new updates"
            Upd.LoadCurVersions()
            Upd.ThreadNewVersions()
        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If frmMain.Running Then
            If MsgBox("Do you want to stop the wallet?" & vbCrLf & " It must be stopped before updating the components.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        btnUpdate.Enabled = False
        If frmMain.Running Then
            lblStatus.Text = "Waiting for wallet to stop"
            frmMain.Pworker.Quit() 'stopping wallet if running
            tmr.Interval = 500
            tmr.Start()
            tmr.Enabled = True
        Else
            Upd.StartUpdates()
        End If





    End Sub

    Public Sub tmr_tick() Handles tmr.Tick

        'launch updatesequence when wallet is stopped
        If frmMain.Running = False Then
            Upd.StartUpdates()
            tmr.Stop()
            tmr.Enabled = False
        End If



    End Sub

End Class