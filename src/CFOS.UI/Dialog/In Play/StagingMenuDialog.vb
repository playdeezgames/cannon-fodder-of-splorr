Imports CFOS.Model
Imports TGGD.UI

Friend Class StagingMenuDialog
    Inherits BaseModelDialog(Of IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, worldModel As IWorldModel) As Func(Of IDialog)
        Return Function() New StagingMenuDialog(context, worldModel)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        context.WriteLine($"Faction Name: {model.FactionName}")
        Dim faction = model.FactionModel
        context.WriteLine($"Faction Units: {faction.UnitCount}")
        Return context.Choose(
            "Now What?",
            DialogChoice.CreateEnabled("Units...", FactionUnitsMenuDialog.Launch(context, faction, Launch(context, model))),
            DialogChoice.CreateEnabled("Faction...", FactionMenuDialog.Launch(context, model, Launch(context, model))),
            DialogChoice.CreateEnabled("Game Menu", GameMenuDialog.Launch(context, model)))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Throw New NotImplementedException()
    End Function
End Class
