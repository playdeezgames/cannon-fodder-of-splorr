Imports System.Runtime.CompilerServices
Imports CFOS.Model
Imports TGGD.UI

Friend Module FeatureModelExtensions
    <Extension>
    Friend Function GetInterations(
                                  feature As IFeatureModel,
                                  context As IHostContext,
                                  exitDialog As Func(Of IDialog)) As IEnumerable(Of IDialogChoice)
        Return If(
                feature IsNot Nothing,
                FeatureModelInteration.All.
                    Select(Function(x) x.ToDialogChoice(context, feature, exitDialog)),
                Enumerable.Empty(Of IDialogChoice))
    End Function
End Module
