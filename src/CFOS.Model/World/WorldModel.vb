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

    Public ReadOnly Property Squad As ISquadModel Implements IWorldModel.Squad
        Get
            Return SquadModel.Create(world.Player)
        End Get
    End Property

    Public ReadOnly Property AvailableUnitTypes As IEnumerable(Of IUnitTypeModel) Implements IWorldModel.AvailableUnitTypes
        Get
            Return UnitTypeModel.All.Values
        End Get
    End Property

    Public Shared Function CreateAndInitialize(factionName As String) As IWorldModel
        Dim world = CFOS.Business.World.Create(New Data.WorldData)
        world.Initialize(factionName)
        Return Create(world)
    End Function
    Friend Shared Function Create(world As IWorld) As IWorldModel
        Return New WorldModel(world)
    End Function
End Class
