Imports System.ServiceProcess

Public Class clsServiceHandler
    Public Event MonitorEvents(ByVal Operation As Integer, ByVal Data As String)

#Region " Public Service Subs / Functions  "
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
        Dim service As ServiceController = New ServiceController("Burst Service")
        If service.Status.Equals(ServiceControllerStatus.Stopped) Or service.Status.Equals(ServiceControllerStatus.StopPending) Then
            service.Start()
        End If
    End Sub
    Public Sub StopService()
        Dim service As ServiceController = New ServiceController("Burst Service")
        If service.Status.Equals(ServiceControllerStatus.Running) Or service.Status.Equals(ServiceControllerStatus.StartPending) Then
            service.Stop()
        End If
    End Sub
    Public Function IsInstalled() As Boolean
        Dim service As ServiceController = New ServiceController("Burst Service")
        If service.Status = Nothing Then
            Return False
        End If
        Return True
    End Function
    Public Function IsServiceRunning() As Boolean
        Dim service As ServiceController = New ServiceController("Burst Service")
        If service.Status.Equals(ServiceControllerStatus.Running) Or service.Status.Equals(ServiceControllerStatus.StartPending) Then
            Return True
        End If
        Return False
    End Function
#End Region

#Region " Public Wallet Sub / Functions "


    Public Function IsConnected() As Boolean

        Return True
    End Function
    Public Sub StartWallet()

    End Sub
    Public Sub StopWallet()

    End Sub
    Public Sub GetConsoleLogs()

    End Sub
    Public Sub SendCommands(ByVal data As String)

    End Sub

#End Region
    Private Sub MonitorService()
        '???
    End Sub

    Private Sub MonitorWallet()
        'catch all incomging streams here before we raise events to mainform
    End Sub


End Class
