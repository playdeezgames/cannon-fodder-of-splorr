Public Interface IEntity
    Sub Clear()
    Function GetMetadata(metadataId As String) As String
    Sub SetMetadata(metadataId As String, metadataValue As String)
    Sub SetCounter(counterId As String, counterValue As Integer)
    Function GetCounter(counterId As String) As Integer
    Function HasTag(tagId As String) As Boolean
    Sub SetTag(tagId As String, tagValue As Boolean)
End Interface
