Imports CFOS.Model
Imports TGGD.UI

Friend Class UseControlPanelInteraction
    Inherits FeatureModelInteration
    Private Sub New()

    End Sub

    Friend Shared Function Create() As FeatureModelInteration
        Return New UseControlPanelInteraction
    End Function

    Protected Overrides Function MakeDialog(context As IHostContext, feature As IFeatureModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return UseControlPanelMenuDialog.Launch(context, feature, exitDialog)
    End Function

    Protected Overrides Function MakeName(feature As IFeatureModel) As String
        Return "Use Control Panel"
    End Function

    Protected Overrides Function CanInteract(feature As IFeatureModel) As Boolean
        Return feature.FeatureTypeModel.IsControlPanel
    End Function
End Class
