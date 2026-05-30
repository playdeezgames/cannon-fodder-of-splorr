Imports GMN.Data
Imports TGGD.Business

Public Class World
    Inherits Entity(Of GMNData)
    Implements IWorld
    Private Sub New(data As GMNData)
        Me.EntityData = data
    End Sub

    Protected Overrides ReadOnly Property EntityData As GMNData

    Public Shared Function Create(data As GMNData) As IWorld
        Return New World(data)
    End Function
End Class
