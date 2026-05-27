Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module WorldExtensions
    Private ReadOnly initialCradleMap As String() =
        {
            "##+##",
            "#@.@#",
            "#...#",
            "#@.@#",
            "#...#",
            "#@.@#",
            "#####"
        }
#Disable Warning CA1859 ' Use concrete types when possible for improved performance
    Private ReadOnly locationTypeLegend As IReadOnlyDictionary(Of Char, String) =
        New Dictionary(Of Char, String) From
        {
            {"#"c, LocationTypes.BULKHEAD},
            {"+"c, LocationTypes.HATCH},
            {"@"c, LocationTypes.DECK},
            {"."c, LocationTypes.DECK}
        }
#Enable Warning CA1859 ' Use concrete types when possible for improved performance
#Disable Warning CA1859 ' Use concrete types when possible for improved performance
    Private ReadOnly featureTypeLegend As IReadOnlyDictionary(Of Char, String) =
        New Dictionary(Of Char, String) From
        {
            {"@"c, FeatureTypes.CRYO_POD}
        }
#Enable Warning CA1859 ' Use concrete types when possible for improved performance
    <Extension>
    Friend Sub Initialize(world As IWorld, factionName As String)
        world.Clear()
        Dim faction = world.CreateFaction()
        Dim cradle = world.CreateArea(initialCradleMap(0).Length, initialCradleMap.Length)
        cradle.SetAreaType(AreaTypes.CRADLE)
        For Each row In Enumerable.Range(0, initialCradleMap.Length)
            Dim line = initialCradleMap(row)
            For Each column In Enumerable.Range(0, line.Length)
                Dim character = line(column)
                Dim location = cradle.GetLocation(column, row)
                location.SetLocationType(locationTypeLegend(character))
                Dim featureType As String = Nothing
                If featureTypeLegend.TryGetValue(character, featureType) Then
                    Dim feature = location.CreateFeature()
                    feature.SetFeatureType(featureType)
                End If
            Next
        Next
        faction.Cradle = cradle
        world.Player = faction
        world.SetFactionName(factionName)
    End Sub
    <Extension>
    Friend Sub SetFactionName(world As IWorld, factionName As String)
        world.Player.SetMetadata(Metadatas.FACTION_NAME, factionName)
    End Sub
    <Extension>
    Friend Function GetFactionName(world As IWorld) As String
        Return world.Player.GetMetadata(Metadatas.FACTION_NAME)
    End Function
End Module
