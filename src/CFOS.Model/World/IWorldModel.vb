Imports TGGD.Model

Public Interface IWorldModel
    Inherits IModel
    Property FactionName As String
    ReadOnly Property Squad As ISquadModel
End Interface
