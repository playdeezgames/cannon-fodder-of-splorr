Imports CFOS.Data

Friend Class Unit
    Inherits WorldEntity(Of UnitData)
    Implements IUnit

    Private Sub New(worldData As WorldData, unitId As Guid)
        MyBase.New(worldData)
        Me.UnitId = unitId
    End Sub

    Public ReadOnly Property UnitType As String Implements IUnit.UnitType
        Get
            Return EntityData.UnitType
        End Get
    End Property

    Public ReadOnly Property UnitId As Guid Implements IUnit.UnitId

    Protected Overrides ReadOnly Property EntityData As UnitData
        Get
            Return worldData.Units(UnitId)
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, unitId As Guid) As IUnit
        Return New Unit(worldData, unitId)
    End Function
End Class
