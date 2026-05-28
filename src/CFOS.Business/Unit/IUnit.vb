Public Interface IUnit
    Inherits IWorldEntity
    ReadOnly Property UnitId As Guid
    ReadOnly Property Faction As IFaction
End Interface
