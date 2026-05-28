Imports System.Runtime.CompilerServices
Imports CFOS.Model
Imports TGGD.UI

Friend Module FeatureModelExtensions
    <Extension>
    Friend Function GetInterations(feature As IFeatureModel) As IEnumerable(Of IDialogChoice)
        Return Enumerable.Empty(Of IDialogChoice)
    End Function
End Module
