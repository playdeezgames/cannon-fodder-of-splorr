Imports TGGD.Model

Public Interface ILocationTypeModel
    Inherits IModel
    ReadOnly Property Identifier As String
    ReadOnly Property Text As String
    ReadOnly Property LocationTypeName As String
    ReadOnly Property LocationTypeDescription As String
End Interface
