Public Interface IHostContext
    Sub OutputLine(text As String)
    Sub Pause()
    Sub Clear()
    Function Choose(title As String, choices As IReadOnlyList(Of IDialogChoice)) As IDialog
End Interface
