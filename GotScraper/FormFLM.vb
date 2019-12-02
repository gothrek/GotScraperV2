Public Class FormFLM
    Dim dtOptionsLayout As DataTable = New DataTable("Options")
    Dim feelPath As String = "G:\Varie\Feel\Feel1.9\Feel"
    Dim dtRisoluzioni As DataTable = New DataTable("Risoluzioni")

    Dim mouseCoordinate As Point = MousePosition

    Dim valorePrecedente As String

    Dim pannelloMainLocation As Point
    Dim pannelloMainSize As Size

    Dim formDimensioni As Size

    Dim pannelloLocation As Point
    Dim pannelloSize As Size

    Dim pannelloRomlistLocation As Point
    Dim pannelloRomlistSize As Size

    Private Sub FormFLM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formDimensioni = Me.Size

        LabelPercorso.Text = feelPath

        LabelSoundPath2.Text = feelPath & "\media"
        LabelMusic_path.Text = feelPath & "\media"

        dtRisoluzioni.Columns.Add("Risoluzione", Type.GetType("System.String"))
        dtRisoluzioni.Columns.Add("x", Type.GetType("System.String"))
        dtRisoluzioni.Columns.Add("y", Type.GetType("System.String"))
        dtRisoluzioni.Columns.Add("Rapporto", Type.GetType("System.String"))

        pannelloMainLocation = PanelMain.Location

        Try
            Using MyReader As New FileIO.TextFieldParser("Risoluzioni.txt")

                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")

                Dim riga As String()

                While Not MyReader.EndOfData
                    Try
                        riga = MyReader.ReadFields()
                        dtRisoluzioni.Rows.Add()

                        For i As Integer = 0 To 3
                            dtRisoluzioni.Rows(dtRisoluzioni.Rows.Count - 1).Item(i) = riga(i)
                        Next

                    Catch ex As Microsoft.VisualBasic.
                                FileIO.MalformedLineException
                    End Try
                End While
            End Using
        Catch ex As Exception 'problemi nel trovare il file carica i dati di default
            MsgBox("Problemi nella lettura del file delle risoluzioni! Verranno caricati valori di default.")

            Dim riga() As String
            riga = {" 320x200  16:10", "320", "200", "16:10"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {" 640x480   4:3", "640", "480", "4:3"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {" 800x600   4:3", "800", "600", "4:3"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1024x768   4:3", "1024", "768", "4:3"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1152x864   4:3", "1152", "864", "4:3"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1280x720  16:9", "1280", "720", "16:9"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1280x800  16:10", "1280", "800", "16:10"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1280x1024  5:4", "1280", "1024", "5:4"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1400x1050  4:3", "1400", "1050", "4:3"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1440x900  16:9", "1440", "900", "16:9"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1600x1200  4:3", "1600", "1200", "4:3"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1680x1050 16:10", "1680", "1050", "16:10"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1920x1080 16:9", "1920", "1080", "16:9"}
            dtRisoluzioni.Rows.Add(riga)
            riga = {"1920x1200 16:10", "1920", "1200", "16:10"}
            dtRisoluzioni.Rows.Add(riga)

        End Try

        ComboBoxRisoluzione.DataSource = dtRisoluzioni
        ComboBoxRisoluzione.DisplayMember = dtRisoluzioni.Columns(0).ColumnName
        ComboBoxRisoluzione.SelectedIndex = 1

        TextBoxScreen_res_x.Text = ComboBoxRisoluzione.SelectedItem.row.item(1)
        TextBoxScreen_res_x.Refresh()
        TextBoxScreen_res_y.Text = ComboBoxRisoluzione.SelectedItem.row.item(2)
        TextBoxScreen_res_y.Refresh()

        LabelScreenRisoluzione.Text = "Main " & TextBoxScreen_res_x.Text & " x " & TextBoxScreen_res_y.Text
        LabelScreenRisoluzione.Refresh()

        Try
            PanelMain.Size = New Size(Int(TextBoxScreen_res_x.Text), Int(TextBoxScreen_res_y.Text))
        Catch ex As Exception

        End Try

        dtOptionsLayout.Columns.Add("sound_fx_list", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_menu", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_confirm", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_cancel", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_startemu", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_volume", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("music_path", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("music_volume", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("screen_res_x", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("screen_res_y", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("screen_saver_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("screen_saver_font_color", Type.GetType("System.String"))

        'dtOptionsLayout.Columns.Add("romlist_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_item_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_selected_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_selected_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_text_align", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romlist_disable_stars", Type.GetType("System.String"))

        'dtOptionsLayout.Columns.Add("background__visible", Type.GetType("System.String"))
        'dtOptionsLayout.Columns.Add("background_x_pos", Type.GetType("System.String"))
        'dtOptionsLayout.Columns.Add("background_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("background_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("background_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("background_ontop", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("background_frame_duration_ms", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("background_repeat_delay_ms", Type.GetType("System.String"))

        'dtOptionsLayout.Columns.Add("snapshot_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("snapshot_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("snapshot_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("snapshot_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("snapshot_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("snapshot_stretch", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("snapshot_blackbackground", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("cabinet_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("cabinet_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("cabinet_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("cabinet_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("cabinet_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("cabinet_stretch", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("cabinet_blackbackground", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("marquee_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("marquee_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("marquee_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("marquee_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("marquee_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("marquee_stretch", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("marquee_blackbackground", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("romcounter_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcounter_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("platformname_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("platformname_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("emulatorname_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("emulatorname_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("gamelistname_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("gamelistname_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("romname_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romname_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("romdescription_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdescription_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("rommanufacturer_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rommanufacturer_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("romdisplaytype_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romdisplaytype_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("rominputcontrol_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("rominputcontrol_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("romstatus_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romstatus_text_align", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("romcategory_visible", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_x_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_width", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("romcategory_text_align", Type.GetType("System.String"))

        'dtOptionsLayout.Columns.Add("menu_visible", Type.GetType("System.String"))
        'dtOptionsLayout.Columns.Add("menu_x_pos", Type.GetType("System.String"))
        'dtOptionsLayout.Columns.Add("menu_y_pos", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_width", Type.GetType("System.String"))
        ' dtOptionsLayout.Columns.Add("menu_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_item_height", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_font_name", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_font_size", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_font_style", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_selected_font_color", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_selected_backcolor", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("menu_show_sidebar", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("actors_frame_duration_ms", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("actors_repeat_delay_ms", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("bezel_frame_duration_ms", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("bezel_repeat_delay_ms", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("show_extended_messages", Type.GetType("System.String"))

        ValoriInTabella()

    End Sub

    Private Sub FormFLM_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        If Me.Size.Width < 1030 Then
            Me.Size = New Size(1030, Me.Size.Height)
        End If

        If Me.Size.Height < 550 Then
            Me.Size = New Size(Me.Size.Width, 550)
        End If

        GroupBoxProprietà.Size = New Size(GroupBoxProprietà.Size.Width, Int(Me.Size.Height - 72)) 'TODO personalizzare il valore 72
        GroupBoxProprietà.Refresh()

        GroupBoxObj.Size = New Size(GroupBoxObj.Size.Width, Int(Me.Size.Height - 54)) 'TODO personalizzare il valore 54
        GroupBoxObj.Location = New Point(Me.Size.Width - 143, GroupBoxObj.Location.Y) 'TODO personalizzare il valore 143
        GroupBoxObj.Refresh()

        PanelMainMaster.Size = New Size(GroupBoxObj.Location.X - PanelMainMaster.Location.X - 6, Me.Size.Height - PanelMainMaster.Location.Y - 42) 'TODO personalizzare il valore 6 e 42
        PanelMainMaster.Refresh()
    End Sub

    Private Sub ButtonAnteprima_Click(sender As Object, e As EventArgs) Handles ButtonAnteprima.Click
        'TODO caricare anche le immagini per simulare l'effetto vero
    End Sub

    Private Sub LabelCarica_DoubleClick(sender As Object, e As EventArgs) Handles LabelPercorso.DoubleClick
        Dim cartella As String ' = ""
        Dim folder As DirectoryInfo

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            cartella = FolderBrowserDialog1.SelectedPath

            LabelPercorso.Text = cartella
            LabelPercorso.Refresh()

            folder = My.Computer.FileSystem.GetDirectoryInfo(cartella)
        End If
    End Sub

    Private Sub ButtonCarica_Click(sender As Object, e As EventArgs) Handles ButtonCarica.Click
        Dim cartella As String = ""
        Dim folder As DirectoryInfo
        Dim file As System.IO.StreamReader


        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            cartella = FolderBrowserDialog1.SelectedPath

            LabelPercorso.Text = cartella
            LabelPercorso.Refresh()

            folder = My.Computer.FileSystem.GetDirectoryInfo(cartella)

            dtOptionsLayout.Rows.Add()



            file = My.Computer.FileSystem.OpenTextFileReader(cartella & "\" & "layout.ini")

            While Not file.EndOfStream
                Try
                    Dim riga As String = file.ReadLine
                    Dim campo As String = riga.Substring(0, riga.IndexOf(" "))
                    Dim valore As String = riga.Substring(40)

                    dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(campo) = valore
                Catch ex As Exception

                End Try
            End While

            'TODO gestire modifiche font dopo il caricamento
            Try
                TextBoxSound_fx_list.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_list")
            Catch ex As Exception

            End Try
            Try
                TextBoxSound_fx_menu.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_menu")
            Catch ex As Exception

            End Try
            Try
                TextBoxSound_fx_confirm.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_confirm")
            Catch ex As Exception

            End Try

            Try
                TextBoxSound_fx_cancel.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_cancel")
            Catch ex As Exception

            End Try

            Try
                TextBoxSound_fx_startemu.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_startemu")
            Catch ex As Exception

            End Try

            Try
                TextBoxSound_fx_volume.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_volume")

            Catch ex As Exception

            End Try

            Try
                TextBoxMusic_path.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_path")
            Catch ex As Exception

            End Try

            Try
                TextBoxMusic_volume.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_volume")

            Catch ex As Exception

            End Try

            Try
                TextBoxScreen_res_x.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_res_x")
            Catch ex As Exception

            End Try

            Try
                TextBoxScreen_res_y.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_res_y")
            Catch ex As Exception

            End Try

            Try
                TextBoxScreen_saver_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_saver_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxScreen_saver_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_saver_font_color")

            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_item_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_item_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_selected_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_selected_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_selected_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_selected_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomlist_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_text_align")
            Catch ex As Exception

            End Try

            Try
                CheckBoxRomlist_disable_stars.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_disable_stars"))

            Catch ex As Exception

            End Try

            Try
                TextBoxBackground_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxBackground_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_height")
            Catch ex As Exception

            End Try

            Try
                CheckBoxBackground_ontop.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_ontop"))
            Catch ex As Exception

            End Try

            Try
                TextBoxBackground_frame_duration_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_frame_duration_ms")
            Catch ex As Exception

            End Try

            Try
                TextBoxBackground_repeat_delay_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_repeat_delay_ms")

            Catch ex As Exception

            End Try

            Try
                TextBoxSnapshot_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxSnapshot_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxSnapshot_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxSnapshot_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_height")
            Catch ex As Exception

            End Try

            Try
                CheckBoxSnapshot_stretch.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_stretch"))
            Catch ex As Exception

            End Try

            Try
                CheckBoxSnapshot_blackbackground.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_blackbackground"))

            Catch ex As Exception

            End Try

            Try
                CheckBoxCabinet_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_visible"))
            Catch ex As Exception

            End Try

            Try
                TextBoxCabinet_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxCabinet_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxCabinet_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxCabinet_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_height")
            Catch ex As Exception

            End Try

            Try
                CheckBoxCabinet_stretch.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_stretch"))
            Catch ex As Exception

            End Try

            Try
                CheckBoxCabinet_blackbackground.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_blackbackground"))

            Catch ex As Exception

            End Try

            Try
                CheckBoxMarquee_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_visible"))
            Catch ex As Exception

            End Try

            Try
                TextBoxMarquee_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxMarquee_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxMarquee_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxMarquee_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_height")
            Catch ex As Exception

            End Try

            Try
                CheckBoxMarquee_stretch.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_stretch"))
            Catch ex As Exception

            End Try

            Try
                CheckBoxMarquee_blackbackground.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_blackbackground"))
            Catch ex As Exception

            End Try

            Try
                CheckBoxRomcounter_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_visible"))
            Catch ex As Exception


            End Try

            Try
                TextBoxRomcounter_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcounter_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_y_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomcounter_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_width")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomcounter_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcounter_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_name")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomcounter_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_size")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomcounter_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_style")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomcounter_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_color")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomcounter_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_backcolor")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomcounter_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_text_align")

            Catch ex As Exception

                End Try

            Try
                CheckBoxPlatformname_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_visible"))
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_x_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_y_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_width")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_height")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_name")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_size")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_style")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_color")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_backcolor")
            Catch ex As Exception

                End Try

            Try
                TextBoxPlatformname_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_text_align")

            Catch ex As Exception

                End Try

            Try
                CheckBoxEmulatorname_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_visible"))
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_x_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_y_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_width")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_height")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_name")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_size")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_style")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_color")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_backcolor")
            Catch ex As Exception

                End Try

            Try
                TextBoxEmulatorname_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_text_align")

            Catch ex As Exception

                End Try

            Try
                CheckBoxGamelistname_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_visible"))
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_x_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_y_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_width")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_height")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_name")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_size")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_style")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_color")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_backcolor")
            Catch ex As Exception

                End Try

            Try
                TextBoxGamelistname_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_text_align")

            Catch ex As Exception

                End Try

            Try
                CheckBoxRomname_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_visible"))
            Catch ex As Exception

                End Try

            Try
                TextBoxRomname_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_x_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomname_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_y_pos")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomname_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_width")
            Catch ex As Exception

                End Try

            Try
                TextBoxRomname_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomname_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomname_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomname_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomname_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomname_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomname_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_text_align")

            Catch ex As Exception

            End Try

            Try
                CheckBoxRomdescription_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_visible"))
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdescription_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_text_align")

            Catch ex As Exception

            End Try

            Try
                CheckBoxRommanufacturer_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_visible"))
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRommanufacturer_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_text_align")

            Catch ex As Exception

            End Try

            Try
                CheckBoxRomdisplaytype_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_visible"))
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomdisplaytype_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_text_align")

            Catch ex As Exception

            End Try

            Try
                CheckBoxRominputcontrol_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_visible"))
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRominputcontrol_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_text_align")

            Catch ex As Exception

            End Try

            Try
                CheckBoxRomstatus_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_visible"))
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomstatus_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_text_align")

            Catch ex As Exception

            End Try

            Try
                CheckBoxRomcategory_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_visible"))
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_x_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_y_pos")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxRomcategory_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_text_align")

            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_width")
            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_item_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_item_height")
            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_name")
            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_size")
            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_style")
            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_backcolor")
            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_selected_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_selected_font_color")
            Catch ex As Exception

            End Try

            Try
                TextBoxMenu_selected_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_selected_backcolor")
            Catch ex As Exception

            End Try

            Try
                CheckBoxMenu_show_sidebar.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_show_sidebar"))

            Catch ex As Exception

            End Try

            Try
                TextBoxActors_frame_duration_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("actors_frame_duration_ms")
            Catch ex As Exception

            End Try

            Try
                TextBoxActors_repeat_delay_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("actors_repeat_delay_ms")

            Catch ex As Exception

            End Try

            Try
                TextBoxBezel_frame_duration_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("bezel_frame_duration_ms")
            Catch ex As Exception

            End Try

            Try
                TextBoxBezel_repeat_delay_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("bezel_repeat_delay_ms")

            Catch ex As Exception

            End Try

            Try
                CheckBoxShow_extended_messages.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("show_extended_messages"))
            Catch ex As Exception

            End Try

            file.Close()

            MsgBox("File layout.ini caricato!")
        End If

    End Sub

    Private Sub ButtonPubblica_Click(sender As Object, e As EventArgs) Handles ButtonPubblica.Click

        Dim file As System.IO.StreamWriter
        Dim cartella As String = ""
        Dim folder As DirectoryInfo

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            cartella = FolderBrowserDialog1.SelectedPath

            LabelPercorso.Text = cartella
            LabelPercorso.Refresh()

            folder = My.Computer.FileSystem.GetDirectoryInfo(cartella)
        End If

        Try
            If My.Computer.FileSystem.FileExists(cartella & "\" & "layout.ini") Then
                My.Computer.FileSystem.RenameFile(cartella & "\" & "layout.ini", "layout_" & Today.Year.ToString & Today.Month.ToString & Today.Day.ToString & ".ini")
            End If
        Catch ex As Exception

        End Try


        file = My.Computer.FileSystem.OpenTextFileWriter(cartella & "\" & "layout.ini", True)

        ValoriInTabella()

        file.WriteLine("'----------- Created by FLM - gothrek@hotmail.com ------")

        For Each dato As DataColumn In dtOptionsLayout.Columns
            Dim riga As String

            riga = dato.ColumnName



            For i As Integer = 1 To 40 - riga.Length
                riga &= " "
            Next

            riga &= dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(dato.Caption)
            file.WriteLine(riga)
        Next

        file.Close()
        MsgBox("File layout.ini scritto correttamente!")
    End Sub

    Private Sub ValoriInTabella()

        dtOptionsLayout.Rows.Add()

        'test1
        'For Each tab As Object In TabControlProprietà.TabPages
        '    For Each controllo As Object In TabControlProprietà.TabPages.Item(tab.name).controls
        '        Try
        '            dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(controllo.name.ToString.Substring(7)) = controllo.text
        '        Catch ex As Exception

        '        End Try
        '    Next
        'Next

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_list") = TextBoxSound_fx_list.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_menu") = TextBoxSound_fx_menu.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_confirm") = TextBoxSound_fx_confirm.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_cancel") = TextBoxSound_fx_cancel.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_startemu") = TextBoxSound_fx_startemu.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_volume") = TextBoxSound_fx_volume.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_path") = TextBoxMusic_path.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_volume") = TextBoxMusic_volume.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_res_x") = TextBoxScreen_res_x.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_res_y") = TextBoxScreen_res_y.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_saver_backcolor") = TextBoxScreen_saver_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_saver_font_color") = TextBoxScreen_saver_font_color.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_x_pos") = TextBoxRomlist_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_y_pos") = TextBoxRomlist_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_width") = TextBoxRomlist_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_height") = TextBoxRomlist_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_name") = TextBoxRomlist_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_item_height") = TextBoxRomlist_item_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_size") = TextBoxRomlist_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_style") = TextBoxRomlist_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_color") = TextBoxRomlist_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_backcolor") = TextBoxRomlist_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_selected_font_color") = TextBoxRomlist_selected_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_selected_backcolor") = TextBoxRomlist_selected_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_text_align") = TextBoxRomlist_text_align.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_disable_stars") = Int(CheckBoxRomlist_disable_stars.Checked)

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_width") = TextBoxBackground_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_height") = TextBoxBackground_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_ontop") = Int(CheckBoxBackground_ontop.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_frame_duration_ms") = TextBoxBackground_frame_duration_ms.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_repeat_delay_ms") = TextBoxBackground_repeat_delay_ms.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_x_pos") = TextBoxSnapshot_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_y_pos") = TextBoxSnapshot_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_width") = TextBoxSnapshot_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_height") = TextBoxSnapshot_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_stretch") = Int(CheckBoxSnapshot_stretch.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_blackbackground") = Int(CheckBoxSnapshot_blackbackground.Checked)

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_visible") = Int(CheckBoxCabinet_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_x_pos") = TextBoxCabinet_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_y_pos") = TextBoxCabinet_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_width") = TextBoxCabinet_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_height") = TextBoxCabinet_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_stretch") = Int(CheckBoxCabinet_stretch.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_blackbackground") = Int(CheckBoxCabinet_blackbackground.Checked)

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_visible") = Int(CheckBoxMarquee_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_x_pos") = TextBoxMarquee_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_y_pos") = TextBoxMarquee_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_width") = TextBoxMarquee_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_height") = TextBoxMarquee_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_stretch") = Int(CheckBoxMarquee_stretch.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_blackbackground") = Int(CheckBoxMarquee_blackbackground.Checked)

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_visible") = Int(CheckBoxRomcounter_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_x_pos") = TextBoxRomcounter_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_y_pos") = TextBoxRomcounter_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_width") = TextBoxRomcounter_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_height") = TextBoxRomcounter_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_name") = TextBoxRomcounter_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_size") = TextBoxRomcounter_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_style") = TextBoxRomcounter_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_color") = TextBoxRomcounter_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_backcolor") = TextBoxRomcounter_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_text_align") = TextBoxRomcounter_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_visible") = Int(CheckBoxPlatformname_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_x_pos") = TextBoxPlatformname_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_y_pos") = TextBoxPlatformname_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_width") = TextBoxPlatformname_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_height") = TextBoxPlatformname_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_name") = TextBoxPlatformname_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_size") = TextBoxPlatformname_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_style") = TextBoxPlatformname_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_color") = TextBoxPlatformname_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_backcolor") = TextBoxPlatformname_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_text_align") = TextBoxPlatformname_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_visible") = Int(CheckBoxEmulatorname_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_x_pos") = TextBoxEmulatorname_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_y_pos") = TextBoxEmulatorname_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_width") = TextBoxEmulatorname_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_height") = TextBoxEmulatorname_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_name") = TextBoxEmulatorname_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_size") = TextBoxEmulatorname_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_style") = TextBoxEmulatorname_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_color") = TextBoxEmulatorname_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_backcolor") = TextBoxEmulatorname_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_text_align") = TextBoxEmulatorname_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_visible") = Int(CheckBoxGamelistname_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_x_pos") = TextBoxGamelistname_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_y_pos") = TextBoxGamelistname_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_width") = TextBoxGamelistname_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_height") = TextBoxGamelistname_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_name") = TextBoxGamelistname_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_size") = TextBoxGamelistname_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_style") = TextBoxGamelistname_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_color") = TextBoxGamelistname_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_backcolor") = TextBoxGamelistname_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_text_align") = TextBoxGamelistname_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_visible") = Int(CheckBoxRomname_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_x_pos") = TextBoxRomname_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_y_pos") = TextBoxRomname_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_width") = TextBoxRomname_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_height") = TextBoxRomname_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_name") = TextBoxRomname_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_size") = TextBoxRomname_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_style") = TextBoxRomname_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_color") = TextBoxRomname_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_backcolor") = TextBoxRomname_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_text_align") = TextBoxRomname_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_visible") = Int(CheckBoxRomdescription_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_x_pos") = TextBoxRomdescription_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_y_pos") = TextBoxRomdescription_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_width") = TextBoxRomdescription_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_height") = TextBoxRomdescription_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_name") = TextBoxRomdescription_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_size") = TextBoxRomdescription_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_style") = TextBoxRomdescription_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_color") = TextBoxRomdescription_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_backcolor") = TextBoxRomdescription_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_text_align") = TextBoxRomdescription_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_visible") = Int(CheckBoxRommanufacturer_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_x_pos") = TextBoxRommanufacturer_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_y_pos") = TextBoxRommanufacturer_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_width") = TextBoxRommanufacturer_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_height") = TextBoxRommanufacturer_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_name") = TextBoxRommanufacturer_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_size") = TextBoxRommanufacturer_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_style") = TextBoxRommanufacturer_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_color") = TextBoxRommanufacturer_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_backcolor") = TextBoxRommanufacturer_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_text_align") = TextBoxRommanufacturer_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_visible") = Int(CheckBoxRomdisplaytype_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_x_pos") = TextBoxRomdisplaytype_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_y_pos") = TextBoxRomdisplaytype_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_width") = TextBoxRomdisplaytype_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_height") = TextBoxRomdisplaytype_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_name") = TextBoxRomdisplaytype_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_size") = TextBoxRomdisplaytype_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_style") = TextBoxRomdisplaytype_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_color") = TextBoxRomdisplaytype_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_backcolor") = TextBoxRomdisplaytype_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_text_align") = TextBoxRomdisplaytype_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_visible") = Int(CheckBoxRominputcontrol_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_x_pos") = TextBoxRominputcontrol_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_y_pos") = TextBoxRominputcontrol_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_width") = TextBoxRominputcontrol_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_height") = TextBoxRominputcontrol_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_name") = TextBoxRominputcontrol_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_size") = TextBoxRominputcontrol_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_style") = TextBoxRominputcontrol_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_color") = TextBoxRominputcontrol_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_backcolor") = TextBoxRominputcontrol_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_text_align") = TextBoxRominputcontrol_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_visible") = Int(CheckBoxRomstatus_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_x_pos") = TextBoxRomstatus_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_y_pos") = TextBoxRomstatus_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_width") = TextBoxRomstatus_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_height") = TextBoxRomstatus_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_name") = TextBoxRomstatus_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_size") = TextBoxRomstatus_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_style") = TextBoxRomstatus_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_color") = TextBoxRomstatus_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_backcolor") = TextBoxRomstatus_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_text_align") = TextBoxRomstatus_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_visible") = Int(CheckBoxRomcategory_visible.Checked)
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_x_pos") = TextBoxRomcategory_x_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_y_pos") = TextBoxRomcategory_y_pos.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_width") = TextBoxRomcategory_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_height") = TextBoxRomcategory_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_name") = TextBoxRomcategory_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_size") = TextBoxRomcategory_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_style") = TextBoxRomcategory_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_color") = TextBoxRomcategory_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_backcolor") = TextBoxRomcategory_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_text_align") = TextBoxRomcategory_text_align.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_width") = TextBoxMenu_width.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_item_height") = TextBoxMenu_item_height.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_name") = TextBoxMenu_font_name.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_size") = TextBoxMenu_font_size.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_style") = TextBoxMenu_font_style.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_color") = TextBoxMenu_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_backcolor") = TextBoxMenu_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_selected_font_color") = TextBoxMenu_selected_font_color.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_selected_backcolor") = TextBoxMenu_selected_backcolor.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_show_sidebar") = Int(CheckBoxMenu_show_sidebar.Checked)

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("actors_frame_duration_ms") = TextBoxActors_frame_duration_ms.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("actors_repeat_delay_ms") = TextBoxActors_repeat_delay_ms.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("bezel_frame_duration_ms") = TextBoxBezel_frame_duration_ms.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("bezel_repeat_delay_ms") = TextBoxBezel_repeat_delay_ms.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("show_extended_messages") = Int(CheckBoxShow_extended_messages.Checked)


    End Sub

    Private Sub TabControlProprietà_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlProprietà.Selected
        Dim usoOggetto As String = sender.selectedtab.name.ToString.Substring(7)
        Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)

        If usoOggetto <> "Background" Then 'per il background non vogliamo che nasconda tutti gli altri oggetti
            Try
                For Each pannello As Control In PanelMain.Controls
                    pannello.BackColor = Color.FromArgb(50, pannello.BackColor.R, pannello.BackColor.G, pannello.BackColor.B)
                Next

                oggettoPanel.BackColor = Color.FromArgb(255, oggettoPanel.BackColor.R, oggettoPanel.BackColor.G, oggettoPanel.BackColor.B)
            Catch ex As Exception
                For Each pannello As Control In PanelMain.Controls
                    pannello.BackColor = Color.FromArgb(255, pannello.BackColor.R, pannello.BackColor.G, pannello.BackColor.B)
                Next
            End Try
        Else
            For Each pannello As Control In PanelMain.Controls
                pannello.BackColor = Color.FromArgb(255, pannello.BackColor.R, pannello.BackColor.G, pannello.BackColor.B)
            Next
        End If
    End Sub

    Private Sub ListBoxObj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxObj.SelectedIndexChanged
        TabControlProprietà.SelectedIndex = ListBoxObj.SelectedIndex + 1
    End Sub

    Private Sub TrackBarZoom_Scroll(sender As Object, e As EventArgs) Handles TrackBarZoom.Scroll

        LabelZoom.Text = sender.value & "%"
        LabelZoom.Refresh()

        PanelMain.Size = New Size(Int(Val(TextBoxScreen_res_x.Text) * sender.value / 100), Int(Val(TextBoxScreen_res_y.Text) * sender.value / 100))
        For Each controllo As Object In PanelMain.Controls
            Dim usoTab As String = controllo.name.ToString.Substring(5)

            Dim oggettoTextBox_size_width As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_width")
            Dim oggettoTextBox_size_height As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_height")

            controllo.size = New Size(Int(Val(oggettoTextBox_size_width.text) * sender.value / 100), Int(Val(oggettoTextBox_size_height.text) * sender.value / 100))
            controllo.refresh
        Next
        PanelMain.Refresh()

    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Oggetti - funzionalità comuni a tutti gli oggetti dello stesso tipo
    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PanelSnapshot.Paint,
                                                                            PanelRomlist.Paint,
                                                                            PanelMarquee.Paint,
                                                                            PanelCabinet.Paint,
                                                                            PanelRomcounter.Paint,
                                                                            PanelPlatformname.Paint,
                                                                            PanelEmulatorname.Paint,
                                                                            PanelGamelistname.Paint,
                                                                            PanelRomname.Paint,
                                                                            PanelRomdescription.Paint,
                                                                            PanelRommanufacturer.Paint,
                                                                            PanelRomdisplaytype.Paint,
                                                                            PanelRominputcontrol.Paint,
                                                                            PanelRomstatus.Paint,
                                                                            PanelRomcategory.Paint,
                                                                            PanelMenu.Paint ', PanelBackground.Paint, PanelMain.Paint,

        Dim nCaratteri As Integer = sender.name.ToString.Length - 5
        Dim larghezza As Integer = sender.size.width
        Dim altezza As Integer = sender.size.height
        Dim grandezzaCaratteri As Integer = Int(larghezza / nCaratteri)
        Dim posizione As Integer = Int((sender.size.height - grandezzaCaratteri) / 2) - 1
        Dim nomepannello As String = sender.name

        'Dim bmp As New Bitmap(larghezza, altezza)
        'Dim gr As Graphics = Graphics.FromImage(bmp)
        Try
            'sender.controls("PictureBox" & nomepannello).BackColor = Color.Transparent

            If grandezzaCaratteri >= sender.size.height Then
                grandezzaCaratteri = sender.size.height
                posizione = -1
            End If

            Try
                'gr.DrawString(sender.name.ToString.Substring(5), New Font("Arial", grandezzaCaratteri, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Red, 0, posizione)
                If sender.backcolor.a = 50 Then
                    e.Graphics.DrawString(sender.name.ToString.Substring(5), New Font("Arial", grandezzaCaratteri, FontStyle.Regular, GraphicsUnit.Pixel), New SolidBrush(Color.FromArgb(50, 255, 0, 0)), 0, posizione)
                Else
                    e.Graphics.DrawString(sender.name.ToString.Substring(5), New Font("Arial", grandezzaCaratteri, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Red, 0, posizione)
                End If

            Catch ex As Exception

            End Try

            'sender.controls("PictureBox" & nomepannello).Image = bmp
            'bmp.Dispose()
            'gr.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel_MouseHover(sender As Object, e As EventArgs) Handles PanelSnapshot.MouseHover,
                                                                            PanelRomstatus.MouseHover,
                                                                            PanelRomname.MouseHover,
                                                                            PanelRommanufacturer.MouseHover,
                                                                            PanelRomlist.MouseHover,
                                                                            PanelRominputcontrol.MouseHover,
                                                                            PanelRomdisplaytype.MouseHover,
                                                                            PanelRomdescription.MouseHover,
                                                                            PanelRomcounter.MouseHover,
                                                                            PanelRomcategory.MouseHover,
                                                                            PanelPlatformname.MouseHover,
                                                                            PanelMenu.MouseHover,
                                                                            PanelMarquee.MouseHover,
                                                                            PanelGamelistname.MouseHover,
                                                                            PanelEmulatorname.MouseHover,
                                                                            PanelCabinet.MouseHover 'PanelBackground.MouseHover, PanelMain.MouseHover,

        ToolTip1.Show(sender.name, sender)
    End Sub

    Private Sub Panel_MouseEnter(sender As Object, e As EventArgs) Handles PanelSnapshot.MouseEnter,
                                                                            PanelRomlist.MouseEnter,
                                                                            PanelCabinet.MouseEnter,
                                                                            PanelMarquee.MouseEnter,
                                                                            PanelRomcounter.MouseEnter,
                                                                            PanelPlatformname.MouseEnter,
                                                                            PanelEmulatorname.MouseEnter,
                                                                            PanelGamelistname.MouseEnter,
                                                                            PanelRomname.MouseEnter,
                                                                            PanelRomdescription.MouseEnter,
                                                                            PanelRommanufacturer.MouseEnter,
                                                                            PanelRomdisplaytype.MouseEnter,
                                                                            PanelRominputcontrol.MouseEnter,
                                                                            PanelRomstatus.MouseEnter,
                                                                            PanelRomcategory.MouseEnter,
                                                                            PanelMenu.MouseEnter ', PanelBackground.MouseEnter, PanelMain.MouseEnter,

        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Panel_MouseLeave(sender As Object, e As EventArgs) Handles PanelSnapshot.MouseLeave,
                                                                            PanelRomlist.MouseLeave,
                                                                            PanelCabinet.MouseLeave,
                                                                            PanelMarquee.MouseLeave,
                                                                            PanelRomcounter.MouseLeave,
                                                                            PanelPlatformname.MouseLeave,
                                                                            PanelEmulatorname.MouseLeave,
                                                                            PanelGamelistname.MouseLeave,
                                                                            PanelRomname.MouseLeave,
                                                                            PanelRomdescription.MouseLeave,
                                                                            PanelRommanufacturer.MouseLeave,
                                                                            PanelRomdisplaytype.MouseLeave,
                                                                            PanelRominputcontrol.MouseLeave,
                                                                            PanelRomstatus.MouseLeave,
                                                                            PanelRomcategory.MouseLeave,
                                                                            PanelMenu.MouseLeave ', PanelBackground.MouseLeave, PanelMain.MouseLeave,

        Me.Cursor = Cursors.Default
        ToolTip1.Hide(sender)
    End Sub

    Private Sub Panel_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelSnapshot.MouseDown,
                                                                                PanelRomlist.MouseDown,
                                                                                PanelCabinet.MouseDown,
                                                                                PanelMarquee.MouseDown,
                                                                                PanelRomcounter.MouseDown,
                                                                                PanelPlatformname.MouseDown,
                                                                                PanelEmulatorname.MouseDown,
                                                                                PanelGamelistname.MouseDown,
                                                                                PanelRomname.MouseDown,
                                                                                PanelRomdescription.MouseDown,
                                                                                PanelRommanufacturer.MouseDown,
                                                                                PanelRomdisplaytype.MouseDown,
                                                                                PanelRominputcontrol.MouseDown,
                                                                                PanelRomstatus.MouseDown,
                                                                                PanelRomcategory.MouseDown,
                                                                                PanelMenu.MouseDown ', PanelBackground.MouseDown, PanelMain.MouseDown,

        pannelloLocation = sender.Location
        mouseCoordinate = MousePosition
    End Sub

    Private Sub Panel_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelSnapshot.MouseUp,
                                                                                PanelCabinet.MouseUp,
                                                                                PanelMarquee.MouseUp,
                                                                                PanelRomcounter.MouseUp,
                                                                                PanelPlatformname.MouseUp,
                                                                                PanelEmulatorname.MouseUp,
                                                                                PanelGamelistname.MouseUp,
                                                                                PanelRomname.MouseUp,
                                                                                PanelRomdescription.MouseUp,
                                                                                PanelRommanufacturer.MouseUp,
                                                                                PanelRomdisplaytype.MouseUp,
                                                                                PanelRominputcontrol.MouseUp,
                                                                                PanelRomstatus.MouseUp,
                                                                                PanelRomcategory.MouseUp,
                                                                                PanelMenu.MouseUp,
                                                                                PanelRomlist.MouseUp ',PanelBackground.MouseUp, PanelMain.Mouseup,

        pannelloLocation = New Point(sender.Location.X + (MousePosition.X - mouseCoordinate.X), sender.Location.Y + (MousePosition.Y) - mouseCoordinate.Y)

        sender.Location = pannelloLocation
        sender.Refresh()

        Try
            Dim usoOggetto As String = sender.name.ToString.Substring(5, sender.name.ToString.Length - 5)
            Dim oggettoX As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_x_pos")
            Dim oggettoY As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_y_pos")

            oggettoX.Text = pannelloLocation.X
            oggettoX.Refresh()

            oggettoY.Text = pannelloLocation.Y
            oggettoY.Refresh()

            TabControlProprietà.SelectedTab = TabControlProprietà.TabPages("TabPage" & usoOggetto)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckBoxPanelVisibile_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCabinet_visible.CheckedChanged,
                                                                                                CheckBoxMarquee_visible.CheckedChanged,
                                                                                                CheckBoxRomcounter_visible.CheckedChanged,
                                                                                                CheckBoxPlatformname_visible.CheckedChanged,
                                                                                                CheckBoxEmulatorname_visible.CheckedChanged,
                                                                                                CheckBoxGamelistname_visible.CheckedChanged,
                                                                                                CheckBoxRomname_visible.CheckedChanged,
                                                                                                CheckBoxRomdescription_visible.CheckedChanged,
                                                                                                CheckBoxRommanufacturer_visible.CheckedChanged,
                                                                                                CheckBoxRomdisplaytype_visible.CheckedChanged,
                                                                                                CheckBoxRominputcontrol_visible.CheckedChanged,
                                                                                                CheckBoxRomstatus_visible.CheckedChanged,
                                                                                                CheckBoxRomcategory_visible.CheckedChanged,
                                                                                                CheckBoxMenu.CheckedChanged,
                                                                                                CheckBoxRomlistVisibile.CheckedChanged,
                                                                                                CheckBoxSnapshot.CheckedChanged

        Try
            Dim usoOggetto As String = sender.name.ToString.Substring(8, sender.name.ToString.Length - 16)
            Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)

            oggettoPanel.Visible = sender.Checked
            oggettoPanel.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_Enter(sender As Object, e As EventArgs) Handles TextBoxRomlist_width.Enter, TextBoxRomlist_height.Enter,
                                                                        TextBoxSound_fx_volume.Enter,
                                                                        TextBoxMusic_volume.Enter,
                                                                        TextBoxRomlist_item_height.Enter,
                                                                        TextBoxBackground_frame_duration_ms.Enter, TextBoxBackground_repeat_delay_ms.Enter,
                                                                        TextBoxSnapshot_x_pos.Enter, TextBoxSnapshot_y_pos.Enter, TextBoxSnapshot_width.Enter, TextBoxSnapshot_height.Enter,
                                                                        TextBoxCabinet_x_pos.Enter, TextBoxCabinet_y_pos.Enter, TextBoxCabinet_width.Enter, TextBoxCabinet_height.Enter,
                                                                        TextBoxMarquee_y_pos.Enter, TextBoxMarquee_x_pos.Enter, TextBoxMarquee_width.Enter, TextBoxMarquee_height.Enter,
                                                                        TextBoxRomcounter_y_pos.Enter, TextBoxRomcounter_x_pos.Enter, TextBoxRomcounter_width.Enter, TextBoxRomcounter_height.Enter,
                                                                        TextBoxPlatformname_y_pos.Enter, TextBoxPlatformname_x_pos.Enter, TextBoxPlatformname_width.Enter, TextBoxPlatformname_height.Enter,
                                                                        TextBoxEmulatorname_y_pos.Enter, TextBoxEmulatorname_x_pos.Enter, TextBoxEmulatorname_width.Enter, TextBoxEmulatorname_height.Enter,
                                                                        TextBoxGamelistname_y_pos.Enter, TextBoxGamelistname_x_pos.Enter, TextBoxGamelistname_width.Enter, TextBoxGamelistname_height.Enter,
                                                                        TextBoxRomname_y_pos.Enter, TextBoxRomname_x_pos.Enter, TextBoxRomname_width.Enter, TextBoxRomname_height.Enter,
                                                                        TextBoxRomdescription_y_pos.Enter, TextBoxRomdescription_x_pos.Enter, TextBoxRomdescription_width.Enter, TextBoxRomdescription_height.Enter,
                                                                        TextBoxRommanufacturer_y_pos.Enter, TextBoxRommanufacturer_x_pos.Enter, TextBoxRommanufacturer_width.Enter, TextBoxRommanufacturer_height.Enter,
                                                                        TextBoxRomdisplaytype_y_pos.Enter, TextBoxRomdisplaytype_x_pos.Enter, TextBoxRomdisplaytype_width.Enter, TextBoxRomdisplaytype_height.Enter,
                                                                        TextBoxRominputcontrol_y_pos.Enter, TextBoxRominputcontrol_x_pos.Enter, TextBoxRominputcontrol_width.Enter, TextBoxRominputcontrol_height.Enter,
                                                                        TextBoxRomstatus_y_pos.Enter, TextBoxRomstatus_x_pos.Enter, TextBoxRomstatus_width.Enter, TextBoxRomstatus_height.Enter,
                                                                        TextBoxRomcategory_y_pos.Enter, TextBoxRomcategory_x_pos.Enter, TextBoxRomcategory_width.Enter, TextBoxRomcategory_height.Enter, TextBoxMenu_width.Enter,
                                                                        TextBoxMenu_item_height.Enter, TextBoxMenu_y_pos.Enter, TextBoxMenu_x_pos.Enter, TextBoxMenu_height.Enter,
                                                                        TextBoxActors_repeat_delay_ms.Enter, TextBoxActors_frame_duration_ms.Enter,
                                                                        TextBoxBezel_repeat_delay_ms.Enter, TextBoxBezel_frame_duration_ms.Enter,
                                                                        TextBoxRomlist_y_pos.Enter, TextBoxRomlist_x_pos.Enter,
                                                                        TextBoxBackground_y_pos.Enter, TextBoxBackground_x_pos.Enter


        valorePrecedente = sender.Text
    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBoxBackground_frame_duration_ms.TextChanged,
                                                                                TextBoxBackground_repeat_delay_ms.TextChanged,
                                                                                TextBoxRomlist_item_height.TextChanged,
                                                                                TextBoxMenu_item_height.TextChanged,
                                                                                TextBoxActors_repeat_delay_ms.TextChanged, TextBoxActors_frame_duration_ms.TextChanged,
                                                                                TextBoxBezel_repeat_delay_ms.TextChanged, TextBoxBezel_frame_duration_ms.TextChanged

        Try
            Int(sender.Text)
        Catch ex As Exception
            sender.Text = valorePrecedente
            sender.Refresh()
        End Try
    End Sub

    Private Sub TextBox_x_pos_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSnapshot_x_pos.TextChanged,
                                                                                    TextBoxMarquee_x_pos.TextChanged,
                                                                                    TextBoxCabinet_x_pos.TextChanged,
                                                                                    TextBoxRomcounter_x_pos.TextChanged,
                                                                                    TextBoxPlatformname_x_pos.TextChanged,
                                                                                    TextBoxEmulatorname_x_pos.TextChanged,
                                                                                    TextBoxGamelistname_x_pos.TextChanged,
                                                                                    TextBoxRomname_x_pos.TextChanged,
                                                                                    TextBoxRomdescription_x_pos.TextChanged,
                                                                                    TextBoxRommanufacturer_x_pos.TextChanged,
                                                                                    TextBoxRomdisplaytype_x_pos.TextChanged,
                                                                                    TextBoxRominputcontrol_x_pos.TextChanged,
                                                                                    TextBoxRomstatus_x_pos.TextChanged,
                                                                                    TextBoxRomcategory_x_pos.TextChanged,
                                                                                    TextBoxMenu_x_pos.TextChanged,
                                                                                    TextBoxRomlist_x_pos.TextChanged,
                                                                                    TextBoxBackground_x_pos.TextChanged

        Try
            Int(sender.Text)
        Catch ex As Exception
            sender.Text = valorePrecedente
            sender.Refresh()
        End Try

        Try
            Dim usoOggetto As String = sender.name.ToString.Substring(7, sender.name.ToString.Length - 13)
            Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)

            oggettoPanel.Location = New Point(Int(sender.Text), oggettoPanel.Location.Y)

            If oggettoPanel.location.x > PanelMain.Location.X + PanelMain.Size.Width Then
                sender.backcolor = Color.Red
            Else
                sender.BackColor = Color.Green
            End If

            oggettoPanel.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox_y_pos_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSnapshot_y_pos.TextChanged,
                                                                                    TextBoxMarquee_y_pos.TextChanged,
                                                                                    TextBoxCabinet_y_pos.TextChanged,
                                                                                    TextBoxRomcounter_y_pos.TextChanged,
                                                                                    TextBoxPlatformname_y_pos.TextChanged,
                                                                                    TextBoxEmulatorname_y_pos.TextChanged,
                                                                                    TextBoxGamelistname_y_pos.TextChanged,
                                                                                    TextBoxRomname_y_pos.TextChanged,
                                                                                    TextBoxRomdescription_y_pos.TextChanged,
                                                                                    TextBoxRommanufacturer_y_pos.TextChanged,
                                                                                    TextBoxRomdisplaytype_y_pos.TextChanged,
                                                                                    TextBoxRominputcontrol_y_pos.TextChanged,
                                                                                    TextBoxRomstatus_y_pos.TextChanged,
                                                                                    TextBoxRomcategory_y_pos.TextChanged,
                                                                                    TextBoxMenu_y_pos.TextChanged,
                                                                                    TextBoxRomlist_y_pos.TextChanged,
                                                                                    TextBoxBackground_y_pos.TextChanged

        Try
            Int(sender.Text)

        Catch ex As Exception
            sender.Text = valorePrecedente
            sender.Refresh()
        End Try

        Try
            Dim usoOggetto As String = sender.name.ToString.Substring(7, sender.name.ToString.Length - 13)
            Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)

            oggettoPanel.Location = New Point(oggettoPanel.Location.X, Int(sender.Text))

            If oggettoPanel.location.y > PanelMain.Location.Y + PanelMain.Size.Height Then
                sender.backcolor = Color.Red
            Else
                sender.BackColor = Color.Green
            End If

            oggettoPanel.Refresh()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox_width_TextChanged(sender As Object, e As EventArgs) Handles TextBoxRomlist_width.TextChanged,
                                                                                    TextBoxSnapshot_width.TextChanged,
                                                                                    TextBoxMarquee_width.TextChanged,
                                                                                    TextBoxCabinet_width.TextChanged,
                                                                                    TextBoxRomcounter_width.TextChanged,
                                                                                    TextBoxPlatformname_width.TextChanged,
                                                                                    TextBoxEmulatorname_width.TextChanged,
                                                                                    TextBoxGamelistname_width.TextChanged,
                                                                                    TextBoxRomname_width.TextChanged,
                                                                                    TextBoxRomdescription_width.TextChanged,
                                                                                    TextBoxRommanufacturer_width.TextChanged,
                                                                                    TextBoxRomdisplaytype_width.TextChanged,
                                                                                    TextBoxRominputcontrol_width.TextChanged,
                                                                                    TextBoxRomstatus_width.TextChanged,
                                                                                    TextBoxRomcategory_width.TextChanged,
                                                                                    TextBoxMenu_width.TextChanged,
                                                                                    TextBoxBackground_width.TextChanged

        Try
            Int(sender.Text)
        Catch ex As Exception
            sender.Text = valorePrecedente
            sender.Refresh()
        End Try

        Try
            Dim usoOggetto As String = sender.name.ToString.Substring(7, sender.name.ToString.Length - 13)
            Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)

            oggettoPanel.size = New Size(Int(sender.Text), oggettoPanel.Size.Height)
            oggettoPanel.Refresh()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox_height_TextChanged(sender As Object, e As EventArgs) Handles TextBoxRomlist_height.TextChanged,
                                                                                        TextBoxSnapshot_height.TextChanged,
                                                                                        TextBoxMarquee_height.TextChanged,
                                                                                        TextBoxCabinet_height.TextChanged,
                                                                                        TextBoxRomcounter_height.TextChanged,
                                                                                        TextBoxPlatformname_height.TextChanged,
                                                                                        TextBoxEmulatorname_height.TextChanged,
                                                                                        TextBoxGamelistname_height.TextChanged,
                                                                                        TextBoxRomname_height.TextChanged,
                                                                                        TextBoxRomdescription_height.TextChanged,
                                                                                        TextBoxRommanufacturer_height.TextChanged,
                                                                                        TextBoxRomdisplaytype_height.TextChanged,
                                                                                        TextBoxRominputcontrol_height.TextChanged,
                                                                                        TextBoxRomstatus_height.TextChanged,
                                                                                        TextBoxRomcategory_height.TextChanged,
                                                                                        TextBoxMenu_height.TextChanged,
                                                                                        TextBoxBackground_height.TextChanged

        Try
            Int(sender.Text)
        Catch ex As Exception
            sender.Text = valorePrecedente
            sender.Refresh()
        End Try

        Try
            Dim usoOggetto As String = sender.name.ToString.Substring(7, sender.name.ToString.Length - 14)
            Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)

            oggettoPanel.size = New Size(oggettoPanel.Size.Width, Int(sender.Text))
            oggettoPanel.Refresh()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox_font_name_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxRomlist_font_name.DoubleClick, TextBoxRomlist_font_style.DoubleClick, TextBoxRomlist_font_style.Click, TextBoxRomlist_font_size.DoubleClick, TextBoxRomlist_font_size.Click, TextBoxRomlist_font_name.Click,
                                                                                        TextBoxRomcounter_font_style.DoubleClick, TextBoxRomcounter_font_style.Click, TextBoxRomcounter_font_size.DoubleClick, TextBoxRomcounter_font_size.Click, TextBoxRomcounter_font_name.DoubleClick, TextBoxRomcounter_font_name.Click,
                                                                                        TextBoxPlatformname_font_style.DoubleClick, TextBoxPlatformname_font_style.Click, TextBoxPlatformname_font_size.DoubleClick, TextBoxPlatformname_font_size.Click, TextBoxPlatformname_font_name.DoubleClick, TextBoxPlatformname_font_name.Click,
                                                                                        TextBoxEmulatorname_font_style.DoubleClick, TextBoxEmulatorname_font_style.Click, TextBoxEmulatorname_font_size.DoubleClick, TextBoxEmulatorname_font_size.Click, TextBoxEmulatorname_font_name.DoubleClick, TextBoxEmulatorname_font_name.Click,
                                                                                        TextBoxGamelistname_font_style.DoubleClick, TextBoxGamelistname_font_style.Click, TextBoxGamelistname_font_size.DoubleClick, TextBoxGamelistname_font_size.Click, TextBoxGamelistname_font_name.DoubleClick, TextBoxGamelistname_font_name.Click,
                                                                                        TextBoxRomname_font_style.DoubleClick, TextBoxRomname_font_style.Click, TextBoxRomname_font_size.DoubleClick, TextBoxRomname_font_size.Click, TextBoxRomname_font_name.DoubleClick, TextBoxRomname_font_name.Click,
                                                                                        TextBoxRomdescription_font_style.DoubleClick, TextBoxRomdescription_font_style.Click, TextBoxRomdescription_font_size.DoubleClick, TextBoxRomdescription_font_size.Click, TextBoxRomdescription_font_name.DoubleClick, TextBoxRomdescription_font_name.Click,
                                                                                        TextBoxRommanufacturer_font_style.DoubleClick, TextBoxRommanufacturer_font_style.Click, TextBoxRommanufacturer_font_size.DoubleClick, TextBoxRommanufacturer_font_size.Click, TextBoxRommanufacturer_font_name.DoubleClick, TextBoxRommanufacturer_font_name.Click,
                                                                                        TextBoxRomdisplaytype_font_style.DoubleClick, TextBoxRomdisplaytype_font_style.Click, TextBoxRomdisplaytype_font_size.DoubleClick, TextBoxRomdisplaytype_font_size.Click, TextBoxRomdisplaytype_font_name.DoubleClick, TextBoxRomdisplaytype_font_name.Click,
                                                                                        TextBoxRominputcontrol_font_style.DoubleClick, TextBoxRominputcontrol_font_style.Click, TextBoxRominputcontrol_font_size.DoubleClick, TextBoxRominputcontrol_font_size.Click, TextBoxRominputcontrol_font_name.DoubleClick, TextBoxRominputcontrol_font_name.Click,
                                                                                        TextBoxRomstatus_font_style.DoubleClick, TextBoxRomstatus_font_style.Click, TextBoxRomstatus_font_size.DoubleClick, TextBoxRomstatus_font_size.Click, TextBoxRomstatus_font_name.DoubleClick, TextBoxRomstatus_font_name.Click,
                                                                                        TextBoxRomcategory_font_style.DoubleClick, TextBoxRomcategory_font_style.Click, TextBoxRomcategory_font_size.DoubleClick, TextBoxRomcategory_font_size.Click, TextBoxRomcategory_font_name.DoubleClick, TextBoxRomcategory_font_name.Click,
                                                                                        TextBoxMenu_font_style.DoubleClick, TextBoxMenu_font_style.Click, TextBoxMenu_font_size.DoubleClick, TextBoxMenu_font_size.Click, TextBoxMenu_font_name.DoubleClick, TextBoxMenu_font_name.Click

        Dim size As Single = 8
        Dim carattere As Font

        Dim usoTab As String = sender.name.ToString.Substring(7, sender.name.ToString.IndexOf("_") - 7)
        Dim usoOggetto As String = sender.name.ToString.Substring(7, sender.name.ToString.LastIndexOf("_") - 7)

        Dim oggettoTextBox As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_name")
        Dim oggettoLabel As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("Label" & usoTab & "FontDescription")

        FontDialog1.ShowDialog()
        carattere = New Font(FontDialog1.Font.FontFamily, size, FontDialog1.Font.Style)

        oggettoTextBox.Font = carattere
        oggettoTextBox.Text = FontDialog1.Font.Name
        oggettoTextBox.Refresh()

        oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_size")
        oggettoTextBox.Font = carattere
        oggettoTextBox.Text = FontDialog1.Font.Size
        oggettoTextBox.Refresh()

        oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_style")
        oggettoTextBox.Font = carattere
        oggettoTextBox.Text = FontDialog1.Font.Style.GetHashCode
        oggettoTextBox.Refresh()

        oggettoLabel.Text = FontDialog1.Font.Style.ToString
        carattere = oggettoLabel.font
        oggettoLabel.Font = New Font(carattere, FontDialog1.Font.Style)
        oggettoLabel.Refresh()

    End Sub

    Private Sub TextBox_font_name_TextChanged(sender As Object, e As EventArgs) Handles TextBoxRomlist_font_name.TextChanged, TextBoxRomlist_font_style.TextChanged, TextBoxRomlist_font_size.TextChanged,
                                                                                        TextBoxRomstatus_font_style.TextChanged, TextBoxRomstatus_font_size.TextChanged, TextBoxRomstatus_font_name.TextChanged,
                                                                                        TextBoxRomname_font_style.TextChanged, TextBoxRomname_font_size.TextChanged, TextBoxRomname_font_name.TextChanged,
                                                                                        TextBoxRommanufacturer_font_style.TextChanged, TextBoxRommanufacturer_font_size.TextChanged, TextBoxRommanufacturer_font_name.TextChanged,
                                                                                        TextBoxRominputcontrol_font_style.TextChanged, TextBoxRominputcontrol_font_size.TextChanged, TextBoxRominputcontrol_font_name.TextChanged,
                                                                                        TextBoxRomdisplaytype_font_style.TextChanged, TextBoxRomdisplaytype_font_size.TextChanged, TextBoxRomdisplaytype_font_name.TextChanged,
                                                                                        TextBoxRomdescription_font_style.TextChanged, TextBoxRomdescription_font_size.TextChanged, TextBoxRomdescription_font_name.TextChanged,
                                                                                        TextBoxRomcounter_font_style.TextChanged, TextBoxRomcounter_font_size.TextChanged, TextBoxRomcounter_font_name.TextChanged,
                                                                                        TextBoxRomcategory_font_style.TextChanged, TextBoxRomcategory_font_size.TextChanged, TextBoxRomcategory_font_name.TextChanged,
                                                                                        TextBoxPlatformname_font_style.TextChanged, TextBoxPlatformname_font_size.TextChanged, TextBoxPlatformname_font_name.TextChanged,
                                                                                        TextBoxMenu_font_style.TextChanged, TextBoxMenu_font_size.TextChanged, TextBoxMenu_font_name.TextChanged,
                                                                                        TextBoxGamelistname_font_style.TextChanged, TextBoxGamelistname_font_size.TextChanged, TextBoxGamelistname_font_name.TextChanged,
                                                                                        TextBoxEmulatorname_font_style.TextChanged, TextBoxEmulatorname_font_size.TextChanged, TextBoxEmulatorname_font_name.TextChanged

        Dim size As Single = 8
        Dim carattere As Font
        Dim carattereFamiglia As FontFamily
        Dim carattereStile As FontStyle

        Try
            Dim usoTab As String = sender.name.ToString.Substring(7, sender.name.ToString.IndexOf("_") - 7)
            Dim usoOggetto As String = sender.name.ToString.Substring(7, sender.name.ToString.LastIndexOf("_") - 7)

            Dim oggettoTextBox As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_name")
            Dim oggettoLabel As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("Label" & usoTab & "FontDescription")

            carattereFamiglia = New FontFamily(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_name").ToString)

            carattereStile = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_style")

            carattere = New Font(carattereFamiglia, size, carattereStile)

            oggettoTextBox.Font = carattere
            oggettoTextBox.Refresh()

            oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_size")
            oggettoTextBox.Font = carattere
            oggettoTextBox.Refresh()

            oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_style")
            oggettoTextBox.Font = carattere
            oggettoTextBox.Refresh()

            oggettoLabel.Text = carattere.Style.ToString
            carattere = oggettoLabel.font
            oggettoLabel.Font = New Font(carattere, carattereStile)
            oggettoLabel.Refresh()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox_font_color_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxRomlist_font_color.DoubleClick, TextBoxRomlist_font_color.Click,
                                                                                            TextBoxRomlist_selected_font_color.DoubleClick, TextBoxRomlist_selected_font_color.Click,
                                                                                            TextBoxScreen_saver_font_color.DoubleClick, TextBoxScreen_saver_font_color.Click,
                                                                                            TextBoxRomcounter_font_color.DoubleClick, TextBoxRomcounter_font_color.Click,
                                                                                            TextBoxPlatformname_font_color.DoubleClick, TextBoxPlatformname_font_color.Click,
                                                                                            TextBoxEmulatorname_font_color.DoubleClick, TextBoxEmulatorname_font_color.Click,
                                                                                            TextBoxGamelistname_font_color.DoubleClick, TextBoxGamelistname_font_color.Click,
                                                                                            TextBoxRomname_font_color.DoubleClick, TextBoxRomname_font_color.Click,
                                                                                            TextBoxRomdescription_font_color.DoubleClick, TextBoxRomdescription_font_color.Click,
                                                                                            TextBoxRommanufacturer_font_color.DoubleClick, TextBoxRommanufacturer_font_color.Click,
                                                                                            TextBoxRomdisplaytype_font_color.DoubleClick, TextBoxRomdisplaytype_font_color.Click,
                                                                                            TextBoxRominputcontrol_font_color.DoubleClick, TextBoxRominputcontrol_font_color.Click,
                                                                                            TextBoxRomstatus_font_color.DoubleClick, TextBoxRomstatus_font_color.Click,
                                                                                            TextBoxRomcategory_font_color.DoubleClick, TextBoxRomcategory_font_color.Click,
                                                                                            TextBoxMenu_font_color.Click, TextBoxMenu_font_color.DoubleClick,
                                                                                            TextBoxMenu_selected_font_color.DoubleClick, TextBoxMenu_selected_font_color.Click

        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            sender.BackColor = ColorDialog1.Color

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = ColorDialog1.Color.R Xor 255
            Dim coloreG As Integer = ColorDialog1.Color.G Xor 255
            Dim coloreB As Integer = ColorDialog1.Color.B Xor 255

            sender.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            sender.Text = coloreR & ", " & coloreG & ", " & coloreB
            sender.Refresh()
        End If

    End Sub

    Private Sub TextBox_font_color_TextChanged(sender As Object, e As EventArgs) Handles TextBoxScreen_saver_font_color.TextChanged, TextBoxScreen_saver_backcolor.TextChanged,
                                                                                            TextBoxRomlist_font_color.TextChanged, TextBoxRomlist_selected_font_color.TextChanged,
                                                                                            TextBoxGamelistname_font_color.TextChanged,
                                                                                            TextBoxEmulatorname_font_color.TextChanged,
                                                                                            TextBoxRomstatus_font_color.TextChanged,
                                                                                            TextBoxRomname_font_color.TextChanged,
                                                                                            TextBoxRommanufacturer_font_color.TextChanged,
                                                                                            TextBoxRomlist_selected_backcolor.TextChanged,
                                                                                            TextBoxRominputcontrol_font_color.TextChanged,
                                                                                            TextBoxRomdisplaytype_font_color.TextChanged,
                                                                                            TextBoxRomdescription_font_color.TextChanged,
                                                                                            TextBoxRomcounter_font_color.TextChanged,
                                                                                            TextBoxRomcategory_font_color.TextChanged,
                                                                                            TextBoxPlatformname_font_color.TextChanged,
                                                                                            TextBoxMenu_selected_font_color.TextChanged, TextBoxMenu_selected_backcolor.TextChanged, TextBoxMenu_font_color.TextChanged

        Try

            Dim valori() As String = sender.text.ToString.Split(",")

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = Int(valori(0))
            Dim coloreG As Integer = Int(valori(1))
            Dim coloreB As Integer = Int(valori(2))

            Try
                coloreA = Int(valori(3))
                If coloreA = 0 Then 'TODO va salvato in qualche modo il dato anche se il controllo non supporta la trasparenza
                    coloreA = 255
                End If
            Catch ex As Exception

            End Try

            sender.backcolor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

            coloreR = coloreR Xor 255
            coloreG = coloreG Xor 255
            coloreB = coloreB Xor 255

            sender.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            sender.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_backcolor_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxRomlist_backcolor.DoubleClick, TextBoxRomlist_backcolor.Click,
                                                                                        TextBoxRomcounter_backcolor.DoubleClick, TextBoxRomcounter_backcolor.Click,
                                                                                        TextBoxPlatformname_backcolor.DoubleClick, TextBoxPlatformname_backcolor.Click,
                                                                                        TextBoxEmulatorname_backcolor.DoubleClick, TextBoxEmulatorname_backcolor.Click,
                                                                                        TextBoxGamelistname_backcolor.DoubleClick, TextBoxGamelistname_backcolor.Click,
                                                                                        TextBoxRomname_backcolor.DoubleClick, TextBoxRomname_backcolor.Click,
                                                                                        TextBoxRomdescription_backcolor.DoubleClick, TextBoxRomdescription_backcolor.Click,
                                                                                        TextBoxRommanufacturer_backcolor.DoubleClick, TextBoxRommanufacturer_backcolor.Click,
                                                                                        TextBoxRomdisplaytype_backcolor.DoubleClick, TextBoxRomdisplaytype_backcolor.Click,
                                                                                        TextBoxRominputcontrol_backcolor.DoubleClick, TextBoxRominputcontrol_backcolor.Click,
                                                                                        TextBoxRomstatus_backcolor.DoubleClick, TextBoxRomstatus_backcolor.Click,
                                                                                        TextBoxRomcategory_backcolor.DoubleClick, TextBoxRomcategory_backcolor.Click, TextBoxMenu_backcolor.DoubleClick, TextBoxMenu_backcolor.Click

        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            sender.BackColor = ColorDialog1.Color

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = ColorDialog1.Color.R Xor 255
            Dim coloreG As Integer = ColorDialog1.Color.G Xor 255
            Dim coloreB As Integer = ColorDialog1.Color.B Xor 255

            sender.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            sender.Text = coloreR & ", " & coloreG & ", " & coloreB
            sender.Refresh()

            Dim usoOggetto As String = sender.name.ToString.Substring(7, sender.name.ToString.IndexOf("_") - 7)
            Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)

            oggettoPanel.BackColor = ColorDialog1.Color
            oggettoPanel.Refresh()
        End If

    End Sub

    Private Sub TextBox_backcolor_TextChanged(sender As Object, e As EventArgs) Handles TextBoxRomlist_backcolor.TextChanged,
                                                                                        TextBoxRomstatus_backcolor.TextChanged,
                                                                                        TextBoxRomname_backcolor.TextChanged,
                                                                                        TextBoxRommanufacturer_backcolor.TextChanged,
                                                                                        TextBoxRominputcontrol_backcolor.TextChanged,
                                                                                        TextBoxRomdisplaytype_backcolor.TextChanged,
                                                                                        TextBoxRomdescription_backcolor.TextChanged,
                                                                                        TextBoxRomcounter_backcolor.TextChanged,
                                                                                        TextBoxRomcategory_backcolor.TextChanged,
                                                                                        TextBoxPlatformname_backcolor.TextChanged,
                                                                                        TextBoxMenu_backcolor.TextChanged,
                                                                                        TextBoxGamelistname_backcolor.TextChanged,
                                                                                        TextBoxEmulatorname_backcolor.TextChanged
        Try

            Dim valori() As String = sender.text.ToString.Split(",")

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = Int(valori(0))
            Dim coloreG As Integer = Int(valori(1))
            Dim coloreB As Integer = Int(valori(2))

            Try
                coloreA = Int(valori(3))
                If coloreA = 0 Then 'TODO va salvato in qualche modo il dato anche se il controllo non supporta la trasparenza
                    coloreA = 255
                End If
            Catch ex As Exception

            End Try

            sender.backcolor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)

            coloreR = coloreR Xor 255
            coloreG = coloreG Xor 255
            coloreB = coloreB Xor 255

            sender.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            sender.Refresh()

            Try
                Dim usoOggetto As String = sender.name.ToString.Substring(7, sender.name.ToString.IndexOf("_") - 7)
                Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)

                oggettoPanel.BackColor = sender.backcolor
                oggettoPanel.Refresh()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonPannelloReset_Click(sender As Object, e As EventArgs) Handles ButtonRomlistReset.Click,
                                                                                    ButtonSnapshotReset.Click,
                                                                                    ButtonRomstatusReset.Click,
                                                                                    ButtonRomnameReset.Click,
                                                                                    ButtonRommanufacturerReset.Click,
                                                                                    ButtonRominputcontrolReset.Click,
                                                                                    ButtonRomdisplaytypeReset.Click,
                                                                                    ButtonRomdescriptionReset.Click,
                                                                                    ButtonRomcounterReset.Click,
                                                                                    ButtonRomcategoryReset.Click,
                                                                                    ButtonPlatformnameReset.Click,
                                                                                    ButtonMenuReset.Click,
                                                                                    ButtonMarqueeReset.Click,
                                                                                    ButtonGamelistnameReset.Click,
                                                                                    ButtonEmulatornameReset.Click,
                                                                                    ButtonCabinetReset.Click,
                                                                                    ButtonBackgroundReset.Click

        Dim usoOggetto As String = sender.name.ToString.Substring(6, sender.name.ToString.Length - 11)
        Dim usoTab As String = usoOggetto 'sender.name.ToString.Substring(7, sender.name.ToString.IndexOf("_") - 7)

        Dim oggettoTextBox As Object

        Try
            oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_x_pos")
            oggettoTextBox.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(usoOggetto & "_x_pos")
        Catch ex As Exception
            'oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_x_pos")
            'oggettoTextBox.Text = dtOptionsLayout.Rows(0).Item(usoOggetto & "_x_pos")
        End Try

        Try
            oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_y_pos")
            oggettoTextBox.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(usoOggetto & "_y_pos")
        Catch ex As Exception
            'oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_y_pos")
            'oggettoTextBox.Text = dtOptionsLayout.Rows(0).Item(usoOggetto & "_y_pos")
        End Try

        Try
            oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_width")
            oggettoTextBox.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(usoOggetto & "_width")
        Catch ex As Exception
            'oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_width")
            'oggettoTextBox.Text = dtOptionsLayout.Rows(0).Item(usoOggetto & "_width")
        End Try

        Try
            oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_height")
            oggettoTextBox.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(usoOggetto & "_height")
        Catch ex As Exception
            'oggettoTextBox = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoOggetto & "_height")
            'oggettoTextBox.Text = dtOptionsLayout.Rows(0).Item(usoOggetto & "_height")
        End Try

    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Sound
    Private Sub TextBoxSound_fx_list_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_list.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_list.Text = OpenFileDialog1.SafeFileName
        TextBoxSound_fx_list.Refresh()
    End Sub

    Private Sub TextBoxSound_fx_menu_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_menu.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_menu.Text = OpenFileDialog1.SafeFileName
        TextBoxSound_fx_menu.Refresh()
    End Sub

    Private Sub TextBoxSound_fx_confirm_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_confirm.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_confirm.Text = OpenFileDialog1.SafeFileName
        TextBoxSound_fx_confirm.Refresh()
    End Sub

    Private Sub TextBoxSound_fx_cancel_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_cancel.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_cancel.Text = OpenFileDialog1.SafeFileName
        TextBoxSound_fx_cancel.Refresh()
    End Sub

    Private Sub TextBoxSound_fx_startemu_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_startemu.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_startemu.Text = OpenFileDialog1.SafeFileName
        TextBoxSound_fx_startemu.Refresh()
    End Sub

    Private Sub TextBoxSound_fx_volume_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSound_fx_volume.TextChanged
        Try
            If (Int(TextBoxSound_fx_volume.Text) >= 0) And (Int(TextBoxSound_fx_volume.Text) <= 100) Then
            Else
                TextBoxSound_fx_volume.Text = valorePrecedente
                TextBoxSound_fx_volume.Refresh()
            End If
        Catch ex As Exception
            TextBoxSound_fx_volume.Text = valorePrecedente
            TextBoxSound_fx_volume.Refresh()
        End Try
    End Sub

    Private Sub ButtonSoundPath_Click(sender As Object, e As EventArgs) Handles ButtonSoundPath.Click
        FolderBrowserDialog1.ShowDialog()
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Music
    Private Sub TextBoxMusicPath_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxMusic_path.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.mp3)|*.mp3"
        OpenFileDialog1.InitialDirectory = LabelMusic_path.Text
        OpenFileDialog1.ShowDialog()
        TextBoxMusic_path.Text = OpenFileDialog1.SafeFileName
        TextBoxMusic_path.Refresh()
    End Sub

    Private Sub TextBoxMusic_volume_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMusic_volume.TextChanged
        Try
            If (Int(TextBoxMusic_volume.Text) >= 0) And (Int(TextBoxMusic_volume.Text) <= 100) Then
            Else
                TextBoxMusic_volume.Text = valorePrecedente
                TextBoxMusic_volume.Refresh()
            End If
        Catch ex As Exception
            TextBoxMusic_volume.Text = valorePrecedente
            TextBoxMusic_volume.Refresh()
        End Try
    End Sub

    Private Sub ButtonMusic_path_Click(sender As Object, e As EventArgs) Handles ButtonMusic_path.Click
        FolderBrowserDialog1.ShowDialog()
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà screen
    Private Sub PanelMain_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelMain.MouseUp
        pannelloMainLocation = New Point(PanelMain.Location.X + (MousePosition.X - mouseCoordinate.X), PanelMain.Location.Y + (MousePosition.Y) - mouseCoordinate.Y)

        PanelMain.Location = pannelloMainLocation
        PanelMain.Refresh()

        LabelPannelloMainX.Text = "Pannello main X: " & pannelloMainLocation.X
        LabelPannelloMainX.Refresh()

        LabelPannelloMainY.Text = "Pannello main Y: " & pannelloMainLocation.Y
        LabelPannelloMainY.Refresh()
    End Sub

    Private Sub ButtonPannelloMainReset_Click(sender As Object, e As EventArgs) Handles ButtonPannelloMainReset.Click
        PanelMain.Location = New Point(0, 0)
        PanelMain.Refresh()

        LabelPannelloMainX.Text = "Pannello main X: " & PanelMain.Location.X
        LabelPannelloMainX.Refresh()

        LabelPannelloMainY.Text = "Pannello main Y: " & PanelMain.Location.Y
        LabelPannelloMainY.Refresh()
    End Sub

    Private Sub ComboBoxRisoluzione_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxRisoluzione.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBoxRisoluzione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxRisoluzione.SelectedIndexChanged
        TextBoxScreen_res_x.Text = ComboBoxRisoluzione.SelectedItem.row.item(1)
        TextBoxScreen_res_x.Refresh()
        TextBoxScreen_res_y.Text = ComboBoxRisoluzione.SelectedItem.row.item(2)
        TextBoxScreen_res_y.Refresh()

        TextBoxBackground_width.Text = TextBoxScreen_res_x.Text
        TextBoxBackground_width.Refresh()
        TextBoxBackground_height.Text = TextBoxScreen_res_y.Text
        TextBoxBackground_height.Refresh()

        LabelScreenRisoluzione.Text = "Main " & TextBoxScreen_res_x.Text & " x " & TextBoxScreen_res_y.Text
        LabelScreenRisoluzione.Refresh()

        Try
            PanelMain.Size = New Size(Int(TextBoxScreen_res_x.Text), Int(TextBoxScreen_res_y.Text))
            PanelMain.Refresh()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBoxScreen_res_x_TextChanged(sender As Object, e As EventArgs) Handles TextBoxScreen_res_x.TextChanged
        Dim i As Integer = 0
        Dim esci As Boolean = False

        Try
            Do
                If TextBoxScreen_res_x.Text = dtRisoluzioni.Rows(i).Item("x") Then
                    esci = True
                End If

                i += 1

            Loop Until esci Or (i = dtRisoluzioni.Rows.Count)

            If esci Then
                TextBoxScreen_res_x.BackColor = Color.Green
                TextBoxScreen_res_x.Refresh()
            Else
                TextBoxScreen_res_x.BackColor = Color.Red
                TextBoxScreen_res_x.Refresh()
            End If
        Catch ex As Exception

        End Try

        Try
            Int(TextBoxScreen_res_x.Text)
        Catch ex As Exception
            TextBoxScreen_res_x.Text = ComboBoxRisoluzione.SelectedItem.row.item(1)
            TextBoxScreen_res_x.Refresh()
        End Try

        LabelScreenRisoluzione.Text = "Main " & TextBoxScreen_res_x.Text & " x " & TextBoxScreen_res_y.Text
        LabelScreenRisoluzione.Refresh()

        Try
            PanelMain.Size = New Size(Int(TextBoxScreen_res_x.Text), Int(TextBoxScreen_res_y.Text))
            PanelMain.Refresh()
        Catch ex As Exception

        End Try

        TextBoxBackground_width.Text = TextBoxScreen_res_x.Text
        TextBoxBackground_width.Refresh()
    End Sub

    Private Sub TextBoxScreen_res_y_TextChanged(sender As Object, e As EventArgs) Handles TextBoxScreen_res_y.TextChanged
        Dim i As Integer = 0
        Dim esci As Boolean = False

        Try
            Do
                If TextBoxScreen_res_y.Text = dtRisoluzioni.Rows(i).Item("y") Then
                    esci = True
                End If

                i += 1

            Loop Until esci Or (i = dtRisoluzioni.Rows.Count)

            If esci Then
                TextBoxScreen_res_x.BackColor = Color.Green
                TextBoxScreen_res_x.Refresh()
            Else
                TextBoxScreen_res_y.BackColor = Color.Red
                TextBoxScreen_res_y.Refresh()
            End If

        Catch ex As Exception

        End Try

        Try
            Int(TextBoxScreen_res_y.Text)
        Catch ex As Exception
            TextBoxScreen_res_y.Text = ComboBoxRisoluzione.SelectedItem.row.item(2)
            TextBoxScreen_res_y.Refresh()
        End Try

        LabelScreenRisoluzione.Text = "Main " & TextBoxScreen_res_x.Text & " x " & TextBoxScreen_res_y.Text
        LabelScreenRisoluzione.Refresh()

        Try
            PanelMain.Size = New Size(Int(TextBoxScreen_res_x.Text), Int(TextBoxScreen_res_y.Text))
            PanelMain.Refresh()
        Catch ex As Exception

        End Try

        TextBoxBackground_height.Text = TextBoxScreen_res_y.Text
        TextBoxBackground_height.Refresh()
    End Sub

    Private Sub TextBoxScreen_saver_backcolor_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxScreen_saver_backcolor.DoubleClick, TextBoxScreen_saver_backcolor.Click
        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            TextBoxScreen_saver_backcolor.BackColor = ColorDialog1.Color

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = ColorDialog1.Color.R Xor 255
            Dim coloreG As Integer = ColorDialog1.Color.G Xor 255
            Dim coloreB As Integer = ColorDialog1.Color.B Xor 255

            TextBoxScreen_saver_backcolor.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            TextBoxScreen_saver_backcolor.Text = coloreR & ", " & coloreG & ", " & coloreB
            TextBoxScreen_saver_backcolor.Refresh()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà RomList

    Private Sub TextBoxRomlist_selected_backcolor_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxRomlist_selected_backcolor.DoubleClick, TextBoxRomlist_selected_backcolor.Click
        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            TextBoxRomlist_selected_backcolor.BackColor = ColorDialog1.Color

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = ColorDialog1.Color.R Xor 255
            Dim coloreG As Integer = ColorDialog1.Color.G Xor 255
            Dim coloreB As Integer = ColorDialog1.Color.B Xor 255

            TextBoxRomlist_selected_backcolor.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            TextBoxRomlist_selected_backcolor.Text = coloreR & ", " & coloreG & ", " & coloreB
            TextBoxRomlist_selected_backcolor.Refresh()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Background

    Private Sub PanelBackground_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelBackground.MouseUp
        TabControlProprietà.SelectedTab = TabControlProprietà.TabPages("TabPageBackground")
    End Sub

    Private Sub ButtonBackgroundPath_Click(sender As Object, e As EventArgs) Handles ButtonBackgroundPath.Click
        Dim cartella As String ' = ""

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            cartella = FolderBrowserDialog1.SelectedPath
            LabelBackgroundPath2.Text = cartella
            LabelBackgroundPath2.Refresh()
        End If
    End Sub

    Private Sub ButtonBackgroundAnimator_Click(sender As Object, e As EventArgs) Handles ButtonBackgroundAnimator.Click
        'Dim cartella As String ' = ""

        'FolderBrowserDialog1.ShowDialog()
        'cartella = FolderBrowserDialog1.SelectedPath
        'LabelCarica.Text = cartella
        'LabelCarica.Refresh()
        MsgBox("Sviluppi futuri!")
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Snapshot

    '----------------------------------------------------------------------------------------------
    'Proprietà Cabinet

    '----------------------------------------------------------------------------------------------
    'Proprietà Marquee

    '----------------------------------------------------------------------------------------------
    'Proprietà Romcounter

    '----------------------------------------------------------------------------------------------
    'Proprietà Platformname

    '----------------------------------------------------------------------------------------------
    'Proprietà Emulatorname

    '----------------------------------------------------------------------------------------------
    'Proprietà Gamelistname

    '----------------------------------------------------------------------------------------------
    'Proprietà Romname

    '----------------------------------------------------------------------------------------------
    'Proprietà Romdescription

    '----------------------------------------------------------------------------------------------
    'Proprietà Romdescription

    '----------------------------------------------------------------------------------------------
    'Proprietà Romdisplaytype

    '----------------------------------------------------------------------------------------------
    'Proprietà Rominputcontrol

    '----------------------------------------------------------------------------------------------
    'Proprietà Romstatus

    '----------------------------------------------------------------------------------------------
    'Proprietà Romcategory

    '----------------------------------------------------------------------------------------------
    'Proprietà Menu

    Private Sub TextBoxMenu_selected_backcolor_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxMenu_selected_backcolor.DoubleClick, TextBoxMenu_selected_backcolor.Click
        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            TextBoxMenu_selected_backcolor.BackColor = ColorDialog1.Color

            Dim coloreA As Integer = 0
            Dim coloreR As Integer = ColorDialog1.Color.R Xor 255
            Dim coloreG As Integer = ColorDialog1.Color.G Xor 255
            Dim coloreB As Integer = ColorDialog1.Color.B Xor 255

            TextBoxMenu_selected_backcolor.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            TextBoxMenu_selected_backcolor.Text = coloreR & ", " & coloreG & ", " & coloreB
            TextBoxMenu_selected_backcolor.Refresh()
        End If
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Actors

    '----------------------------------------------------------------------------------------------
    'Proprietà Bezel

    '----------------------------------------------------------------------------------------------
    'Proprietà Show

End Class