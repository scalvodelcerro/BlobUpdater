
Public Interface IActualizacionRepository
  Function ObtenerUltimaActualizacion(nombreAplicacion As String) As Actualizacion
  Sub GuardarActualizacion(actualizacion As Actualizacion)
End Interface
