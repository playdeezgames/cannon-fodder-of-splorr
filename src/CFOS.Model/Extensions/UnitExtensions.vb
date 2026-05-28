Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module UnitExtensions
    <Extension>
    Friend Function GetUnitType(unit As IUnit) As String
        Return unit.GetMetadata(Metadatas.UNIT_TYPE)
    End Function
    <Extension>
    Friend Sub SetUnitType(unit As IUnit, unitType As String)
        unit.SetMetadata(Metadatas.UNIT_TYPE, unitType)
    End Sub
End Module
