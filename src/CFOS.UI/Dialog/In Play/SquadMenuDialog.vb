Imports CFOS.Model
Imports TGGD.UI

Friend Class SquadMenuDialog
    Inherits BaseModelDialog
    Private Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context, model)
    End Sub
    Friend Shared Function Launch(context As IHostContext, model As IWorldModel) As Func(Of IDialog)
        Return Function() New SquadMenuDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()

        Return context.Choose(
            "Squad Menu:",
            DialogChoice.CreateEnabled("Never Mind", Neutral.GetNextDialog(context, model)))
    End Function
End Class
