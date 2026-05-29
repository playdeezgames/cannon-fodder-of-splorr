Public MustInherit Class BaseModelDialog(Of TContext As IHostContext, TModel)
    Inherits BaseDialog(Of TContext)

    Protected ReadOnly Model As TModel

    Protected Sub New(context As TContext, model As TModel)
        MyBase.New(context)
        Me.Model = model
    End Sub
End Class
