Imports BlobUpdater.Model

Public Class FormPrincipal
  Private actualizacionManager As ActualizacionManager

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim args As String() = Environment.GetCommandLineArgs()

    actualizacionManager =
      New ActualizacionManager(New ActualizacionRepository(), New ListBoxLogger(Me.ListBoxLog))

    Dim nombreAplicacion = My.Resources.APP_NAME
    Dim version = My.Application.Info.Version.ToString()

    If actualizacionManager.HayActualizaciones(nombreAplicacion, version) Then
      actualizacionManager.ActualizarAplicacion(nombreAplicacion)
    End If
  End Sub
End Class
