Imports System.Diagnostics.Eventing
Imports System.Xml
Public Class ModlistForm
    Private Sub ModlistForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not System.IO.File.Exists(".\modlist.xml") Then
            Dim xmlset As XmlWriterSettings = New XmlWriterSettings()
            Using writer2 As XmlWriter = XmlWriter.Create(".\modlist.xml", xmlset)
                xmlset.Indent = True
                xmlset.NewLineOnAttributes = True
                writer2.WriteStartDocument()
                writer2.WriteStartElement("listomods")
            End Using
        End If
        Modlist_read()
        If Me.MainModList.Items.Count = 0 Then Me.MainModList.Items.Add("None")
    End Sub
    Public Sub Modlist_update()
        Dim xmlset As XmlWriterSettings = New XmlWriterSettings()
        xmlset.Indent = True
        xmlset.NewLineOnAttributes = True
        Using writer2 As XmlWriter = XmlWriter.Create(".\modlist.xml", xmlset)
            writer2.WriteStartDocument()
            writer2.WriteStartElement("listomods")
            For Each modnamed In Me.MainModList.Items
                writer2.WriteElementString("modname", modnamed)
            Next
            writer2.WriteEndDocument()
        End Using
        Me.MainModList.Items.Clear()
    End Sub

    Public Sub Modlist_read()
        Dim reader2 As XmlReaderSettings = New XmlReaderSettings()
        Using Reader As XmlReader = XmlReader.Create(".\modlist.xml", reader2)
            While Reader.Read()
                If Reader.IsStartElement Then
                    If Reader.Name = "modname" Then
                        If Reader.Read() Then
                            Dim value As String = Reader.Value.Trim()
                            Me.MainModList.Items.Add(value)
                        End If
                    End If
                End If
            End While
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddModButton.Click
        If Not String.IsNullOrWhiteSpace(ModTextBox.Text) Then
            If Me.MainModList.Items.Count = 1 AndAlso Me.MainModList.Items(0) = "None" Then
                Me.MainModList.Items.Clear()
            End If
            Me.MainModList.Items.Add(ModTextBox.Text)
            Modlist_update()
            Modlist_read()
            Me.ModTextBox.Text = ""
        End If
    End Sub

    Private Sub DelModButton_Click(sender As Object, e As EventArgs) Handles DelModButton.Click
        If Me.MainModList.SelectedIndex >= 0 Then
            Me.MainModList.Items.RemoveAt(Me.MainModList.SelectedIndex)
            Modlist_update()
            Me.MainModList.Items.Clear()
            Modlist_read()
        End If
    End Sub
End Class