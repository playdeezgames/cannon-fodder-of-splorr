Imports GMN.Business
Imports TGGD.Model

Public Class WorldModel
    Inherits BaseModel(Of IWorld)
    Implements IWorldModel

    Protected Sub New(entity As IWorld)
        MyBase.New(entity)
    End Sub

    Public Shared Function Create(world As IWorld) As IWorldModel
        Return New WorldModel(world)
    End Function
End Class
