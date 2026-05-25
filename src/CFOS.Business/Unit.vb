Imports CFOS.Data
Imports TGGD.Business

Friend Class Unit
    Inherits Entity(Of UnitData)
    Implements IUnit

    Private ReadOnly worldData As WorldData
    Private ReadOnly factionId As Guid
    Private ReadOnly unitId As Integer

    Private Sub New(worldData As WorldData, factionId As Guid, unitId As Integer)
        Me.worldData = worldData
        Me.factionId = factionId
        Me.unitId = unitId
    End Sub

    Public ReadOnly Property UnitType As String Implements IUnit.UnitType
        Get
            Return EntityData.UnitType
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As UnitData
        Get
            Return worldData.Factions(factionId).Units(unitId)
        End Get
    End Property

    Private ReadOnly Property IUnit_UnitId As Integer Implements IUnit.UnitId
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Friend Shared Function Create(worldData As WorldData, factionId As Guid, unitId As Integer) As IUnit
        Return New Unit(worldData, factionId, unitId)
    End Function
End Class
