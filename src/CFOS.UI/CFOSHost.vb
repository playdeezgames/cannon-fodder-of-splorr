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

    Public Overrides Function Run() As IDialog
        Dim dialog As IDialog = TitleDialog.Launch(context).Invoke()
        Do While dialog IsNot Nothing
            dialog = dialog.Run()
        Loop
        Return dialog
    End Function
End Class
