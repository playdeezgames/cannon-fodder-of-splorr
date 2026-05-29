Imports CFOS.Model
Imports TGGD.UI

Friend Class CradleAreaMenuDialog
    Inherits BaseModelDialog(Of IAreaModel)

    Private x As Integer
    Private y As Integer

    Private Sub New(context As IHostContext, model As IAreaModel)
        MyBase.New(context, model)
        x = model.Columns \ 2
        y = model.Rows \ 2
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IAreaModel) As Func(Of IDialog)
        Return Function() New CradleAreaMenuDialog(context, model)
    End Function

    Public Overrides Function Run() As IDialog
        context.Clear()
        Dim location As ILocationModel
        For Each row In Enumerable.Range(0, model.Rows)
            For Each column In Enumerable.Range(0, model.Columns)
                If x = column AndAlso y = row Then
                    context.WriteString("[[")
                ElseIf x = column - 1 AndAlso y = row Then
                    context.WriteString("]]")
                Else
                    context.WriteString(" ")
                End If
                location = model.GetLocationModel(column, row)
                context.WriteString(location.GetText())
            Next
            If x = model.Columns - 1 AndAlso y = row Then
                context.WriteLine("]]")
            Else
                context.WriteLine(" ")
            End If
        Next
        context.WriteString($"Location ({x}, {y}): ")
        location = model.GetLocationModel(x, y)
        context.WriteString(location.LocationTypeModel.LocationTypeName)
        Dim feature = location.FeatureModel
        If feature IsNot Nothing Then
            context.WriteString($", {feature.FeatureTypeModel.Name}")
        End If
        Dim unit = location.UnitModel
        If unit IsNot Nothing Then
            context.WriteLine($", {unit.GetName()}")
        End If
        context.WriteLine("")
        context.WriteLine($"Arrows: move | Space/Enter: ENHANCE! | Escape: Game Menu")
        Dim key = context.ReadKey()
        Select Case key
            Case Keys.Escape
                Return GameMenuDialog.Launch(context, model.WorldModel, AddressOf Relaunch).Invoke
            Case Keys.LeftArrow
                x = Math.Max(0, x - 1)
                Return Me
            Case Keys.RightArrow
                x = Math.Min(model.Columns - 1, x + 1)
                Return Me
            Case Keys.UpArrow
                y = Math.Max(0, y - 1)
                Return Me
            Case Keys.DownArrow
                y = Math.Min(model.Rows - 1, y + 1)
                Return Me
            Case Keys.Spacebar, Keys.Enter
                Return CradleLocationMenuDialog.Launch(context, model.GetLocationModel(x, y), Me).Invoke()
            Case Else
                Return Me
        End Select
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(context, model).Invoke
    End Function
End Class
