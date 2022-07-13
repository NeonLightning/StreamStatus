Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class gradiantwindow
    Dim tlc As New ColorDialog
    Dim trc As New ColorDialog
    Dim blc As New ColorDialog
    Dim brc As New ColorDialog
    Private Sub TopLeftButton_Click(sender As Object, e As EventArgs) Handles TopLeftButton.Click
        tlc.ShowDialog()
        tlc.Color = My.Forms.StatusUpdateGUIFrontend.TopLeftColor
    End Sub

    Private Sub TopRightButton_Click(sender As Object, e As EventArgs) Handles TopRightButton.Click
        trc.ShowDialog()
        trc.Color = My.Forms.StatusUpdateGUIFrontend.TopRightColor
    End Sub

    Private Sub BottomLeftButton_Click(sender As Object, e As EventArgs) Handles BottomLeftButton.Click
        blc.ShowDialog()
        blc.Color = My.Forms.StatusUpdateGUIFrontend.BottomLeftColor
    End Sub

    Private Sub BottomRightButton_Click(sender As Object, e As EventArgs) Handles BottomRightButton.Click
        brc.ShowDialog()
        blc.Color = My.Forms.StatusUpdateGUIFrontend.BottomRightColor
    End Sub

    Private Sub PreviewButton_Click(sender As Object, e As EventArgs) Handles PreviewButton.Click
        PreviewWindow.Dispose()
        My.Forms.StatusUpdateGUIFrontend.BackgrounPreviewImage = New Bitmap(320, 900)
        Dim bmp As New Bitmap(320, 900)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.Transparent)
        Dim path As New GraphicsPath()
        path.AddLine(New Point(0, 0), New Point(320, 0))
        path.AddLine(New Point(320, 0), New Point(320, 900))
        path.AddLine(New Point(320, 900), New Point(0, 900))
        path.AddLine(New Point(0, 900), New Point(0, 0))
        path.CloseFigure()
        Dim pathBrush As New PathGradientBrush(path)
        'Dim colors As Color() = {tlc.Color, trc.Color, blc.Color, brc.Color}
        Dim colors As Color() = {Color.Blue, Color.Red, Color.Green, Color.Yellow}
        pathBrush.SurroundColors = colors
        pathBrush.CenterColor = Color.Transparent
        g.FillRectangle(pathBrush, New Rectangle(0, 0, 320, 900))
        bmp.Save("base\background\streamstatusneongradient.png", System.Drawing.Imaging.ImageFormat.Png)
        File.Copy("base\background\streamstatusneongradient.png", "base\background\background.png", overwrite:=True)
        PreviewWindow.Image = Image.FromFile("base\background\streamstatusneongradient.png")
        PreviewWindow.Refresh()
        PreviewWindow.Dispose()
        File.Delete("base\background\streamstatusneongradient.png")
    End Sub

    Private Sub gradiantwindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PreviewWindow.Refresh()
        PreviewWindow.Dispose()
    End Sub

    Private Sub gradiantwindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        If System.IO.File.Exists("backgrounds\gradient.png") Then
            PreviewWindow.Image = Image.FromFile("backgrounds\gradient.png")
        End If
    End Sub
End Class