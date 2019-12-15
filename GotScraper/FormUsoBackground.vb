Public Class FormUsoBackground
    Private Sub FormUsoBackground_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim imgTop As New Bitmap(716, 113)
        Dim imgTopFile As New Bitmap("D:\Progetti\VB\GotScraper\Materiale\Immagini\top-bg-arcade.jpg")
        Dim imgCenterFile As New Bitmap("D:\Progetti\VB\GotScraper\Materiale\Immagini\bg-arcade-4.png")
        Dim imgBottomFile As New Bitmap("D:\Progetti\VB\GotScraper\Materiale\Immagini\bottom-bg-arcade.jpg")
        Dim imgCenter As New Bitmap(1688, 100)
        Dim imgBottom As New Bitmap(716, 146)
        Dim imgFinale As New Bitmap(1280, 800)

        Dim g As Graphics = Graphics.FromImage(imgFinale)
        Dim gt As Graphics = Graphics.FromImage(imgTop)
        Dim gb As Graphics = Graphics.FromImage(imgBottom)
        Dim gc As Graphics = Graphics.FromImage(imgCenter)

        Dim layoutBG As Integer = 0

        gt.DrawImage(imgTopFile, 0, 0, imgTop.Size.Width + 1, imgTop.Size.Height + 1)
        gb.DrawImage(imgBottomFile, 0, 0, imgBottom.Size.Width + 1, imgBottom.Size.Height + 1)
        gc.DrawImage(imgCenterFile, 0, 0, imgCenter.Size.Width + 1, imgCenter.Size.Height + 1)

        Select Case layoutBG
            Case 1
                For i As Integer = 0 To Int(imgFinale.Size.Height / imgCenter.Size.Height)
                    g.DrawImage(imgCenter, New Point(Int((1280 - imgCenter.Size.Width) / 2), i * imgCenter.Size.Height))
                Next

                g.DrawImage(imgTop, New Point(Int((1280 - imgTop.Size.Width) / 2), 0))
                g.DrawImage(imgBottom, New Point(Int((1280 - imgBottom.Size.Width) / 2), 800 - imgBottom.Size.Height))
            Case 2
                For i As Integer = 0 To Int(imgFinale.Size.Height / imgCenter.Size.Height)
                    g.DrawImage(imgCenter, New Point(Int((1280 - imgCenter.Size.Width) / 2 + 280), i * imgCenter.Size.Height))
                Next

                g.DrawImage(imgTop, New Point(Int((1280 - imgTop.Size.Width)), 0))
                g.DrawImage(imgBottom, New Point(Int((1280 - imgBottom.Size.Width)), 800 - imgBottom.Size.Height))
            Case 3

            Case Else

        End Select


        g.Dispose()
        g = Nothing

        imgFinale.Save("test.bmp")
    End Sub
End Class