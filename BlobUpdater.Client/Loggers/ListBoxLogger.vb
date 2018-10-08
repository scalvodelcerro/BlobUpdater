Imports BlobUpdater.Model

Friend Class ListBoxLogger
  Implements ILoggingService

  Private listBox As ListBox

  Public Sub New(listBox As ListBox)
    Me.listBox = listBox
  End Sub

  Public Sub Log(message As String) Implements ILoggingService.Log
    listBox.Items.Add(message)
  End Sub
End Class
