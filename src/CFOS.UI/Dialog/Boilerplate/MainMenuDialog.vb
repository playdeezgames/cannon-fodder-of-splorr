Imports TGGD.UI

Friend Class MainMenuDialog
    Inherits BaseDialog(Of IHostContext)

    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub

    Public Overrides Function Run() As IDialog
        Context.Clear()
        Return Context.Choose(
            "Main Menu:",
            DialogChoice.CreateEnabled("Embark!", EmbarkDialog.Launch(Context)),
            DialogChoice.CreateEnabled(
                "Quit",
                ConfirmDialog.Launch(
                    Context,
                    "Are you sure you want to quit?",
                    Function() Nothing,
                    MainMenuDialog.Launch(Context))))
    End Function

    Friend Shared Function Launch(
                                 context As IHostContext) As Func(Of IDialog)
        Return Function() New MainMenuDialog(context)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context).Invoke()
    End Function
End Class
