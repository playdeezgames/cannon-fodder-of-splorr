Imports CFOS.Data
Imports TGGD.Business

Friend Class Faction
    Inherits Entity(Of FactionData)
    Implements IFaction
    Private Sub New(worldData As WorldData, factionId As Guid)
        Me.worldData = worldData
        Me.FactionId = factionId
    End Sub

    Friend Shared Function Create(worldData As WorldData, factionId As Guid) As IFaction
        Return New Faction(worldData, factionId)
    End Function

    Public Function CreateUnit(unitTypeId As String) As IUnit Implements IFaction.CreateUnit
        Dim unitId = EntityData.Units.Count
        EntityData.Units.Add(New UnitData With {.UnitType = unitTypeId})
        Return Unit.Create(worldData, FactionId, unitId)
    End Function

    Private ReadOnly worldData As WorldData
    Public ReadOnly Property FactionId As Guid Implements IFaction.FactionId

    Protected Overrides ReadOnly Property EntityData As FactionData
        Get
            Return worldData.Factions(FactionId)
        End Get
    End Property

    Public ReadOnly Property World As IWorld Implements IFaction.World
        Get
            Return CFOS.Business.World.Create(worldData)
        End Get
    End Property

    Public ReadOnly Property UnitCount As Integer Implements IFaction.UnitCount
        Get
            Return EntityData.Units.Count
        End Get
    End Property
End Class
