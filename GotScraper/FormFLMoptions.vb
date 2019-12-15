Public Class FormFLMoptions

    Dim usoLayout As Integer = FormFLM.flmLayout

    Private Sub FormFLMoptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxPathFeel.Text = FormFLM.LabelPercorso.Text
        TextBoxPathFeel.Text = FormFLM.feelPath

        TextBoxPathGraphEditor.Text = FormFLM.grafxEditorPath

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


    Private Sub CheckBoxFLMBackgroundImage_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFLMBackgroundImage.CheckedChanged
        If CheckBoxFLMBackgroundImage.Checked Then
            FormFLM.BackgroundImage = ClassUtility.ChangeOpacity(FormFLM.flmBackgroundImage, 1)
        Else
            FormFLM.BackgroundImage = Nothing
        End If
    End Sub

    Private Sub RadioButtonFLMLayout1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout1.CheckedChanged
        FormFLM.flmLayout = 1
        FormFLM.flmBackgroundImage = My.Resources.Layout1

        PanelFLMLayout1.Enabled = RadioButtonFLMLayout1.Checked
    End Sub

    Private Sub RadioButtonFLMLayout2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout2.CheckedChanged
        FormFLM.flmLayout = 2
        FormFLM.flmBackgroundImage = My.Resources.Layout2

        PanelFLMLayout2.Enabled = RadioButtonFLMLayout2.Checked
    End Sub

    Private Sub RadioButtonFLMLayout3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFLMLayout3.CheckedChanged
        FormFLM.flmLayout = 3
        'FormFLM.flmBackgroundImage = My.Resources.Layout3

        PanelFLMLayout3.Enabled = RadioButtonFLMLayout3.Checked
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        FormFLM.LabelPercorso.Text = TextBoxPathFeel.Text
        FormFLM.feelPath = TextBoxPathFeel.Text

        FormFLM.grafxEditorPath = TextBoxPathGraphEditor.Text

        FormFLM.flmBackgroundImageCheck = CheckBoxFLMBackgroundImage.Checked

        'FormFLM.flmLayout = FormFLM.flmLayout
        FormFLM.FormFLM_Resize()

        If My.Computer.FileSystem.FileExists("FLM.ini") Then
            Try
                System.IO.File.Delete("FLM.ini")
                Dim file As System.IO.StreamWriter

                file = My.Computer.FileSystem.OpenTextFileWriter("FLM.ini", True)

                file.WriteLine("File di configurazione del programma FLM F.E.(E.L.) Layout Manager by gothrek")
                file.WriteLine()
                file.WriteLine("non editare il file, le sue impostazioni vengono gestite direttamente dal programma.")
                file.WriteLine()
                file.WriteLine("feelPath=" & TextBoxPathFeel.Text)
                file.WriteLine("grafxEditorPath=" & TextBoxPathGraphEditor.Text)
                file.WriteLine("templateLayoutIni=" & TextBoxTemplateLayoutIni.Text)
                file.WriteLine("flmBackgroundImageCheck=" & CheckBoxFLMBackgroundImage.Checked)
                file.WriteLine("flmLayout=" & FormFLM.flmLayout)

                file.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim file As System.IO.StreamWriter

            file = My.Computer.FileSystem.OpenTextFileWriter("FLM.ini", True)

            file.WriteLine("File di configurazione del programma FLM F.E.(E.L.) Layout Manager by gothrek")
            file.WriteLine()
            file.WriteLine("non editare il file, le sue impostazioni vengono gestite direttamente dal programma.")
            file.WriteLine()
            file.WriteLine("feelPath=" & TextBoxPathFeel.Text)
            file.WriteLine("grafxEditorPath=" & TextBoxPathGraphEditor.Text)
            file.WriteLine("templateLayoutIni=" & TextBoxTemplateLayoutIni.Text)
            file.WriteLine("flmBackgroundImageCheck=" & CheckBoxFLMBackgroundImage.Checked)
            file.WriteLine("flmLayout=" & FormFLM.flmLayout)

            file.Close()
        End If

        Me.Close()
    End Sub

End Class