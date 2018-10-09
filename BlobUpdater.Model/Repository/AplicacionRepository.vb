Public Class AplicacionRepository
  Implements IAplicacionRepository

  Public Function ObtenerAplicaciones() As List(Of Aplicacion) Implements IAplicacionRepository.ObtenerAplicaciones
    Using db = New BlobUpdaterContext()
      Return db.Aplicaciones.ToList()
    End Using
  End Function
End Class
