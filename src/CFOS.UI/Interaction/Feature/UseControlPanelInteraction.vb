Imports CFOS.Model
Imports TGGD.UI

Friend Class UseControlPanelInteraction
    Inherits FeatureModelInteration
    Private Sub New()

    End Sub

    Friend Shared Function Create() As FeatureModelInteration
        Return New UseControlPanelInteraction
    End Function

    Protected Overrides Function MakeDialog(context As IHostContext, model As IFeatureModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return UseControlPanelMenuDialog.Launch(context, model, exitDialog)
    End Function

    Protected Overrides Function MakeName(model As IFeatureModel) As String
        Return "Use Control Panel"
    End Function

    Protected Overrides Function CanInteract(model As IFeatureModel) As Boolean
        Return model.FeatureTypeModel.IsControlPanel
    End Function
End Class
