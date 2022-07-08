Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Xml
Imports System.Text.RegularExpressions
Imports System.Drawing


Public Class StatusUpdateGUIFrontend : Inherits Form
    Private Sub LastEvent_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LastEvent.KeyDown
        If Started = True Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                e.SuppressKeyPress = True
                CurrentNotes.Text = LTrim(LastEvent.Text)
                committedLastEvent = LTrim(LastEvent.Text)
                My.Settings.quicknotes = LTrim(LastEvent.Text)
                ScreenUpdate()
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Settings.Click
        If SettingsForm.Visible = False Then
            SettingsForm.Show()
        Else
            SettingsForm.Close()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Modlist As New List(Of String)
        If Not System.IO.File.Exists(".\modlist.xml") Then
            Dim xmlset As XmlWriterSettings = New XmlWriterSettings()
            xmlset.Indent = True
            xmlset.NewLineOnAttributes = True
            Using writer2 As XmlWriter = XmlWriter.Create(".\modlist.xml", xmlset)
                writer2.WriteStartDocument()
                writer2.WriteStartElement("listomods")
                For Each modnamed In ModlistForm.MainModList.Items
                    writer2.WriteElementString("modname", "None")
                Next
                writer2.WriteEndDocument()
            End Using
        End If
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        StartButton.Image = My.Resources.Resources._start
        LastEvent.Text = "Press start to be able to save notes. Press enter to confirm notes in box."
        CurrentNotes.Text = My.Settings.quicknotes
        Me.StartStop.SetToolTip(Me.StartButton, "Start/Stop")
    End Sub

#Region "Variables and Definitions"

    Dim Started As Boolean = 0
    Dim StreamTime As Int32 = 0
    Dim StatusBar As Byte = 255
    Dim FF7Process As Process
    Dim mySaveMap As FF7SaveMap
    Dim MemRead As NativeMemoryReader
    Dim committedLastEvent As String = "None"
    Dim sReader As String




    Structure WriterInput
        Public Disc As Byte
        Public Location As String
        Public StreamTime As String
        Public GameTime As String
        Public LastEvent As String
        Public PartyNames As String()
        Public PartyLevels As String()
        Public ExpToLevel As String()
        Public Weapon As String()
        Public Armor As String()
        Public Accessory As String()
        Public HP As String()
        Public MP As String()
        Public LiveGil As Integer
        Public BaseHP As String()
        Public BaseMP As String()
    End Structure

#End Region

