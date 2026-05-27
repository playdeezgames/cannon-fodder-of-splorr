Imports CFOS.Business
Imports TGGD.Model

Friend Class FeatureModel
    Inherits BaseModel
    Implements IFeatureModel

    Private ReadOnly feature As IFeature

    Private Sub New(feature As IFeature)
        Me.feature = feature
    End Sub

#Disable Warning CA1859 ' Use concrete types when possible for improved performance
    Private Shared ReadOnly textTable As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {FeatureTypes.CRYO_POD, "@"}
        }
#Enable Warning CA1859 ' Use concrete types when possible for improved performance

    Public ReadOnly Property Text As String Implements IFeatureModel.Text
        Get
            Return textTable(feature.GetFeatureType())
        End Get
    End Property

#Disable Warning CA1859 ' Use concrete types when possible for improved performance
    Private Shared ReadOnly nameTable As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {FeatureTypes.CRYO_POD, "Cryo Pod"}
        }
#Enable Warning CA1859 ' Use concrete types when possible for improved performance

    Public ReadOnly Property FeatureTypeName As String Implements IFeatureModel.FeatureTypeName
        Get
            Return nameTable(feature.GetFeatureType())
        End Get
    End Property

    Friend Shared Function Create(feature As IFeature) As IFeatureModel
        Return New FeatureModel(feature)
    End Function
End Class
