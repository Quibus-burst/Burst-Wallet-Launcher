Module main

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

    Public Const ServiceJava As Integer = 0
    Public Const ServiceMaria As Integer = 1
End Module
