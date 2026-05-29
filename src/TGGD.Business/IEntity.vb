Public Interface IEntity
    Sub Clear()
    Function GetMetadata(metadataId As String) As String
    Sub SetMetadata(metadataId As String, metadataValue As String)
    Sub SetStatistic(statisticId As String, statisticValue As Integer)
    Function GetStatistic(statisticId As String) As Integer
    Function GetFlag(flagId As String) As Boolean
End Interface
