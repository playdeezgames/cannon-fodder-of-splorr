Imports CFOS.Business
Imports TGGD.Model

Friend Class AreaModel
    Inherits BaseModel
    Implements IAreaModel

    Private ReadOnly area As IArea

    Private Sub New(area As IArea)
        Me.area = area
    End Sub

    Public ReadOnly Property WorldModel As IWorldModel Implements IAreaModel.WorldModel
        Get
            Return CFOS.Model.WorldModel.Create(area.World)
        End Get
    End Property

    Public ReadOnly Property Rows As Integer Implements IAreaModel.Rows
        Get
            Return area.Rows
        End Get
    End Property

    Public ReadOnly Property Columns As Integer Implements IAreaModel.Columns
        Get
            Return area.Columns
        End Get
    End Property

    Friend Shared Function Create(area As IArea) As IAreaModel
        Return New AreaModel(area)
    End Function
End Class
