Imports System.Runtime.CompilerServices
Imports CFOS.Model
Imports TGGD.UI

Friend Module UnitModelExtensions
    <Extension>
    Friend Function GetName(unit As IUnitModel) As String
        Return $"{unit.UnitTypeModel.UnitTypeName}(#{unit.SerialNumber})"
    End Function
    <Extension>
    Friend Function GetInterations(
                                  unit As IUnitModel,
                                  context As IHostContext,
                                  exitDialog As Func(Of IDialog)) As IEnumerable(Of IDialogChoice)
        Return If(
                unit IsNot Nothing,
                UnitModelInteraction.All.
                    Select(Function(x) x.ToDialogChoice(context, unit, exitDialog)),
                Enumerable.Empty(Of IDialogChoice))
    End Function
End Module
