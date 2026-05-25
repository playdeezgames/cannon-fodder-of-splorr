Imports CFOS.Model
Imports TGGD.UI

Friend Class SquadRecruitUnitTypeDialog
    Inherits BaseModelDialog(Of ISquadModel)

    Private ReadOnly unitTypeModel As IUnitTypeModel

    Private Sub New(context As IHostContext, model As ISquadModel, unitTypeModel As IUnitTypeModel)
        MyBase.New(context, model)
        Me.unitTypeModel = unitTypeModel
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As ISquadModel, unitTypeModel As IUnitTypeModel) As Func(Of IDialog)
        Return Function() New SquadRecruitUnitTypeDialog(context, model, unitTypeModel)
    End Function

    Public Overrides Function Run() As IDialog
        model.AddUnit(unitTypeModel)
        Return SquadRecruitDialog.Launch(context, model).Invoke()
    End Function
End Class
