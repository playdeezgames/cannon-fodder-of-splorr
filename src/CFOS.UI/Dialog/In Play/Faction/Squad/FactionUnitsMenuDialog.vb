Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitsMenuDialog
    Inherits BaseModelDialog(Of IFactionModel)
    Private Sub New(context As IHostContext, model As IFactionModel)
        MyBase.New(context, model)
    End Sub
    Friend Shared Function Launch(context As IHostContext, model As IFactionModel) As Func(Of IDialog)
        Return Function() New FactionUnitsMenuDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        Dim choices =
            {
            DialogChoice.CreateEnabled("Never Mind", Neutral.GetNextDialog(context, model.WorldModel)),
            DialogChoice.Create(model.CanRecruit, "Recruit...", FactionUnitRecruitMenuDialog.Launch(context, model))
            }.Concat(model.UnitModels.Select(Function(x) DialogChoice.Create(True, x.GetName(), FactionUnitDialog.Launch(context, x))))
        Return context.Choose(
            "Faction Units Menu:",
            choices.ToArray)
    End Function
End Class
