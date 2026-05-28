Imports TGGD.Model

Public Interface IUnitModel
    Inherits IModel
    ReadOnly Property UnitTypeModel As IUnitTypeModel
    ReadOnly Property SquadModel As ISquadModel
End Interface
