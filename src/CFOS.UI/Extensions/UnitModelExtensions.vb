Imports System.Runtime.CompilerServices
Imports CFOS.Model

Friend Module UnitModelExtensions
    <Extension>
    Friend Function GetName(unit As IUnitModel) As String
        Return $"{unit.UnitTypeModel.UnitTypeName}(#{unit.SerialNumber})"
    End Function
End Module
