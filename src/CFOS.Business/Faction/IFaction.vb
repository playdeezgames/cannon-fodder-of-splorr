Public Interface IFaction
    Inherits IWorldEntity
    ReadOnly Property FactionId As Guid
    Function CreateUnit(unitTypeId As String) As IUnit
    ReadOnly Property UnitCount As Integer
    Property Cradle As IArea
End Interface
