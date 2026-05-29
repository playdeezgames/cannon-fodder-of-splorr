Imports TGGD.Model

Public Interface IFactionModel
    Inherits IModel
    ReadOnly Property UnitCount As Integer
    Sub AddUnit(unitTypeModel As IUnitTypeModel)
    ReadOnly Property WorldModel As IWorldModel
    ReadOnly Property CanRecruit As Boolean
    ReadOnly Property UnitModels As IEnumerable(Of IUnitModel)
End Interface
