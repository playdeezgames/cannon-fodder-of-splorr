Imports GMN.Business
Imports TGGD.Model

Public Class WorldModel
    Inherits BaseModel(Of IWorld)
    Implements IWorldModel

    Protected Sub New(entity As IWorld)
        MyBase.New(entity)
    End Sub

    Public Shared Function Create() As IWorldModel
        Dim world As IWorld
        Try
            world = GMN.Business.World.Load(SAVE_FILE_NAME)
        Catch ex As Exception
            world = GMN.Business.World.Create(New Data.GMNData)
        End Try
        Return New WorldModel(world)
    End Function
End Class
