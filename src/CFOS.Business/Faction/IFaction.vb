Public Interface IFaction
    Inherits IWorldEntity
    ReadOnly Property FactionId As Guid
    Function CreateUnit(location As ILocation) As IUnit
    ReadOnly Property UnitCount As Integer
    Property Cradle As IArea
    ReadOnly Property Units As IEnumerable(Of IUnit)
    Sub RemoveUnit(unit As IUnit)
End Interface
