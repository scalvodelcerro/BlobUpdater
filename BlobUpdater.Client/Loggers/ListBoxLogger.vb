Imports BlobUpdater.Model

Friend Class ListBoxLogger
  Implements ILoggingService

  Private listBox As ListBox

  Public Sub New(listBox As ListBox)
    Me.listBox = listBox
  End Sub

  Delegate Sub LogCallback(message As String)
  Public Sub Log(message As String) Implements ILoggingService.Log
    If listBox.InvokeRequired Then
      listBox.Invoke(New LogCallback(AddressOf Log), {message})
    Else
      listBox.Items.Add(message)
    End If

  End Sub
End Class
