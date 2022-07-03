Imports System.Xml

Public Class ModlistForm
    Public modlistentry As New List(Of String)

    Private Sub ModlistForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddModButton.Click
        Dim xmlset As XmlWriterSettings = New XmlWriterSettings()
        xmlset.Indent = True
        xmlset.NewLineOnAttributes = True
        If Not String.IsNullOrWhiteSpace(ModTextBox.Text) Then
            modlistentry.Add(ModTextBox.Text)
            MainModList.Items.Clear()
            Using writer2 As XmlWriter = XmlWriter.Create(".\modlist.xml", xmlset)
                writer2.WriteStartDocument()
                writer2.WriteStartElement("listomods")
                For Each myMod In Me.modlistentry
                    writer2.WriteElementString("modname", myMod)
                Next
                writer2.WriteEndElement()
                writer2.WriteEndDocument()
            End Using
            For Each listmain In modlistentry
                Me.MainModList.Items.Add(listmain)
            Next
            Me.ModTextBox.Text = ""
        End If
    End Sub
End Class