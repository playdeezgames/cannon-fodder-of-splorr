Imports TGGD.UI

Friend Class EmbarkDialog
    Inherits BaseDialog

    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub

    Friend Shared Function Launch(context As IHostContext) As Func(Of IDialog)
        Return Function() New EmbarkDialog(context)
    End Function

    Public Overrides Function Run() As IDialog
        Throw New NotImplementedException()
    End Function
End Class
