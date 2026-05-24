Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionMenuDialog
    Inherits BaseModelDialog

    Private Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel) As Func(Of IDialog)
        Return Function() New FactionMenuDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        context.OutputLine($"Faction Name: {model.FactionName}")
        Return context.Choose(
            "Menu:",
            DialogChoice.CreateEnabled("Rename...", AddressOf RenameFaction),
            DialogChoice.CreateEnabled(
                "Never Mind",
                Neutral.GetNextDialog(context, model)))
    End Function

    Private Function RenameFaction() As IDialog
        model.FactionName = context.ReadString("New Faction Name:", model.FactionName)
        Return Launch(context, model).Invoke()
    End Function
End Class
