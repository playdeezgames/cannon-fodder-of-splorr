Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module AreaExtensions
    <Extension>
    Friend Sub SetAreaType(area As IArea, areaType As String)
        area.SetMetadata(Metadatas.AREA_TYPE, areaType)
    End Sub
End Module
