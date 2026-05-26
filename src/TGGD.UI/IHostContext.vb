Public Interface IHostContext
    Sub WriteLine(text As String)
    Sub WriteString(text As String)
    Sub Pause()
    Sub Clear()
    Function Choose(title As String, ParamArray choices As IDialogChoice()) As IDialog
    Function ReadString(text As String, Optional defaultValue As String = Nothing) As String
    Function ReadKey() As String
End Interface
