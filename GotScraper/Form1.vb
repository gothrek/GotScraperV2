Imports System.Net
Imports System.Xml

Public Class Form1
    Public fileGamelist As String = "gamelist.xml"
    Public percorsoServerMedia As String = "D:\Personale\ROMS\media\" 'eventuale server locale di tutti i media
    Public percorsoMediaImages As String = "\media\images\"
    Public percorsoMediaVideos As String = "\media\videos\"
    Public percorsoMediaTitles As String = "\media\titles\"
    Public percorsoMediaMarquees As String = "\media\marquees\"
    Public percorsoMediaCabinets As String = "\media\cabinets\"
    Public percorsoMediaFlyers As String = "\media\flyers\"

    Private ReadOnly dt As DataTable = New DataTable("Elenco")

    Public Function CercaArcadeDatabase(ByVal sFileName As String) As String
        Dim strReq As String ' = "" 'Testo della richiesta/query
        Dim strData As String ' = "" 'Testo recuperato dalla richiesta
        Dim dataStream As Stream
        Dim reader As StreamReader
        Dim request As WebRequest
        Dim response As WebResponse

        Dim query As String = "query_mame&game_name="
        Dim lingua As String = "it"

        If RadioButton2.Checked Then
            lingua = "en"
        End If

        strReq = "http://adb.arcadeitalia.net/service_scraper.php?ajax=" & query & sFileName & "&lang=" & lingua
        'strReq = "http://www.progettoemma.net/index.php?gioco=4dwarrio"
        request = WebRequest.Create(strReq)
        'request.UseDefaultCredentials = True

        Dim proxy As WebProxy = New WebProxy() '= request.Proxy
        'Dim proxyAddress As String = "proxy01.cef-farma.lan:3128"

        Try
            response = request.GetResponse()
        Catch ex As Exception
            'TODO gestire il proxy
            'Dim newUri As Uri = New Uri(proxyAddress)

            'proxy.Address = newUri
            'proxy.Credentials = New NetworkCredential("RMPELLUC01", "N4tanN3ver", "Cef-farma.lan")
            'proxy.UseDefaultCredentials = True

            'request.Proxy = proxy
            MsgBox("La connessione richiede l'uso di un proxy!!")
            response = request.GetResponse()
        End Try

        dataStream = response.GetResponseStream()
        reader = New StreamReader(dataStream)
        strData = reader.ReadToEnd()

        If strData.Length > 25 Then 'TODO sostituire con un controllo di result null
            CercaArcadeDatabase = strData
        Else
            CercaArcadeDatabase = ""
        End If

        reader.Close()
        response.Close()
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CreaFileDemoXML(fileGamelist)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cartella As String ' = ""

        FolderBrowserDialog1.ShowDialog()
        cartella = FolderBrowserDialog1.SelectedPath
        Label1.Text = cartella

        fileGamelist = cartella & "\" & fileGamelist

        If Directory.Exists(cartella & percorsoMediaImages) Then
            'TODO dalle opzioni decidere cosa fare di una cartella preesistente
        Else

            Try
                System.IO.Directory.CreateDirectory(cartella & percorsoMediaImages)
            Catch ex As Exception
                'la cartella già esiste
            End Try

        End If

        If Directory.Exists(cartella & percorsoMediaVideos) Then
            'TODO dalle opzioni decidere cosa fare di una cartella preesistente
        Else

            Try
                System.IO.Directory.CreateDirectory(cartella & percorsoMediaVideos)
            Catch ex As Exception
                'la cartella già esiste
            End Try

        End If

        If Directory.Exists(cartella & percorsoMediaTitles) Then
            'TODO dalle opzioni decidere cosa fare di una cartella preesistente
        Else

            Try
                System.IO.Directory.CreateDirectory(cartella & percorsoMediaTitles)
            Catch ex As Exception
                'la cartella già esiste
            End Try

        End If

        If Directory.Exists(cartella & percorsoMediaMarquees) Then
            'TODO dalle opzioni decidere cosa fare di una cartella preesistente
        Else

            Try
                System.IO.Directory.CreateDirectory(cartella & percorsoMediaMarquees)
            Catch ex As Exception
                'la cartella già esiste
            End Try

        End If

        If Directory.Exists(cartella & percorsoMediaCabinets) Then
            'TODO dalle opzioni decidere cosa fare di una cartella preesistente
        Else

            Try
                System.IO.Directory.CreateDirectory(cartella & percorsoMediaCabinets)
            Catch ex As Exception
                'la cartella già esiste
            End Try

        End If

        If Directory.Exists(cartella & percorsoMediaFlyers) Then
            'TODO dalle opzioni decidere cosa fare di una cartella preesistente
        Else

            Try
                System.IO.Directory.CreateDirectory(cartella & percorsoMediaFlyers)
            Catch ex As Exception
                'la cartella già esiste
            End Try

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fileName As String = "log.txt"
        Dim fileNameFalliti As String = "logFalliti.txt"

        Dim swFile As StreamWriter
        Dim swFileFalliti As StreamWriter
        Dim fs As FileStream ' = Nothing
        Dim fsFalliti As FileStream ' = Nothing

        Dim game As String ' = ""
        Dim info As String ' = ""

        Dim crc32 As String ' = ""
        Dim utility As New ClassUtility()

        Dim contatore As Integer = 0
        Dim contatoreScartati As Integer = 0

        If File.Exists(fileName) = True Then 'se esite un file di log lo cancelliamo
            File.Delete(fileName)
        End If

        If File.Exists(fileNameFalliti) = True Then 'se esite un file di log lo cancelliamo
            File.Delete(fileNameFalliti)
        End If

        fs = File.Create(fileName)
        fs.Close()
        swFile = File.AppendText(fileName)

        fsFalliti = File.Create(fileNameFalliti)
        fsFalliti.Close()
        swFileFalliti = File.AppendText(fileNameFalliti)

        Dim inizio As DateTime = Now

        For Each file As String In Directory.GetFiles(Label1.Text)

            game = file.Substring(Label1.Text.Length + 1, file.Length - Label1.Text.Length - 5)
            Label2.Text = game

            info = CercaArcadeDatabase(game)
            Try
                If info <> "" Then 'info.Chars(11) <> "]" Then
                    crc32 = utility.GetCRC32(file)

                    swFile.WriteLine(info)
                    contatore += 1
                Else
                    game = file.Substring(Label1.Text.Length + 1, file.Length - Label1.Text.Length - 1)
                    crc32 = utility.GetCRC32(file)
                    swFileFalliti.WriteLine(game & crc32 & " - Fallito")
                    contatoreScartati += 1
                End If
            Catch ex As Exception
                'TODO non un file game
            End Try

        Next

        Dim fine As DateTime = Now

        swFile.Close()
        swFileFalliti.Close()

        MsgBox("Scansione terminata! Elementi individuati:" & contatore & " in " & fine.Subtract(inizio).Hours & " ore " & fine.Subtract(inizio).Minutes & " minuti " & fine.Subtract(inizio).Seconds & " secondi.")

    End Sub

    Private Sub InserisciDati(ByVal valori As Dictionary(Of String, String), ByVal sito As String)

        Dim client As New WebClient

        Dim riga As Integer

        dt.Rows.Add()

        riga = dt.Rows.Count - 1

        Try 'ID - identificativo del game dello scraper utilizzato
            dt.Rows(riga).Item("ID") = valori("ID")
        Catch ex As Exception
            dt.Rows(riga).Item("ID") = 0
        End Try

        Try 'URL - pagina web specifica del game
            dt.Rows(riga).Item("URL") = valori("url")
        Catch ex As Exception
            dt.Rows(riga).Item("URL") = ""
        End Try

        Try 'game_name - nome del file game
            dt.Rows(riga).Item("Game") = valori("game_name")
        Catch ex As Exception
            dt.Rows(riga).Item("Game") = ""
        End Try

        Try 'source - sito utilizzato per lo scraper
            dt.Rows(riga).Item("Source") = sito
        Catch ex As Exception
            dt.Rows(riga).Item("Source") = ""
        End Try

        Try 'path - posizione del file .\game_name
            dt.Rows(riga).Item("Path") = ".\" & valori("game_name") & ".zip" 'TODO sostituire la stringa .zip con quella specifica del sistema
        Catch ex As Exception
            dt.Rows(riga).Item("path") = ""
        End Try

        Try 'name - titolo del game
            dt.Rows(riga).Item("Name") = valori("title")
        Catch ex As Exception
            dt.Rows(riga).Item("Name") = ""
        End Try

        Try 'CloneOf - nome del gioco parent
            dt.Rows(riga).Item("CloneOf") = valori("cloneof")
        Catch ex As Exception
            dt.Rows(riga).Item("CloneOf") = ""
        End Try

        Try 'Desc - descrizione del game
            dt.Rows(riga).Item("Desc") = valori("history")
        Catch ex As Exception
            dt.Rows(riga).Item("Desc") = ""
        End Try

        Try 'Rating - voto
            dt.Rows(riga).Item("Rating") = valori("rate")
        Catch ex As Exception
            dt.Rows(riga).Item("Rating") = 0
        End Try

        Try 'ReleaseDate - anno/data di rilascio
            dt.Rows(riga).Item("ReleaseDate") = valori("year")
        Catch ex As Exception
            dt.Rows(riga).Item("ReleaseDate") = ""
        End Try

        Try 'Developer - sviluppatore (prima parte del campo manufactured)
            dt.Rows(riga).Item("Developer") = valori("manufacturer").Substring(0, valori("manufacturer").IndexOf("/"))
        Catch ex As Exception
            dt.Rows(riga).Item("Developer") = ""
        End Try

        Try 'Publisher - distributore (seconda parte del campo manufacturer)
            dt.Rows(riga).Item("Publisher") = valori("manufacturer").Substring(valori("manufacturer").IndexOf("/") + 1)
        Catch ex As Exception
            dt.Rows(riga).Item("Publisher") = ""
        End Try

        Try 'Genre - genere
            dt.Rows(riga).Item("Genre") = valori("genre")
        Catch ex As Exception
            dt.Rows(riga).Item("Genre") = ""
        End Try

        Try 'Players - numero di giocatori
            dt.Rows(riga).Item("Players") = valori("players")
        Catch ex As Exception
            dt.Rows(riga).Item("Players") = 0
        End Try

        Try 'Region - regione del game
            dt.Rows(riga).Item("Region") = valori("region")
        Catch ex As Exception
            dt.Rows(riga).Item("Region") = ""
        End Try

        Try 'Hash - hash del game
            dt.Rows(riga).Item("Hash") = valori("hash")
        Catch ex As Exception
            dt.Rows(riga).Item("Hash") = ""
        End Try

        Try 'Image - posizione del file immagine .\media\images\game_name.png
            dt.Rows(riga).Item("Image") = "." & percorsoMediaImages & valori("game_name") & ".png"
        Catch ex As Exception
            dt.Rows(riga).Item("Image") = ""
        End Try

        Try 'Thumbnail - immagine del box del game
            dt.Rows(riga).Item("Thumbnail") = valori("thumbnail")
        Catch ex As Exception
            dt.Rows(riga).Item("thumbnail") = ""
        End Try

        Try 'URLImageInGame - URL dell'immagine durante il game
            dt.Rows(riga).Item("URLImageInGame") = valori("url_image_ingame")
            client.DownloadFile(valori("url_image_ingame") & "/" & valori("game_name") & ".png", Label1.Text & percorsoMediaImages & valori("game_name") & ".png")
        Catch ex As Exception
            dt.Rows(riga).Item("URLImageInGame") = ""
        End Try

        Try 'URLImageTitle - URL dell'immagine del titolo del game
            dt.Rows(riga).Item("URLImageTitle") = valori("url_image_title")
            client.DownloadFile(valori("url_image_title") & "/" & valori("game_name") & ".png", Label1.Text & percorsoMediaTitles & valori("game_name") & ".png")
        Catch ex As Exception
            dt.Rows(riga).Item("URLImageTitle") = ""
        End Try

        Try 'URLImageMarquee - URL dell'immagine del marquee (barra sopra il bartop) del game
            dt.Rows(riga).Item("URLImageMarquee") = valori("url_image_marquee")
            client.DownloadFile(valori("url_image_marquee") & "/" & valori("game_name") & ".png", Label1.Text & percorsoMediaMarquees & valori("game_name") & ".png")
        Catch ex As Exception
            dt.Rows(riga).Item("URLImageMarquee") = ""
        End Try

        Try 'URLImageCabinet - URL dell'immagine del cabinato del game
            dt.Rows(riga).Item("URLImageCabinet") = valori("url_image_cabinet")
            client.DownloadFile(valori("url_image_cabinet") & "/" & valori("game_name") & ".png", Label1.Text & percorsoMediaCabinets & valori("game_name") & ".png")
        Catch ex As Exception
            dt.Rows(riga).Item("URLImageCabinet") = ""
        End Try

        Try 'URLImageFlyer - URL dell'immagine del volantino del game
            dt.Rows(riga).Item("URLImageFlyer") = valori("url_image_flyer")
            client.DownloadFile(valori("url_image_flyer") & "/" & valori("game_name") & ".png", Label1.Text & percorsoMediaFlyers & valori("game_name") & ".png")
        Catch ex As Exception
            dt.Rows(riga).Item("URLImageFlyer") = ""
        End Try

        Try 'Status - stato di emulazione del game
            dt.Rows(riga).Item("Status") = valori("status")
        Catch ex As Exception
            dt.Rows(riga).Item("Status") = ""
        End Try

        Try 'HistoryCopyrightLong - copyright long version
            dt.Rows(riga).Item("HistoryCopyrightLong") = valori("history_copyright_long")
        Catch ex As Exception
            dt.Rows(riga).Item("HistoryCopyrightLong") = ""
        End Try

        Try 'HistoryCopyrightShort - copyright short version
            dt.Rows(riga).Item("HistoryCopyrightShort") = valori("history_copyright_short")
        Catch ex As Exception
            dt.Rows(riga).Item("HistoryCopyrightShort") = ""
        End Try

        Try 'YoutubeVideoID - ID di youtube del video del game
            dt.Rows(riga).Item("YoutubeVideoID") = valori("youtube_video_id")
        Catch ex As Exception
            dt.Rows(riga).Item("YoutubeVideoID") = ""
        End Try

        Try 'URLVideoShortplay - url del video del game short version
            dt.Rows(riga).Item("URLVideoShortplay") = valori("url_video_shortplay")
        Catch ex As Exception
            dt.Rows(riga).Item("URLVideoShortplay") = ""
        End Try

        Try 'URLVideoShortplayHD - url del video del game short version in HD
            dt.Rows(riga).Item("URLVideoShortplayHD") = valori("url_video_shortplay_hd")
            client.DownloadFile(valori("url_video_shortplay_hd"), Label1.Text & percorsoMediaVideos & valori("game_name") & valori("url_video_shortplay_hd").Substring(valori("url_video_shortplay_hd").Length - 4)) 'recupera l'estensione dalle ultime 3 lettere
        Catch ex As Exception
            dt.Rows(riga).Item("URLVideoShortplayHD") = ""
        End Try

        Try 'EmulatorID - ID dell'emulatore del game
            dt.Rows(riga).Item("EmulatorID") = valori("emulator_id")
        Catch ex As Exception
            dt.Rows(riga).Item("EmulatorID") = 0
        End Try

        Try 'EmulatorName - nome dell'emulatore del game
            dt.Rows(riga).Item("EmulatorName") = valori("emulator_name")
        Catch ex As Exception
            dt.Rows(riga).Item("EmulatorName") = ""
        End Try

        Try 'Languages - lingue del game
            dt.Rows(riga).Item("Languages") = valori("languages")
        Catch ex As Exception
            dt.Rows(riga).Item("Languages") = ""
        End Try

        client.Dispose()
    End Sub

    Private Sub CreaFileDemoXML(ByVal filePaths As String)
        Dim fileReader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader("log.txt")
        Dim stringReader As String
        Dim jss As New Web.Script.Serialization.JavaScriptSerializer()
        Dim valori As Dictionary(Of String, String)
        Dim inizioStringa As Integer
        Dim fineStringa As Integer

        Dim Scrivi As New XmlTextWriter(filePaths, System.Text.Encoding.UTF8)

        dt.Columns.Add("ID", Type.GetType("System.Int16")) 'id riconosciuto dal sito di scraper
        dt.Columns.Add("URL", Type.GetType("System.String")) 'url
        dt.Columns.Add("Game", Type.GetType("System.String")) 'game_name
        dt.Columns.Add("Source", Type.GetType("System.String")) 'sito di scraper
        dt.Columns.Add("Path", Type.GetType("System.String")) 'posizione del file .\game_name
        dt.Columns.Add("Name", Type.GetType("System.String")) 'title
        dt.Columns.Add("CloneOf", Type.GetType("System.String")) 'cloneof
        dt.Columns.Add("Desc", Type.GetType("System.String")) 'history
        dt.Columns.Add("Rating", Type.GetType("System.Double")) 'rate
        dt.Columns.Add("ReleaseDate", Type.GetType("System.String")) 'year
        dt.Columns.Add("Developer", Type.GetType("System.String")) 'manufacturer (prima parte)
        dt.Columns.Add("Publisher", Type.GetType("System.String")) 'manufacturer (seconda parte)
        dt.Columns.Add("Genre", Type.GetType("System.String")) 'genre
        dt.Columns.Add("Players", Type.GetType("System.Int16")) 'players
        dt.Columns.Add("Region", Type.GetType("System.String"))
        dt.Columns.Add("Hash", Type.GetType("System.String"))
        dt.Columns.Add("Image", Type.GetType("System.String")) 'posizione del file immagine .\media\image
        dt.Columns.Add("Thumbnail", Type.GetType("System.String"))
        dt.Columns.Add("URLImageInGame", Type.GetType("System.String")) 'url_image_ingame
        dt.Columns.Add("URLImageTitle", Type.GetType("System.String")) 'url_image_title
        dt.Columns.Add("URLImageMarquee", Type.GetType("System.String")) 'url_image_marquee
        dt.Columns.Add("URLImageCabinet", Type.GetType("System.String")) 'url_image_cabinet
        dt.Columns.Add("URLImageFlyer", Type.GetType("System.String")) 'url_image_flyer
        dt.Columns.Add("Status", Type.GetType("System.String")) 'status
        dt.Columns.Add("HistoryCopyrightLong", Type.GetType("System.String")) 'history_copyright_long
        dt.Columns.Add("HistoryCopyrightShort", Type.GetType("System.String")) 'history_copyright_short
        dt.Columns.Add("YoutubeVideoID", Type.GetType("System.String")) 'youtube_video_id
        dt.Columns.Add("URLVideoShortplay", Type.GetType("System.String")) 'url_video_shortplay
        dt.Columns.Add("URLVideoShortplayHD", Type.GetType("System.String")) 'url_video_shortplay_hd
        dt.Columns.Add("EmulatorID", Type.GetType("System.Int16")) 'emulator_id
        dt.Columns.Add("EmulatorName", Type.GetType("System.String")) 'emulator_name
        dt.Columns.Add("Languages", Type.GetType("System.String")) 'languages

        stringReader = fileReader.ReadLine()
        inizioStringa = stringReader.IndexOf("[")
        fineStringa = stringReader.IndexOf("]")
        stringReader = stringReader.Substring(inizioStringa + 1, fineStringa - inizioStringa - 1)

        Do While Not stringReader Is Nothing

            valori = jss.Deserialize(Of Dictionary(Of String, String))(stringReader)
            InserisciDati(valori, "arcadeitalia.net")

            stringReader = fileReader.ReadLine()

            Try
                inizioStringa = stringReader.IndexOf("[{")
                fineStringa = stringReader.IndexOf("}]")
                stringReader = stringReader.Substring(inizioStringa + 1, fineStringa - inizioStringa)

            Catch ex As Exception
                '
            End Try

        Loop

        fileReader.Close()

        Scrivi.WriteStartDocument(True)
        Scrivi.Formatting = Formatting.Indented
        Scrivi.Indentation = 2
        Scrivi.WriteStartElement("gameList")

        For riga As Integer = 0 To dt.Rows.Count - 1
            CreaNodo(riga, Scrivi)
        Next

        Scrivi.WriteEndElement()
        Scrivi.WriteEndDocument()
        Scrivi.Close()

        dt.Dispose()

    End Sub

    Private Sub CreaNodo(ByVal riga As Integer, ByVal scrivi As XmlTextWriter)

        scrivi.WriteStartElement("game")
        scrivi.WriteAttributeString("id", dt.Rows(riga).Item("ID"))
        scrivi.WriteAttributeString("source", "arcadeitalia.net")

        scrivi.WriteStartElement("path")
        scrivi.WriteString(dt.Rows(riga).Item("Path"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("name")
        scrivi.WriteString(dt.Rows(riga).Item("Name"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("desc")
        scrivi.WriteString(dt.Rows(riga).Item("Desc"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("rating")
        scrivi.WriteString(dt.Rows(riga).Item("Rating"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("releasedate")
        scrivi.WriteString(dt.Rows(riga).Item("ReleaseDate"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("developer")
        scrivi.WriteString(dt.Rows(riga).Item("Developer"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("publisher")
        scrivi.WriteString(dt.Rows(riga).Item("Publisher"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("genre")
        scrivi.WriteString(dt.Rows(riga).Item("Genre"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("players")
        scrivi.WriteString(dt.Rows(riga).Item("Players"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("region")
        scrivi.WriteString(dt.Rows(riga).Item("Region"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("hash")
        scrivi.WriteString(dt.Rows(riga).Item("Hash"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("image")
        scrivi.WriteString(dt.Rows(riga).Item("Image"))
        scrivi.WriteEndElement()

        scrivi.WriteStartElement("thumbnail")
        scrivi.WriteString(dt.Rows(riga).Item("Thumbnail"))
        scrivi.WriteEndElement()

        'scrivi.WriteStartElement("hidden")
        'scrivi.WriteString("hidden")
        'scrivi.WriteEndElement()

        'scrivi.WriteStartElement("nplay")
        'scrivi.WriteString("nplay")
        'scrivi.WriteEndElement()

        scrivi.WriteEndElement() 'chiude nodo game
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dt.Dispose()
    End Sub

    Private Sub ButtonOption_Click(sender As Object, e As EventArgs) Handles ButtonOption.Click
        'TODO caricare/salvare configurazione programma tramite finestra
        FormOptions.Show()
    End Sub

    Private Sub ButtonUtility_Click(sender As Object, e As EventArgs) Handles ButtonUtility.Click
        FormUtility.Show()
    End Sub

    Private Sub ButtonFeelLayoutManager_Click(sender As Object, e As EventArgs) Handles ButtonFeelLayoutManager.Click
        FormFLM.Show()
    End Sub
End Class
