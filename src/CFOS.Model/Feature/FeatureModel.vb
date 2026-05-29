Imports CFOS.Business
Imports TGGD.Model

Friend Class FeatureModel
    Inherits BaseModel(Of IFeature)
    Implements IFeatureModel

    Private Sub New(feature As IFeature)
        MyBase.New(feature)
    End Sub

    Public ReadOnly Property FeatureTypeModel As IFeatureTypeModel Implements IFeatureModel.FeatureTypeModel
        Get
            Return CFOS.Model.FeatureTypeModel.All(Entity.GetFeatureType())
        End Get
    End Property

    Public ReadOnly Property FactionModel As IFactionModel Implements IFeatureModel.FactionModel
        Get
            Return CFOS.Model.FactionModel.Create(Entity.World.Player)
        End Get
    End Property

    Friend Shared Function Create(feature As IFeature) As IFeatureModel
        Return New FeatureModel(feature)
    End Function
End Class
