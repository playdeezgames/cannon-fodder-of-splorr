Imports CFOS.Business

Friend Class SquadModel
    Implements ISquadModel

    Private ReadOnly world As IWorld

    Private Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property MemberCount As Integer Implements ISquadModel.MemberCount
        Get
            Return 0
        End Get
    End Property

    Public ReadOnly Property WorldModel As IWorldModel Implements ISquadModel.WorldModel
        Get
            Return CFOS.Model.WorldModel.Create(world)
        End Get
    End Property

    Friend Shared Function Create(world As IWorld) As ISquadModel
        Return New SquadModel(world)
    End Function
End Class