#Region "Internal Functions"

    Private Sub wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Private Sub UpdateStatus()
        Select Case StatusBar
            Case 255
                StartButton.Image = My.Resources.Resources._start
            Case 254
                StartButton.Image = My.Resources.Resources._stop
            Case 0
                StartButton.Image = My.Resources.Resources._error
            Case Else
                StartButton.Image = My.Resources.Resources._start
                StatusBar = 0
        End Select
    End Sub

    Private Sub XmlWrite(ByRef Input As WriterInput)
        Dim WeaponNames() As String = New String(126) {
        "Buster", "Mythril Saber", "Hardedge", "Butterfly Edge", "Enhance Sword", "Organics", "Crystal Sword", "Force Stealer", "Rune Blade", "Murasame", "Nail Bat", "Yoshiyuki", "Apocalypse", "Heaven's Cloud", "Ragnarok", "Ultima Weapon",
        "Leather Glove", "Metal Knuckle", "Mythril Claw", "Grand Glove", "Tiger Fang", "Diamond Knuckle", "Dragon Claw", "Crystal Glove", "Motor Drive", "Platinum Fist", "Kaiser Knuckle", "Work Glove", "Powersoul", "Master Fist", "God's Hand", "Premium Heart",
        "Gatling Gun", "Assault Gun", "Cannon Ball", "Atomic Scissors", "Heavy Vulcan", "Chainsaw", "Microlaser", "A-M Cannon", "W Machine Gun", "Drill Arm", "Solid Bazooka", "Rocket Punch", "Enemy Launcher", "Pile Banger", "Max Ray", "Missing Score",
        "Mythril Clip", "Diamond Pin", "Silver Barrette", "Adaman Clip", "Crystal Comb", "Magic Comb", "Plus Barrette", "Centclip", "Hairpin", "Seraph Comb", "Behemoth Horn", "Spring Gun Clip", "Limited Moon",
        "Guard Stick", "Mythril Rod", "Full Metal Staff", "Striking Staff", "Prism Staff", "Aurora Rod", "Wizard Staff", "Wizer Staff", "Fairy Tale", "Umbrella", "Princess Guard",
        "Spear", "Slash Lance", "Trident", "Mast Ax", "Partisan", "Viper Halberd", "Javelin", "Grow Lance", "Mop", "Dragon Lance", "Scimitar", "Flayer", "Spirit Guard", "venus Gospel",
        "4-point Shuriken", "Boomerang", "Pinwheel", "Razor Ring", "Hawkeye", "Crystal Cross", "Wind Slash", "Twin Viper", "Spiral Shuriken", "Superball", "Magic Shuriken", "Rising Sun", "Oritsuru", "Conformer",
        "Yellow M-phone", "Green M-phone", "Blue M-phone", "Red M-phone", "Crystal M-phone", "White M-phone", "Black M-phone", "Silver M-phone", "Trumpet Shell", "Gold M-Phone", "Battle Trumpet", "Starlight Phone", "HP Shout",
        "Quicksilver", "Shotgun", "Shortbarrel", "Lariat", "Winchester", "Peacemaker", "Buntline", "Long Barrel R", "Silver Rifle", "Sniper CR", "Supershot ST", "Outsider", "Death Penalty",
        "Masamune"
        }
        Dim ArmorNames() As String = New String(255) {
        "Bronze Bangle", "Iron Bangle", "Titan Bangle", "Mythril Armlet", "Carbon Bangle", "Silver Armlet", "Gold Armlet", "Diamond Bangle", "Crystal Bangle", "Platinum Bangle", "Rune Armlet", "Edincoat", "Wizard Bracelet", "Adaman Bangle", "Gigas Armlet", "Imperial Guard", "Aegis Armlet", "Fourth Bracelet", "Warrior Bangle", "Shinra Beta", "Shinra Alpha", "Four Slots", "Fire Armlet", "Aurora Armlet", "Bolt Armlet", "Dragon Armlet", "Minerva Band", "Escort Guard", "Mystile", "Ziedrich", "Precious Watch", "Chocobracelet",
        "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none""none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none""none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none""none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none"
        }
        Dim AccessoryNames() As String = New String(255) {
        "Power Wrist", "Protect Vest", "Earring", "Talisman", "Choco Feater", "Amulet", "Champion Belt", "Poison Ring", "Tough Ring", "Circlet", "Star Pendant", "Silver Glasses", "Headband", "Fairy Ring", "Jem Ring", "White Cape", "Sprint Shoes", "Peace Ring", "Ribbon", "Fire Ring", "Ice Ring", "Bolt Ring", "Tetra Elemental", "Safety Bit", "Fury Ring", "Curse Ring", "Protect Ring", "Cat's Bell", "Reflect Ring", "Water Ring", "Sneak Glove", "HypnoCrown",
        "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none", "none"
        }
        Dim Settings As XmlWriterSettings = New XmlWriterSettings()
        Settings.Indent = True
        Try
            wait(50)
            Using writer As XmlWriter = XmlWriter.Create(".\status.xml", Settings)
                writer.WriteStartDocument()
                writer.WriteStartElement("status")                                 ' <status>
                If My.Settings.QuicknotesOn = True Then
                    writer.WriteElementString("quicknotes", Input.LastEvent)            '    <lastevent>I Picked a Booger</lastevent>
                End If
                If My.Settings.Discnums = True Then
                    writer.WriteElementString("disc", Input.Disc)                      '    <disc>1</disc>
                End If
                If My.Settings.LocSet = True Then
                    writer.WriteElementString("location", Input.Location)              '    <location>God Knows</location>
                End If
                If My.Settings.TimeSet Then
                    writer.WriteStartElement("timeset")
                    If My.Settings.LocalTimeSet Then
                        writer.WriteElementString("localtimeset", "true")
                    End If
                    If My.Settings.StreamTimeSet Then
                        writer.WriteElementString("streamtime", Input.StreamTime)          '    <timestarted>1428292404</timestarted>
                    End If
                    writer.WriteElementString("gametime", Input.GameTime)              '    <gametime>79324</gametime>
                    writer.WriteEndElement()
                End If
                If My.Settings.ModList = True Then
                    writer.WriteStartElement("modlist")
                    Dim reader2 As XmlReaderSettings = New XmlReaderSettings()
                    Using Reader As XmlReader = XmlReader.Create(".\modlist.xml", reader2)
                        While Reader.Read()
                            If Reader.IsStartElement Then
                                If Reader.Name = "modname" Then
                                    If Reader.Read() Then
                                        Dim value As String = Reader.Value.Trim()
                                        writer.WriteElementString("modentry", value)                       '        <mod>Reunion R03b</mod>
                                    End If
                                End If
                            End If
                        End While
                    End Using
                    writer.WriteEndElement()
                End If
                If My.Settings.GilDisplay = True Then
                    writer.WriteElementString("gil", Input.LiveGil)                        '    <gil>1234</gil>
                End If
                writer.WriteStartElement("party")                                  '    <party>
                Dim Index As Byte = 0
                For Each myName In Input.PartyNames
                    writer.WriteStartElement("member")                             '        <member>
                    writer.WriteElementString("name", myName)                      '            <name>Blah</name>
                    writer.WriteElementString("hp", Input.HP(Index).ToString())                      '            <hp>6969</hp>
                    writer.WriteElementString("basehp", Input.BaseHP(Index).ToString())                      '            <basehp>6969</basehp>
                    writer.WriteElementString("mp", Input.MP(Index).ToString())                      '            <mp>6969</mp>
                    writer.WriteElementString("basemp", Input.BaseMP(Index).ToString())                      '            <basemp>6969</basemp>
                    If My.Settings.Level = True Then
                        writer.WriteElementString("level", Input.PartyLevels(Index).ToString()) '   <level>3</level>
                        writer.WriteElementString("exptolevel", Input.ExpToLevel(Index).ToString()) '   <level>3</level>
                    End If
                    If My.Settings.WpDisplay = True Then
                        writer.WriteElementString("weapon", WeaponNames(Input.Weapon(Index)))    '            <weapon>Blah</weapon>
                    End If
                    writer.WriteElementString("armor", ArmorNames(Input.Armor(Index)))    '            <armour>Blah</armour>
                    writer.WriteElementString("accessory", AccessoryNames(Input.Accessory(Index)))    '            <Accessory>Blah</Accessory>
                    writer.WriteEndElement()                                       '        </member>
                    Index = Index + 1
                Next
                writer.WriteEndElement()                                           '    </party>
                writer.WriteEndElement()                                              ' </status>
                writer.WriteEndDocument()
            End Using
        Catch ex As System.IO.IOException
            ' Just pass it, it probably just means we're being read at the same time we're trying to
            ' write, we'll wait until the next second.
            Return
        End Try
    End Sub

    Private Sub ScreenUpdate()

        Dim myXMLInput As WriterInput
        If Started = False Then
            StatusBar = 255
            UpdateStatus()
            Return
        End If
        If StatusBar = 255 Then
            StatusBar = 0
        End If
        UpdateStatus()
        If mySaveMap.Disc >= 1 And mySaveMap.Disc <= 3 Then
            myXMLInput.Disc = mySaveMap.Disc
        Else
            myXMLInput.Disc = 0
        End If
        If mySaveMap.LiveGil = 0 Then
            myXMLInput.LiveGil = 0
        Else
            myXMLInput.LiveGil = mySaveMap.LiveGil
        End If
        If Not String.IsNullOrWhiteSpace(mySaveMap.LiveMapName) Then
            Location.Text = mySaveMap.LiveMapName
            myXMLInput.Location = mySaveMap.LiveMapName
        Else
            Location.Text = ""
            myXMLInput.Location = "Unknown"
        End If
        If StreamTime > 0 Then
            myXMLInput.StreamTime = SecsToHMS(StreamTime)
            Time.Text = "Time: Local (" & DateTime.Now.ToString("HH:mm:ss") & ") Stream (" & SecsToHMS(StreamTime) & ")"
            If StreamTime > 0 And mySaveMap.LiveTotalSeconds > 0 Then
                Time.Text = "Time: Local (" & DateTime.Now.ToString("HH:mm:ss") & ") Stream (" & SecsToHMS(StreamTime) & ")"
                myXMLInput.GameTime = SecsToHMS(mySaveMap.LiveTotalSeconds)
            End If
            If StreamTime > 0 And mySaveMap.LiveTotalSeconds <= 0 Then
                Time.Text = "Time: Local (" & DateTime.Now.ToString("HH:mm:ss") & ") Stream (" & SecsToHMS(StreamTime) & ")"
                myXMLInput.GameTime = "00:00:00"
            End If


        Else
            Time.Text = "Time: Local (" & DateTime.Now.ToString("HH:mm:ss") & ")"
            myXMLInput.StreamTime = "00:00:00"
            myXMLInput.GameTime = "00:00:00"
        End If
        Dim TempStr As String
        Dim numParty As Byte = 0
        TempStr = ""
        If Not IsNothing(mySaveMap.LiveParty(0)) And Not String.IsNullOrWhiteSpace(mySaveMap.LiveParty(0).Name) Then
            TempStr = TempStr & mySaveMap.LiveParty(0).Name & " (" & mySaveMap.LiveParty(0).Level & ") "
            numParty = numParty + 1
        Else
            TempStr = "None"
        End If
        If Not IsNothing(mySaveMap.LiveParty(1)) And Not String.IsNullOrWhiteSpace(mySaveMap.LiveParty(1).Name) Then
            TempStr = TempStr & mySaveMap.LiveParty(1).Name & " (" & mySaveMap.LiveParty(1).Level & ") "
            numParty = numParty + 1
        End If
        If Not IsNothing(mySaveMap.LiveParty(2)) And Not String.IsNullOrWhiteSpace(mySaveMap.LiveParty(2).Name) Then
            TempStr = TempStr & mySaveMap.LiveParty(2).Name & " (" & mySaveMap.LiveParty(2).Level & ") "
            numParty = numParty + 1
        End If
        Party.Text = TempStr
        If numParty > 0 Then
            ReDim myXMLInput.PartyNames(numParty - 1)
            ReDim myXMLInput.Weapon(numParty - 1)
            ReDim myXMLInput.Armor(numParty - 1)
            ReDim myXMLInput.Accessory(numParty - 1)
            ReDim myXMLInput.PartyLevels(numParty - 1)
            ReDim myXMLInput.ExpToLevel(numParty - 1)
            ReDim myXMLInput.HP(numParty - 1)
            ReDim myXMLInput.MP(numParty - 1)
            ReDim myXMLInput.BaseHP(numParty - 1)
            ReDim myXMLInput.BaseMP(numParty - 1)
            For myIterator As Byte = 0 To (numParty - 1)
                myXMLInput.PartyNames(myIterator) = mySaveMap.LiveParty(myIterator).Name
                myXMLInput.Weapon(myIterator) = mySaveMap.LiveParty(myIterator).Weapon
                myXMLInput.Armor(myIterator) = mySaveMap.LiveParty(myIterator).Armor
                myXMLInput.Accessory(myIterator) = mySaveMap.LiveParty(myIterator).Accessory
                myXMLInput.HP(myIterator) = mySaveMap.LiveParty(myIterator).HP
                myXMLInput.BaseHP(myIterator) = mySaveMap.LiveParty(myIterator).BaseHP
                myXMLInput.MP(myIterator) = mySaveMap.LiveParty(myIterator).MP
                myXMLInput.BaseMP(myIterator) = mySaveMap.LiveParty(myIterator).BaseMP
                myXMLInput.PartyLevels(myIterator) = mySaveMap.LiveParty(myIterator).Level
                myXMLInput.ExpToLevel(myIterator) = mySaveMap.LiveParty(myIterator).ExpToLevel
            Next
        Else
            ReDim myXMLInput.PartyNames(0)
            ReDim myXMLInput.Weapon(0)
            ReDim myXMLInput.Armor(0)
            ReDim myXMLInput.Accessory(0)
            ReDim myXMLInput.PartyLevels(0)
            ReDim myXMLInput.ExpToLevel(0)
            ReDim myXMLInput.HP(0)
            ReDim myXMLInput.BaseHP(0)
            ReDim myXMLInput.MP(0)
            ReDim myXMLInput.BaseMP(0)
            myXMLInput.PartyNames(0) = "None"
            myXMLInput.BaseHP(0) = 0
            myXMLInput.HP(0) = 0
            myXMLInput.LiveGil = 0
            myXMLInput.Weapon(0) = "None"
            myXMLInput.Accessory(255) = "None"
            myXMLInput.Armor(0) = "None"
            myXMLInput.PartyLevels(0) = 0
            myXMLInput.ExpToLevel(0) = 0
        End If
