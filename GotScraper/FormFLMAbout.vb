Public Class FormFLMAbout
    Private Sub FormFLMAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(255, 219, 219, 181)
        LabelVersion.Text = System.String.Format(LabelVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
        LabelAuthor.Text = My.Application.Info.Copyright
    End Sub
End Class