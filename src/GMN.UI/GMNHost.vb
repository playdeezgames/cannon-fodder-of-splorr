Imports TGGD.UI

Public Class GMNHost
    Inherits Host

    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub
    Public Shared Sub Execute(context As IHostContext)
        Dim host As New GMNHost(context)
        host.Run()
    End Sub

    Public Overrides Function Run() As IDialog
        Context.WriteLine("Hello, world!")
        Context.Pause()
        Return Nothing
    End Function
End Class
