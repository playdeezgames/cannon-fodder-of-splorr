Imports CFOS.Model

Friend MustInherit Class UnitModelInteraction
    Inherits ModelInteraction(Of IUnitModel)
    Protected Sub New()

    End Sub

    Friend Shared ReadOnly All As IReadOnlyList(Of UnitModelInteraction) =
        New List(Of UnitModelInteraction) From
        {
            LiquifyUnitInteraction.Create()
        }
End Class
