<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrincipal
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
    Me.ListBoxLog = New System.Windows.Forms.ListBox()
    Me.LblActualizando = New System.Windows.Forms.Label()
    Me.LblVersionOld = New System.Windows.Forms.Label()
    Me.LblVersionNew = New System.Windows.Forms.Label()
    Me.PbInstalacion = New System.Windows.Forms.ProgressBar()
    Me.SuspendLayout()
    '
    'ListBoxLog
    '
    Me.ListBoxLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ListBoxLog.FormattingEnabled = True
    Me.ListBoxLog.Location = New System.Drawing.Point(12, 87)
    Me.ListBoxLog.Name = "ListBoxLog"
    Me.ListBoxLog.Size = New System.Drawing.Size(564, 134)
    Me.ListBoxLog.TabIndex = 0
    '
    'LblActualizando
    '
    Me.LblActualizando.AutoSize = True
    Me.LblActualizando.Location = New System.Drawing.Point(12, 9)
    Me.LblActualizando.Name = "LblActualizando"
    Me.LblActualizando.Size = New System.Drawing.Size(94, 13)
    Me.LblActualizando.TabIndex = 1
    Me.LblActualizando.Text = "Actualizando {0}..."
    '
    'LblVersionOld
    '
    Me.LblVersionOld.AutoSize = True
    Me.LblVersionOld.Location = New System.Drawing.Point(12, 22)
    Me.LblVersionOld.Name = "LblVersionOld"
    Me.LblVersionOld.Size = New System.Drawing.Size(94, 13)
    Me.LblVersionOld.TabIndex = 2
    Me.LblVersionOld.Text = "Versión actual: {0}"
    '
    'LblVersionNew
    '
    Me.LblVersionNew.AutoSize = True
    Me.LblVersionNew.Location = New System.Drawing.Point(12, 35)
    Me.LblVersionNew.Name = "LblVersionNew"
    Me.LblVersionNew.Size = New System.Drawing.Size(125, 13)
    Me.LblVersionNew.TabIndex = 3
    Me.LblVersionNew.Text = "Versión más reciente: {0}"
    Me.LblVersionNew.Visible = False
    '
    'PbInstalacion
    '
    Me.PbInstalacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.PbInstalacion.Location = New System.Drawing.Point(12, 58)
    Me.PbInstalacion.Name = "PbInstalacion"
    Me.PbInstalacion.Size = New System.Drawing.Size(564, 23)
    Me.PbInstalacion.TabIndex = 4
    '
    'FormPrincipal
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(588, 245)
    Me.Controls.Add(Me.PbInstalacion)
    Me.Controls.Add(Me.LblVersionNew)
    Me.Controls.Add(Me.LblVersionOld)
    Me.Controls.Add(Me.LblActualizando)
    Me.Controls.Add(Me.ListBoxLog)
    Me.Name = "FormPrincipal"
    Me.Text = "Form1"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents ListBoxLog As ListBox
  Friend WithEvents LblActualizando As Label
  Friend WithEvents LblVersionOld As Label
  Friend WithEvents LblVersionNew As Label
  Friend WithEvents PbInstalacion As ProgressBar
End Class
