Imports CFOS.Model
Imports TGGD.UI

Friend Class SquadMenuDialog
    Inherits BaseModelDialog(Of ISquadModel)
    Private Sub New(context As IHostContext, model As ISquadModel)
        MyBase.New(context, model)
    End Sub
    Friend Shared Function Launch(context As IHostContext, model As ISquadModel) As Func(Of IDialog)
        Return Function() New SquadMenuDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        Dim choices =
            {
            DialogChoice.CreateEnabled("Never Mind", Neutral.GetNextDialog(context, model.WorldModel)),
            DialogChoice.Create(model.CanRecruit, "Recruit...", SquadRecruitMenuDialog.Launch(context, model))
            }.Concat(model.UnitModels.Select(Function(x) DialogChoice.Create(True, x.GetName(), SquadDetailDialog.Launch(context, x))))
        Return context.Choose(
            "Squad Menu:",
            choices.ToArray)
    End Function
End Class
