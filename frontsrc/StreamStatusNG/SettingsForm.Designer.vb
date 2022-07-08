<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        Me.GilDisplayBox = New System.Windows.Forms.CheckBox()
        Me.WepBox = New System.Windows.Forms.CheckBox()
        Me.ModlistButton = New System.Windows.Forms.Button()
        Me.ModlistCheckbox = New System.Windows.Forms.CheckBox()
        Me.LevelCheckbox = New System.Windows.Forms.CheckBox()
        Me.DiscCheckBox1 = New System.Windows.Forms.CheckBox()
        Me.LocCheckBox1 = New System.Windows.Forms.CheckBox()
        Me.QuicknotesCheckBox1 = New System.Windows.Forms.CheckBox()
        Me.LocalTimeSetCheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SettingsPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.CharSetBox = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.SettingsPanel.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GilDisplayBox
        '
        Me.GilDisplayBox.AutoSize = True
        Me.GilDisplayBox.Location = New System.Drawing.Point(3, 72)
        Me.GilDisplayBox.Name = "GilDisplayBox"
        Me.GilDisplayBox.Size = New System.Drawing.Size(75, 17)
        Me.GilDisplayBox.TabIndex = 0
        Me.GilDisplayBox.Text = "Gil Display"
        Me.GilDisplayBox.UseVisualStyleBackColor = True
        '
        'WepBox
        '
        Me.WepBox.AutoSize = True
        Me.WepBox.Location = New System.Drawing.Point(3, 26)
        Me.WepBox.Name = "WepBox"
        Me.WepBox.Size = New System.Drawing.Size(104, 17)
        Me.WepBox.TabIndex = 1
        Me.WepBox.Text = "Weapon Display"
        Me.WepBox.UseVisualStyleBackColor = True
        '
        'ModlistButton
        '
        Me.ModlistButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModlistButton.Location = New System.Drawing.Point(47, 141)
        Me.ModlistButton.Name = "ModlistButton"
        Me.ModlistButton.Size = New System.Drawing.Size(75, 23)
        Me.ModlistButton.TabIndex = 2
        Me.ModlistButton.Text = "Modlist"
        Me.ModlistButton.UseVisualStyleBackColor = True
        '
        'ModlistCheckbox
        '
        Me.ModlistCheckbox.AutoSize = True
        Me.ModlistCheckbox.Location = New System.Drawing.Point(3, 118)
        Me.ModlistCheckbox.Name = "ModlistCheckbox"
        Me.ModlistCheckbox.Size = New System.Drawing.Size(59, 17)
        Me.ModlistCheckbox.TabIndex = 3
        Me.ModlistCheckbox.Text = "Modlist"
        Me.ModlistCheckbox.UseVisualStyleBackColor = True
        '
        'LevelCheckbox
        '
        Me.LevelCheckbox.AutoSize = True
        Me.LevelCheckbox.Location = New System.Drawing.Point(3, 3)
        Me.LevelCheckbox.Name = "LevelCheckbox"
        Me.LevelCheckbox.Size = New System.Drawing.Size(89, 17)
        Me.LevelCheckbox.TabIndex = 4
        Me.LevelCheckbox.Text = "Level Display"
        Me.LevelCheckbox.UseVisualStyleBackColor = True
        '
        'DiscCheckBox1
        '
        Me.DiscCheckBox1.AutoSize = True
        Me.DiscCheckBox1.Location = New System.Drawing.Point(3, 26)
        Me.DiscCheckBox1.Name = "DiscCheckBox1"
        Me.DiscCheckBox1.Size = New System.Drawing.Size(84, 17)
        Me.DiscCheckBox1.TabIndex = 5
        Me.DiscCheckBox1.Text = "Disc Display"
        Me.DiscCheckBox1.UseVisualStyleBackColor = True
        '
        'LocCheckBox1
        '
        Me.LocCheckBox1.AutoSize = True
        Me.LocCheckBox1.Location = New System.Drawing.Point(3, 49)
        Me.LocCheckBox1.Name = "LocCheckBox1"
        Me.LocCheckBox1.Size = New System.Drawing.Size(104, 17)
        Me.LocCheckBox1.TabIndex = 6
        Me.LocCheckBox1.Text = "Location Display"
        Me.LocCheckBox1.UseVisualStyleBackColor = True
        '
        'QuicknotesCheckBox1
        '
        Me.QuicknotesCheckBox1.AutoSize = True
        Me.QuicknotesCheckBox1.Location = New System.Drawing.Point(3, 95)
        Me.QuicknotesCheckBox1.Name = "QuicknotesCheckBox1"
        Me.QuicknotesCheckBox1.Size = New System.Drawing.Size(119, 17)
        Me.QuicknotesCheckBox1.TabIndex = 7
        Me.QuicknotesCheckBox1.Text = "QuickNotes Display"
        Me.QuicknotesCheckBox1.UseVisualStyleBackColor = True
        '
        'LocalTimeSetCheckBox1
        '
        Me.LocalTimeSetCheckBox1.AutoSize = True
        Me.LocalTimeSetCheckBox1.Location = New System.Drawing.Point(3, 3)
        Me.LocalTimeSetCheckBox1.Name = "LocalTimeSetCheckBox1"
        Me.LocalTimeSetCheckBox1.Size = New System.Drawing.Size(112, 17)
        Me.LocalTimeSetCheckBox1.TabIndex = 8
        Me.LocalTimeSetCheckBox1.Text = "LocalTime Display"
        Me.LocalTimeSetCheckBox1.UseVisualStyleBackColor = True
        '
        'SettingsPanel
        '
        Me.SettingsPanel.AutoSize = True
        Me.SettingsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SettingsPanel.BackColor = System.Drawing.Color.Transparent
        Me.SettingsPanel.Controls.Add(Me.LocalTimeSetCheckBox1)
        Me.SettingsPanel.Controls.Add(Me.DiscCheckBox1)
        Me.SettingsPanel.Controls.Add(Me.LocCheckBox1)
        Me.SettingsPanel.Controls.Add(Me.GilDisplayBox)
        Me.SettingsPanel.Controls.Add(Me.QuicknotesCheckBox1)
        Me.SettingsPanel.Controls.Add(Me.ModlistCheckbox)
        Me.SettingsPanel.Controls.Add(Me.ModlistButton)
        Me.SettingsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.SettingsPanel.Location = New System.Drawing.Point(12, 12)
        Me.SettingsPanel.Name = "SettingsPanel"
        Me.SettingsPanel.Size = New System.Drawing.Size(125, 167)
        Me.SettingsPanel.TabIndex = 9
        '
        'CharSetBox
        '
        Me.CharSetBox.AutoSize = True
        Me.CharSetBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CharSetBox.BackColor = System.Drawing.Color.Transparent
        Me.CharSetBox.Location = New System.Drawing.Point(539, 107)
        Me.CharSetBox.Name = "CharSetBox"
        Me.CharSetBox.Size = New System.Drawing.Size(6, 5)
        Me.CharSetBox.TabIndex = 10
        Me.CharSetBox.TabStop = False
        Me.CharSetBox.Text = "Char Settings"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.LevelCheckbox)
        Me.FlowLayoutPanel1.Controls.Add(Me.WepBox)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 185)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(110, 46)
        Me.FlowLayoutPanel1.TabIndex = 10
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.CharSetBox)
        Me.Controls.Add(Me.SettingsPanel)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 500)
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "SettingsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Settings"
        Me.SettingsPanel.ResumeLayout(False)
        Me.SettingsPanel.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GilDisplayBox As CheckBox
    Friend WithEvents WepBox As CheckBox
    Friend WithEvents ModlistButton As Button
    Friend WithEvents ModlistCheckbox As CheckBox
    Friend WithEvents LevelCheckbox As CheckBox
    Friend WithEvents DiscCheckBox1 As CheckBox
    Friend WithEvents LocCheckBox1 As CheckBox
    Friend WithEvents QuicknotesCheckBox1 As CheckBox
    Friend WithEvents LocalTimeSetCheckBox1 As CheckBox
    Friend WithEvents SettingsPanel As FlowLayoutPanel
    Friend WithEvents CharSetBox As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
