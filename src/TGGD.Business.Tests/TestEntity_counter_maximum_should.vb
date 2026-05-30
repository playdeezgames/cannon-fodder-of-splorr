Imports Shouldly
Imports Xunit

Public Class TestEntity_counter_maximum_should
    <Fact>
    Sub throw_exception_when_reading_null_entity_data()
        Dim sut = TestEntity.Create(Nothing)
        Should.Throw(Of NullReferenceException)(Sub() sut.GetCounterMaximum(Keys.ONE))
    End Sub

End Class
