Imports CFOS.Model
Imports TGGD.UI

Friend Class UseControlPanelMenuDialog
    Inherits ExitableModelDialog(Of IHostContext, IFeatureModel)

    Private Sub New(context As IHostContext, model As IFeatureModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IFeatureModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New UseControlPanelMenuDialog(context, model, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        Context.WriteLine("Yer using the control panel!")
        Return Context.Choose(
            "Now What?",
            ExitChoice,
            DialogChoice.CreateEnabled(
                "Units...",
                FactionUnitsMenuDialog.Launch(Context, Model.FactionModel, AddressOf Relaunch)),
            DialogChoice.CreateEnabled(
                "Faction...",
                FactionMenuDialog.Launch(Context, Model.FactionModel.WorldModel, AddressOf Relaunch)))
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, EditDialog).Invoke
    End Function
End Class
