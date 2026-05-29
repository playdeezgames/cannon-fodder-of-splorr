Imports TGGD.Model

Public Interface IWorldModel
    Inherits IModel
    Property FactionName As String
    ReadOnly Property FactionModel As IFactionModel
    ReadOnly Property AvailableUnitTypes As IEnumerable(Of IUnitTypeModel)
    ReadOnly Property CradleAreaModel As IAreaModel
End Interface
