Imports TGGD.Model

Public Interface IFeatureModel
    Inherits IModel
    ReadOnly Property Text As String
    ReadOnly Property FeatureTypeName As String
End Interface
