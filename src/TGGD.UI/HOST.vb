Public MustInherit Class Host
    Implements IHost

    Protected ReadOnly context As IHostContext

    Protected Sub New(context As IHostContext)
        Me.context = context
    End Sub
    Public MustOverride Sub Run() Implements IHost.Run
End Class
