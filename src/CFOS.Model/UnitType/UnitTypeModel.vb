Friend Class UnitTypeModel
    Implements IUnitTypeModel

    Private Sub New(unitTypeId As String, unitTypeName As String, text As String)
        Me.UnitTypeId = unitTypeId
        Me.UnitTypeName = unitTypeName
        Me.Text = text
    End Sub

    Public ReadOnly Property UnitTypeName As String Implements IUnitTypeModel.UnitTypeName
    Public ReadOnly Property UnitTypeId As String Implements IUnitTypeModel.UnitTypeId
    Public ReadOnly Property Text As String Implements IUnitTypeModel.Text

    Friend Shared ReadOnly All As IReadOnlyDictionary(Of String, IUnitTypeModel) =
        New List(Of IUnitTypeModel) From
        {
            New UnitTypeModel(UnitTypes.MOOK, "Mook", "m")
        }.ToDictionary(Function(x) x.UnitTypeId, Function(x) x)
End Class
