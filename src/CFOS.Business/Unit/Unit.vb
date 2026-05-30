Imports CFOS.Data

Friend Class Unit
    Inherits WorldEntity(Of UnitData)
    Implements IUnit

    Private Sub New(worldData As WorldData, unitId As Guid)
        MyBase.New(worldData)
        Me.UnitId = unitId
    End Sub

    Public ReadOnly Property UnitId As Guid Implements IUnit.UnitId

    Public ReadOnly Property Faction As IFaction Implements IUnit.Faction
        Get
            Return CFOS.Business.Faction.Create(worldData, EntityData.FactionId)
        End Get
    End Property

    Public ReadOnly Property Location As ILocation Implements IUnit.Location
        Get
            Return CFOS.Business.Location.Create(worldData, EntityData.LocationId)
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As UnitData
        Get
            Return worldData.Units(UnitId)
        End Get
    End Property

    Public Sub Disband() Implements IUnit.Disband
        Me.Faction.RemoveUnit(Me)
        Me.Location.Unit = Nothing
        worldData.Units.Remove(UnitId)
    End Sub

    Friend Shared Function Create(worldData As WorldData, unitId As Guid) As IUnit
        Return New Unit(worldData, unitId)
    End Function
End Class
