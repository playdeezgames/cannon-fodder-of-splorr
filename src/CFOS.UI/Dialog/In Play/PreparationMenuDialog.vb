Imports CFOS.Model
Imports TGGD.UI

Friend Class PreparationMenuDialog
    Inherits BaseModelDialog(Of IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, worldModel As IWorldModel) As Func(Of IDialog)
        Return Function() New PreparationMenuDialog(context, worldModel)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        context.OutputLine($"Faction Name: {model.FactionName}")
        Dim squad = model.Squad
        context.OutputLine($"Squad Members: {squad.UnitCount}")
        Return context.Choose(
            "Now What?",
            DialogChoice.CreateEnabled("Squad...", SquadMenuDialog.Launch(context, squad)),
            DialogChoice.CreateEnabled("Faction...", FactionMenuDialog.Launch(context, model)),
            DialogChoice.CreateEnabled("Game Menu", GameMenuDialog.Launch(context, model)))
    End Function
End Class
