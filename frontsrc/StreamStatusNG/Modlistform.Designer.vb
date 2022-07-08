<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModlistForm
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
        Me.MainModList = New System.Windows.Forms.ListBox()
        Me.ModTextBox = New System.Windows.Forms.TextBox()
        Me.AddModButton = New System.Windows.Forms.Button()
        Me.DelModButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MainModList
        '
        Me.MainModList.FormattingEnabled = True
        Me.MainModList.Location = New System.Drawing.Point(0, 0)
        Me.MainModList.Name = "MainModList"
        Me.MainModList.Size = New System.Drawing.Size(284, 381)
        Me.MainModList.TabIndex = 0
        '
        'ModTextBox
        '
        Me.ModTextBox.Location = New System.Drawing.Point(0, 429)
        Me.ModTextBox.Name = "ModTextBox"
        Me.ModTextBox.Size = New System.Drawing.Size(284, 20)
        Me.ModTextBox.TabIndex = 1
        Me.ModTextBox.WordWrap = False
        '
        'AddModButton
        '
        Me.AddModButton.Location = New System.Drawing.Point(53, 387)
        Me.AddModButton.Name = "AddModButton"
        Me.AddModButton.Size = New System.Drawing.Size(75, 23)
        Me.AddModButton.TabIndex = 2
        Me.AddModButton.Text = "Add Mod"
        Me.AddModButton.UseVisualStyleBackColor = True
        '
        'DelModButton
        '
        Me.DelModButton.Location = New System.Drawing.Point(164, 387)
        Me.DelModButton.Name = "DelModButton"
        Me.DelModButton.Size = New System.Drawing.Size(75, 23)
        Me.DelModButton.TabIndex = 3
        Me.DelModButton.Text = "Del Mod"
        Me.DelModButton.UseVisualStyleBackColor = True
        '
        'ModlistForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 461)
        Me.Controls.Add(Me.DelModButton)
        Me.Controls.Add(Me.AddModButton)
        Me.Controls.Add(Me.ModTextBox)
        Me.Controls.Add(Me.MainModList)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 500)
        Me.Name = "ModlistForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modlist"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainModList As ListBox
    Friend WithEvents ModTextBox As TextBox
    Friend WithEvents AddModButton As Button
    Friend WithEvents DelModButton As Button
End Class
