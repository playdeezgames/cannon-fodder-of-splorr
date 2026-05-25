Imports TGGD.Model

Public Interface IWorldModel
    Inherits IModel
    Property FactionName As String
    ReadOnly Property Squad As ISquadModel
    ReadOnly Property AvailableUnitTypes As IEnumerable(Of IUnitTypeModel)
End Interface
