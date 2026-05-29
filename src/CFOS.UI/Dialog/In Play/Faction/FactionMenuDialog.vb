Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionMenuDialog
    Inherits ExitableModelDialog(Of IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New FactionMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        context.WriteLine($"Faction Name: {model.FactionName}")
        Return context.Choose(
            "Menu:",
            DialogChoice.CreateEnabled(
                "Never Mind",
                Neutral.GetNextDialog(context, model)),
        DialogChoice.CreateEnabled("Rename...", AddressOf RenameFaction))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, model, exitDialog).Invoke
    End Function

    Private Function RenameFaction() As IDialog
        model.FactionName = context.ReadString("New Faction Name:", model.FactionName)
        Return Launch(context, model, exitDialog).Invoke()
    End Function
End Class
