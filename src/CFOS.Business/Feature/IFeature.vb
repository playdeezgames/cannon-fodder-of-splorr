Public Interface IFeature
    Inherits IWorldEntity
    ReadOnly Property FeatureId As Guid
    Sub Destroy()
End Interface
