Imports System.Net.Sockets
Public Class clsSystemCheck
    Public Event Done()



    Public Structure StrucService
        Public Service As String
        Public Status As Boolean
        Public Note As String
        Public Path As String
        Public InstallType As Integer
    End Structure

    Public Service() As StrucService
    Public AllServicesOk As Boolean
    Private _basedir As String
    Sub New()
        ReDim Service(3)
        AllServicesOk = False
        Service(ServiceJava).Service = "Java"
        Service(ServiceJava).Status = False
        Service(ServiceJava).InstallType = InstallType.Missing
        Service(ServiceMaria).Service = "MariaDB"
        Service(ServiceMaria).Status = False
        Service(ServiceMaria).InstallType = InstallType.Missing
        Service(2).Service = "MariaDB Port"
        Service(2).Status = False
        Service(3).Service = "NRS Ports"
        Service(3).Status = False
        _basedir = Application.StartupPath
        If Not _basedir.EndsWith("\") Then _basedir &= "\"
    End Sub

    Public Sub CheckInstall()

        If CheckSystemJava() Then
            Service(ServiceJava).InstallType = InstallType.Installed
        ElseIf FindJavaPortable() Then
            Service(ServiceJava).InstallType = InstallType.Portable
        Else
            Service(ServiceJava).InstallType = InstallType.Missing
        End If

        If CheckMariaDB() Then
            Service(ServiceMaria).InstallType = InstallType.Portable
        Else
            Service(ServiceMaria).InstallType = InstallType.Missing
        End If

    End Sub

    Public Function CheckSystemJava() As Boolean
        Dim JavaFound As Boolean = False
        Try
            Dim p As New Process
            Dim result As String = ""
            p.StartInfo.RedirectStandardError = True
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True
            p.StartInfo.FileName = "java"
            p.StartInfo.Arguments = "-d64 -showversion"
            p.Start()
            p.WaitForExit()
            result = LCase(p.StandardError.ReadLine())
            If result <> "" Then
                If LCase(result).Contains("java version") Then
                    result = result.Replace("java version", "")
                    result = result.Replace(" ", "")
                    result = Trim(result.Replace(Chr(34), ""))
                    JavaFound = CheckVersion("1.8", result, False)
                End If
            End If
            p.Dispose()
            p.Dispose()
        Catch ex As Exception

        End Try
        Return JavaFound
    End Function

    Private Function FindJavaPortable(Optional ByVal path As String = "") As Boolean
        If path = "" Then path = _basedir & "Java\bin\java.exe"

        'check java portable
        If IO.File.Exists(path) Then
            Service(0).Status = True
            Service(0).Note = "Found"
            Return True
        Else
            Service(0).Status = False
            Service(0).Note = "Java package is missing from the bundle."
            Return False
        End If

    End Function
    Private Function CheckMariaDB(Optional ByVal path As String = "") As Boolean
        If path = "" Then path = _basedir & "MariaDb\bin\mysqld.exe"
        Try
            If IO.File.Exists(path) Then
                Service(1).Status = True
                Service(1).Note = "Found"
            Else
                Service(1).Status = False
                Service(1).Note = "Maria DB is not found."
            End If
        Catch ex As Exception

        End Try
        Return Service(1).Status
    End Function
    Private Sub CheckMariaPort()
        If CheckPorts(3306) Then
            Service(2).Status = False
            Service(2).Note = "You either already have Maria DB running or another database that conflicts with this bundle."
        Else
            Service(2).Status = True
            Service(2).Note = "No Maria/Mysql found running."
        End If
    End Sub
    Private Sub CheckNRSPorts()
        Service(3).Status = True
        Service(3).Note = "No NRS found running."
        For t As Integer = 8124 To 8126
            If CheckPorts(t) Then
                Service(3).Status = False
                Service(3).Note = "Port " & CStr(t) & " seams to be used by another service. You may already have a wallet running."
                Exit For
            End If
        Next
    End Sub
    Private Function CheckPorts(ByVal port As Integer) As Boolean
        Dim popen As Boolean = False
        Dim Client As New TcpClient
        Try
            Client.SendTimeout = 100
            Client.Connect("127.0.0.1", port)
            popen = True
        Catch ex As SocketException
        End Try
        Try
            If Not Client Is Nothing Then Client.Close()
        Catch ex As Exception
        End Try
        Return popen
    End Function
    Public Function CheckVersion(ByVal MinVersion As String, ByVal NewVersion As String, ByVal OnlyNew As Boolean) As Boolean

        MinVersion = MinVersion.Replace("_", ".")
        Dim mver() As String = Split(MinVersion, ".")

        NewVersion = NewVersion.Replace("_", ".")
        Dim nver() As String = Split(NewVersion, ".")

        If nver.Length <> mver.Length Then
            If nver.Length > mver.Length Then
                ReDim Preserve mver(UBound(nver))
            Else
                ReDim Preserve nver(UBound(mver))
            End If
        End If

        Dim vheight As Integer = 1 '0=lower version '1 same version '2 newer version
        For t As Integer = 0 To UBound(mver)
            If Val(nver(t)) > Val(mver(t)) Then
                vheight = 2
                Exit For
            ElseIf nver(t) < mver(t) Then
                vheight = 0
                Exit For
            End If
        Next
        Dim result As Boolean = False
        If OnlyNew Then
            If vheight = 2 Then result = True
        Else
            If vheight <> 0 Then result = True
        End If

        Return result
    End Function


End Class
