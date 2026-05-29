Imports CFOS.Model
Imports TGGD.UI

Friend Class UseControlPanelMenuDialog
    Inherits ExitableModelDialog(Of IFeatureModel)

    Private Sub New(context As IHostContext, model As IFeatureModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IFeatureModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New UseControlPanelMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        context.WriteLine("Yer using the control panel!")
        Return context.Choose(
            "Now What?",
            DialogChoice.Create(exitDialog IsNot Nothing, "Never Mind", exitDialog),
            DialogChoice.CreateEnabled(
                "Units...",
                FactionUnitsMenuDialog.Launch(context, model.FactionModel, Launch(context, model, exitDialog))),
            DialogChoice.CreateEnabled("Faction...", FactionMenuDialog.Launch(context, model.FactionModel.WorldModel, Launch(context, model, exitDialog))))
    End Function
End Class
