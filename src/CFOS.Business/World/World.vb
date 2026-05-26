Imports CFOS.Data
Imports TGGD.Business

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld

    Private ReadOnly worldData As WorldData

    Private Sub New(worldData As WorldData)
        Me.worldData = worldData
    End Sub

    Public Property Player As IFaction Implements IWorld.Player
        Get
            Dim factionId = worldData.PlayerFactionId
            If factionId.HasValue Then
                Return Faction.Create(worldData, factionId.Value)
            End If
            Return Nothing
        End Get
        Set(value As IFaction)
            worldData.PlayerFactionId = value?.FactionId
        End Set
    End Property

    Protected Overrides ReadOnly Property EntityData As WorldData
        Get
            Return worldData
        End Get
    End Property

    Public Shared Function Create(worldData As WorldData) As IWorld
        Return New World(worldData)
    End Function

    Public Function CreateFaction() As IFaction Implements IWorld.CreateFaction
        Dim factionId = Guid.NewGuid
        EntityData.Factions(factionId) = New FactionData
        Return Faction.Create(worldData, factionId)
    End Function

    Public Function CreateArea(columns As Integer, rows As Integer) As IArea Implements IWorld.CreateArea
        Dim areaId = Guid.NewGuid
        worldData.Areas(areaId) = New AreaData With
            {
                .Columns = columns,
                .Rows = rows,
                .LocationIds = Enumerable.Range(0, rows).SelectMany(Function(row) Enumerable.Range(0, columns).Select(Function(column) CreateLocation(areaId, column, row))).ToList
            }
        Return Area.Create(worldData, areaId)
    End Function

    Private Function CreateLocation(areaId As Guid, column As Integer, row As Integer) As Guid
        Dim locationId = Guid.NewGuid
        worldData.Locations(locationId) = New LocationData With
            {
                .AreaId = areaId,
                .Column = column,
                .Row = row
            }
        Return locationId
    End Function
End Class
