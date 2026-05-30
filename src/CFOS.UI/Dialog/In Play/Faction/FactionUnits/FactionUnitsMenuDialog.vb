Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitsMenuDialog
    Inherits ExitableModelDialog(Of IHostContext, IFactionModel)
    Private Sub New(context As IHostContext, model As IFactionModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub
    Friend Shared Function Launch(context As IHostContext, model As IFactionModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New FactionUnitsMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        Context.Clear()
        Dim choices =
            {
            ExitChoice,
            DialogChoice.Create(Model.CanRecruit, "Recruit...", FactionUnitRecruitMenuDialog.Launch(Context, Model, AddressOf Relaunch))
            }.Concat(Model.UnitModels.Select(Function(x) DialogChoice.Create(True, x.GetName(), FactionUnitDialog.Launch(Context, x, AddressOf Relaunch))))
        Return Context.Choose(
            "Faction Units Menu:",
            choices.ToArray)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function
End Class
