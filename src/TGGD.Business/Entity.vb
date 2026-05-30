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

    Public Sub SetStatistic(statisticId As String, statisticValue As Integer) Implements IEntity.SetStatistic
        EntityData.Statistics(statisticId) = statisticValue
    End Sub

    Public Sub SetTag(tagId As String, tagValue As Boolean) Implements IEntity.SetTag
        If tagValue Then
            EntityData.Tags.Add(tagId)
        Else
            EntityData.Tags.Remove(tagId)
        End If
    End Sub

    Public Function GetMetadata(metadataId As String) As String Implements IEntity.GetMetadata
        Return EntityData.Metadatas(metadataId)
    End Function

    Public Function GetStatistic(statisticId As String) As Integer Implements IEntity.GetStatistic
        Return EntityData.Statistics(statisticId)
    End Function

    Public Function HasTag(tagId As String) As Boolean Implements IEntity.HasTag
        Return EntityData.Tags.Contains(tagId)
    End Function
End Class
