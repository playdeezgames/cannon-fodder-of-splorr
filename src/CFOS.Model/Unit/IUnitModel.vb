Imports TGGD.Model

Public Interface IUnitModel
    Inherits IModel
    ReadOnly Property UnitTypeModel As IUnitTypeModel
    ReadOnly Property FactionModel As IFactionModel
    ReadOnly Property SerialNumber As Integer
    ReadOnly Property CanLiquefy As Boolean
    Sub Liquefy()
End Interface
