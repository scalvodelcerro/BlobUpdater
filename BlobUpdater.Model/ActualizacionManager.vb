Imports System.IO.Compression
Imports System.IO
Imports System.Text

Public Class ActualizacionManager

  Const ZIP_FILE_PATH As String = "contenido.zip"
  Const TMP_DIR_PATH As String = "c:\tmp\blob_update"

  Private repo As ActualizacionRepository
  Private log As ILoggingService

  Public Sub New(repo As ActualizacionRepository, log As ILoggingService)
    Me.repo = repo
    Me.log = log
  End Sub

  Public Function HayActualizaciones()
    Dim ultimaActualizacion As Actualizacion = repo.ObtenerUltimaActualizacion()
    Dim version = My.Application.Info.Version.ToString()
    Return ultimaActualizacion.Version <> version
  End Function

  Public Sub ActualizarAplicacion()
    Dim actualizacion As Actualizacion = repo.ObtenerUltimaActualizacion()
    If actualizacion Is Nothing Then
      log.Log("No hay actualizaciones")
    Else
      File.WriteAllBytes(ZIP_FILE_PATH, actualizacion.Contenido)
      log.Log("Fichero descargado de bbdd")
      If directory.Exists(TMP_DIR_PATH) Then
        directory.Delete(TMP_DIR_PATH, True)
      End If
      ZipFile.ExtractToDirectory(ZIP_FILE_PATH, TMP_DIR_PATH)
      log.Log("Fichero descomprimido")


      ' Renombrar ejecutable actual
      Dim thisProcess As Process = Process.GetCurrentProcess()
      Dim thisProcessFileName As String = thisProcess.MainModule.FileName
      Dim bak As String = thisProcessFileName & ".bak"
      log.Log(String.Format("Renombrando proceso a: '{0}'", bak))

      If File.Exists(bak) Then File.Delete(bak)
      File.Move(thisProcessFileName, bak)
      File.Copy(bak, thisProcessFileName)

      ' Copiar ficheros
      Dim tmpDir = New DirectoryInfo(TMP_DIR_PATH)
      Dim files = tmpDir.GetFiles("*.*", SearchOption.AllDirectories)

      For Each file As FileInfo In files
        log.Log(String.Format("Instalando fichero: '{0}'", file.Name))
        Directory.CreateDirectory(New FileInfo(file.Name).DirectoryName)
        file.CopyTo(file.Name, True)
      Next

      'Limpiar temporales
      File.Delete(ZIP_FILE_PATH)
      directory.Delete(TMP_DIR_PATH, True)
      log.Log("Ficheros temporales borrados")
    End If
  End Sub

End Class
