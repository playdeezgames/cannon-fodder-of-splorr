Imports CFOS.Model
Imports TGGD.UI

Friend Class LegacyFactionMenuDialog
    Inherits BaseModelDialog(Of IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel) As Func(Of IDialog)
        Return Function() New LegacyFactionMenuDialog(context, model)
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

    Private Function RenameFaction() As IDialog
        model.FactionName = context.ReadString("New Faction Name:", model.FactionName)
        Return Launch(context, model).Invoke()
    End Function
End Class
