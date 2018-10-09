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
    Me.SuspendLayout()
    '
    'ListBoxLog
    '
    Me.ListBoxLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ListBoxLog.FormattingEnabled = True
    Me.ListBoxLog.Location = New System.Drawing.Point(12, 12)
    Me.ListBoxLog.Name = "ListBoxLog"
    Me.ListBoxLog.Size = New System.Drawing.Size(471, 251)
    Me.ListBoxLog.TabIndex = 0
    '
    'FormPrincipal
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(495, 276)
    Me.Controls.Add(Me.ListBoxLog)
    Me.Name = "FormPrincipal"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents ListBoxLog As ListBox
End Class
