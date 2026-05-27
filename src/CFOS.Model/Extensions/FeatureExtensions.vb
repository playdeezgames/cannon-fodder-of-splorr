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
End Module
