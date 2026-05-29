Imports CFOS.Business
Imports TGGD.Model

Friend Class FactionModel
    Inherits BaseModel(Of IFaction)
    Implements IFactionModel

    Private ReadOnly faction As IFaction

    Private Sub New(faction As IFaction)
        MyBase.New(faction)
    End Sub

    Public ReadOnly Property UnitCount As Integer Implements IFactionModel.UnitCount
        Get
            Return faction.UnitCount
        End Get
    End Property

    Public ReadOnly Property WorldModel As IWorldModel Implements IFactionModel.WorldModel
        Get
            Return CFOS.Model.WorldModel.Create(faction.World)
        End Get
    End Property

    Public ReadOnly Property CanRecruit As Boolean Implements IFactionModel.CanRecruit
        Get
            Return faction.Cradle.Locations.Any(Function(l) l.HasAvailableCryoPod())
        End Get
    End Property

    Public ReadOnly Property UnitModels As IEnumerable(Of IUnitModel) Implements IFactionModel.UnitModels
        Get
            Return faction.Units.Select(Function(x) UnitModel.Create(x))
        End Get
    End Property

    Public Sub AddUnit(unitTypeModel As IUnitTypeModel) Implements IFactionModel.AddUnit
        Dim unit = faction.CreateUnit(faction.Cradle.Locations.First(Function(l) l.HasAvailableCryoPod()))
        unit.SetSerialNumber(faction.IncrementNextSerialNumber())
        unit.SetUnitType(unitTypeModel.UnitTypeId)
    End Sub

    Friend Shared Function Create(faction As IFaction) As IFactionModel
        Return New FactionModel(faction)
    End Function
End Class
