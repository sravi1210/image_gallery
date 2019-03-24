Imports System.IO
Public Class Form1
    Dim Images(1000) As String     'Image Array to store the image paths globally

    Dim Length As Integer = 0       'Length of the image list

    Dim Index As Integer = 0        'Current Index for the images array

    Dim TotalIndex As Integer = 0
    Dim it As Integer = -1
    Private Sub btnbrowse_Click(sender As Object, e As EventArgs) Handles btnbrowse.Click   'Browse button click function
        While Me.Controls.Count > 14         'Loop to clear screen and add new images
            RemovePictureBoxes(Me)
            RemoveLabels(Me)
        End While
        Length = 0              'length of the images array
        TotalIndex = 0
        SlideShow.Visible = False    'All different components that are not needed first
        Button1.Visible = False
        Button2.Visible = False
        Button6.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        Dim fd As FolderBrowserDialog = New FolderBrowserDialog()    'folderBrowseDialog for Browse button event
        If fd.ShowDialog() = DialogResult.OK Then
            Me.TextBox1.Text = fd.SelectedPath    'Path of the browse button copied in TextBox1 for further use
        End If
        If Me.RadioButton2.Checked = True Then      'If Radiobutton2 is selected
            RadioButton1.Enabled = False
            RadioButton3.Enabled = False
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
            Dim extensions As String = ".jpeg.bmp.png.gif.jpg.tiff"     'all extensions of images known
            Dim count As Integer = 0
            If Directory.Exists(TextBox1.Text) Then              'if directory exists
                For Each img As String In IO.Directory.GetFiles(TextBox1.Text)    'loop through all files in there 
                    If extensions.Contains(IO.Path.GetExtension(img).ToLower) Then   'if the file extension matches with extensions variable
                        Images(Index) = img                 'put image path in the array
                        count = count + 1
                        Index = Index + 1
                        TotalIndex = TotalIndex + 1
                    End If
                Next
                If count = 0 Then                         'if no images in the folder
                    MessageBox.Show("Sorry ! No Images In The Gallery")
                    RadioButton1.Enabled = True
                    RadioButton3.Enabled = True
                    RadioButton2.Enabled = True
                    Button3.Visible = False
                    Button4.Visible = False
                    Button5.Visible = False
                Else
                    Index = 0                          'if path entered is incorrect
                    Button4.PerformClick()
                End If
            Else
                If TextBox1.Text <> "" Then               'if no path is entered
                    MessageBox.Show("Sorry! You Entered Wrong Path")
                End If
                Button5.Visible = False
                Button4.Visible = False
                Button3.Visible = False
                Button6.Visible = False
                RadioButton1.Enabled = True
                RadioButton3.Enabled = True
                RadioButton2.Enabled = True
            End If

        ElseIf Me.RadioButton1.Checked = True Then           'if radiobutton1 is selected then
            RadioButton2.Enabled = False
            RadioButton3.Enabled = False
            it = -1
            Dim Imgcount As Integer = 0           'imgcount to store the count of the no of images
            Dim path As String = Me.TextBox1.Text     'taking the string present in Textbox1
            Dim imglist As ImageList = New ImageList()
            Dim extensions As String = ".jpeg.bmp.png.gif.jpg.tiff"    'all extensions of images 
            If Directory.Exists(TextBox1.Text) Then               'if directory exists
                For Each img As String In IO.Directory.GetFiles(TextBox1.Text)  'loop through all images in the folder
                    If extensions.Contains(IO.Path.GetExtension(img).ToLower) Then    'if file has same extension as extensions variable
                        Images(Imgcount) = img    'adding image to the image array
                        Imgcount = Imgcount + 1
                        Length = Length + 1
                    End If
                Next
                If Imgcount = 0 Then         'if no images are present in the gallery
                    MessageBox.Show("Sorry ! No Images In The Gallery")
                    RadioButton1.Enabled = True
                    RadioButton3.Enabled = True
                    RadioButton2.Enabled = True
                    Button3.Visible = False
                    Button4.Visible = False
                    Button5.Visible = False
                Else                           'if path is incorrect
                    SlideShow.Visible = True
                    Button1.Visible = True
                    Button2.Visible = True
                    Button3.Visible = True
                    Button6.Visible = True
                    Button2.PerformClick()
                    Me.Timer1.Interval = TimeSpan.FromSeconds(2).TotalMilliseconds  'timer1 is active now to automatically slidesjow images
                    Me.Timer1.Start()             'timer1 starts 
                End If
            Else
                If TextBox1.Text <> "" Then        'if nothing entered in the Textbox1 and pressed enter
                    MessageBox.Show("Sorry! You Entered Wrong Path")
                End If
                Button5.Visible = False
                Button4.Visible = False
                Button3.Visible = False
                Button6.Visible = False
                RadioButton1.Enabled = True
                RadioButton3.Enabled = True
                RadioButton2.Enabled = True
            End If

        ElseIf Me.RadioButton3.Checked = True Then    'if radiobutton3 is checked then
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
            Dim extensions As String = ".jpeg.bmp.png.gif.jpg.tiff"    'file extension matches with the extensions variable
            Dim var As Integer = 50
            Dim curwidth As Integer = 50
            Dim var2 As Integer = 70
            Dim count As Integer = 0
            Dim i As Integer = 0
            If Directory.Exists(TextBox1.Text) Then     'if directory exists
                For Each img As String In IO.Directory.GetFiles(TextBox1.Text)  'loop through images in the folder
                    If extensions.Contains(IO.Path.GetExtension(img).ToLower) Then  'if extension of the file matches with the extensions variable
                        Images(Index) = img      'append in the image array
                        count = count + 1
                        Index = Index + 1
                        TotalIndex = TotalIndex + 1
                    End If
                Next
                If count = 0 Then          'if no images in the folder
                    If TextBox1.Text <> "" Then    'if textbox1 is empty then
                        MessageBox.Show("Sorry! You Entered Wrong Path")
                    End If
                    RadioButton1.Enabled = True
                    RadioButton3.Enabled = True
                    RadioButton2.Enabled = True
                    Button3.Visible = False
                    Button4.Visible = False
                    Button5.Visible = False
                Else
                    Index = 0
                    Button4.PerformClick()
                End If
            Else                    'if wrong path is entered 
                MessageBox.Show("Sorry! You Entered Wrong Path")
                Button5.Visible = False
                Button4.Visible = False
                Button3.Visible = False
                Button6.Visible = False
                RadioButton1.Enabled = True
                RadioButton3.Enabled = True
                RadioButton2.Enabled = True
            End If
        End If
    End Sub
    Private Sub pic_Click(ByVal sender As Object, ByVal e As EventArgs)   'handler to execute when a image is clicked in thumbnail form
        Dim pc As PictureBox = DirectCast(sender, PictureBox)    'direct cast to take information of the image path clicked
        Form2.PictureBox1.ImageLocation = pc.ImageLocation         'set the picture box of the form2 then
        Form2.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        Form2.Height = 700
        Form2.Width = 900
        Form2.Panel1.Left = 100
        Form2.Panel1.Top = 100
        Form2.PictureBox1.BackColor = Color.Black
        Form2.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        Form2.Show()      'show form2 then
    End Sub
    Private Sub lb_Click(ByVal sender As Object, ByVal e As EventArgs)      'handler to execute when a image is clicked in thumbnail form
        Dim pc As PictureBox = DirectCast(sender, PictureBox)     'direct cast to take info about the image path clicked 
        Form2.PictureBox1.ImageLocation = pc.ImageLocation       'again the same step as pic_click
        Form2.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        Form2.Height = 700
        Form2.Width = 900
        Form2.Panel1.Left = 100
        Form2.Panel1.Top = 100
        Form2.PictureBox1.BackColor = Color.Black
        Form2.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        Form2.Show()     'form2 show then
    End Sub
    Public Sub RemovePictureBoxes(tp As Form)        'function to remove Pictureboxes from the screen
        Dim pbs = tp.Controls.OfType(Of Label)().
                   Where(Function(pb) pb.Name.Contains("x"))  'select all controls with name = x
        For Each pb In pbs
            tp.Controls.Remove(pb)   'remove those controls
        Next
    End Sub
    Public Sub RemoveLabels(tp As Form)                  'functions to remove labels 
        Dim pbs = tp.Controls.OfType(Of PictureBox)().
                   Where(Function(pb) pb.Name.Contains("PictureBox"))     'select all controls with name pictureboxes
        For Each pb In pbs
            tp.Controls.Remove(pb)    'remove all those controls
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click   'Next Button for the slideshow
        Button1.Enabled = True
        Dim incp As String
        incp = +1      'increment by 1 and then that image is shown
        it += 1
        SlideShow.ImageLocation = Images(it)
        SlideShow.SizeMode = PictureBoxSizeMode.Zoom
        If it = Length - 1 Then   'boundary case : here image is revolved back to image(0)
            it = -1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click   'Prev button for the slideshow
        Dim incp As String
        incp = +1
        it += 1    'again increment by 1 and then that image is displayed
        SlideShow.ImageLocation = Images(it)
        SlideShow.SizeMode = PictureBoxSizeMode.Zoom
        If it = Length - 1 Then    'boundary case : here image is revolved back to image(0)
            it = -incp
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick    'function to handle timer_tick
        Button1.PerformClick()   'call button3 click event
    End Sub
    Private Sub Pic_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)   'Mouse up function on the images in the thumbnail form
        Dim pc As PictureBox = DirectCast(sender, PictureBox)   'direct cast to retrieve info about image
        pc.SizeMode = PictureBoxSizeMode.Zoom
        If e.Button <> Windows.Forms.MouseButtons.Right Then Return 'if click is rightclick
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Save")   'added different options
        item1.Tag = 1
        AddHandler item1.Click, AddressOf menuChoice    'adding handles for the event
        Dim item2 = cms.Items.Add("Rename")
        item2.Tag = 2
        AddHandler item2.Click, AddressOf menuChoice
        cms.Show(pc, e.Location)
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)   'menu choice of the right click on the thumbnail images
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If item.ToString = "Save" Then
            Dim DestPath As String = "C:\Users\Lenovo\Documents\Downloads\images2"
        End If
    End Sub
    Private Sub pic_leave(ByVal sender As Object, ByVal e As EventArgs)   'Hover effect on the thumbnail images
        Dim pf As PictureBox = DirectCast(sender, PictureBox)  'direct cast to get info about the hovered image
        pf.Width = 200
        pf.Height = 150
    End Sub
    Private Sub pic_hover(ByVal sender As Object, ByVal e As EventArgs)  'hover effect on the thumbnail images
        Dim pf As PictureBox = DirectCast(sender, PictureBox)     'directcast to get info about the hovered images
        pf.Height = pf.Height + 15
        pf.Width = pf.Width
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click  'Exit button event handler function
        SlideShow.Visible = False
        Button1.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        Button6.Visible = False
        RadioButton1.Enabled = True
        RadioButton3.Enabled = True
        RadioButton2.Enabled = True
        Timer1.Stop()      'timer stops if slide show was active
        TextBox1.Text = ""    'text box back to empty string
        While Me.Controls.Count > 14    'again clearing the screen of the gallery
            RemovePictureBoxes(Me)
            RemoveLabels(Me)
        End While
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click   'Next Button in the thumbnail
        Dim img As String
        While Me.Controls.Count > 14   'clear the screen for new images and pictureboxes
            RemovePictureBoxes(Me)
            RemoveLabels(Me)
        End While
        If RadioButton2.Checked = True Then   'if radiobutton2 is selected then
            Dim totalwidth As Integer = Me.Size.Width  'width of the form then
            Dim var As Integer = 50
            Dim curwidth As Integer = 50
            Dim var2 As Integer = 90
            Dim count As Integer = 0
            Dim i As Integer = 0
            If Index + 8 <= TotalIndex - 1 Then   'if next 9 images are present then
                Dim j As Integer = 0
                For j = Index To Index + 8   'loop through those 9 images
                    img = Images(j)
                    Dim pb As New PictureBox     'create a dynamic picturebox
                    pb.Name = "PictureBox" + j.ToString
                    i = i + 1
                    pb.Width = 200
                    pb.Height = 150
                    pb.Top = var2
                    count = count + 1
                    pb.Left = var
                    var = var + 210
                    pb.BorderStyle = BorderStyle.FixedSingle
                    pb.BackColor = Color.Black
                    curwidth = curwidth + 210
                    If curwidth + 250 >= totalwidth Then   'boundary case : when image width exceeds screen width then revert to next row
                        count = 0
                        var2 = var2 + 170
                        var = 50
                        curwidth = 50
                    End If
                    pb.ImageLocation = img
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    Me.Controls.Add(pb)              'add control to the form
                    AddHandler pb.Click, AddressOf pic_Click   'adding handler for click event on the pictureboxes
                    AddHandler pb.MouseDown, AddressOf Pic_MouseUp   'adding handler for hover event on the pictureboxes
                    AddHandler pb.MouseHover, AddressOf pic_hover    'adding handler for hover event on the pictureboxes
                    AddHandler pb.MouseLeave, AddressOf pic_leave    'adding handler for mouse leave on the pictureboxes
                Next
                Index = Index + 9                      'update the global index variable
            Else                                          'else if less than 9 images present
                Dim j As Integer = 0
                For j = Index To TotalIndex - 1      'loop through the images and same as If part
                    img = Images(j)
                    Dim pb As New PictureBox
                    pb.Name = "PictureBox" + i.ToString
                    i = i + 1
                    pb.Width = 200
                    pb.Height = 150
                    pb.Top = var2
                    count = count + 1
                    pb.Left = var
                    var = var + 210
                    pb.BorderStyle = BorderStyle.FixedSingle
                    pb.BackColor = Color.Black
                    curwidth = curwidth + 210
                    If curwidth + 250 >= totalwidth Then
                        count = 0
                        var2 = var2 + 170
                        var = 50
                        curwidth = 50
                    End If
                    pb.ImageLocation = img
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    Me.Controls.Add(pb)
                    AddHandler pb.Click, AddressOf pic_Click
                    AddHandler pb.MouseDown, AddressOf Pic_MouseUp
                    AddHandler pb.MouseHover, AddressOf pic_hover
                    AddHandler pb.MouseLeave, AddressOf pic_leave
                Next
                Index = TotalIndex + 1      'update the global index variable
            End If
        ElseIf RadioButton3.Checked = True Then   'If Radio button3 is selected same sunction as Radiobutton2
            Dim var As Integer = 50
            Dim curwidth As Integer = 50
            Dim var2 As Integer = 70
            Dim count As Integer = 0
            Dim i As Integer = 0
            If Index + 8 <= TotalIndex - 1 Then
                Dim j As Integer = 0
                For j = Index To Index + 8
                    img = Images(j)
                    Dim pb As New PictureBox
                    pb.Name = "PictureBox" + i.ToString
                    i = i + 1
                    pb.Width = 50
                    pb.Height = 50
                    pb.Top = var2
                    count = count + 1
                    pb.Left = var
                    pb.BorderStyle = BorderStyle.FixedSingle
                    pb.BackColor = Color.Black
                    pb.ImageLocation = img
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    Dim lb As Label = New Label()
                    lb.Text = System.IO.Path.GetFileName(img)
                    lb.Top = var2 + 10
                    lb.Width = 300
                    lb.TextAlign = ContentAlignment.TopCenter
                    lb.BackColor = Color.Black
                    lb.ForeColor = Color.White
                    lb.Font = New Drawing.Font("Lucida Handwriting", _
                                                7.8, _
                                                FontStyle.Bold)
                    lb.Left = var + 60
                    var2 = var2 + 60
                    lb.Name = "x"
                    Me.Controls.Add(pb)   'Adding the controls in the form
                    Me.Controls.Add(lb)
                    AddHandler pb.Click, AddressOf lb_Click
                Next
                Index = Index + 9                  'update the global index variable
            ElseIf TotalIndex - Index >= 0 Then
                Dim j As Integer = 0
                For j = Index To TotalIndex - 1
                    img = Images(j)
                    Dim pb As New PictureBox
                    pb.Name = "PictureBox" + i.ToString
                    i = i + 1
                    pb.Width = 50
                    pb.Height = 50
                    pb.Top = var2
                    count = count + 1
                    pb.Left = var
                    pb.BorderStyle = BorderStyle.FixedSingle
                    pb.BackColor = Color.Black
                    pb.ImageLocation = img
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    Dim lb As Label = New Label()
                    lb.Text = System.IO.Path.GetFileName(img)
                    lb.Top = var2 + 10
                    lb.Width = 300
                    lb.TextAlign = ContentAlignment.TopCenter
                    lb.BackColor = Color.Black
                    lb.ForeColor = Color.White
                    lb.Font = New Drawing.Font("Lucida Handwriting", _
                                                7.8, _
                                                FontStyle.Bold)
                    lb.Left = var + 60
                    var2 = var2 + 60
                    lb.Name = "x"
                    Me.Controls.Add(pb)
                    Me.Controls.Add(lb)
                    AddHandler pb.Click, AddressOf lb_Click   'Event handler for the image click in list form
                Next
                Index = TotalIndex + 1       'update the global index variable
            End If
        End If
    End Sub
    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter   'Drag and drop in the slideshow
        If e.Data.GetDataPresent(DataFormats.FileDrop, False) = True Then   'if dragged file path takem
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop   'when drag image is dropped in the form
        Dim newImg As String() = e.Data.GetData(DataFormats.FileDrop)   'taking path of the image dropped
        Dim extensions As String = ".jpeg.bmp.png.gif.jpg.tiff"
        For Each Path In newImg
            If Directory.Exists(Path) Then     'checking if dragged file is not a folder
                Dim d As Integer = 0
            ElseIf extensions.Contains(IO.Path.GetExtension(Path).ToLower) Then   'checking if the file is image and not other ones
                Images(TotalIndex) = Path
                TotalIndex = TotalIndex + 1
                Timer1.Stop()
                it = TotalIndex - 2
                Button2.PerformClick()
                Timer1.Start()
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click    'Prev Button in the thumbnail and list view form - Same implementation as The Next Button just with loop back
        Dim img As String
        While Me.Controls.Count > 14
            RemovePictureBoxes(Me)
            RemoveLabels(Me)
        End While
        If RadioButton2.Checked = True Then
            Dim totalwidth As Integer = Me.Size.Width
            Dim var As Integer = 50
            Dim curwidth As Integer = 50
            Dim var2 As Integer = 90
            Dim count As Integer = 0
            Dim i As Integer = 0
            If Index - 8 >= 0 Then
                Dim j As Integer = 0
                For j = Index - 8 To Index   'loop to go back
                    img = Images(j)
                    Dim pb As New PictureBox
                    pb.Name = "PictureBox" + j.ToString
                    i = i + 1
                    pb.Width = 200
                    pb.Height = 150
                    pb.Top = var2
                    count = count + 1
                    pb.Left = var
                    var = var + 210
                    pb.BorderStyle = BorderStyle.FixedSingle
                    pb.BackColor = Color.Black
                    curwidth = curwidth + 210
                    If curwidth + 250 >= totalwidth Then
                        count = 0
                        var2 = var2 + 170
                        var = 50
                        curwidth = 50
                    End If
                    pb.ImageLocation = img
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    Me.Controls.Add(pb)
                    AddHandler pb.Click, AddressOf pic_Click
                    AddHandler pb.MouseDown, AddressOf Pic_MouseUp
                    AddHandler pb.MouseHover, AddressOf pic_hover
                    AddHandler pb.MouseLeave, AddressOf pic_leave
                Next
                Index = Index - 8
            Else
                Dim j As Integer = 0
                For j = 0 To Index    'loop to go back
                    img = Images(j)
                    Dim pb As New PictureBox
                    pb.Name = "PictureBox" + i.ToString
                    i = i + 1
                    pb.Width = 200
                    pb.Height = 150
                    pb.Top = var2
                    count = count + 1
                    pb.Left = var
                    var = var + 210
                    pb.BorderStyle = BorderStyle.FixedSingle
                    pb.BackColor = Color.Black
                    curwidth = curwidth + 210
                    If curwidth + 250 >= totalwidth Then
                        count = 0
                        var2 = var2 + 170
                        var = 50
                        curwidth = 50
                    End If
                    pb.ImageLocation = img
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    Me.Controls.Add(pb)
                    AddHandler pb.Click, AddressOf pic_Click
                    AddHandler pb.MouseDown, AddressOf Pic_MouseUp
                    AddHandler pb.MouseHover, AddressOf pic_hover
                    AddHandler pb.MouseLeave, AddressOf pic_leave
                Next
                Index = 0
            End If
        ElseIf RadioButton3.Checked = True Then
            Dim var As Integer = 50
            Dim curwidth As Integer = 50
            Dim var2 As Integer = 70
            Dim count As Integer = 0
            Dim i As Integer = 0
            If Index - 8 >= 0 Then
                Dim j As Integer = 0
                For j = Index - 8 To Index  'loop to go back
                    img = Images(j)
                    Dim pb As New PictureBox
                    pb.Name = "PictureBox" + i.ToString
                    i = i + 1
                    pb.Width = 50
                    pb.Height = 50
                    pb.Top = var2
                    count = count + 1
                    pb.Left = var
                    pb.BorderStyle = BorderStyle.FixedSingle
                    pb.BackColor = Color.Black
                    pb.ImageLocation = img
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    Dim lb As Label = New Label()
                    lb.Text = img
                    lb.Top = var2 + 10
                    lb.Width = 300
                    lb.TextAlign = ContentAlignment.TopCenter
                    lb.BackColor = Color.Black
                    lb.ForeColor = Color.White
                    lb.Font = New Drawing.Font("Lucida Handwriting", _
                                                7.8, _
                                                FontStyle.Bold)
                    lb.Left = var + 60
                    var2 = var2 + 60
                    lb.Name = "x"
                    Me.Controls.Add(pb)
                    Me.Controls.Add(lb)
                    AddHandler pb.Click, AddressOf lb_Click
                Next
                Index = Index - 8
            Else
                Dim j As Integer = 0
                For j = 0 To Index   'loop to go back
                    img = Images(j)
                    Dim pb As New PictureBox
                    pb.Name = "PictureBox" + i.ToString
                    i = i + 1
                    pb.Width = 50
                    pb.Height = 50
                    pb.Top = var2
                    count = count + 1
                    pb.Left = var
                    pb.BorderStyle = BorderStyle.FixedSingle
                    pb.BackColor = Color.Black
                    pb.ImageLocation = img
                    pb.SizeMode = PictureBoxSizeMode.Zoom
                    Dim lb As Label = New Label()
                    lb.Text = img
                    lb.Top = var2 + 10
                    lb.Width = 300
                    lb.TextAlign = ContentAlignment.TopCenter
                    lb.BackColor = Color.Black
                    lb.ForeColor = Color.White
                    lb.Font = New Drawing.Font("Lucida Handwriting", _
                                                7.8, _
                                                FontStyle.Bold)
                    lb.Left = var + 60
                    var2 = var2 + 60
                    lb.Name = "x"
                    Me.Controls.Add(pb)
                    Me.Controls.Add(lb)
                    AddHandler pb.Click, AddressOf lb_Click
                Next
                Index = 0
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click  'Pause button for the slide-show
        If Button6.Text = "Pause" Then    'if text is Pause then
            Timer1.Stop()     'stop the timer
            Button6.Text = "Continue"  'change the button to continue
        Else
            Timer1.Start()     'timer starts when clicked again
            Button6.Text = "Pause"   'text chenged back to Pause when clicked again
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click   'Go button in the form1 event handler
        While Me.Controls.Count > 14    'loop to delete all existing pictureboxes and clear screen for new ones
            RemovePictureBoxes(Me)
            RemoveLabels(Me)
        End While
        Length = 0        'Length of the images array
        TotalIndex = 0    'Totalindex of the image array
        SlideShow.Visible = False
        Button1.Visible = False
        Button2.Visible = False
        Button6.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        If Me.RadioButton2.Checked = True Then 'if radiobutton2 is selected then
            RadioButton1.Enabled = False
            RadioButton3.Enabled = False
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
            Dim extensions As String = ".jpeg.bmp.png.gif.jpg.tiff"   'extensions of the images possible
            Dim count As Integer = 0
            If Directory.Exists(TextBox1.Text) Then   'if directory exists
                For Each img As String In IO.Directory.GetFiles(TextBox1.Text)   'loop through the images in the folder
                    If extensions.Contains(IO.Path.GetExtension(img).ToLower) Then  'if extension matches with the extensions variable
                        Images(Index) = img        'append the images in the image array
                        count = count + 1
                        Index = Index + 1
                        TotalIndex = TotalIndex + 1
                    End If
                Next
                If count = 0 Then                'if no images in the folder
                    MessageBox.Show("Sorry ! No Images In The Gallery")
                    RadioButton1.Enabled = True
                    RadioButton3.Enabled = True
                    RadioButton2.Enabled = True
                    Button3.Visible = False
                    Button4.Visible = False
                    Button5.Visible = False
                Else
                    Index = 0         'if images are present
                    Button4.PerformClick()
                End If
            Else
                If TextBox1.Text <> "" Then     'if textbox1 is not empty
                    MessageBox.Show("Sorry! You Entered Wrong Path")
                End If
                Button5.Visible = False
                Button4.Visible = False
                Button3.Visible = False
                Button6.Visible = False
                RadioButton1.Enabled = True
                RadioButton3.Enabled = True
                RadioButton2.Enabled = True
            End If

        ElseIf Me.RadioButton1.Checked = True Then   'if radiobutton1 is selected then
            RadioButton2.Enabled = False
            RadioButton3.Enabled = False
            it = -1
            Dim Imgcount As Integer = 0   'image count to count the no of images currently processed
            Dim path As String = Me.TextBox1.Text
            Dim imglist As ImageList = New ImageList()   'imagelist 
            Dim extensions As String = ".jpeg.bmp.png.gif.jpg.tiff"   'extension possible for the images
            If Directory.Exists(TextBox1.Text) Then       'if directory exists
                For Each img As String In IO.Directory.GetFiles(TextBox1.Text)  'loop through the images in the folder
                    If extensions.Contains(IO.Path.GetExtension(img).ToLower) Then  'if extension of the  file matches with the extensions variable
                        Images(Imgcount) = img      'append the images in the image
                        Imgcount = Imgcount + 1
                        Length = Length + 1
                    End If
                Next
                If Imgcount = 0 Then       'no images in the folder
                    MessageBox.Show("Sorry ! No Images In The Gallery")
                    RadioButton1.Enabled = True
                    RadioButton3.Enabled = True
                    RadioButton2.Enabled = True
                    Button3.Visible = False
                    Button4.Visible = False
                    Button5.Visible = False
                Else                       'if images is present
                    SlideShow.Visible = True
                    Button1.Visible = True
                    Button2.Visible = True
                    Button3.Visible = True
                    Button6.Visible = True
                    Button2.PerformClick()
                    Me.Timer1.Interval = TimeSpan.FromSeconds(2).TotalMilliseconds
                    Me.Timer1.Start()
                End If
            Else                             ' if incorrect path is givem
                If TextBox1.Text <> "" Then    'if textbox1 is empty
                    MessageBox.Show("Sorry! You Entered Wrong Path")
                End If
                Button5.Visible = False
                Button4.Visible = False
                Button3.Visible = False
                Button6.Visible = False
                RadioButton1.Enabled = True
                RadioButton3.Enabled = True
                RadioButton2.Enabled = True
            End If
        ElseIf Me.RadioButton3.Checked = True Then   'if radiobutton3 is selected then
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
            Dim extensions As String = ".jpeg.bmp.png.gif.jpg.tiff"   'extension variable to hold all extensions 
            Dim var As Integer = 50
            Dim curwidth As Integer = 50
            Dim var2 As Integer = 70
            Dim count As Integer = 0
            Dim i As Integer = 0
            If Directory.Exists(TextBox1.Text) Then            'if directory exists 
                For Each img As String In IO.Directory.GetFiles(TextBox1.Text)   'for loop to loop through all files in the folders
                    If extensions.Contains(IO.Path.GetExtension(img).ToLower) Then  'if extension matches with the extension variable
                        Images(Index) = img   'append images in the array
                        count = count + 1
                        Index = Index + 1
                        TotalIndex = TotalIndex + 1
                    End If
                Next
                If count = 0 Then    'if no images are present in the folder
                    MessageBox.Show("Sorry ! No Images In The Gallery")
                    RadioButton1.Enabled = True
                    RadioButton3.Enabled = True
                    RadioButton2.Enabled = True
                    Button3.Visible = False
                    Button4.Visible = False
                    Button5.Visible = False
                Else
                    Index = 0
                    Button4.PerformClick()
                End If
            Else             'if directory entered is incorrect then
                If TextBox1.Text <> "" Then  'if textbox1 is empty then
                    MessageBox.Show("Sorry! You Entered Wrong Path")
                End If
                Button5.Visible = False
                Button4.Visible = False
                Button3.Visible = False
                Button6.Visible = False
                RadioButton1.Enabled = True
                RadioButton3.Enabled = True
                RadioButton2.Enabled = True
            End If
        End If
    End Sub
End Class
