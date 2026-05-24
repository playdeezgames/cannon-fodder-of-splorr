Imports Spectre.Console
Imports TGGD.UI

Friend Class CFOSHostContext
    Implements IHostContext

    Public Sub OutputLine(text As String) Implements IHostContext.OutputLine
        AnsiConsole.MarkupLine(text)
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

    Public Function Choose(title As String, choices As IReadOnlyList(Of IDialogChoice)) As IDialog Implements IHostContext.Choose
        Dim prompt As New SelectionPrompt(Of IDialogChoice) With
            {
                .Title = $"[olive]{title}[/]",
                .Converter = Function(x) x.Text
            }
        prompt.AddChoices(choices)
        Return AnsiConsole.Prompt(prompt).NextDialog
    End Function
End Class
