Public MustInherit Class ExitableModelDialog(Of TContext As IHostContext, TModel)
    Inherits BaseModelDialog(Of TContext, TModel)

    Protected ReadOnly EditDialog As Func(Of IDialog)

    Protected Sub New(
                     context As TContext,
                     model As TModel,
                     exitDialog As Func(Of IDialog))
        MyBase.New(context, model)
        Me.EditDialog = exitDialog
    End Sub
    Protected ReadOnly Property ExitChoice As IDialogChoice
        Get
            Return DialogChoice.Create(EditDialog IsNot Nothing, GetExitText(), EditDialog)
        End Get
    End Property

    Protected Overridable Function GetExitText() As String
        Return "Never Mind"
    End Function
End Class
