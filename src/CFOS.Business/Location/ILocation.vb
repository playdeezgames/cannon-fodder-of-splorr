Public Interface ILocation
    Inherits IWorldEntity
    ReadOnly Property LocationId As Guid
    ReadOnly Property Area As IArea
    Function CreateFeature() As IFeature
    ReadOnly Property HasFeature As Boolean
    ReadOnly Property Feature As IFeature
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    ReadOnly Property HasUnit As Boolean
End Interface
