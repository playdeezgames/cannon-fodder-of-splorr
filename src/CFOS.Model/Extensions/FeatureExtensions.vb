Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module FeatureExtensions
    <Extension>
    Sub SetFeatureType(feature As IFeature, featureType As String)
        feature.SetMetadata(Metadatas.FEATURE_TYPE, featureType)
    End Sub
End Module
