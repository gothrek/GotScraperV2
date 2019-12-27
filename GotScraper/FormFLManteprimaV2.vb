Public Class FormFLManteprimaV2
    Dim dt As DataTable
    Dim arrayObj(FormFLM.ListBoxObj.Items.Count) As String

    Dim mp3playerMusic As New ClassMedia.MP3Player

    Dim dtRoms As DataTable
    Dim indiceRom As Integer
    Dim romlistUsoFont As String
    Dim romlistUsoSize As Integer
    Dim romlistUsoStyle As Integer
    Dim romlistUsoAlign As Integer
    Dim romlistUsoAltezzaRiga As Integer
    Dim romlistW As Integer
    Dim romlistH As Integer

    Dim colorePrincipale As Color
    Dim coloreSecondario As Color
    Dim coloreSecondarioBack As Color

    Dim main(9) As Bitmap
    Dim contaImmaginiMain As Integer = 0
    Dim nImmagineMain As Integer = 0
    Dim background_frame_duration_ms As Integer
    Dim background_repeat_delay_ms As Integer

    Dim actors(9) As Bitmap
    Dim contaImmaginiActors As Integer = 0
    Dim nImmagineActors As Integer = 0
    Dim actors_frame_duration_ms As Integer
    Dim actors_repeat_delay_ms As Integer
    Dim actorsStart(9) As Bitmap
    Dim contaImmaginiActorsStart As Integer = 0
    Dim nImmagineActorsStart As Integer = 0
    Dim actors_start As Boolean = False
    Dim actors_startCTRL As Boolean = False

    Dim bezel(9) As Bitmap
    Dim contaImmaginiBezel As Integer = 0
    Dim nImmagineBezel As Integer = 0
    Dim bezel_frame_duration_ms As Integer
    Dim bezel_repeat_delay_ms As Integer
    Dim bezelStart(9) As Bitmap
    Dim contaImmaginiBezelStart As Integer = 0
    Dim nImmagineBezelStart As Integer = 0
    Dim bezel_start As Boolean = False
    Dim bezel_startCTRL As Boolean = False

    Dim pannelliBMP(22) As Bitmap
    Dim pannelliBMPNomi(22) As String
    Dim pannelliBMPX(22) As Integer
    Dim pannelliBMPY(22) As Integer
    Dim pannelliBMPW(22) As Integer
    Dim pannelliBMPH(22) As Integer
    Dim pannelliBMPIndexUltimo As Integer = 0
    Dim pannelliBMPelenco = New List(Of Integer)

    Private Sub FormFLManteprimaV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usocolor As String
        Dim coloreA As Integer
        Dim coloreR As Integer
        Dim coloreG As Integer
        Dim coloreB As Integer

        dt = FormFLM.dtOptionsLayout

        For Each obj As String In FormFLM.ListBoxObj.Items
            arrayObj(FormFLM.ListBoxObj.Items.IndexOf(obj)) = obj
        Next

        dtRoms = New DataTable

        dtRoms.Columns.Add("romlist", Type.GetType("System.String"))
        dtRoms.Columns.Add("romcounter", Type.GetType("System.String"))
        dtRoms.Columns.Add("platformname", Type.GetType("System.String"))
        dtRoms.Columns.Add("emulatorname", Type.GetType("System.String"))
        dtRoms.Columns.Add("gamelistname", Type.GetType("System.String"))
        dtRoms.Columns.Add("romname", Type.GetType("System.String"))
        dtRoms.Columns.Add("romdescription", Type.GetType("System.String"))
        dtRoms.Columns.Add("rommanufacturer", Type.GetType("System.String"))
        dtRoms.Columns.Add("romdisplaytype", Type.GetType("System.String"))
        dtRoms.Columns.Add("rominputcontrol", Type.GetType("System.String"))
        dtRoms.Columns.Add("romstatus", Type.GetType("System.String"))
        dtRoms.Columns.Add("romcategory", Type.GetType("System.String"))

        dtRoms.Rows.Add("88games", "romcounter1", "platformname1", "emulatorname1", "gamelistname1", "'88 Games", "romdescription1", "Konami", "Horizontal", "Buttons only", "GOOD", "Sports / Track & Field")
        dtRoms.Rows.Add("gtmr", "romcounter2", "platformname2", "emulatorname2", "gamelistname2", "1000 Miglia: Great 1000 Miles Rally (94/07/18)", "romdescription2", "Kaneko", "Horizontal", "Joystick 8 ways, Dial, Paddle", "GOOD", "Driving / Race")
        dtRoms.Rows.Add("1941", "romcounter3", "platformname3", "emulatorname3", "gamelistname3", "1941: Counter Attack (World 900227)", "romdescription3", "Capcom", "Vertical", "Joystick 8 ways", "GOOD", "Shooter / Flying Vertical")
        dtRoms.Rows.Add("amazon", "romcounter4", "platformname4", "emulatorname4", "gamelistname4", "Soldier Girl Amazon", "romdescription4", "Nichibutsu", "Vertical", "Joystick 8 ways", "GOOD", "Shooter / Walking")
        dtRoms.Rows.Add("altbeast", "romcounter5", "platformname5", "emulatorname5", "gamelistname5", "Altered Beast (set 8) (8751 317-0078)", "romdescription5", "Sega", "Horizontal", "Joystick 8 ways", "GOOD", "Platform / Fighter Scrolling")
        dtRoms.Rows.Add("badlands", "romcounter6", "platformname6", "emulatorname6", "gamelistname6", "Bad Lands", "romdescription6", "Atari Games", "Horizontal", "Dial", "GOOD", "Driving / Race Track")
        dtRoms.Rows.Add("digdug", "romcounter7", "platformname7", "emulatorname7", "gamelistname7", "Dig Dug (rev 2)", "romdescription7", "Namco", "Vertical", "Joystick 4 ways", "GOOD", "Maze / Digging")
        dtRoms.Rows.Add("rampage", "romcounter8", "platformname8", "emulatorname8", "gamelistname8", "Rampage (Rev 3, 8/27/86)", "romdescription8", "Bally Midway", "Horizontal", "Joystick 8 ways", "GOOD", "Platform / Fighter")
        dtRoms.Rows.Add("sf2", "romcounter9", "platformname9", "emulatorname9", "gamelistname9", "Street Fighter II: The World Warrior (World 910522)", "romdescription9", "Capcom", "Horizontal", "Joystick 8 ways", "GOOD", "Fighter / Versus")

        '----------------------------------------------------------------------------------------------
        '---sound----
        'sound_fx_confirm                        invader_confirm.wav
        'sound_fx_cancel                         invader_cancel.wav
        'sound_fx_volume                         100

        '----------------------------------------------------------------------------------------------
        '---music----
        If dt.Rows(dt.Rows.Count - 1).Item("music_path").ToString.Length > 2 Then
            Try
                mp3playerMusic.VolumeAll = Int(dt.Rows(dt.Rows.Count - 1).Item("music_volume"))
                mp3playerMusic.Looping = True
                mp3playerMusic.Open(FormFLM.feelPath & "\media\" & dt.Rows(dt.Rows.Count - 1).Item("music_path"))
                mp3playerMusic.Play()
            Catch ex As Exception
                MsgBox("Attenzione! Verificare il file audio musicale impostato!")
            End Try
        End If

        '----------------------------------------------------------------------------------------------
        '---screen----
        Me.Size = New Size(Int(dt.Rows(dt.Rows.Count - 1).Item("screen_res_x")), Int(dt.Rows(dt.Rows.Count - 1).Item("screen_res_y")))

        Try
            main(0) = Bitmap.FromFile(FormFLM.LabelPercorso.Text & "\main.png")
            pannelliBMP(0) = main(0)
            pannelliBMPNomi(0) = "base"
            pannelliBMPX(0) = 0
            pannelliBMPY(0) = 0
            pannelliBMPW(0) = Me.Width
            pannelliBMPH(0) = Me.Height
            pannelliBMPelenco.Add(2)
        Catch ex As Exception

        End Try
        'screen_saver_backcolor                  0, 0, 0
        'screen_saver_font_color                 0, 96, 96

        '----------------------------------------------------------------------------------------------
        '---romlist----
        romlistW = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_width"))
        romlistH = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_height"))
        romlistUsoFont = dt.Rows(dt.Rows.Count - 1).Item("romlist_font_name")
        romlistUsoSize = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_font_size"))
        romlistUsoStyle = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_font_style"))
        romlistUsoAltezzaRiga = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_item_height"))
        usocolor = dt.Rows(dt.Rows.Count - 1).Item("romlist_font_color")
        romlistUsoAlign = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_text_align"))

        Dim contaValori() As String = usocolor.Split(",")

        coloreA = 255
        coloreR = Int(contaValori(0))
        coloreG = Int(contaValori(1))
        coloreB = Int(contaValori(2))

        colorePrincipale = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

        usocolor = dt.Rows(dt.Rows.Count - 1).Item("romlist_selected_font_color")

        Dim contaValori2() As String = usocolor.Split(",")

        coloreR = Int(contaValori2(0))
        coloreG = Int(contaValori2(1))
        coloreB = Int(contaValori2(2))

        If contaValori2.Length = 4 Then
            coloreA = Int(contaValori2(3))
        Else
            coloreA = 255
        End If

        coloreSecondario = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

        Romlist(0)

        ''romlist_backcolor                       11, 86, 162, 0

        ''PanelRomlist.Controls("LabelRomlist_0").ForeColor = coloreSecondario

        ''usocolor = dt.Rows(dt.Rows.Count - 1).Item("romlist_selected_backcolor")

        ''Dim contaValori3() As String = usocolor.Split(",")

        ''coloreR = Int(contaValori3(0))
        ''coloreG = Int(contaValori3(1))
        ''coloreB = Int(contaValori3(2))

        ''If contaValori3.Length = 4 Then
        ''    coloreA = Int(contaValori3(3))
        ''Else
        ''    coloreA = 255
        ''End If

        ''coloreSecondarioBack = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

        ''PanelRomlist.Controls("LabelRomlist_0").BackColor = coloreSecondarioBack

        'OLD romlist_disable_stars                   0

        Try
            pannelliBMPNomi(4) = "romlist"
            pannelliBMPX(4) = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_x_pos"))
            pannelliBMPY(4) = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_y_pos"))
            pannelliBMPW(4) = romlistW
            pannelliBMPH(4) = romlistH
            pannelliBMPelenco.Add(4)
        Catch ex As Exception

        End Try

        indiceRom = 0

        '----------------------------------------------------------------------------------------------
        '---background----
        Dim timerMainOK As Boolean = False
        Dim esci As Boolean = False

        Try

            pannelliBMP(2) = main(0)
            pannelliBMPNomi(2) = "background"
            pannelliBMPX(2) = 0
            pannelliBMPY(2) = 0
            pannelliBMPW(2) = Int(dt.Rows(dt.Rows.Count - 1).Item("background_width"))
            pannelliBMPH(2) = Int(dt.Rows(dt.Rows.Count - 1).Item("background_height"))
        Catch ex As Exception
            esci = True
        End Try

        Do
            If Not esci Then
                Try
                    contaImmaginiMain += 1
                    main(contaImmaginiMain) = New Bitmap(Image.FromFile(FormFLM.LabelPercorso.Text & "\main" & contaImmaginiMain & ".png"), Me.Width, Me.Height)

                    timerMainOK = True
                Catch ex As Exception
                    esci = True
                End Try

            End If
        Loop Until esci

        esci = False

        'OLD background_ontop                        0

        background_frame_duration_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("background_frame_duration_ms"))
        Try
            TimerMain.Interval = background_frame_duration_ms
        Catch ex As Exception

        End Try
        background_repeat_delay_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("background_repeat_delay_ms"))

        '----------------------------------------------------------------------------------------------
        '---snapshot/cabinet/marquee----
        Try
            If My.Computer.FileSystem.FileExists(".\anteprima\media\images\" & dtRoms.Rows(0).Item("romlist") & ".png") Then
                pannelliBMP(5) = New Bitmap(Image.FromFile(".\anteprima\media\images\" & dtRoms.Rows(0).Item("romlist") & ".png"), dt.Rows(dt.Rows.Count - 1).Item("snapshot_width"), dt.Rows(dt.Rows.Count - 1).Item("snapshot_height"))
            Else
                Dim w As Int32 = Int(dt.Rows(dt.Rows.Count - 1).Item("snapshot_width"))
                Dim h As Int32 = Int(dt.Rows(dt.Rows.Count - 1).Item("snapshot_height"))
                pannelliBMP(5) = New Bitmap(w, h)
            End If

            pannelliBMPNomi(5) = "snapshot"
            pannelliBMPX(5) = dt.Rows(dt.Rows.Count - 1).Item("snapshot_x_pos")
            pannelliBMPY(5) = dt.Rows(dt.Rows.Count - 1).Item("snapshot_y_pos")
            pannelliBMPW(5) = dt.Rows(dt.Rows.Count - 1).Item("snapshot_width")
            pannelliBMPH(5) = dt.Rows(dt.Rows.Count - 1).Item("snapshot_height")
            pannelliBMPelenco.Add(5)
        Catch ex As Exception

        End Try

        Try
            If dt.Rows(dt.Rows.Count - 1).Item("cabinet_visible") Then
                If My.Computer.FileSystem.FileExists(".\anteprima\media\cabinets\" & dtRoms.Rows(0).Item("romlist") & ".png") Then
                    pannelliBMP(6) = New Bitmap(Image.FromFile(".\anteprima\media\cabinets\" & dtRoms.Rows(0).Item("romlist") & ".png"), dt.Rows(dt.Rows.Count - 1).Item("cabinet_width"), dt.Rows(dt.Rows.Count - 1).Item("cabinet_height"))
                Else
                    Dim w As Int32 = Int(dt.Rows(dt.Rows.Count - 1).Item("cabinet_width"))
                    Dim h As Int32 = Int(dt.Rows(dt.Rows.Count - 1).Item("cabinet_height"))
                    pannelliBMP(6) = New Bitmap(w, h)
                End If

                pannelliBMPNomi(6) = "cabinet"
                pannelliBMPX(6) = dt.Rows(dt.Rows.Count - 1).Item("cabinet_x_pos")
                pannelliBMPY(6) = dt.Rows(dt.Rows.Count - 1).Item("cabinet_y_pos")
                pannelliBMPW(6) = dt.Rows(dt.Rows.Count - 1).Item("cabinet_width")
                pannelliBMPH(6) = dt.Rows(dt.Rows.Count - 1).Item("cabinet_height")
                pannelliBMPelenco.Add(6)
            End If
        Catch ex As Exception

        End Try

        Try
            If dt.Rows(dt.Rows.Count - 1).Item("marquee_visible") Then
                If My.Computer.FileSystem.FileExists(".\anteprima\media\cabinets\" & dtRoms.Rows(0).Item("romlist") & ".png") Then
                    pannelliBMP(7) = New Bitmap(Image.FromFile(".\anteprima\media\marquees\" & dtRoms.Rows(0).Item("romlist") & ".png"), dt.Rows(dt.Rows.Count - 1).Item("marquee_width"), dt.Rows(dt.Rows.Count - 1).Item("marquee_height"))
                Else
                    Dim w As Int32 = Int(dt.Rows(dt.Rows.Count - 1).Item("marquee_width"))
                    Dim h As Int32 = Int(dt.Rows(dt.Rows.Count - 1).Item("marquee_height"))
                    pannelliBMP(7) = New Bitmap(w, h)
                End If

                pannelliBMPNomi(7) = "marquee"
                pannelliBMPX(7) = dt.Rows(dt.Rows.Count - 1).Item("marquee_x_pos")
                pannelliBMPY(7) = dt.Rows(dt.Rows.Count - 1).Item("marquee_y_pos")
                pannelliBMPW(7) = dt.Rows(dt.Rows.Count - 1).Item("marquee_width")
                pannelliBMPH(7) = dt.Rows(dt.Rows.Count - 1).Item("marquee_height")
                pannelliBMPelenco.Add(7)
            End If
        Catch ex As Exception

        End Try

        '----------------------------------------------------------------------------------------------
        '---pannelli----
        Pannelli()

        PanelMenu.Size = New Size(dt.Rows(dt.Rows.Count - 1).Item("menu_width"), Me.Size.Height - 100) 'TODO da verificare dimensione, nota solo la width
        PanelMenu.Location = New Point(Int((Me.Size.Width - PanelMenu.Size.Width) / 2), 50) 'TODO da verificare la posizione

        pannelliBMPIndexUltimo = 19

        '----------------------------------------------------------------------------------------------
        '---menu----
        Dim usoFontMenu As String = dt.Rows(dt.Rows.Count - 1).Item("menu_font_name")
        Dim usoSizeMenu As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item("menu_font_size"))
        Dim usoStyleMenu As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item("menu_font_style"))

        usocolor = dt.Rows(dt.Rows.Count - 1).Item("menu_font_color")

        Dim contaValori4() As String = usocolor.Split(",")

        coloreA = 255
        coloreR = Int(contaValori4(0))
        coloreG = Int(contaValori4(1))
        coloreB = Int(contaValori4(2))

        usocolor = dt.Rows(dt.Rows.Count - 1).Item("menu_backcolor")

        Dim contaValori5() As String = usocolor.Split(",")

        Dim coloreA2 As Integer
        Dim coloreR2 As Integer = Int(contaValori5(0))
        Dim coloreG2 As Integer = Int(contaValori5(1))
        Dim coloreB2 As Integer = Int(contaValori5(2))

        If contaValori5.Length = 4 Then
            coloreA2 = Int(contaValori5(3))
        Else
            coloreA2 = 255
        End If

        For Each labelMenu As Label In PanelMenu.Controls
            labelMenu.Font = New Font(usoFontMenu, usoSizeMenu, usoStyleMenu, GraphicsUnit.Point)
            labelMenu.Size = New Size(labelMenu.Size.Width, Int(dt.Rows(dt.Rows.Count - 1).Item("menu_item_height")))
            labelMenu.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            labelMenu.BackColor = Color.FromArgb(coloreA2, coloreR2, coloreG2, coloreB2)
        Next

        PanelMenu.BackColor = Color.FromArgb(coloreA2, coloreR2, coloreG2, coloreB2)

        usocolor = dt.Rows(dt.Rows.Count - 1).Item("menu_selected_font_color")

        Dim contaValori6() As String = usocolor.Split(",")

        coloreR = Int(contaValori6(0))
        coloreG = Int(contaValori6(1))
        coloreB = Int(contaValori6(2))

        If contaValori6.Length = 4 Then
            coloreA = Int(contaValori6(3))
        Else
            coloreA = 255
        End If

        LabelMenuSelectTOPGAMES.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

        usocolor = dt.Rows(dt.Rows.Count - 1).Item("menu_selected_backcolor")

        Dim contaValori7() As String = usocolor.Split(",")

        coloreR = Int(contaValori7(0))
        coloreG = Int(contaValori7(1))
        coloreB = Int(contaValori7(2))

        If contaValori7.Length = 4 Then
            coloreA = Int(contaValori7(3))
        Else
            coloreA = 255
        End If

        LabelMenuSelectTOPGAMES.BackColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

        'menu_show_sidebar                       1

        '----------------------------------------------------------------------------------------------
        '---actors----
        Dim timerActorsOK As Boolean = False

        Try
            actors(0) = Bitmap.FromFile(FormFLM.LabelPercorso.Text & "\actors.png")
            pannelliBMP(19) = actors(0)
            pannelliBMPNomi(19) = "actors"
            pannelliBMPX(19) = 0
            pannelliBMPY(19) = 0
            pannelliBMPW(19) = Me.Width
            pannelliBMPH(19) = Me.Height

            timerActorsOK = True
            pannelliBMPIndexUltimo = 20
            pannelliBMPelenco.Add(19)
        Catch ex As Exception

        End Try

        Do
            If Not esci Then
                Try
                    contaImmaginiActors += 1
                    actors(contaImmaginiActors) = New Bitmap(Image.FromFile(FormFLM.LabelPercorso.Text & "\actors" & contaImmaginiActors & ".png"), Me.Width, Me.Height)
                Catch ex As Exception
                    esci = True
                End Try
            End If
        Loop Until esci

        esci = False

        actors_frame_duration_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("actors_frame_duration_ms"))
        Try
            TimerActors.Interval = actors_frame_duration_ms
        Catch ex As Exception

        End Try
        actors_repeat_delay_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("actors_repeat_delay_ms"))

        Try
            actorsStart(0) = Bitmap.FromFile(FormFLM.LabelPercorso.Text & "\actors_start.png")
            pannelliBMP(20) = actorsStart(0)
            pannelliBMPNomi(20) = "actors_start"
            pannelliBMPX(20) = 0
            pannelliBMPY(20) = 0
            pannelliBMPW(20) = Me.Width
            pannelliBMPH(20) = Me.Height

            actors_start = True
            pannelliBMPIndexUltimo = 21
        Catch ex As Exception

        End Try

        Do
            If Not esci Then
                Try
                    contaImmaginiActorsStart += 1
                    actorsStart(contaImmaginiActorsStart) = New Bitmap(Image.FromFile(FormFLM.LabelPercorso.Text & "\actors_start" & contaImmaginiActorsStart & ".png"), Me.Width, Me.Height)
                Catch ex As Exception
                    esci = True
                End Try
            End If
        Loop Until esci

        esci = False

        '----------------------------------------------------------------------------------------------
        '---bezel----
        Dim timerBezelOK As Boolean = False

        Try
            bezel(0) = Bitmap.FromFile(FormFLM.LabelPercorso.Text & "\bezel.png")
            pannelliBMP(21) = bezel(0)
            pannelliBMPNomi(21) = "bezel"
            pannelliBMPX(21) = 0
            pannelliBMPY(21) = 0
            pannelliBMPW(21) = Me.Width
            pannelliBMPH(21) = Me.Height

            timerBezelOK = True
            pannelliBMPIndexUltimo = 22
            pannelliBMPelenco.Add(21)
        Catch ex As Exception

        End Try

        Do
            If Not esci Then
                Try
                    contaImmaginiBezel += 1
                    bezel(contaImmaginiBezel) = New Bitmap(Image.FromFile(FormFLM.LabelPercorso.Text & "\bezel" & contaImmaginiBezel & ".png"), Me.Width, Me.Height)
                Catch ex As Exception
                    esci = True
                End Try
            End If
        Loop Until esci

        esci = False

        bezel_frame_duration_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("bezel_frame_duration_ms"))
        Try
            TimerBezel.Interval = bezel_frame_duration_ms
        Catch ex As Exception

        End Try
        bezel_repeat_delay_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("bezel_repeat_delay_ms"))

        Try
            bezelStart(0) = Bitmap.FromFile(FormFLM.LabelPercorso.Text & "\bezel_start.png")
            pannelliBMP(22) = bezelStart(0)
            pannelliBMPNomi(22) = "bezel_start"
            pannelliBMPX(22) = 0
            pannelliBMPY(22) = 0
            pannelliBMPW(22) = Me.Width
            pannelliBMPH(22) = Me.Height

            bezel_start = True
            pannelliBMPIndexUltimo = 23
        Catch ex As Exception

        End Try

        Do
            If Not esci Then
                Try
                    contaImmaginiBezelStart += 1
                    bezelStart(contaImmaginiBezelStart) = New Bitmap(Image.FromFile(FormFLM.LabelPercorso.Text & "\bezel_start" & contaImmaginiBezelStart & ".png"), Me.Width, Me.Height)
                Catch ex As Exception
                    esci = True
                End Try
            End If
        Loop Until esci

        '----------------------------------------------------------------------------------------------
        If timerMainOK Then TimerMain.Start()
        If timerActorsOK Then TimerActors.Start()
        If timerBezelOK Then TimerBezel.Start()
    End Sub

    Private Sub Romlist(itemSelected As Integer)
        Dim posizioneX As Integer
        Dim posizioney As Integer
        Dim posizioneYDelta As Integer = Int((romlistUsoAltezzaRiga - romlistUsoSize) / 2)

        Dim tmpImg As Bitmap = New Bitmap(romlistW, romlistH)
        Dim gRomlist As Graphics = Graphics.FromImage(tmpImg)

        For i As Integer = 0 To dtRoms.Rows.Count - 1
            Select Case romlistUsoAlign
                Case 0
                    posizioneX = 0
                Case 1
                    posizioneX = Int((romlistW - romlistUsoSize * dtRoms.Rows(i).Item(0).ToString.Length) / 2)
                Case 2
                    posizioneX = romlistW - romlistUsoSize * dtRoms.Rows(i).Item(0).ToString.Length
            End Select

            posizioney = romlistUsoAltezzaRiga * i + posizioneYDelta
            If i = itemSelected Then
                gRomlist.DrawString(dtRoms.Rows(i).Item(0), New Font(romlistUsoFont, romlistUsoSize, romlistUsoStyle, GraphicsUnit.Point), New SolidBrush(coloreSecondario), posizioneX, posizioney)
            Else
                gRomlist.DrawString(dtRoms.Rows(i).Item(0), New Font(romlistUsoFont, romlistUsoSize, romlistUsoStyle, GraphicsUnit.Point), New SolidBrush(colorePrincipale), posizioneX, posizioney)
            End If
        Next

        Try
            pannelliBMP(4) = tmpImg
            gRomlist.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Pannelli()
        For i As Integer = 8 To 18 'TODO modificare se si vogliono parametrizzare gli altri pannelli
            If dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_visible") Then
                Dim usoFont As String = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_font_name")
                Dim usoSize As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_font_size"))
                Dim usoStyle As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_font_style"))
                Dim usoColor As String = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_font_color")
                Dim usoAlign As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_text_align"))

                Dim contaValori() As String = usoColor.Split(",")

                Dim posizioneX As Integer
                Dim posizioneY As Integer

                Dim w As Integer = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_width")
                Dim h As Integer = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_height")

                Dim coloreA As Integer = 255
                Dim coloreR As Integer = Int(contaValori(0))
                Dim coloreG As Integer = Int(contaValori(1))
                Dim coloreB As Integer = Int(contaValori(2))

                If contaValori.Length = 4 Then
                    coloreA = Int(contaValori(3))
                End If

                posizioneY = Int((h - usoSize) / 2)

                Select Case usoAlign
                    Case 0
                        posizioneX = 0
                    Case 1
                        posizioneX = Int((w - dtRoms.Rows(indiceRom).Item(arrayObj(i)).ToString.Length * usoSize) / 2)
                    Case 2
                        posizioneX = Int(w - dtRoms.Rows(indiceRom).Item(arrayObj(i)).ToString.Length * usoSize)
                End Select

                Dim g As Graphics
                Dim imgtemp As Bitmap = New Bitmap(w, h)

                g = Graphics.FromImage(imgtemp)

                'TODO gestire il backcolor del testo
                'usoColor = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_backcolor")
                'Dim contaValori2() As String = usoColor.Split(",")

                'coloreR = Int(contaValori2(0))
                'coloreG = Int(contaValori2(1))
                'coloreB = Int(contaValori2(2))

                'If contaValori2.Length = 4 Then
                '    coloreSecondarioBack = Color.Transparent
                'Else
                '    coloreSecondarioBack = Color.FromArgb(255, coloreR, coloreG, coloreB)
                'End If

                'If coloreSecondarioBack <> Color.Transparent Then
                '    g.FillRectangle(New SolidBrush(coloreSecondarioBack), New Rectangle(0, 0, w, h))
                'End If

                g.DrawString(dtRoms.Rows(indiceRom).Item(arrayObj(i)), New Font(usoFont, usoSize, usoStyle, GraphicsUnit.Point), New SolidBrush(Color.FromArgb(coloreA, coloreR, coloreG, coloreB)), posizioneX, posizioneY)
                pannelliBMPNomi(i) = arrayObj(i)
                pannelliBMPX(i) = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_x_pos")
                pannelliBMPY(i) = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_y_pos")
                pannelliBMPW(i) = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_width")
                pannelliBMPH(i) = dt.Rows(dt.Rows.Count - 1).Item(arrayObj(i) & "_height")
                pannelliBMP(i) = imgtemp
                pannelliBMPelenco.Add(i)
            End If
        Next

    End Sub

    Private Sub AggiornaSfondo2()
        Dim g As Graphics
        Dim image As Bitmap = New Bitmap(Me.Width, Me.Height)

        g = Graphics.FromImage(image)
        Dim g2 As Graphics = Graphics.FromHwnd(PanelBackground.Handle)
        g.SmoothingMode = Drawing2D.SmoothingMode.None
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g2.SmoothingMode = Drawing2D.SmoothingMode.None
        g2.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        For Each i As Integer In pannelliBMPelenco
            Try
                Dim imgtemp As Bitmap = New Bitmap(pannelliBMP(i), New Size(pannelliBMPW(i), pannelliBMPH(i)))
                g.DrawImage(imgtemp, New Point(pannelliBMPX(i), pannelliBMPY(i)))
            Catch ex As Exception

            End Try
        Next

        g2.DrawImage(image, 0, 0)

    End Sub

    Private Sub Panel_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles PanelBackground.PreviewKeyDown, MyBase.PreviewKeyDown
        Dim esci As Boolean = False

        Select Case e.Modifiers
            Case Keys.Alt
                PanelMenu.Visible = Not PanelMenu.Visible

                Try
                    My.Computer.Audio.Play(FormFLM.feelPath & "\media\" & dt.Rows(dt.Rows.Count - 1).Item("sound_fx_menu"), AudioPlayMode.Background)
                Catch ex As Exception

                End Try
            Case Keys.Control
                If actors_start Then
                    actors_startCTRL = True
                    Try
                        pannelliBMPelenco.remove(19)
                        pannelliBMPelenco.remove(21)
                        pannelliBMPelenco.add(20)
                        pannelliBMPelenco.add(21)
                    Catch ex As Exception

                    End Try
                End If

                If bezel_start Then
                    bezel_startCTRL = True
                    Try
                        pannelliBMPelenco.remove(21)
                        pannelliBMPelenco.add(22)
                    Catch ex As Exception

                    End Try
                End If

                Try
                    My.Computer.Audio.Play(FormFLM.feelPath & "\media\" & dt.Rows(dt.Rows.Count - 1).Item("sound_fx_startemu"), AudioPlayMode.Background)
                Catch ex As Exception

                End Try
            Case Else
                PanelMenu.Visible = False

                Select Case e.KeyCode
                    Case Keys.Up
                        indiceRom -= 1

                        If indiceRom < 0 Then
                            indiceRom = dtRoms.Rows.Count - 1
                        End If

                        Romlist(indiceRom)

                        Try
                            My.Computer.Audio.Play(FormFLM.feelPath & "\media\" & dt.Rows(dt.Rows.Count - 1).Item("sound_fx_list"), AudioPlayMode.Background)
                        Catch ex As Exception

                        End Try
                    Case Keys.Down
                        indiceRom += 1

                        If indiceRom = dtRoms.Rows.Count Then
                            indiceRom = 0
                        End If

                        Romlist(indiceRom)

                        Try
                            My.Computer.Audio.Play(FormFLM.feelPath & "\media\" & dt.Rows(dt.Rows.Count - 1).Item("sound_fx_list"), AudioPlayMode.Background)
                        Catch ex As Exception

                        End Try
                    Case Keys.Escape
                        esci = True
                End Select
        End Select

        Try
            pannelliBMP(5) = Image.FromFile(".\anteprima\media\images\" & dtRoms.Rows(indiceRom).Item("romlist") & ".png")
        Catch ex As Exception
            pannelliBMP(5) = Nothing
        End Try

        Try
            pannelliBMP(6) = Image.FromFile(".\anteprima\media\cabinets\" & dtRoms.Rows(indiceRom).Item("romlist") & ".png")
        Catch ex As Exception
            pannelliBMP(6) = Nothing
        End Try

        Try
            pannelliBMP(7) = Image.FromFile(".\anteprima\media\marquees\" & dtRoms.Rows(indiceRom).Item("romlist") & ".png")
        Catch ex As Exception
            pannelliBMP(7) = Nothing
        End Try

        pannelli()

        AggiornaSfondo2()

        If esci Then
            mp3playerMusic.Close()
            Me.Close()
        End If
    End Sub

    Private Sub TimerMain_Tick(sender As Object, e As EventArgs) Handles TimerMain.Tick
        nImmagineMain += 1

        If nImmagineMain = contaImmaginiMain Then
            nImmagineMain = 0

            If background_repeat_delay_ms > 0 Then
                TimerMainDelay.Interval = background_repeat_delay_ms
                TimerMainDelay.Start()
            End If
        End If

        Try
            pannelliBMP(2) = main(nImmagineMain)
            AggiornaSfondo2()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TimerMainDelay_Tick(sender As Object, e As EventArgs) Handles TimerMainDelay.Tick
        TimerMainDelay.Stop()
    End Sub

    Private Sub TimerActors_Tick(sender As Object, e As EventArgs) Handles TimerActors.Tick
        If actors_startCTRL Then 'actors start
            nImmagineActorsStart += 1

            If nImmagineActorsStart = contaImmaginiActorsStart Then
                nImmagineActorsStart = 0
                nImmagineActors = 0

                pannelliBMPelenco.remove(20)
                pannelliBMPelenco.remove(21)
                pannelliBMPelenco.add(19)
                pannelliBMPelenco.add(21)

                actors_startCTRL = False
            End If

            Try
                pannelliBMP(20) = actorsStart(nImmagineActorsStart)
                AggiornaSfondo2()
            Catch ex As Exception

            End Try
        Else 'actors normale
            nImmagineActors += 1

            If nImmagineActors = contaImmaginiActors Then
                nImmagineActors = 0
            End If

            If (nImmagineActors = (contaImmaginiActors - 1)) And (actors_repeat_delay_ms > 0) Then
                TimerActorsDelay.Interval = actors_repeat_delay_ms
                TimerActors.Stop()
                TimerActorsDelay.Start()
            End If

            Try
                pannelliBMP(19) = actors(nImmagineActors)
                AggiornaSfondo2()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TimerActorsDelay_Tick(sender As Object, e As EventArgs) Handles TimerActorsDelay.Tick
        TimerActorsDelay.Stop()
        TimerActors.Start()
    End Sub

    Private Sub TimerBezel_Tick(sender As Object, e As EventArgs) Handles TimerBezel.Tick
        If bezel_startCTRL Then 'bezel start
            nImmagineBezelStart += 1

            If (nImmagineBezelStart = contaImmaginiBezelStart) Then
                nImmagineBezelStart = 0
                nImmagineBezel = 0

                pannelliBMPelenco.remove(22)
                pannelliBMPelenco.add(21)

                bezel_startCTRL = False
            End If

            Try
                pannelliBMP(22) = bezelStart(nImmagineBezelStart)
                AggiornaSfondo2()
            Catch ex As Exception

            End Try
        Else 'bezel normale
            nImmagineBezel += 1

            If (nImmagineBezel = contaImmaginiBezel) Then
                nImmagineBezel = 0
            End If

            If (nImmagineBezel = (contaImmaginiBezel - 1)) And (bezel_repeat_delay_ms > 0) Then
                TimerBezelDelay.Interval = bezel_repeat_delay_ms
                TimerBezel.Stop()
                TimerBezelDelay.Start()
            End If

            Try
                pannelliBMP(21) = bezel(nImmagineBezel)
                AggiornaSfondo2()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TimerBezelDelay_Tick(sender As Object, e As EventArgs) Handles TimerBezelDelay.Tick
        TimerBezelDelay.Stop()
        TimerBezel.Start()
    End Sub

End Class