﻿Imports System.Management

Friend Class Generic
    Public Shared DebugMe As Boolean
    Friend Shared Sub CheckUpgrade()

        Dim CurVer As Integer = Reflection.Assembly.GetExecutingAssembly.GetName.Version.Major * 10
        CurVer += Reflection.Assembly.GetExecutingAssembly.GetName.Version.Minor

        Dim OldVer As Integer = BWL.settings.Upgradev
        If CurVer <= OldVer Then Exit Sub

        Do
            Select Case OldVer
                Case 11 'upgrade from 11 to 12
                    'write a config file if missing



            End Select
            OldVer += 1
            If CurVer = OldVer Then Exit Do
        Loop

        BWL.settings.Upgradev = CurVer
        BWL.settings.SaveSettings()

    End Sub
    Friend Shared Sub WriteNRSConfig()
        Dim Data As String = ""
        Dim Buffer() As String = Nothing
        'writing nxt.properties

        'Peer settings
        Data &= "#Peer network" & vbCrLf
        Buffer = Split(BWL.settings.ListenPeer, ";")
        Data &= "nxt.peerServerPort = " & Buffer(1) & vbCrLf
        Data &= "nxt.peerServerHost = " & Buffer(0) & vbCrLf & vbCrLf

        'API settings
        Data &= "#API network" & vbCrLf
        Buffer = Split(BWL.settings.ListenIf, ";")
        Data &= "nxt.apiServerPort = " & Buffer(1) & vbCrLf
        Data &= "nxt.apiServerHost = " & Buffer(0) & vbCrLf
        If BWL.settings.ConnectFrom.Contains("0.0.0.0") Then
            Data &= "nxt.allowedBotHosts = *" & vbCrLf & vbCrLf
        Else
            Data &= "nxt.allowedBotHosts = " & BWL.settings.ConnectFrom & vbCrLf & vbCrLf
        End If


        'autoip
        If BWL.settings.AutoIp Then
            Dim ip As String = GetMyIp()
            If ip <> "" Then
                Data &= "#Auto IP set" & vbCrLf
                Data &= "nxt.myAddress = " & ip & vbCrLf & vbCrLf
            End If
        End If

        'Dyn platform
        If BWL.settings.AutoIp Then
            Dim ip As String = GetMyIp()
            If ip <> "" Then
                Data &= "#Dynamic platform" & vbCrLf
                Data &= "nxt.myPlatform = WCB-" & App.GetDbNameFromType(BWL.settings.DbType) & vbCrLf & vbCrLf
            End If
        End If

        Select Case BWL.settings.DbType
            Case DbType.FireBird
                Data &= "#Using Firebird" & vbCrLf
                Data &= "nxt.dbUrl = jdbc:firebirdsql:embedded:./burst_db/burst.firebirxd.db" & vbCrLf
                Data &= "nxt.dbUsername = " & vbCrLf
                Data &= "nxt.dbPassword = " & vbCrLf & vbCrLf
            Case DbType.pMariaDB
                Data &= "#Using MariaDb Portable" & vbCrLf
                Data &= "nxt.dbUrl = jdbc:mariadb://localhost:3306/burstwallet" & vbCrLf
                Data &= "nxt.dbUsername = burstwallet" & vbCrLf
                Data &= "nxt.dbPassword = burstwallet" & vbCrLf & vbCrLf
            Case DbType.MariaDB
                Data &= "#Using installed MariaDb" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:mariadb://" & BWL.settings.DbServer & "/" & BWL.settings.DbName & vbCrLf
                Data &= "nxt.dbUsername = " & BWL.settings.DbUser & vbCrLf
                Data &= "nxt.dbPassword = " & BWL.settings.DbPass & vbCrLf & vbCrLf
            Case DbType.H2
                Data &= "#Using H2" & vbCrLf
                Data &= "nxt.dbUrl=jdbc:h2:./burst_db/burst;DB_CLOSE_ON_EXIT=False" & vbCrLf
                Data &= "nxt.dbUsername = " & vbCrLf
                Data &= "nxt.dbPassword = " & vbCrLf & vbCrLf
        End Select

        If BWL.settings.useOpenCL Then
            Data &= "#CPU Offload" & vbCrLf
            Data &= "burst.oclAuto = true" & vbCrLf
            Data &= "burst.oclVerify = true" & vbCrLf & vbCrLf

        End If

        Try

            IO.File.WriteAllText(BaseDir & "conf\nxt.properties", Data)
        Catch ex As Exception
            If BWL.Generic.DebugMe Then BWL.Generic.WriteDebug(ex.Message)
        End Try



    End Sub
    Friend Shared Function CalculateBytes(ByVal value As Long, ByVal decimals As Integer, Optional ByVal startat As Integer = 0) As String
        Dim t As Integer
        Dim res As Double = CDbl(value)
        For t = startat To 10
            If res > 1024 Then
                res /= 1024
            Else
                Exit For
            End If
        Next
        If startat = 11 Then
            Return Math.Round(res, decimals).ToString("0.00")
        End If
        If t = 0 Then
            Return Math.Round(res, decimals).ToString("0.00") & "bytes"
        End If
        If t = 1 Then
            Return Math.Round(res, decimals).ToString("0.00") & "KiB"
        End If
        If t = 2 Then
            Return Math.Round(res, decimals).ToString("0.00") & "MiB"
        End If
        If t = 3 Then
            Return Math.Round(res, decimals).ToString("0.00") & "GiB"
        End If
        If t = 4 Then
            Return Math.Round(res, decimals).ToString("0.00") & "TiB"
        End If
        Return "??"

    End Function
    Friend Shared Function IsAdmin() As Boolean
        Try
            If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Friend Shared Sub SetFirewallFromSettings()

        Dim s() As String
        Dim buffer As String
        If IsAdmin() Then
            s = Split(BWL.settings.ListenPeer, ";")
            If s(0) = "0.0.0.0" Then s(0) = "*"
            If Not SetFirewall("Burst Peers", s(1), s(0), "") Then
                MsgBox("Failed to apply firewall rules.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Firewall")
                End
            End If
            s = Split(BWL.settings.ListenIf, ";")
            If s(0) = "0.0.0.0" Then s(0) = "*"
            buffer = Trim(BWL.settings.ConnectFrom)
            If Buffer <> "" Then
                Buffer = Buffer.Replace(";", ",")
                Buffer = Buffer.Replace(" ", "")
                If Buffer.EndsWith(",") Then Buffer = Buffer.Remove(Buffer.Length - 1)
            End If
            If Not SetFirewall("Burst Api", s(1), s(0), Buffer) Then
                MsgBox("Failed to apply firewall rules.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Firewall")
                End
            End If
            MsgBox("Windows firewall rules sucessfully applied.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Firewall")
        Else
            'start it as admin
            Try
                Dim p As Process = New Process
                p.StartInfo.WorkingDirectory = BaseDir
                p.StartInfo.Arguments = "ADDFW"
                p.StartInfo.UseShellExecute = True
                'p.StartInfo.CreateNoWindow = True 'we need window for messages(?)
                p.StartInfo.FileName = Application.ExecutablePath
                p.StartInfo.Verb = "runas"
                p.Start()
            Catch ex As Exception
                MsgBox("Failed to apply firewall rules.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Firewall")
            End Try
        End If


    End Sub

    Private Shared Function SetFirewall(ByVal fwName As String, ByVal ports As String, LocalNet As String, RemoteNet As String) As Boolean
        Try
            'first we try to remove old rule if any
            Const NET_FW_IP_PROTOCOL_TCP = 6
            Const NET_FW_RULE_DIR_IN = 1
            Const NET_FW_ACTION_ALLOW = 1
            Dim fwPolicy2 As Object = CreateObject("HNetCfg.FwPolicy2")
            Dim RulesObject As Object = fwPolicy2.Rules
            'remove old if exists
            RulesObject.Remove(fwName)
            'add new settings
            Dim CurrentProfiles As Object = fwPolicy2.CurrentProfileTypes
            Dim NewRule As Object = CreateObject("HNetCfg.FWRule")
            NewRule.Name = fwName
            NewRule.Description = "Allows incoming traffic to " & fwName
            NewRule.Protocol = NET_FW_IP_PROTOCOL_TCP
            NewRule.LocalPorts = ports
            NewRule.Direction = NET_FW_RULE_DIR_IN
            NewRule.Enabled = True
            NewRule.LocalAddresses = LocalNet
            NewRule.RemoteAddresses = RemoteNet '"127.0.0.1/255.255.255.255,192.168.0.0/255.255.255.0,192.168.1.0/255.255.0.0"
            NewRule.Profiles = 7 'CurrentProfiles
            NewRule.Action = NET_FW_ACTION_ALLOW
            RulesObject.Add(NewRule)
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function
    Friend Shared Sub CheckCommandArgs()
        '0 = appname
        '1 = Type to do

        Dim clArgs() As String = Environment.GetCommandLineArgs()
        If UBound(clArgs) > 0 Then
            Select Case clArgs(1)
                Case "ADDFW"
                    Try
                        BWL.Generic.SetFirewallFromSettings()
                    Catch ex As Exception
                        MsgBox("Failed to apply firewall rules. Maybe you run another firewall on your computer?", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Firewall")
                    End Try
                    End
                Case "InstallService"
                    Try
                        Dim Srv As String = BaseDir & "BurstService.exe"
                        Configuration.Install.ManagedInstallerClass.InstallHelper(New String() {Srv})
                        MsgBox("Sucessfully installed burst wallet as a service.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Service")
                    Catch ex As Exception
                        MsgBox("Unable to install burstwallet as a service.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Service")
                    End Try
                Case "UnInstallService"
                    Try
                        Dim Srv As String = BaseDir & "BurstService.exe"
                        Configuration.Install.ManagedInstallerClass.InstallHelper(New String() {"/u", Srv})
                        MsgBox("Sucessfully removed burstwallet from services.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Service")
                    Catch ex As Exception
                        MsgBox("Unable to remove burstwallet from services.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Service")
                    End Try
                Case "Debug"
                    BWL.Generic.DebugMe = True

            End Select

        End If
    End Sub
    Friend Shared Function SanityCheck() As Boolean

        Dim Ok As Boolean = True
        Dim searcher As ManagementObjectSearcher
        Dim cmdline As String = ""
        Dim Msg As String = ""
        Dim res As MsgBoxResult = Nothing
        'Check if Java is running another burst.jar
        searcher = New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Process WHERE Name='java.exe'")
        For Each p As ManagementObject In searcher.[Get]()
            cmdline = p("CommandLine")
            If cmdline.ToLower.Contains("burst.jar") Then
                Msg = "The launcher has detected that another burst wallet is running." & vbCrLf
                Msg &= "If the other wallet use the same setting as this one. it will not work." & vbCrLf
                Msg &= "Would you like to stop the other wallet?" & vbCrLf & vbCrLf
                Msg &= "Yes = Stop the other wallet and start this one." & vbCrLf
                Msg &= "No = Start this wallet despite the other wallet." & vbCrLf
                Msg &= "Cancel = Do not start this one." & vbCrLf
                res = MsgBox(Msg, MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel, "Another wallet is running")
                If res = MsgBoxResult.Yes Then
                    Dim proc As Process = Process.GetProcessById(Integer.Parse(p("ProcessId").ToString))
                    proc.Kill()
                    Threading.Thread.Sleep(1000)
                ElseIf res = MsgBoxResult.No Then
                    'do nothing 
                Else
                    Ok = False
                End If
            End If
        Next

        If BWL.settings.DbType = DbType.pMariaDB And Ok = True Then
            cmdline = ""
            Msg = ""
            searcher = New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Process WHERE Name='mysqld.exe'")
            For Each p As ManagementObject In searcher.[Get]()
                ' cmdline = p("CommandLine")
                Msg = "The launcher has detected that another Mysql/MariaDB is running." & vbCrLf
                Msg &= "If the other database use the same setting as this one. it will not work." & vbCrLf
                Msg &= "Would you like to stop the other database?" & vbCrLf & vbCrLf
                Msg &= "Yes = Stop the other database and start this one." & vbCrLf
                Msg &= "No = Start this database despite the other database." & vbCrLf
                Msg &= "Cancel = Do not start this one." & vbCrLf
                res = MsgBox(Msg, MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel, "Another database is running")
                If res = MsgBoxResult.Yes Then
                    Dim proc As Process = Process.GetProcessById(Integer.Parse(p("ProcessId").ToString))
                    proc.Kill()
                    Threading.Thread.Sleep(1000)
                ElseIf res = MsgBoxResult.No Then
                    'do nothing 
                Else
                    Ok = False
                End If
            Next
        End If


        Return Ok
    End Function
    Friend Shared Function GetMyIp() As String
        Try
            Dim WC As Net.WebClient = New Net.WebClient()
            Return WC.DownloadString("http://files.getburst.net/ip.php")
        Catch ex As Exception
            If BWL.Generic.DebugMe Then BWL.Generic.WriteDebug(ex.Message)
        End Try
        Return ""
    End Function
    Friend Shared Function CheckWritePermission() As Boolean
        Try
            IO.File.WriteAllText(BaseDir & "testfile", "test")
            IO.File.Delete(BaseDir & "testfile")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Friend Shared Sub WriteDebug(ByVal msg As String)

        Try
            IO.File.AppendAllText(BaseDir & "\bwl_debug.txt", msg & vbCrLf)

        Catch ex As Exception
            MsgBox(msg)
        End Try


    End Sub
    Friend Shared Sub RestartAsAdmin()

        Try
            Dim p As Process = New Process
            p.StartInfo.WorkingDirectory = BaseDir
            p.StartInfo.UseShellExecute = True
            If BWL.Generic.DebugMe Then p.StartInfo.Arguments = "Debug"
            p.StartInfo.FileName = Application.ExecutablePath
            p.StartInfo.Verb = "runas"
            p.Start()
        Catch ex As Exception
            MsgBox("Failed to start burst wallet launcher as administrator.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Admin")
        End Try
    End Sub
    Public Function GetLatencyMs(ByRef hostNameOrAddress As String) As Long
        Dim ping As New System.Net.NetworkInformation.Ping
        Return ping.Send(hostNameOrAddress, 300).RoundtripTime
    End Function
End Class
