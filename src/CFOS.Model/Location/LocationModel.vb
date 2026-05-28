Imports CFOS.Business
Imports TGGD.Model

Friend Class LocationModel
    Inherits BaseModel
    Implements ILocationModel

    Private ReadOnly location As ILocation

    Private Sub New(location As ILocation)
        Me.location = location
    End Sub

    Public ReadOnly Property Column As Integer Implements ILocationModel.Column
        Get
            Return location.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements ILocationModel.Row
        Get
            Return location.Row
        End Get
    End Property
    Public ReadOnly Property FeatureModel As IFeatureModel Implements ILocationModel.FeatureModel
        Get
            If location.HasFeature Then
                Return CFOS.Model.FeatureModel.Create(location.Feature)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property UnitModel As IUnitModel Implements ILocationModel.UnitModel
        Get
            If location.HasUnit Then
                Return CFOS.Model.UnitModel.Create(location.Unit)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property LocationTypeModel As ILocationTypeModel Implements ILocationModel.LocationTypeModel
        Get
            Return CFOS.Model.LocationTypeModel.All(location.GetLocationType())
        End Get
    End Property

    Friend Shared Function Create(location As ILocation) As ILocationModel
        Return New LocationModel(location)
    End Function
End Class
