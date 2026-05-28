Imports CFOS.Data

Friend Class Location
    Inherits WorldEntity(Of LocationData)
    Implements ILocation

    Public Sub New(worldData As WorldData, locationId As Guid)
        MyBase.New(worldData)
        Me.LocationId = locationId
    End Sub

    Public ReadOnly Property Area As IArea Implements ILocation.Area
        Get
            Return CFOS.Business.Area.Create(worldData, EntityData.AreaId)
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As LocationData
        Get
            Return worldData.Locations(LocationId)
        End Get
    End Property

    Public ReadOnly Property HasFeature As Boolean Implements ILocation.HasFeature
        Get
            Return EntityData.FeatureId.HasValue
        End Get
    End Property

    Public ReadOnly Property Feature As IFeature Implements ILocation.Feature
        Get
            Return If(
                EntityData.FeatureId.HasValue,
                CFOS.Business.Feature.Create(worldData, EntityData.FeatureId.Value),
                Nothing)
        End Get
    End Property

    Public ReadOnly Property LocationId As Guid Implements ILocation.LocationId

    Public ReadOnly Property Column As Integer Implements ILocation.Column
        Get
            Return EntityData.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements ILocation.Row
        Get
            Return EntityData.Row
        End Get
    End Property

    Public ReadOnly Property HasUnit As Boolean Implements ILocation.HasUnit
        Get
            Return EntityData.UnitId.HasValue
        End Get
    End Property

    Public Property Unit As IUnit Implements ILocation.Unit
        Get
            Return If(
                EntityData.UnitId.HasValue,
                CFOS.Business.Unit.Create(worldData, EntityData.UnitId.Value),
                Nothing)
        End Get
        Set(value As IUnit)
            EntityData.UnitId = value?.UnitId
        End Set
    End Property

    Friend Shared Function Create(worldData As WorldData, locationId As Guid) As ILocation
        Return New Location(worldData, locationId)
    End Function

    Public Function CreateFeature() As IFeature Implements ILocation.CreateFeature
        If HasFeature Then
            Feature.Destroy()
        End If
        Dim featureId = Guid.NewGuid
        EntityData.FeatureId = featureId
        worldData.Features(featureId) = New FeatureData With {.LocationId = LocationId}
        Return CFOS.Business.Feature.Create(worldData, featureId)
    End Function
End Class
