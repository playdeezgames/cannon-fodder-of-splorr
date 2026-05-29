Imports Shouldly
Imports TGGD.Data
Imports Xunit

Public Class TestEntity_statistic_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetStatistic(Statistics.ONE))
    End Sub
    <Fact>
    Sub throw_exception_when_reading_invalid_key()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        Should.Throw(Of KeyNotFoundException)(Sub() sut.GetStatistic(Statistics.ONE))
    End Sub
    Const STATISTIC_VALUE = 69
    <Fact>
    Sub set_statistic()
        Dim entityData As New EntityData
        Dim sut = TestEntity.Create(entityData)
        sut.SetStatistic(Statistics.ONE, STATISTIC_VALUE)
        entityData.Statistics.Count.ShouldBe(1)
        entityData.Statistics.Single.Key.ShouldBe(Statistics.ONE)
        entityData.Statistics.Single.Value.ShouldBe(STATISTIC_VALUE)
    End Sub
    <Fact>
    Sub get_statistic()
        Dim entityData As New EntityData
        With entityData
            .Statistics(Statistics.ONE) = STATISTIC_VALUE
        End With
        Dim sut = TestEntity.Create(entityData)
        Dim actual = sut.GetStatistic(Statistics.ONE)
        actual.ShouldBe(STATISTIC_VALUE)
    End Sub
End Class
