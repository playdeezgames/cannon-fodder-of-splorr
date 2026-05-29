Imports CFOS.Model
Imports TGGD.UI

Friend Class FactionUnitRecruitUnitTypeMenuDialog
    Inherits BaseModelDialog(Of IFactionModel)

    Private ReadOnly unitTypeModel As IUnitTypeModel

    Private Sub New(context As IHostContext, model As IFactionModel, unitTypeModel As IUnitTypeModel)
        MyBase.New(context, model)
        Me.unitTypeModel = unitTypeModel
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IFactionModel, unitTypeModel As IUnitTypeModel) As Func(Of IDialog)
        Return Function() New FactionUnitRecruitUnitTypeMenuDialog(context, model, unitTypeModel)
    End Function

    Public Overrides Function Run() As IDialog
        model.AddUnit(unitTypeModel)
        Return FactionUnitsMenuDialog.Launch(context, model, Launch(context, model, unitTypeModel)).Invoke()
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, model, unitTypeModel).Invoke
    End Function
End Class
