Public Interface ILocation
    Inherits IWorldEntity
    ReadOnly Property LocationId As Guid
    ReadOnly Property Area As IArea
    Function CreateFeature() As IFeature
    ReadOnly Property HasFeature As Boolean
    ReadOnly Property Feature As IFeature
End Interface
