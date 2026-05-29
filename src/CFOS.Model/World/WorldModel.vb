Imports CFOS.Business

Public Class WorldModel
    Inherits TGGD.Model.BaseModel(Of IWorld)
    Implements IWorldModel

    Private Sub New(world As IWorld)
        MyBase.New(world)
    End Sub

    Public Property FactionName As String Implements IWorldModel.FactionName
        Get
            Return Entity.GetFactionName()
        End Get
        Set(value As String)
            Entity.SetFactionName(value)
        End Set
    End Property

    Public ReadOnly Property FactionModel As IFactionModel Implements IWorldModel.FactionModel
        Get
            Return Model.FactionModel.Create(Entity.Player)
        End Get
    End Property

    Public ReadOnly Property AvailableUnitTypes As IEnumerable(Of IUnitTypeModel) Implements IWorldModel.AvailableUnitTypes
        Get
            Return UnitTypeModel.All.Values
        End Get
    End Property

    Public ReadOnly Property CradleAreaModel As IAreaModel Implements IWorldModel.CradleAreaModel
        Get
            Return AreaModel.Create(Entity.Player.Cradle)
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
