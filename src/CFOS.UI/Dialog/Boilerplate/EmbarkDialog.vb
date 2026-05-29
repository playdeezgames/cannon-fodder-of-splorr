Imports CFOS.Model
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
        Return CradleAreaMenuDialog.Launch(context, WorldModel.CreateAndInitialize(context.ReadString("Faction Name:", "Nacho Mamas")).CradleAreaModel, Function() Nothing).Invoke()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context).Invoke()
    End Function
End Class
