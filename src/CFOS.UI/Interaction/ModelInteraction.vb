Imports TGGD.UI

Friend MustInherit Class ModelInteraction(Of TModel)
    Friend Function ToDialogChoice(context As IHostContext, feature As TModel, exitDialog As Func(Of IDialog)) As IDialogChoice
        Return DialogChoice.Create(
            CanInteract(feature),
            MakeName(feature),
            MakeDialog(context, feature, exitDialog))
    End Function

    Protected MustOverride Function MakeDialog(context As IHostContext, model As TModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
    Protected MustOverride Function MakeName(model As TModel) As String
    Protected MustOverride Function CanInteract(model As TModel) As Boolean
End Class
