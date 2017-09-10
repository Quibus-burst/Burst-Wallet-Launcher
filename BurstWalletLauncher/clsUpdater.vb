Imports System.IO
Imports System.IO.Compression
Imports System.Threading

Public Class clsUpdater
    Public Repos() As String
    Public Event Progress(ByVal ptype As Integer, ByVal Msg As String, ByVal Percent As Integer) '0 waiting for wallet 1 download 2 unpack
    Public Event UpdateDone()
    Public Event LoadDone()
    Public LauncherUpdateFile As String
    Public Structure Versions
        Dim Service As String
        Dim CurVer As Integer
        Dim NewVer As Integer
        Dim sCurVer As String
        Dim sNewVer As String
        Dim TargetDir As String
        Dim Remoteurl As String
    End Structure
    Public Updates(1) As Versions

    Public Sub New()
        Updates(0).Service = "Burst wallet launcher"
        Updates(1).Service = "Burst NRS"
        LoadCurVersions()
        ReDim Repos(1)
        Repos(0) = "http://files.getburst.net/"
        Repos(1) = "http://files2.getburst.net/"
        LauncherUpdateFile = "BWLUpdate" 'this is the file that should be extracted
    End Sub

    Public Sub ThreadNewVersions()
        Dim trda As Thread
        trda = New Thread(AddressOf GetNewVersions)
        trda.IsBackground = True
        trda.Start()
        trda = Nothing
    End Sub
    Public Sub StartUpdates()
        Dim trda As Thread
        trda = New Thread(AddressOf UpdateSequence)
        trda.IsBackground = True
        trda.Start()
        trda = Nothing
    End Sub

    Public Function GetNewVersions() As Boolean

        Dim Http As clsHttp
        Dim data As String = ""
        Try
            For i = 0 To UBound(Repos)
                Http = New clsHttp
                data = Http.GetUrl(Repos(i) & "versions")
                Http = Nothing
                If data.Length <> 0 Then Exit For
            Next
            If data.Length <> 0 Then
                Dim Services() As String = Split(data, vbCrLf)
                For Each Line In Services
                    If Trim(Line) <> "" Then
                        Dim Cell() As String = Split(Line, "|")
                        If UBound(Cell) = 3 Then
                            Select Case Cell(0)
                                Case "Launcher"
                                    Updates(0).NewVer = Val(Cell(1).Replace(".", ""))
                                    Updates(0).TargetDir = ""
                                    Updates(0).Remoteurl = Cell(3)
                                    Updates(0).sNewVer = Cell(1)
                                Case "NRS"
                                    Updates(1).NewVer = Val(Cell(1).Replace(".", ""))
                                    Updates(1).TargetDir = ""
                                    Updates(1).Remoteurl = Cell(3)
                                    Updates(1).sNewVer = Cell(1)
                            End Select
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Return False
        End Try
        RaiseEvent LoadDone()
        Return True
    End Function

    Public Sub LoadCurVersions()
        Dim basedir As String = Application.StartupPath
        If Not basedir.EndsWith("\") Then basedir &= "\"
        Try
            'Launcher
            Dim Major As String = CStr(Reflection.Assembly.GetExecutingAssembly.GetName.Version.Major)
            Dim Minor As String = CStr(Reflection.Assembly.GetExecutingAssembly.GetName.Version.Minor)
            Updates(0).CurVer = Val(Major & Minor)
            Updates(0).sCurVer = Major & "." & Minor
            'NRS
            If IO.File.Exists(basedir & "conf\version") Then
                OpenClose(basedir & "conf\version")  'To prevent os cache to return wrong data.
                Dim Version As String = IO.File.ReadAllText(basedir & "conf\version")
                Version.Trim()
                Updates(1).CurVer = Val(Version.Replace(".", ""))
                Updates(1).sCurVer = Version
            End If
        Catch ex As Exception

        End Try
        RaiseEvent LoadDone()

    End Sub


    Private Sub UpdateSequence()

        Dim basedir As String = Application.StartupPath
        If Not basedir.EndsWith("\") Then basedir &= "\"


        'get NRS
        If Updates(1).CurVer < Updates(1).NewVer Then
            DownloadFile(Updates(1).Remoteurl, basedir & "NRSUpdate.zip", Updates(1).Service)
            RaiseEvent Progress(1, Updates(1).Service, 0)
            Extractfiles(basedir & "NRSUpdate.zip", basedir & Updates(1).TargetDir, Updates(1).Service)
            File.Delete(basedir & "NRSUpdate.zip")
        End If

        'get Launcher
        If Updates(0).CurVer < Updates(0).NewVer Then
            DownloadFile(Updates(0).Remoteurl, basedir & "Launcher.zip", Updates(0).Service)
            Extractfiles(basedir & "Launcher.zip", basedir & Updates(0).TargetDir, Updates(0).Service)
            File.Delete(basedir & "Launcher.zip")
        End If

        RaiseEvent UpdateDone()

    End Sub



    Private Function DownloadFile(ByVal Url As String, ByVal filename As String, ByVal ServiceName As String) As Boolean

        Dim http As Net.HttpWebRequest
        Dim WebResponse As Net.HttpWebResponse
        Dim bBuffer(4095) As Byte '4k chunks
        Dim TotalRead As Long
        Dim iBytesRead As Integer = 0
        Dim ContentLength As Long = 0
        Dim percent As Integer = 0
        Try
            http = Net.WebRequest.Create(Url)
            WebResponse = http.GetResponse
            ContentLength = WebResponse.ContentLength
            Dim sChunks As Stream = WebResponse.GetResponseStream
            Dim File As FileStream = New FileStream(filename, FileMode.Create, FileAccess.Write)
            TotalRead = 0
            Do
                iBytesRead = sChunks.Read(bBuffer, 0, 4096)
                If iBytesRead = 0 Then Exit Do
                TotalRead += iBytesRead
                File.Write(bBuffer, 0, iBytesRead)
                percent = Math.Round((TotalRead / ContentLength) * 100, 0)
                RaiseEvent Progress(1, "Downloading " & ServiceName, percent)
            Loop
            File.Flush()
            File.Close()
            sChunks.Close()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Sub OpenClose(ByVal filename As String)

        Try
            Dim tmp As FileStream = File.OpenWrite(filename)
            tmp.Close()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Extractfiles(ByVal filename As String, ByVal target As String, ByVal Servicename As String)
        Try
            Dim Archive As ZipArchive = ZipFile.OpenRead(filename)
            Dim totalfiles As Integer = Archive.Entries.Count
            Dim counter As Integer = 0
            Dim percent As Integer = 0
            For Each entry As ZipArchiveEntry In Archive.Entries
                If entry.FullName.EndsWith("/") Then
                    If Not Directory.Exists(Path.Combine(target, entry.FullName)) Then
                        Directory.CreateDirectory(Path.Combine(target, entry.FullName))
                    End If
                Else
                        entry.ExtractToFile(Path.Combine(target, entry.FullName), True)
                End If
                counter += 1
                percent = Math.Round((counter / totalfiles) * 100, 0)
                RaiseEvent Progress(2, "Extracting: " & Servicename, percent)
            Next
            Archive.Dispose()
        Catch ex As Exception

        End Try



    End Sub
End Class
