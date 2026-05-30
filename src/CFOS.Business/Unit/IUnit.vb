Public Interface IUnit
    Inherits IWorldEntity
    ReadOnly Property UnitId As Guid
    ReadOnly Property Faction As IFaction
    Sub Disband()
    ReadOnly Property Location As ILocation
End Interface
