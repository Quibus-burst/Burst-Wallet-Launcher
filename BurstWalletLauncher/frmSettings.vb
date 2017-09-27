Imports System.Net
Imports System.Net.NetworkInformation

Public Class frmSettings

    Private JavaType As Integer

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If Not App.isInstalled(AppNames.JavaInstalled) Then rJava0.Enabled = False
        If Not App.isInstalled(AppNames.JavaPortable) Then rJava1.Enabled = False
        If My.Settings.DbType = DbType.MariaDB Then
            pnlMaria.Enabled = True
            pnlDbSettings.Enabled = True
        Else
            pnlMaria.Enabled = True
            pnlDbSettings.Enabled = False
        End If
        lblDb.Text = App.GetDbNameFromType(My.Settings.DbType)

        chkCheckForUpdates.Checked = My.Settings.CheckForUpdates
        chkAlwaysAdmin.Checked = My.Settings.AlwaysAdmin

        chkAutoIP.Checked = My.Settings.CheckForUpdates
        chkDynPlatform.Checked = My.Settings.DynPlatform
        txtDbServer.Text = My.Settings.DbServer
        txtDbName.Text = My.Settings.DbName
        txtDbUser.Text = My.Settings.DbUser
        txtDbPass.Text = My.Settings.DbPass
        ChangeJavaType(My.Settings.JavaType)
        If App.CheckOpenCL() Then
            chkOpenCL.Checked = My.Settings.useOpenCL
        Else
            chkOpenCL.Enabled = False
            chkOpenCL.Checked = False
        End If

        nrCores.Maximum = Environment.ProcessorCount
        nrCores.Value = My.Settings.Cpulimit
        lblMaxCores.Text = CStr(Environment.ProcessorCount) & " cores."
        Select Case Environment.ProcessorCount
            Case 1
                lblRecommendedCPU.Text = CStr(1) & " cores."
            Case 2
                lblRecommendedCPU.Text = CStr(1) & " cores."
            Case 4
                lblRecommendedCPU.Text = CStr(3) & " cores."
            Case Else
                lblRecommendedCPU.Text = CStr(Environment.ProcessorCount - 2) & " cores."
        End Select

        'SetNRSnet
        SetIf()
        SetAllowedIP()
        chkFirewall.Checked = My.Settings.SetFireWall



    End Sub

    Private Sub ChangeJavaType(ByVal id As Integer)
        rJava0.Checked = False
        rJava1.Checked = False
        Select Case id
            Case AppNames.JavaInstalled
                rJava0.Checked = True
            Case AppNames.JavaPortable
                rJava1.Checked = True
            Case Else
                rJava1.Checked = True
                id = AppNames.JavaPortable
        End Select
        JavaType = id
    End Sub

    Private Sub rJava0_Click(sender As Object, e As EventArgs) Handles rJava0.Click
        ChangeJavaType(AppNames.JavaInstalled)
    End Sub
    Private Sub rJava1_Click(sender As Object, e As EventArgs) Handles rJava1.Click
        ChangeJavaType(AppNames.JavaPortable)
    End Sub


    Public Sub SaveSettings()

        Dim buffer As String = ""

        'generic
        My.Settings.CheckForUpdates = chkCheckForUpdates.Checked
        My.Settings.AlwaysAdmin = chkAlwaysAdmin.Checked

        'nrs

        My.Settings.AutoIP = chkAutoIP.Checked
        My.Settings.DynPlatform = chkDynPlatform.Checked
        'nrs advanced
        My.Settings.Cpulimit = nrCores.Value
        My.Settings.useOpenCL = chkOpenCL.Checked
        'nrs net
        If cmbListen.SelectedIndex = 0 Then
            My.Settings.ListenIf = "0.0.0.0" & ";" & CStr(nrListenPort.Value)
        Else
            My.Settings.ListenIf = cmbListen.Items.Item(cmbListen.SelectedIndex) & ";" & CStr(nrListenPort.Value)
        End If
        If cmbPeerIP.SelectedIndex = 0 Then
            My.Settings.ListenPeer = "0.0.0.0" & ";" & CStr(nrPeerPort.Value)
        Else
            My.Settings.ListenPeer = cmbPeerIP.Items.Item(cmbPeerIP.SelectedIndex) & ";" & CStr(nrPeerPort.Value)
        End If



        For x As Integer = 0 To lstConnectFrom.Items.Count - 1
            buffer &= lstConnectFrom.Items.Item(x) & ";"
        Next
        My.Settings.ConnectFrom = buffer
        My.Settings.SetFireWall = chkFirewall.Checked

        My.Settings.DbServer = txtDbServer.Text
        My.Settings.DbName = txtDbName.Text
        My.Settings.DbUser = txtDbUser.Text
        My.Settings.DbPass = txtDbPass.Text

        My.Settings.JavaType = JavaType
        My.Settings.Save()

        'ok lets fix firewall if its intended to be like that

        If chkFirewall.Checked Then
            Dim s() As String = Nothing

            If BWL.Generic.IsAdmin Then
                Try
                    s = Split(My.Settings.ListenPeer, ";")
                    If s(0) = "0.0.0.0" Then s(0) = "*"
                    BWL.Generic.SetFirewall("Burst Peers", s(1), s(0), "")
                    s = Split(My.Settings.ListenIf, ";")
                    If s(0) = "0.0.0.0" Then s(0) = "*"
                    buffer = Trim(My.Settings.ConnectFrom)
                    If buffer <> "" Then
                        buffer = buffer.Replace(";", ",")
                        buffer = buffer.Replace(" ", "")
                        If buffer.EndsWith(",") Then buffer = buffer.Remove(buffer.Length - 1)
                    End If
                    BWL.Generic.SetFirewall("Burst Api", s(1), s(0), buffer)
                    MsgBox("Windows firewall rules sucessfully applied.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Firewall")
                Catch ex As Exception
                    MsgBox("Failed to apply firewall rules. Maybe you run another firewall on your computer?", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Firewall")
                End Try
            Else
                'start process with admin
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
        End If



        Me.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveSettings()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveSettings()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SaveSettings()
    End Sub

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics = e.Graphics
        Dim _TB As Brush
        Dim _TP As TabPage = TabControl1.TabPages(e.Index)
        Dim _TA As Rectangle = TabControl1.GetTabRect(e.Index)
        If (e.State = DrawItemState.Selected) Then
            _TB = New SolidBrush(Color.Black)
            g.FillRectangle(Brushes.SkyBlue, e.Bounds)
        Else
            _TB = New SolidBrush(e.ForeColor)
            e.DrawBackground()
        End If
        Dim _TF As New Font("Arial", 12.0, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim _strFlags As New StringFormat()
        _strFlags.Alignment = StringAlignment.Center
        _strFlags.LineAlignment = StringAlignment.Center
        g.DrawString(_TP.Text, _TF, _TB, _TA, New StringFormat(_strFlags))
    End Sub

    Private Sub nrCores_ValueChanged(sender As Object, e As EventArgs)
        If nrCores.Value > Environment.ProcessorCount Then nrCores.Value = Environment.ProcessorCount
        If nrCores.Value < 1 Then nrCores.Value = 1

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SaveSettings()
    End Sub

    Private Sub SetIf()
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        cmbListen.Items.Clear()
        cmbPeerIP.Items.Clear()
        cmbListen.Items.Add("All Interfaces")
        cmbPeerIP.Items.Add("All Interfaces")
        cmbListen.Items.Add("127.0.0.1")
        cmbPeerIP.Items.Add("127.0.0.1")

        For Each adapter In adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            For Each address In properties.UnicastAddresses
                'If address.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                If adapter.OperationalStatus = OperationalStatus.Up And adapter.NetworkInterfaceType = NetworkInterfaceType.Ethernet Then
                    If address.Address.ToString.Contains("%") Then
                        Dim buffer As String = address.Address.ToString.Remove(address.Address.ToString.IndexOf("%"))
                        cmbListen.Items.Add(buffer)
                        cmbPeerIP.Items.Add(buffer)
                    Else
                        cmbListen.Items.Add(address.Address.ToString)
                        cmbPeerIP.Items.Add(address.Address.ToString)
                    End If


                End If
                'End If
            Next
        Next adapter


        Dim S() As String = Nothing
        Try
            S = Split(My.Settings.ListenPeer, ";")
            nrPeerPort.Value = Val(S(1))
            If S(0) = "0.0.0.0" Then
                cmbPeerIP.SelectedIndex = 0
            Else
                For t As Integer = 0 To cmbListen.Items.Count - 1
                    If cmbPeerIP.Items.Item(t) = S(0) Then cmbListen.SelectedIndex = t
                Next
            End If
        Catch ex As Exception
            If BWL.Generic.DebugMe Then BWL.Generic.WriteDebug(ex.Message)
        End Try


        Try
            S = Split(My.Settings.ListenIf, ";")
            nrListenPort.Value = Val(S(1))
            If S(0) = "0.0.0.0" Then
                cmbListen.SelectedIndex = 0
            Else
                For t As Integer = 0 To cmbListen.Items.Count - 1
                    If cmbListen.Items.Item(t) = S(0) Then cmbListen.SelectedIndex = t
                Next
            End If
        Catch ex As Exception
            If BWL.Generic.DebugMe Then BWL.Generic.WriteDebug(ex.Message)
        End Try


    End Sub

    Private Sub SetAllowedIP()

        Dim s() As String = Split(My.Settings.ConnectFrom, ";")
        lstConnectFrom.Items.Clear()
        For Each netw As String In s
            If Trim(netw) <> "" Then
                lstConnectFrom.Items.Add(Trim(netw))
            End If
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim buffer() As String = Split(txtAddAllow.Text, "/")

        Dim ip As IPAddress = Nothing

        Select Case UBound(buffer)
            Case 0
                If Not IPAddress.TryParse(buffer(0), ip) Then
                    MsgBox("You have not entered a valid IP.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Wrong format")
                    Exit Sub
                End If

                lstConnectFrom.Items.Add(buffer(0))
            Case 1
                If Not IPAddress.TryParse(buffer(0), ip) Then
                    MsgBox("You have not entered a valid cidr network.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Wrong format")
                    Exit Sub
                End If
                If buffer(0).Contains(":") Then 'ipv6
                    If Val(buffer(1)) > 128 Or Val(buffer(1)) < 0 Then
                        MsgBox("You have not entered a valid ipv6 cidr network.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Wrong format")
                        Exit Sub
                    End If

                Else 'ipv4
                    If Val(buffer(1)) > 32 Or Val(buffer(1)) < 0 Then
                        MsgBox("You have not entered a valid  ipv4 cidr network.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Wrong format")
                        Exit Sub
                    End If
                End If
                lstConnectFrom.Items.Add(buffer(0) & "/" & buffer(1))
            Case Else
                MsgBox("You have not entered a valid IP or network.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Wrong format")
        End Select
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If lstConnectFrom.SelectedIndex = -1 Then Exit Sub
        lstConnectFrom.Items.RemoveAt(lstConnectFrom.SelectedIndex)
    End Sub

End Class