#Disable Warning BC42108 ' Variable is passed by reference before it has been assigned a value
        myXMLInput.LastEvent = committedLastEvent
        wait(50)
        XmlWrite(myXMLInput)
#Enable Warning BC42108 ' Variable is passed by reference before it has been assigned a value

    End Sub
    Function StripTags(html As String) As String
        ' Remove HTML tags.
        Return Regex.Replace(html, "<(?:[^>=]|='[^']*'|=""[^""]*""|=[^'""][^\s>]*)*>", "").Trim
    End Function

    Private Function SecsToHMS(ByVal Seconds As Int32) As String
        Dim outHours As Int32
        Dim outMinutes As Byte
        Dim outSeconds As Byte
        outHours = Math.Floor(Seconds / 3600)
        Seconds = Seconds Mod 3600
        outMinutes = Math.Floor(Seconds / 60)
        Seconds = Seconds Mod 60
        outSeconds = Seconds
        Return outHours.ToString("00") & ":" & outMinutes.ToString("00") & ":" & outSeconds.ToString("00")
    End Function

    Private Sub ExceptionHandler(ByVal ExceptionMessage As String)
        Started = False
        Timer1.Enabled = False
        If Not IsNothing(MemRead) Then
            MemRead.Dispose()
        End If
        StatusBar = 254
        UpdateStatus()
        MessageBox.Show(ExceptionMessage)
        Application.Exit()
    End Sub
