Imports TGGD.Model

Public Interface IAreaModel
    Inherits IModel
    ReadOnly Property WorldModel As IWorldModel
    ReadOnly Property Rows As Integer
    ReadOnly Property Columns As Integer
End Interface
