Imports TGGD.UI

Friend MustInherit Class BaseDialog
    Implements IDialog

    Protected ReadOnly context As IHostContext

    Sub New(context As IHostContext)
        Me.context = context
    End Sub

    Public MustOverride Function Run() As IDialog Implements IDialog.Run
End Class
