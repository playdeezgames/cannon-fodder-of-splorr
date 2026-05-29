Imports CFOS.Business
Imports TGGD.Model

Friend Class UnitModel
    Inherits BaseModel(Of IUnit)
    Implements IUnitModel

    Private Sub New(unit As IUnit)
        MyBase.New(unit)
    End Sub

    Public ReadOnly Property UnitTypeModel As IUnitTypeModel Implements IUnitModel.UnitTypeModel
        Get
            Return CFOS.Model.UnitTypeModel.All(Entity.GetUnitType())
        End Get
    End Property

    Public ReadOnly Property FactionModel As IFactionModel Implements IUnitModel.FactionModel
        Get
            Return CFOS.Model.FactionModel.Create(Entity.Faction)
        End Get
    End Property

    Public ReadOnly Property SerialNumber As Integer Implements IUnitModel.SerialNumber
        Get
            Return Entity.GetSerialNumber()
        End Get
    End Property

    Friend Shared Function Create(unit As IUnit) As IUnitModel
        Return New UnitModel(unit)
    End Function
End Class
