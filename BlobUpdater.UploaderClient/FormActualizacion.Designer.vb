<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormActualizacion
  Inherits System.Windows.Forms.Form

  'Form reemplaza a Dispose para limpiar la lista de componentes.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Requerido por el Diseñador de Windows Forms
  Private components As System.ComponentModel.IContainer

  'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
  'Se puede modificar usando el Diseñador de Windows Forms.  
  'No lo modifique con el editor de código.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TbFichero = New System.Windows.Forms.TextBox()
    Me.TbVersion = New System.Windows.Forms.TextBox()
    Me.LblFichero = New System.Windows.Forms.Label()
    Me.LblNombreAplicacion = New System.Windows.Forms.Label()
    Me.LblVersion = New System.Windows.Forms.Label()
    Me.BtnGuardar = New System.Windows.Forms.Button()
    Me.BtnExplorar = New System.Windows.Forms.Button()
    Me.FileDialog = New System.Windows.Forms.OpenFileDialog()
    Me.CbAplicacion = New System.Windows.Forms.ComboBox()
    Me.AplicacionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.LblAppVersion = New System.Windows.Forms.Label()
    CType(Me.AplicacionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TbFichero
    '
    Me.TbFichero.AllowDrop = True
    Me.TbFichero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TbFichero.Location = New System.Drawing.Point(77, 12)
    Me.TbFichero.Name = "TbFichero"
    Me.TbFichero.Size = New System.Drawing.Size(245, 20)
    Me.TbFichero.TabIndex = 0
    '
    'TbVersion
    '
    Me.TbVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TbVersion.Location = New System.Drawing.Point(77, 64)
    Me.TbVersion.Name = "TbVersion"
    Me.TbVersion.Size = New System.Drawing.Size(245, 20)
    Me.TbVersion.TabIndex = 2
    '
    'LblFichero
    '
    Me.LblFichero.AutoSize = True
    Me.LblFichero.Location = New System.Drawing.Point(26, 15)
    Me.LblFichero.Name = "LblFichero"
    Me.LblFichero.Size = New System.Drawing.Size(45, 13)
    Me.LblFichero.TabIndex = 3
    Me.LblFichero.Text = "Fichero:"
    '
    'LblNombreAplicacion
    '
    Me.LblNombreAplicacion.AutoSize = True
    Me.LblNombreAplicacion.Location = New System.Drawing.Point(12, 41)
    Me.LblNombreAplicacion.Name = "LblNombreAplicacion"
    Me.LblNombreAplicacion.Size = New System.Drawing.Size(59, 13)
    Me.LblNombreAplicacion.TabIndex = 4
    Me.LblNombreAplicacion.Text = "Aplicación:"
    '
    'LblVersion
    '
    Me.LblVersion.AutoSize = True
    Me.LblVersion.Location = New System.Drawing.Point(26, 67)
    Me.LblVersion.Name = "LblVersion"
    Me.LblVersion.Size = New System.Drawing.Size(45, 13)
    Me.LblVersion.TabIndex = 5
    Me.LblVersion.Text = "Versión:"
    '
    'BtnGuardar
    '
    Me.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
    Me.BtnGuardar.Location = New System.Drawing.Point(170, 101)
    Me.BtnGuardar.Name = "BtnGuardar"
    Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
    Me.BtnGuardar.TabIndex = 6
    Me.BtnGuardar.Text = "Guardar"
    Me.BtnGuardar.UseVisualStyleBackColor = True
    '
    'BtnExplorar
    '
    Me.BtnExplorar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.BtnExplorar.Location = New System.Drawing.Point(328, 10)
    Me.BtnExplorar.Name = "BtnExplorar"
    Me.BtnExplorar.Size = New System.Drawing.Size(75, 23)
    Me.BtnExplorar.TabIndex = 7
    Me.BtnExplorar.Text = "Explorar..."
    Me.BtnExplorar.UseVisualStyleBackColor = True
    '
    'FileDialog
    '
    '
    'CbAplicacion
    '
    Me.CbAplicacion.DataSource = Me.AplicacionBindingSource
    Me.CbAplicacion.DisplayMember = "Nombre"
    Me.CbAplicacion.FormattingEnabled = True
    Me.CbAplicacion.Location = New System.Drawing.Point(77, 38)
    Me.CbAplicacion.Name = "CbAplicacion"
    Me.CbAplicacion.Size = New System.Drawing.Size(245, 21)
    Me.CbAplicacion.TabIndex = 8
    Me.CbAplicacion.ValueMember = "Nombre"
    '
    'AplicacionBindingSource
    '
    Me.AplicacionBindingSource.DataSource = GetType(BlobUpdater.Model.Aplicacion)
    Me.AplicacionBindingSource.Sort = "Nombre"
    '
    'LblAppVersion
    '
    Me.LblAppVersion.AutoSize = True
    Me.LblAppVersion.Location = New System.Drawing.Point(12, 114)
    Me.LblAppVersion.Name = "LblAppVersion"
    Me.LblAppVersion.Size = New System.Drawing.Size(62, 13)
    Me.LblAppVersion.TabIndex = 9
    Me.LblAppVersion.Text = "Versión: {0}"
    Me.LblAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'FormActualizacion
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(415, 136)
    Me.Controls.Add(Me.LblAppVersion)
    Me.Controls.Add(Me.CbAplicacion)
    Me.Controls.Add(Me.BtnExplorar)
    Me.Controls.Add(Me.BtnGuardar)
    Me.Controls.Add(Me.LblVersion)
    Me.Controls.Add(Me.LblNombreAplicacion)
    Me.Controls.Add(Me.LblFichero)
    Me.Controls.Add(Me.TbVersion)
    Me.Controls.Add(Me.TbFichero)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.Name = "FormActualizacion"
    Me.Text = "Subida de versiones"
    CType(Me.AplicacionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents TbFichero As TextBox
  Friend WithEvents TbVersion As TextBox
  Friend WithEvents LblFichero As Label
  Friend WithEvents LblNombreAplicacion As Label
  Friend WithEvents LblVersion As Label
  Friend WithEvents BtnGuardar As Button
  Friend WithEvents BtnExplorar As Button
  Friend WithEvents FileDialog As OpenFileDialog
  Friend WithEvents CbAplicacion As ComboBox
  Friend WithEvents AplicacionBindingSource As BindingSource
  Friend WithEvents LblAppVersion As Label
End Class
