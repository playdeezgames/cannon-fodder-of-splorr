Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module FactionExtensions
    <Extension>
    Friend Sub SetNextSerialNumber(faction As IFaction, serialNumber As Integer)
        faction.SetStatistic(Statistics.NEXT_SERIAL_NUMBER, serialNumber)
    End Sub
    <Extension>
    Friend Function IncrementNextSerialNumber(faction As IFaction) As Integer
        Dim result = faction.GetStatistic(Statistics.NEXT_SERIAL_NUMBER)
        faction.SetStatistic(Statistics.NEXT_SERIAL_NUMBER, result + 1)
        Return result
    End Function
End Module
