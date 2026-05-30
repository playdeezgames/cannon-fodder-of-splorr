Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module FactionExtensions
    <Extension>
    Friend Sub SetNextSerialNumber(faction As IFaction, serialNumber As Integer)
        faction.SetCounter(Counters.NEXT_SERIAL_NUMBER, serialNumber)
    End Sub
    <Extension>
    Friend Function IncrementNextSerialNumber(faction As IFaction) As Integer
        Dim result = faction.GetCounter(Counters.NEXT_SERIAL_NUMBER)
        faction.SetCounter(Counters.NEXT_SERIAL_NUMBER, result + 1)
        Return result
    End Function
End Module
