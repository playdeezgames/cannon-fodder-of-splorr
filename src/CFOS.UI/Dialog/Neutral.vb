Imports CFOS.Model
Imports TGGD.UI

Friend Module Neutral
    Friend Function GetNextDialog(context As IHostContext, model As IWorldModel) As Func(Of IDialog)
        Return InPlayDialog.Launch(context, model)
    End Function
End Module
