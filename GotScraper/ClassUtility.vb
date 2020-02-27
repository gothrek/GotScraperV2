Imports System.Security.Cryptography
Imports System.Text
Imports System.Drawing.Imaging

Public Class ClassUtility
    Public Shared Function GetCRC32(ByVal fileName As String) As String
        Try
            Dim FS As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
            Dim CRC32Result As Integer = &HFFFFFFFF
            Dim Buffer(4096) As Byte
            Dim ReadSize As Integer = 4096
            Dim Count As Integer = FS.Read(Buffer, 0, ReadSize)
            Dim CRC32Table(256) As Integer
            Dim DWPolynomial As Integer = &HEDB88320
            Dim DWCRC As Integer
            Dim i As Integer, j As Integer, n As Integer

            'Create CRC32 Table
            For i = 0 To 255
                DWCRC = i
                For j = 8 To 1 Step -1
                    If (DWCRC And 1) Then
                        DWCRC = ((DWCRC And &HFFFFFFFE) \ 2&) And &H7FFFFFFF
                        DWCRC = DWCRC Xor DWPolynomial
                    Else
                        DWCRC = ((DWCRC And &HFFFFFFFE) \ 2&) And &H7FFFFFFF
                    End If
                Next j
                CRC32Table(i) = DWCRC
            Next i

            'Calcualting CRC32 Hash
            Do While (Count > 0)
                For i = 0 To Count - 1
                    n = (CRC32Result And &HFF) Xor Buffer(i)
                    CRC32Result = ((CRC32Result And &HFFFFFF00) \ &H100) And &HFFFFFF
                    CRC32Result = CRC32Result Xor CRC32Table(n)
                Next i
                Count = FS.Read(Buffer, 0, ReadSize)
            Loop

            FS.Dispose()

            Return Hex(Not (CRC32Result))

        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Shared Function GetMD5(ByVal fileName As String) As String
        Dim md5Hash As MD5 = MD5.Create()
        Dim data As Byte() '= md5Hash.ComputeHash(Encoding.UTF8.GetBytes(Input))
        Dim sBuilder = New StringBuilder


        Using st As New IO.FileStream(fileName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            data = md5Hash.ComputeHash(st)
        End Using

        For Each b In data
            sBuilder.Append(b.ToString("X2"))
        Next


        'For i = 0 To data.Length - 1
        '    sBuilder.Append(data(i).ToString("x2"))
        'Next

        md5Hash.Dispose()

        Return sBuilder.ToString

    End Function

    Public Shared Function ChangeOpacity(ByVal img As Image, ByVal opacityvalue As Single) As Bitmap

        Dim bmp As New Bitmap(img.Width, img.Height)
        Dim graphics__1 As Graphics = Graphics.FromImage(bmp)
        Dim colormatrix As New ColorMatrix With {
            .Matrix33 = opacityvalue
        }

        Dim imgAttribute As New ImageAttributes

        imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
        graphics__1.DrawImage(img, New Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute)
        graphics__1.Dispose()

        Return bmp
    End Function

    Public Shared Function GetBitmap(ByVal pCtrl As Control) As Drawing.Bitmap
        Dim myBmp As New Bitmap(pCtrl.Width, pCtrl.Height)
        Dim g As Graphics = Graphics.FromImage(myBmp)
        Dim pt As Point = pCtrl.Parent.PointToScreen(pCtrl.Location)
        g.CopyFromScreen(pt, Point.Empty, myBmp.Size)
        g.Dispose()
        Return myBmp
    End Function

    Public Shared Function GetControlImage(ByVal ctl As Control) As Bitmap
        Dim bm As New Bitmap(ctl.Width, ctl.Height)
        ctl.DrawToBitmap(bm, New Rectangle(0, 0, ctl.Width, ctl.Height))
        Return bm
    End Function

    Public Shared Function ResizeImage(ByVal InputImage As Image, w As Integer, h As Integer) As Image
        Return New Bitmap(InputImage, New Size(w, h))
    End Function
End Class
