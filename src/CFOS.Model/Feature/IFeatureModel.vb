Imports TGGD.Model

Public Interface IFeatureModel
    Inherits IModel
    ReadOnly Property Text As String
    ReadOnly Property FeatureTypeName As String
    ReadOnly Property FeatureTypeModel As IFeatureTypeModel
End Interface
