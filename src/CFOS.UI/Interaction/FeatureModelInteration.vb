Imports CFOS.Model

Friend MustInherit Class FeatureModelInteration
    Inherits ModelInteraction(Of IFeatureModel)
    Protected Sub New()

    End Sub

    Friend Shared ReadOnly All As IReadOnlyList(Of FeatureModelInteration) =
        New List(Of FeatureModelInteration) From
        {
            UseControlPanelInteraction.Create()
        }
End Class
