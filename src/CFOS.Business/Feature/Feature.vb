Imports CFOS.Data

Friend Class Feature
    Inherits WorldEntity(Of FeatureData)
    Implements IFeature

    Public Sub New(worldData As WorldData, featureId As Guid)
        MyBase.New(worldData)
        Me.FeatureId = featureId
    End Sub

    Public ReadOnly Property FeatureId As Guid Implements IFeature.FeatureId

    Protected Overrides ReadOnly Property EntityData As FeatureData
        Get
            Return worldData.Features(FeatureId)
        End Get
    End Property

    Public Sub Destroy() Implements IFeature.Destroy
        worldData.Features.Remove(FeatureId)
    End Sub

    Friend Shared Function Create(worldData As WorldData, featureId As Guid) As IFeature
        Return New Feature(worldData, featureId)
    End Function
End Class
