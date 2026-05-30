Imports CFOS.Model
Imports TGGD.UI

Friend Class LiquifyUnitInteraction
    Inherits UnitModelInteraction

    Private Sub New()
    End Sub

    Friend Shared Function Create() As UnitModelInteraction
        Return New LiquifyUnitInteraction()
    End Function

    Protected Overrides Function MakeDialog(context As IHostContext, model As IUnitModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return LiquefyUnitDialog.Launch(context, model, exitDialog)
    End Function

    Protected Overrides Function MakeName(model As IUnitModel) As String
        Return $"Liquefy {model.GetName()}"
    End Function

    Protected Overrides Function CanInteract(model As IUnitModel) As Boolean
        Return model.CanLiquefy()
    End Function
End Class
