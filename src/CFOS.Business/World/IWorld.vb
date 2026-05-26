Imports TGGD.Business

Public Interface IWorld
    Inherits IEntity
    Property Player As IFaction
    Function CreateFaction() As IFaction
    Function CreateArea(columns As Integer, rows As Integer) As IArea
End Interface
