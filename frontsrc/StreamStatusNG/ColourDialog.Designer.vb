<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColourDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ColorPickerOkButton = New System.Windows.Forms.Button()
        Me.BaseColorDialog = New Cyotek.Windows.Forms.ColorEditor()
        Me.SuspendLayout()
        '
        'ColorPickerOkButton
        '
        Me.ColorPickerOkButton.Location = New System.Drawing.Point(78, 156)
        Me.ColorPickerOkButton.Name = "ColorPickerOkButton"
        Me.ColorPickerOkButton.Size = New System.Drawing.Size(37, 23)
        Me.ColorPickerOkButton.TabIndex = 3
        Me.ColorPickerOkButton.Text = "OK"
        Me.ColorPickerOkButton.UseVisualStyleBackColor = True
        '
        'BaseColorDialog
        '
        Me.BaseColorDialog.Color = System.Drawing.Color.Blue
        Me.BaseColorDialog.Location = New System.Drawing.Point(12, 12)
        Me.BaseColorDialog.Name = "BaseColorDialog"
        Me.BaseColorDialog.ShowHsl = False
        Me.BaseColorDialog.Size = New System.Drawing.Size(173, 138)
        Me.BaseColorDialog.TabIndex = 2
        '
        'ColourDialog
        '
        Me.AcceptButton = Me.ColorPickerOkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(197, 182)
        Me.ControlBox = False
        Me.Controls.Add(Me.ColorPickerOkButton)
        Me.Controls.Add(Me.BaseColorDialog)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(213, 221)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(213, 221)
        Me.Name = "ColourDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Form2"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ColorPickerOkButton As Button
    Friend WithEvents BaseColorDialog As Cyotek.Windows.Forms.ColorEditor
End Class
