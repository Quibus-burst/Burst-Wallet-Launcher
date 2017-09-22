Public Class frmFirstTime
    Private Delegate Sub DProgress(ByVal [Job] As Integer, ByVal [AppId] As Integer, ByVal [percent] As Integer, ByVal [Speed] As Integer)
    Private Delegate Sub DDldone(ByVal [AppId] As Integer)
    Private Delegate Sub DDlError(ByVal [AppId] As Integer)
    Private SelectedDBType As Integer = 0
    Private DbVerified As Boolean = False


#Region " DB Selection "



    Private Sub ChangeButton(ByVal Dbver As Integer)

        'disable all
        r0.Checked = False
        r1.Checked = False
        r2.Checked = False
        r3.Checked = False

        P0.BackColor = Color.White
        P1.BackColor = Color.White
        P2.BackColor = Color.White
        P3.BackColor = Color.White
        SelectedDBType = Dbver
        Select Case Dbver
            Case DbType.H2
                r0.Checked = True
                P0.BackColor = SystemColors.GradientInactiveCaption
            Case DbType.FireBird
                r1.Checked = True
                P1.BackColor = SystemColors.GradientInactiveCaption
            Case DbType.pMariaDB
                r2.Checked = True
                P2.BackColor = SystemColors.GradientInactiveCaption
            Case DbType.MariaDB
                r3.Checked = True
                P3.BackColor = SystemColors.GradientInactiveCaption
        End Select
    End Sub

    'h2
    Private Sub lblH2Desc_Click(sender As Object, e As EventArgs) Handles lblH2Desc.Click
        ChangeButton(DbType.H2)
    End Sub
    Private Sub lblH2Header_Click(sender As Object, e As EventArgs) Handles lblH2Header.Click
        ChangeButton(DbType.H2)
    End Sub
    Private Sub r4_Click(sender As Object, e As EventArgs) Handles r0.Click
        ChangeButton(DbType.H2)
    End Sub
    Private Sub P0_Click(sender As Object, e As EventArgs) Handles P0.Click

        ChangeButton(DbType.H2)
    End Sub

    'FireBird
    Private Sub P1_Click(sender As Object, e As EventArgs) Handles P1.Click
        ChangeButton(DbType.FireBird)
    End Sub
    Private Sub r1_Click(sender As Object, e As EventArgs) Handles r1.Click
        ChangeButton(DbType.FireBird)
    End Sub
    Private Sub lblFireBirdHeader_Click(sender As Object, e As EventArgs) Handles lblFireBirdHeader.Click
        ChangeButton(DbType.FireBird)
    End Sub
    Private Sub lblFireBirdDesc_Click(sender As Object, e As EventArgs) Handles lblFireBirdDesc.Click
        ChangeButton(DbType.FireBird)
    End Sub

    'PMaria
    Private Sub P2_Click(sender As Object, e As EventArgs) Handles P2.Click
        ChangeButton(DbType.pMariaDB)
    End Sub
    Private Sub lblPMariaHeader_Click(sender As Object, e As EventArgs) Handles lblPMariaHeader.Click
        ChangeButton(DbType.pMariaDB)
    End Sub
    Private Sub lblPMariaDesc_Click(sender As Object, e As EventArgs) Handles lblPMariaDesc.Click
        ChangeButton(DbType.pMariaDB)
    End Sub
    Private Sub r2_click(sender As Object, e As EventArgs) Handles r2.Click
        ChangeButton(DbType.pMariaDB)
    End Sub

    'DB Own
    Private Sub P3_Click(sender As Object, e As EventArgs) Handles P3.Click
        ChangeButton(DbType.MariaDB)
    End Sub
    Private Sub lblOwnHeader_Click(sender As Object, e As EventArgs) Handles lblOwnHeader.Click
        ChangeButton(DbType.MariaDB)
    End Sub
    Private Sub lblOwnDesc_Click(sender As Object, e As EventArgs) Handles lblOwnDesc.Click
        ChangeButton(DbType.MariaDB)
    End Sub
    Private Sub r3_Click(sender As Object, e As EventArgs) Handles r3.Click
        ChangeButton(DbType.MariaDB)
    End Sub

