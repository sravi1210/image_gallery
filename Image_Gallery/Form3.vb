Public Class Form3

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = True
        Static i As Integer
        Dim incp As String
        incp = +1
        i += 1
        PictureBox1.Image = ImageList1.Images(i)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        If i = ImageList1.Images.Count - 1 Then
            i = -1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Static i As Integer
        Dim incp As String
        incp = +1
        i += 1
        PictureBox1.Image = ImageList1.Images(i)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        If i = ImageList1.Images.Count - 1 Then
            i = -incp
        End If
    End Sub
End Class