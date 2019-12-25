Public Class FormFLMoptions
    Dim start As Boolean = True

    Dim fontName As String = FormFLM.fontIntestazioni
    Dim fontSize As Single = FormFLM.fontIntestazioniSize
    Dim fontStyle As FontStyle = FormFLM.fontIntestazioniStyle
    Dim fontColor As String = FormFLM.fontIntestazioniColor

    Dim mouseTimeClick As Integer = FormFLM.Timer1.Interval

    Dim usoLayout As Integer

    Private Sub FormFLMoptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim carattere As Font

        usoLayout = FormFLM.flmLayout

        TextBoxPathFeel.Text = FormFLM.LabelPercorso.Text
        TextBoxPathFeel.Text = FormFLM.feelPath

        TextBoxPathGraphEditor.Text = FormFLM.grafxEditorPath

        carattere = New Font(fontName, 8, fontStyle)

        TextBoxFontIntestazioni.Text = fontName
        TextBoxFontIntestazioni.Font = carattere
        TextBoxFontIntestazioni.ForeColor = Color.FromName(fontColor)

        TextBoxMouseTimeClick.Text = mouseTimeClick

        CheckBoxFLMBackgroundImage.Checked = FormFLM.flmBackgroundImageCheck

        Select Case usoLayout
            Case 1
                RadioButtonFLMLayout1.Checked = True
            Case 2
                RadioButtonFLMLayout2.Checked = True
            Case 3
                RadioButtonFLMLayout3.Checked = True
            Case Else
                MsgBox("Attenzione, valore di Layout nel file ini errato!! Verificare!")
        End Select

        PanelFLMLayout1.Enabled = RadioButtonFLMLayout1.Checked
        PanelFLMLayout2.Enabled = RadioButtonFLMLayout2.Checked
        PanelFLMLayout3.Enabled = RadioButtonFLMLayout3.Checked
    End Sub

    Private Sub TextBoxPathFeel_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxPathFeel.DoubleClick, TextBoxPathFeel.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBoxPathFeel.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub TextBoxPathGraphEditor_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxPathGraphEditor.DoubleClick, TextBoxPathGraphEditor.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBoxPathGraphEditor.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub TextBoxFontIntestazioni_DoubleClick(sender As Object, e As EventArgs) Handles TextBoxFontIntestazioni.DoubleClick, TextBoxFontIntestazioni.Click
        Dim carattere As Font

        If FontDialog1.ShowDialog() = DialogResult.OK Then
            fontName = FontDialog1.Font.Name
            fontSize = FontDialog1.Font.Size
            fontStyle = FontDialog1.Font.Style
            carattere = New Font(fontName, 8, fontStyle)
            fontColor = FontDialog1.Color.Name

            TextBoxFontIntestazioni.ForeColor = FontDialog1.Color
            TextBoxFontIntestazioni.Font = carattere
            TextBoxFontIntestazioni.Text = fontName
        End If
    End Sub

    Private Sub TextBoxFontIntestazioni_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxFontIntestazioni.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub TextBoxMouseTimeClick_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMouseTimeClick.TextChanged
        If Not start Then
            Try
                mouseTimeClick = Int(sender.text)
            Catch ex As Exception
                mouseTimeClick = FormFLM.Timer1.Interval
            End Try

            sender.text = mouseTimeClick
        Else
            start = False
        End If
    End Sub

    Private Sub RadioButtonFLMLayout1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout1.CheckedChanged
        usoLayout = 1
        PanelFLMLayout1.Enabled = RadioButtonFLMLayout1.Checked
    End Sub

    Private Sub RadioButtonFLMLayout2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout2.CheckedChanged
        usoLayout = 2
        PanelFLMLayout2.Enabled = RadioButtonFLMLayout2.Checked
    End Sub

    Private Sub RadioButtonFLMLayout3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout3.CheckedChanged
        usoLayout = 3
        PanelFLMLayout3.Enabled = RadioButtonFLMLayout3.Checked
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        FormFLM.LabelPercorso.Text = TextBoxPathFeel.Text
        FormFLM.feelPath = TextBoxPathFeel.Text

        FormFLM.grafxEditorPath = TextBoxPathGraphEditor.Text

        FormFLM.fontIntestazioni = fontName
        FormFLM.fontIntestazioniSize = fontSize
        FormFLM.fontIntestazioniStyle = fontStyle
        FormFLM.fontIntestazioniColor = fontColor

        FormFLM.mouseTimeClick = mouseTimeClick
        FormFLM.Timer1.Interval = mouseTimeClick

        FormFLM.flmBackgroundImageCheck = CheckBoxFLMBackgroundImage.Checked

        Select Case usoLayout
            Case 1
                FormFLM.flmLayout = 1
                FormFLM.flmBackgroundImage = My.Resources.Layout1
            Case 2
                FormFLM.flmLayout = 2
                FormFLM.flmBackgroundImage = My.Resources.Layout2
            Case 3
                FormFLM.flmLayout = 3
                'FormFLM.flmBackgroundImage = My.Resources.Layout3
        End Select

        If CheckBoxFLMBackgroundImage.Checked Then
            FormFLM.BackgroundImage = ClassUtility.ChangeOpacity(FormFLM.flmBackgroundImage, 1)
        Else
            FormFLM.BackgroundImage = Nothing
        End If

        FormFLM.FormFLM_Resize()
        FormFLM.Refresh()

        If My.Computer.FileSystem.FileExists("FLM.ini") Then
            Try
                System.IO.File.Delete("FLM.ini")

                CreaFile()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            CreaFile()
        End If

        Dim usoFont As Font
        usoFont = New Font(fontName, fontSize, fontStyle)
        FormFLM.GroupBoxObj.Font = usoFont
        FormFLM.GroupBoxObj.ForeColor = Color.FromName(fontColor)
        FormFLM.GroupBoxObj.Refresh()

        FormFLM.GroupBoxProprietà.Font = usoFont
        FormFLM.GroupBoxProprietà.ForeColor = Color.FromName(fontColor)
        FormFLM.GroupBoxProprietà.Refresh()

        usoFont = New Font(fontName, fontSize - 4, FontStyle.Regular)
        FormFLM.ListBoxObj.Font = usoFont
        FormFLM.ListBoxObj.Refresh()

        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        TextBoxMouseTimeClick.Text = FormFLM.Timer1.Interval
        Me.Close()
    End Sub

    Private Sub CreaFile()
        Dim file As System.IO.StreamWriter

        file = My.Computer.FileSystem.OpenTextFileWriter("FLM.ini", True)

        file.WriteLine("File di configurazione del programma FLM F.E.(E.L.) Layout Manager by gothrek")
        file.WriteLine()
        file.WriteLine("non editare il file, le sue impostazioni vengono gestite direttamente dal programma.")
        file.WriteLine()
        file.WriteLine("feelPath=" & TextBoxPathFeel.Text)
        file.WriteLine("grafxEditorPath=" & TextBoxPathGraphEditor.Text)
        file.WriteLine("templateLayoutIni=" & TextBoxTemplateLayoutIni.Text)
        file.WriteLine("fontIntestazioniName=" & fontName)
        file.WriteLine("fontIntestazioniSize=" & fontSize)
        file.WriteLine("fontIntestazioniStyle=" & fontStyle)
        file.WriteLine("fontIntestazioniColor=" & fontColor)
        file.WriteLine("mouseTimeClick=" & mouseTimeClick)
        file.WriteLine("flmBackgroundImageCheck=" & CheckBoxFLMBackgroundImage.Checked)
        file.WriteLine("flmLayout=" & usoLayout)

        file.Close()
    End Sub

End Class