Imports System.IO
Imports BlobUpdater.Model
Imports NDesk.Options

Public Class FormPrincipal
  Private log As ListBoxLogger
  Private repo As ActualizacionRepository
  Private actualizacionManager As ActualizacionManager

  Private nombreAplicacion As String
  Private versionAplicacion As String
  Private rutaAplicacion As String

  Private optionSet As OptionSet = New OptionSet() From {
    {"n|nombre=", "{NOMBRE} de la aplicación a actualizar", Sub(v) Me.nombreAplicacion = v},
    {"v|version=", "{VERSION} actual de la aplicación a actualizar", Sub(v) Me.versionAplicacion = v},
    {"r|ruta=", "{RUTA} al ejecutable de la aplicación a actualizar", Sub(v) Me.rutaAplicacion = v}
  }

  Private Async Sub Form1_LoadAsync(sender As Object, e As EventArgs) Handles MyBase.Load
    Init()

    Dim args As String() = Environment.GetCommandLineArgs()
    Try
      optionSet.Parse(args)
    Catch ex As OptionException
      log.Log("Argumentos incorrectos")
      Close()
    End Try
    LblActualizando.Text = String.Format(LblActualizando.Text, nombreAplicacion)
    LblVersionOld.Text = String.Format(LblVersionOld.Text, versionAplicacion)

    Await Task.Run(Sub() LanzarActualizacion(args))
    Close()
  End Sub

  Private Sub LanzarActualizacion(args() As String)
    actualizacionManager = New ActualizacionManager(repo, log)

    If actualizacionManager.HayActualizaciones(nombreAplicacion, versionAplicacion) Then
      DetenerProcesos(rutaAplicacion)
      actualizacionManager.ActualizarAplicacion(nombreAplicacion, rutaAplicacion)
      IniciarAplicacion(rutaAplicacion, args)
    End If
  End Sub

  Private Sub Init()
    log = New ListBoxLogger(Me.ListBoxLog)
    repo = New ActualizacionRepository()
  End Sub

  Private Sub IniciarAplicacion(rutaAplicacion As String, arguments As String())
    Dim psi As ProcessStartInfo = New ProcessStartInfo(rutaAplicacion, String.Join(" ", arguments.Skip(1)))
    Process.Start(psi)
  End Sub

  Private Shared Sub DetenerProcesos(nombreEjecutable As String)
    For Each p In Process.GetProcessesByName(Path.GetFileName(nombreEjecutable))
      p.Kill()
    Next
    For Each p In Process.GetProcessesByName(Path.GetFileNameWithoutExtension(nombreEjecutable))
      p.Kill()
    Next
  End Sub
End Class
