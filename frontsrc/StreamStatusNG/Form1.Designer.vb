<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StatusUpdateGUIFrontend

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
        Me.LocationLabel = New System.Windows.Forms.Label()
        Me.Time = New System.Windows.Forms.Label()
        Me.PartyLabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Party = New System.Windows.Forms.Label()
        Me.Location = New System.Windows.Forms.Label()
        Me.LastEvent = New System.Windows.Forms.TextBox()
        Me.LastEventLabel = New System.Windows.Forms.Label()
        Me.CurrentNotes = New System.Windows.Forms.Label()
        Me.StatusIcon = New System.Windows.Forms.PictureBox()
        Me.Settings = New System.Windows.Forms.Button()
        CType(Me.StatusIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LocationLabel
        '
        Me.LocationLabel.AutoSize = True
        Me.LocationLabel.Location = New System.Drawing.Point(11, 36)
        Me.LocationLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LocationLabel.Name = "LocationLabel"
        Me.LocationLabel.Size = New System.Drawing.Size(54, 13)
        Me.LocationLabel.TabIndex = 1
        Me.LocationLabel.Text = "Location: "
        '
        'Time
        '
        Me.Time.AutoSize = True
        Me.Time.Location = New System.Drawing.Point(-2, 0)
        Me.Time.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Time.Name = "Time"
        Me.Time.Size = New System.Drawing.Size(224, 13)
        Me.Time.TabIndex = 1
        Me.Time.Text = "Time: Local (HH:MM:SS) Stream (HH:MM:SS)"
        '
        'PartyLabel
        '
        Me.PartyLabel.AutoSize = True
        Me.PartyLabel.Location = New System.Drawing.Point(11, 19)
        Me.PartyLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.PartyLabel.Name = "PartyLabel"
        Me.PartyLabel.Size = New System.Drawing.Size(34, 13)
        Me.PartyLabel.TabIndex = 1
        Me.PartyLabel.Text = "Party:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Party
        '
        Me.Party.AutoSize = True
        Me.Party.Location = New System.Drawing.Point(65, 19)
        Me.Party.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Party.Name = "Party"
        Me.Party.Size = New System.Drawing.Size(0, 13)
        Me.Party.TabIndex = 1
        '
        'Location
        '
        Me.Location.AutoSize = True
        Me.Location.Location = New System.Drawing.Point(65, 36)
        Me.Location.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Location.Name = "Location"
        Me.Location.Size = New System.Drawing.Size(0, 13)
        Me.Location.TabIndex = 1
        '
        'LastEvent
        '
        Me.LastEvent.Location = New System.Drawing.Point(1, 97)
        Me.LastEvent.Margin = New System.Windows.Forms.Padding(2)
        Me.LastEvent.Name = "LastEvent"
        Me.LastEvent.Size = New System.Drawing.Size(482, 20)
        Me.LastEvent.TabIndex = 2
        '
        'LastEventLabel
        '
        Me.LastEventLabel.AutoSize = True
        Me.LastEventLabel.Location = New System.Drawing.Point(-2, 82)
        Me.LastEventLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LastEventLabel.Name = "LastEventLabel"
        Me.LastEventLabel.Size = New System.Drawing.Size(35, 13)
        Me.LastEventLabel.TabIndex = 1
        Me.LastEventLabel.Text = "Notes"
        '
        'CurrentNotes
        '
        Me.CurrentNotes.AutoSize = True
        Me.CurrentNotes.Location = New System.Drawing.Point(39, 82)
        Me.CurrentNotes.Name = "CurrentNotes"
        Me.CurrentNotes.Size = New System.Drawing.Size(0, 13)
        Me.CurrentNotes.TabIndex = 1
        '
        'StatusIcon
        '
        Me.StatusIcon.ErrorImage = Global.StreamStatusNeon.My.Resources.Resources._error
        Me.StatusIcon.InitialImage = Global.StreamStatusNeon.My.Resources.Resources._stop
        Me.StatusIcon.Location = New System.Drawing.Point(425, 9)
        Me.StatusIcon.Margin = New System.Windows.Forms.Padding(0)
        Me.StatusIcon.Name = "StatusIcon"
        Me.StatusIcon.Size = New System.Drawing.Size(50, 50)
        Me.StatusIcon.TabIndex = 4
        Me.StatusIcon.TabStop = False
        '
        'Settings
        '
        Me.Settings.Location = New System.Drawing.Point(408, 72)
        Me.Settings.Name = "Settings"
        Me.Settings.Size = New System.Drawing.Size(75, 23)
        Me.Settings.TabIndex = 5
        Me.Settings.Text = "Settings"
        Me.Settings.UseVisualStyleBackColor = True
        '
        'StatusUpdateGUIFrontend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 117)
        Me.Controls.Add(Me.Settings)
        Me.Controls.Add(Me.StatusIcon)
        Me.Controls.Add(Me.CurrentNotes)
        Me.Controls.Add(Me.LastEvent)
        Me.Controls.Add(Me.LastEventLabel)
        Me.Controls.Add(Me.Location)
        Me.Controls.Add(Me.Party)
        Me.Controls.Add(Me.PartyLabel)
        Me.Controls.Add(Me.Time)
        Me.Controls.Add(Me.LocationLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.StreamStatusNeon.My.Resources.Resources.Icon
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(500, 156)
        Me.MinimumSize = New System.Drawing.Size(500, 156)
        Me.Name = "StatusUpdateGUIFrontend"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "FF7 Stream Status Overlay: Live Updater"
        CType(Me.StatusIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Private Sub LastEvent_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LastEvent.KeyDown
        If Started = True Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                e.SuppressKeyPress = True
                CurrentNotes.Text = LTrim(LastEvent.Text)
                committedLastEvent = LTrim(LastEvent.Text)
                My.Settings.quicknotes = LTrim(LastEvent.Text)
                ScreenUpdate()
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Settings.Click
        If SettingsForm.Visible = False Then
            SettingsForm.Show()
        Else
            SettingsForm.Close()
            SettingsForm.Show()
        End If
    End Sub
    Friend WithEvents LocationLabel As System.Windows.Forms.Label
    Friend WithEvents Time As System.Windows.Forms.Label
    Friend WithEvents PartyLabel As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Party As System.Windows.Forms.Label
#Disable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'
    Friend WithEvents Location As System.Windows.Forms.Label
    Friend WithEvents LastEvent As TextBox
    Friend WithEvents LastEventLabel As Label
    Friend WithEvents CurrentNotes As Label
    Friend WithEvents StatusIcon As PictureBox
    Friend WithEvents Settings As Button
#Enable Warning BC40004 ' Member conflicts with member in the base type and should be declared 'Shadows'

End Class
