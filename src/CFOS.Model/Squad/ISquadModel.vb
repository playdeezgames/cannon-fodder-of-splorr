Public Interface ISquadModel
    ReadOnly Property UnitCount As Integer
    Sub AddUnit(unitTypeModel As IUnitTypeModel)
    ReadOnly Property WorldModel As IWorldModel
End Interface
