Public Class ModlistForm
    Public modlistentry As New List(Of String)
    Private Sub ModlistForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    'Dim modlistbiglist(0) As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddModButton.Click
        If Not String.IsNullOrWhiteSpace(ModTextBox.Text) Then
            'ReDim Preserve modlistbiglist(modlistbiglist.Count + 1)
            'modlistbiglist(modlistbiglist.Count - 1) = Me.ModTextBox.Text
            'For i As Integer = 0 To modlistbiglist.Count
            '    Me.MainModList.Items.Add(modlistbiglist(i))
            'Next
            modlistentry.Add(ModTextBox.Text)
            MainModList.Items.Clear()
            For Each listmain In modlistentry
                Me.MainModList.Items.Add(listmain)
            Next
            Me.ModTextBox.Text = ""
        End If
    End Sub
End Class