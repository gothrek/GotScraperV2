Imports System.Xml
Imports System.IO

Public Class FormOptions
    Private Sub FormOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If File.Exists("GotScraper.cfg") Then 'il file esiste

            Dim Leggi As New XmlTextReader("GotScraper.cfg")

            While Leggi.Read()
                If Leggi.Name = "Config" Then
                    'For i As Integer = 0 To Leggi.AttributeCount - 1
                    '    MsgBox(Leggi.GetAttribute(i))
                    'Next
                    Try
                        Form1.fileGamelist = Leggi.GetAttribute(0)
                    Catch ex As Exception
                        Form1.fileGamelist = "gamelist.xml"
                    End Try

                    Try
                        Form1.percorsoServerMedia = Leggi.GetAttribute(1)
                    Catch ex As Exception
                        Form1.percorsoServerMedia = "D:\Personale\ROMS\media\"
                    End Try

                    Try
                        Form1.percorsoMediaImages = Leggi.GetAttribute(2)
                    Catch ex As Exception
                        Form1.percorsoMediaImages = "\media\images\"
                    End Try

                    Try
                        Form1.percorsoMediaVideos = Leggi.GetAttribute(3)
                    Catch ex As Exception
                        Form1.percorsoMediaVideos = "\media\videos\"
                    End Try

                    Try
                        Form1.percorsoMediaTitles = Leggi.GetAttribute(4)
                    Catch ex As Exception
                        Form1.percorsoMediaTitles = "\media\titles\"
                    End Try

                    Try
                        Form1.percorsoMediaMarquees = Leggi.GetAttribute(5)
                    Catch ex As Exception
                        Form1.percorsoMediaMarquees = "\media\marquees\"
                    End Try

                    Try
                        Form1.percorsoMediaCabinets = Leggi.GetAttribute(6)
                    Catch ex As Exception
                        Form1.percorsoMediaCabinets = "\media\cabinets\"
                    End Try

                    Try
                        Form1.percorsoMediaFlyers = Leggi.GetAttribute(7)
                    Catch ex As Exception
                        Form1.percorsoMediaFlyers = "\media\flyers\"
                    End Try

                End If
            End While

            Leggi.Dispose()

        Else 'il file non esiste, ne viene creato uno di default

            Dim Scrivi As New XmlTextWriter("GotScraper.cfg", System.Text.Encoding.UTF8)

            Scrivi.WriteStartDocument(True)

            Scrivi.Formatting = Formatting.Indented
            Scrivi.Indentation = 2

            Scrivi.WriteStartElement("GotScraper")

            Scrivi.WriteStartElement("Config")

            Scrivi.WriteAttributeString("fileGameList", "gamelist.xml")
            Scrivi.WriteAttributeString("percorsoServerMedia", "D:\Personale\ROMS\media\")
            Scrivi.WriteAttributeString("percorsoMediaImages", "\media\images\")
            Scrivi.WriteAttributeString("percorsoMediaVideos", "\media\videos\")
            Scrivi.WriteAttributeString("percorsoMediaTitles", "\media\titles\")
            Scrivi.WriteAttributeString("percorsoMediaMarquees", "\media\marquees\")
            Scrivi.WriteAttributeString("percorsoMediaCabinets", "\media\cabinets\")
            Scrivi.WriteAttributeString("percorsoMediaFlyers", "\media\flyers\")

            'Scrivi.WriteStartElement("path")
            'Scrivi.WriteString(dt.Rows(riga).Item("Path"))
            'Scrivi.WriteEndElement()
            Scrivi.WriteEndElement()

            Scrivi.WriteEndElement()
            Scrivi.WriteEndDocument()
            Scrivi.Close()

            Form1.fileGamelist = "gamelist.xml"
            Form1.percorsoServerMedia = "D:\Personale\ROMS\media\"
            Form1.percorsoMediaImages = "\media\images\"
            Form1.percorsoMediaVideos = "\media\videos\"
            Form1.percorsoMediaTitles = "\media\titles\"
            Form1.percorsoMediaMarquees = "\media\marquees\"
            Form1.percorsoMediaCabinets = "\media\cabinets\"
            Form1.percorsoMediaFlyers = "\media\flyers\"

            Scrivi.Dispose()

        End If

    End Sub

End Class