Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class SettingsForm
    Private Sub ModlistButton_Click(sender As Object, e As EventArgs) Handles ModlistButton.Click
        ModlistForm.ShowDialog()
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BackgroundDrop.Items.AddRange(My.Forms.StatusUpdateGUIFrontend.mybgArray)

        If My.Settings.TimeSet = True Then
            TimeCheckBox1.CheckState = CheckState.Checked
            TimeCheckBox1.Text = "Time Enabled"
            TimeGroupBox1.Visible = True
        Else
            TimeCheckBox1.CheckState = CheckState.Unchecked
            TimeCheckBox1.Text = "Time Disabled"
            TimeGroupBox1.Visible = False
        End If
        If My.Settings.LocalTimeSet = True Then
            LocalTimeSetCheckBox1.CheckState = CheckState.Checked
            LocalTimeSetCheckBox1.Text = "LocalTime Enabled"
        Else
            LocalTimeSetCheckBox1.CheckState = CheckState.Unchecked
            LocalTimeSetCheckBox1.Text = "LocalTime Disabled"
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


        If My.Settings.Discnums = False Then
            DiscCheckBox1.CheckState = CheckState.Unchecked
            DiscCheckBox1.Text = "Disc Disabled"
        Else
            DiscCheckBox1.CheckState = CheckState.Checked
            DiscCheckBox1.Text = "Disc Enabled"
        End If
        If My.Settings.LocSet = False Then
            LocCheckBox1.CheckState = CheckState.Unchecked
            LocCheckBox1.Text = "Location Disabled"
        Else
            LocCheckBox1.CheckState = CheckState.Checked
            LocCheckBox1.Text = "Location Enabled"
        End If
        If My.Settings.GilDisplay = False Then
            GilDisplayBox.CheckState = CheckState.Unchecked
            GilDisplayBox.Text = "Gil Disabled"
        Else
            GilDisplayBox.CheckState = CheckState.Checked
            GilDisplayBox.Text = "Gil Enabled"
        End If


        If My.Settings.PartySet = True Then
            PartyDisplayCheckBox1.CheckState = CheckState.Checked
            PartyDisplayCheckBox1.Text = "Party Enabled"
            PartyGroupBox1.Visible = True
        Else
            PartyDisplayCheckBox1.CheckState = CheckState.Unchecked
            PartyDisplayCheckBox1.Text = "Party Disabled"
            PartyGroupBox1.Visible = False
        End If
        If My.Settings.NameSet = True Then
            NameCheckBox1.CheckState = CheckState.Checked
            NameCheckBox1.Text = "Name Enabled"
        Else
            NameCheckBox1.CheckState = CheckState.Unchecked
            NameCheckBox1.Text = "Name Disabled"
        End If
        If My.Settings.HPSet = True Then
            HPCheckBox1.CheckState = CheckState.Checked
            HPCheckBox1.Text = "HP Enabled"
        Else
            HPCheckBox1.CheckState = CheckState.Unchecked
            HPCheckBox1.Text = "HP Disabled"
        End If
        If My.Settings.MPSet = True Then
            MPCheckBox1.CheckState = CheckState.Checked
            MPCheckBox1.Text = "MP Enabled"
        Else
            MPCheckBox1.CheckState = CheckState.Unchecked
            MPCheckBox1.Text = "MP Disabled"
        End If
        If My.Settings.Level = False Then
            LevelCheckbox.CheckState = CheckState.Unchecked
            LevelCheckbox.Text = "Level Disabled"
        Else
            LevelCheckbox.CheckState = CheckState.Checked
            LevelCheckbox.Text = "Level Enabled"
        End If
        If My.Settings.WpDisplay = False Then
            WepBox.CheckState = CheckState.Unchecked
            WepBox.Text = "Weapon Disabled"
        Else
            WepBox.CheckState = CheckState.Checked
            WepBox.Text = "Weapon Enabled"
        End If
        If My.Settings.ArDisplay = False Then
            ArDisplayCheckBox1.CheckState = CheckState.Unchecked
            ArDisplayCheckBox1.Text = "Armor Disabled"
        Else
            ArDisplayCheckBox1.CheckState = CheckState.Checked
            ArDisplayCheckBox1.Text = "Armor Enabled"
        End If
        If My.Settings.AcDisplay = False Then
            AcDisplayCheckBox1.CheckState = CheckState.Unchecked
            AcDisplayCheckBox1.Text = "Acces Disabled"
        Else
            AcDisplayCheckBox1.CheckState = CheckState.Checked
            AcDisplayCheckBox1.Text = "Acces Enabled"
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
    Private Sub GilDisplayBox_CheckedChanged(sender As Object, e As EventArgs) Handles GilDisplayBox.CheckedChanged
        If GilDisplayBox.Checked = True Then
            My.Settings.GilDisplay = True
            GilDisplayBox.Text = "Gil Enabled"
        Else
            My.Settings.GilDisplay = False
            GilDisplayBox.Text = "Gil Disabled"
        End If
    End Sub

    Private Sub PartyDisplayCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles PartyDisplayCheckBox1.CheckedChanged
        If PartyDisplayCheckBox1.Checked = True Then
            PartyDisplayCheckBox1.Text = "Party Enabled"
            My.Settings.PartySet = True
            Me.PartyGroupBox1.Visible = True
        Else
            PartyDisplayCheckBox1.Text = "Party Disabled"
            My.Settings.PartySet = False
            Me.PartyGroupBox1.Visible = False
        End If
    End Sub
    Private Sub NameCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles NameCheckBox1.CheckedChanged
        If NameCheckBox1.Checked = True Then
            My.Settings.NameSet = True
            NameCheckBox1.Text = "Name Enabled"
        Else
            My.Settings.NameSet = False
            NameCheckBox1.Text = "Name Disabled"
        End If
    End Sub
    Private Sub HPCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles HPCheckBox1.CheckedChanged
        If HPCheckBox1.Checked = True Then
            My.Settings.HPSet = True
            HPCheckBox1.Text = "HP Enabled"
        Else
            My.Settings.HPSet = False
            HPCheckBox1.Text = "HP Disabled"
        End If
    End Sub
    Private Sub MPCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MPCheckBox1.CheckedChanged
        If MPCheckBox1.Checked = True Then
            My.Settings.MPSet = True
            MPCheckBox1.Text = "MP Enabled"
        Else
            My.Settings.MPSet = False
            MPCheckBox1.Text = "MP Disabled"
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
    Private Sub WepBox_CheckedChanged(sender As Object, e As EventArgs) Handles WepBox.CheckedChanged
        If WepBox.Checked = True Then
            My.Settings.WpDisplay = True
            WepBox.Text = "Weapon Enabled"
        Else
            My.Settings.WpDisplay = False
            WepBox.Text = "Weapon Disabled"
        End If
    End Sub
    Private Sub ArDisplayCheckbox1_CheckedChanged(sender As Object, e As EventArgs) Handles ArDisplayCheckBox1.CheckedChanged
        If ArDisplayCheckBox1.Checked = True Then
            My.Settings.ArDisplay = True
            ArDisplayCheckBox1.Text = "Armor Enabled"
        Else
            My.Settings.ArDisplay = False
            ArDisplayCheckBox1.Text = "Armor Disabled"
        End If
    End Sub
    Private Sub AcDisplayCheckbox1_CheckedChanged(sender As Object, e As EventArgs) Handles AcDisplayCheckBox1.CheckedChanged
        If AcDisplayCheckBox1.Checked = True Then
            My.Settings.AcDisplay = True
            AcDisplayCheckBox1.Text = "Acces Enabled"
        Else
            My.Settings.AcDisplay = False
            AcDisplayCheckBox1.Text = "Acces Disabled"
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
    Private Sub ModlistCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles ModlistCheckbox.CheckedChanged
        If ModlistCheckbox.Checked = True Then
            My.Settings.ModList = True
            ModlistCheckbox.Text = "Modlist Enabled"
        Else
            My.Settings.ModList = False
            ModlistCheckbox.Text = "modlist Disabled"
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

    Public Sub BackgroundDrop_SelectedValueChanged(sender As Object, e As EventArgs) Handles BackgroundDrop.SelectedValueChanged
        Dim temp = My.Forms.StatusUpdateGUIFrontend.mybgArray(BackgroundDrop.SelectedIndex)
        My.Computer.FileSystem.CopyFile(temp, "base\background\background.png", overwrite:=True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bmp1 As New Bitmap(320, 900)
        Dim color1 As New Color
        Dim brush As New Drawing.Drawing2D.LinearGradientBrush(New PointF(0, 0), New PointF(bmp1.Width, bmp1.Height), color1, SystemColors.ControlDark)
        Dim gr As Graphics = Graphics.FromImage(bmp1)
        gr.FillRectangle(brush, New RectangleF(0, 0, bmp1.Width, bmp1.Height))
        bmp1.Save("backgrounds\background.png", System.Drawing.Imaging.ImageFormat.Png)
    End Sub
End Class