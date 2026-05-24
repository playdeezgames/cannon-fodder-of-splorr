Imports TGGD.UI

Friend Class MainMenuDialog
    Inherits BaseDialog

    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub

    Public Overrides Function Run() As IDialog
        context.Clear()
        Return context.Choose(
            "Main Menu:",
            New List(Of IDialogChoice) From
            {
                New DialogChoice("Embark!", EmbarkDialog.Launch(context)),
                New DialogChoice(
                    "Quit",
                    ConfirmDialog.Launch(
                        context,
                        "Are you sure you want to quit?",
                        Function() Nothing,
                        MainMenuDialog.Launch(context)))
            })
    End Function

    Friend Shared Function Launch(
                                 context As IHostContext) As Func(Of IDialog)
        Return Function() New MainMenuDialog(context)
    End Function
End Class
