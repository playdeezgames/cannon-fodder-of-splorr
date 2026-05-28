Imports System.Runtime.CompilerServices
Imports CFOS.Model

Friend Module UnitModelExtensions
    <Extension>
    Friend Function GetName(unit As IUnitModel) As String
        Return unit.UnitTypeModel.UnitTypeName
    End Function
End Module
