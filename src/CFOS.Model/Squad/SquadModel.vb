Imports CFOS.Business
Imports TGGD.Model

Friend Class SquadModel
    Inherits BaseModel
    Implements ISquadModel

    Private ReadOnly faction As IFaction

    Private Sub New(faction As IFaction)
        Me.faction = faction
    End Sub

    Public ReadOnly Property UnitCount As Integer Implements ISquadModel.UnitCount
        Get
            Return faction.UnitCount
        End Get
    End Property

    Public ReadOnly Property WorldModel As IWorldModel Implements ISquadModel.WorldModel
        Get
            Return CFOS.Model.WorldModel.Create(faction.World)
        End Get
    End Property

    Public ReadOnly Property CanRecruit As Boolean Implements ISquadModel.CanRecruit
        Get
            Return faction.Cradle.Locations.Any(Function(l) l.HasAvailbleCryoPod())
        End Get
    End Property

    Public Sub AddUnit(unitTypeModel As IUnitTypeModel) Implements ISquadModel.AddUnit
        faction.CreateUnit(unitTypeModel.UnitTypeId, faction.Cradle.Locations.First())
    End Sub

    Friend Shared Function Create(faction As IFaction) As ISquadModel
        Return New SquadModel(faction)
    End Function
End Class
