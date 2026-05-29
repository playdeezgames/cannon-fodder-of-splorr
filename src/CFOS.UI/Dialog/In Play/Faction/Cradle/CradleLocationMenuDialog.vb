Imports CFOS.Model
Imports TGGD.UI

Friend Class CradleLocationMenuDialog
    Inherits ExitableModelDialog(Of ILocationModel)

    Private Sub New(context As IHostContext, model As ILocationModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
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
                NeverMindChoice
            }.Concat(feature.GetInterations(context, AddressOf Relaunch))
        Return context.Choose("Now What?", choices.ToArray)
    End Function

    Friend Shared Function Launch(context As IHostContext, model As ILocationModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New CradleLocationMenuDialog(context, model, exitDialog)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, model, exitDialog).Invoke
    End Function
End Class
