Imports System.Runtime.CompilerServices
Imports CFOS.Business

Friend Module WorldExtensions
    <Extension>
    Friend Sub Initialize(world As IWorld, factionName As String)
        world.Clear()
        world.Player = world.CreateFaction()
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
