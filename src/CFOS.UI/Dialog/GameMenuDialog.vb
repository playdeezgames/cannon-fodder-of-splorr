Imports CFOS.Model
Imports TGGD.UI

Friend Class GameMenuDialog
    Inherits BaseModelDialog

    Private Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel) As Func(Of IDialog)
        Return Function() New GameMenuDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        Return context.Choose(
            "Game Menu:",
            New List(Of IDialogChoice) From
            {
                New DialogChoice(
                    "Continue",
                    Neutral.GetNextDialog(context, model)),
                New DialogChoice(
                    "Abandon Game",
                    ConfirmDialog.Launch(
                        context,
                        "Are you sure you want to abandon?",
                        MainMenuDialog.Launch(context),
                        GameMenuDialog.Launch(context, model)))
            })
    End Function
End Class
