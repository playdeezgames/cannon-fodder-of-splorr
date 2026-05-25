Imports CFOS.Model
Imports TGGD.UI

Friend Class GameMenuDialog
    Inherits BaseModelDialog(Of IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel) As Func(Of IDialog)
        Return Function() New GameMenuDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        Return context.Choose(
            "Game Menu:",
            DialogChoice.CreateEnabled(
                "Continue",
                Neutral.GetNextDialog(context, model)),
            DialogChoice.CreateEnabled(
                "Abandon Game",
                ConfirmDialog.Launch(
                    context,
                    "Are you sure you want to abandon?",
                    MainMenuDialog.Launch(context),
                    GameMenuDialog.Launch(context, model))))
    End Function
End Class
