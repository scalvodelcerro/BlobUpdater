Public Class ActualizacionRepository

  Public Function ObtenerUltimaActualizacion() As Actualizacion
    Using db = New BlobUpdaterContext()
      Return db.Actualizaciones.
        OrderByDescending(Function(a) a.Fecha).
        FirstOrDefault()
    End Using
  End Function

End Class
