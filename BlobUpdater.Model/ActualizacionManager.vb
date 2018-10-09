Imports System.IO.Compression
Imports System.IO
Imports System.Reflection

Public Class ActualizacionManager

  Private repo As IActualizacionRepository
  Private log As ILoggingService

  Public Sub New(repo As IActualizacionRepository, log As ILoggingService)
    Me.repo = repo
    Me.log = log
  End Sub

  Public Function HayActualizaciones(nombreAplicacion As String, version As String)
    Dim ultimaActualizacion As Actualizacion = repo.ObtenerUltimaActualizacion(nombreAplicacion)
    Return ultimaActualizacion.Version <> version
  End Function

  Public Sub ActualizarAplicacion(nombreAplicacion)
    Dim actualizacion As Actualizacion = repo.ObtenerUltimaActualizacion(nombreAplicacion)
    If actualizacion Is Nothing Then
      log.Log("No hay actualizaciones")
    Else
      GuardarYExtraerZip(actualizacion.Contenido)
      RenombrarFicheros()
      InstalarFicheros()
      LimpiarFicherosTemporales()
      ReiniciarAplicacion()
    End If
  End Sub


  Public Sub AnadirActualizacion(nombreAplicacion As String, version As String, zipPath As String)
    Dim actualizacion As Actualizacion = New Actualizacion() With
    {
      .Aplicacion = nombreAplicacion,
      .Version = version,
      .Fecha = Now,
      .Contenido = File.ReadAllBytes(zipPath)
    }
    repo.GuardarActualizacion(actualizacion)
    log.Log(String.Format("Actualización guardada: {0} - v{1}", nombreAplicacion, version))
  End Sub

  Private Sub LimpiarFicherosTemporales()
    File.Delete(Constants.ZIP_FILE_PATH)
    Directory.Delete(Constants.TMP_DIR_PATH, True)
    log.Log("Ficheros temporales borrados")
  End Sub

  Private Sub InstalarFicheros()
    Environment.GetCommandLineArgs()
    Dim tmpDir = New DirectoryInfo(Constants.TMP_DIR_PATH)
    Dim files = tmpDir.GetFiles("*.*", SearchOption.AllDirectories)

    For Each file As FileInfo In files
      log.Log(String.Format("Instalando fichero: '{0}'", file.Name))
      Directory.CreateDirectory(New FileInfo(file.Name).DirectoryName)
      file.CopyTo(file.Name, True)
    Next
  End Sub

  Private Sub RenombrarFicheros()
    Dim thisProcess As Process = Process.GetCurrentProcess()
    Dim thisProcessFileName As String = thisProcess.MainModule.FileName

    Dim location As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
    For Each filePath In Directory.EnumerateFiles(location, "*.*", SearchOption.AllDirectories)
      Dim bak As String = filePath & ".bak"
      If File.Exists(bak) Then File.Delete(bak)
      File.Move(thisProcessFileName, bak)
      File.Copy(bak, thisProcessFileName)
      log.Log(String.Format("Copiando fichero {0} a {1}: '{0}'", filePath, bak))
    Next
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

  Private Sub ReiniciarAplicacion()
    Dim thisProcess As Process = Process.GetCurrentProcess()
    Dim thisProcessFileName As String = thisProcess.MainModule.FileName
    log.Log("Lanzando nuevo proceso")
    Dim spawn As Process = Process.Start(thisProcessFileName)
    log.Log(String.Format("GUID del nuevo proceso: {0}", spawn.Id))
    log.Log(String.Format("Cerrando proceso actual: {0}", thisProcess.Id))
    thisProcess.CloseMainWindow()
    thisProcess.Close()
    thisProcess.Dispose()
  End Sub
End Class
