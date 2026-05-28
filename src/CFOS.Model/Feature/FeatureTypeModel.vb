Imports TGGD.Model

Friend Class FeatureTypeModel
    Inherits BaseModel
    Implements IFeatureTypeModel
    Private Sub New()

    End Sub
    Friend Shared ReadOnly All As IReadOnlyDictionary(Of String, IFeatureTypeModel) =
        New Dictionary(Of String, IFeatureTypeModel) From
        {
            {FeatureTypes.CRYO_POD, New FeatureTypeModel()}
        }
End Class
