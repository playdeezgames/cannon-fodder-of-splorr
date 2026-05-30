Imports TGGD.UI

Friend Class TitleDialog
    Inherits BaseDialog(Of IHostContext)

    Private Sub New(context As IHostContext)
        MyBase.New(context)
    End Sub

    Public Overrides Function Run() As IDialog
        Context.WriteLine("Welcome to:")
        Context.WriteFiglet("Cannon Fodder of SPLORR!!", "fuchsia")
        Context.WriteLine("A production of TheGrumpyGameDev")
        Context.Pause()
        Return MainMenuDialog.Launch(Context).Invoke()
    End Function

    Friend Shared Function Launch(context As IHostContext) As Func(Of IDialog)
        Return Function() New TitleDialog(context)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context).Invoke
    End Function
End Class
