Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitRecruitMenuDialog
    Inherits BaseModelDialog(Of IFactionModel)

    Private Sub New(context As IHostContext, model As IFactionModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IFactionModel) As Func(Of IDialog)
        Return Function() New FactionUnitRecruitMenuDialog(context, model)
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
            {DialogChoice.CreateEnabled("Never Mind", FactionUnitsMenuDialog.Launch(context, model))}.
            Concat(choices).ToArray)
    End Function
End Class
