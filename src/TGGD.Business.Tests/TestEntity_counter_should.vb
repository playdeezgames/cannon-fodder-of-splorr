Imports Shouldly
Imports TGGD.Data
Imports Xunit

Public Class TestEntity_counter_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetCounter(Keys.ONE))
    End Sub
    <Fact>
    Sub throw_exception_when_reading_invalid_key()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        Should.Throw(Of KeyNotFoundException)(Sub() sut.GetCounter(Keys.ONE))
    End Sub
    Const COUNTER_VALUE = 69
    <Fact>
    Sub set_counter()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetCounter(Keys.ONE, COUNTER_VALUE)
        entityData.Counters.Count.ShouldBe(1)
        entityData.Counters.Single.Key.ShouldBe(Keys.ONE)
        entityData.Counters.Single.Value.ShouldBe(COUNTER_VALUE)
    End Sub
    <Fact>
    Sub get_counter()
        Dim entityData As New EntityData
        With entityData
            .Counters(Keys.ONE) = COUNTER_VALUE
        End With
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.GetCounter(Keys.ONE)
        actual.ShouldBe(COUNTER_VALUE)
    End Sub
End Class
