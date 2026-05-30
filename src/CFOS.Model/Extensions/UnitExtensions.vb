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
    <Extension>
    Friend Sub SetSerialNumber(unit As IUnit, serialNumber As Integer)
        unit.SetCounter(Counters.SERIAL_NUMBER, serialNumber)
    End Sub
    <Extension>
    Friend Function GetSerialNumber(unit As IUnit) As Integer
        Return unit.GetCounter(Counters.SERIAL_NUMBER)
    End Function
End Module
