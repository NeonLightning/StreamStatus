Imports System.Runtime.InteropServices.ComTypes
Imports System.Xml

Public Class ModlistForm
    Public modlistentry As New List(Of String)
    Public Sub Modlist_update()
        Dim xmlset As XmlWriterSettings = New XmlWriterSettings()
        xmlset.Indent = True
        xmlset.NewLineOnAttributes = True
        Using writer2 As XmlWriter = XmlWriter.Create(".\modlist.xml", xmlset)
            writer2.WriteStartDocument()
            For Each modnamed In modlistentry
                writer2.WriteStartElement("listomods")
                writer2.WriteElementString("modname", modnamed)
                Me.MainModList.Items.Add(modnamed)
                writer2.WriteEndElement()
            Next
            writer2.WriteEndDocument()
        End Using
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddModButton.Click
        If Not String.IsNullOrWhiteSpace(ModTextBox.Text) Then
            modlistentry.Add(ModTextBox.Text)
            Me.ModTextBox.Clear()
            Modlist_update()
            Me.ModTextBox.Text = ""
        End If
    End Sub
End Class