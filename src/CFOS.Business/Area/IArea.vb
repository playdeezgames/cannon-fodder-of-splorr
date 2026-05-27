Public Interface IArea
    Inherits IWorldEntity
    Function GetLocation(column As Integer, row As Integer) As ILocation
    ReadOnly Property AreaId As Guid
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
    ReadOnly Property Locations As IEnumerable(Of ILocation)
End Interface
