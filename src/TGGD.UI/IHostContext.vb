Public Interface IHostContext
    Sub OutputLine(text As String)
    Sub Pause()
    Sub Clear()
    Function Choose(title As String, ParamArray choices As IDialogChoice()) As IDialog
    Function ReadString(text As String, Optional defaultValue As String = Nothing) As String
End Interface
