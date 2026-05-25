Imports TGGD.Data

Public Class WorldData
    Inherits EntityData
    Public Property Factions As New Dictionary(Of Guid, FactionData)
    Public Property PlayerFactionId As Guid? = Nothing
End Class
