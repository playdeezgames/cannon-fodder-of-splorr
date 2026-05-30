Imports CFOS.Model
Imports TGGD.UI

Friend Class CradleLocationMenuDialog
    Inherits ExitableModelDialog(Of IHostContext, ILocationModel)

    Private Sub New(context As IHostContext, model As ILocationModel, exitDialog As Func(Of IDialog))
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialog
        Context.Clear()
        Context.WriteLine($"Location: ({Model.Column}, {Model.Row})")
        Context.WriteLine($"Location Type: {Model.LocationTypeModel.LocationTypeName}")
        Context.WriteLine($"Description: {Model.LocationTypeModel.LocationTypeDescription}")
        Dim feature = Model.FeatureModel
        If feature IsNot Nothing Then
            Context.WriteLine($"Feature Type: {feature.FeatureTypeModel.Name}")
        End If
        Dim unit = Model.UnitModel
        If unit IsNot Nothing Then
            Context.WriteLine($"Unit Type: {unit.UnitTypeModel.UnitTypeName}")
        End If
        Dim choices =
            {
                ExitChoice
            }.
            Concat(feature.GetInterations(Context, AddressOf Relaunch)).
            Concat(unit.GetInterations(Context, AddressOf Relaunch))
        Return Context.Choose("Now What?", choices.ToArray)
    End Function

    Friend Shared Function Launch(context As IHostContext, model As ILocationModel, exitDialog As Func(Of IDialog)) As Func(Of IDialog)
        Return Function() New CradleLocationMenuDialog(context, model, exitDialog)
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, ExitDialog).Invoke
    End Function
End Class
