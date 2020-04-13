Public Class FormFLM
    Public fileErrorLog As System.IO.StreamWriter

    Public feelPath As String = "C:\"
    Public grafxEditorPath As String = "C:\Windows\system32\mspaint.exe" 'percorso di default del Paint di Windows

    Public flmTipsCheck As Integer = 1
    Public flmTip As String = ""

    Public flmBackgroundImageCheck As Boolean = True
    Public flmBackgroundImage As Image = My.Resources.bartop1280_800

    Public fontIntestazioni As String = "Arial"
    Public fontIntestazioniSize As Single = 8
    Public fontIntestazioniStyle As FontStyle = 0
    Public fontIntestazioniColor As String = "Red"

    Public fontElementi As String = "Arial"
    Public fontElementiSize As Single = 8
    Public fontElementiStyle As FontStyle = 0
    Public fontElementiColor As String = "Red"

    Public fontFLM As String = "Aghara Pro Regular"
    Public fontFLMSize As Single = 36
    Public fontFLMStyle As FontStyle = 1
    Public fontFLMColor As String = "ControlDarkDark"

    Public mouseTimeClick As Integer '= 300

    Public templateLayoutIni As String = "Default"
    Public flmLayout As Integer = 1

    Public dtOptionsLayout As DataTable
    Dim dtRisoluzioni As DataTable = New DataTable

    Dim colorDialog1 As New CutoutPro.Winforms.ArgbColorDialog

    Dim mp3player As New ClassMedia.MP3Player
    Dim soundPlay As Boolean = False
    Dim musicPlay As Boolean = False

    Dim mouseCoordinate As Point = MousePosition
    Dim tempoMouseClick As Date
    Dim mouseDownX As Integer
    Dim mouseDownY As Integer

    Dim valorePrecedente As String
    Dim tabSelezionata As Integer = 3 '3 corrisponde alla tab "Screen"

    Dim pannelloMainLocation As Point
    Dim pannelloMainSize As Size

    Dim formDimensioni As Size

    Dim pannelloLocation As Point
    Dim pannelloSize As Size
    Dim pannello As Panel

    Dim pannelloRomlistLocation As Point
    Dim pannelloRomlistSize As Size

    Private Sub FormFLM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "FLM - F.E.(E.L.) Layout Manager - versione " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & " - " & My.Application.Info.Copyright

        fileErrorLog = My.Computer.FileSystem.OpenTextFileWriter(Today.Year & Today.Month & Today.Day & "ErrorLog.txt", False)
        fileErrorLog.Close()

        If My.Computer.FileSystem.FileExists("FLM.ini") Then
            'Il file esiste, verrà caricato
            Dim file As String
            Dim inizioStringa As Integer = 0
            Dim fineStringa As Integer = 0
            Dim usoStringa As String

            file = My.Computer.FileSystem.ReadAllText("FLM.ini")

            inizioStringa = file.IndexOf("feelPath=") + 9
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            feelPath = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("grafxEditorPath=") + 16
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            grafxEditorPath = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("templateLayoutIni=") + 18
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            templateLayoutIni = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("fontIntestazioniName=") + 21
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontIntestazioni = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("fontIntestazioniSize=") + 21
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontIntestazioniSize = Int(usoStringa.Substring(0, fineStringa))

            inizioStringa = file.IndexOf("fontIntestazioniStyle=") + 22
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontIntestazioniStyle = Int(usoStringa.Substring(0, fineStringa))

            inizioStringa = file.IndexOf("fontIntestazioniColor=") + 22
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontIntestazioniColor = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("fontElementiName=") + 17
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontElementi = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("fontElementiSize=") + 17
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontElementiSize = Int(usoStringa.Substring(0, fineStringa))

            inizioStringa = file.IndexOf("fontElementiStyle=") + 18
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontElementiStyle = Int(usoStringa.Substring(0, fineStringa))

            inizioStringa = file.IndexOf("fontElementiColor=") + 18
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontElementiColor = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("fontFLMName=") + 12
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontFLM = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("fontFLMSize=") + 12
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontFLMSize = Int(usoStringa.Substring(0, fineStringa))

            inizioStringa = file.IndexOf("fontFLMStyle=") + 13
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontFLMStyle = Int(usoStringa.Substring(0, fineStringa))

            inizioStringa = file.IndexOf("fontFLMColor=") + 13
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            fontFLMColor = usoStringa.Substring(0, fineStringa)

            inizioStringa = file.IndexOf("mouseTimeClick=") + 15
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            mouseTimeClick = Int(usoStringa.Substring(0, fineStringa))
            Timer1.Interval = mouseTimeClick

            inizioStringa = file.IndexOf("flmTips=") + 8
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            flmTipsCheck = Int(usoStringa.Substring(0, fineStringa))

            inizioStringa = file.IndexOf("flmBackgroundImageCheck=") + 24
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)

            Try
                flmBackgroundImageCheck = Convert.ToBoolean(usoStringa.Substring(0, fineStringa))
            Catch ex As Exception
                flmBackgroundImageCheck = True
                fileErrorLog = My.Computer.FileSystem.OpenTextFileWriter(Today.Year & Today.Month & Today.Day & "ErrorLog.txt", True)
                fileErrorLog.WriteLine(Now.ToShortTimeString & " - FormFLM_Load" & " - flmBackgroundImageCheck - " & ex.Message)
                fileErrorLog.Close()
            End Try

            inizioStringa = file.IndexOf("flmLayout=") + 10
            usoStringa = file.Substring(inizioStringa)
            fineStringa = usoStringa.IndexOf(vbCrLf)
            Try
                flmLayout = Int(usoStringa.Substring(0, fineStringa))
                Select Case flmLayout
                    Case 1
                        flmBackgroundImage = My.Resources.Layout1Marquee
                    Case 2
                        flmBackgroundImage = My.Resources.Layout2Marquee
                    Case 3
                        flmBackgroundImage = My.Resources.Layout3Marquee
                    Case Else
                        MsgBox("Attenzione, valore di Layout nel file ini errato!! Verificare!")
                End Select

                FormFLM_Resize()
            Catch ex As Exception
                flmLayout = 1
                fileErrorLog = My.Computer.FileSystem.OpenTextFileWriter(Today.Year & Today.Month & Today.Day & "ErrorLog.txt", True)
                fileErrorLog.WriteLine(Now.ToShortTimeString & " - FormFLM_Load" & " - flmLayout - " & ex.Message)
                fileErrorLog.Close()
            End Try

        Else
            'Il file non esiste, verrà creato
            CreaFileIni()
        End If

        Dim usoFont As Font
        usoFont = New Font(fontIntestazioni, fontIntestazioniSize, fontIntestazioniStyle)
        GroupBoxObj.Font = usoFont
        GroupBoxObj.ForeColor = Color.FromName(fontIntestazioniColor)
        GroupBoxProprietà.Font = usoFont
        GroupBoxProprietà.ForeColor = Color.FromName(fontIntestazioniColor)

        LabelScreenRisoluzione.ForeColor = Color.FromName(fontIntestazioniColor)
        LabelValoreCursore.ForeColor = Color.FromName(fontIntestazioniColor)
        TextBoxValoreCursore.ForeColor = Color.FromName(fontIntestazioniColor)
        LabelPannello.ForeColor = Color.FromName(fontIntestazioniColor)
        LabelPosizioneMouse.ForeColor = Color.FromName(fontIntestazioniColor)
        LabelPercorso.ForeColor = Color.FromName(fontIntestazioniColor)
        LabelZoom.ForeColor = Color.FromName(fontIntestazioniColor)
        LabelZoomTesto.ForeColor = Color.FromName(fontIntestazioniColor)
        TextBoxZoom.ForeColor = Color.FromName(fontIntestazioniColor)

        usoFont = New Font(fontElementi, fontElementiSize, FontStyle.Regular)
        ListBoxObj.Font = usoFont

        If flmBackgroundImageCheck Then
            Me.BackgroundImage = ClassUtility.ChangeOpacity(flmBackgroundImage, 1)
        Else
            Me.BackgroundImage = Nothing
        End If

        dtOptionsLayout = New DataTable("Options")

        formDimensioni = Me.Size

        LabelPercorso.Text = feelPath

        colorDialog1.AnyColor = True
        colorDialog1.FullOpen = True
        colorDialog1.Text = "Seleziona un colore"

        LabelSoundPath2.Text = feelPath & "\media"
        LabelMusic_path.Text = feelPath & "\media"

        dtRisoluzioni = New DataTable("Risoluzioni")

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

                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        fileErrorLog = My.Computer.FileSystem.OpenTextFileWriter(Today.Year & Today.Month & Today.Day & "ErrorLog.txt", True)
                        fileErrorLog.WriteLine(Now.ToShortTimeString & " - FormFLM_Load" & " - MyReader - " & ex.Message)
                        fileErrorLog.Close()
                    End Try
                End While
            End Using
        Catch ex As Exception 'problemi nel trovare il file, carica i dati di default
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
            riga = {"1366x768  16:9", "1366", "768", "16:9"}
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

            fileErrorLog = My.Computer.FileSystem.OpenTextFileWriter(Today.Year & Today.Month & Today.Day & "ErrorLog.txt", True)
            fileErrorLog.WriteLine(Now.ToShortTimeString & " - FormFLM_Load" & " - dtRisoluzioni - " & ex.Message)
            fileErrorLog.Close()
        End Try

        For Each riga As DataRow In dtRisoluzioni.Rows
            ComboBoxPubblica.Items.Add("Esporta in " & riga.Item(0))
        Next

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
            fileErrorLog = My.Computer.FileSystem.OpenTextFileWriter(Today.Year & Today.Month & Today.Day & "ErrorLog.txt", True)
            fileErrorLog.WriteLine(Now.ToShortTimeString & " - FormFLM_Load" & " - PanelMain.Size - " & ex.Message)
            fileErrorLog.Close()
        End Try

        For i As Integer = 0 To 23
            TabControlTemp.TabPages.Add(TabControlProprietà.TabPages(0))
        Next
        'ListBoxObj.SelectedItem = "Screen"
        TabControlProprietà.TabPages.Add(TabControlTemp.TabPages(3))

        dtOptionsLayout.Columns.Add("sound_fx_list", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_menu", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_confirm", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_cancel", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_startemu", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("sound_fx_volume", Type.GetType("System.String"))

        dtOptionsLayout.Columns.Add("music_path", Type.GetType("System.String"))
        dtOptionsLayout.Columns.Add("music_change_delay", Type.GetType("System.String"))
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

    Public Sub CreaFileIni()
        If My.Computer.FileSystem.FileExists("FLM.ini") Then
            My.Computer.FileSystem.DeleteFile("FLM.ini")
        End If

        Dim file As System.IO.StreamWriter

        file = My.Computer.FileSystem.OpenTextFileWriter("FLM.ini", True)

        file.WriteLine("File di configurazione del programma FLM F.E.(E.L.) Layout Manager by gothrek")
        file.WriteLine()
        file.WriteLine("non editare il file, le sue impostazioni vengono gestite direttamente dal programma.")
        file.WriteLine()
        file.WriteLine("feelPath=" & feelPath)
        file.WriteLine("grafxEditorPath=" & grafxEditorPath)
        file.WriteLine("templateLayoutIni=" & templateLayoutIni)
        file.WriteLine("fontIntestazioniName=" & fontIntestazioni)
        file.WriteLine("fontIntestazioniSize=" & fontIntestazioniSize)
        file.WriteLine("fontIntestazioniStyle=" & fontIntestazioniStyle)
        file.WriteLine("fontIntestazioniColor=" & fontIntestazioniColor)
        file.WriteLine("mouseTimeClick=" & mouseTimeClick)
        file.WriteLine("flmTips=" & flmTipsCheck)
        file.WriteLine("flmBackgroundImageCheck=" & flmBackgroundImageCheck)
        file.WriteLine("flmLayout=" & flmLayout)

        file.Close()
    End Sub

    Private Sub FormFLM_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If flmTipsCheck > 0 Then
            If My.Computer.FileSystem.FileExists("FLMTips.txt") Then

                Dim objReader As New StreamReader("FLMTips.txt")
                Dim sLine As String = ""
                Dim arrText As New ArrayList()

                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        arrText.Add(sLine)
                    End If
                Loop Until sLine Is Nothing
                objReader.Close()

                flmTip = arrText(flmTipsCheck)

                Dim esci As Boolean = False
                Do
                    Dim risultato As DialogResult = FormFLMtips.ShowDialog

                    If risultato = DialogResult.OK Then
                        flmTipsCheck += 1
                        If flmTipsCheck = arrText.Count Then
                            flmTipsCheck = 1
                        End If

                        flmTip = arrText(flmTipsCheck)
                        CreaFileIni()
                        esci = True 'da eliminare
                    Else
                        esci = True

                        If risultato = DialogResult.Cancel Then
                            flmTipsCheck = 0
                            CreaFileIni()
                        End If
                    End If
                Loop Until esci
            End If
        End If
    End Sub

    Public Sub FormFLM_Resize() Handles MyBase.Resize, MyBase.SizeChanged
        If Me.WindowState <> FormWindowState.Minimized Then

            If Me.Size.Width < 1280 Then
                Me.Size = New Size(1280, Me.Size.Height)
            End If

            If Me.Size.Height < 800 Then
                Me.Size = New Size(Me.Size.Width, 800)
            End If

            Select Case flmLayout
                Case 1
                    ToolStrip1.Visible = False

                    LabelFeelLayoutManager.Visible = False

                    GroupBoxProprietà.Size = New Size(Int(Me.Size.Width * 20 / 100), Int(Me.Size.Height - 92)) 'TODO personalizzare il valore 92= 39 barra form +41sopra +12sotto
                    GroupBoxProprietà.Location = New Point(12, 41)

                    GroupBoxObj.Size = New Size(Int(Me.Size.Width * 20 / 100), Int(Me.Size.Height - 92)) 'TODO personalizzare il valore 92= 39 barra form +41sopra +12sotto
                    GroupBoxObj.Location = New Point(Me.Size.Width - Int(Me.Size.Width * 20 / 100) - 20, GroupBoxObj.Location.Y) 'TODO personalizzare il valore -20=20% della nuova dimensione a 12+8di bord form

                    PanelMainMaster.Size = New Size(Int(Me.Size.Width * 50 / 100), Int(Me.Size.Height * 60 / 100)) 'Il pannello è il 50%W e il 60%H
                    PanelMainMaster.Location = New Point(Int(Me.Size.Width * 24.683544303797468 / 100) + 8, Int(Me.Size.Height * 14.5 / 100))

                    PanelMain.Size = PanelBackground.Size
                    PanelMain.Location = New Point(Int((PanelMainMaster.Size.Width - PanelBackground.Size.Width) / 2), PanelMain.Location.Y)

                    LabelScreenRisoluzione.Location = New Point(PanelMainMaster.Location.X, PanelMainMaster.Location.Y - 16)

                    LabelPannello.Location = New Point(Int(PanelMainMaster.Location.X + PanelMainMaster.Location.X * 50 / 100), PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)

                    LabelPannelloMainY.Location = New Point(Int(PanelMainMaster.Location.X + PanelMainMaster.Size.Width / 2), PanelMainMaster.Location.Y - 16)

                    ButtonPannelloMainReset.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Size.Width - ButtonPannelloMainReset.Size.Width, PanelMainMaster.Location.Y - 45)

                    LabelValoreCursore.Location = New Point(PanelMainMaster.Location.X, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)
                    TextBoxValoreCursore.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width + ButtonValoreCursoreSX.Size.Width + 3, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)
                    TextBoxValoreCursore.BackColor = Color.Black
                    ButtonValoreCursoreSX.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width, PanelMainMaster.Location.Y + PanelMainMaster.Height)
                    ButtonValoreCursoreSX.BackColor = Color.Black
                    ButtonValoreCursoreSX.Image = My.Resources.Remove_color_16x
                    ButtonValoreCursoreDX.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width + ButtonValoreCursoreSX.Size.Width + TextBoxValoreCursore.Size.Width, PanelMainMaster.Location.Y + PanelMainMaster.Height)
                    ButtonValoreCursoreDX.BackColor = Color.Black
                    ButtonValoreCursoreDX.Image = My.Resources.Add_16x

                    LabelPercorso.Location = New Point(PanelMainMaster.Location.X, Me.Size.Height - 31 - 39)

                    PanelZoom.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Size.Width - PanelZoom.Size.Width, Me.Size.Height - 68 - 39)
                    TrackBarZoom.BackColor = Color.Black
                    TextBoxZoom.BackColor = Color.Black

                    ButtonCarica.Location = New Point(12, 1)
                    ButtonCarica.Visible = True

                    ButtonPainter.Location = New Point(ButtonCarica.Location.X + ButtonCarica.Size.Width + 6, ButtonCarica.Location.Y)
                    ButtonPainter.Visible = True

                    ButtonPubblica.Location = New Point(ButtonPainter.Location.X + ButtonPainter.Size.Width + 6, ButtonCarica.Location.Y)
                    ComboBoxPubblica.Location = ButtonPubblica.Location
                    ButtonPubblica.Visible = True
                    ComboBoxPubblica.Visible = True

                    ButtonAbout.Location = New Point(Me.Size.Width - ButtonAbout.Size.Width - 20 - 8, ButtonCarica.Location.Y)

                    ButtonFLMOptions.Location = New Point(ButtonAbout.Location.X - ButtonFLMOptions.Size.Width - 6, ButtonCarica.Location.Y)
                    ButtonFLMOptions.Visible = True

                    ButtonAnteprima.Location = New Point(ButtonFLMOptions.Location.X - ButtonAnteprima.Size.Width - 6, ButtonCarica.Location.Y)
                    ButtonAnteprima.Visible = True

                    ButtonAbout.Visible = True

                    LabelPosizioneMouse.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Width - LabelPosizioneMouse.Width - 23, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)
                Case 2
                    ToolStrip1.Visible = False

                    LabelFeelLayoutManager.Visible = False

                    GroupBoxObj.Size = New Size(Int(Me.Size.Width * 20 / 100), Int(Me.Size.Height - 92)) 'TODO personalizzare il valore 92= 39 barra form +41sopra +12sotto
                    GroupBoxObj.Location = New Point(12, 41) 'TODO personalizzare il valore -20=20% della nuova dimensione a 12+8di bord form

                    GroupBoxProprietà.Size = New Size(Int(Me.Size.Width * 20 / 100), Int(Me.Size.Height - 92)) 'TODO personalizzare il valore 92= 39 barra form +41sopra +12sotto
                    GroupBoxProprietà.Location = New Point(GroupBoxObj.Location.X + GroupBoxObj.Size.Width + 12, GroupBoxObj.Location.Y)

                    PanelMainMaster.Size = New Size(Int(Me.Size.Width * 50 / 100), Int(Me.Size.Height * 60 / 100)) 'Il pannello è il 50%W e il 60%H
                    PanelMainMaster.Location = New Point(Me.Size.Width - PanelMainMaster.Size.Width - 50 * (Me.Size.Width / 1280), Int(Me.Size.Height * 14.5 / 100))

                    PanelMain.Size = PanelBackground.Size
                    PanelMain.Location = New Point(Int((PanelMainMaster.Size.Width - PanelBackground.Size.Width) / 2), PanelMain.Location.Y)

                    LabelScreenRisoluzione.Location = New Point(PanelMainMaster.Location.X, PanelMainMaster.Location.Y - 16)

                    LabelPannello.Location = New Point(Int(PanelMainMaster.Location.X + PanelMainMaster.Location.X * 50 / 100), PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)

                    LabelPannelloMainY.Location = New Point(Int(PanelMainMaster.Location.X + PanelMainMaster.Size.Width / 2), PanelMainMaster.Location.Y - 16)

                    ButtonPannelloMainReset.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Size.Width - ButtonPannelloMainReset.Size.Width, PanelMainMaster.Location.Y - 45)

                    LabelValoreCursore.Location = New Point(PanelMainMaster.Location.X, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)
                    TextBoxValoreCursore.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width + ButtonValoreCursoreSX.Size.Width + 3, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)
                    TextBoxValoreCursore.BackColor = Color.Black
                    ButtonValoreCursoreSX.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width, PanelMainMaster.Location.Y + PanelMainMaster.Height)
                    ButtonValoreCursoreSX.BackColor = Color.Black
                    ButtonValoreCursoreSX.Image = My.Resources.Remove_color_16x
                    ButtonValoreCursoreDX.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width + ButtonValoreCursoreSX.Size.Width + TextBoxValoreCursore.Size.Width, PanelMainMaster.Location.Y + PanelMainMaster.Height)
                    ButtonValoreCursoreDX.BackColor = Color.Black
                    ButtonValoreCursoreDX.Image = My.Resources.Add_16x

                    LabelPercorso.Location = New Point(PanelMainMaster.Location.X, Me.Size.Height - 31 - 39)

                    PanelZoom.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Size.Width - PanelZoom.Size.Width, Me.Size.Height - 68 - 39)
                    TrackBarZoom.BackColor = Color.Black
                    TextBoxZoom.BackColor = Color.Black

                    ButtonCarica.Location = New Point(12, 1)
                    ButtonCarica.Visible = True

                    ButtonPainter.Location = New Point(ButtonCarica.Location.X + ButtonCarica.Size.Width + 6, ButtonCarica.Location.Y)
                    ButtonPainter.Visible = True

                    ButtonPubblica.Location = New Point(ButtonPainter.Location.X + ButtonPainter.Size.Width + 6, ButtonCarica.Location.Y)
                    ComboBoxPubblica.Location = ButtonPubblica.Location
                    ButtonPubblica.Visible = True
                    ComboBoxPubblica.Visible = True

                    ButtonAbout.Location = New Point(Me.Size.Width - ButtonAbout.Size.Width - 20 - 8, ButtonCarica.Location.Y)

                    ButtonFLMOptions.Location = New Point(ButtonAbout.Location.X - ButtonFLMOptions.Size.Width - 6, ButtonCarica.Location.Y)
                    ButtonFLMOptions.Visible = True

                    ButtonAnteprima.Location = New Point(ButtonFLMOptions.Location.X - ButtonAnteprima.Size.Width - 6, ButtonCarica.Location.Y)
                    ButtonAnteprima.Visible = True

                    ButtonAbout.Visible = True

                    LabelPosizioneMouse.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Width - LabelPosizioneMouse.Width - 23, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)
                Case 3
                    ToolStrip1.Visible = True

                    GroupBoxObj.Size = New Size(Int(Me.Size.Width * 20 / 100), Int(Me.Size.Height - 92)) 'TODO personalizzare il valore 92= 39 barra form +41sopra +12sotto
                    GroupBoxObj.Location = New Point(12, 41) 'TODO personalizzare il valore -20=20% della nuova dimensione a 12+8di bord form

                    GroupBoxProprietà.Size = New Size(Int(Me.Size.Width * 20 / 100), Int(Me.Size.Height - 92)) 'TODO personalizzare il valore 92= 39 barra form +41sopra +12sotto
                    GroupBoxProprietà.Location = New Point(GroupBoxObj.Location.X + GroupBoxObj.Size.Width + 12, GroupBoxObj.Location.Y)

                    PanelMainMaster.Size = New Size(Int(Me.Size.Width * 50 / 100), Int(Me.Size.Height * 60 / 100)) 'Il pannello è il 50%W e il 60%H
                    PanelMainMaster.Location = New Point(Me.Size.Width - PanelMainMaster.Size.Width - 50 * (Me.Size.Width / 1280), Int(Me.Size.Height * 14.5 / 100))

                    PanelMain.Size = PanelBackground.Size
                    PanelMain.Location = New Point(Int((PanelMainMaster.Size.Width - PanelBackground.Size.Width) / 2), PanelMain.Location.Y)

                    LabelScreenRisoluzione.Location = New Point(PanelMainMaster.Location.X, PanelMainMaster.Location.Y - 16)

                    LabelPannello.Location = New Point(Int(PanelMainMaster.Location.X + PanelMainMaster.Location.X * 50 / 100), PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)

                    LabelPannelloMainY.Location = New Point(Int(PanelMainMaster.Location.X + PanelMainMaster.Size.Width / 2), PanelMainMaster.Location.Y - 16)

                    ButtonPannelloMainReset.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Size.Width - ButtonPannelloMainReset.Size.Width, PanelMainMaster.Location.Y - 45)

                    LabelValoreCursore.Location = New Point(PanelMainMaster.Location.X, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)
                    TextBoxValoreCursore.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width + ButtonValoreCursoreSX.Size.Width + 3, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)
                    TextBoxValoreCursore.BackColor = Color.FromArgb(255, 30, 30, 30)
                    ButtonValoreCursoreSX.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width, PanelMainMaster.Location.Y + PanelMainMaster.Height)
                    ButtonValoreCursoreSX.BackColor = Color.FromArgb(255, 30, 30, 30)
                    ButtonValoreCursoreSX.Image = My.Resources.Remove_16x
                    ButtonValoreCursoreDX.Location = New Point(PanelMainMaster.Location.X + LabelValoreCursore.Size.Width + ButtonValoreCursoreSX.Size.Width + TextBoxValoreCursore.Size.Width, PanelMainMaster.Location.Y + PanelMainMaster.Height)
                    ButtonValoreCursoreDX.BackColor = Color.FromArgb(255, 30, 30, 30)
                    ButtonValoreCursoreDX.Image = My.Resources.Add_grey_16x

                    LabelPercorso.Location = New Point(PanelMainMaster.Location.X, Me.Size.Height - 31 - 39)

                    PanelZoom.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Size.Width - PanelZoom.Size.Width, Me.Size.Height - 68 - 39)
                    TrackBarZoom.BackColor = Color.FromArgb(255, 30, 30, 30)
                    TextBoxZoom.BackColor = Color.FromArgb(255, 30, 30, 30)

                    ButtonCarica.Location = New Point(12, 1)
                    ButtonCarica.Visible = False

                    ButtonPainter.Location = New Point(ButtonCarica.Location.X + ButtonCarica.Size.Width + 6, ButtonCarica.Location.Y)
                    ButtonPainter.Visible = False

                    ButtonPubblica.Location = New Point(ButtonPainter.Location.X + ButtonPainter.Size.Width + 6, ButtonCarica.Location.Y)
                    ComboBoxPubblica.Location = ButtonPubblica.Location
                    ButtonPubblica.Visible = False
                    ComboBoxPubblica.Visible = False

                    ButtonAbout.Location = New Point(Me.Size.Width - ButtonAbout.Size.Width - 20 - 8, ButtonCarica.Location.Y)

                    ButtonFLMOptions.Location = New Point(ButtonAbout.Location.X - ButtonFLMOptions.Size.Width - 6, ButtonCarica.Location.Y)
                    ButtonFLMOptions.Visible = False

                    ButtonAnteprima.Location = New Point(ButtonFLMOptions.Location.X - ButtonAnteprima.Size.Width - 6, ButtonCarica.Location.Y)
                    ButtonAnteprima.Visible = False

                    ButtonAbout.Visible = False

                    LabelPosizioneMouse.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Width - LabelPosizioneMouse.Width - 23, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)

                    LabelFeelLayoutManager.Location = New Point(PanelMainMaster.Location.X + ((PanelMainMaster.Size.Width - LabelFeelLayoutManager.Size.Width) / 2), LabelFeelLayoutManager.Location.Y)
                    LabelFeelLayoutManager.Visible = True
                Case Else

            End Select

            Try
                TrackBarZoom.Maximum = Int(PanelMainMaster.Size.Width / Int(TextBoxScreen_res_x.Text) * 100)

                If Int(PanelMainMaster.Size.Height / Int(TextBoxScreen_res_y.Text) * 100) < TrackBarZoom.Maximum Then
                    TrackBarZoom.Maximum = Int(PanelMainMaster.Size.Height / Int(TextBoxScreen_res_y.Text) * 100)
                End If

                TextBoxZoom.Text = TrackBarZoom.Value
            Catch ex As Exception
                fileErrorLog = My.Computer.FileSystem.OpenTextFileWriter(Today.Year & Today.Month & Today.Day & "ErrorLog.txt", True)
                fileErrorLog.WriteLine(Now.ToShortTimeString & " - FormFLM_Resize" & " - TrackBarZoom.Maximum - " & ex.Message)
                fileErrorLog.Close()
            End Try

        End If
    End Sub

    Private Sub FormFLM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        mp3player.Close()
        dtOptionsLayout.Dispose()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        mp3player.Close()
        dtOptionsLayout.Dispose()
        Me.Close()
    End Sub

    Private Sub ButtonPainter_Click(sender As Object, e As EventArgs) Handles ButtonPainter.Click,
                                                                                PaintToolStripMenuItem.Click

        Dim proc As New System.Diagnostics.Process()

        proc = Process.Start(grafxEditorPath, "")
    End Sub

    Private Sub ButtonAbout_Click(sender As Object, e As EventArgs) Handles ButtonAbout.Click,
                                                                                InformazioniSuFeelLayoutManagerToolStripMenuItem.Click

        soundPlay = False
        musicPlay = False
        ButtonSoundPlay.Text = "Play"
        ButtonMusicPlay.Text = "Play"
        mp3player.Close()
        FormFLMAbout.Show()
    End Sub

    Private Sub SupportoTecnico_Click(sender As Object, e As EventArgs) Handles SupportoTecnico.Click
        Process.Start("https://www.arcadeitalia.net/viewforum.php?f=64")
    End Sub

    Private Sub FEELWebSiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FEELWebSiteToolStripMenuItem.Click
        Process.Start("http://feelfrontend.altervista.org/it/")
    End Sub

    Private Sub SegnalaUnProblemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SegnalaUnProblemaToolStripMenuItem.Click
        Process.Start("https://github.com/gothrek/GotScraperV2/issues")
    End Sub

    Private Sub SuggerisciUnaFunzionalitàToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuggerisciUnaFunzionalitàToolStripMenuItem.Click
        Process.Start("https://github.com/gothrek/GotScraperV2")
    End Sub

    Private Sub VisualizzaGuidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisualizzaGuidaToolStripMenuItem.Click
        If System.IO.File.Exists("Quick Guide FLM.pdf") Then
            Process.Start("Quick Guide FLM.pdf")
        Else
            MsgBox("Attenzione!! Verificare esistenza file guida 'Quick Guide FLM.pdf'")
        End If
    End Sub

    Private Sub OffrimiUnCaffèToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OffrimiUnCaffèToolStripMenuItem.Click
        'BuyMeACoffee

        MsgBox("Ti è piaciuto il mio lavoro? offrimi un caffè!! " & vbCr & "    (paypal gothek@hotmail.com)")
    End Sub
    Private Sub ButtonFLMOptions_Click(sender As Object, e As EventArgs) Handles ButtonFLMOptions.Click,
                                                                                OpzioniToolStripMenuItem.Click

        soundPlay = False
        musicPlay = False
        ButtonSoundPlay.Text = "Play"
        ButtonMusicPlay.Text = "Play"
        mp3player.Close()
        FormFLMoptions.ShowDialog()
    End Sub

    Private Sub ButtonAnteprima_Click(sender As Object, e As EventArgs) Handles ButtonAnteprima.Click,
                                                                                AnteprimaToolStripMenuItem.Click

        ValoriInTabella()
        soundPlay = False
        musicPlay = False
        ButtonSoundPlay.Text = "Play"
        ButtonMusicPlay.Text = "Play"
        mp3player.Close()
        FormFLManteprimaV2.Show()
    End Sub

    Private Sub LabelCarica_DoubleClick(sender As Object, e As EventArgs) Handles LabelPercorso.DoubleClick
        Dim cartella As String
        Dim folder As DirectoryInfo

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            cartella = FolderBrowserDialog1.SelectedPath

            LabelPercorso.Text = cartella
            LabelPercorso.Refresh()

            folder = My.Computer.FileSystem.GetDirectoryInfo(cartella)
        End If
    End Sub

    Private Sub ButtonCarica_Click(sender As Object, e As EventArgs) Handles ButtonCarica.Click,
                                                                                LoadToolStripMenuItem.Click
        Dim cartella As String = ""
        Dim folder As DirectoryInfo
        Dim file As System.IO.StreamReader
        Dim campiDisabilitati As ArrayList = New ArrayList

        FolderBrowserDialog1.SelectedPath = feelPath & "\layouts\"

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) And My.Computer.FileSystem.FileExists(FolderBrowserDialog1.SelectedPath & "\" & "layout.ini") Then
            cartella = FolderBrowserDialog1.SelectedPath

            PanelMainMaster.Visible = False

            LabelPercorso.Text = cartella
            LabelPercorso.Refresh()

            folder = My.Computer.FileSystem.GetDirectoryInfo(cartella)

            dtOptionsLayout.Rows.Add()

            file = My.Computer.FileSystem.OpenTextFileReader(cartella & "\" & "layout.ini")

            While Not file.EndOfStream
                Try
                    Dim riga As String = file.ReadLine

                    If riga.Substring(0, 1) = "#" Then
                        campiDisabilitati.Add(riga.Substring(1, riga.IndexOf(" ") - 1))
                    Else
                        Dim campo As String = riga.Substring(0, riga.IndexOf(" "))
                        Dim valore As String = riga.Substring(40)

                        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(campo) = valore
                    End If
                Catch ex As Exception
                    fileErrorLog = My.Computer.FileSystem.OpenTextFileWriter(Today.Year & Today.Month & Today.Day & "ErrorLog.txt", True)
                    fileErrorLog.WriteLine(Now.ToShortTimeString & " - ButtonCarica_Click" & " - file.ReadLine - " & ex.Message)
                    fileErrorLog.Close()
                End Try
            End While

            mp3player.Close()
            ListBoxSound.Items.Clear()
            soundPlay = False
            musicPlay = False
            ButtonSoundPlay.Text = "Play"
            ButtonMusicPlay.Text = "Play"

            Try
                TextBoxSound_fx_list.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_list")
                ListBoxSound.Items.Add(TextBoxSound_fx_list.Text)
                LabelSound_fx_list.ForeColor = Color.Black
            Catch ex As Exception
                LabelSound_fx_list.ForeColor = Color.Green
            End Try
            Try
                TextBoxSound_fx_menu.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_menu")
                ListBoxSound.Items.Add(TextBoxSound_fx_menu.Text)
                LabelSound_fx_menu.ForeColor = Color.Black
            Catch ex As Exception
                LabelSound_fx_menu.ForeColor = Color.Green
            End Try
            Try
                TextBoxSound_fx_confirm.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_confirm")
                ListBoxSound.Items.Add(TextBoxSound_fx_confirm.Text)
                LabelSound_fx_confirm.ForeColor = Color.Black
            Catch ex As Exception
                LabelSound_fx_confirm.ForeColor = Color.Green
            End Try
            Try
                TextBoxSound_fx_cancel.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_cancel")
                ListBoxSound.Items.Add(TextBoxSound_fx_cancel.Text)
                LabelSound_fx_cancel.ForeColor = Color.Black
            Catch ex As Exception
                LabelSound_fx_cancel.ForeColor = Color.Green
            End Try
            Try
                TextBoxSound_fx_startemu.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_startemu")
                ListBoxSound.Items.Add(TextBoxSound_fx_startemu.Text)
                LabelSound_fx_startemu.ForeColor = Color.Black
            Catch ex As Exception
                LabelSound_fx_startemu.ForeColor = Color.Green
            End Try
            Try
                TextBoxSound_fx_volume.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_volume")
                LabelSound_fx_volume.ForeColor = Color.Black
            Catch ex As Exception
                LabelSound_fx_volume.ForeColor = Color.Green
            End Try

            Try
                TextBoxMusic_path.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_path")
                LabelMusic_path.ForeColor = Color.Black
            Catch ex As Exception
                LabelMusic_path.ForeColor = Color.Green
            End Try
            Try
                TextBoxMusic_change_delay.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_change_delay")
                LabelMusic_path.ForeColor = Color.Black
            Catch ex As Exception
                LabelMusic_path.ForeColor = Color.Green
            End Try
            Try
                TextBoxMusic_volume.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_volume")
                LabelMusic_volume.ForeColor = Color.Black
            Catch ex As Exception
                LabelMusic_volume.ForeColor = Color.Green
            End Try

            Try
                TextBoxScreen_res_x.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_res_x")
                LabelScreen_res_x.ForeColor = Color.Black
            Catch ex As Exception
                LabelScreen_res_x.ForeColor = Color.Green
            End Try
            Try
                TextBoxScreen_res_y.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_res_y")
                LabelScreen_res_y.ForeColor = Color.Black
            Catch ex As Exception
                LabelScreen_res_y.ForeColor = Color.Green
            End Try
            Try
                TextBoxScreen_saver_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_saver_backcolor")
                LabelScreen_saver_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelScreen_saver_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxScreen_saver_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("screen_saver_font_color")
                LabelScreen_saver_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelScreen_saver_font_color.ForeColor = Color.Green
            End Try

            Try
                TextBoxRomlist_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_x_pos")
                LabelRomlist_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_y_pos")
                LabelRomlist_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_width")
                LabelRomlist_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_height")
                LabelRomlist_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_name")
                LabelRomlist_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_item_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_item_height")
                LabelRomlist_item_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_item_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_size")
                LabelRomlist_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_style")
                LabelRomlist_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_font_color")
                LabelRomlist_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_backcolor")
                LabelRomlist_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_selected_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_selected_font_color")
                LabelRomlist_selected_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_selected_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_selected_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_selected_backcolor")
                LabelRomlist_selected_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_selected_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomlist_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_text_align")
                LabelRomlist_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomlist_text_align.ForeColor = Color.Green
            End Try
            Try
                CheckBoxRomlist_disable_stars.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romlist_disable_stars"))
                CheckBoxRomlist_disable_stars.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRomlist_disable_stars.ForeColor = Color.Green
            End Try

            Try
                TextBoxBackground_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_width")
                LabelBackground_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelBackground_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxBackground_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_height")
                LabelBackground_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelBackground_height.ForeColor = Color.Green
            End Try
            Try
                CheckBoxBackground_ontop.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_ontop"))
                CheckBoxBackground_ontop.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxBackground_ontop.ForeColor = Color.Green
            End Try
            Try
                TextBoxBackground_frame_duration_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_frame_duration_ms")
                LabelBackground_frame_duration_ms.ForeColor = Color.Black
            Catch ex As Exception
                LabelBackground_frame_duration_ms.ForeColor = Color.Green
            End Try
            Try
                TextBoxBackground_repeat_delay_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("background_repeat_delay_ms")
                LabelBackground_repeat_delay_ms.ForeColor = Color.Black
            Catch ex As Exception
                LabelBackground_repeat_delay_ms.ForeColor = Color.Green
            End Try
            Try
                Dim bm As Bitmap
                bm = ClassUtility.ChangeOpacity(Image.FromFile(LabelPercorso.Text & "\main.png"), TrackBarPanelBackgroundImage.Value / 100)
                PanelBackground.BackgroundImage = bm
                PanelBackground.Refresh()
            Catch ex As Exception
            End Try

            Try
                TextBoxSnapshot_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_x_pos")
                LabelSnapshot_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelSnapshot_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxSnapshot_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_y_pos")
                LabelSnapshot_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelSnapshot_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxSnapshot_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_width")
                LabelSnapshot_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelSnapshot_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxSnapshot_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_height")
                LabelSnapshot_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelSnapshot_height.ForeColor = Color.Green
            End Try
            Try
                CheckBoxSnapshot_stretch.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_stretch"))
                CheckBoxSnapshot_stretch.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxSnapshot_stretch.ForeColor = Color.Green
            End Try
            Try
                CheckBoxSnapshot_blackbackground.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("snapshot_blackbackground"))
                CheckBoxSnapshot_blackbackground.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxSnapshot_blackbackground.ForeColor = Color.Green
            End Try

            Try
                CheckBoxCabinet_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_visible"))
                CheckBoxCabinet_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxCabinet_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxCabinet_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_x_pos")
                LabelCabinet_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelCabinet_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxCabinet_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_y_pos")
                LabelCabinet_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelCabinet_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxCabinet_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_width")
                LabelCabinet_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelCabinet_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxCabinet_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_height")
                LabelCabinet_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelCabinet_height.ForeColor = Color.Green
            End Try
            Try
                CheckBoxCabinet_stretch.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_stretch"))
                CheckBoxCabinet_stretch.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxCabinet_stretch.ForeColor = Color.Green
            End Try
            Try
                CheckBoxCabinet_blackbackground.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("cabinet_blackbackground"))
                CheckBoxCabinet_blackbackground.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxCabinet_blackbackground.ForeColor = Color.Green
            End Try

            Try
                CheckBoxMarquee_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_visible"))
                CheckBoxMarquee_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxMarquee_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxMarquee_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_x_pos")
                LabelMarquee_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelMarquee_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxMarquee_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_y_pos")
                LabelMarquee_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelMarquee_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxMarquee_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_width")
                LabelMarquee_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelMarquee_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxMarquee_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_height")
                LabelMarquee_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelMarquee_height.ForeColor = Color.Green
            End Try
            Try
                CheckBoxMarquee_stretch.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_stretch"))
                CheckBoxMarquee_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxMarquee_visible.ForeColor = Color.Green
            End Try
            Try
                CheckBoxMarquee_blackbackground.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("marquee_blackbackground"))
                CheckBoxMarquee_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxMarquee_visible.ForeColor = Color.Green
            End Try

            Try
                CheckBoxRomcounter_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_visible"))
                CheckBoxRomcounter_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRomcounter_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_x_pos")
                LabelRomcounter_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_y_pos")
                LabelRomcounter_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_width")
                LabelRomcounter_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_height")
                LabelRomcounter_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_name")
                LabelRomcounter_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_size")
                LabelRomcounter_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_style")
                LabelRomcounter_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_font_color")
                LabelRomcounter_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_backcolor")
                LabelRomcounter_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcounter_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcounter_text_align")
                LabelRomcounter_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcounter_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxPlatformname_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_visible"))
                CheckBoxPlatformname_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxPlatformname_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_x_pos")
                LabelPlatformname_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_y_pos")
                LabelPlatformname_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_width")
                LabelPlatformname_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_height")
                LabelPlatformname_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_name")
                LabelPlatformname_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_size")
                LabelPlatformname_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_style")
                LabelPlatformname_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_font_color")
                LabelPlatformname_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_backcolor")
                LabelPlatformname_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxPlatformname_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("platformname_text_align")
                LabelPlatformname_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelPlatformname_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxEmulatorname_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_visible"))
                CheckBoxEmulatorname_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxEmulatorname_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_x_pos")
                LabelEmulatorname_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_y_pos")
                LabelEmulatorname_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_width")
                LabelEmulatorname_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_height")
                LabelEmulatorname_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_name")
                LabelEmulatorname_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_size")
                LabelEmulatorname_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_style")
                LabelEmulatorname_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_font_color")
                LabelEmulatorname_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_backcolor")
                LabelEmulatorname_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxEmulatorname_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("emulatorname_text_align")
                LabelEmulatorname_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelEmulatorname_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxGamelistname_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_visible"))
                CheckBoxGamelistname_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxGamelistname_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_x_pos")
                LabelGamelistname_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_y_pos")
                LabelGamelistname_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_width")
                LabelGamelistname_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_height")
                LabelGamelistname_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_name")
                LabelGamelistname_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_size")
                LabelGamelistname_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_style")
                LabelGamelistname_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_font_color")
                LabelGamelistname_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_backcolor")
                LabelGamelistname_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxGamelistname_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("gamelistname_text_align")
                LabelGamelistname_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelGamelistname_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxRomname_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_visible"))
                CheckBoxRomname_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRomname_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_x_pos")
                LabelRomname_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_y_pos")
                LabelRomname_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_width")
                LabelRomname_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_height")
                LabelRomname_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_name")
                LabelRomname_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_size")
                LabelRomname_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_style")
                LabelRomname_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_font_color")
                LabelRomname_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_backcolor")
                LabelRomname_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomname_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romname_text_align")
                LabelRomname_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomname_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxRomdescription_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_visible"))
                CheckBoxRomdescription_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRomdescription_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_x_pos")
                LabelRomdescription_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_y_pos")
                LabelRomdescription_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_width")
                LabelRomdescription_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_height")
                LabelRomdescription_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_name")
                LabelRomdescription_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_size")
                LabelRomdescription_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_style")
                LabelRomdescription_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_font_color")
                LabelRomdescription_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_backcolor")
                LabelRomdescription_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdescription_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdescription_text_align")
                LabelRomdescription_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdescription_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxRommanufacturer_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_visible"))
                CheckBoxRommanufacturer_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRommanufacturer_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_x_pos")
                LabelRommanufacturer_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_y_pos")
                LabelRommanufacturer_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_width")
                LabelRommanufacturer_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_height")
                LabelRommanufacturer_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_name")
                LabelRommanufacturer_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_size")
                LabelRommanufacturer_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_style")
                LabelRommanufacturer_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_font_color")
                LabelRommanufacturer_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_backcolor")
                LabelRommanufacturer_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRommanufacturer_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rommanufacturer_text_align")
                LabelRommanufacturer_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRommanufacturer_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxRomdisplaytype_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_visible"))
                CheckBoxRomdisplaytype_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRomdisplaytype_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_x_pos")
                LabelRomdisplaytype_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_y_pos")
                LabelRomdisplaytype_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_width")
                LabelRomdisplaytype_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_height")
                LabelRomdisplaytype_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_name")
                LabelRomdisplaytype_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_size")
                LabelRomdisplaytype_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_style")
                LabelRomdisplaytype_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_font_color")
                LabelRomdisplaytype_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_backcolor")
                LabelRomdisplaytype_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomdisplaytype_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romdisplaytype_text_align")
                LabelRomdisplaytype_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomdisplaytype_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxRominputcontrol_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_visible"))
                CheckBoxRominputcontrol_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRominputcontrol_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_x_pos")
                LabelRominputcontrol_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_y_pos")
                LabelRominputcontrol_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_width")
                LabelRominputcontrol_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_height")
                LabelRominputcontrol_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_name")
                LabelRominputcontrol_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_size")
                LabelRominputcontrol_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_style")
                LabelRominputcontrol_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_font_color")
                LabelRominputcontrol_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_backcolor")
                LabelRominputcontrol_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRominputcontrol_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("rominputcontrol_text_align")
                LabelRominputcontrol_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRominputcontrol_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxRomstatus_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_visible"))
                CheckBoxRomstatus_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRomstatus_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_x_pos")
                LabelRomstatus_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_y_pos")
                LabelRomstatus_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_width")
                LabelRomstatus_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_height")
                LabelRomstatus_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_name")
                LabelRomstatus_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_size")
                LabelRomstatus_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_style")
                LabelRomstatus_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_font_color")
                LabelRomstatus_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_backcolor")
                LabelRomstatus_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomstatus_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romstatus_text_align")
                LabelRomstatus_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomstatus_text_align.ForeColor = Color.Green
            End Try

            Try
                CheckBoxRomcategory_visible.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_visible"))
                CheckBoxRomcategory_visible.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxRomcategory_visible.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_x_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_x_pos")
                LabelRomcategory_x_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_x_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_y_pos.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_y_pos")
                LabelRomcategory_y_pos.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_y_pos.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_width")
                LabelRomcategory_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_height")
                LabelRomcategory_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_name")
                LabelRomcategory_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_size")
                LabelRomcategory_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_style")
                LabelRomcategory_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_font_color")
                LabelRomcategory_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_backcolor")
                LabelRomcategory_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxRomcategory_text_align.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("romcategory_text_align")
                LabelRomcategory_text_align.ForeColor = Color.Black
            Catch ex As Exception
                LabelRomcategory_text_align.ForeColor = Color.Green
            End Try

            Try
                TextBoxMenu_width.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_width")
                LabelMenu_width.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_width.ForeColor = Color.Green
            End Try
            Try
                TextBoxMenu_item_height.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_item_height")
                LabelMenu_item_height.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_item_height.ForeColor = Color.Green
            End Try
            Try
                TextBoxMenu_font_name.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_name")
                LabelMenu_font_name.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_font_name.ForeColor = Color.Green
            End Try
            Try
                TextBoxMenu_font_size.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_size")
                LabelMenu_font_size.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_font_size.ForeColor = Color.Green
            End Try
            Try
                TextBoxMenu_font_style.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_style")
                LabelMenu_font_style.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_font_style.ForeColor = Color.Green
            End Try
            Try
                TextBoxMenu_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_font_color")
                LabelMenu_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxMenu_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_backcolor")
                LabelMenu_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_backcolor.ForeColor = Color.Green
            End Try
            Try
                TextBoxMenu_selected_font_color.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_selected_font_color")
                LabelMenu_selected_font_color.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_selected_font_color.ForeColor = Color.Green
            End Try
            Try
                TextBoxMenu_selected_backcolor.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_selected_backcolor")
                LabelMenu_selected_backcolor.ForeColor = Color.Black
            Catch ex As Exception
                LabelMenu_selected_backcolor.ForeColor = Color.Green
            End Try
            Try
                CheckBoxMenu_show_sidebar.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("menu_show_sidebar"))
                CheckBoxMenu_show_sidebar.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxMenu_show_sidebar.ForeColor = Color.Green
            End Try

            Try
                TextBoxActors_frame_duration_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("actors_frame_duration_ms")
                LabelActors_frame_duration_ms.ForeColor = Color.Black
            Catch ex As Exception
                LabelActors_frame_duration_ms.ForeColor = Color.Green
            End Try

            Try
                TextBoxActors_repeat_delay_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("actors_repeat_delay_ms")
                LabelActors_repeat_delay_ms.ForeColor = Color.Black
            Catch ex As Exception
                LabelActors_repeat_delay_ms.ForeColor = Color.Green
            End Try

            Try
                TextBoxBezel_frame_duration_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("bezel_frame_duration_ms")
                LabelBezel_frame_duration_ms.ForeColor = Color.Black
            Catch ex As Exception
                LabelBezel_frame_duration_ms.ForeColor = Color.Green
            End Try

            Try
                TextBoxBezel_repeat_delay_ms.Text = dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("bezel_repeat_delay_ms")
                LabelBezel_repeat_delay_ms.ForeColor = Color.Black
            Catch ex As Exception
                LabelBezel_repeat_delay_ms.ForeColor = Color.Green
            End Try

            Try
                CheckBoxShow_extended_messages.Checked = Int(dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("show_extended_messages"))
                CheckBoxShow_extended_messages.ForeColor = Color.Black
            Catch ex As Exception
                CheckBoxShow_extended_messages.ForeColor = Color.Green
            End Try

            file.Close()

            TabControlTemp.TabPages.Insert(tabSelezionata, TabControlProprietà.TabPages(0))

            For Each elemento As String In campiDisabilitati
                Try
                    Dim usoTab As String = "TabPage" & elemento.Substring(0, elemento.IndexOf("_"))
                    Dim usoLabel As Label = TabControlTemp.TabPages(usoTab).Controls.Item("Label" & elemento)
                    usoLabel.ForeColor = Color.Green
                Catch ex As Exception

                End Try
            Next

            TabControlProprietà.TabPages.Add(TabControlTemp.TabPages(tabSelezionata))

            PanelMainMaster.Visible = True

            MsgBox("File layout.ini caricato!")
        Else
            MsgBox("Attenzione! verifica file layout.ini e percorso!")
        End If
    End Sub

    Private Sub ButtonPubblica_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonPubblica.MouseDown
        If e.X >= 58 Then
            ComboBoxPubblica.DroppedDown = Not ComboBoxPubblica.DroppedDown
        End If
    End Sub

    Private Sub ButtonPubblica_Click(sender As Object, e As EventArgs) Handles ButtonPubblica.Click,
                                                                                ComboBoxPubblica.SelectedIndexChanged,
                                                                                SaveToolStripMenuItem.Click,
                                                                                SaveAsToolStripMenuItem.Click,
                                                                                ExportToolStripMenuItem.Click


        Dim file As System.IO.StreamWriter
        Dim cartella As String
        Dim cartella2 As String
        Dim folder As DirectoryInfo
        Dim condivisione As MsgBoxResult
        Dim precedenteRisoluzioneComboIndex As Integer = ComboBoxRisoluzione.SelectedIndex 'salva risoluzione attuale
        Dim x As Integer
        Dim y As Integer

        condivisione = MsgBox("Vuoi condividere il layout col sito di FEEL?", MsgBoxStyle.YesNo)

        FolderBrowserDialog1.SelectedPath = LabelPercorso.Text

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            cartella = FolderBrowserDialog1.SelectedPath

            If sender.name = "ComboBoxPubblica" Then 'esportazione ad una risoluzione diversa dalla selezionata

                ComboBoxRisoluzione.SelectedIndex = ComboBoxPubblica.SelectedIndex

                If CheckBoxScreen_verticale.Checked Then
                    x = Int(ComboBoxRisoluzione.SelectedValue.row.item(2))
                    y = Int(ComboBoxRisoluzione.SelectedValue.row.item(1))
                Else
                    x = Int(ComboBoxRisoluzione.SelectedValue.row.item(1))
                    y = Int(ComboBoxRisoluzione.SelectedValue.row.item(2))
                End If

                Dim dirTemp As String = cartella & x & "x" & y

                My.Computer.FileSystem.CopyDirectory(cartella, dirTemp)

                Dim dir As New DirectoryInfo(dirTemp)
                Dim filesTemp As FileInfo() = dir.GetFiles("*.png")

                For Each fileTemp As FileInfo In filesTemp
                    Dim image_source As Image = Image.FromFile(dirTemp & "\" & fileTemp.Name)
                    Dim image_dest As Image = ClassUtility.ResizeImage(image_source, CInt(x), CInt(y))

                    image_source.Dispose()
                    fileTemp.Delete()

                    image_dest.Save(dirTemp & "\" & fileTemp.Name)
                Next

                cartella = dirTemp
            End If

            LabelPercorso.Text = cartella
            LabelPercorso.Refresh()

            folder = My.Computer.FileSystem.GetDirectoryInfo(cartella)

            Dim indiceCartella2 As Integer = cartella.LastIndexOf("\")

            cartella2 = cartella.Substring(indiceCartella2 + 1)

            Try
                If My.Computer.FileSystem.FileExists(cartella & "\" & "layout.ini") Then
                    My.Computer.FileSystem.RenameFile(cartella & "\" & "layout.ini", "layout_" & Today.Year.ToString & Today.Month.ToString & Today.Day.ToString & Now.Hour.ToString & Now.Minute.ToString & Now.Second.ToString & ".ini")
                End If
            Catch ex As Exception
                My.Computer.FileSystem.DeleteFile(cartella & "\" & "layout.ini")
            End Try

            file = My.Computer.FileSystem.OpenTextFileWriter(cartella & "\" & "layout.ini", True)

            ValoriInTabella()

            file.WriteLine("####################################################################################################")
            file.WriteLine("#                                                                                                  #")
            file.WriteLine("# F.E.(E.L.) ® – FrontEnd (Emulator Launcher) - dR.pRoDiGy – ArcadeItalia.net                      #")
            file.WriteLine("#                                                                                                  #")
            file.WriteLine("# FeelEdit development: sincro                                                                     #")
            file.WriteLine("# layout design: adolfo69                                                                          #")
            file.WriteLine("# F.L.M. Feel Layout Manager development: Gothrek - gothrek@hotmail.com                            #")
            file.WriteLine("#                                                                                                  #")
            file.WriteLine("# homepage: http://www.arcadeitalia.net/viewtopic.php?f=19&t=8062                                  #")
            file.WriteLine("#                                                                                                  #")
            file.WriteLine("####################################################################################################")
            file.WriteLine("")

            TabControlTemp.TabPages.Insert(tabSelezionata, TabControlProprietà.TabPages(0))

            For Each dato As DataColumn In dtOptionsLayout.Columns
                Dim riga As String
                Dim usoTab As String = dato.ColumnName.Substring(0, dato.ColumnName.IndexOf("_"))

                Try
                    Dim oggettoColoreFont As Color = TabControlTemp.TabPages.Item("TabPage" & usoTab).Controls.Item("Label" & dato.ColumnName).ForeColor

                    riga = dato.ColumnName
                    If oggettoColoreFont = Color.Green Then
                        riga = "#" & riga
                    End If

                    For i As Integer = 1 To 40 - riga.Length
                        riga &= " "
                    Next

                    riga &= dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(dato.Caption)
                    file.WriteLine(riga)
                Catch ex As Exception

                End Try

                Try
                    Dim oggettoColoreFont As Color = TabControlTemp.TabPages.Item("TabPage" & usoTab).Controls.Item("CheckBox" & dato.ColumnName).ForeColor

                    riga = dato.ColumnName
                    If oggettoColoreFont = Color.Green Then
                        riga = "#" & riga
                    End If

                    For i As Integer = 1 To 40 - riga.Length
                        riga &= " "
                    Next

                    riga &= dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item(dato.Caption)
                    file.WriteLine(riga)
                Catch ex As Exception

                End Try

            Next

            file.Close()

            TabControlProprietà.TabPages.Add(TabControlTemp.TabPages(tabSelezionata))

            If condivisione = MsgBoxResult.Yes Then
                'TO DO pubblica sul sito in ftp
                Dim userFTP As String = "flm"
                Dim passwordFTP As String = "8XapaPYHxfCq"
                Dim hostFTP As String = "ftp://flm.altervista.org"
                Dim portaFTP As Integer = 21
                Dim fileZip As String = cartella2 & ".zip"

                cartella2 = cartella.Substring(0, indiceCartella2)
                'zip del layout
                ZipFile.CreateFromDirectory(cartella, cartella2 & "\" & fileZip)
                'pubblicazione dello zip

                ' set up request...
                Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(hostFTP & "/layouts/" & fileZip), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential(userFTP, passwordFTP)
                clsRequest.UsePassive = True
                clsRequest.KeepAlive = False
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...

                Dim bFile() As Byte = System.IO.File.ReadAllBytes(cartella2 & "\" & fileZip)

                ' upload file...
                Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                MsgBox("File condiviso correttamente!")
            Else
                MsgBox("File layout.ini scritto correttamente!")
            End If

            If sender.name = "ComboBoxPubblica" Then 'esportazione ad una risoluzione diversa da quella selezionata
                'TODO sender.text
                'ripristina vecchia risoluzione
                ComboBoxRisoluzione.SelectedIndex = precedenteRisoluzioneComboIndex
            End If

        End If
    End Sub

    Private Sub ValoriInTabella()

        dtOptionsLayout.Rows.Add()

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_list") = TextBoxSound_fx_list.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_menu") = TextBoxSound_fx_menu.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_confirm") = TextBoxSound_fx_confirm.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_cancel") = TextBoxSound_fx_cancel.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_startemu") = TextBoxSound_fx_startemu.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("sound_fx_volume") = TextBoxSound_fx_volume.Text

        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_path") = TextBoxMusic_path.Text
        dtOptionsLayout.Rows(dtOptionsLayout.Rows.Count - 1).Item("music_change_delay") = TextBoxMusic_change_delay.Text
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

    Private Sub ListBoxObj_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxObj.SelectedIndexChanged
        soundPlay = False
        musicPlay = False
        ButtonSoundPlay.Text = "Play"
        ButtonMusicPlay.Text = "Play"
        mp3player.Close()

        TabControlTemp.TabPages.Insert(tabSelezionata, TabControlProprietà.TabPages(0))
        tabSelezionata = ListBoxObj.SelectedIndex + 1
        TabControlProprietà.TabPages.Add(TabControlTemp.TabPages(tabSelezionata))

        Dim usoOggetto As String = ListBoxObj.SelectedItem
        Dim oggettoPanel As Object = PanelMain.Controls.Item("Panel" & usoOggetto)
        Dim usoComboBox As ComboBox = TabControlProprietà.TabPages(0).Controls("ComboBox" & usoOggetto & "_text_align")
        Dim usoTextBox As TextBox = TabControlProprietà.TabPages(0).Controls("TextBox" & usoOggetto & "_text_align")

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
            Try
                Select Case Int(usoTextBox.Text)
                    Case 0
                        usoComboBox.SelectedIndex = 0
                    Case 1
                        usoComboBox.SelectedIndex = 2
                    Case 2
                        usoComboBox.SelectedIndex = 1
                    Case Else
                        usoComboBox.SelectedIndex = 0
                End Select
                'usoComboBox.SelectedIndex = Int(usoTextBox.Text)
            Catch ex As Exception

            End Try
        Else
            For Each pannello As Control In PanelMain.Controls
                pannello.BackColor = Color.FromArgb(255, pannello.BackColor.R, pannello.BackColor.G, pannello.BackColor.B)
            Next
        End If
    End Sub

    Private Sub TrackBarZoom_ValueChanged(sender As Object, e As EventArgs) Handles TrackBarZoom.ValueChanged
        Try
            If sender.Value > TrackBarZoom.Maximum Then
                TrackBarZoom.Value = TrackBarZoom.Maximum
            End If
        Catch ex As Exception
            TrackBarZoom.Value = 100
        End Try

        AggiornaZoom(sender.value)
    End Sub

    Private Sub TextBoxZoom_TextChanged(sender As Object, e As EventArgs) Handles TextBoxZoom.TextChanged
        Try
            TrackBarZoom.Value = Int(sender.text)

            If TrackBarZoom.Value > TrackBarZoom.Maximum Then
                TrackBarZoom.Value = TrackBarZoom.Maximum
            End If
        Catch ex As Exception
            sender.text = "100"
            TrackBarZoom.Value = 100
        End Try

        AggiornaZoom(TrackBarZoom.Value)
    End Sub

    Private Sub AggiornaZoom(valore As Integer)
        If valore > TrackBarZoom.Maximum Then
            valore = TrackBarZoom.Maximum
        End If

        LabelZoom.Text = valore & "%"

        PanelMain.Size = New Size(Int(Val(TextBoxScreen_res_x.Text) * valore / 100), Int(Val(TextBoxScreen_res_y.Text) * valore / 100))
        For Each controllo As Object In PanelMain.Controls
            Dim usoTab As String = controllo.name.ToString.Substring(5)

            Try
                Dim oggettoTextBox_size_width As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_width")
                Dim oggettoTextBox_size_height As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_height")
                Dim oggettoTextBox_x_pos As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_x_pos")
                Dim oggettoTextBox_y_pos As Object = TabControlProprietà.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_y_pos")

                controllo.size = New Size(Int(Val(oggettoTextBox_size_width.text) * valore / 100), Int(Val(oggettoTextBox_size_height.text) * valore / 100))
                controllo.location = New Point(Int(Val(oggettoTextBox_x_pos.text) * valore / 100), Int(Val(oggettoTextBox_y_pos.text) * valore / 100))
            Catch ex As Exception
                Dim oggettoTextBox_size_width As Object = TabControlTemp.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_width")
                Dim oggettoTextBox_size_height As Object = TabControlTemp.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_height")
                Dim oggettoTextBox_x_pos As Object = TabControlTemp.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_x_pos")
                Dim oggettoTextBox_y_pos As Object = TabControlTemp.TabPages.Item("TabPage" & usoTab).Controls.Item("TextBox" & usoTab & "_y_pos")

                controllo.size = New Size(Int(Val(oggettoTextBox_size_width.text) * valore / 100), Int(Val(oggettoTextBox_size_height.text) * valore / 100))
                controllo.location = New Point(Int(Val(oggettoTextBox_x_pos.text) * valore / 100), Int(Val(oggettoTextBox_y_pos.text) * valore / 100))
            End Try
        Next

        PanelMain.Refresh()
        FormFLM_Resize()
    End Sub

    Private Sub TextBoxValoreCursore_TextChanged(sender As Object, e As EventArgs) Handles TextBoxValoreCursore.TextChanged
        Try
            If Int(sender.Text) < 1 Then
                sender.Text = 1
            End If
        Catch ex As Exception
            sender.Text = 1
            sender.Refresh()
        End Try

        Try
            If Int(sender.Text) > 10 Then
                sender.Text = 10
            End If
        Catch ex As Exception
            sender.Text = 10
            sender.Refresh()
        End Try
    End Sub

    Private Sub ButtonValoreCursoreSX_Click(sender As Object, e As EventArgs) Handles ButtonValoreCursoreSX.Click
        Try
            Dim valore As Integer = Int(TextBoxValoreCursore.Text)

            valore -= 1
            TextBoxValoreCursore.Text = valore
        Catch ex As Exception
            TextBoxValoreCursore.Text = 1
            TextBoxValoreCursore.Refresh()
        End Try
    End Sub

    Private Sub ButtonValoreCursoreDX_Click(sender As Object, e As EventArgs) Handles ButtonValoreCursoreDX.Click
        Try
            Dim valore As Integer = Int(TextBoxValoreCursore.Text)

            valore += 1
            TextBoxValoreCursore.Text = valore
        Catch ex As Exception
            TextBoxValoreCursore.Text = 10
            TextBoxValoreCursore.Refresh()
        End Try
    End Sub

    Private Sub LabelValoreCursore_MouseHover(sender As Object, e As EventArgs) Handles LabelValoreCursore.MouseHover,
                                                                                        TextBoxValoreCursore.MouseHover,
                                                                                        ButtonValoreCursoreSX.MouseHover,
                                                                                        ButtonValoreCursoreDX.MouseHover

        ToolTip1.Show("Regola il n.di pixel per lo spostamento con i cursori.", sender)
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
                                                                            PanelMenu.Paint

        Dim nCaratteri As Integer = sender.name.ToString.Length - 5
        Dim larghezza As Integer = sender.size.width
        Dim altezza As Integer = sender.size.height
        Dim grandezzaCaratteri As Integer = Int(larghezza / nCaratteri)
        Dim posizione As Integer = Int((sender.size.height - grandezzaCaratteri) / 2) - 1
        Dim nomepannello As String = sender.name

        If grandezzaCaratteri >= sender.size.height Then
            grandezzaCaratteri = sender.size.height
            posizione = -1
        End If


        Try
            If sender.backcolor.a = 50 Then
                e.Graphics.DrawString(sender.name.ToString.Substring(5), New Font("Arial", grandezzaCaratteri, FontStyle.Regular, GraphicsUnit.Pixel), New SolidBrush(Color.FromArgb(50, 255, 0, 0)), 0, posizione)
            Else
                e.Graphics.DrawString(sender.name.ToString.Substring(5), New Font("Arial", grandezzaCaratteri, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Red, 0, posizione)
            End If

            If sender.tag = 1 Then
                e.Graphics.DrawRectangle(New Pen(Color.Red, 2), sender.ClientRectangle)
            Else
                e.Graphics.DrawRectangle(New Pen(Color.Green, 2), sender.ClientRectangle)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelSnapshot.MouseMove,
                                                                                            PanelRomstatus.MouseMove,
                                                                                            PanelRomname.MouseMove,
                                                                                            PanelRommanufacturer.MouseMove,
                                                                                            PanelRomlist.MouseMove,
                                                                                            PanelRominputcontrol.MouseMove,
                                                                                            PanelRomdisplaytype.MouseMove,
                                                                                            PanelRomdescription.MouseMove,
                                                                                            PanelRomcounter.MouseMove,
                                                                                            PanelRomcategory.MouseMove,
                                                                                            PanelPlatformname.MouseMove,
                                                                                            PanelMenu.MouseMove,
                                                                                            PanelMarquee.MouseMove,
                                                                                            PanelGamelistname.MouseMove,
                                                                                            PanelEmulatorname.MouseMove,
                                                                                            PanelBackground.MouseMove,
                                                                                            PanelCabinet.MouseMove

        Dim delta As Integer = Int((Me.Size.Width / 2 - PanelMain.Size.Width) / 2)
        Dim x As Integer = MousePosition.X - PanelMainMaster.Location.X - Me.Location.X - 8 - delta '8 è il bordo
        Dim y As Integer = MousePosition.Y - PanelMainMaster.Location.Y - Me.Location.Y - 30 '30 è l'intestazione della form

        If (x >= 0) And (x <= PanelBackground.Size.Width) And (y >= 0) And (y <= PanelBackground.Size.Height) Then
            LabelPosizioneMouse.Text = Int(x / TrackBarZoom.Value * 100) & " , " & Int(y / TrackBarZoom.Value * 100)
        Else
            LabelPosizioneMouse.Text = "- , -"
        End If

        LabelPosizioneMouse.Location = New Point(PanelMainMaster.Location.X + PanelMainMaster.Width - LabelPosizioneMouse.Width - 23, PanelMainMaster.Location.Y + PanelMainMaster.Height + 3)

        If MouseButtons.HasFlag(MouseButtons.Left) And (sender.tag <> 1) Then
            x = Math.Round((x - sender.size.width / 2) / TrackBarZoom.Value * 100)
            y = Math.Round((y - sender.size.height / 2) / TrackBarZoom.Value * 100)

            LabelPannello.Text = "Pannello " & sender.name.ToString.Substring(5) & " " & x & " , " & y

            mouseCoordinate = MousePosition

            Dim usoOggetto As String = sender.name.ToString.Substring(5, sender.name.ToString.Length - 5)

            Dim oggettoX As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_x_pos")
            Dim oggettoY As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_y_pos")

            oggettoX.Text = x
            oggettoY.Text = y
        End If
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
                                                                            PanelCabinet.MouseHover

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
                                                                            PanelMenu.MouseEnter

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
                                                                            PanelMenu.MouseLeave,
                                                                            LabelValoreCursore.MouseLeave,
                                                                            TextBoxValoreCursore.MouseLeave,
                                                                            ButtonValoreCursoreSX.MouseLeave,
                                                                            ButtonValoreCursoreDX.MouseLeave

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
                                                                                PanelMenu.MouseDown

        Dim usoOggetto As String = sender.name.ToString.Substring(5, sender.name.ToString.Length - 5)

        ListBoxObj.SelectedItem = usoOggetto

        If e.Button = MouseButtons.Right Then
            TabControlProprietà.SelectedTab = TabControlProprietà.TabPages("TabPage" & usoOggetto)

            sender.tag = Math.Abs(Int(sender.tag) - 1)
            sender.refresh()
        Else
            tempoMouseClick = Now()

            TabControlProprietà.SelectedTab = TabControlProprietà.TabPages("TabPage" & usoOggetto)

            Dim x As Integer = Int(sender.size.width / 2 - e.X)
            Dim y As Integer = Int(sender.size.height / 2 - e.Y)

            mouseCoordinate = New Point(mouseCoordinate.X + x - 9, mouseCoordinate.Y + y - 1) '-9 e -1 aggiustano la posizione rispetto al cursore del mouse
            mouseDownX = MousePosition.X
            mouseDownY = MousePosition.Y

            pannello = sender
            Timer1.Start()
        End If
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
                                                                                PanelRomlist.MouseUp

        Dim usoOggetto As String = sender.name.ToString.Substring(5, sender.name.ToString.Length - 5)

        If e.Button = MouseButtons.Left Then
            If sender.tag <> 1 Then
                Dim dataDiff As TimeSpan = Now.Subtract(tempoMouseClick)
                Timer1.Stop()

                If ((dataDiff.TotalMilliseconds) > mouseTimeClick) And (mouseDownX <> MousePosition.X) And (mouseDownY <> MousePosition.Y) Then
                    ListBoxObj.SelectedItem = usoOggetto

                    Dim delta As Integer = Int((Me.Size.Width / 2 - PanelMain.Size.Width) / 2)
                    Dim x As Integer = MousePosition.X - PanelMainMaster.Location.X - Me.Location.X - 8 - delta '8 è il bordo
                    Dim y As Integer = MousePosition.Y - PanelMainMaster.Location.Y - Me.Location.Y - 30 '30 è l'intestazione della form

                    Try
                        Dim oggettoX As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_x_pos")
                        Dim oggettoY As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_y_pos")

                        oggettoX.Text = Math.Round((x - sender.size.width / 2) / TrackBarZoom.Value * 100)
                        oggettoY.Text = Math.Round((y - sender.size.height / 2) / TrackBarZoom.Value * 100)

                        sender.location = New Point(Int(Val(oggettoX.text) * TrackBarZoom.Value / 100), Int(Val(oggettoY.text) * TrackBarZoom.Value / 100))
                        sender.visible = True


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    sender.visible = True
                End If
            Else
                Timer1.Stop()
                sender.visible = True
                MsgBox("Il pannello è in lock! Per spostarlo col mouse devi prima sbloccarlo con bottone dx del mouse.")
            End If

            LabelPannello.Text = "Pannello " & sender.name.ToString.Substring(5) & " " & Int(sender.location.x * 100 / TrackBarZoom.Value) & " , " & Int(sender.location.y * 100 / TrackBarZoom.Value)
            sender.focus()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim bm As Bitmap = ClassUtility.GetControlImage(pannello)
        Dim ptrCur As IntPtr = bm.GetHicon
        Dim cur As Cursor

        cur = New Cursor(ptrCur)
        pannello.Visible = False

        Me.Cursor = cur
    End Sub

    Private Sub Panel_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles PanelSnapshot.PreviewKeyDown, PanelRomstatus.PreviewKeyDown, PanelRomname.PreviewKeyDown, PanelRommanufacturer.PreviewKeyDown, PanelRomlist.PreviewKeyDown, PanelRominputcontrol.PreviewKeyDown, PanelRomdisplaytype.PreviewKeyDown, PanelRomdescription.PreviewKeyDown, PanelRomcounter.PreviewKeyDown, PanelRomcategory.PreviewKeyDown, PanelPlatformname.PreviewKeyDown, PanelMenu.PreviewKeyDown, PanelMarquee.PreviewKeyDown, PanelGamelistname.PreviewKeyDown, PanelEmulatorname.PreviewKeyDown, PanelCabinet.PreviewKeyDown
        Dim valoreCursore As Integer = Int(TextBoxValoreCursore.Text)

        If sender.tag <> 1 Then
            Dim usoOggetto As String = sender.name.ToString.Substring(5, sender.name.ToString.Length - 5)

            Select Case e.KeyCode
                Case Keys.Right
                    Dim oggettoX As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_x_pos")

                    sender.location = New Point(sender.location.x + valoreCursore, sender.location.y)
                    oggettoX.Text = sender.location.X
                Case Keys.Left
                    Dim oggettoX As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_x_pos")

                    sender.location = New Point(sender.location.x - valoreCursore, sender.location.y)
                    oggettoX.Text = sender.location.X
                Case Keys.Up
                    Dim oggettoY As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_y_pos")

                    sender.location = New Point(sender.location.x, sender.location.y - valoreCursore)
                    oggettoY.Text = sender.location.Y
                Case Keys.Down
                    Dim oggettoY As Object = TabControlProprietà.TabPages.Item("TabPage" & usoOggetto).Controls.Item("TextBox" & usoOggetto & "_y_pos")

                    sender.location = New Point(sender.location.x, sender.location.y + valoreCursore)
                    oggettoY.Text = sender.location.Y
            End Select

            LabelPannello.Text = "Pannello " & sender.name.ToString.Substring(5) & " " & sender.location.x & " , " & sender.location.y
        Else
            MsgBox("Il pannello è in lock! Per spostarlo col mouse devi prima sbloccarlo con bottone dx del mouse.")
        End If
    End Sub

    Private Sub CheckBoxPanelVisibile_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSnapshot.CheckedChanged, CheckBoxRomstatus_visible.CheckedChanged, CheckBoxRomname_visible.CheckedChanged, CheckBoxRommanufacturer_visible.CheckedChanged, CheckBoxRomlistVisibile.CheckedChanged, CheckBoxRominputcontrol_visible.CheckedChanged, CheckBoxRomdisplaytype_visible.CheckedChanged, CheckBoxRomdescription_visible.CheckedChanged, CheckBoxRomcounter_visible.CheckedChanged, CheckBoxRomcategory_visible.CheckedChanged, CheckBoxPlatformname_visible.CheckedChanged, CheckBoxMenu.CheckedChanged, CheckBoxMarquee_visible.CheckedChanged, CheckBoxGamelistname_visible.CheckedChanged, CheckBoxEmulatorname_visible.CheckedChanged, CheckBoxCabinet_visible.CheckedChanged

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
                                                                        TextBoxBackground_y_pos.Enter, TextBoxBackground_x_pos.Enter, TextBoxMusic_change_delay.Enter

        valorePrecedente = sender.Text
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBoxBackground_frame_duration_ms.TextChanged,
                                                                                TextBoxBackground_repeat_delay_ms.TextChanged,
                                                                                TextBoxRomlist_item_height.TextChanged,
                                                                                TextBoxMenu_item_height.TextChanged,
                                                                                TextBoxActors_repeat_delay_ms.TextChanged, TextBoxActors_frame_duration_ms.TextChanged,
                                                                                TextBoxBezel_repeat_delay_ms.TextChanged, TextBoxBezel_frame_duration_ms.TextChanged, TextBoxMusic_change_delay.TextChanged

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

            oggettoPanel.Location = New Point(Int(Val(sender.text) * TrackBarZoom.Value / 100), oggettoPanel.Location.Y)

            If oggettoPanel.location.x < (-oggettoPanel.Size.Width) Then
                sender.backcolor = Color.Red
            Else
                If (oggettoPanel.location.x * TrackBarZoom.Value / 100) > PanelMain.Location.X + PanelMain.Size.Width Then
                    sender.backcolor = Color.Red

                Else
                    sender.BackColor = Color.Green
                End If
            End If
            oggettoPanel.Refresh()

            LabelPannello.Text = "Pannello " & oggettoPanel.name.ToString.Substring(5) & " " & Int(Val(sender.text)) & " , " & Int(oggettoPanel.location.y * 100 / TrackBarZoom.Value)
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

            oggettoPanel.Location = New Point(oggettoPanel.Location.x, Int(Val(sender.text) * TrackBarZoom.Value / 100))

            If oggettoPanel.location.y < (-oggettoPanel.Size.Height) Then
                sender.backcolor = Color.Red
            Else
                If (oggettoPanel.location.y * TrackBarZoom.Value / 100) > PanelMain.Location.Y + PanelMain.Size.Height Then
                    sender.backcolor = Color.Red
                Else
                    sender.BackColor = Color.Green
                End If
            End If
            oggettoPanel.Refresh()

            LabelPannello.Text = "Pannello " & oggettoPanel.name.ToString.Substring(5) & " " & Int(oggettoPanel.location.x * 100 / TrackBarZoom.Value) & " , " & Int(Val(sender.text))
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
        carattere.Dispose()

        oggettoLabel.Text = FontDialog1.Font.Style.ToString
        carattere = oggettoLabel.font
        carattere = New Font(carattere, FontDialog1.Font.Style)
        oggettoLabel.Font = carattere
        oggettoLabel.Refresh()
        carattere.Dispose()
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
            carattere.Dispose()

            oggettoLabel.Text = carattere.Style.ToString
            carattere = oggettoLabel.font
            carattere = New Font(carattere, carattereStile)
            oggettoLabel.Font = carattere
            oggettoLabel.Refresh()
            carattere.Dispose()

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

        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            Dim coloreA As Integer = 255
            Dim coloreR As Integer = colorDialog1.Color.R Xor 255
            Dim coloreG As Integer = colorDialog1.Color.G Xor 255
            Dim coloreB As Integer = colorDialog1.Color.B Xor 255

            sender.BackColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
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
                If coloreA = 0 Then
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
            sender.BackColor = Color.FromArgb(255, colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B)

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = ColorDialog1.Color.R Xor 255
            Dim coloreG As Integer = ColorDialog1.Color.G Xor 255
            Dim coloreB As Integer = ColorDialog1.Color.B Xor 255

            sender.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            sender.Text = coloreR & ", " & coloreG & ", " & coloreB & ", " & colorDialog1.Color.A
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
                If coloreA = 0 Then
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
                Dim oggettoPanel As Object = New Object
                oggettoPanel = PanelMain.Controls.Item("Panel" & usoOggetto)

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
        Dim usoTab As String = usoOggetto

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

    Private Sub Button_MouseHover(sender As Object, e As EventArgs) Handles ButtonCarica.MouseHover,
                                                                            ButtonPubblica.MouseHover,
                                                                            ButtonPainter.MouseHover,
                                                                            ButtonFLMOptions.MouseHover,
                                                                            ButtonAnteprima.MouseHover,
                                                                            ButtonAbout.MouseHover

        ToolTip1.Show(sender.name.ToString.Substring(6), sender)
    End Sub

    Private Sub Button_MouseLeave(sender As Object, e As EventArgs) Handles ButtonPubblica.MouseLeave,
                                                                            ButtonPainter.MouseLeave,
                                                                            ButtonFLMOptions.MouseLeave,
                                                                            ButtonAnteprima.MouseLeave,
                                                                            ButtonAbout.MouseLeave

        ToolTip1.Hide(sender)
    End Sub


    Private Sub Label_MouseDown(sender As Object, e As MouseEventArgs) Handles LabelSound_fx_list.MouseDown, LabelSound_fx_volume.MouseDown, LabelSound_fx_startemu.MouseDown, LabelSound_fx_menu.MouseDown, LabelSound_fx_confirm.MouseDown, LabelSound_fx_cancel.MouseDown,
                                                                                LabelMusic_volume.MouseDown, LabelMusic_path.MouseDown,
                                                                                LabelScreen_saver_font_color.MouseDown, LabelScreen_saver_backcolor.MouseDown, LabelScreen_res_y.MouseDown, LabelScreen_res_x.MouseDown,
                                                                                LabelRomlist_y_pos.MouseDown, LabelRomlist_x_pos.MouseDown, LabelRomlist_width.MouseDown, LabelRomlist_text_align.MouseDown, LabelRomlist_selected_font_color.MouseDown, LabelRomlist_selected_backcolor.MouseDown, LabelRomlist_item_height.MouseDown, LabelRomlist_height.MouseDown, LabelRomlist_font_style.MouseDown, LabelRomlist_font_size.MouseDown, LabelRomlist_font_name.MouseDown, LabelRomlist_font_color.MouseDown, LabelRomlist_backcolor.MouseDown, CheckBoxRomlist_disable_stars.MouseDown,
                                                                                LabelBackground_width.MouseDown, LabelBackground_repeat_delay_ms.MouseDown, CheckBoxBackground_ontop.MouseDown, LabelBackground_height.MouseDown, LabelBackground_frame_duration_ms.MouseDown,
                                                                                LabelSnapshot_y_pos.MouseDown, LabelSnapshot_x_pos.MouseDown, LabelSnapshot_width.MouseDown, LabelSnapshot_height.MouseDown, CheckBoxSnapshot_stretch.MouseDown, CheckBoxSnapshot_blackbackground.MouseDown,
                                                                                CheckBoxRomcounter_visible.MouseDown, LabelRomcounter_y_pos.MouseDown, LabelRomcounter_x_pos.MouseDown, LabelRomcounter_width.MouseDown, LabelRomcounter_text_align.MouseDown, LabelRomcounter_height.MouseDown, LabelRomcounter_font_style.MouseDown, LabelRomcounter_font_size.MouseDown, LabelRomcounter_font_name.MouseDown, LabelRomcounter_font_color.MouseDown, LabelRomcounter_backcolor.MouseDown,
                                                                                LabelMarquee_y_pos.MouseDown, LabelMarquee_x_pos.MouseDown, LabelMarquee_width.MouseDown, LabelMarquee_height.MouseDown, CheckBoxMarquee_visible.MouseDown, CheckBoxMarquee_stretch.MouseDown, CheckBoxMarquee_blackbackground.MouseDown,
                                                                                LabelCabinet_y_pos.MouseDown, LabelCabinet_x_pos.MouseDown, LabelCabinet_width.MouseDown, LabelCabinet_height.MouseDown, CheckBoxCabinet_visible.MouseDown, CheckBoxCabinet_stretch.MouseDown, CheckBoxCabinet_blackbackground.MouseDown,
                                                                                LabelPlatformname_y_pos.MouseDown, LabelPlatformname_x_pos.MouseDown, LabelPlatformname_width.MouseDown, LabelPlatformname_text_align.MouseDown, LabelPlatformname_height.MouseDown, LabelPlatformname_font_style.MouseDown, LabelPlatformname_font_size.MouseDown, LabelPlatformname_font_name.MouseDown, LabelPlatformname_font_color.MouseDown, LabelPlatformname_backcolor.MouseDown, CheckBoxPlatformname_visible.MouseDown,
                                                                                LabelEmulatorname_y_pos.MouseDown, LabelEmulatorname_x_pos.MouseDown, LabelEmulatorname_width.MouseDown, LabelEmulatorname_text_align.MouseDown, LabelEmulatorname_height.MouseDown, LabelEmulatorname_font_style.MouseDown, LabelEmulatorname_font_size.MouseDown, LabelEmulatorname_font_name.MouseDown, LabelEmulatorname_font_color.MouseDown, LabelEmulatorname_backcolor.MouseDown, CheckBoxEmulatorname_visible.MouseDown,
                                                                                LabelGamelistname_y_pos.MouseDown, LabelGamelistname_x_pos.MouseDown, LabelGamelistname_width.MouseDown, LabelGamelistname_text_align.MouseDown, LabelGamelistname_height.MouseDown, LabelGamelistname_font_style.MouseDown, LabelGamelistname_font_size.MouseDown, LabelGamelistname_font_name.MouseDown, LabelGamelistname_font_color.MouseDown, LabelGamelistname_backcolor.MouseDown, CheckBoxGamelistname_visible.MouseDown,
                                                                                LabelRomname_y_pos.MouseDown, LabelRomname_x_pos.MouseDown, LabelRomname_width.MouseDown, LabelRomname_text_align.MouseDown, LabelRomname_height.MouseDown, LabelRomname_font_style.MouseDown, LabelRomname_font_size.MouseDown, LabelRomname_font_name.MouseDown, LabelRomname_font_color.MouseDown, LabelRomname_backcolor.MouseDown, CheckBoxRomname_visible.MouseDown,
                                                                                LabelRomdescription_y_pos.MouseDown, LabelRomdescription_x_pos.MouseDown, LabelRomdescription_width.MouseDown, LabelRomdescription_text_align.MouseDown, LabelRomdescription_height.MouseDown, LabelRomdescription_font_style.MouseDown, LabelRomdescription_font_size.MouseDown, LabelRomdescription_font_name.MouseDown, LabelRomdescription_font_color.MouseDown, LabelRomdescription_backcolor.MouseDown, CheckBoxRomdescription_visible.MouseDown,
                                                                                LabelRommanufacturer_y_pos.MouseDown, LabelRommanufacturer_x_pos.MouseDown, LabelRommanufacturer_width.MouseDown, LabelRommanufacturer_text_align.MouseDown, LabelRommanufacturer_height.MouseDown, LabelRommanufacturer_font_style.MouseDown, LabelRommanufacturer_font_size.MouseDown, LabelRommanufacturer_font_name.MouseDown, LabelRommanufacturer_font_color.MouseDown, LabelRommanufacturer_backcolor.MouseDown, CheckBoxRommanufacturer_visible.MouseDown,
                                                                                LabelRomdisplaytype_y_pos.MouseDown, LabelRomdisplaytype_x_pos.MouseDown, LabelRomdisplaytype_width.MouseDown, LabelRomdisplaytype_text_align.MouseDown, LabelRomdisplaytype_height.MouseDown, LabelRomdisplaytype_font_style.MouseDown, LabelRomdisplaytype_font_size.MouseDown, LabelRomdisplaytype_font_name.MouseDown, LabelRomdisplaytype_font_color.MouseDown, LabelRomdisplaytype_backcolor.MouseDown, CheckBoxRomdisplaytype_visible.MouseDown,
                                                                                LabelRomstatus_y_pos.MouseDown, LabelRomstatus_x_pos.MouseDown, LabelRomstatus_width.MouseDown, LabelRomstatus_text_align.MouseDown, LabelRomstatus_height.MouseDown, LabelRomstatus_font_style.MouseDown, LabelRomstatus_font_size.MouseDown, LabelRomstatus_font_name.MouseDown, LabelRomstatus_font_color.MouseDown, LabelRomstatus_backcolor.MouseDown, CheckBoxRomstatus_visible.MouseDown,
                                                                                LabelRominputcontrol_y_pos.MouseDown, LabelRominputcontrol_x_pos.MouseDown, LabelRominputcontrol_width.MouseDown, LabelRominputcontrol_text_align.MouseDown, LabelRominputcontrol_height.MouseDown, LabelRominputcontrol_font_style.MouseDown, LabelRominputcontrol_font_size.MouseDown, LabelRominputcontrol_font_name.MouseDown, LabelRominputcontrol_font_color.MouseDown, LabelRominputcontrol_backcolor.MouseDown, CheckBoxRominputcontrol_visible.MouseDown,
                                                                                LabelRomcategory_y_pos.MouseDown, LabelRomcategory_x_pos.MouseDown, LabelRomcategory_width.MouseDown, LabelRomcategory_text_align.MouseDown, LabelRomcategory_height.MouseDown, LabelRomcategory_font_style.MouseDown, LabelRomcategory_font_size.MouseDown, LabelRomcategory_font_name.MouseDown, LabelRomcategory_font_color.MouseDown, LabelRomcategory_backcolor.MouseDown, CheckBoxRomcategory_visible.MouseDown,
                                                                                LabelMenu_width.MouseDown, LabelMenu_selected_font_color.MouseDown, LabelMenu_selected_backcolor.MouseDown, LabelMenu_item_height.MouseDown, LabelMenu_font_style.MouseDown, LabelMenu_font_size.MouseDown, LabelMenu_font_name.MouseDown, LabelMenu_font_color.MouseDown, LabelMenu_backcolor.MouseDown, CheckBoxMenu_show_sidebar.MouseDown,
                                                                                LabelActors_repeat_delay_ms.MouseDown, LabelActors_frame_duration_ms.MouseDown,
                                                                                LabelBezel_repeat_delay_ms.MouseDown, LabelBezel_frame_duration_ms.MouseDown,
                                                                                CheckBoxShow_extended_messages.MouseDown

        If e.Button = MouseButtons.Right Then

            If sender.forecolor = Color.Green Then
                sender.forecolor = Color.Black
            Else
                sender.forecolor = Color.Green
            End If
        End If
    End Sub

    Private Sub ComboBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxRomstatus_text_align.KeyDown, ComboBoxRomname_text_align.KeyDown, ComboBoxRommanufacturer_text_align.KeyDown, ComboBoxRomlist_text_align.KeyDown, ComboBoxRominputcontrol_text_align.KeyDown, ComboBoxRomdisplaytype_text_align.KeyDown, ComboBoxRomdescription_text_align.KeyDown, ComboBoxRomcounter_text_align.KeyDown, ComboBoxRomcategory_text_align.KeyDown, ComboBoxRisoluzione.KeyDown, ComboBoxPlatformname_text_align.KeyDown, ComboBoxGamelistname_text_align.KeyDown, ComboBoxEmulatorname_text_align.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBoxRomText_align_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxRomstatus_text_align.SelectedIndexChanged, ComboBoxRomname_text_align.SelectedIndexChanged, ComboBoxRommanufacturer_text_align.SelectedIndexChanged, ComboBoxRomlist_text_align.SelectedIndexChanged, ComboBoxRominputcontrol_text_align.SelectedIndexChanged, ComboBoxRomdisplaytype_text_align.SelectedIndexChanged, ComboBoxRomdescription_text_align.SelectedIndexChanged, ComboBoxRomcounter_text_align.SelectedIndexChanged, ComboBoxRomcategory_text_align.SelectedIndexChanged, ComboBoxPlatformname_text_align.SelectedIndexChanged, ComboBoxGamelistname_text_align.SelectedIndexChanged, ComboBoxEmulatorname_text_align.SelectedIndexChanged
        Dim textAlign As Integer = sender.selectedindex
        Dim usoOggetto As String = sender.name.ToString.Substring(8)
        Dim oggettoTextBox As Object = TabControlProprietà.TabPages.Item(sender.parent.name).Controls.Item("TextBox" & usoOggetto)

        oggettoTextBox.Text = textAlign

        'Select Case textAlign
        '    Case 0
        '        oggettoTextBox.Text = 0
        '    Case 1
        '        oggettoTextBox.Text = 2
        '    Case 2
        '        oggettoTextBox.Text = 1
        '    Case Else
        '        oggettoTextBox.Text = 0
        'End Select
        'oggettoTextBox.Text = textAlign

        Try
            Select Case textAlign
                Case 0
                    oggettoTextBox.TextAlign = 0
                Case 1
                    oggettoTextBox.TextAlign = 2
                Case 2
                    oggettoTextBox.TextAlign = 1
                Case Else
                    oggettoTextBox.TextAlign = 0
            End Select
            'oggettoTextBox.TextAlign = textAlign ' Int(sender.selecteditem.substring(sender.selecteditem.length - 1, 1))
        Catch ex As Exception

        End Try
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Sound
    Private Sub TextBoxSound_fx_list_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_list.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_list.Text = OpenFileDialog1.SafeFileName
    End Sub

    Private Sub TextBoxSound_fx_menu_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_menu.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_menu.Text = OpenFileDialog1.SafeFileName
    End Sub

    Private Sub TextBoxSound_fx_confirm_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_confirm.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_confirm.Text = OpenFileDialog1.SafeFileName
    End Sub

    Private Sub TextBoxSound_fx_cancel_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_cancel.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_cancel.Text = OpenFileDialog1.SafeFileName
    End Sub

    Private Sub TextBoxSound_fx_startemu_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxSound_fx_startemu.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.wav)|*.wav"
        OpenFileDialog1.InitialDirectory = LabelSoundPath2.Text
        OpenFileDialog1.ShowDialog()
        TextBoxSound_fx_startemu.Text = OpenFileDialog1.SafeFileName
    End Sub

    Private Sub TextBoxSound_fx_volume_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSound_fx_volume.TextChanged
        Try
            If (Int(TextBoxSound_fx_volume.Text) >= 0) And (Int(TextBoxSound_fx_volume.Text) <= 100) Then
            Else
                TextBoxSound_fx_volume.Text = valorePrecedente
            End If
        Catch ex As Exception
            TextBoxSound_fx_volume.Text = valorePrecedente
        End Try
    End Sub

    Private Sub ButtonSoundPath_Click(sender As Object, e As EventArgs) Handles ButtonSoundPath.Click
        FolderBrowserDialog1.ShowDialog()
    End Sub

    Private Sub ButtonSoundPlay_Click(sender As Object, e As EventArgs) Handles ButtonSoundPlay.Click
        soundPlay = Not soundPlay
        mp3player.Looping = CheckBoxSoundLoop.Checked

        If soundPlay Then
            Try
                mp3player.VolumeAll = Int(TextBoxSound_fx_volume.Text)
                mp3player.Open(feelPath & "\media\" & ListBoxSound.SelectedItem)
                mp3player.Play()

                If Not CheckBoxSoundLoop.Checked Then
                    TimerMP3.Interval = mp3player.AudioLength
                    TimerMP3.Start()
                End If

                ButtonSoundPlay.Text = "Pause"
            Catch ex As Exception

            End Try
        Else
            ButtonSoundPlay.Text = "Play"
            mp3player.Close()
        End If
    End Sub

    Private Sub ListBoxSound_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxSound.SelectedIndexChanged,
                                                                                            CheckBoxSoundLoop.CheckedChanged

        ButtonSoundPlay.Text = "Play"
        soundPlay = False
        mp3player.Close()
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Music
    Private Sub TextBoxMusicPath_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxMusic_path.DoubleClick
        OpenFileDialog1.Filter = "File audio (*.mp3)|*.mp3"
        OpenFileDialog1.InitialDirectory = LabelMusic_path.Text
        OpenFileDialog1.ShowDialog()
        TextBoxMusic_path.Text = OpenFileDialog1.SafeFileName
    End Sub

    Private Sub TextBoxMusic_volume_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMusic_volume.TextChanged
        Try
            If (Int(TextBoxMusic_volume.Text) >= 0) And (Int(TextBoxMusic_volume.Text) <= 100) Then
            Else
                TextBoxMusic_volume.Text = valorePrecedente
            End If
        Catch ex As Exception
            TextBoxMusic_volume.Text = valorePrecedente
        End Try
    End Sub

    Private Sub ButtonMusic_path_Click(sender As Object, e As EventArgs) Handles ButtonMusic_path.Click
        FolderBrowserDialog1.ShowDialog()
    End Sub

    Private Sub ButtonMusicPlay_Click(sender As Object, e As EventArgs) Handles ButtonMusicPlay.Click
        musicPlay = Not musicPlay
        mp3player.Looping = CheckBoxMusicLoop.Checked

        If musicPlay Then
            mp3player.VolumeAll = Int(TextBoxMusic_volume.Text)
            mp3player.Open(feelPath & "\media\" & TextBoxMusic_path.Text)
            mp3player.Play()

            If Not CheckBoxMusicLoop.Checked Then
                TimerMP3.Interval = mp3player.AudioLength
                TimerMP3.Start()
            End If

            ButtonMusicPlay.Text = "Pause"
        Else
            ButtonMusicPlay.Text = "Play"
            mp3player.Close()
        End If
    End Sub

    Private Sub CheckBoxMusicLoop_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMusicLoop.CheckedChanged
        ButtonMusicPlay.Text = "Play"
        musicPlay = False
        mp3player.Close()
    End Sub

    Private Sub TimerMP3_Tick(sender As Object, e As EventArgs) Handles TimerMP3.Tick
        ButtonSoundPlay.Text = "Play"
        soundPlay = False
        ButtonMusicPlay.Text = "Play"
        musicPlay = False
        mp3player.Close()
        TimerMP3.Stop()
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà screen
    Private Sub PanelMain_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelMain.MouseUp
        pannelloMainLocation = New Point(PanelMain.Location.X + (MousePosition.X - mouseCoordinate.X), PanelMain.Location.Y + (MousePosition.Y) - mouseCoordinate.Y)

        PanelMain.Location = pannelloMainLocation

        LabelPannello.Text = "Pannello main X: " & pannelloMainLocation.X

        LabelPannelloMainY.Text = "Pannello main Y: " & pannelloMainLocation.Y
    End Sub

    Private Sub ButtonPannelloMainReset_Click(sender As Object, e As EventArgs) Handles ButtonPannelloMainReset.Click
        PanelMain.Location = New Point(0, 0)

        LabelPannello.Text = "Pannello main X: " & PanelMain.Location.X

        LabelPannelloMainY.Text = "Pannello main Y: " & PanelMain.Location.Y
    End Sub

    Private Sub ComboBoxRisoluzione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxRisoluzione.SelectedIndexChanged,
                                                                                                    CheckBoxScreen_verticale.CheckedChanged

        If CheckBoxScreen_verticale.Checked Then
            TextBoxScreen_res_x.Text = ComboBoxRisoluzione.SelectedItem.row.item(2)
            TextBoxScreen_res_y.Text = ComboBoxRisoluzione.SelectedItem.row.item(1)
        Else
            TextBoxScreen_res_x.Text = ComboBoxRisoluzione.SelectedItem.row.item(1)
            TextBoxScreen_res_y.Text = ComboBoxRisoluzione.SelectedItem.row.item(2)
        End If

        TextBoxBackground_width.Text = TextBoxScreen_res_x.Text
        TextBoxBackground_height.Text = TextBoxScreen_res_y.Text

        LabelScreenRisoluzione.Text = "Main " & TextBoxScreen_res_x.Text & " x " & TextBoxScreen_res_y.Text

        Try
            PanelMain.Size = New Size(Int(TextBoxScreen_res_x.Text), Int(TextBoxScreen_res_y.Text))

            TrackBarZoom.Maximum = Int(PanelMainMaster.Size.Width / Int(TextBoxScreen_res_x.Text) * 100)

            If Int(PanelMainMaster.Size.Height / Int(TextBoxScreen_res_y.Text) * 100) < TrackBarZoom.Maximum Then
                TrackBarZoom.Maximum = Int(PanelMainMaster.Size.Height / Int(TextBoxScreen_res_y.Text) * 100)
            End If

            TextBoxZoom.Text = TrackBarZoom.Maximum
            TrackBarZoom.Value = TrackBarZoom.Maximum

            AggiornaZoom(TrackBarZoom.Value)
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
            Else
                TextBoxScreen_res_x.BackColor = Color.Red
            End If
        Catch ex As Exception

        End Try

        Try
            Int(TextBoxScreen_res_x.Text)
        Catch ex As Exception
            TextBoxScreen_res_x.Text = ComboBoxRisoluzione.SelectedItem.row.item(1)
        End Try

        LabelScreenRisoluzione.Text = "Main " & TextBoxScreen_res_x.Text & " x " & TextBoxScreen_res_y.Text

        Try
            PanelMain.Size = New Size(Int(TextBoxScreen_res_x.Text), Int(TextBoxScreen_res_y.Text))
        Catch ex As Exception

        End Try

        TextBoxBackground_width.Text = TextBoxScreen_res_x.Text
        FormFLM_Resize()
    End Sub

    Private Sub TextBoxScreen_res_y_TextChanged(sender As Object, e As EventArgs) Handles TextBoxScreen_res_y.TextChanged
        Dim i As Integer = 0
        Dim esci As Boolean = False

        If dtRisoluzioni.Rows.Count > 0 Then
            Try
                Do
                    If TextBoxScreen_res_y.Text = dtRisoluzioni.Rows(i).Item("y") Then
                        esci = True
                    End If

                    i += 1

                Loop Until esci Or (i = dtRisoluzioni.Rows.Count)

                If esci Then
                    TextBoxScreen_res_x.BackColor = Color.Green
                Else
                    TextBoxScreen_res_y.BackColor = Color.Red
                End If

            Catch ex As Exception

            End Try

            Try
                Int(TextBoxScreen_res_y.Text)
            Catch ex As Exception
                TextBoxScreen_res_y.Text = ComboBoxRisoluzione.SelectedItem.row.item(2)
            End Try

            LabelScreenRisoluzione.Text = "Main " & TextBoxScreen_res_x.Text & " x " & TextBoxScreen_res_y.Text

            Try
                PanelMain.Size = New Size(Int(TextBoxScreen_res_x.Text), Int(TextBoxScreen_res_y.Text))
            Catch ex As Exception

            End Try

            TextBoxBackground_height.Text = TextBoxScreen_res_y.Text
            FormFLM_Resize()
        End If
    End Sub

    Private Sub TextBoxScreen_saver_backcolor_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxScreen_saver_backcolor.DoubleClick, TextBoxScreen_saver_backcolor.Click
        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            TextBoxScreen_saver_backcolor.BackColor = Color.FromArgb(255, colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B)

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = colorDialog1.Color.R Xor 255
            Dim coloreG As Integer = colorDialog1.Color.G Xor 255
            Dim coloreB As Integer = colorDialog1.Color.B Xor 255

            TextBoxScreen_saver_backcolor.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            TextBoxScreen_saver_backcolor.Text = coloreR & ", " & coloreG & ", " & coloreB & ", " & coloreA
        End If
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà RomList
    Private Sub TextBoxRomlist_selected_backcolor_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxRomlist_selected_backcolor.DoubleClick, TextBoxRomlist_selected_backcolor.Click
        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            TextBoxRomlist_selected_backcolor.BackColor = Color.FromArgb(255, colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B)

            Dim coloreA As Integer = 255
            Dim coloreR As Integer = colorDialog1.Color.R Xor 255
            Dim coloreG As Integer = colorDialog1.Color.G Xor 255
            Dim coloreB As Integer = colorDialog1.Color.B Xor 255

            TextBoxRomlist_selected_backcolor.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            TextBoxRomlist_selected_backcolor.Text = coloreR & ", " & coloreG & ", " & coloreB & ", " & coloreA
        End If
    End Sub

    '----------------------------------------------------------------------------------------------
    'Proprietà Background
    Private Sub PanelBackground_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelBackground.MouseUp
        TabControlProprietà.SelectedTab = TabControlProprietà.TabPages("TabPageBackground")
    End Sub

    Private Sub CheckBoxBackgroundImage_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBackgroundImage.CheckedChanged
        If CheckBoxBackgroundImage.Checked Then
            Try
                Dim bm As Bitmap

                bm = ClassUtility.ChangeOpacity(Image.FromFile(LabelPercorso.Text & "\main.png"), 0.3)

                PanelBackground.BackgroundImage = bm
            Catch ex As Exception

            End Try
        Else
            PanelBackground.BackgroundImage = Nothing
        End If
    End Sub

    Private Sub TrackBarPanelBackgroundImage_Scroll(sender As Object, e As EventArgs) Handles TrackBarPanelBackgroundImage.Scroll
        If CheckBoxBackgroundImage.Checked Then
            Try
                Dim bm As Bitmap

                bm = ClassUtility.ChangeOpacity(Image.FromFile(LabelPercorso.Text & "\main.png"), sender.value / 100)

                PanelBackground.BackgroundImage = bm
            Catch ex As Exception

            End Try
        Else
            PanelBackground.BackgroundImage = Nothing
        End If
    End Sub

    Private Sub ButtonBackgroundPath_Click(sender As Object, e As EventArgs) Handles ButtonBackgroundPath.Click
        Dim cartella As String ' = ""

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            cartella = FolderBrowserDialog1.SelectedPath
            LabelBackgroundPath2.Text = cartella
        End If
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
        If (colorDialog1.ShowDialog() = DialogResult.OK) Then
            TextBoxMenu_selected_backcolor.BackColor = Color.FromArgb(255, colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B)

            Dim coloreA As Integer = 0
            Dim coloreR As Integer = colorDialog1.Color.R Xor 255
            Dim coloreG As Integer = colorDialog1.Color.G Xor 255
            Dim coloreB As Integer = colorDialog1.Color.B Xor 255

            TextBoxMenu_selected_backcolor.ForeColor = Color.FromArgb(coloreA, coloreR, coloreG, coloreB)
            TextBoxMenu_selected_backcolor.Text = coloreR & ", " & coloreG & ", " & coloreB & ", " & coloreA
        End If
    End Sub


    '----------------------------------------------------------------------------------------------
    'Proprietà Actors

    '----------------------------------------------------------------------------------------------
    'Proprietà Bezel

    '----------------------------------------------------------------------------------------------
    'Proprietà Show

End Class