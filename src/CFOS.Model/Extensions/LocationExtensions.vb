Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module LocationExtensions
    <Extension>
    Sub SetLocationType(location As ILocation, locationType As String)
        location.SetMetadata(Metadatas.LOCATION_TYPE, locationType)
    End Sub
End Module
