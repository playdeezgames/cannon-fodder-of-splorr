Imports TGGD.UI

Friend Class TitleDialog
    Inherits BaseDialog

    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub

    Public Overrides Function Run() As IDialog
        context.WriteLine("Welcome to:")
        context.WriteLine("Cannon Fodder of SPLORR!!")
        context.WriteLine("A production of TheGrumpyGameDev")
        context.Pause()
        Return MainMenuDialog.Launch(context).Invoke()
    End Function

    Friend Shared Function Launch(context As IHostContext) As Func(Of IDialog)
        Return Function() New TitleDialog(context)
    End Function
End Class
