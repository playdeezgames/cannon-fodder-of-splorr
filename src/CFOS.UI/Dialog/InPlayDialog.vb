Imports CFOS.Model
Imports TGGD.UI

Friend Class InPlayDialog
    Inherits BaseModelDialog

    Private Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, worldModel As IWorldModel) As Func(Of IDialog)
        Return Function() New InPlayDialog(context, worldModel)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        context.OutputLine("Yer playing the game!")
        Return context.Choose(
            "Now What?",
            New List(Of IDialogChoice) From
            {
                New DialogChoice("Game Menu", GameMenuDialog.Launch(context, model))
            })
    End Function
End Class
