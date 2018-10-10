Imports System.Text
Imports BlobUpdater.Model

Public Class FormActualizacion

  Private actualizacionManager As ActualizacionManager
  Private aplicacionRepo As IAplicacionRepository = New AplicacionRepository()
  Private valido As Boolean

  Private Sub FormActualizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    actualizacionManager = New ActualizacionManager(New ActualizacionRepository, New ConsoleLogger())
    AplicacionBindingSource.DataSource = aplicacionRepo.ObtenerAplicaciones()
  End Sub

  Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
    ValidarCampos()
    If valido Then
      Try
        Dim nombreAplicacion As String = CbAplicacion.SelectedValue
        Dim versionAplicacion As String = TbVersion.Text
        Dim rutaFichero As String = TbFichero.Text

        actualizacionManager.AnadirActualizacion(nombreAplicacion, versionAplicacion, rutaFichero)
        TbFichero.Clear()
        TbVersion.Clear()
        MessageBox.Show(Me, String.Format("Actualización guardada: {0} - v{1}", nombreAplicacion, versionAplicacion), "Correcto")
      Catch ex As Exception
        MessageBox.Show(Me, String.Format("Error al guardar la actualización: {0}", ComponerMensajeExcepcion(ex)), "Error")
      End Try
    End If
  End Sub

  Private Sub ValidarCampos()
    Me.valido = True
    For Each textBox In Me.Controls.OfType(Of TextBox)
      textBox.Focus()
      Validate()
    Next
  End Sub

  Private Shared Function ComponerMensajeExcepcion(ex As Exception)
    Dim sbMessage As StringBuilder = New StringBuilder()
    Do
      sbMessage.AppendLine(ex.Message)
      ex = ex.InnerException
    Loop While ex IsNot Nothing

    Return sbMessage.ToString()
  End Function

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

  Private Sub TextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TbFichero.Validating, TbVersion.Validating
    Dim textBox As TextBox = sender
    If String.IsNullOrEmpty(textBox.Text) Then
      textBox.BackColor = Color.Pink
      valido = False
    Else
      textBox.BackColor = SystemColors.Window
    End If
  End Sub
End Class
