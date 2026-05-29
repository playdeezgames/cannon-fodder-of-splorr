Public Interface IFactionModel
    ReadOnly Property UnitCount As Integer
    Sub AddUnit(unitTypeModel As IUnitTypeModel)
    ReadOnly Property WorldModel As IWorldModel
    ReadOnly Property CanRecruit As Boolean
    ReadOnly Property UnitModels As IEnumerable(Of IUnitModel)
End Interface
