Imports System.IO

Public Class Form1
  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    IniciarUpdater()
    LblVersion.Text = String.Format(LblVersion.Text, My.Application.Info.Version.ToString())
  End Sub

  Private Sub IniciarUpdater()
    If Directory.Exists("Updater") Then
      Dim updaterPath As String = Path.Combine(Directory.GetCurrentDirectory(), "Updater\BlobUpdater.DownloaderClient.exe")
      Dim psi As ProcessStartInfo = New ProcessStartInfo(updaterPath)
      Dim args As String = String.Format("-n {0} -v {1} -r {2}",
                                         My.Resources.AppName,
                                         My.Application.Info.Version.ToString(),
                                         Application.ExecutablePath)
      psi.Arguments = args
      Process.Start(psi)
    End If
  End Sub
End Class
