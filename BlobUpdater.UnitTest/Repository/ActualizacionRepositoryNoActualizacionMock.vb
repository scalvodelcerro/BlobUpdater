Imports BlobUpdater.Model

Public Class ActualizacionRepositoryNoActualizacionMock
  Implements IActualizacionRepository

  Public Function ObtenerUltimaActualizacion(nombreAplicacion As String) As Actualizacion Implements IActualizacionRepository.ObtenerUltimaActualizacion
    Return Nothing
  End Function

  Public Sub GuardarActualizacion(actualizacion As Actualizacion) Implements IActualizacionRepository.GuardarActualizacion
    Throw New NotImplementedException()
  End Sub
End Class
