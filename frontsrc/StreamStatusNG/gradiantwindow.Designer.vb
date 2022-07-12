<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gradiantwindow
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
        Me.BottomRightButton = New System.Windows.Forms.Button()
        Me.BottomLeftButton = New System.Windows.Forms.Button()
        Me.TopRightButton = New System.Windows.Forms.Button()
        Me.TopLeftButton = New System.Windows.Forms.Button()
        Me.PreviewWindow = New System.Windows.Forms.PictureBox()
        Me.TopLeftColorDialog = New System.Windows.Forms.ColorDialog()
        Me.TopRightColorDialog = New System.Windows.Forms.ColorDialog()
        Me.BottomLeftColorDialog = New System.Windows.Forms.ColorDialog()
        Me.BottomRightColorDialog = New System.Windows.Forms.ColorDialog()
        Me.PreviewButton = New System.Windows.Forms.Button()
        CType(Me.PreviewWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BottomRightButton
        '
        Me.BottomRightButton.Location = New System.Drawing.Point(78, 32)
        Me.BottomRightButton.Name = "BottomRightButton"
        Me.BottomRightButton.Size = New System.Drawing.Size(75, 23)
        Me.BottomRightButton.TabIndex = 24
        Me.BottomRightButton.Text = "BottomRight"
        Me.BottomRightButton.UseVisualStyleBackColor = True
        '
        'BottomLeftButton
        '
        Me.BottomLeftButton.Location = New System.Drawing.Point(2, 32)
        Me.BottomLeftButton.Name = "BottomLeftButton"
        Me.BottomLeftButton.Size = New System.Drawing.Size(75, 23)
        Me.BottomLeftButton.TabIndex = 23
        Me.BottomLeftButton.Text = "BottomLeft"
        Me.BottomLeftButton.UseVisualStyleBackColor = True
        '
        'TopRightButton
        '
        Me.TopRightButton.Location = New System.Drawing.Point(78, 3)
        Me.TopRightButton.Name = "TopRightButton"
        Me.TopRightButton.Size = New System.Drawing.Size(75, 23)
        Me.TopRightButton.TabIndex = 22
        Me.TopRightButton.Text = "TopRight"
        Me.TopRightButton.UseVisualStyleBackColor = True
        '
        'TopLeftButton
        '
        Me.TopLeftButton.Location = New System.Drawing.Point(2, 3)
        Me.TopLeftButton.Name = "TopLeftButton"
        Me.TopLeftButton.Size = New System.Drawing.Size(75, 23)
        Me.TopLeftButton.TabIndex = 21
        Me.TopLeftButton.Text = "TopLeft"
        Me.TopLeftButton.UseVisualStyleBackColor = True
        '
        'PreviewWindow
        '
        Me.PreviewWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PreviewWindow.Location = New System.Drawing.Point(159, 5)
        Me.PreviewWindow.MaximumSize = New System.Drawing.Size(320, 900)
        Me.PreviewWindow.MinimumSize = New System.Drawing.Size(320, 900)
        Me.PreviewWindow.Name = "PreviewWindow"
        Me.PreviewWindow.Size = New System.Drawing.Size(320, 900)
        Me.PreviewWindow.TabIndex = 25
        Me.PreviewWindow.TabStop = False
        '
        'PreviewButton
        '
        Me.PreviewButton.Location = New System.Drawing.Point(39, 73)
        Me.PreviewButton.Name = "PreviewButton"
        Me.PreviewButton.Size = New System.Drawing.Size(75, 23)
        Me.PreviewButton.TabIndex = 26
        Me.PreviewButton.Text = "Preview"
        Me.PreviewButton.UseVisualStyleBackColor = True
        '
        'gradiantwindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 909)
        Me.Controls.Add(Me.PreviewButton)
        Me.Controls.Add(Me.PreviewWindow)
        Me.Controls.Add(Me.BottomRightButton)
        Me.Controls.Add(Me.BottomLeftButton)
        Me.Controls.Add(Me.TopRightButton)
        Me.Controls.Add(Me.TopLeftButton)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gradiantwindow"
        Me.Text = "gradiantwindow"
        CType(Me.PreviewWindow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BottomRightButton As Button
    Friend WithEvents BottomLeftButton As Button
    Friend WithEvents TopRightButton As Button
    Friend WithEvents TopLeftButton As Button
    Friend WithEvents PreviewWindow As PictureBox
    Friend WithEvents TopLeftColorDialog As ColorDialog
    Friend WithEvents TopRightColorDialog As ColorDialog
    Friend WithEvents BottomLeftColorDialog As ColorDialog
    Friend WithEvents BottomRightColorDialog As ColorDialog
    Friend WithEvents PreviewButton As Button
End Class
