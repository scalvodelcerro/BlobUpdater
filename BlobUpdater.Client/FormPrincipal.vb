Imports BlobUpdater.Model

Public Class FormPrincipal
  Private actualizacionManager As ActualizacionManager

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    actualizacionManager =
      New ActualizacionManager(New ActualizacionRepository(), New ListBoxLogger(Me.ListBoxLog))

    If actualizacionManager.HayActualizaciones() Then
      actualizacionManager.ActualizarAplicacion()
    End If
  End Sub
End Class
