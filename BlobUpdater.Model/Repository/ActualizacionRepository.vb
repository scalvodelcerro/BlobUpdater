Public Class ActualizacionRepository
  Implements IActualizacionRepository

  Public Function ObtenerUltimaActualizacion(nombreAplicacion As String) As Actualizacion Implements IActualizacionRepository.ObtenerUltimaActualizacion
    Using db = New BlobUpdaterContext()
      Return db.Actualizaciones.
        Where(Function(a) a.Aplicacion = nombreAplicacion).
        OrderByDescending(Function(a) a.Fecha).
        FirstOrDefault()
    End Using
  End Function

  Public Sub GuardarActualizacion(actualizacion As Actualizacion) Implements IActualizacionRepository.GuardarActualizacion
    Using db = New BlobUpdaterContext()
      db.Actualizaciones.Add(actualizacion)
      db.SaveChanges()
    End Using
  End Sub

End Class
