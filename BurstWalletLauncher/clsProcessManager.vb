Imports System.Runtime.InteropServices
Imports System.Threading

Public Class ProcessWorker
    Public Event Update(ByVal Pid As Integer, ByVal Status As Integer, ByVal Data As String) 'fires when compleytly done
    Public Event Stoped()
    Public Event Starting()

    Private WithEvents NRS As ProcessManager
    Private WithEvents Maria As ProcessManager
    Private _quit As Boolean
    Public MyLocation As String

    Public Sub Start()
        Maria = New ProcessManager
        Maria.AppToStart = MyLocation & "MariaDb\bin\mysqld.exe"
        Maria.WorkingDirectory = MyLocation & "MariaDb\bin\"
        Maria.Arguments = "--console"
        Maria.StartSignal = "ready for connections."

        'nrs service
        NRS = New ProcessManager
        NRS.AppToStart = MyLocation & "Java\bin\java.exe"
        NRS.WorkingDirectory = MyLocation
        NRS.Arguments = "-cp burst.jar;lib\*;conf nxt.Nxt"
        NRS.StartSignal = "Started API server at 127.0.0.1:8125"
        NRS.ID = 1

        _quit = False
        'run worker
        Dim trda As Thread
        trda = New Thread(AddressOf Worker)
        trda.IsBackground = True
        trda.Start()
        trda = Nothing

    End Sub

    Public Sub Quit()
        Try
            _quit = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Worker()
        Dim tmr As Date

        ' #############################################
        '  Starting Processes
        ' #############################################

        'Throw("StartingMaria")
        RaiseEvent Starting()
        RaiseEvent Update(0, 1, "") ' maria starting
        Maria.Start()
        tmr = Now.AddMinutes(1)
        Do
            If Maria.IsRunning Then Exit Do
            Thread.Sleep(500)
            If tmr < Now Then
                RaiseEvent Update(0, 10, "")
                RaiseEvent Stoped()
                Exit Sub
            End If
        Loop

        RaiseEvent Update(0, 2, "") ' maria running

        RaiseEvent Update(1, 1, "") ' nrs starting
        NRS.Start()
        tmr = Now.AddMinutes(1)
        Do
            If NRS.IsRunning Then Exit Do
            Thread.Sleep(500)
            If tmr < Now Then
                RaiseEvent Update(1, 10, "")
                RaiseEvent Stoped()
                Exit Sub
            End If

        Loop
        'Throw("NRS is running")
        RaiseEvent Update(1, 2, "")
        ' #############################################
        '  Monitoring Processes
        ' #############################################

        Do
            Thread.Sleep(500)
            If Not Maria.IsRunning Then
                RaiseEvent Update(0, 0, "") 'Maria not running
            End If

            If Not NRS.IsRunning Then
                RaiseEvent Update(1, 0, "") 'nrs not running
            End If
            'we have exit signal
            If _quit Then Exit Do
        Loop



        ' #############################################
        '  Stoping Processes
        ' #############################################
        'shutdown and wait. if not shuting down within 10sec. kill the app

        'stopnrs
        RaiseEvent Update(1, 3, "") ' NRS stopping
        NRS.ShutDown(10000, 5000)
        If Not NRS.IsRunning Then
            RaiseEvent Update(1, 0, "") ' NRS stopping
        End If

        'stopmaria
        RaiseEvent Update(0, 3, "")
        Maria.ShutDown(10000, 5000)
        If Not Maria.IsRunning Then
            RaiseEvent Update(0, 0, "") ' NRS stopping
        End If

        Try
            Maria.Cleanup()
            Maria = Nothing

        Catch ex As Exception

        End Try

        Try
            NRS.Cleanup()
            NRS = Nothing
        Catch ex As Exception

        End Try

        RaiseEvent Stoped()


    End Sub

    Private Sub NRSUpdates(ByVal type As Integer, ByVal Data As String) Handles NRS.UpdateConsole
        RaiseEvent Update(1, type, Data)
    End Sub
    Private Sub MariaUpdates(ByVal type As Integer, ByVal Data As String) Handles Maria.UpdateConsole
        RaiseEvent Update(0, type, Data)
    End Sub

