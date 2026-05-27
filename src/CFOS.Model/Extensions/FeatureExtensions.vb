Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module FeatureExtensions
    <Extension>
    Sub SetFeatureType(feature As IFeature, featureType As String)
        feature.SetMetadata(Metadatas.FEATURE_TYPE, featureType)
    End Sub
    <Extension>
    Function GetFeatureType(feature As IFeature) As String
        Return feature.GetMetadata(Metadatas.FEATURE_TYPE)
    End Function
#Disable Warning CA1859 ' Use concrete types when possible for improved performance
    Private ReadOnly unitHousers As IReadOnlySet(Of String) =
        New HashSet(Of String) From
        {
            FeatureTypes.CRYO_POD
        }
#Enable Warning CA1859 ' Use concrete types when possible for improved performance
    <Extension>
    Function CanHouseUnit(feature As IFeature) As Boolean
        Return unitHousers.Contains(feature.GetFeatureType())
    End Function
End Module
