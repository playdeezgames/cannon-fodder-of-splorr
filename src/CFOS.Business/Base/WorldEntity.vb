Imports CFOS.Data
Imports TGGD.Business
Imports TGGD.Data

Friend MustInherit Class WorldEntity(Of TEntityData As EntityData)
    Inherits Entity(Of TEntityData)
    Implements IWorldEntity

    Protected ReadOnly worldData As WorldData

    Protected Sub New(worldData As WorldData)
        Me.worldData = worldData
    End Sub

    Public ReadOnly Property World As IWorld Implements IWorldEntity.World
        Get
            Return CFOS.Business.World.Create(worldData)
        End Get
    End Property
End Class