End Class


Public Class ProcessManager
    Public Event UpdateConsole(ByVal type As Integer, ByVal Data As String) 'fires when compleytly done
    Private p As Process
    Public AppToStart As String
    Public WorkingDirectory As String
    Public Arguments As String
    Public OutputBuffer As String
    Public ErrorBuffer As String
    Public ID As Integer
    Public StartSignal As String
    Public FoundStartSignal As Boolean


    Private Enum CtrlTypes As UInteger
        CTRL_C_EVENT = 0
        CTRL_BREAK_EVENT
        CTRL_CLOSE_EVENT
        CTRL_LOGOFF_EVENT = 5
        CTRL_SHUTDOWN_EVENT
    End Enum
    Private Delegate Function ConsoleCtrlDelegate(CtrlType As CtrlTypes) As Boolean
    Private Declare Function AttachConsole Lib "kernel32" (dwProcessId As UInteger) As Boolean
    Private Declare Sub GenerateConsoleCtrlEvent Lib "kernel32" (ByVal dwCtrlEvent As Short, ByVal dwProcessGroupId As Short)
    Private Declare Function SetConsoleCtrlHandler Lib "kernel32" (Handler As ConsoleCtrlDelegate, Add As Boolean) As Boolean
    Private Declare Function FreeConsole Lib "kernel32" () As Boolean
    Public Sub ShutDown(ByVal SigIntSleep As Integer, ByVal SigKillSleep As Integer)
        Try
            AttachConsole(p.Id)
            SetConsoleCtrlHandler(New ConsoleCtrlDelegate(AddressOf OnExit), True)
            GenerateConsoleCtrlEvent(CtrlTypes.CTRL_C_EVENT, 0)
            p.WaitForExit(SigIntSleep) 'wait for exit before we release. if not we might get ourself terminated.
            If Not p.HasExited Then
                p.Kill()
                p.WaitForExit(SigKillSleep)
            End If
            FreeConsole()
        Catch ex As Exception

        End Try
    End Sub
    Private Function OnExit(CtrlType As CtrlTypes)
        Return True
    End Function

    Public Sub Start()
        FoundStartSignal = False
        p = New Process
        p.StartInfo.WorkingDirectory = WorkingDirectory
        p.StartInfo.Arguments = Arguments
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.CreateNoWindow = True
        AddHandler p.OutputDataReceived, AddressOf OutputHandler
        AddHandler p.ErrorDataReceived, AddressOf ErroutHandler
        p.StartInfo.FileName = AppToStart
        p.Start()
        p.BeginErrorReadLine()
        p.BeginOutputReadLine()


    End Sub
    Public Function IsRunning() As Boolean
        Try
            If p.HasExited Then

                Return False
            End If
        Catch ex As Exception
        End Try
        If FoundStartSignal Then Return True
        Return False

    End Function
    Public Function KillMe() As Boolean
        Try
            p.Kill()
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function
    Public Sub Cleanup()
        Try
            p = Nothing
            AppToStart = Nothing
            WorkingDirectory = Nothing
            Arguments = Nothing
            OutputBuffer = Nothing
            ErrorBuffer = Nothing

        Catch ex As Exception

        End Try
    End Sub
    Sub OutputHandler(sender As Object, e As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(e.Data) Then

            If e.Data.Contains(StartSignal) Then FoundStartSignal = True

            RaiseEvent UpdateConsole(4, e.Data)

        End If
    End Sub
    Sub ErroutHandler(sender As Object, e As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(e.Data) Then
            If e.Data.Contains(StartSignal) Then FoundStartSignal = True
            RaiseEvent UpdateConsole(5, e.Data)
        End If
    End Sub
End Class
