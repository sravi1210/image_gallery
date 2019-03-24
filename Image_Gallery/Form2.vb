Imports System.Drawing.Imaging

Public Class Form2
    Dim Path As String = ""   'Global variable to store Path of the  and Img to hold that Image
    Dim Img As Image

    Private Sub PictureBox_MouseWheel(sender As System.Object,
                             e As MouseEventArgs) Handles PictureBox1.MouseWheel         'Handling the Zoom In and Zoom Out in the picturbox
        If e.Delta <> 0 Then                    'if mouse if scrolled real ie maximize
            If e.Delta <= 0 Then
                If PictureBox1.Width < 200 And PictureBox1.Height < 200 Then Exit Sub 'minimum 500?
            Else
                If PictureBox1.Width > 604 And PictureBox1.Height < 752 Then Exit Sub 'maximum 2000?
            End If

            PictureBox1.Width += CInt(PictureBox1.Width * e.Delta / 1000)   'maximum width
            PictureBox1.Height += CInt(PictureBox1.Height * e.Delta / 1000)  'minimum width
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click   'Exit button in the form2
        Me.Close()      'close the form2
        Form1.TextBox1.Text = ""   'empty the textbox
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click   'Save option in the form2
        Dim curr As String = PictureBox1.ImageLocation      'current location of the image
        Dim filename As String = System.IO.Path.GetFileName(curr)     'extract the file-name from it
        Dim DestPath As String = "C:\" + filename    'hardcoded path to save image
        My.Computer.FileSystem.CopyFile(curr, DestPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        MessageBox.Show("Image Saved")   'message box to confirm user
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click   'Image filter for Sepia
        If Path = "" Then
            Path = PictureBox1.ImageLocation    'restoring the real image back
        End If
        Img = System.Drawing.Image.FromFile(Path)   'making image from its path
        Dim bmpImage As Bitmap 'Source '
        bmpImage = New Bitmap(Img)                  'converting the image to bitmap to access bits
        Dim cCurrColor As Color
        For iY As Integer = 0 To bmpImage.Height - 1      'looping through bits by bits to change rgb values
            For iX As Integer = 0 To bmpImage.Width - 1
                cCurrColor = bmpImage.GetPixel(iX, iY)
                Dim intAlpha As Integer = cCurrColor.A
                Dim intRed As Integer = cCurrColor.R
                Dim intGreen As Integer = cCurrColor.G
                Dim intBlue As Integer = cCurrColor.B
                Dim intSRed As Integer = CInt((0.393 * intRed + _
                   0.769 * intGreen + 0.189 * intBlue))
                Dim intSGreen As Integer = CInt((0.349 * intRed + _
                   0.686 * intGreen + 0.168 * intBlue))
                Dim intSBlue As Integer = CInt((0.272 * intRed + _
                   0.534 * intGreen + 0.131 * intBlue))
                If intSRed > 255 Then
                    intRed = 255
                Else
                    intRed = intSRed
                End If
                If intSGreen > 255 Then
                    intGreen = 255
                Else
                    intGreen = intSGreen
                End If
                If intSBlue > 255 Then
                    intBlue = 255
                Else
                    intBlue = intSBlue
                End If
                bmpImage.SetPixel(iX, iY, Color.FromArgb(intAlpha, _
                   intRed, intGreen, intBlue))
            Next
        Next
        PictureBox1.Image = bmpImage     'finally setting the image in the picturebox as the one edited

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click  'Image filter for grayScale
        If Path = "" Then
            Path = PictureBox1.ImageLocation      'restoring the real image back
        End If
        Img = System.Drawing.Image.FromFile(Path)     'making image from its path
        Dim iX As Integer
        Dim iY As Integer

        Dim bmpImage As Bitmap 'Source '

        bmpImage = New Bitmap(Img)

        Dim intPrevColor As Integer

        For iX = 0 To bmpImage.Width - 1             'looping through bits by bits to change rgb values

            For iY = 0 To bmpImage.Height - 1         'looping through bits by bits to change rgb values

                intPrevColor = (CInt(bmpImage.GetPixel(iX, iY).R) +
                   bmpImage.GetPixel(iX, iY).G +
                   bmpImage.GetPixel(iX, iY).B) \ 3

                bmpImage.SetPixel(iX, iY, _
                   Color.FromArgb(intPrevColor, intPrevColor, _
                   intPrevColor))

            Next iY

        Next iX

        PictureBox1.Image = bmpImage     'finally setting the image in the picturebox as the one edited
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Path = "" Then
            Path = PictureBox1.ImageLocation      'restoring the real image back
        End If
        Img = System.Drawing.Image.FromFile(Path)     'making image from its path
        Dim iaAttributes As New ImageAttributes
        Dim cmMatrix As New ColorMatrix

        cmMatrix.Matrix00 = -1 : cmMatrix.Matrix11 = -1 _
         : cmMatrix.Matrix22 = -1
        cmMatrix.Matrix40 = 1 : cmMatrix.Matrix41 = 1 _
         : cmMatrix.Matrix42 = 1

        iaAttributes.SetColorMatrix(cmMatrix)

        Dim bmpImage As Bitmap = Img

        Dim rect As New Rectangle(0, 0, bmpImage.Width, _
           bmpImage.Height)

        Dim graph As Graphics = Graphics.FromImage(bmpImage)

        graph.DrawImage(bmpImage, rect, rect.X, rect.Y, rect.Width, _
           rect.Height, GraphicsUnit.Pixel, iaAttributes)

        PictureBox1.Image = bmpImage    'finally setting the image in the picturebox as the one edited
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Path = "" Then
            Path = PictureBox1.ImageLocation     'restoring the real image back
        End If
        Img = System.Drawing.Image.FromFile(Path)     'making image from its path
        Dim tmpImage As Bitmap = New Bitmap(Img)    'converting the image to bitmap to access bits 
        Dim bmpImage As Bitmap = New Bitmap(Img)    'converting the image to bitmap to access bits

        Dim intWidth As Integer = tmpImage.Width
        Dim intHeight As Integer = tmpImage.Height

        Dim intOldX As Integer(,) = New Integer(,) {{-1, 0, 1}, _
           {-2, 0, 2}, {-1, 0, 1}}
        Dim intOldY As Integer(,) = New Integer(,) {{1, 2, 1}, _
           {0, 0, 0}, {-1, -2, -1}}

        Dim intR As Integer(,) = New Integer(intWidth - 1, _
           intHeight - 1) {}
        Dim intG As Integer(,) = New Integer(intWidth - 1, _
           intHeight - 1) {}
        Dim intB As Integer(,) = New Integer(intWidth - 1, _
           intHeight - 1) {}

        Dim intMax As Integer = 128 * 128

        For i As Integer = 0 To intWidth - 1      'looping through bits by bits to change rgb values

            For j As Integer = 0 To intHeight - 1    'looping through bits by bits to change rgb values

                intR(i, j) = tmpImage.GetPixel(i, j).R
                intG(i, j) = tmpImage.GetPixel(i, j).G
                intB(i, j) = tmpImage.GetPixel(i, j).B

            Next

        Next

        Dim intRX As Integer = 0
        Dim intRY As Integer = 0
        Dim intGX As Integer = 0
        Dim intGY As Integer = 0
        Dim intBX As Integer = 0
        Dim intBY As Integer = 0

        Dim intRTot As Integer
        Dim intGTot As Integer
        Dim intBTot As Integer

        For i As Integer = 1 To tmpImage.Width - 1 - 1

            For j As Integer = 1 To tmpImage.Height - 1 - 1

                intRX = 0
                intRY = 0
                intGX = 0
                intGY = 0
                intBX = 0
                intBY = 0

                intRTot = 0
                intGTot = 0
                intBTot = 0

                For width As Integer = -1 To 2 - 1       'looping through bits by bits to change rgb values
                    For height As Integer = -1 To 2 - 1      'looping through bits by bits to change rgb values
                        intRTot = intR(i + height, j + width)
                        intRX += intOldX(width + 1, height + 1) * intRTot
                        intRY += intOldY(width + 1, height + 1) * intRTot

                        intGTot = intG(i + height, j + width)
                        intGX += intOldX(width + 1, height + 1) * intGTot
                        intGY += intOldY(width + 1, height + 1) * intGTot

                        intBTot = intB(i + height, j + width)
                        intBX += intOldX(width + 1, height + 1) * intBTot
                        intBY += intOldY(width + 1, height + 1) * intBTot
                    Next
                Next
                If intRX * intRX + intRY * intRY > intMax OrElse
                   intGX * intGX + intGY * intGY > intMax OrElse
                   intBX * intBX + intBY * intBY > intMax Then

                    bmpImage.SetPixel(i, j, Color.Black)

                Else

                    bmpImage.SetPixel(i, j, Color.Transparent)

                End If

            Next

        Next

        PictureBox1.Image = bmpImage     'finally setting the image in the picturebox as the one edited

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Path = "" Then
            Path = PictureBox1.ImageLocation       'restoring the real image back
        End If
        Img = System.Drawing.Image.FromFile(Path)     'making image from its path
        Dim iX As Integer
        Dim iY As Integer

        Dim bmpImage As Bitmap 'Source '

        bmpImage = New Bitmap(Img)    'converting the image to bitmap to access bits

        Dim intPrevColor As Integer

        For iX = 0 To bmpImage.Width - 1        'looping through bits by bits to change rgb values

            For iY = 0 To bmpImage.Height - 1     'looping through bits by bits to change rgb values

                intPrevColor = (CInt(bmpImage.GetPixel(iX, iY).R) +
                   bmpImage.GetPixel(iX, iY).G +
                   bmpImage.GetPixel(iX, iY).B) \ 3

                bmpImage.SetPixel(iX, iY, _
                   Color.FromArgb(intPrevColor, intPrevColor, _
                   intPrevColor))

            Next iY

        Next iX

        Dim iaAttributes As New ImageAttributes

        Dim cmMatrix As New ColorMatrix

        cmMatrix.Matrix00 = -1 : cmMatrix.Matrix11 = -1 _
         : cmMatrix.Matrix22 = -1
        cmMatrix.Matrix40 = 1 : cmMatrix.Matrix41 = 1 _
         : cmMatrix.Matrix42 = 1

        iaAttributes.SetColorMatrix(cmMatrix)

        Dim rect As New Rectangle(0, 0, bmpImage.Width, _
           bmpImage.Height)

        Dim graph As Graphics = Graphics.FromImage(bmpImage)

        graph.DrawImage(bmpImage, rect, rect.X, rect.Y, rect.Width, _
           rect.Height, GraphicsUnit.Pixel, iaAttributes)

        PictureBox1.Image = bmpImage      'finally setting the image in the picturebox as the one edited
    End Sub
End Class