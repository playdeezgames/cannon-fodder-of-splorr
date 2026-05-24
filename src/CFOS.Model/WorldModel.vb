Public Class WorldModel
    Inherits TGGD.Model.BaseModel
    Implements IWorldModel
    Private Sub New()

    End Sub
    Public Shared Function Create() As IWorldModel
        Return New WorldModel
    End Function
End Class
