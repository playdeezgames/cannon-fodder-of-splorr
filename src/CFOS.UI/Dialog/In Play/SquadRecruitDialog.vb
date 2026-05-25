Imports CFOS.Model
Imports TGGD.UI

Friend Class SquadRecruitDialog
    Inherits BaseModelDialog(Of ISquadModel)

    Private Sub New(context As IHostContext, model As ISquadModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As ISquadModel) As Func(Of IDialog)
        Return Function() New SquadRecruitDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        Dim choices = model.
            WorldModel.
            AvailableUnitTypes.
            Select(Function(x) DialogChoice.CreateEnabled(
                x.UnitTypeName,
                SquadRecruitUnitTypeDialog.Launch(context, model, x)))
        Return context.Choose("Recruit Whom:",
            choices.
            Append(DialogChoice.CreateEnabled("Never Mind", SquadMenuDialog.Launch(context, model))).ToArray)
    End Function
End Class
