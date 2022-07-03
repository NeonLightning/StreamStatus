Public Class SettingsForm
    Private Sub ModlistButton_Click(sender As Object, e As EventArgs) Handles ModlistButton.Click
        If ModlistForm.Visible = False Then
            ModlistForm.Show()
        Else
            ModlistForm.Close()
            ModlistForm.Show()
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
End Class