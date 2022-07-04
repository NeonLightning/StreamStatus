Imports System.Diagnostics.Eventing
Imports System.Xml
Public Class ModlistForm
    Private Sub ModlistForm_Load(sender As Object, e As EventArgs) Handles Me.Load

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
        Using readermain As XmlReader = XmlReader.Create(".\modlist.xml", reader2)
            While readermain.Read()
                If readermain.IsStartElement Then
                    If readermain.Name = "modname" Then
                        Me.MainModList.Items.Add(readermain.ToString)
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