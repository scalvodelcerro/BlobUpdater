Imports BlobUpdater.Model

Public Class FormActualizacion

  Private actualizacionManager As ActualizacionManager
  Private aplicacionRepo As IAplicacionRepository = New AplicacionRepository()

  Private Sub FormActualizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    actualizacionManager = New ActualizacionManager(New ActualizacionRepository, New ConsoleLogger())
    AplicacionBindingSource.DataSource = aplicacionRepo.ObtenerAplicaciones()


    LblAppVersion.Text = String.Format(LblAppVersion.Text, My.Application.Info.Version.ToString())
  End Sub

  Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
    actualizacionManager.AnadirActualizacion(CbAplicacion.SelectedValue, TbVersion.Text, TbFichero.Text)
  End Sub

  Private Sub TbFichero_DragDrop(sender As Object, e As DragEventArgs) Handles TbFichero.DragDrop
    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
      Dim files = e.Data.GetData(DataFormats.FileDrop)
      TbFichero.Text = files(0)
    End If
  End Sub

  Private Sub TbFichero_DragEnter(sender As Object, e As DragEventArgs) Handles TbFichero.DragEnter
    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
      e.Effect = DragDropEffects.Copy
    End If
  End Sub

  Private Sub BtnExplorar_Click(sender As Object, e As EventArgs) Handles BtnExplorar.Click
    FileDialog.FileName = TbFichero.Text
    FileDialog.ShowDialog()
  End Sub

  Private Sub FileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FileDialog.FileOk
    TbFichero.Text = FileDialog.FileName
  End Sub

End Class
