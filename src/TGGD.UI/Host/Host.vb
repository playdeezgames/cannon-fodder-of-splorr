Public MustInherit Class Host
    Implements IHost

    Protected ReadOnly context As IHostContext

    Protected Sub New(context As IHostContext)
        Me.context = context
    End Sub

    Public MustOverride Function Run() As IDialog Implements IDialog.Run
End Class