#End Region

#Region "Event Handlers"


#End Region
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Started = False Then
            StreamTime = 0
            Timer1.Enabled = False
            Return
        End If
        StreamTime = StreamTime + 1
        Dim TempBytes As Byte()
        TempBytes = MemRead.ReadMemory(New IntPtr(&HDBFD38), 4342)
        If Not mySaveMap.Update(TempBytes) Or Not mySaveMap.IsValid Then
            Timer1.Enabled = False
            ExceptionHandler("SaveMap failed to update. Is FF7 no longer running? Terminating.")
        End If
        ScreenUpdate()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles StartButton.Click
        If Started = True Then
            StreamTime = 0
            Started = False
            Timer1.Enabled = False
            StatusBar = 255
            StartButton.Image = My.Resources._stop
            UpdateStatus()
            Return
        End If
        Try
            FF7Process = Process.GetProcessesByName("ff7")(0)
        Catch ex As Exception
            ExceptionHandler("Unable to create copy of SaveMap: Unable to grab FF7 Process: " & ex.Message)
            Return
        End Try
        Try
            MemRead = New NativeMemoryReader(FF7Process)
        Catch ex As Exception
            ExceptionHandler("Unable to create copy of SaveMap: Unable to attach to FF7 Process: " & ex.Message)
            Return
        End Try
        Dim TempBytes As Byte()
        TempBytes = MemRead.ReadMemory(New IntPtr(&HDBFD38), 4342)
        mySaveMap = New FF7SaveMap(TempBytes)
        If Not mySaveMap.IsValid Then
            ExceptionHandler("Sorry, your SaveMap isn't valid! Please make sure FF7 is running and ingame before you start this application. Terminating.")
            Return
        End If
        If Started = False Then
            StreamTime = 0
            Started = True
            Timer1.Enabled = True
            StatusBar = 1
            StartButton.Image = My.Resources._start
            UpdateStatus()
            Return
        End If
        ScreenUpdate()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Me.Visible = False Then
            Me.Show()
        Else
            Me.Hide()
            SettingsForm.Close()
            ModlistForm.Close()
        End If
    End Sub
