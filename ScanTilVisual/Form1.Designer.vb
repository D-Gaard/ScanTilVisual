<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormScanTilVisual
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ButtonTegn = New System.Windows.Forms.Button()
        Me.TextBoxInput = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SuspendLayout()
        '
        'ButtonTegn
        '
        Me.ButtonTegn.Location = New System.Drawing.Point(12, 38)
        Me.ButtonTegn.Name = "ButtonTegn"
        Me.ButtonTegn.Size = New System.Drawing.Size(135, 23)
        Me.ButtonTegn.TabIndex = 0
        Me.ButtonTegn.Text = "Optegn scaning"
        Me.ButtonTegn.UseVisualStyleBackColor = True
        '
        'TextBoxInput
        '
        Me.TextBoxInput.Location = New System.Drawing.Point(12, 67)
        Me.TextBoxInput.Name = "TextBoxInput"
        Me.TextBoxInput.Size = New System.Drawing.Size(135, 20)
        Me.TextBoxInput.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'FormScanTilVisual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 583)
        Me.Controls.Add(Me.TextBoxInput)
        Me.Controls.Add(Me.ButtonTegn)
        Me.Name = "FormScanTilVisual"
        Me.Text = "ScanToVisual"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonTegn As Button
    Friend WithEvents TextBoxInput As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
End Class
