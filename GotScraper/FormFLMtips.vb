Public Class FormFLMtips
    Dim tip As String = FormFLM.flmTip

    Private Sub FormFLMtips_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelTip.Text = tip
    End Sub

    Private Sub ButtonTip_Click(sender As Object, e As EventArgs) Handles ButtonTip.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonChiudi_Click(sender As Object, e As EventArgs) Handles ButtonChiudi.Click
        If CheckBoxTip.Checked Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
        Me.Close()
    End Sub

End Class