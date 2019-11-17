Imports System.IO
Imports System.Diagnostics

Public Class FormUtility
    Dim dtFiles As DataTable = New DataTable("Files")

    Private Sub ButtonDirectory_Click(sender As Object, e As EventArgs) Handles ButtonDirectory.Click
        Dim cartella As String ' = ""
        Dim folder As DirectoryInfo
        Dim file As String

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

        Next

        UltraGrid1.DataSource = dtFiles

    End Sub

    Private Sub ButtonScan_Click(sender As Object, e As EventArgs) Handles ButtonScan.Click
        Dim contaSi As Integer = 0
        Dim conflitti(Int(dtFiles.Rows.Count / 2), 1) As String

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
                        conflitti(c, 0) = i
                        conflitti(c, 1) = i + k - 1
                        c += 1

                    End If

                    esci = True
                Else
                    k += 1
                End If
            Loop Until esci Or (k = dtFiles.Rows.Count)

            i += k

        Loop Until (i >= dtFiles.Rows.Count - 1)

        If dtFiles.Rows(dtFiles.Rows.Count - 1).Item("Name") <> dtFiles.Rows(dtFiles.Rows.Count - 2).Item("Name") Then 'controlla l'ultima riga essendo diversa dalle altre in quanto non ha riga successiva ma solo precedente
            dtFiles.Rows(dtFiles.Rows.Count - 1).Item("Note") = "Si"
            contaSi += 1
        End If

        LabelScan.Text = "Si=" & contaSi & " - No=" & dtFiles.Rows.Count - contaSi & " - Conflitti=" & c
        'UltraGrid1.DisplayLayout.Bands(0).Columns("FullName").FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("Note").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, "Si")
        UltraGrid1.Refresh()

        If MsgBox("Ci sono " & c & " conflitti! Vuoi risolverli ora?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For j As Integer = 0 To c - 1
                UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.GreaterThanOrEqualTo, conflitti(j, 0))
                UltraGrid1.DisplayLayout.Bands(0).ColumnFilters("ID").FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.LessThanOrEqualTo, conflitti(j, 1))
            Next
        End If
        'For j As Integer = 0 To c - 1
        '    Debug.WriteLine(conflitti(j))
        'Next

    End Sub


End Class