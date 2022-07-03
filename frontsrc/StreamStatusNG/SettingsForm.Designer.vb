﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.SuspendLayout()
        '
        'GilDisplayBox
        '
        Me.GilDisplayBox.AutoSize = True
        Me.GilDisplayBox.Location = New System.Drawing.Point(13, 13)
        Me.GilDisplayBox.Name = "GilDisplayBox"
        Me.GilDisplayBox.Size = New System.Drawing.Size(75, 17)
        Me.GilDisplayBox.TabIndex = 0
        Me.GilDisplayBox.Text = "Gil Display"
        Me.GilDisplayBox.UseVisualStyleBackColor = True
        '
        'WepBox
        '
        Me.WepBox.AutoSize = True
        Me.WepBox.Location = New System.Drawing.Point(13, 37)
        Me.WepBox.Name = "WepBox"
        Me.WepBox.Size = New System.Drawing.Size(104, 17)
        Me.WepBox.TabIndex = 1
        Me.WepBox.Text = "Weapon Display"
        Me.WepBox.UseVisualStyleBackColor = True
        '
        'ModlistButton
        '
        Me.ModlistButton.Location = New System.Drawing.Point(681, 426)
        Me.ModlistButton.Name = "ModlistButton"
        Me.ModlistButton.Size = New System.Drawing.Size(75, 23)
        Me.ModlistButton.TabIndex = 2
        Me.ModlistButton.Text = "Modlist"
        Me.ModlistButton.UseVisualStyleBackColor = True
        '
        'ModlistCheckbox
        '
        Me.ModlistCheckbox.AutoSize = True
        Me.ModlistCheckbox.Location = New System.Drawing.Point(681, 403)
        Me.ModlistCheckbox.Name = "ModlistCheckbox"
        Me.ModlistCheckbox.Size = New System.Drawing.Size(59, 17)
        Me.ModlistCheckbox.TabIndex = 3
        Me.ModlistCheckbox.Text = "Modlist"
        Me.ModlistCheckbox.UseVisualStyleBackColor = True
        '
        'LevelCheckbox
        '
        Me.LevelCheckbox.AutoSize = True
        Me.LevelCheckbox.Location = New System.Drawing.Point(12, 60)
        Me.LevelCheckbox.Name = "LevelCheckbox"
        Me.LevelCheckbox.Size = New System.Drawing.Size(89, 17)
        Me.LevelCheckbox.TabIndex = 4
        Me.LevelCheckbox.Text = "Level Display"
        Me.LevelCheckbox.UseVisualStyleBackColor = True
        '
        'DiscCheckBox1
        '
        Me.DiscCheckBox1.AutoSize = True
        Me.DiscCheckBox1.Location = New System.Drawing.Point(12, 83)
        Me.DiscCheckBox1.Name = "DiscCheckBox1"
        Me.DiscCheckBox1.Size = New System.Drawing.Size(84, 17)
        Me.DiscCheckBox1.TabIndex = 5
        Me.DiscCheckBox1.Text = "Disc Display"
        Me.DiscCheckBox1.UseVisualStyleBackColor = True
        '
        'LocCheckBox1
        '
        Me.LocCheckBox1.AutoSize = True
        Me.LocCheckBox1.Location = New System.Drawing.Point(13, 106)
        Me.LocCheckBox1.Name = "LocCheckBox1"
        Me.LocCheckBox1.Size = New System.Drawing.Size(104, 17)
        Me.LocCheckBox1.TabIndex = 6
        Me.LocCheckBox1.Text = "Location Display"
        Me.LocCheckBox1.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.LocCheckBox1)
        Me.Controls.Add(Me.DiscCheckBox1)
        Me.Controls.Add(Me.LevelCheckbox)
        Me.Controls.Add(Me.ModlistCheckbox)
        Me.Controls.Add(Me.ModlistButton)
        Me.Controls.Add(Me.WepBox)
        Me.Controls.Add(Me.GilDisplayBox)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 500)
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "SettingsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.GilDisplay = False Then
            GilDisplayBox.CheckState = CheckState.Unchecked
            GilDisplayBox.Text = "Gil Disabled"
        Else
            GilDisplayBox.CheckState = CheckState.Checked
            GilDisplayBox.Text = "Gil Enabled"
        End If
        If My.Settings.WpDisplay = False Then
            WepBox.CheckState = CheckState.Unchecked
            WepBox.Text = "Weapon Disabled"
        Else
            WepBox.CheckState = CheckState.Checked
            WepBox.Text = "Weapon Enabled"
        End If
        If My.Settings.Level = False Then
            LevelCheckbox.CheckState = CheckState.Unchecked
            LevelCheckbox.Text = "Level Disabled"
        Else
            LevelCheckbox.CheckState = CheckState.Checked
            LevelCheckbox.Text = "Level Enabled"
        End If
        If My.Settings.LocSet = False Then
            LocCheckBox1.CheckState = CheckState.Unchecked
            LocCheckBox1.Text = "Location Disabled"
        Else
            LocCheckBox1.CheckState = CheckState.Checked
            LocCheckBox1.Text = "Location Enabled"
        End If
        If My.Settings.Discnums = False Then
            DiscCheckBox1.CheckState = CheckState.Unchecked
            DiscCheckBox1.Text = "Disc Disabled"
        Else
            DiscCheckBox1.CheckState = CheckState.Checked
            DiscCheckBox1.Text = "Disc Enabled"
        End If
        If My.Settings.ModList = False Then
            ModlistCheckbox.CheckState = CheckState.Unchecked
            ModlistCheckbox.Text = "Modlist Disabled"
        Else
            ModlistCheckbox.CheckState = CheckState.Checked
            ModlistCheckbox.Text = "Modlist Enabled"
        End If

    End Sub

    Friend WithEvents GilDisplayBox As CheckBox
    Friend WithEvents WepBox As CheckBox
    Friend WithEvents ModlistButton As Button
    Friend WithEvents ModlistCheckbox As CheckBox
    Friend WithEvents LevelCheckbox As CheckBox
    Friend WithEvents DiscCheckBox1 As CheckBox
    Friend WithEvents LocCheckBox1 As CheckBox
End Class