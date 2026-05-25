Imports TGGD.Data

Public MustInherit Class Entity(Of TEntityData As EntityData)
    Implements IEntity

    Protected MustOverride ReadOnly Property EntityData As TEntityData

    Public Sub Clear() Implements IEntity.Clear
        EntityData.Metadatas.Clear()
    End Sub

    Public Sub SetMetadata(metadataId As String, metadataValue As String) Implements IEntity.SetMetadata
        EntityData.Metadatas(metadataId) = metadataValue
    End Sub

    Public Function GetMetadata(metadataId As String) As String Implements IEntity.GetMetadata
        Return EntityData.Metadatas(metadataId)
    End Function
End Class
