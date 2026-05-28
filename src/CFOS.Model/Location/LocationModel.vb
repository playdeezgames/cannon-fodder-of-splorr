Imports CFOS.Business
Imports TGGD.Model

Friend Class LocationModel
    Inherits BaseModel
    Implements ILocationModel

    Private ReadOnly location As ILocation

    Private Sub New(location As ILocation)
        Me.location = location
    End Sub

#Disable Warning CA1859 ' Use concrete types when possible for improved performance
    Private Shared ReadOnly textTable As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {LocationTypes.DECK, "."},
            {LocationTypes.HATCH, "+"},
            {LocationTypes.BULKHEAD, "#"}
        }
#Enable Warning CA1859 ' Use concrete types when possible for improved performance

    Public ReadOnly Property Text As String Implements ILocationModel.Text
        Get
            Dim unit = Me.UnitModel
            If unit IsNot Nothing Then
                Return unit.UnitTypeModel.Text
            End If
            Dim feature = Me.FeatureModel
            If feature IsNot Nothing Then
                Return feature.Text
            End If
            Return textTable(location.GetLocationType())
        End Get
    End Property

    Public ReadOnly Property Column As Integer Implements ILocationModel.Column
        Get
            Return location.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements ILocationModel.Row
        Get
            Return location.Row
        End Get
    End Property

#Disable Warning CA1859 ' Use concrete types when possible for improved performance
    Private Shared ReadOnly nameTable As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {LocationTypes.DECK, "Deck"},
            {LocationTypes.HATCH, "Hatch"},
            {LocationTypes.BULKHEAD, "Bulkhead"}
        }
#Enable Warning CA1859 ' Use concrete types when possible for improved performance

    Public ReadOnly Property LocationTypeName As String Implements ILocationModel.LocationTypeName
        Get
            Return nameTable(location.GetLocationType())
        End Get
    End Property

#Disable Warning CA1859 ' Use concrete types when possible for improved performance
    Private Shared ReadOnly descriptionTable As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {LocationTypes.DECK, "It's a deck, dumbass!"},
            {LocationTypes.HATCH, "It's a hatch, dumbass!"},
            {LocationTypes.BULKHEAD, "It's a bulkhead, dumbass!"}
        }
#Enable Warning CA1859 ' Use concrete types when possible for improved performance

    Public ReadOnly Property LocationTypeDescription As String Implements ILocationModel.LocationTypeDescription
        Get
            Return descriptionTable(location.GetLocationType())
        End Get
    End Property

    Public ReadOnly Property FeatureModel As IFeatureModel Implements ILocationModel.FeatureModel
        Get
            If location.HasFeature Then
                Return CFOS.Model.FeatureModel.Create(location.Feature)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property UnitModel As IUnitModel Implements ILocationModel.UnitModel
        Get
            If location.HasUnit Then
                Return CFOS.Model.UnitModel.Create(location.Unit)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property LocationTypeModel As ILocationTypeModel Implements ILocationModel.LocationTypeModel
        Get
            Return CFOS.Model.LocationTypeModel.All(location.GetLocationType())
        End Get
    End Property

    Friend Shared Function Create(location As ILocation) As ILocationModel
        Return New LocationModel(location)
    End Function
End Class
