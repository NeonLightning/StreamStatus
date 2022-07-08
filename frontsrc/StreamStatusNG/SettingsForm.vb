Imports System.ComponentModel

Public Class SettingsForm
    Private Sub SettingsForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If ModlistForm.Visible = True Then
            ModlistForm.Close()
        End If
    End Sub
    Private Sub ModlistButton_Click(sender As Object, e As EventArgs) Handles ModlistButton.Click
        If ModlistForm.Visible = False Then
            ModlistForm.Show()
        Else
            ModlistForm.Close()
        End If
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
        If My.Settings.QuicknotesOn = False Then
            QuicknotesCheckBox1.CheckState = CheckState.Unchecked
            QuicknotesCheckBox1.Text = "Quicknotes Disabled"
        Else
            QuicknotesCheckBox1.CheckState = CheckState.Checked
            QuicknotesCheckBox1.Text = "Quicknotes Enabled"
        End If
        If My.Settings.TimeSet = True Then
            TimeCheckBox1.CheckState = CheckState.Checked
            TimeCheckBox1.Text = "Time Enabled"
            TimeGroupBox1.Visible = True
        Else
            TimeCheckBox1.CheckState = CheckState.Unchecked
            TimeCheckBox1.Text = "Time Disabled"
            TimeGroupBox1.Visible = False
        End If
        If My.Settings.GameTimeSet = True Then
            GameTimeCheckBox1.CheckState = CheckState.Checked
            GameTimeCheckBox1.Text = "GameTime Enabled"
        Else
            GameTimeCheckBox1.CheckState = CheckState.Unchecked
            GameTimeCheckBox1.Text = "GameTime Disabled"
        End If
        If My.Settings.StreamTimeSet = True Then
            StreamTimeCheckBox1.CheckState = CheckState.Checked
            StreamTimeCheckBox1.Text = "StreamTime Enabled"
        Else
            StreamTimeCheckBox1.CheckState = CheckState.Unchecked
            StreamTimeCheckBox1.Text = "StreamTime Disabled"
        End If
    End Sub
    Private Sub GilDisplayBox_CheckedChanged(sender As Object, e As EventArgs) Handles GilDisplayBox.CheckedChanged
        If GilDisplayBox.Checked = True Then
            My.Settings.GilDisplay = True
            GilDisplayBox.Text = "Gil Enabled"
        Else
            My.Settings.GilDisplay = False
            GilDisplayBox.Text = "Gil Disabled"
        End If

    End Sub
    Private Sub WepBox_CheckedChanged(sender As Object, e As EventArgs) Handles WepBox.CheckedChanged
        If WepBox.Checked = True Then
            My.Settings.WpDisplay = True
            WepBox.Text = "Weapon Enabled"
        Else
            My.Settings.WpDisplay = False
            WepBox.Text = "Weapon Disabled"
        End If

    End Sub

    Private Sub ModlistCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles ModlistCheckbox.CheckedChanged
        If ModlistCheckbox.Checked = True Then
            My.Settings.ModList = True
            ModlistCheckbox.Text = "Modlist Enabled"
        Else
            My.Settings.ModList = False
            ModlistCheckbox.Text = "modlist Disabled"
        End If
    End Sub

    Private Sub LevelCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles LevelCheckbox.CheckedChanged
        If LevelCheckbox.Checked = True Then
            My.Settings.Level = True
            LevelCheckbox.Text = "Level Enabled"
        Else
            My.Settings.Level = False
            LevelCheckbox.Text = "Level Disabled"
        End If
    End Sub

    Private Sub DiscCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles DiscCheckBox1.CheckedChanged
        If DiscCheckBox1.Checked = True Then
            My.Settings.Discnums = True
            DiscCheckBox1.Text = "Disc Enabled"
        Else
            My.Settings.Discnums = False
            DiscCheckBox1.Text = "Disc Disabled"
        End If
    End Sub

    Private Sub LocCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles LocCheckBox1.CheckedChanged
        If LocCheckBox1.Checked = True Then
            My.Settings.LocSet = True
            LocCheckBox1.Text = "Location Enabled"
        Else
            My.Settings.LocSet = False
            LocCheckBox1.Text = "Location Disabled"
        End If
    End Sub

    Private Sub QuicknotesCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles QuicknotesCheckBox1.CheckedChanged
        If QuicknotesCheckBox1.Checked = True Then
            My.Settings.QuicknotesOn = True
            QuicknotesCheckBox1.Text = "Quicknotes Enabled"
        Else
            My.Settings.QuicknotesOn = False
            QuicknotesCheckBox1.Text = "Quicknotes Disabled"
        End If
    End Sub
    Private Sub TimeCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles TimeCheckBox1.CheckedChanged
        If TimeCheckBox1.Checked = True Then
            TimeCheckBox1.Text = "Time Enabled"
            My.Settings.TimeSet = True
            Me.TimeGroupBox1.Visible = True
        Else
            TimeCheckBox1.Text = "Time Disabled"
            My.Settings.TimeSet = False
            Me.TimeGroupBox1.Visible = False
        End If
    End Sub
    Private Sub GameTimeCheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles GameTimeCheckBox1.CheckedChanged
        If GameTimeCheckBox1.Checked = True Then
            My.Settings.GameTimeSet = True
            GameTimeCheckBox1.Text = "GameTime Enabled"
        Else
            My.Settings.GameTimeSet = False
            GameTimeCheckBox1.Text = "GameTime Disabled"
        End If
    End Sub
    Private Sub LocalTimeSetCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles LocalTimeSetCheckBox1.CheckedChanged
        If LocalTimeSetCheckBox1.Checked = True Then
            My.Settings.LocalTimeSet = True
            LocalTimeSetCheckBox1.Text = "LocalTime Enabled"
        Else
            My.Settings.LocalTimeSet = False
            LocalTimeSetCheckBox1.Text = "LocalTime Disabled"
        End If
    End Sub
    Private Sub StreamTimeCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles StreamTimeCheckBox1.CheckedChanged
        If StreamTimeCheckBox1.Checked = True Then
            My.Settings.StreamTimeSet = True
            StreamTimeCheckBox1.Text = "StreamTime Enabled"
        Else
            My.Settings.StreamTimeSet = False
            StreamTimeCheckBox1.Text = "StreamTime Disabled"
        End If
    End Sub
    Private Sub TimeGroupBox1_VisibleChanged(sender As Object, e As EventArgs) Handles TimeGroupBox1.VisibleChanged
        If TimeGroupBox1.Visible = True Then
            If My.Settings.LocalTimeSet = False Then
                LocalTimeSetCheckBox1.CheckState = CheckState.Unchecked
                LocalTimeSetCheckBox1.Text = "LocalTime Disabled"
            Else
                LocalTimeSetCheckBox1.CheckState = CheckState.Checked
                LocalTimeSetCheckBox1.Text = "LocalTime Enabled"
            End If
            If My.Settings.StreamTimeSet = False Then
                StreamTimeCheckBox1.CheckState = CheckState.Unchecked
                StreamTimeCheckBox1.Text = "StreamTime Disabled"
            Else
                StreamTimeCheckBox1.CheckState = CheckState.Checked
                StreamTimeCheckBox1.Text = "StreamTime Enabled"
            End If
            If My.Settings.GameTimeSet = False Then
                GameTimeCheckBox1.CheckState = CheckState.Unchecked
                GameTimeCheckBox1.Text = "GameTime Disabled"
            Else
                GameTimeCheckBox1.CheckState = CheckState.Checked
                GameTimeCheckBox1.Text = "GameTime Enabled"
            End If
        End If
    End Sub
End Class