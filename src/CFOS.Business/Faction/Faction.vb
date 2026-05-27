Imports CFOS.Data

Friend Class Faction
    Inherits WorldEntity(Of FactionData)
    Implements IFaction
    Private Sub New(worldData As WorldData, factionId As Guid)
        MyBase.New(worldData)
        Me.FactionId = factionId
    End Sub

    Friend Shared Function Create(worldData As WorldData, factionId As Guid) As IFaction
        Return New Faction(worldData, factionId)
    End Function

    Public Function CreateUnit(unitTypeId As String, location As ILocation) As IUnit Implements IFaction.CreateUnit
        Dim unitId = Guid.NewGuid
        worldData.Units(unitId) = New UnitData With
            {
                .UnitType = unitTypeId,
                .LocationId = location.LocationId,
                .FactionId = FactionId}
        EntityData.UnitIds.Add(unitId)
        Return Unit.Create(worldData, unitId)
    End Function
    Public ReadOnly Property FactionId As Guid Implements IFaction.FactionId

    Protected Overrides ReadOnly Property EntityData As FactionData
        Get
            Return worldData.Factions(FactionId)
        End Get
    End Property

    Public ReadOnly Property UnitCount As Integer Implements IFaction.UnitCount
        Get
            Return EntityData.UnitIds.Count
        End Get
    End Property

    Public Property Cradle As IArea Implements IFaction.Cradle
        Get
            With EntityData
                If .CradleAreaId.HasValue Then
                    Return Area.Create(worldData, .CradleAreaId.Value)
                Else
                    Return Nothing
                End If
            End With
        End Get
        Set(value As IArea)
            EntityData.CradleAreaId = value?.AreaId
        End Set
    End Property
End Class
