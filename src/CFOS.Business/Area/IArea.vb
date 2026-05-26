Public Interface IArea
    Inherits IWorldEntity
    Function GetLocation(column As Integer, row As Integer) As ILocation
    ReadOnly Property AreaId As Guid
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
End Interface
