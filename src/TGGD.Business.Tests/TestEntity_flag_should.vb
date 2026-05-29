Imports Shouldly
Imports TGGD.Data
Imports Xunit

Public Class TestEntity_flag_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetFlag(Keys.ONE))
    End Sub
    <Fact>
    Sub return_false_when_seeking_nonexistent_flag()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.GetFlag(Keys.ONE)
        actual.ShouldBeFalse
    End Sub
End Class
