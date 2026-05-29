Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionMenuDialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New FactionMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        Context.Clear()
        Context.WriteLine($"Faction Name: {Model.FactionName}")
        Return Context.Choose(
            "Menu:",
            ExitChoice,
            DialogChoice.CreateEnabled("Rename...", AddressOf RenameFaction))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, EditDialog).Invoke
    End Function

    Private Function RenameFaction() As IDialog
        Model.FactionName = Context.ReadString("New Faction Name:", Model.FactionName)
        Return Relaunch()
    End Function
End Class
