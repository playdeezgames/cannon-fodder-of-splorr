Imports CFOS.Model
Imports TGGD.UI

Friend MustInherit Class BaseModelDialog
    Inherits BaseDialog

    Protected ReadOnly model As IWorldModel

    Public Sub New(context As IHostContext, model As IWorldModel)
        MyBase.New(context)
        Me.model = model
    End Sub
End Class
