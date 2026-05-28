Imports TGGD.Model

Friend Class LocationTypeModel
    Inherits BaseModel
    Implements ILocationTypeModel
    Private Sub New()

    End Sub
    Friend Shared ReadOnly All As IReadOnlyDictionary(Of String, ILocationTypeModel) =
        New Dictionary(Of String, ILocationTypeModel) From
        {
            {LocationTypes.BULKHEAD, New LocationTypeModel()},
            {LocationTypes.DECK, New LocationTypeModel()},
            {LocationTypes.HATCH, New LocationTypeModel()}
        }
End Class