End Class

Public Class FF7SaveMap

#Region "Internal Definitions"
    Structure Character
        Public ID As Byte
        Public DefaultName As String
        Public Name As String ' 0x10
        Public Level As Byte ' 0x01
        Public Strength As Byte ' 0x02
        Public Vitality As Byte ' 0x03
        Public Magic As Byte ' 0x04
        Public Spirit As Byte ' 0x05
        Public Dexterity As Byte ' 0x06
        Public Luck As Byte ' 0x07
        Public StrBonus As Byte ' 0x08
        Public VitBonus As Byte ' 0x09
        Public MagBonus As Byte ' 0x0A
        Public SprBonus As Byte ' 0x0B
        Public DexBonus As Byte ' 0x0C
        Public LucBonus As Byte ' 0x0D
        Public LimitLevel As Byte ' 0x0E
        Public LimitBar As Byte ' 0x0F
        Public Weapon As Byte ' 0x1C
        Public Armor As Byte ' 0x1D
        Public Accessory As Byte ' 0x1E
        Public Flags As Byte ' 0x1F
        Public AtFront As Boolean ' 0x20
        Public LevelProgress As Byte ' 0x21
        Public LimitMask As Int16 ' 0x22, See Qhimm/BC SaveMap
        Public Kills As Int16 ' 0x24
        Public LimitTimes As Int16() ' 0x26, 0x28, 0x2A
        Public HP As Int16 ' 0x2C
        Public BaseHP As Int16 ' 0x2E
        Public MP As Int16 ' 0x30
        Public BaseMP As Int16 ' 0x32
        Public MaxHP As Int16 ' 0x38
        Public MaxMP As Int16 ' 0x3A
        Public Experience As Int32 ' 0x34
        Public WeaponMateria As Int32() ' 0x40, 0x44, 0x48, 0x4C, 0x50, 0x54, 0x58, 0x5C
        Public ArmorMateria As Int32() ' 0x60, 0x64, 0x68, 0x6C, 0x60, 0x74, 0x78, 0x7C
        Public ExpToLevel As Int32 ' 0x80
    End Structure

#End Region

#Region "Internal Variables"
    Private _Map As Byte()
    Private Valid As Boolean
#End Region

