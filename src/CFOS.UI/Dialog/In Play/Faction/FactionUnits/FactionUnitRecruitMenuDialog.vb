Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitRecruitMenuDialog
    Inherits ExitableModelDialog(Of IHostContext, IFactionModel)

    Private Sub New(context As IHostContext, model As IFactionModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IFactionModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New FactionUnitRecruitMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        Context.Clear()
        Dim choices = Model.
            WorldModel.
            AvailableUnitTypes.
            Select(Function(x) DialogChoice.CreateEnabled(
                x.UnitTypeName,
                FactionUnitRecruitUnitTypeMenuDialog.Launch(Context, Model, x, ExitDialog)))
        Return Context.Choose("Recruit Whom:",
            {
                ExitChoice
            }.
            Concat(choices).ToArray)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function
End Class
