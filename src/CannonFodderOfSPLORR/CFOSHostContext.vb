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
End Class
