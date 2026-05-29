Friend Class LocationTypeModel
    Implements ILocationTypeModel
    Private Sub New(identifier As String, name As String, description As String, text As String)
        Me.Identifier = identifier
        Me.LocationTypeName = name
        Me.LocationTypeDescription = description
        Me.Text = text
    End Sub
    Friend Shared ReadOnly All As IReadOnlyDictionary(Of String, ILocationTypeModel) =
        New List(Of ILocationTypeModel) From
        {
            New LocationTypeModel(LocationTypes.BULKHEAD, "Bulkhead", "It's a bulkhead, dumbass.", "#"),
            New LocationTypeModel(LocationTypes.DECK, "Deck", "It's a deck, dumbass.", "."),
            New LocationTypeModel(LocationTypes.HATCH, "Hatch", "It's a hatch, dumbass.", "+")
        }.ToDictionary(Function(x) x.Identifier, Function(x) x)

    Public ReadOnly Property Identifier As String Implements ILocationTypeModel.Identifier

    Public ReadOnly Property Text As String Implements ILocationTypeModel.Text

    Public ReadOnly Property LocationTypeName As String Implements ILocationTypeModel.LocationTypeName

    Public ReadOnly Property LocationTypeDescription As String Implements ILocationTypeModel.LocationTypeDescription
End Class
