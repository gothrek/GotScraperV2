Public Class FormFLManteprima
    Dim dt As DataTable
    Dim dtRoms As DataTable
    Dim indiceRom As Integer

    Dim colorePrincipale As Color
    Dim coloreSecondario As Color
    Dim coloreSecondarioBack As Color

    Dim main(9) As Bitmap
    Dim contaImmaginiMain As Integer = 1
    Dim nImmagineMain As Integer = 0
    Dim background_frame_duration_ms As Integer
    Dim background_repeat_delay_ms As Integer

    Dim actors(9) As Bitmap
    Dim contaImmaginiActors As Integer = 1
    Dim nImmagineActors As Integer = 0
    Dim actors_frame_duration_ms As Integer
    Dim actors_repeat_delay_ms As Integer

    Dim bezel(9) As Bitmap
    Dim contaImmaginiBezel As Integer = 1
    Dim nImmagineBezel As Integer = 0
    Dim bezel_frame_duration_ms As Integer
    Dim bezel_repeat_delay_ms As Integer

    Dim pannelliBMP(200) As Bitmap
    Dim pannelliBMPNomi(200) As String
    Dim pannelliBMPIndex As Integer

    Dim eventoPaint As Boolean = True

    Private Sub FormFLManteprima_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt = FormFLM.dtOptionsLayout
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
        'sound_fx_list                           invader_list.wav
        'sound_fx_menu                           invader_menu.wav
        'sound_fx_confirm                        invader_confirm.wav
        'sound_fx_cancel                         invader_cancel.wav
        'sound_fx_startemu                       goal.wav
        'sound_fx_volume                         100

        '----------------------------------------------------------------------------------------------
        '---music----
        'music_path                              wizball.mp3
        'music_volume                            5

        '----------------------------------------------------------------------------------------------
        '---screen----
        'screen_saver_backcolor                  0, 0, 0
        'screen_saver_font_color                 0, 96, 96

        '----------------------------------------------------------------------------------------------
        '---romlist----
        Dim usocolor As String
        Dim coloreA As Integer
        Dim coloreR As Integer
        Dim coloreG As Integer
        Dim coloreB As Integer

        For i As Integer = 0 To dtRoms.Rows.Count - 1

            Dim usoFont As String = dt.Rows(dt.Rows.Count - 1).Item("romlist_font_name")
            Dim usoSize As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_font_size"))
            Dim usoStyle As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_font_style"))

            usocolor = dt.Rows(dt.Rows.Count - 1).Item("romlist_font_color")

            Dim usoAlign As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_text_align"))
            Dim contaValori() As String = usoColor.Split(",")

            coloreA = 255
            coloreR = Int(contaValori(0))
            coloreG = Int(contaValori(1))
            coloreB = Int(contaValori(2))

            Dim row As Label

            row = New Label With {
            .Name = "LabelRomlist_" & i,
            .AutoSize = False,
            .Font = New Font(usoFont, usoSize, usoStyle, GraphicsUnit.Point),
            .Parent = PanelRomlist,
            .Size = New Size(.Parent.Size.Width, Int(dt.Rows(dt.Rows.Count - 1).Item("romlist_item_height"))),
            .Location = New Point(0, .Size.Height * i),
            .ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB),
            .Text = dtRoms.Rows(i).Item("romlist"),
            .BackColor = Color.Transparent
            }

            colorePrincipale = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

            Select Case usoAlign
                Case 0
                    row.TextAlign = 16
                Case 1
                    row.TextAlign = 32
                Case 2
                    row.TextAlign = 64
            End Select

            AddHandler row.PreviewKeyDown, AddressOf RomlistKeyPressed 'Label_PreviewKeyDown

            PanelRomlist.Controls.Add(row)
        Next

        'romlist_backcolor                       11, 86, 162, 0

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

        PanelRomlist.Controls("LabelRomlist_0").ForeColor = coloreSecondario

        usocolor = dt.Rows(dt.Rows.Count - 1).Item("romlist_selected_backcolor")

        Dim contaValori3() As String = usocolor.Split(",")

        coloreR = Int(contaValori3(0))
        coloreG = Int(contaValori3(1))
        coloreB = Int(contaValori3(2))

        If contaValori3.Length = 4 Then
            coloreA = Int(contaValori3(3))
        Else
            coloreA = 255
        End If

        coloreSecondarioBack = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

        PanelRomlist.Controls("LabelRomlist_0").BackColor = coloreSecondarioBack

        indiceRom = 0

        'OLD romlist_disable_stars                   0

        '----------------------------------------------------------------------------------------------
        '---background----

        Dim esci As Boolean = False

        Try
            main(0) = Bitmap.FromFile(FormFLM.LabelPercorso.Text & "\main.png")
            Me.BackgroundImage = main(0)
            contaImmaginiMain = 1
        Catch ex As Exception
            esci = True
        End Try

        Do
            If File.Exists(FormFLM.LabelPercorso.Text & "\main" & contaImmaginiMain & ".png") Then
                Try
                    main(contaImmaginiMain) = New Bitmap(Image.FromFile(FormFLM.LabelPercorso.Text & "\main" & contaImmaginiMain & ".png"), Me.Width, Me.Height)
                    pannelliBMP(0) = main(contaImmaginiMain)
                    pannelliBMPNomi(0) = Me.Name
                    pannelliBMP(1) = main(contaImmaginiMain)
                    pannelliBMPNomi(1) = PanelBackground.Name
                    contaImmaginiMain += 1
                Catch ex As Exception

                End Try
            Else
                esci = True
            End If
        Loop Until esci Or (contaImmaginiMain = 10)

        esci = False
        contaImmaginiMain -= 1

        'OLD background_ontop                        0

        background_frame_duration_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("background_frame_duration_ms"))
        TimerMain.Interval = background_frame_duration_ms
        background_repeat_delay_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("background_repeat_delay_ms"))

        '----------------------------------------------------------------------------------------------
        '---snapshot/cabinet/marquee----
        If Int(dt.Rows(dt.Rows.Count - 1).Item("snapshot_stretch")) = 1 Then
            PanelSnapshot.BackgroundImageLayout = ImageLayout.Stretch
        End If

        If Int(dt.Rows(dt.Rows.Count - 1).Item("snapshot_blackbackground")) = 1 Then
            PanelSnapshot.BackColor = Color.Black
        End If

        Try
            PanelSnapshot.BackgroundImage = Image.FromFile(".\anteprima\media\images\" & dtRoms.Rows(0).Item("romlist") & ".png")
            pannelliBMP(2) = PanelSnapshot.BackgroundImage
            pannelliBMPNomi(2) = PanelSnapshot.Name
        Catch ex As Exception
            PanelSnapshot.BackgroundImage = Nothing
        End Try

        If Int(dt.Rows(dt.Rows.Count - 1).Item("cabinet_stretch")) = 1 Then
            PanelCabinet.BackgroundImageLayout = ImageLayout.Stretch
        End If

        If Int(dt.Rows(dt.Rows.Count - 1).Item("cabinet_blackbackground")) = 1 Then
            PanelCabinet.BackColor = Color.Black
        End If

        Try
            PanelCabinet.BackgroundImage = Image.FromFile(".\anteprima\media\cabinets\" & dtRoms.Rows(0).Item("romlist") & ".png")
            pannelliBMP(3) = PanelCabinet.BackgroundImage
            pannelliBMPNomi(3) = PanelCabinet.Name
        Catch ex As Exception
            PanelCabinet.BackgroundImage = Nothing
        End Try

        If Int(dt.Rows(dt.Rows.Count - 1).Item("marquee_stretch")) = 1 Then
            PanelMarquee.BackgroundImageLayout = ImageLayout.Stretch
        End If

        If Int(dt.Rows(dt.Rows.Count - 1).Item("marquee_blackbackground")) = 1 Then
            PanelMarquee.BackColor = Color.Black
        End If

        Try
            PanelMarquee.BackgroundImage = Image.FromFile(".\anteprima\media\marquees\" & dtRoms.Rows(0).Item("romlist") & ".png")
            pannelliBMP(4) = PanelMarquee.BackgroundImage
            pannelliBMPNomi(4) = PanelMarquee.Name
        Catch ex As Exception
            PanelMarquee.BackgroundImage = Nothing
        End Try

        '----------------------------------------------------------------------------------------------
        '---pannelli----
        Dim usoOggetto As String

        pannelliBMPIndex = 5
        For Each pannello As Panel In Me.Controls
            usoOggetto = pannello.Name.Substring(5)

            Try
                pannello.Visible = dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_visible")
            Catch ex As Exception
                pannello.Visible = True
            End Try

            Try
                pannello.Location = New Point(dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_x_pos"), dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_y_pos"))
            Catch ex As Exception
                pannello.Location = New Point(0, 0)
            End Try

            Try
                pannello.Size = New Size(dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_width"), dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_height"))
            Catch ex As Exception
                pannello.Visible = False
            End Try
        Next

        '----------------------------------------------------------------------------------------------
        '---menu----
        PanelMenu.Size = New Size(dt.Rows(dt.Rows.Count - 1).Item("menu_width"), Me.Size.Height - 100) 'TODO da verificare dimensione, nota solo la width
        PanelMenu.Location = New Point(Int((Me.Size.Width - PanelMenu.Size.Width) / 2), 50) 'TODO da verificare la posizione

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

        'AggiornaSfondo2()

        '----------------------------------------------------------------------------------------------
        '---actors----
        actors_frame_duration_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("actors_frame_duration_ms"))
        TimerActors.Interval = actors_frame_duration_ms
        actors_repeat_delay_ms = Int(dt.Rows(dt.Rows.Count - 1).Item("actors_repeat_delay_ms"))

        Try
            Dim g As Graphics


            Dim panelActors As Panel

            panelActors = New Panel With {
            .Name = "PanelActors",
            .AutoSize = False,
            .Parent = Me,
            .Size = PanelBackground.Size,
            .Location = PanelBackground.Location,
            .BackColor = Color.Transparent
            }

            g = panelActors.CreateGraphics()
            actors(0) = Image.FromFile(FormFLM.LabelPercorso.Text & "\actors.png")
            g.DrawImage(actors(0), 0, 0)

            AddHandler panelActors.MouseClick, AddressOf FormFLManteprima_MouseClick
            AddHandler panelActors.PreviewKeyDown, AddressOf RomlistKeyPressed 'Label_PreviewKeyDown

            'Me.Controls.Add(panelActors)
            'Me.Controls("panelActors").BringToFront()
            'Me.Controls("PanelMenu").BringToFront()

            contaImmaginiActors = 1
        Catch ex As Exception
            esci = True
        End Try

        Do
            If File.Exists(FormFLM.LabelPercorso.Text & "\actors" & contaImmaginiActors & ".png") And (Not esci) Then
                Try
                    actors(contaImmaginiActors) = Bitmap.FromFile(FormFLM.LabelPercorso.Text & "\actors" & contaImmaginiActors & ".png")
                    contaImmaginiActors += 1
                Catch ex As Exception

                End Try
            Else
                esci = True
            End If
        Loop Until esci Or (contaImmaginiActors = 10)

        esci = False
        contaImmaginiActors -= 1

        '----------------------------------------------------------------------------------------------
        '---bezel----
        'bezel_frame_duration_ms                 100
        'bezel_repeat_delay_ms                   10000

        '----------------------------------------------------------------------------------------------
        '---show----
        'show_extended_messages                  0



        TimerMain.Start()
        'TimerActors.Start()
    End Sub

    Private Sub RomlistKeyPressed(sender As Object, e As PreviewKeyDownEventArgs) Handles PanelSnapshot.PreviewKeyDown, PanelRomstatus.PreviewKeyDown, PanelRomname.PreviewKeyDown, PanelRommanufacturer.PreviewKeyDown, PanelRomlist.PreviewKeyDown, PanelRominputcontrol.PreviewKeyDown, PanelRomdisplaytype.PreviewKeyDown, PanelRomdescription.PreviewKeyDown, PanelRomcounter.PreviewKeyDown, PanelRomcategory.PreviewKeyDown, PanelPlatformname.PreviewKeyDown, PanelMarquee.PreviewKeyDown, PanelGamelistname.PreviewKeyDown, PanelEmulatorname.PreviewKeyDown, PanelCabinet.PreviewKeyDown, PanelBackground.PreviewKeyDown, MyBase.PreviewKeyDown
        Dim esci As Boolean = False

        If e.Modifiers = Keys.Alt Then
            PanelMenu.Visible = Not PanelMenu.Visible
        Else
            PanelMenu.Visible = False

            Select Case e.KeyCode
                Case Keys.Up
                    PanelRomlist.Controls("LabelRomlist_" & indiceRom).ForeColor = colorePrincipale
                    PanelRomlist.Controls("LabelRomlist_" & indiceRom).BackColor = Color.Transparent
                    indiceRom -= 1

                    If indiceRom < 0 Then
                        indiceRom = dtRoms.Rows.Count - 1
                    End If

                Case Keys.Down
                    PanelRomlist.Controls("LabelRomlist_" & indiceRom).ForeColor = colorePrincipale
                    PanelRomlist.Controls("LabelRomlist_" & indiceRom).BackColor = Color.Transparent
                    indiceRom += 1

                    If indiceRom = dtRoms.Rows.Count Then
                        indiceRom = 0
                    End If

                Case Keys.Escape
                    esci = True
            End Select

            PanelRomlist.Controls("LabelRomlist_" & indiceRom).ForeColor = coloreSecondario
            PanelRomlist.Controls("LabelRomlist_" & indiceRom).BackColor = coloreSecondarioBack

            Try
                PanelSnapshot.BackgroundImage = Image.FromFile(".\anteprima\media\images\" & dtRoms.Rows(indiceRom).Item("romlist") & ".png")
            Catch ex As Exception
                PanelSnapshot.BackgroundImage = Nothing
            End Try

            Try
                PanelCabinet.BackgroundImage = Image.FromFile(".\anteprima\media\cabinets\" & dtRoms.Rows(indiceRom).Item("romlist") & ".png")
            Catch ex As Exception
                PanelCabinet.BackgroundImage = Nothing
            End Try

            Try
                PanelMarquee.BackgroundImage = Image.FromFile(".\anteprima\media\marquees\" & dtRoms.Rows(indiceRom).Item("romlist") & ".png")
            Catch ex As Exception
                PanelMarquee.BackgroundImage = Nothing
            End Try

            PanelRomstatus.Refresh()
            PanelRomname.Refresh()
            PanelRommanufacturer.Refresh()
            PanelRominputcontrol.Refresh()
            PanelRomdisplaytype.Refresh()
            PanelRomdescription.Refresh()
            PanelRomcounter.Refresh()
            PanelRomcategory.Refresh()
            PanelPlatformname.Refresh()
            PanelGamelistname.Refresh()
            PanelEmulatorname.Refresh()

            If esci Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub FormFLManteprima_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick,
                                                                                            PanelSnapshot.MouseClick,
                                                                                            PanelRomstatus.MouseClick,
                                                                                            PanelRomname.MouseClick,
                                                                                            PanelRommanufacturer.MouseClick,
                                                                                            PanelRomlist.MouseClick,
                                                                                            PanelRominputcontrol.MouseClick,
                                                                                            PanelRomdisplaytype.MouseClick,
                                                                                            PanelRomdescription.MouseClick,
                                                                                            PanelRomcounter.MouseClick,
                                                                                            PanelRomcategory.MouseClick,
                                                                                            PanelPlatformname.MouseClick,
                                                                                            PanelMenu.MouseClick,
                                                                                            PanelMarquee.MouseClick,
                                                                                            PanelGamelistname.MouseClick,
                                                                                            PanelEmulatorname.MouseClick,
                                                                                            PanelCabinet.MouseClick,
                                                                                            PanelBackground.MouseClick

        If e.Button = MouseButtons.Right Then
            Me.Close()
        End If

    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PanelRomstatus.Paint,
                                                                            PanelRomname.Paint,
                                                                            PanelRommanufacturer.Paint,
                                                                            PanelRominputcontrol.Paint,
                                                                            PanelRomdisplaytype.Paint,
                                                                            PanelRomdescription.Paint,
                                                                            PanelRomcounter.Paint,
                                                                            PanelRomcategory.Paint,
                                                                            PanelPlatformname.Paint,
                                                                            PanelGamelistname.Paint,
                                                                            PanelEmulatorname.Paint


        Dim usoOggetto As String = sender.Name.Substring(5)

            Dim usoFont As String = dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_font_name")
            Dim usoSize As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_font_size"))
            Dim usoStyle As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_font_style"))
            Dim usoColor As String = dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_font_color")
            Dim usoAlign As Integer = Int(dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_text_align"))

            Dim contaValori() As String = usoColor.Split(",")

            Dim posizioneX As Integer
            Dim posizioneY As Integer = Int((sender.size.height - usoSize) / 2)

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = Int(contaValori(0))
            Dim coloreG As Integer = Int(contaValori(1))
            Dim coloreB As Integer = Int(contaValori(2))

            If contaValori.Length = 4 Then
                coloreA = Int(contaValori(3))
            End If

            Select Case usoAlign
                Case 0
                    posizioneX = 0
                Case 1
                    posizioneX = Int((sender.size.width - dtRoms.Rows(indiceRom).Item(usoOggetto).ToString.Length * usoSize) / 2)
                Case 2
                    posizioneX = Int(sender.size.width - dtRoms.Rows(indiceRom).Item(usoOggetto).ToString.Length * usoSize)
            End Select

        If sender.Visible Then
            e.Graphics.DrawString(dtRoms.Rows(indiceRom).Item(usoOggetto), New Font(usoFont, usoSize, usoStyle, GraphicsUnit.Point), New SolidBrush(Color.FromArgb(coloreA, coloreR, coloreG, coloreB)), posizioneX, posizioneY)

            usoColor = dt.Rows(dt.Rows.Count - 1).Item(usoOggetto & "_backcolor")
            Dim contaValori2() As String = usoColor.Split(",")

            coloreR = Int(contaValori2(0))
            coloreG = Int(contaValori2(1))
            coloreB = Int(contaValori2(2))
            If contaValori2.Length = 4 Then
                sender.backcolor = Color.Transparent
            Else
                sender.backcolor = Color.FromArgb(255, coloreR, coloreG, coloreB)
            End If
        End If

        '---------------
        'If eventoPaint Then

        '    Dim w As Int16 = sender.width
        '    Dim h As Int16 = sender.height
        '    Dim panelBMP As Bitmap = New Bitmap(w, h)
        '    sender.DrawToBitmap(panelBMP, sender.ClientRectangle)

        '    pannelliBMP(pannelliBMPIndex) = panelBMP
        '    pannelliBMPNomi(pannelliBMPIndex) = sender.name

        '    pannelliBMPIndex += 1


        '    eventoPaint = False
        'End If
        '---------------

        PanelRomlist.Controls("LabelRomlist_" & indiceRom).Focus()
    End Sub

    Private Sub TimerMain_Tick(sender As Object, e As EventArgs) Handles TimerMain.Tick
        nImmagineMain += 1

        If nImmagineMain > contaImmaginiMain Then
            nImmagineMain = 0

            If background_repeat_delay_ms > 0 Then
                TimerMainDelay.Interval = background_repeat_delay_ms
                TimerMainDelay.Start()
            End If
        End If

        '---Metodo1----
        'Me.SuspendLayout()
        'Me.BackgroundImage = Nothing
        'Me.BackgroundImage = main(nImmagineMain)
        'Me.ResumeLayout()

        '---Metodo2----
        Try
            Dim g As Graphics
            g = PanelBackground.CreateGraphics()
            g.DrawImage(main(nImmagineMain), 0, 0)
        Catch ex As Exception

        End Try

        '---Metodo3----
        'Try
        '    pannelliBMP(1) = main(nImmagineMain)
        '    AggiornaSfondo2()
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub TimerMainDelay_Tick(sender As Object, e As EventArgs) Handles TimerMainDelay.Tick
        TimerMainDelay.Stop()
    End Sub

    Private Sub TimerActors_Tick(sender As Object, e As EventArgs) Handles TimerActors.Tick
        nImmagineActors += 1

        If nImmagineActors > contaImmaginiActors Then
            nImmagineActors = 0

            If actors_repeat_delay_ms > 0 Then
                TimerActorsDelay.Interval = actors_repeat_delay_ms
                TimerActorsDelay.Start()
            End If
        End If

        'Dim g As Graphics
        'g = Me.Controls("panelActors").CreateGraphics()
        'g.Clear(Color.Transparent)
        'g.DrawImage(actors(nImmagineActors), 0, 0)
    End Sub

    Private Sub TimerActorsDelay_Tick(sender As Object, e As EventArgs) Handles TimerActorsDelay.Tick
        TimerActorsDelay.Stop()
    End Sub

    Private Sub TimerBezel_Tick(sender As Object, e As EventArgs) Handles TimerBezel.Tick

    End Sub

    Private Sub TimerBezelDelay_Tick(sender As Object, e As EventArgs) Handles TimerBezelDelay.Tick
        TimerBezelDelay.Stop()
    End Sub

    'Private Sub AggiornaSfondo()

    '    ''---Romlist----
    '    'Dim panelRomlistBMP As Bitmap = New Bitmap(PanelRomlist.Width, PanelRomlist.Height)
    '    'PanelRomlist.DrawToBitmap(panelRomlistBMP, PanelRomlist.ClientRectangle)
    '    'Dim gRomlist As Graphics
    '    'gRomlist = Me.CreateGraphics()
    '    'gRomlist.DrawImage(panelRomlistBMP, PanelRomlist.Location)
    '    'PanelRomlist.Visible = False

    '    '---Snapshot----
    '    Dim bgClone As Bitmap = Me.BackgroundImage
    '    Dim panelSnapshotBMP As Bitmap = New Bitmap(PanelSnapshot.Width, PanelSnapshot.Height)
    '    PanelSnapshot.DrawToBitmap(panelSnapshotBMP, PanelSnapshot.ClientRectangle)
    '    Dim gSnapshot As Graphics
    '    gSnapshot = Graphics.FromImage(bgClone)
    '    gSnapshot.DrawImage(panelSnapshotBMP, PanelSnapshot.Location)
    '    Me.BackgroundImage = bgClone
    '    PanelSnapshot.Visible = False

    '    ''---Cabinet----
    '    'Dim panelCabinetBMP As Bitmap = New Bitmap(PanelCabinet.Width, PanelCabinet.Height)
    '    'PanelSnapshot.DrawToBitmap(panelCabinetBMP, PanelCabinet.ClientRectangle)
    '    'Dim gCabinet As Graphics
    '    'gCabinet = Me.CreateGraphics()
    '    'gCabinet.DrawImage(panelCabinetBMP, PanelCabinet.Location)
    '    'PanelCabinet.Visible = False

    '    ''---Marquee----
    '    'Dim panelMarqueeBMP As Bitmap = New Bitmap(PanelMarquee.Width, PanelMarquee.Height)
    '    'PanelMarquee.DrawToBitmap(panelMarqueeBMP, PanelMarquee.ClientRectangle)
    '    'Dim gMarquee As Graphics
    '    'gMarquee = Me.CreateGraphics()
    '    'gMarquee.DrawImage(panelMarqueeBMP, PanelMarquee.Location)
    '    'PanelMarquee.Visible = False

    '    'For Each pannello As Panel In Me.Controls
    '    '    If pannello.Visible And (pannello.Name <> "PanelBackground") Then
    '    '        Dim panelBMP As Bitmap = New Bitmap(pannello.Width, pannello.Height)
    '    '        pannello.DrawToBitmap(panelBMP, pannello.ClientRectangle)
    '    '        panelBMP.Save(pannello.Name & ".png")
    '    '        Dim g As Graphics
    '    '        g = Me.CreateGraphics()
    '    '        g.DrawImage(panelBMP, pannello.Location)
    '    '        Me.Invalidate(pannello.ClientRectangle)
    '    '        pannello.Visible = False
    '    '    End If
    '    'Next
    'End Sub

    'Private Sub AggiornaSfondo2()

    '    Dim contaPannelliBMP As Integer = 1

    '    For Each pannello As Panel In Me.Controls
    '        If pannello.Visible And (pannello.Name <> "PanelBackground") Then
    '            Dim panelBMP As Bitmap = New Bitmap(pannello.Width, pannello.Height)
    '            pannello.DrawToBitmap(panelBMP, pannello.ClientRectangle)
    '            pannelliBMP(contaPannelliBMP) = panelBMP
    '            pannelliBMPNomi(contaPannelliBMP) = pannello.Name
    '            pannello.Visible = False
    '            contaPannelliBMP += 1
    '        End If
    '    Next

    '    Dim g As Graphics

    '    'g = PanelBackground.CreateGraphics()

    '    'For i As Integer = 0 To contaPannelliBMP - 1
    '    '    Try
    '    '        g.DrawImage(pannelliBMP(i), Me.Controls(pannelliBMPNomi(i)).Location)
    '    '    Catch ex As Exception

    '    '    End Try

    '    'Next

    'End Sub

End Class