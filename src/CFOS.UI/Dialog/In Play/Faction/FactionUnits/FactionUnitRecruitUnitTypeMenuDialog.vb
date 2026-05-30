Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitRecruitUnitTypeMenuDialog
    Inherits ExitableModelDialog(Of IHostContext, IFactionModel)

    Private ReadOnly unitTypeModel As IUnitTypeModel

    Private Sub New(context As IHostContext, model As IFactionModel, unitTypeModel As IUnitTypeModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
        Me.unitTypeModel = unitTypeModel
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IFactionModel, unitTypeModel As IUnitTypeModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New FactionUnitRecruitUnitTypeMenuDialog(context, model, unitTypeModel, exitDialog)
    End Function

    Public Overrides Function Run() As IDialog
        Model.AddUnit(unitTypeModel)
        Return ExitDialog.Invoke()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, unitTypeModel, ExitDialog).Invoke
    End Function
End Class
