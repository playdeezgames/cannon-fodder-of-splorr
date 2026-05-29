Imports TGGD.UI

Friend Class ConfirmDialog
    Inherits BaseDialog

    Private ReadOnly text As String
    Private ReadOnly onConfirm As Func(Of IDialog)
    Private ReadOnly onCancel As Func(Of IDialog)

    Private Sub New(
            context As IHostContext,
            text As String,
            onConfirm As Func(Of IDialog),
            onCancel As Func(Of IDialog))
        MyBase.New(context)
        Me.text = text
        Me.onConfirm = onConfirm
        Me.onCancel = onCancel
    End Sub

    Friend Shared Function Launch(
                                 context As IHostContext,
                                 text As String,
                                 onConfirm As Func(Of IDialog),
                                 onCancel As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New ConfirmDialog(context, text, onConfirm, onCancel)
    End Function

    Public Overrides Function Run() As IDialog
        Return context.Choose(
            text,
            DialogChoice.CreateEnabled("No", onCancel),
            DialogChoice.CreateEnabled("Yes", onConfirm))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, text, onConfirm, onCancel).Invoke()
    End Function
End Class
