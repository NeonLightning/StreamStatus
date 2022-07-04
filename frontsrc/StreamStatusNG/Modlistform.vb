Imports System.Diagnostics.Eventing
Imports System.Xml
Public Class ModlistForm
    Private Sub ModlistForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not System.IO.File.Exists(".\Modlist_read.xml") Then
            Dim xmlset As XmlWriterSettings = New XmlWriterSettings()
            Using writer2 As XmlWriter = XmlWriter.Create(".\modlist.xml", xmlset)
                xmlset.Indent = True
                xmlset.NewLineOnAttributes = True
                writer2.WriteStartDocument()
                writer2.WriteStartElement("listomods")
                writer2.WriteElementString("modname", "None")

            End Using
        End If
        Modlist_read()
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
            Me.MainModList.Items.Add(ModTextBox.Text)
            Modlist_update()
            Me.MainModList.Items.Clear()
            Modlist_read()
            Me.ModTextBox.Text = ""
        End If
    End Sub


End Class