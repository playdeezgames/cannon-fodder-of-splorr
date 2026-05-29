Imports CFOS.Model
Imports TGGD.UI

Friend Class CradleLocationMenuDialog
    Inherits BaseModelDialog(Of ILocationModel)

    Private ReadOnly previousDialog As IDialog

    Private Sub New(context As IHostContext, model As ILocationModel, previousDialog As IDialog)
        MyBase.New(context, model)
        Me.previousDialog = previousDialog
    End Sub

    Public Overrides Function Run() As IDialog
        context.WriteLine($"Location: ({model.Column}, {model.Row})")
        context.WriteLine($"Location Type: {model.LocationTypeModel.LocationTypeName}")
        context.WriteLine($"Description: {model.LocationTypeModel.LocationTypeDescription}")
        Dim feature = model.FeatureModel
        If feature IsNot Nothing Then
            context.WriteLine($"Feature Type: {feature.FeatureTypeModel.Name}")
        End If
        Dim unit = model.UnitModel
        If unit IsNot Nothing Then
            context.WriteLine($"Unit Type: {unit.UnitTypeModel.UnitTypeName}")
        End If
        Dim choices =
            {
                DialogChoice.Create(True, "Never Mind", Function() previousDialog)
            }.Concat(feature.GetInterations(context, Function() Me))
        Return context.Choose("Now What?", choices.ToArray)
    End Function

    Friend Shared Function Launch(context As IHostContext, model As ILocationModel, previousDialog As IDialog) As Func(Of IDialog)
        Return Function() New CradleLocationMenuDialog(context, model, previousDialog)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, model, previousDialog).Invoke
    End Function
End Class
