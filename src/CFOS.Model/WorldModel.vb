Public Class WorldModel
    Inherits TGGD.Model.BaseModel
    Implements IWorldModel
    Private Sub New()

    End Sub

    Public Property FactionName As String Implements IWorldModel.FactionName

    Public Shared Function Create(factionName As String) As IWorldModel
        Return New WorldModel With
            {
                .FactionName = factionName
            }
    End Function
End Class
