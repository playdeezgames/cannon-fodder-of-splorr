Friend Class UnitTypeModel
    Implements IUnitTypeModel

    Private Sub New(unitTypeId As String, unitTypeName As String)
        Me.UnitTypeId = unitTypeId
        Me.UnitTypeName = unitTypeName
    End Sub

    Public ReadOnly Property UnitTypeName As String Implements IUnitTypeModel.UnitTypeName
    Public ReadOnly Property UnitTypeId As String Implements IUnitTypeModel.UnitTypeId

    Friend Shared ReadOnly All As IReadOnlyDictionary(Of String, IUnitTypeModel) =
        New List(Of IUnitTypeModel) From
        {
            New UnitTypeModel(UnitTypes.MOOK, "Mook")
        }.ToDictionary(Function(x) x.UnitTypeId, Function(x) x)
End Class
