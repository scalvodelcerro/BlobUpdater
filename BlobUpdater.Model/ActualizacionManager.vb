Imports System.IO.Compression
Imports System.IO

Public Class ActualizacionManager

  Private repo As IActualizacionRepository
  Private log As ILoggingService

  Public Sub New(repo As IActualizacionRepository, log As ILoggingService)
    Me.repo = repo
    Me.log = log
  End Sub

  Public Function HayActualizaciones(nombreAplicacion As String, version As String)
    Dim actualizacion As Actualizacion = repo.ObtenerUltimaActualizacion(nombreAplicacion)
    Return actualizacion.Version <> version
  End Function

  Public Sub ActualizarAplicacion(nombreAplicacion As String, rutaAplicacion As String)
    Dim actualizacion As Actualizacion = repo.ObtenerUltimaActualizacion(nombreAplicacion)
    If actualizacion Is Nothing Then
      log.Log("No hay actualizaciones")
    Else
      GuardarYExtraerZip(actualizacion.Contenido)
      InstalarFicheros(Path.GetDirectoryName(rutaAplicacion))
      LimpiarFicherosTemporales()
    End If
  End Sub

  Public Sub AnadirActualizacion(nombreAplicacion As String, versionAplicacion As String, zipPath As String)
    Dim actualizacion As Actualizacion = New Actualizacion() With
    {
      .Aplicacion = nombreAplicacion,
      .Version = versionAplicacion,
      .Fecha = Now,
      .Contenido = File.ReadAllBytes(zipPath)
    }
    repo.GuardarActualizacion(actualizacion)

  End Sub

  Private Sub GuardarYExtraerZip(contenido As Byte())
    File.WriteAllBytes(Constants.ZIP_FILE_PATH, contenido)
    log.Log("Fichero descargado de bbdd")
    If Directory.Exists(Constants.TMP_DIR_PATH) Then
      Directory.Delete(Constants.TMP_DIR_PATH, True)
    End If
    ZipFile.ExtractToDirectory(Constants.ZIP_FILE_PATH, Constants.TMP_DIR_PATH)
    log.Log("Fichero descomprimido")
  End Sub

  Private Sub InstalarFicheros(rutaInstalacion As String)
    Dim tmpDir = New DirectoryInfo(Constants.TMP_DIR_PATH)
    Dim files = tmpDir.GetFiles("*.*", SearchOption.TopDirectoryOnly)
    Directory.CreateDirectory(rutaInstalacion)

    For Each file As FileInfo In files
      log.Log(String.Format("Instalando fichero: '{0}'", file.Name))
      file.CopyTo(Path.Combine(rutaInstalacion, file.Name), True)
    Next
  End Sub

  Private Sub LimpiarFicherosTemporales()
    File.Delete(Constants.ZIP_FILE_PATH)
    Directory.Delete(Constants.TMP_DIR_PATH, True)
    log.Log("Ficheros temporales borrados")
  End Sub

End Class
