Imports TGGD.Model

Public Interface ILocationModel
    Inherits IModel
    ReadOnly Property Text As String
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    ReadOnly Property LocationTypeName As String
    ReadOnly Property LocationTypeDescription As String
    ReadOnly Property FeatureModel As IFeatureModel
    ReadOnly Property UnitModel As IUnitModel
    ReadOnly Property LocationTypeModel As ILocationTypeModel
End Interface
