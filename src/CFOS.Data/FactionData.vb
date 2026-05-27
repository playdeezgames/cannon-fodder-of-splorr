Imports TGGD.Data

Public Class FactionData
    Inherits EntityData
    Public Property CradleAreaId As Guid?
    Public Property UnitIds As New HashSet(Of Guid)
End Class
