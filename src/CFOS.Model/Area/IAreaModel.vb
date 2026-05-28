Imports TGGD.Model

Public Interface IAreaModel
    Inherits IModel
    ReadOnly Property WorldModel As IWorldModel
    ReadOnly Property Rows As Integer
    ReadOnly Property Columns As Integer
    Function GetLocationModel(column As Integer, row As Integer) As ILocationModel
    ReadOnly Property AreaTypeModel As IAreaTypeModel
End Interface
