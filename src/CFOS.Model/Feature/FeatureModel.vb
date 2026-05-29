Imports CFOS.Business
Imports TGGD.Model

Friend Class FeatureModel
    Inherits BaseModel
    Implements IFeatureModel

    Private ReadOnly feature As IFeature

    Private Sub New(feature As IFeature)
        Me.feature = feature
    End Sub

    Public ReadOnly Property FeatureTypeModel As IFeatureTypeModel Implements IFeatureModel.FeatureTypeModel
        Get
            Return CFOS.Model.FeatureTypeModel.All(feature.GetFeatureType())
        End Get
    End Property

    Public ReadOnly Property FactionModel As IFactionModel Implements IFeatureModel.FactionModel
        Get
            Return CFOS.Model.FactionModel.Create(feature.World.Player)
        End Get
    End Property

    Friend Shared Function Create(feature As IFeature) As IFeatureModel
        Return New FeatureModel(feature)
    End Function
End Class