#End Region

    Private Sub frmFirstTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 674
        Me.Height = 418 ' 405
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        Dim Ok As Boolean = True

        'Set Default settings
        btnDone.Enabled = True
        btnDownload.Enabled = False
        pnlDb.Height = pnlJava.Height
        pnlDb.Visible = True
        pnlMariaSettings.Visible = False

        'Set java panael
        If App.isInstalled(AppNames.JavaInstalled) Then
            pnlJava.BackColor = Color.PaleGreen
            lblJavaStatus.Text = "Java was found installed."
        ElseIf App.isInstalled(AppNames.JavaPortable) Then
            pnlJava.BackColor = Color.PaleGreen
            lblJavaStatus.Text = "Java was found in a portable version."
        Else
            pnlJava.BackColor = Color.LightCoral
            lblJavaStatus.Text = "Java is not found. Use download components to download a portable version."
            'offer the download
            btnDone.Enabled = False
            btnDownload.Enabled = True
        End If

        'set DB panel

        Select Case SelectedDBType
            Case DbType.H2
                pnlDb.BackColor = Color.PaleGreen
                lblDbHeader.Text = "H2"
                lblDBstatus.Text = "H2 embedded does not require aditional components."
            Case DbType.FireBird
                pnlDb.BackColor = Color.PaleGreen
                lblDbHeader.Text = "Firebird"
                lblDBstatus.Text = "Firebird embedded does not require aditional components."
            Case DbType.pMariaDB
                If App.isInstalled(AppNames.MariaPortable) Then
                    pnlDb.BackColor = Color.PaleGreen
                    lblDbHeader.Text = "MariaDB"
                    lblDBstatus.Text = "MariaDB was found as a portable version."
                Else
                    pnlDb.BackColor = Color.LightCoral
                    lblDbHeader.Text = "MariaDB"
                    lblDBstatus.Text = "MariaDB was not found. Use download components to download a portable version."
                    btnDone.Enabled = False
                    btnDownload.Enabled = True
                End If
            Case DbType.MariaDB 'we require settings
                btnDone.Enabled = False
                lblDbHeader.Text = "MariaDB / Mysql"
                lblDBstatus.Text = "Use settings below to configure the database settings."
                pnlDb.BackColor = Color.LightCoral
                pnlDb.Height = 180
                pnlMariaSettings.Visible = True
        End Select
        pnlWiz1.Visible = False
        PnlWiz2.Top = pnlWiz1.Top
        PnlWiz2.Left = pnlWiz1.Left
        PnlWiz2.Visible = True


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        PnlWiz2.Visible = False
        pnlWiz1.Visible = True
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click

        lblStatusInfo.Text = ""
        Pb1.Minimum = 0
        Pb1.Maximum = 100
        Pb1.Value = 0

        lblStatus.Visible = True
        lblStatusInfo.Visible = True
        Pb1.Visible = True
        btnDownload.Enabled = False
        btnBack.Enabled = False
        Try
            AddHandler App.Progress, AddressOf Progress
            AddHandler App.DownloadDone, AddressOf DlDone
            AddHandler App.Aborted, AddressOf DlError
        Catch ex As Exception

        End Try
        DlDone(0) 'we can init from done sub that loops over all needed

    End Sub

    Public Sub DlDone(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DDldone(AddressOf DlDone)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If

        Pb1.Value = 0

        'download java if installed or portable is missing
        If Not App.isInstalled(AppNames.JavaInstalled) And Not App.isInstalled(AppNames.JavaPortable) Then
            App.DownloadApp(AppNames.JavaPortable)
            Exit Sub
        Else 'if we have downloaded we can update screen
            pnlJava.BackColor = Color.PaleGreen
            lblJavaStatus.Text = "Java was found in a portable version."
        End If

        If SelectedDBType = DbType.pMariaDB Then
            If Not App.isInstalled(AppNames.MariaPortable) Then
                App.DownloadApp(AppNames.MariaPortable)
                Exit Sub
            Else
                pnlDb.BackColor = Color.PaleGreen
                lblDBstatus.Text = "MariaDB was found as a portable version."
            End If
        End If

        If SelectedDBType = DbType.MariaDB And DbVerified Then
            btnDone.Visible = True
        ElseIf SelectedDBType <> DbType.MariaDB Then
            btnDone.Visible = True
        End If

        Pb1.Visible = False
        lblStatusInfo.Text = "All components are downloaded."
        btnBack.Enabled = True
        'cleanup
        Try
            RemoveHandler App.Progress, AddressOf Progress
            RemoveHandler App.DownloadDone, AddressOf DlDone
            RemoveHandler App.Aborted, AddressOf DlError
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DlError(ByVal AppId As Integer)
        If Me.InvokeRequired Then
            Dim d As New DDlError(AddressOf DlError)
            Me.Invoke(d, New Object() {AppId})
            Return
        End If
        Try
            MsgBox("Something went wrong. Burst wallet launcher needs internet connection to download components. Please check internet connection and your firewalls.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            RemoveHandler App.Progress, AddressOf Progress
            RemoveHandler App.DownloadDone, AddressOf DlDone
            RemoveHandler App.Aborted, AddressOf DlError
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Progress(ByVal Job As Integer, ByVal AppId As Integer, percent As Integer, ByVal Speed As Integer)
        If Me.InvokeRequired Then
            Dim d As New DProgress(AddressOf Progress)
            Me.Invoke(d, New Object() {Job, AppId, percent, Speed})
            Return
        End If
        '  Dim AppName = [Enum].GetName(GetType(AppNames), AppId)

        Select Case Job
            Case 0
                lblStatusInfo.Text = "Downloading: " & App.GetAppNameFromId(AppId)
            Case 1
                lblStatusInfo.Text = "Extracting: " & App.GetAppNameFromId(AppId)
        End Select

        Pb1.Value = percent

    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        My.Settings.DbType = SelectedDBType
        If App.isInstalled(AppNames.JavaInstalled) Then
            My.Settings.JavaType = AppNames.JavaInstalled
        Else
            My.Settings.JavaType = AppNames.JavaPortable
        End If
        My.Settings.CheckForUpdates = chkUpdates.Checked
        My.Settings.DbName = txtDbName.Text
        My.Settings.DbPass = txtDbPass.Text
        My.Settings.DbUser = txtDbUser.Text
        My.Settings.DbServer = txtDbAddress.Text
        My.Settings.FirstRun = False
        Dim CurVer As Integer = Reflection.Assembly.GetExecutingAssembly.GetName.Version.Major * 10
        CurVer += Reflection.Assembly.GetExecutingAssembly.GetName.Version.Minor
        My.Settings.Upgradev = CurVer
        My.Settings.Save()
        'writing nxt.properties
        Me.Close()

    End Sub

    Private Sub txtDbAddress_TextChanged(sender As Object, e As EventArgs) Handles txtDbAddress.TextChanged
        CheckMariaSettings()
    End Sub

    Private Sub txtDbName_TextChanged(sender As Object, e As EventArgs) Handles txtDbName.TextChanged
        CheckMariaSettings()
    End Sub

    Private Sub txtDbUser_TextChanged(sender As Object, e As EventArgs) Handles txtDbUser.TextChanged
        CheckMariaSettings()
    End Sub

    Private Sub txtDbPass_TextChanged(sender As Object, e As EventArgs) Handles txtDbPass.TextChanged
        CheckMariaSettings()
    End Sub
    Private Sub CheckMariaSettings()
        Dim Ok As Boolean = True
        If Not txtDbAddress.Text <> "" Then Ok = False
        If Not txtDbName.Text <> "" Then Ok = False
        If Not txtDbUser.Text <> "" Then Ok = False
        If Not txtDbPass.Text <> "" Then Ok = False

        If Ok = False Then
            pnlDb.BackColor = Color.LightCoral
            DbVerified = False
        Else
            pnlDb.BackColor = Color.PaleGreen
            DbVerified = True
        End If
        'also check that we have downloaded all
        If DbVerified = True Then
            If App.isInstalled(AppNames.JavaInstalled) Or App.isInstalled(AppNames.JavaPortable) Then
                btnDone.Enabled = True
            End If
        Else
            btnDone.Enabled = False
        End If
    End Sub
End Class