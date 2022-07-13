Public Class ColourDialog
    Dim temp As Color = System.Drawing.Color.Transparent
    Private Sub ColorPickerOkButton_Click(sender As Object, e As EventArgs) Handles ColorPickerOkButton.Click
        My.Forms.SettingsForm.pickedColor = temp
        Me.Hide()
    End Sub

    Private Sub BaseColorDialog_ColorChanged(sender As Object, e As EventArgs) Handles BaseColorDialog.ColorChanged
        temp = BaseColorDialog.Color
    End Sub
End Class