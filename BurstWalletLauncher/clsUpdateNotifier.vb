Imports System.Threading

Public Class clsUpdateNotifier
    Public Event GetCompleate(ByVal Data As String)
    Private Working As Boolean
    Private _quit As Boolean
    ' Public Repos() As String
    Sub New()
        Working = False
    End Sub
    Public Sub Start()
        If Working = True Then
            _quit = False
            Exit Sub
        End If
        Working = True
        _quit = False
        Dim trda As Thread
        trda = New Thread(AddressOf Work)
        trda.IsBackground = True
        trda.Start()
        trda = Nothing
    End Sub
    Public Sub Quit()
        _quit = True
    End Sub
    Private Sub Work()
        Dim Nextcheck As New Date
        Dim Data As String = ""
        Do
            Dim CheckUpdates As New clsUpdater
            If CheckUpdates.GetNewVersions() Then
                For l = 0 To UBound(CheckUpdates.Updates)
                    If Not CheckUpdates.Updates(l).CurVer = CheckUpdates.Updates(l).NewVer Then
                        RaiseEvent GetCompleate("")
                        Exit For
                    End If
                Next
            End If
            CheckUpdates = Nothing
            Nextcheck = Now.AddDays(1) '24 hours check
            Do
                Thread.Sleep(600000) 'sleep for 10 minutes
                If Now > Nextcheck Then Exit Do
                If _quit Then Exit Do
            Loop
            If _quit = False Then Exit Do
        Loop
        Nextcheck = Nothing
        Working = False
    End Sub
End Class


