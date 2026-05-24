Public Class DialogChoice
    Implements IDialogChoice
    Sub New(text As String, nextDialogGenerator As Func(Of IDialog))
        Me.Text = text
        Me.nextDialogGenerator = nextDialogGenerator
    End Sub

    Public ReadOnly Property Text As String Implements IDialogChoice.Text
    Private ReadOnly nextDialogGenerator As Func(Of IDialog)

    Public ReadOnly Property NextDialog As IDialog Implements IDialogChoice.NextDialog
        Get
            Return nextDialogGenerator.Invoke()
        End Get
    End Property
End Class
