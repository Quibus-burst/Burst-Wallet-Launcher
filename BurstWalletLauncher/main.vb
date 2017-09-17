Module main


    '############################
    ' Enums
    '############################
    Public Enum DbType As Integer
        H2 = 0
        FireBird = 1
        pMariaDB = 2
        MariaDB = 3
    End Enum
    Public Enum InstallType As Integer
        Installed = 0
        Portable = 1
        Missing = 3
    End Enum
    Public Enum AppNames As Integer
        'dont forget to update const TotalNrOfApps
        Launcher = 0
        NRS = 1
        JavaInstalled = 2
        JavaPortable = 3
        MariaPortable = 4
    End Enum

    '############################
    'Const
    '############################
    'Public Const TotalNrOfApps As Integer = 4 'base 0
    '  Public Const ServiceJava As Integer = 0
    '  Public Const ServiceMaria As Integer = 1

    '############################
    'Classes
    '############################
    Public WithEvents App As clsApp


End Module
