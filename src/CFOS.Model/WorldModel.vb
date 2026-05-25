Imports CFOS.Business

Public Class WorldModel
    Inherits TGGD.Model.BaseModel
    Implements IWorldModel

    Private ReadOnly world As IWorld

    Private Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public Property FactionName As String Implements IWorldModel.FactionName
        Get
            Return world.GetFactionName()
        End Get
        Set(value As String)
            world.SetFactionName(value)
        End Set
    End Property

    Public Shared Function Create(factionName As String) As IWorldModel
        Dim world = CFOS.Business.World.Create(New Data.WorldData)
        world.Initialize(factionName)
        Return New WorldModel(world)
    End Function
End Class
