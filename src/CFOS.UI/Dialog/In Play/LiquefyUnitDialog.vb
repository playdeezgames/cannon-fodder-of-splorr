Imports CFOS.Model
Imports TGGD.UI

Friend Class LiquefyUnitDialog
    Inherits ExitableModelDialog(Of IHostContext, IUnitModel)

    Private Sub New(context As IHostContext, model As IUnitModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IUnitModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New LiquefyUnitDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        Context.WriteLine("laksjghweoigjhs'idgjWPEGJS'LENGwg!!!")
        Model.Liquefy()
        Context.Pause()
        Return ExitDialog.Invoke()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function
End Class
