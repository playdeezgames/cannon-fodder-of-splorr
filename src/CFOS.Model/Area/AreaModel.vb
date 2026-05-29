Imports CFOS.Business
Imports TGGD.Model

Friend Class AreaModel
    Inherits BaseModel(Of IArea)
    Implements IAreaModel

    Private Sub New(area As IArea)
        MyBase.New(area)
    End Sub

    Public ReadOnly Property WorldModel As IWorldModel Implements IAreaModel.WorldModel
        Get
            Return CFOS.Model.WorldModel.Create(Entity.World)
        End Get
    End Property

    Public ReadOnly Property Rows As Integer Implements IAreaModel.Rows
        Get
            Return Entity.Rows
        End Get
    End Property

    Public ReadOnly Property Columns As Integer Implements IAreaModel.Columns
        Get
            Return Entity.Columns
        End Get
    End Property

    Public ReadOnly Property AreaTypeModel As IAreaTypeModel Implements IAreaModel.AreaTypeModel
        Get
            Return CFOS.Model.AreaTypeModel.All(Entity.GetAreaType())
        End Get
    End Property

    Friend Shared Function Create(area As IArea) As IAreaModel
        Return New AreaModel(area)
    End Function

    Public Function GetLocationModel(column As Integer, row As Integer) As ILocationModel Implements IAreaModel.GetLocationModel
        Dim location = Entity.GetLocation(column, row)
        If location IsNot Nothing Then
            Return LocationModel.Create(location)
        End If
        Return Nothing
    End Function
End Class
