Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class gradiantwindow
    Dim tlc As New ColorDialog
    Dim trc As New ColorDialog
    Dim blc As New ColorDialog
    Dim brc As New ColorDialog
    Private Sub TopLeftButton_Click(sender As Object, e As EventArgs) Handles TopLeftButton.Click
        tlc.ShowDialog()
        My.Forms.StatusUpdateGUIFrontend.TopLeftColor = tlc.Color
    End Sub

    Private Sub TopRightButton_Click(sender As Object, e As EventArgs) Handles TopRightButton.Click
        trc.ShowDialog()
        My.Forms.StatusUpdateGUIFrontend.TopRightColor = trc.Color
    End Sub

    Private Sub BottomLeftButton_Click(sender As Object, e As EventArgs) Handles BottomLeftButton.Click
        blc.ShowDialog()
        My.Forms.StatusUpdateGUIFrontend.BottomLeftColor = blc.Color
    End Sub

    Private Sub BottomRightButton_Click(sender As Object, e As EventArgs) Handles BottomRightButton.Click
        brc.ShowDialog()
        My.Forms.StatusUpdateGUIFrontend.BottomRightColor = blc.Color
    End Sub

    Private Sub PreviewButton_Click(sender As Object, e As EventArgs) Handles PreviewButton.Click
        My.Forms.StatusUpdateGUIFrontend.BackgrounPreviewImage = New Bitmap(320, 900)
        Dim bmp As New Bitmap(320, 900)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.Transparent)
        Dim path As New GraphicsPath()
        path.AddLine(New Point(0, 0), New Point(320, 0))
        path.AddLine(New Point(320, 0), New Point(320, 900))
        path.AddLine(New Point(320, 900), New Point(0, 900))
        path.AddLine(New Point(0, 900), New Point(0, 0))
        Dim pathBrush As New PathGradientBrush(path)
        Dim colors As Color() = {tlc.Color, trc.Color, blc.Color, brc.Color}
        pathBrush.SurroundColors = colors
        pathBrush.CenterColor = Color.Transparent
        g.FillPath(pathBrush, path)
        'g.FillRectangle(pathBrush, New Rectangle(0, 0, 320, 900))
        bmp.Save("backgrounds\gradient.png", System.Drawing.Imaging.ImageFormat.Png)
        PreviewWindow.Image = Image.FromFile("backgrounds\gradient.png")
        PreviewWindow.Refresh()
    End Sub

    Private Sub gradiantwindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PreviewWindow.Refresh()
        Me.PreviewWindow.Dispose()
    End Sub

    Private Sub gradiantwindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        If System.IO.File.Exists("backgrounds\gradient.png") Then
            PreviewWindow.Image = Image.FromFile("backgrounds\gradient.png")
        End If
    End Sub
End Class