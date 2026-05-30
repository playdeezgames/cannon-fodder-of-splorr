Imports CFOS.Business
Imports TGGD.Model

Friend Class FactionModel
    Inherits BaseModel(Of IFaction)
    Implements IFactionModel

    Private Sub New(faction As IFaction)
        MyBase.New(faction)
    End Sub

    Public ReadOnly Property UnitCount As Integer Implements IFactionModel.UnitCount
        Get
            Return Entity.UnitCount
        End Get
    End Property

    Public ReadOnly Property WorldModel As IWorldModel Implements IFactionModel.WorldModel
        Get
            Return CFOS.Model.WorldModel.Create(Entity.World)
        End Get
    End Property

    Public ReadOnly Property CanRecruit As Boolean Implements IFactionModel.CanRecruit
        Get
            Return Entity.Cradle.Locations.Any(Function(l) l.HasAvailableCryoPod())
        End Get
    End Property

    Public ReadOnly Property UnitModels As IEnumerable(Of IUnitModel) Implements IFactionModel.UnitModels
        Get
            Return Entity.Units.Select(Function(x) UnitModel.Create(x))
        End Get
    End Property

    Public Sub AddUnit(unitTypeModel As IUnitTypeModel) Implements IFactionModel.AddUnit
        Dim unit = Entity.CreateUnit(Entity.Cradle.Locations.First(Function(l) l.HasAvailableCryoPod()))
        unit.SetSerialNumber(Entity.IncrementNextSerialNumber())
        unit.SetUnitType(unitTypeModel.UnitTypeId)
    End Sub

    Friend Shared Function Create(faction As IFaction) As IFactionModel
        Return New FactionModel(faction)
    End Function
End Class
