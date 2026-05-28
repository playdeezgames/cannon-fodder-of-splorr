Imports System.Runtime.CompilerServices
Imports CFOS.Model

Friend Module LocationModelExtensions
    <Extension>
    Friend Function GetText(location As ILocationModel) As String
        Return If(
            location.UnitModel?.UnitTypeModel?.Text,
            If(
                location.FeatureModel?.FeatureTypeModel?.Text,
                location.LocationTypeModel.Text))
    End Function
End Module
