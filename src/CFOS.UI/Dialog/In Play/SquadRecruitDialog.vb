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
        Return context.Choose("Recruit Whom:",
            DialogChoice.CreateEnabled("Never Mind", SquadMenuDialog.Launch(context, model)))
    End Function
End Class
