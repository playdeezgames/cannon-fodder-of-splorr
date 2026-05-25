Imports TGGD.Business

Public Interface IWorld
    Inherits IEntity
    Property Player As IFaction
    Function CreateFaction() As IFaction
End Interface
