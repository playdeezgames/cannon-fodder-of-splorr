Public Interface IEntity
    Sub Clear()
    Function GetMetadata(metadataId As String) As String
    Sub SetMetadata(metadataId As String, metadataValue As String)
End Interface