#Region "Constructor"
    Public Sub New(ByRef Map As Byte())
        ' Not much else to do here. Checking validity of the response won't be useful in a constructor since
        ' we can't get "out" of it, though the caller of our constructor can check .IsValid 
        Update(Map)
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property PreviewParty As Character()
        Get
            Dim resultArray(2) As Character
            If FillChar(_Map(&H5), resultArray(0)) = False Then
                Return Nothing
            End If
            If FillChar(_Map(&H6), resultArray(1)) = False Then
                resultArray(1) = Nothing
                resultArray(2) = Nothing
                Return resultArray
            End If
            If FillChar(_Map(&H7), resultArray(2)) = False Then
                resultArray(2) = Nothing
                Return resultArray
            End If
            Return resultArray
        End Get
    End Property

    Public ReadOnly Property LiveParty As Character()
        Get
            Dim resultArray(2) As Character
            If FillChar(_Map(&H4F8), resultArray(0)) = False Then
                resultArray(0) = Nothing
                resultArray(1) = Nothing
                resultArray(2) = Nothing
                Return resultArray
            End If
            If FillChar(_Map(&H4F9), resultArray(1)) = False Then
                resultArray(1) = Nothing
                resultArray(2) = Nothing
                Return resultArray
            End If
            If FillChar(_Map(&H4FA), resultArray(2)) = False Then
                resultArray(2) = Nothing
                Return resultArray
            End If
            Return resultArray
        End Get
    End Property

    Public ReadOnly Property PreviewGil As Int32
        Get
            Return BitConverter.ToInt32(_Map, &H20)
        End Get
    End Property

    Public ReadOnly Property PreviewTotalSeconds As Int32
        Get
            Return BitConverter.ToInt32(_Map, &H24)
        End Get
    End Property

    Public ReadOnly Property PreviewMapName As String
        Get
            Dim TempArr(31) As Byte
            Array.Copy(_Map, &H28, TempArr, 0, 32)
            Return FFStringtoString(TempArr)
        End Get
    End Property

    Public ReadOnly Property LiveCharIDs As Byte()
        Get
            Dim RetArray(2) As Byte
            RetArray(0) = _Map(&H4F8)
            RetArray(1) = _Map(&H4F9)
            RetArray(2) = _Map(&H4FA)
            Return RetArray
        End Get
    End Property

    ' Skipping right along because I'm *not* reading the entire item and materia lists...

    Public ReadOnly Property LiveGil As Int32
        Get
            Return BitConverter.ToInt32(_Map, &HB7C)
        End Get
    End Property

    Public ReadOnly Property LiveTotalSeconds As Int32
        Get
            Return BitConverter.ToInt32(_Map, &HB80)
        End Get
    End Property

    Public ReadOnly Property CountDownTimer As Int32
        Get
            Return BitConverter.ToInt32(_Map, &HB84)
        End Get
    End Property

    Public ReadOnly Property MapID As Int16
        Get
            Return BitConverter.ToInt16(_Map, &HB94)
        End Get
    End Property

    Public ReadOnly Property LocID As Int16
        Get
            Return BitConverter.ToInt16(_Map, &HB96)
        End Get
    End Property

    Public ReadOnly Property PosX As Int16
        Get
            Return BitConverter.ToInt16(_Map, &HB9A)
        End Get
    End Property

    Public ReadOnly Property PosY As Int16
        Get
            Return BitConverter.ToInt16(_Map, &HB9C)
        End Get
    End Property

    Public ReadOnly Property Dir As Byte
        Get
            Return _Map(&HBA0)
        End Get
    End Property

    Public ReadOnly Property FieldTotalSeconds As Int32
        Get
            Dim RetValue As Int32 = _Map(&HBB6)
            RetValue = RetValue + (_Map(&HBB5) * 60)
            RetValue = RetValue + (_Map(&HBB4) * 3600)
            Return RetValue
        End Get
    End Property

    Public ReadOnly Property BattlesFought As Int16
        Get
            Return BitConverter.ToInt16(_Map, &HBBC)
        End Get
    End Property

    Public ReadOnly Property Escapes As Int16
        Get
            Return BitConverter.ToInt16(_Map, &HBBE)
        End Get
    End Property

    Public ReadOnly Property UltimateWeaponHP As UInt32
        Get
            ' Dirty hack time! It's a 24-bit value and we don't exactly have a "ToInt24"
            Dim TempStorage As Byte
            Dim RetValue As UInt32
            TempStorage = _Map(&HBFE)
            _Map(&HBFE) = 0
            RetValue = BitConverter.ToUInt32(_Map, &HBFE)
            _Map(&HBFE) = TempStorage
            Return RetValue
        End Get
    End Property

    Public ReadOnly Property BattlePoints As Int16
        Get
            Return BitConverter.ToInt16(_Map, &HC14)
        End Get
    End Property

    Public ReadOnly Property PartyGP As Int16
        Get
            Return BitConverter.ToInt16(_Map, &HCEE)
        End Get
    End Property

    Public ReadOnly Property Disc As Byte
        Get
            Return _Map(&HEA4)
        End Get
    End Property

    Public ReadOnly Property IsValid As Boolean
        Get
            Return Valid
        End Get
    End Property

    Public ReadOnly Property LiveMapName As String
        Get
            Dim TempArr(31) As Byte
            Array.Copy(_Map, &HF0C, TempArr, 0, 32)
            Return FFStringtoString(TempArr)
        End Get
    End Property
#End Region

