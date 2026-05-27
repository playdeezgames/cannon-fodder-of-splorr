Imports System.Text
Imports Spectre.Console
Imports TGGD.UI

Friend Class CFOSHostContext
    Implements IHostContext

    Private ReadOnly buffer As New StringBuilder

    Public Sub WriteLine(text As String) Implements IHostContext.WriteLine
        buffer.AppendLine(text)
    End Sub

    Private Sub Render()
        AnsiConsole.Clear()
        AnsiConsole.Markup(buffer.ToString())
        buffer.Clear()
    End Sub

    Public Sub Pause() Implements IHostContext.Pause
        Render()
        Dim prompt As New SelectionPrompt(Of String) With
            {
                .Title = String.Empty
            }
        prompt.AddChoice("Ok")
        AnsiConsole.Prompt(prompt)
    End Sub

    Public Sub Clear() Implements IHostContext.Clear
        buffer.Clear()
    End Sub

    Public Sub WriteString(text As String) Implements IHostContext.WriteString
        buffer.Append(text)
    End Sub

    Public Function Choose(title As String, ParamArray choices As IDialogChoice()) As IDialog Implements IHostContext.Choose
        Dim prompt As New SelectionPrompt(Of IDialogChoice) With
            {
                .Title = $"[olive]{title}[/]",
                .Converter = Function(x) x.Text
            }
        prompt.AddChoices(choices.Where(Function(x) x.Enabled))
        Render()
        Return AnsiConsole.Prompt(prompt).NextDialog
    End Function

    Public Function ReadString(text As String, Optional defaultValue As String = Nothing) As String Implements IHostContext.ReadString
        If defaultValue IsNot Nothing Then
            Return AnsiConsole.Ask(Of String)(text, defaultValue)
        End If
        Render()
        Return AnsiConsole.Ask(Of String)(text)
    End Function

    Public Function ReadKey() As String Implements IHostContext.ReadKey
        Render()
        Return Console.ReadKey(True).Key.ToString
    End Function
End Class
