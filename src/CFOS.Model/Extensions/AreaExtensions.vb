Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module AreaExtensions
    <Extension>
    Friend Sub SetAreaType(area As IArea, areaType As String)
        area.SetMetadata(Metadatas.AREA_TYPE, areaType)
    End Sub
    <Extension>
    Friend Function GetAreaType(area As IArea) As String
        Return area.GetMetadata(Metadatas.AREA_TYPE)
    End Function
End Module
