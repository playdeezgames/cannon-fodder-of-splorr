Imports TGGD.Data

Public Class WorldData
    Inherits EntityData
    Public Property Factions As New Dictionary(Of Guid, FactionData)
    Public Property PlayerFactionId As Guid? = Nothing
    Public Property Areas As New Dictionary(Of Guid, AreaData)
    Public Property Features As New Dictionary(Of Guid, FeatureData)
    Public Property Locations As New Dictionary(Of Guid, LocationData)
End Class
