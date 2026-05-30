Imports Shouldly
Imports Xunit

Public Class TestEntity_counter_maximum_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetCounterMaximum(Keys.ONE))
    End Sub
    <Fact>
    Sub return_maximum_integer_when_reading_invalid_key()
        Dim sut = TestEntity.Create(New Data.EntityData)
        Dim actual = sut.GetCounterMaximum(Keys.ONE)
        actual.ShouldBe(Integer.MaxValue)
    End Sub
End Class
