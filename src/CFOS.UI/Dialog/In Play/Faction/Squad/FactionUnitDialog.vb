Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitDialog
    Inherits BaseModelDialog(Of IUnitModel)

    Private Sub New(context As IHostContext, model As IUnitModel)
        MyBase.New(context, model)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IUnitModel) As Func(Of IDialog)
        Return Function() New FactionUnitDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        context.WriteLine($"Unit: {model.GetName()}")
        Return context.Choose(
            "Now What?",
            DialogChoice.CreateEnabled("Never Mind", FactionUnitsMenuDialog.Launch(context, model.FactionModel, Launch(context, model))))
    End Function
End Class
