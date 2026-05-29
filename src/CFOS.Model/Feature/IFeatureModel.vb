Imports TGGD.Model

Public Interface IFeatureModel
    Inherits IModel
    ReadOnly Property FeatureTypeModel As IFeatureTypeModel
    ReadOnly Property FactionModel As IFactionModel
End Interface
