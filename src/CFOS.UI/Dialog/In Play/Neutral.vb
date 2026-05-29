Imports CFOS.Model
Imports TGGD.UI

Friend Module Neutral
    Friend Function GetNextDialog(context As IHostContext, model As IWorldModel) As Func(Of IDialog)
        Return CradleMenuDialog.Launch(
            context,
            model.CradleAreaModel,
            "Game Menu",
            GameMenuDialog.Launch(context, model, GetNextDialog(context, model)))
    End Function
End Module
