Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitRecruitMenuDialog
    Inherits ExitableModelDialog(Of IFactionModel)

    Private Sub New(context As IHostContext, model As IFactionModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IFactionModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New FactionUnitRecruitMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        Dim choices = model.
            WorldModel.
            AvailableUnitTypes.
            Select(Function(x) DialogChoice.CreateEnabled(
                x.UnitTypeName,
                FactionUnitRecruitUnitTypeMenuDialog.Launch(context, model, x)))
        Return context.Choose("Recruit Whom:",
            {
                DialogChoice.CreateEnabled(
                    "Never Mind",
                    FactionUnitsMenuDialog.Launch(context, model, Launch(context, model, exitDialog)))
            }.
            Concat(choices).ToArray)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, model, exitDialog).Invoke
    End Function
End Class
