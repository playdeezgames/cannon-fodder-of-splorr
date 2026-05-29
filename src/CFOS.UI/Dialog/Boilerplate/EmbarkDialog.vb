Imports CFOS.Model
Imports TGGD.UI

Friend Class EmbarkDialog
    Inherits BaseDialog(Of IHostContext)

    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub

    Friend Shared Function Launch(context As IHostContext) As Func(Of IDialog)
        Return Function() New EmbarkDialog(context)
    End Function

    Public Overrides Function Run() As IDialog
        Return CradleAreaMenuDialog.Launch(Context, WorldModel.CreateAndInitialize(Context.ReadString("Faction Name:", "Nacho Mamas")).CradleAreaModel).Invoke()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context).Invoke()
    End Function
End Class
