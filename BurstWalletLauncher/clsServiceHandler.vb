Public Class clsServiceHandler
    Public Event MonitorEvents(ByVal Operation As Integer, ByVal Data As String)

#Region " Public Subs / Functions "


    Public Function InstallService() As Boolean
        Try
            If frmMain.IsAdmin Then
                Dim Srv As String = BaseDir & "BurstService.exe"
                Configuration.Install.ManagedInstallerClass.InstallHelper(New String() {Srv})
                Return True
            Else
                Dim p As Process = New Process
                p.StartInfo.WorkingDirectory = BaseDir
                p.StartInfo.Arguments = "InstallService"
                p.StartInfo.UseShellExecute = True
                p.StartInfo.CreateNoWindow = True
                p.StartInfo.FileName = Application.ExecutablePath
                p.StartInfo.Verb = "runas"
                p.Start()
                Return True
            End If
        Catch ex As Exception

        End Try
        Return False

    End Function
    Public Function UninstallService() As Boolean
        Try
            If frmMain.IsAdmin Then
                Dim Srv As String = BaseDir & "BurstService.exe"
                Configuration.Install.ManagedInstallerClass.InstallHelper(New String() {"/u", Srv})
                Return True
            Else
                Dim p As Process = New Process
                p.StartInfo.WorkingDirectory = BaseDir
                p.StartInfo.Arguments = "InstallService"
                p.StartInfo.UseShellExecute = True
                p.StartInfo.CreateNoWindow = True
                p.StartInfo.FileName = Application.ExecutablePath
                p.StartInfo.Verb = "runas"
                p.Start()

                Return True
            End If
        Catch ex As Exception

        End Try
        Return False
    End Function

    Public Sub StartService()
        'service
    End Sub
    Public Sub StopService()

    End Sub

    Public Function IsInstalled() As Boolean

        Return True
    End Function

    Public Function IsConnected() As Boolean

        Return True
    End Function
    Public Sub StartWallet()

    End Sub
    Public Sub StopWallet()

    End Sub
    Public Sub GetConsoleLogs()

    End Sub
    Public Sub SendCommands()

    End Sub

#End Region
    Private Sub MonitorService()

    End Sub

    Private Sub MonitorWallet()
        'catch all incomging streams here before we raise events to mainform
    End Sub


End Class
