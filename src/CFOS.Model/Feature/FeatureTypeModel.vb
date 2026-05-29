Imports TGGD.Model

Friend Class FeatureTypeModel
    Inherits BaseModel
    Implements IFeatureTypeModel
    Private Sub New(
                   identifier As String,
                   featureTypeName As String,
                   text As String,
                   Optional isControlPanel As Boolean = False)
        Me.Identifier = identifier
        Me.Name = featureTypeName
        Me.Text = text
        Me.IsControlPanel = isControlPanel
    End Sub
    Friend Shared ReadOnly All As IReadOnlyDictionary(Of String, IFeatureTypeModel) =
        New List(Of IFeatureTypeModel) From
        {
            New FeatureTypeModel(FeatureTypes.CRYO_POD, "Cryo Pod", "@"),
            New FeatureTypeModel(FeatureTypes.CONTROL_PANEL, "Control Panel", "!", isControlPanel:=True)
        }.ToDictionary(Function(x) x.Identifier, Function(x) x)

    Public ReadOnly Property Text As String Implements IFeatureTypeModel.Text

    Public ReadOnly Property Name As String Implements IFeatureTypeModel.Name

    Public ReadOnly Property Identifier As String Implements IFeatureTypeModel.Identifier

    Public ReadOnly Property IsControlPanel As Boolean Implements IFeatureTypeModel.IsControlPanel
End Class
