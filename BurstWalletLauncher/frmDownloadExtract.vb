﻿Public Class frmDownloadExtract

    Friend OverideFilename As String
    Friend Appid As Integer
    Friend Url As String
    Private Delegate Sub DProgress(ByVal [Job] As Integer, ByVal [AppId] As Integer, ByVal [percent] As Integer, ByVal [Speed] As Integer, ByVal [lRead] As Long, ByVal [lLength] As Long)
    Private Delegate Sub DDone(ByVal [AppId] As Integer)
    Private Delegate Sub DAborting(ByVal [AppId] As Integer)

    Private DownloadName As String 'set depending on dl type
    Private Result As DialogResult = Nothing
    Private Sub frmDownloadExtract_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler App.Progress, AddressOf Progress
        AddHandler App.DownloadDone, AddressOf Done
        AddHandler App.Aborted, AddressOf Aborting
        lblSpeed.Text = "0 KB/sec"
        lblRead.Text = "0 / 0 bytes"
        lblProgress.Text = "0%"
        Pb1.Value = 0
        If Url <> "" Then
            App.DownloadFile(Url)
            DownloadName = IO.Path.GetFileName(Url) 'just download
        Else
            App.DownloadApp(AppNames.JavaPortable) 'download and extract
            DownloadName = App.GetAppNameFromId(Appid)
        End If
        If OverideFilename <> "" Then
            DownloadName = OverideFilename
        End If
    End Sub
    Public Sub Done(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DDone(AddressOf Done)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If

        lblProgress.Text = "100%"
        Pb1.Value = 100
        Try
            RemoveHandler App.Progress, AddressOf Progress
            RemoveHandler App.DownloadDone, AddressOf Done
            RemoveHandler App.Aborted, AddressOf Aborting
        Catch ex As Exception
        End Try

        'we are done so close
        If Result = Nothing Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = Result
        End If

        Me.Close()
    End Sub

    Private Sub Aborting(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DAborting(AddressOf Aborting)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If
        Result = DialogResult.Cancel
    End Sub

    Private Sub Progress(ByVal Job As Integer, ByVal AppId As Integer, percent As Integer, ByVal Speed As Integer, ByVal lRead As Long, ByVal lLength As Long)
        If Me.InvokeRequired Then
            Dim d As New DProgress(AddressOf Progress)
            Me.Invoke(d, New Object() {Job, AppId, percent, Speed, lRead, lLength})
            Return
        End If
        Select Case Job
            Case 0
                lblStatus.Text = "Downloading: " & DownloadName
                lblSpeed.Text = CStr(Speed) & "KiB / sec"
                lblRead.Text = "Read: " & CStr(lRead) & " / " & CStr(lLength) & " bytes"
            Case 1
                lblStatus.Text = "Extracting: " & DownloadName
                lblSpeed.Visible = False
                lblRead.Visible = False
        End Select
        lblProgress.Text = CStr(percent) & "%"
        Pb1.Value = percent
    End Sub


End Class