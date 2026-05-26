Imports CFOS.Data

Friend Class Area
    Inherits WorldEntity(Of AreaData)
    Implements IArea
    Private Sub New(worldData As WorldData, areaId As Guid)
        MyBase.New(worldData)
        Me.AreaId = areaId
    End Sub

    Public ReadOnly Property AreaId As Guid Implements IArea.AreaId

    Protected Overrides ReadOnly Property EntityData As AreaData
        Get
            Return worldData.Areas(AreaId)
        End Get
    End Property

    Public ReadOnly Property Columns As Integer Implements IArea.Columns
        Get
            Return EntityData.Columns
        End Get
    End Property

    Public ReadOnly Property Rows As Integer Implements IArea.Rows
        Get
            Return EntityData.Rows
        End Get
    End Property

    Public Function GetLocation(column As Integer, row As Integer) As ILocation Implements IArea.GetLocation
        If column >= 0 AndAlso row >= 0 AndAlso column < Columns AndAlso row < Rows Then
            Return Location.Create(worldData, EntityData.LocationIds(column + row * Columns))
        End If
        Return Nothing
    End Function

    Friend Shared Function Create(worldData As WorldData, areaId As Guid) As IArea
        Return New Area(worldData, areaId)
    End Function
End Class
