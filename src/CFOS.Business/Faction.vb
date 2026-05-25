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

    Private ReadOnly worldData As WorldData
    Public ReadOnly Property FactionId As Guid Implements IFaction.FactionId

    Protected Overrides ReadOnly Property EntityData As FactionData
        Get
            Return worldData.Factions(FactionId)
        End Get
    End Property
End Class
