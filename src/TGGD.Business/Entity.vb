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

    Public Sub SetCounter(counterId As String, counterValue As Integer) Implements IEntity.SetCounter
        EntityData.Counters(counterId) = counterValue
    End Sub

    Public Sub SetTag(tagId As String, tagValue As Boolean) Implements IEntity.SetTag
        If tagValue Then
            EntityData.Tags.Add(tagId)
        Else
            EntityData.Tags.Remove(tagId)
        End If
    End Sub

    Public Sub SetCounterMaximum(counterId As String, counterMaximum As Integer) Implements IEntity.SetCounterMaximum
        EntityData.CounterMaximums(counterId) = counterMaximum
    End Sub

    Public Function GetMetadata(metadataId As String) As String Implements IEntity.GetMetadata
        Return EntityData.Metadatas(metadataId)
    End Function

    Public Function GetCounter(counterId As String) As Integer Implements IEntity.GetCounter
        Return EntityData.Counters(counterId)
    End Function

    Public Function HasTag(tagId As String) As Boolean Implements IEntity.HasTag
        Return EntityData.Tags.Contains(tagId)
    End Function

    Public Function GetCounterMaximum(counterId As String) As Integer Implements IEntity.GetCounterMaximum
        If EntityData IsNot Nothing Then
            Return Integer.MaxValue
        End If
        Throw New NullReferenceException()
    End Function
End Class