#Region "Private Subs/Functions"
    Private Function NamestoFaces(ByRef Input As Byte) As String
        Select Case Input
            Case 0
                Return "Cloud"
            Case 1
                Return "Barrett"
            Case 2
                Return "Tifa"
            Case 3
                Return "Aerith"
            Case 4
                Return "Red XIII"
            Case 5
                Return "Yuffie"
            Case 6
                Return "Cait Sith"
            Case 7
                Return "Vincent"
            Case 8
                Return "Cid"
            Case 9
                Return "Young Cloud"
            Case 10
                Return "Sephiroth"
            Case 11
                Return "Chocobo"
            Case 255
                Return "None"
            Case Else
                Return "Invalid Value"
        End Select
        Return "none"
    End Function

    Private Function GetCharOffset(ByVal ID As Byte) As Int16
        Select Case ID
            Case 0
                Return &H54
            Case 1
                Return &HD8
            Case 2
                Return &H15C
            Case 3
                Return &H1E0
            Case 4
                Return &H264
            Case 5
                Return &H2E8
            Case 6
                Return &H36C
            Case 7
                Return &H3F0
            Case 8
                Return &H474
            Case 9
                Return &H36C
            Case 10
                Return &H3F0
            Case Else
                Return -1
        End Select
        Return -1
    End Function

    Private Function FFStringtoString(ByVal FFString As Byte())
        ' Dirty translation, will only work for printable chars.
        Dim DestBytes(FFString.Length - 1) As Byte
        Dim myIterator As Byte = 0
        Dim endIndex As Byte = 255
        For Each ThisByte As Byte In FFString
            If ThisByte < &H60 Then
                DestBytes(myIterator) = ThisByte + &H20
                myIterator = myIterator + 1
            ElseIf ThisByte = &HD0 Then
                DestBytes(myIterator) = &H20
            ElseIf ThisByte < &HE1 Then
                ' Not going to bother doing all the non-english characters, sorry!
                DestBytes(myIterator) = &H3F
            ElseIf ThisByte = &HE2 Then
                DestBytes(myIterator) = &H9
            ElseIf ThisByte = &HE3 Then
                DestBytes(myIterator) = &H2C
            ElseIf ThisByte < &HFE Then
                DestBytes(myIterator) = &H3F
            ElseIf ThisByte = &HFF Then
                DestBytes(myIterator) = &H0
                If endIndex = 255 Then
                    endIndex = myIterator
                End If
            Else
                DestBytes(myIterator) = &H3F
            End If
        Next
        Dim RetValue As String = System.Text.Encoding.ASCII.GetString(DestBytes)
        If endIndex <> 255 Then
            RetValue = RetValue.Remove(endIndex)
        End If
        Return RetValue
    End Function

    Private Function FillChar(ByVal CharID As Byte, ByRef RetChar As Character) As Boolean
        Dim Offset As Int16
        RetChar.DefaultName = NamestoFaces(CharID)
        If RetChar.DefaultName = "None" Then
            Return False
        End If
        Offset = GetCharOffset(CharID)
        If Offset = -1 Then
            Return False
        End If
        Dim FFName(11) As Byte
        Array.Copy(_Map, Offset + &H10, FFName, 0, 12)
        RetChar.Name = FFStringtoString(FFName)
        RetChar.Level = _Map(Offset + &H1)
        RetChar.Strength = _Map(Offset + &H2)
        RetChar.Vitality = _Map(Offset + &H3)
        RetChar.Magic = _Map(Offset + &H4)
        RetChar.Spirit = _Map(Offset + &H5)
        RetChar.Dexterity = _Map(Offset + &H6)
        RetChar.Luck = _Map(Offset + &H7)
        RetChar.StrBonus = _Map(Offset + &H8)
        RetChar.VitBonus = _Map(Offset + &H9)
        RetChar.MagBonus = _Map(Offset + &HA)
        RetChar.SprBonus = _Map(Offset + &HB)
        RetChar.DexBonus = _Map(Offset + &HC)
        RetChar.LucBonus = _Map(Offset + &HD)
        RetChar.LimitLevel = _Map(Offset + &HE)
        RetChar.LimitBar = _Map(Offset + &HF)
        RetChar.Weapon = _Map(Offset + &H1C)
        RetChar.Armor = _Map(Offset + &H1D)
        RetChar.Accessory = _Map(Offset + &H1E)
        RetChar.Flags = _Map(Offset + &H1F)
        If _Map(Offset + &H20) = &HFF Then
            RetChar.AtFront = True
        Else
            RetChar.AtFront = False
        End If
        RetChar.LevelProgress = _Map(Offset + &H21)
        RetChar.LimitMask = BitConverter.ToInt16(_Map, Offset + &H22)
        RetChar.Kills = BitConverter.ToInt16(_Map, Offset + &H24)
        ReDim RetChar.LimitTimes(2)
        RetChar.LimitTimes(0) = BitConverter.ToInt16(_Map, Offset + &H26)
        RetChar.LimitTimes(1) = BitConverter.ToInt16(_Map, Offset + &H28)
        RetChar.LimitTimes(2) = BitConverter.ToInt16(_Map, Offset + &H2A)
        RetChar.HP = BitConverter.ToInt16(_Map, Offset + &H2C)
        RetChar.BaseHP = BitConverter.ToInt16(_Map, Offset + &H2E)
        RetChar.MP = BitConverter.ToInt16(_Map, Offset + &H30)
        RetChar.BaseMP = BitConverter.ToInt16(_Map, Offset + &H32)
        RetChar.MaxHP = BitConverter.ToInt16(_Map, Offset + &H38)
        RetChar.MaxMP = BitConverter.ToInt16(_Map, Offset + &H3A)
        RetChar.Experience = BitConverter.ToInt32(_Map, Offset + &H3C)
        ReDim RetChar.WeaponMateria(7)
        For MatId As Integer = 0 To 7
            RetChar.WeaponMateria(MatId) = BitConverter.ToInt32(_Map, Offset + &H40 + (4 * MatId))
        Next
        ReDim RetChar.ArmorMateria(7)
        For MatId As Integer = 0 To 7
            RetChar.WeaponMateria(MatId) = BitConverter.ToInt32(_Map, Offset + &H60 + (4 * MatId))
        Next
        RetChar.ExpToLevel = BitConverter.ToInt32(_Map, Offset + &H80)
        Return True
    End Function
#End Region

#Region "Public Methods"
    Public Function Update(ByRef NewMap As Byte()) As Boolean
        ' Check the map for sanity, if it's not sane, return FALSE and set Valid to FALSE.
        Dim Passed As Boolean = True
        Try
            If NewMap(&H4FB) <> &HFF Then
                Passed = False
            End If
            If NewMap(&HB98) <> &H0 Then
                Passed = False
            End If
            If NewMap(&HBA3) <> &H0 Then
                Passed = False
            End If
        Catch ex As Exception
            Passed = False
        End Try
        If Not Passed Then
            Valid = False
            _Map = Nothing
        Else
            Valid = True
            _Map = NewMap
        End If
        Return Passed
    End Function
#End Region

End Class

Public Class NativeMemoryReader : Implements IDisposable


