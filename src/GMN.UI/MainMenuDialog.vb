Imports GMN.Model
Imports TGGD.UI

Friend Class MainMenuDialog
    Inherits ExitableModelDialog(Of IHostContext, IWorldModel)

    Private Sub New(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialog
        Return Context.Choose(
            "Main Menu:",
            ExitChoice)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function

    Friend Shared Function Launch(context As IHostContext, model As IWorldModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New MainMenuDialog(context, model, exitDialog)
    End Function

    Protected Overrides Function GetExitText() As String
        Return "Quit"
    End Function
End Class
