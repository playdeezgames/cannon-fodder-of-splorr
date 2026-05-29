Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitsMenuDialog
    Inherits ExitableModelDialog(Of IFactionModel)
    Private Sub New(context As IHostContext, model As IFactionModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub
    Friend Shared Function Launch(context As IHostContext, model As IFactionModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New FactionUnitsMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        Dim choices =
            {
            NeverMindChoice,
            DialogChoice.Create(model.CanRecruit, "Recruit...", FactionUnitRecruitMenuDialog.Launch(context, model, AddressOf Relaunch))
            }.Concat(model.UnitModels.Select(Function(x) DialogChoice.Create(True, x.GetName(), FactionUnitDialog.Launch(context, x, AddressOf Relaunch))))
        Return context.Choose(
            "Faction Units Menu:",
            choices.ToArray)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, model, exitDialog).Invoke
    End Function
End Class
