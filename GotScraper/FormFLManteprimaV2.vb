Public Class FormFLManteprimaV2
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

    Private Sub FormFLManteprimaV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
    End Sub
End Class