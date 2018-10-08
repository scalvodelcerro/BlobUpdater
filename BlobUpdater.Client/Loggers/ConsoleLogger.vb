Imports BlobUpdater.Model

Friend Class ConsoleLogger
  Implements ILoggingService

  Public Sub Log(message As String) Implements ILoggingService.Log
    Console.WriteLine(message)
  End Sub
End Class
