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

    Public Enum AppNames As Integer
        Launcher = 0
        NRS = 1
        JavaInstalled = 2
        JavaPortable = 3
        MariaPortable = 4
    End Enum
    Public Enum States
        Stopped
        Running
        Abort
    End Enum
    Public Enum ProcOp As Integer
        Running = 1
        FoundSignal = 2
        Stopping = 3
        Stopped = 4
        Err = 5
        ConsoleErr = 6
        ConsoleOut = 7
    End Enum
    '############################
    'Const
    '############################


    '############################
    'Classes
    '############################
    Public WithEvents App As clsApp
    Public WithEvents ProcHandler As clsProcessHandler

End Module
