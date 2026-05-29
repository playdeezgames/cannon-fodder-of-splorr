Imports CFOS.Model
Imports TGGD.UI

Friend Class GameMenuDialog
    Inherits ExitableModelDialog(Of IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New GameMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        Return context.Choose(
            "Game Menu:",
            NeverMindChoice,
            DialogChoice.CreateEnabled(
                "Abandon Game",
                ConfirmDialog.Launch(
                    context,
                    "Are you sure you want to abandon?",
                    MainMenuDialog.Launch(context),
                    AddressOf Relaunch)))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, model, exitDialog).Invoke()
    End Function
End Class