#Region "API Definitions"

    <DllImport("kernel32.dll", EntryPoint:="OpenProcess", SetLastError:=True)>
    Private Shared Function OpenProcess(ByVal dwDesiredAccess As UInteger, <MarshalAsAttribute(UnmanagedType.Bool)> ByVal bInheritHandle As Boolean, ByVal dwProcessId As UInteger) As IntPtr
    End Function

    <DllImportAttribute("kernel32.dll", EntryPoint:="ReadProcessMemory", SetLastError:=True)>
    Private Shared Function ReadProcessMemory(<InAttribute()> ByVal hProcess As System.IntPtr, <InAttribute()> ByVal lpBaseAddress As System.IntPtr, <Out()> ByVal lpBuffer As Byte(), ByVal nSize As UInteger, <OutAttribute()> ByRef lpNumberOfBytesRead As UInteger) As <System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="CloseHandle", SetLastError:=True)>
    Private Shared Function CloseHandle(ByVal hObject As IntPtr) As <MarshalAsAttribute(UnmanagedType.Bool)> Boolean
    End Function

#End Region


#Region "Private Fields"

    Private _TargetProcess As Process = Nothing
    Private _TargetProcessHandle As IntPtr = IntPtr.Zero
    Const PROCESS_VM_READ As UInteger = 16
    Const PROCESS_QUERY_INFORMATION As UInteger = 1024

#End Region


#Region "Public Properties"

    ''' <summary>
    ''' The process that memory will be read from when ReadMemory is called
    ''' </summary>
    Public ReadOnly Property TargetProcess() As Process
        Get
            Return _TargetProcess
        End Get
    End Property

    ''' <summary>
    ''' The handle to the process that was retrieved during the constructor or the last
    ''' successful call to the Open method
    ''' </summary>
    Public ReadOnly Property TargetProcessHandle() As IntPtr
        Get
            Return _TargetProcessHandle
        End Get
    End Property

#End Region


#Region "Public Methods"

    ''' <summary>
    ''' Reads the specified number of bytes from an address in the process's memory.
    ''' All memory in the specified range must be available or the method will fail.
    ''' Returns Nothing if the method fails for any reason
    ''' </summary>
    ''' <param name="MemoryAddress">The address in the process's virtual memory to start reading from</param>
    ''' <param name="Count">The number of bytes to read</param>
    Public Function ReadMemory(ByVal MemoryAddress As IntPtr, ByVal Count As Integer) As Byte()
        If _TargetProcessHandle = IntPtr.Zero Then
            Me.Open()
        End If
        Dim Bytes(Count) As Byte
        Dim Result As Boolean = ReadProcessMemory(_TargetProcessHandle, MemoryAddress, Bytes, CUInt(Count), 0)
        If Result Then
            Return Bytes
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Gets a handle to the process specified in the TargetProcess property.
    ''' A handle is automatically obtained by the constructor of this class but if the Close
    ''' method has been called to close a previously obtained handle then another handle can
    ''' be obtained by calling this method. If a handle has previously been obtained and Close has
    ''' not been called yet then an exception will be thrown.
    ''' </summary>
    Public Sub Open()
        If _TargetProcess Is Nothing Then
            Throw New ApplicationException("Process not found")
        End If
        If _TargetProcessHandle = IntPtr.Zero Then
            _TargetProcessHandle = OpenProcess(PROCESS_VM_READ Or PROCESS_QUERY_INFORMATION, True, CUInt(_TargetProcess.Id))
            If _TargetProcessHandle = IntPtr.Zero Then
                Throw New ApplicationException("Unable to open process for memory reading. The last error reported was: " & New System.ComponentModel.Win32Exception().Message)
            End If
        Else
            Throw New ApplicationException("A handle to the process has already been obtained, " &
                                           "close the existing handle by calling the Close method before calling Open again")
        End If
    End Sub

    ''' <summary>
    ''' Closes a handle that was previously obtained by the constructor or a call to the Open method
    ''' </summary>
    Public Sub Close()
        If Not _TargetProcessHandle = IntPtr.Zero Then
            Dim Result As Boolean = CloseHandle(_TargetProcessHandle)
            If Not Result Then
                Throw New ApplicationException("Unable to close process handle. The last error reported was: " &
                                               New System.ComponentModel.Win32Exception().Message)
            End If
            _TargetProcessHandle = IntPtr.Zero
        End If
    End Sub

#End Region


#Region "Constructors"

    ''' <summary>
    ''' Creates a new instance of the NativeMemoryReader class and attempts to get a handle to the
    ''' process that is to be read by calls to the ReadMemory method.
    ''' If a handle cannot be obtained then an exception is thrown
    ''' </summary>
    ''' <param name="ProcessToRead">The process that memory will be read from</param>
    Public Sub New(ByVal ProcessToRead As Process)
        If ProcessToRead Is Nothing Then
            Throw New ArgumentNullException("ProcessToRead")
        End If
        _TargetProcess = ProcessToRead
        Me.Open()
    End Sub

#End Region


#Region "IDisposable Support"

    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If Not _TargetProcessHandle = IntPtr.Zero Then
                Try
                    CloseHandle(_TargetProcessHandle)
                Catch ex As Exception
                    Debug.WriteLine("Error closing handle - " & ex.Message)
                End Try
            End If
        End If
        Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' Releases resources and closes any process handles that are still open
    ''' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class


