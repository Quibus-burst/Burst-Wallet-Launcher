Friend Class Settings
    'NRS
    Private Shared _autoip As Boolean
    Private Shared _WalletException As Boolean
    Private Shared _DynPlatform As Boolean
    Private Shared _useOpenCL As Boolean
    Private Shared _Cpulimit As Integer
    Private Shared _ListenIf As String
    Private Shared _ListenPeer As String
    Private Shared _ConnectFrom As String
    'DB
    Private Shared _DbType As Integer
    Private Shared _DbServer As String
    Private Shared _DbUser As String
    Private Shared _DbName As String
    Private Shared _DbPass As String

    'JAVA
    Private Shared _JavaType As Integer

    'general
    Private Shared _FirstRun As Boolean
    Private Shared _CheckForUpdates As Boolean
    Private Shared _Upgradev As Integer
    Private Shared _AlwaysAdmin As Boolean
    Private Shared _Repo As String

    Friend Shared Sub DefaultSettings()
        _autoip = True
        _WalletException = True
        _DynPlatform = True
        _useOpenCL = False
        _Cpulimit = 0
        _ListenIf = "127.0.0.1;8125"
        _ListenPeer = "0.0.0.0;8123"
        _ConnectFrom = "127.0.0.1"

        _DbType = 0
        _DbServer = "127.0.0.1:3306"
        _DbName = "burstwallet"
        _DbUser = ""
        _DbPass = ""

        _JavaType = 1

        _FirstRun = False
        _CheckForUpdates = True
        _Upgradev = 12
        _AlwaysAdmin = False
        _Repo = "http://files.getburst.net;http://files2.getburst.net"
    End Sub
    'NRS
    Friend Property AutoIp() As Boolean
        Get
            Return _autoip
        End Get
        Set(ByVal value As Boolean)
            _autoip = value
        End Set
    End Property
    Friend Property WalletException() As Boolean
        Get
            Return _WalletException
        End Get
        Set(ByVal value As Boolean)
            _WalletException = value
        End Set
    End Property
    Friend Property DynPlatform() As Boolean
        Get
            Return _DynPlatform
        End Get
        Set(ByVal value As Boolean)
            _DynPlatform = value
        End Set
    End Property
    Friend Property useOpenCL() As Boolean
        Get
            Return _useOpenCL
        End Get
        Set(ByVal value As Boolean)
            _useOpenCL = value
        End Set
    End Property
    Friend Property Cpulimit() As Integer
        Get
            Return _Cpulimit
        End Get
        Set(ByVal value As Integer)
            _Cpulimit = value
        End Set
    End Property
    Friend Property ListenIf() As String
        Get
            Return _ListenIf
        End Get
        Set(ByVal value As String)
            _ListenIf = value
        End Set
    End Property
    Friend Property ListenPeer() As String
        Get
            Return _ListenPeer
        End Get
        Set(ByVal value As String)
            _ListenPeer = value
        End Set
    End Property
    Friend Property ConnectFrom() As String
        Get
            Return _ConnectFrom
        End Get
        Set(ByVal value As String)
            _ConnectFrom = value
        End Set
    End Property
    'DB

    'JAVA

    'General


End Class
