Imports System.Xml
Imports System.Security.Cryptography

Public Class FormUtility
    Dim dtFiles As DataTable

    Dim conflitti(0, 1) As String
    Dim contatoreConflitti As Integer = 0
    Dim nConflitti As Integer = 0

    Dim utility As New ClassUtility()

    Private Sub ButtonDirectory_Click(sender As Object, e As EventArgs) Handles ButtonDirectory.Click
        Dim cartella As String ' = ""
        Dim folder As DirectoryInfo
        Dim file As String

        dtFiles = New DataTable("Files")

        dtFiles.Columns.Add("ID", Type.GetType("System.Int16")) 'id del file
        dtFiles.Columns.Add("FullName", Type.GetType("System.String")) 'nome file completo
        dtFiles.Columns.Add("Name", Type.GetType("System.String")) 'nome file senza attributi
        dtFiles.Columns.Add("Region", Type.GetType("System.String"))
        dtFiles.Columns.Add("Attrib1", Type.GetType("System.String"))
        dtFiles.Columns.Add("Attrib2", Type.GetType("System.String"))
        dtFiles.Columns.Add("Attrib3", Type.GetType("System.String"))
        dtFiles.Columns.Add("Attrib4", Type.GetType("System.String"))
        dtFiles.Columns.Add("Attrib5", Type.GetType("System.String"))
        dtFiles.Columns.Add("Note", Type.GetType("System.String"))

        FolderBrowserDialog1.ShowDialog()
        cartella = FolderBrowserDialog1.SelectedPath
        LabelDirectory.Text = cartella
        LabelDirectory.Refresh()
        folder = My.Computer.FileSystem.GetDirectoryInfo(cartella)

        For Each files As FileInfo In folder.GetFiles()

            If files.Extension = ".zip" Then
                Dim contatore As Integer = 2

                dtFiles.Rows.Add()
                dtFiles.Rows(dtFiles.Rows.Count - 1).Item("ID") = dtFiles.Rows.Count
                dtFiles.Rows(dtFiles.Rows.Count - 1).Item("FullName") = files.Name

                file = files.Name.Replace(")", "")
                file = file.Substring(0, file.Length - 4)

                For Each attributo In file.Split("(")
                    dtFiles.Rows(dtFiles.Rows.Count - 1).Item(contatore) = attributo
                    contatore += 1
                Next
            End If

        Next

        UltraGrid1.DataSource = dtFiles
        UltraGrid1.DisplayLayout.Bands(0).Columns(1).AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
        UltraGrid1.Refresh()

    End Sub

    Private Sub ButtonScan_Click(sender As Object, e As EventArgs) Handles ButtonScan.Click
        Dim contaSi As Integer = 0
        ReDim conflitti(Int(dtFiles.Rows.Count / 2), 1)

        Dim i As Integer = 0
        Dim c As Integer = 0

        Do
            Dim k As Integer = 1
            Dim esci As Boolean = False

            Do
                If dtFiles.Rows(i).Item("Name") <> dtFiles.Rows(i + k).Item("Name") Then
                    If k = 1 Then
                        dtFiles.Rows(i).Item("Note") = "Si"
                        contaSi += 1
                    Else
                        dtFiles.Rows(i).Item("Note") = "No"
                        conflitti(c, 0) = i + 1 'il campo ID ha un valore superiore di una unità rispetto al nRiga
                        conflitti(c, 1) = i + k
                        UltraListView1.Items.Add(c, conflitti(c, 0) & "-" & conflitti(c, 1) & "-" & dtFiles.Rows(i).Item("Name"))
                        c += 1
                    End If

                    esci = True
                Else
                    dtFiles.Rows(i + k).Item("Note") = "No"
                    k += 1
                End If
            Loop Until esci Or (k = dtFiles.Rows.Count)

            i += k

        Loop Until (i >= dtFiles.Rows.Count - 1)

        If dtFiles.Rows(dtFiles.Rows.Count - 1).Item("Name") <> dtFiles.Rows(dtFiles.Rows.Count - 2).Item("Name") Then 'controlla l'ultima riga essendo diversa dalle altre in quanto non ha riga successiva ma solo precedente
            dtFiles.Rows(dtFiles.Rows.Count - 1).Item("Note") = "Si"
            contaSi += 1
        End If

        nConflitti = c

        LabelScan.Text = "Si=" & contaSi & " - No=" & dtFiles.Rows.Count - contaSi & " - Conflitti=" & c

        If MsgBox("Ci sono " & c & " conflitti! Vuoi risolverli ora?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            RisolviConflitto(0)
        End If
        'For j As Integer = 0 To c - 1
        '    Debug.WriteLine(conflitti(j))
        'Next

    End Sub

    Private Sub UltraGrid1_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles UltraGrid1.DoubleClickRow
        dtFiles.Rows(e.Row.Cells("ID").Value - 1).Item("Note") = "Si"
        contatoreConflitti += 1
        If contatoreConflitti < nConflitti Then
            RisolviConflitto(contatoreConflitti)
        Else
            UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Clear()
            MsgBox("Risolti tutti i conflitti! Verrà generato file dat.")
            UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("Note").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, "Si")
            UltraGrid1.Refresh()

            File.Delete(LabelDirectory.Text & "\filetest.dat")

            GeneraFileDat()
        End If
    End Sub

    Private Sub RisolviConflitto(j As Integer)
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Clear()
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.GreaterThanOrEqualTo, conflitti(j, 0))
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.LessThanOrEqualTo, conflitti(j, 1))
        UltraGrid1.Refresh()
    End Sub

    Private Sub GeneraFileDat()
        'TODO Generazione file DAT x CRLMamePro
        Dim Scrivi As New XmlTextWriter(LabelDirectory.Text & "\filetest.dat", System.Text.Encoding.UTF8)
        Dim nomeFile As String

        Scrivi.WriteStartDocument(True)
        Scrivi.Formatting = Formatting.Indented
        Scrivi.Indentation = 2
        Scrivi.WriteStartElement("datafile")
        Scrivi.WriteStartElement("header")
        Scrivi.WriteElementString("name", "")
        Scrivi.WriteElementString("description", "")
        Scrivi.WriteElementString("version", "")
        Scrivi.WriteElementString("date", "")
        Scrivi.WriteElementString("author", "Gothrek")
        Scrivi.WriteElementString("url", "")
        Scrivi.WriteEndElement() 'header

        'TODO elementi dei file
        For i As Integer = 0 To dtFiles.Rows.Count - 1
            If dtFiles.Rows(i).Item("Note") = "Si" Then
                Scrivi.WriteStartElement("game")
                nomeFile = dtFiles.Rows(i).Item("FullName").ToString.Substring(0, dtFiles.Rows(i).Item("FullName").ToString.Length - 4)
                Scrivi.WriteAttributeString("name", nomeFile)
                'cloneof Scrivi.WriteAttributeString("name", dtFiles.Rows(i).Item("FullName"))
                Scrivi.WriteElementString("description", nomeFile)
                'Scrivi.WriteStartElement("release")
                'Scrivi.WriteAttributeString("name", nomeFile)
                'Scrivi.WriteEndElement() 'release
                'region Scrivi.WriteAttributeString("name", dtFiles.Rows(i).Item("FullName"))

                Dim zip As ZipArchive = ZipFile.Open(LabelDirectory.Text & "\" & dtFiles.Rows(i).Item("FullName"), ZipArchiveMode.Read)

                zip.ExtractToDirectory(My.Application.GetEnvironmentVariable("temp"))

                For Each entry As ZipArchiveEntry In zip.Entries()

                    Scrivi.WriteStartElement("rom")
                    Scrivi.WriteAttributeString("name", entry.Name)
                    Scrivi.WriteAttributeString("size", entry.Length) 'size 
                    'MsgBox(utility.GetCRC32(My.Application.GetEnvironmentVariable("temp") & "\" & entry.FullName))
                    'MsgBox(utility.GetMD5(My.Application.GetEnvironmentVariable("temp") & "\" & entry.FullName))
                    Scrivi.WriteAttributeString("crc", utility.GetCRC32(My.Application.GetEnvironmentVariable("temp") & "\" & entry.FullName)) 'crc
                    Scrivi.WriteAttributeString("md5", utility.GetMD5(My.Application.GetEnvironmentVariable("temp") & "\" & entry.FullName)) 'md5
                    'sha1 Scrivi.WriteAttributeString("sha1", dtFiles.Rows(i).Item("FullName"))
                    'status Scrivi.WriteAttributeString("status", dtFiles.Rows(i).Item("FullName"))
                    Scrivi.WriteEndElement() 'rom

                    File.Delete(My.Application.GetEnvironmentVariable("temp") & "\" & entry.FullName)
                Next

                zip.Dispose()

                Scrivi.WriteEndElement() 'game
            End If
        Next

        Scrivi.WriteEndElement() 'datafile
        Scrivi.WriteEndDocument()
        Scrivi.Close()

        MsgBox("Generazione file completata!")

        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Clear()
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("Note").FilterConditions.Clear()
        UltraGrid1.Refresh()
    End Sub

    Private Sub UltraListView1_ItemDoubleClick(sender As Object, e As Infragistics.Win.UltraWinListView.ItemDoubleClickEventArgs) Handles UltraListView1.ItemDoubleClick
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Clear()
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("Note").FilterConditions.Clear()
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.GreaterThanOrEqualTo, conflitti(Int(e.Item.Key), 0))
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.LessThanOrEqualTo, conflitti(Int(e.Item.Key), 1))
        UltraGrid1.Refresh()
    End Sub

    Private Sub ButtonGeneraFileDat_Click(sender As Object, e As EventArgs) Handles ButtonGeneraFileDat.Click
        GeneraFileDat()
    End Sub
End Class