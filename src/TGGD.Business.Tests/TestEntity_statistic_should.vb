Imports Shouldly
Imports TGGD.Data
Imports Xunit

Public Class TestEntity_statistic_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetStatistic(Keys.ONE))
    End Sub
    <Fact>
    Sub throw_exception_when_reading_invalid_key()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        Should.Throw(Of KeyNotFoundException)(Sub() sut.GetStatistic(Keys.ONE))
    End Sub
    Const STATISTIC_VALUE = 69
    <Fact>
    Sub set_statistic()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetStatistic(Keys.ONE, STATISTIC_VALUE)
        entityData.Statistics.Count.ShouldBe(1)
        entityData.Statistics.Single.Key.ShouldBe(Keys.ONE)
        entityData.Statistics.Single.Value.ShouldBe(STATISTIC_VALUE)
    End Sub
    <Fact>
    Sub get_statistic()
        Dim entityData As New EntityData
        With entityData
            .Statistics(Keys.ONE) = STATISTIC_VALUE
        End With
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.GetStatistic(Keys.ONE)
        actual.ShouldBe(STATISTIC_VALUE)
    End Sub
End Class
