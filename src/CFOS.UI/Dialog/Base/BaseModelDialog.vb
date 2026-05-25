Imports TGGD.UI

Friend MustInherit Class BaseModelDialog(Of TModel)
    Inherits BaseDialog

    Protected ReadOnly model As TModel

    Public Sub New(context As IHostContext, model As TModel)
        MyBase.New(context)
        Me.model = model
    End Sub
End Class
