Imports TGGD.UI

Public Class CFOSHost
    Inherits Host
    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub
    Public Shared Sub Execute(context As IHostContext)
        Dim host As New CFOSHost(context)
        host.Run()
    End Sub

    Public Overrides Sub Run()
        context.OutputLine("Welcome to:")
        context.OutputLine("Cannon Fodder of SPLORR!!")
        context.OutputLine("A production of TheGrumpyGameDev")
        context.Pause()
    End Sub
End Class
