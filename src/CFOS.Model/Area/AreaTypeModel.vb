Imports TGGD.Model

Friend Class AreaTypeModel
    Inherits BaseModel
    Implements IAreaTypeModel
    Private Sub New()

    End Sub
    Friend Shared ReadOnly All As IReadOnlyDictionary(Of String, IAreaTypeModel) =
        New Dictionary(Of String, IAreaTypeModel) From
        {
            {AreaTypes.CRADLE, New AreaTypeModel()}
        }
End Class
