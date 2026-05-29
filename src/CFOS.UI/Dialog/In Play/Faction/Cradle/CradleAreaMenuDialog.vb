Imports CFOS.Model
Imports TGGD.UI

Friend Class CradleAreaMenuDialog
    Inherits BaseModelDialog(Of IHostContext, IAreaModel)

    Private x As Integer
    Private y As Integer

    Private Sub New(context As IHostContext, model As IAreaModel, Optional x As Integer? = Nothing, Optional y As Integer? = Nothing)
        MyBase.New(context, model)
        Me.x = If(x.HasValue, Math.Clamp(x.Value, 0, model.Columns - 1), model.Columns \ 2)
        Me.y = If(y.HasValue, Math.Clamp(y.Value, 0, model.Rows - 1), model.Rows \ 2)
    End Sub

    Friend Shared Function Launch(context As IHostContext, model As IAreaModel, Optional x As Integer? = Nothing, Optional y As Integer? = Nothing) As Func(Of IDialog)
        Return Function() New CradleAreaMenuDialog(context, model, x, y)
    End Function

    Public Overrides Function Run() As IDialog
        Context.Clear()
        Dim location As ILocationModel
        For Each row In Enumerable.Range(0, Model.Rows)
            For Each column In Enumerable.Range(0, Model.Columns)
                If x = column AndAlso y = row Then
                    Context.WriteString("[[")
                ElseIf x = column - 1 AndAlso y = row Then
                    Context.WriteString("]]")
                Else
                    Context.WriteString(" ")
                End If
                location = Model.GetLocationModel(column, row)
                Context.WriteString(location.GetText())
            Next
            If x = Model.Columns - 1 AndAlso y = row Then
                Context.WriteLine("]]")
            Else
                Context.WriteLine(" ")
            End If
        Next
        Context.WriteString($"Location ({x}, {y}): ")
        location = Model.GetLocationModel(x, y)
        Context.WriteString(location.LocationTypeModel.LocationTypeName)
        Dim feature = location.FeatureModel
        If feature IsNot Nothing Then
            Context.WriteString($", {feature.FeatureTypeModel.Name}")
        End If
        Dim unit = location.UnitModel
        If unit IsNot Nothing Then
            Context.WriteLine($", {unit.GetName()}")
        End If
        Context.WriteLine("")
        Context.WriteLine($"Arrows: move | Space/Enter: ENHANCE! | Escape: Game Menu")
        Dim key = Context.ReadKey()
        Select Case key
            Case Keys.Escape
                Return GameMenuDialog.Launch(Context, Model.WorldModel, AddressOf Relaunch).Invoke
            Case Keys.LeftArrow
                x = Math.Max(0, x - 1)
                Return Me
            Case Keys.RightArrow
                x = Math.Min(Model.Columns - 1, x + 1)
                Return Me
            Case Keys.UpArrow
                y = Math.Max(0, y - 1)
                Return Me
            Case Keys.DownArrow
                y = Math.Min(Model.Rows - 1, y + 1)
                Return Me
            Case Keys.Spacebar, Keys.Enter
                Return CradleLocationMenuDialog.Launch(Context, Model.GetLocationModel(x, y), AddressOf Relaunch).Invoke()
            Case Else
                Return Me
        End Select
    End Function

    Protected Overrides Function Relaunch() As IDialog
        Return Launch(Context, Model, x, y).Invoke
    End Function
End Class
