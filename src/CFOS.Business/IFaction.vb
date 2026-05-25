Imports TGGD.Business

Public Interface IFaction
    Inherits IEntity
    ReadOnly Property FactionId As Guid
    ReadOnly Property World As IWorld
    Function CreateUnit(unitTypeId As String) As IUnit
    ReadOnly Property UnitCount As Integer
End Interface
