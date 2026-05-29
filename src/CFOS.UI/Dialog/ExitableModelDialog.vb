Imports TGGD.UI

Friend MustInherit Class ExitableModelDialog(Of TModel)
    Inherits BaseModelDialog(Of TModel)

    Protected ReadOnly exitDialog As Func(Of IDialog)

    Protected Sub New(context As IHostContext, model As TModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model)
        Me.exitDialog = exitDialog
    End Sub
End Class
