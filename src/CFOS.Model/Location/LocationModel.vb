Imports CFOS.Business
Imports TGGD.Model

Friend Class LocationModel
    Inherits BaseModel(Of ILocation)
    Implements ILocationModel

    Private Sub New(location As ILocation)
        MyBase.New(location)
    End Sub

    Public ReadOnly Property Column As Integer Implements ILocationModel.Column
        Get
            Return Entity.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements ILocationModel.Row
        Get
            Return Entity.Row
        End Get
    End Property
    Public ReadOnly Property FeatureModel As IFeatureModel Implements ILocationModel.FeatureModel
        Get
            If Entity.HasFeature Then
                Return CFOS.Model.FeatureModel.Create(Entity.Feature)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property UnitModel As IUnitModel Implements ILocationModel.UnitModel
        Get
            If Entity.HasUnit Then
                Return CFOS.Model.UnitModel.Create(Entity.Unit)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property LocationTypeModel As ILocationTypeModel Implements ILocationModel.LocationTypeModel
        Get
            Return CFOS.Model.LocationTypeModel.All(Entity.GetLocationType())
        End Get
    End Property

    Friend Shared Function Create(location As ILocation) As ILocationModel
        Return New LocationModel(location)
    End Function
End Class
