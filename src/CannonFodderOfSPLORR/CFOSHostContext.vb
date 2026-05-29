Imports Spectre.Console
Imports TGGD.UI

Friend Class CFOSHostContext
    Implements IHostContext

    Public Sub WriteLine(text As String) Implements IHostContext.WriteLine
        AnsiConsole.WriteLine(text)
    End Sub

    Public Sub Pause() Implements IHostContext.Pause
        Dim prompt As New SelectionPrompt(Of String) With
            {
                .Title = String.Empty
            }
        prompt.AddChoice("Ok")
        AnsiConsole.Prompt(prompt)
    End Sub

    Public Sub Clear() Implements IHostContext.Clear
        AnsiConsole.Clear()
    End Sub

    Public Sub WriteString(text As String) Implements IHostContext.WriteString
        AnsiConsole.Markup(text)
    End Sub

    Public Function Choose(title As String, ParamArray choices As IDialogChoice()) As IDialog Implements IHostContext.Choose
        Dim prompt As New SelectionPrompt(Of IDialogChoice) With
            {
                .Title = $"[olive]{title}[/]",
                .Converter = Function(x) x.Text
            }
        prompt.AddChoices(choices.Where(Function(x) x.Enabled))
        Return AnsiConsole.Prompt(prompt).NextDialog
    End Function

    Public Function ReadString(text As String, Optional defaultValue As String = Nothing) As String Implements IHostContext.ReadString
        If defaultValue IsNot Nothing Then
            Return AnsiConsole.Ask(Of String)(text, defaultValue)
        End If
        Return AnsiConsole.Ask(Of String)(text)
    End Function

    Public Function ReadKey() As String Implements IHostContext.ReadKey
        Return Console.ReadKey(True).Key.ToString
    End Function
End Class
