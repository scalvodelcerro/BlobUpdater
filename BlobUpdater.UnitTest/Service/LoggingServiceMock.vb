Imports BlobUpdater.Model

Public Class LoggingServiceMock
  Implements ILoggingService

  Public Property Messages As List(Of String) = New List(Of String)()

  Public Sub Log(message As String) Implements ILoggingService.Log
    Messages.Add(message)
  End Sub
End Class
