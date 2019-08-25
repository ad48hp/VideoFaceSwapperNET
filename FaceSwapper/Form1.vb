Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading

Public Class Form1
    Public faceswaperzz As New List(Of FaceSwapperTM)
    Public imageexts As String() = {"jpg", "bmp", "png", "tiff", "tga"}
    Public videoexts As String() = {"avi", "mkv", "m4v", "wmv", "mov", "264", "ts", "mp4"}

    Public imageexts2 As New List(Of String)
    Public videoexts2 As New List(Of String)

    Public mybmpboi6901 As Bitmap
    Public mybmpboi6902 As Bitmap
    Public mybmpboi6903 As Bitmap
    Public mybmpboi6904 As Bitmap

    Public myfile1 As FileInfo
    Public myfile2 As FileInfo
    Public myfile3 As FileInfo
    Public myfile4 As FileInfo

    Public failedfirstone As Boolean
    Public failedsekkundone As Boolean

    Public curboxx91911 As TextBox

    Public curfejzfapper As FaceSwapperTM
    Public cursrc01 As Bitmap
    Public cursrc02 As Bitmap
    Public curresult03 As Bitmap
    Public curresult03err As Boolean

    Public mytimruzz As New Stopwatch

    Public shallstop As Boolean

    Private Sub ReadString(myrdr6991 As StreamReader, ByRef txtmymy As String)
        If Not myrdr6991.EndOfStream Then
            txtmymy = myrdr6991.ReadLine()
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim mywriter6969 As New StreamWriter("options")
        mywriter6969.WriteLine(TextBox1.Text)
        mywriter6969.WriteLine(TextBox2.Text)
        mywriter6969.WriteLine(TextBox3.Text)
        mywriter6969.WriteLine(TextBox4.Text)
        mywriter6969.WriteLine(CheckBox1.Checked.ToString())
        mywriter6969.WriteLine(CheckBox2.Checked.ToString())
        mywriter6969.WriteLine(CheckBox3.Checked.ToString())
        mywriter6969.WriteLine(CheckBox4.Checked.ToString())
        mywriter6969.WriteLine(CheckBox5.Checked.ToString())
        mywriter6969.WriteLine(TextBox6.Text)
        mywriter6969.WriteLine(TextBox7.Text)
        mywriter6969.WriteLine(CheckBox6.Checked.ToString())
        mywriter6969.WriteLine(TextBox8.Text)
        mywriter6969.WriteLine(TextBox9.Text)
        mywriter6969.WriteLine(CheckBox7.Checked.ToString())
        mywriter6969.WriteLine(TextBox11.Text)
        mywriter6969.WriteLine(TextBox12.Text)
        mywriter6969.WriteLine(TextBox13.Text)
        mywriter6969.WriteLine(CheckBox8.Checked.ToString())
        mywriter6969.WriteLine(CheckBox9.Checked.ToString())
        mywriter6969.WriteLine(CheckBox10.Checked.ToString())
        mywriter6969.WriteLine(CheckBox11.Checked.ToString())
        mywriter6969.WriteLine(TextBox10.Text)
        If ComboBox1.SelectedIndex > -1 Then
            mywriter6969.WriteLine(ComboBox1.SelectedIndex)
        Else
            mywriter6969.WriteLine("0")
        End If
        For Each myimgzz69 In imageexts2
            mywriter6969.WriteLine("@img " + myimgzz69)
        Next
        For Each myvidzz69 In videoexts2
            mywriter6969.WriteLine("@vid " + myvidzz69)
        Next
        mywriter6969.Close()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        PictureBox5.Location = New Point((TrackBar1.Value / TrackBar1.Maximum) * (PictureBox6.Location.X - PictureBox5.Size.Width), PictureBox5.Location.Y)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Process!" Then
            Button1.Text = "Stop"
            Button1.ForeColor = Color.LightYellow
            Button1.BackColor = Color.Blue
            shallstop = False
            Dim cancontinue As Boolean
            cancontinue = True
            TextBox1.Text = ProcessPath(TextBox1.Text)
            TextBox2.Text = ProcessPath(TextBox2.Text)
            TextBox3.Text = ProcessPath(TextBox3.Text)
            TextBox4.Text = ProcessPath(TextBox4.Text)
            TextBox8.Text = ProcessPath(TextBox8.Text)
            TextBox9.Text = ProcessPath(TextBox9.Text)
            If Not TextBox1.Text = "" AndAlso Not File.Exists(AbsolutePath(TextBox1.Text)) Then
                MessageBox.Show("Input file 1. apparently doesn't exists..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cancontinue = False
            End If
            If Not TextBox2.Text = "" AndAlso Not File.Exists(AbsolutePath(TextBox2.Text)) Then
                MessageBox.Show("Input file 2. apparently doesn't exists..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cancontinue = False
            End If
            If CheckBox4.Checked AndAlso Not Integer.TryParse(TextBox6.Text, 1) Then
                MessageBox.Show("Resize by X plane val. isn't an integer..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cancontinue = False
            End If
            If CheckBox5.Checked AndAlso Not Integer.TryParse(TextBox7.Text, 1) Then
                MessageBox.Show("Resize by Y plane val. isn't an integer..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cancontinue = False
            End If
            Dim šalsejv03 As Boolean
            šalsejv03 = True
            Dim šalsejv04 As Boolean
            šalsejv04 = True
            If Not TextBox3.Text = "" AndAlso File.Exists(AbsolutePath(TextBox3.Text)) Then
                Select Case ComboBox1.SelectedIndex
                    Case < 0
                        If MessageBox.Show("Output file 1. apparently exists.. Do you want to remove it ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.Yes Then
                            šalsejv03 = True
                        End If
                    Case 0
                        šalsejv03 = True
                        File.Delete(TextBox3.Text)
                    Case 1
                        šalsejv03 = False
                    Case 2
                        šalsejv03 = True
                End Select
            End If
            If Not TextBox4.Text = "" AndAlso File.Exists(AbsolutePath(TextBox4.Text)) Then
                Select Case ComboBox1.SelectedIndex
                    Case < 0
                        If MessageBox.Show("Output file 2. apparently exists.. Do you want to remove it ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) = DialogResult.Yes Then
                            šalsejv04 = True
                        End If
                    Case 0
                        šalsejv04 = True
                        File.Delete(TextBox4.Text)
                    Case 1
                        šalsejv04 = False
                    Case 2
                        šalsejv04 = True
                End Select
            End If
            'If Not File.Exists(TextBox3.Text) Then
            'MessageBox.Show("Output file 1. apparently doesn't exists..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'cancontinue = False
            'End If
            'If Not File.Exists(TextBox4.Text) Then
            'MessageBox.Show("Output file 2. apparently doesn't exists..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'cancontinue = False
            'End If
            If cancontinue Then
                If CheckBox3.Checked Then
                    TextBox5.Text = ""
                End If
                Dim shallusetempšit6969 As Boolean
                shallusetempšit6969 = True
                If Not TextBox1.Text = "" Then
                    myfile1 = New FileInfo(TextBox1.Text)
                    If Not (imageexts.Contains(ParseExt(myfile1.Extension)) OrElse imageexts2.Contains(ParseExt(myfile1.Extension)) OrElse videoexts.Contains(ParseExt(myfile1.Extension)) OrElse videoexts2.Contains(ParseExt(myfile1.Extension))) Then
                        Dim dazzrezzultzz As String
                        dazzrezzultzz = CustomMssggBox("This extension seems to be unknown for the software.. Do you want to use it as an image or video ext. ?", New String() {"Image", "Video"})
                        If dazzrezzultzz = "Image" Then
                            imageexts2.Add(ParseExt(myfile1.Extension))
                        End If
                        If dazzrezzultzz = "Video" Then
                            videoexts2.Add(ParseExt(myfile1.Extension))
                        End If
                    End If
                    If (imageexts.Contains(ParseExt(myfile1.Extension)) OrElse imageexts2.Contains(ParseExt(myfile1.Extension))) Then
                        Using myzztream1 As New FileStream(TextBox1.Text, FileMode.Open)
                            mybmpboi6901 = New Bitmap(myzztream1)
                        End Using
                    End If
                End If
                If Not TextBox2.Text = "" Then
                    myfile2 = New FileInfo(TextBox2.Text)
                    If Not (imageexts.Contains(ParseExt(myfile2.Extension)) OrElse imageexts2.Contains(ParseExt(myfile2.Extension)) OrElse videoexts.Contains(ParseExt(myfile2.Extension)) OrElse videoexts2.Contains(ParseExt(myfile2.Extension))) Then
                        Dim dazzrezzultzz As String
                        dazzrezzultzz = CustomMssggBox("This extension seems to be unknown for the software.. Do you want to use it as an image or video ext. ?", New String() {"Image", "Video"})
                        If dazzrezzultzz = "Image" Then
                            imageexts2.Add(ParseExt(myfile2.Extension))
                        End If
                        If dazzrezzultzz = "Video" Then
                            videoexts2.Add(ParseExt(myfile2.Extension))
                        End If
                    End If
                    If (imageexts.Contains(ParseExt(myfile2.Extension)) OrElse imageexts2.Contains(ParseExt(myfile2.Extension))) Then
                        Using myzztream2 As New FileStream(TextBox2.Text, FileMode.Open)
                            mybmpboi6902 = New Bitmap(myzztream2)
                        End Using
                    End If
                End If
                If Not TextBox1.Text = "" AndAlso Not TextBox2.Text = "" Then
                    'myfile3 = New FileInfo(TextBox3.Text)
                    'myfile4 = New FileInfo(TextBox4.Text)
                    If (imageexts.Contains(ParseExt(myfile1.Extension)) OrElse imageexts2.Contains(ParseExt(myfile1.Extension))) AndAlso (videoexts.Contains(ParseExt(myfile2.Extension)) OrElse videoexts2.Contains(ParseExt(myfile2.Extension))) Then
                        Dim myimg As String
                        Dim myvid As String
                        myimg = TextBox1.Text
                        myvid = TextBox2.Text
                        TextBox2.Text = myimg
                        TextBox1.Text = myvid
                        myfile1 = New FileInfo(TextBox1.Text)
                        myfile2 = New FileInfo(TextBox2.Text)
                    End If
                    If (imageexts.Contains(ParseExt(myfile1.Extension)) OrElse imageexts2.Contains(ParseExt(myfile1.Extension))) AndAlso (imageexts.Contains(ParseExt(myfile2.Extension)) OrElse imageexts2.Contains(ParseExt(myfile2.Extension))) Then
                        PictureBox1.Image = mybmpboi6901
                        PictureBox2.Image = mybmpboi6902
                        If Not shallstop Then
                            ProcessFSImgzz(True)
                        End If
                        If Not failedfirstone Then
                            PictureBox3.Image = mybmpboi6903
                        End If
                        If Not failedsekkundone Then
                            PictureBox4.Image = mybmpboi6904
                        End If
                        If Not TextBox3.Text = "" AndAlso šalsejv03 Then
                            mybmpboi6903.Save(PathWOOverridder(AbsolutePath(TextBox3.Text)))
                        End If
                        If Not TextBox4.Text = "" AndAlso šalsejv04 Then
                            mybmpboi6904.Save(PathWOOverridder(AbsolutePath(TextBox4.Text)))
                        End If
                        shallusetempšit6969 = False
                    End If
                    If (videoexts.Contains(ParseExt(myfile1.Extension)) OrElse videoexts2.Contains(ParseExt(myfile1.Extension))) OrElse (videoexts.Contains(ParseExt(myfile2.Extension)) OrElse videoexts2.Contains(ParseExt(myfile2.Extension))) Then
                        If Not shallstop Then
                            PrepareTemporaryPathzz()
                        End If
                        If Not shallstop Then
                            ExtractFFMPEG()
                        End If
                        If (imageexts.Contains(ParseExt(myfile2.Extension)) OrElse imageexts2.Contains(ParseExt(myfile2.Extension))) Then
                            Using myzztream2 As New FileStream(TextBox2.Text, FileMode.Open)
                                mybmpboi6902 = New Bitmap(myzztream2)
                            End Using
                        End If
                    End If
                End If
                If Not shallstop AndAlso shallusetempšit6969 Then
                    If Directory.Exists(AbsolutePath(TextBox8.Text)) Then
                        Dim icuntrm96 As Integer
                        icuntrm96 = 1
                        Dim icuntrm966 As Integer
                        icuntrm966 = 1
                        Dim reverzzdirekšn As Boolean
                        reverzzdirekšn = False
                        While Not shallstop AndAlso File.Exists(AbsolutePath(TextBox8.Text + "/1/" + icuntrm96.ToString() + ".png"))
                            If Not File.Exists(AbsolutePath(TextBox8.Text + "/3/" + icuntrm96.ToString() + ".png")) Then
                                Using myzztrýmboizz6969 As New FileStream(AbsolutePath(TextBox8.Text + "/1/" + icuntrm96.ToString() + ".png"), FileMode.Open)
                                    mybmpboi6901 = New Bitmap(myzztrýmboizz6969)
                                End Using
                                If TextBox2.Text = "" OrElse Not (imageexts.Contains(ParseExt(myfile2.Extension)) OrElse imageexts2.Contains(ParseExt(myfile2.Extension))) Then
                                    If Not File.Exists(AbsolutePath(TextBox8.Text + "/2/" + icuntrm96.ToString() + ".png")) Then
                                        If Not CheckBox11.Checked Then
                                            icuntrm966 = 0
                                        Else
                                            reverzzdirekšn = Not reverzzdirekšn
                                            If reverzzdirekšn Then
                                                icuntrm966 += -2
                                            Else
                                                icuntrm966 += 2
                                            End If
                                        End If
                                    End If
                                    Using myzztrýmboizz696981816969 As New FileStream(AbsolutePath(TextBox8.Text + "/2/" + icuntrm966.ToString() + ".png"), FileMode.Open)
                                        mybmpboi6902 = New Bitmap(myzztrýmboizz696981816969)
                                    End Using
                                    If Not reverzzdirekšn Then
                                        icuntrm966 += 1
                                    Else
                                        icuntrm966 += -1
                                    End If
                                End If
                                PictureBox1.Image = mybmpboi6901
                                PictureBox2.Image = mybmpboi6902
                                If Not shallstop Then
                                    ProcessFSImgzz(False)
                                End If
                                PictureBox3.Image = mybmpboi6903
                                If Not failedfirstone Then
                                    mybmpboi6903.Save(AbsolutePath(TextBox8.Text + "/3/" + icuntrm96.ToString() + ".png"))
                                End If
                            End If
                            icuntrm96 += 1
                        End While
                        If TextBox2.Text = "" OrElse Not (imageexts.Contains(ParseExt(myfile2.Extension)) OrElse imageexts2.Contains(ParseExt(myfile2.Extension))) Then
                            While Not shallstop AndAlso File.Exists(AbsolutePath(TextBox8.Text + "/2/" + icuntrm96.ToString() + ".png"))
                                If Not File.Exists(AbsolutePath(TextBox8.Text + "/4/" + icuntrm96.ToString())) Then
                                    Using myzztrýmboizz6969 As New FileStream(AbsolutePath(TextBox8.Text + "/2/" + icuntrm96.ToString() + ".png"), FileMode.Open)
                                        mybmpboi6901 = New Bitmap(myzztrýmboizz6969)
                                    End Using
                                    If Not File.Exists(AbsolutePath(TextBox8.Text + "/1/" + icuntrm96.ToString() + ".png")) Then
                                        If Not CheckBox11.Checked Then
                                            icuntrm966 = 0
                                        Else
                                            reverzzdirekšn = Not reverzzdirekšn
                                            If reverzzdirekšn Then
                                                icuntrm966 += -2
                                            Else
                                                icuntrm966 += 2
                                            End If
                                        End If
                                    End If
                                    Using myzztrýmboizz696981816969 As New FileStream(AbsolutePath(TextBox8.Text + "/1/" + icuntrm966.ToString() + ".png"), FileMode.Open)
                                        mybmpboi6902 = New Bitmap(myzztrýmboizz696981816969)
                                    End Using
                                    If Not reverzzdirekšn Then
                                        icuntrm966 += 1
                                    Else
                                        icuntrm966 += -1
                                    End If
                                    PictureBox1.Image = mybmpboi6901
                                    PictureBox2.Image = mybmpboi6902
                                    If Not shallstop Then
                                        ProcessFSImgzz(False)
                                    End If
                                    PictureBox3.Image = mybmpboi6903
                                    If Not failedfirstone Then
                                        mybmpboi6903.Save(AbsolutePath(TextBox8.Text + "/4/" + icuntrm96.ToString() + ".png"))
                                    End If
                                End If
                                icuntrm96 += 1
                            End While
                        End If
                    End If
                End If
                Button1.Text = "Process!"
                Button1.ForeColor = Color.Lime
                Button1.BackColor = Color.Red
            End If
        Else
            shallstop = True
        End If
    End Sub

    Private Function PathWOOverridder(xxxtx As String) As String
        If Not File.Exists(xxxtx) Then
            Return xxxtx
        Else
            Dim myinfo696969 As New FileInfo(xxxtx)
            Dim i024 As Integer
            i024 = 2
            While File.Exists(ProcessPath(myinfo696969.DirectoryName) + "/" + Path.GetFileNameWithoutExtension(xxxtx) + "_" + i024.ToString() + "/" + ParseExt(myinfo696969.Extension))
                i024 += 1
            End While
            Return ProcessPath(myinfo696969.DirectoryName) + "/" + Path.GetFileNameWithoutExtension(xxxtx) + "_" + i024.ToString() + "/" + ParseExt(myinfo696969.Extension)
        End If
    End Function

    Private Function CustomMssggBox(dzdzdztitluzz As String, dzdzdzbuttonzzz() As String) As String
        Dim mygettuzz As String
        Dim mywenboxzzz As New CustomMsgBox()
        mywenboxzzz.Label1.Text = dzdzdztitluzz
        mywenboxzzz.AddToButtonz(dzdzdzbuttonzzz)
        mywenboxzzz.ShowDialog()
        mygettuzz = mywenboxzzz.setto
        mywenboxzzz.Close()
        Return mygettuzz
    End Function

    Private Sub ExtractFFMPEG()
        Dim mytempdir1 As New DirectoryInfo(AbsolutePath(TextBox8.Text + "/1"))
        Dim mytempdir2 As New DirectoryInfo(AbsolutePath(TextBox8.Text + "/2"))
        Dim mytempdir3 As New DirectoryInfo(AbsolutePath(TextBox8.Text + "/3"))
        Dim mytempdir4 As New DirectoryInfo(AbsolutePath(TextBox8.Text + "/4"))
        Dim mahboikencontinue As Boolean
        mahboikencontinue = True
        If Not ((mytempdir1.GetFiles().Length = 0 AndAlso mytempdir1.GetDirectories().Length = 0) AndAlso (mytempdir2.GetFiles().Length = 0 AndAlso mytempdir2.GetDirectories().Length = 0) AndAlso (mytempdir3.GetFiles().Length = 0 AndAlso mytempdir3.GetDirectories().Length = 0) AndAlso (mytempdir4.GetFiles().Length = 0 AndAlso mytempdir4.GetDirectories().Length = 0)) Then
            Dim lastfirstelement As String
            Dim lastsecondelement As String
            Dim shallklýr As Boolean
            shallklýr = False
            If File.Exists(AbsolutePath("lastclearpatzz")) Then
                Dim myreadertmrc As New StreamReader(AbsolutePath("lastclearpatzz"))
                lastfirstelement = myreadertmrc.ReadLine()
                lastsecondelement = myreadertmrc.ReadLine()
                myreadertmrc.Close()
                If Not TextBox1.Text = lastfirstelement OrElse Not TextBox2.Text = lastsecondelement Then
                    If MessageBox.Show("Input paths have changed since last use.. Do you want to clear the last usage ? (otherwise attempt to continue w/ temp pathzz..)", "Undone job", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                        shallklýr = True
                    End If
                Else
                    mahboikencontinue = False
                End If
            Else
                If MessageBox.Show("Do you want to clear the last usage ? (otherwise attempt to continue w/ temp pathzz..)", "Undone job", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    shallklýr = True
                End If
            End If
            If shallklýr Then
                RemoveDirContentzz(AbsolutePath(TextBox8.Text + "/1"))
                RemoveDirContentzz(AbsolutePath(TextBox8.Text + "/2"))
                RemoveDirContentzz(AbsolutePath(TextBox8.Text + "/3"))
                RemoveDirContentzz(AbsolutePath(TextBox8.Text + "/4"))
            Else
                mahboikencontinue = False
            End If
        End If
        If Not File.Exists(AbsolutePath(TextBox9.Text)) Then
            MessageBox.Show("FFMPEG executable doesn't exist..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mahboikencontinue = False
        End If
        If mahboikencontinue Then
            Dim mywritruzzmtcr6969 As New StreamWriter(AbsolutePath("lastclearpatzz"))
            mywritruzzmtcr6969.WriteLine(AbsolutePath(TextBox1.Text))
            mywritruzzmtcr6969.WriteLine(AbsolutePath(TextBox2.Text))
            mywritruzzmtcr6969.Close()
            Dim myffboizz As New ProcessStartInfo
            myffboizz.FileName = AbsolutePath(TextBox9.Text)
            If (videoexts.Contains(ParseExt(myfile1.Extension)) OrElse videoexts2.Contains(ParseExt(myfile1.Extension))) Then
                SetFFArgumentzz(myffboizz, AbsolutePath(TextBox1.Text), AbsolutePath(TextBox8.Text + "/1"))
                ReadOutputProcessM9(myffboizz, TextBox14, True, True)
            End If
            If (videoexts.Contains(ParseExt(myfile2.Extension)) OrElse videoexts2.Contains(ParseExt(myfile1.Extension))) Then
                SetFFArgumentzz(myffboizz, AbsolutePath(TextBox2.Text), AbsolutePath(TextBox8.Text + "/2"))
                ReadOutputProcessM9(myffboizz, TextBox14, True, True)
            End If
        End If
    End Sub

    Private Sub ReadOutputProcessM9(dazzprocessuzz6969 As ProcessStartInfo, dztxtboxx As TextBox, readoutput As Boolean, readerr As Boolean)
        curboxx91911 = dztxtboxx
        If dazzprocessuzz6969.UseShellExecute Then
            dazzprocessuzz6969.UseShellExecute = False
        End If
        If readoutput Then
            dazzprocessuzz6969.RedirectStandardOutput = True
        End If
        If readerr Then
            dazzprocessuzz6969.RedirectStandardError = True
        End If
        Dim myprocc696969 As New Process
        myprocc696969.StartInfo = dazzprocessuzz6969
        If readoutput Then
            AddHandler myprocc696969.OutputDataReceived, AddressOf outputmrec6969
        End If
        If readerr Then
            AddHandler myprocc696969.OutputDataReceived, AddressOf errmrec6969
        End If
        myprocc696969.Start()
        If readoutput Then
            myprocc696969.BeginOutputReadLine()
        End If
        If readerr Then
            myprocc696969.BeginErrorReadLine()
        End If
        While Not myprocc696969.HasExited
            ApplicationDoEvents()
        End While
    End Sub

    Private Sub outputmrec6969(sender As Object, e As DataReceivedEventArgs)
        WriteToBox(curboxx91911, e.Data, True)
        curboxx91911.BeginInvoke(Sub() curboxx91911.SelectionStart = curboxx91911.Text.Length)
        curboxx91911.BeginInvoke(Sub() curboxx91911.SelectionLength = 0)
    End Sub

    Private Sub errmrec6969(sender As Object, e As DataReceivedEventArgs)
        WriteToBox(curboxx91911, e.Data, True)
        curboxx91911.BeginInvoke(Sub() curboxx91911.SelectionStart = curboxx91911.Text.Length)
        curboxx91911.BeginInvoke(Sub() curboxx91911.SelectionLength = 0)
    End Sub

    Private Sub WriteToBox(curboxx91911 As TextBox, mystrr6969 As String, addme6969 As Boolean)
        If curboxx91911.InvokeRequired Then
            Dim myinvokertmtm As New mahhinvkrboxxezz(AddressOf WriteToBox)
            Invoke(myinvokertmtm, New Object() {curboxx91911, mystrr6969, addme6969})
        Else
            If Not addme6969 Then
                curboxx91911.Text = mystrr6969
            Else
                curboxx91911.Text += mystrr6969
                curboxx91911.Text += Environment.NewLine
            End If
        End If
    End Sub

    Public Delegate Sub mahhinvkrboxxezz(curboxx91911 As TextBox, mystrr6969 As String, addme6969 As Boolean)

    Private Sub SetFFArgumentzz(myffboizz As ProcessStartInfo, mypazzboizz As String, mypazzputtboizz As String)
        myffboizz.Arguments = "-i " + ChrW(34) + mypazzboizz + ChrW(34) + " "
        Dim vfilterzz As String
        vfilterzz = ""
        If CheckBox8.Checked AndAlso CheckBox9.Checked Then
            vfilterzz = "scale=" + TextBox11.Text + ":" + TextBox12.Text + ","
        End If
        If CheckBox8.Checked AndAlso Not CheckBox9.Checked Then
            vfilterzz = "scale=" + TextBox11.Text + ":-1,"
        End If
        If Not CheckBox8.Checked AndAlso CheckBox9.Checked Then
            vfilterzz = "scale=-1:" + TextBox12.Text + ","
        End If
        If CheckBox10.Checked Then
            vfilterzz += "fps=" + TextBox13.Text + ","
        End If
        If Not vfilterzz = "" Then
            vfilterzz = vfilterzz.Substring(0, vfilterzz.Length - 1)
            myffboizz.Arguments += "-vf" + ChrW(34) + vfilterzz + ChrW(34) + " "
        End If
        myffboizz.Arguments += ChrW(34) + mypazzputtboizz + ChrW(34) + "/%01d.png"
    End Sub

    Private Sub RemoveDirContentzz(mycumtent As String)
        Dim myinfotmtm As New DirectoryInfo(mycumtent)
        Dim myfilezz As FileInfo()
        Dim mydirrzz As DirectoryInfo()
        myfilezz = myinfotmtm.GetFiles()
        mydirrzz = myinfotmtm.GetDirectories()
        For Each myfiletmtm In myfilezz
            File.Delete(myfiletmtm.FullName)
        Next
        For Each mydirboiitmtm In mydirrzz
            RemoveDirContentzz(mydirboiitmtm.FullName)
            'Directory.Delete(mydirboiitmtm.FullName)
        Next
    End Sub

    Private Sub PrepareTemporaryPathzz()
        If Not Directory.Exists(AbsolutePath(TextBox8.Text)) Then
            Directory.CreateDirectory(AbsolutePath(TextBox8.Text))
        End If
        If Not Directory.Exists(AbsolutePath(TextBox8.Text + "/1")) Then
            Directory.CreateDirectory(AbsolutePath(TextBox8.Text + "/1"))
        End If
        If Not Directory.Exists(AbsolutePath(TextBox8.Text + "/2")) Then
            Directory.CreateDirectory(AbsolutePath(TextBox8.Text + "/2"))
        End If
        If Not Directory.Exists(AbsolutePath(TextBox8.Text + "/3")) Then
            Directory.CreateDirectory(AbsolutePath(TextBox8.Text + "/3"))
        End If
        If Not Directory.Exists(AbsolutePath(TextBox8.Text + "/4")) Then
            Directory.CreateDirectory(AbsolutePath(TextBox8.Text + "/4"))
        End If
    End Sub

    Public Sub ProcessFSImgzz(procezzsekundimgboizz As Boolean)
        failedfirstone = False
        failedsekkundone = False
        Dim myfaceswappertmtm As FaceSwapperTM
        myfaceswappertmtm = faceswaperzz(ListBox1.SelectedIndex)
        myfaceswappertmtm.Prepare()
        Select Case myfaceswappertmtm.GetType()
            Case GetType(ComputerVision_BootCamp)
                DirectCast(myfaceswappertmtm, ComputerVision_BootCamp).Prepare2(AddressOf ProgrezzozČengddozz, TextBox10.Text)
                DirectCast(myfaceswappertmtm, ComputerVision_BootCamp).substractmatticezz01 = CheckBox12.Checked
        End Select
        Dim mybmpresizzzz1 As Bitmap
        Dim mybmpresizzzz2 As Bitmap
        If Not CheckBox4.Checked Then
            mybmpresizzzz1 = mybmpboi6901
            mybmpresizzzz2 = mybmpboi6902
        Else
            If Not CheckBox5.Checked Then
                mybmpresizzzz1 = ResizeImage(mybmpboi6901, New Point(TextBox6.Text, "-1"))
                mybmpresizzzz2 = ResizeImage(mybmpboi6902, New Point(TextBox6.Text, "-1"))
            Else
                mybmpresizzzz1 = ResizeImage(mybmpboi6901, New Point(TextBox6.Text, TextBox7.Text))
                mybmpresizzzz2 = ResizeImage(mybmpboi6902, New Point(TextBox6.Text, TextBox7.Text))
            End If
        End If
        mybmpresizzzz1 = ReformatImage(mybmpresizzzz1, PixelFormat.Format24bppRgb)
        mybmpresizzzz2 = ReformatImage(mybmpresizzzz2, PixelFormat.Format24bppRgb)
        curfejzfapper = myfaceswappertmtm
        If Not shallstop Then
            cursrc01 = mybmpresizzzz1
            cursrc02 = mybmpresizzzz2
            ProcessDzImage02(mybmpboi6903, failedfirstone)
        Else
            failedfirstone = True
        End If
        If Not shallstop Then
            If procezzsekundimgboizz Then
                cursrc01 = mybmpresizzzz2
                cursrc02 = mybmpresizzzz1
                ProcessDzImage02(mybmpboi6904, failedsekkundone)
            End If
        Else
            failedsekkundone = True
        End If
        For Each myex6969696996969696 In myfaceswappertmtm.Errors
            If CheckBox1.Checked Then
                TextBox5.Text += myex6969696996969696.StackTrace.ToString()
                TextBox5.Text += Environment.NewLine
            End If
            If CheckBox2.Checked Then
                TextBox5.Text += myex6969696996969696.Message.ToString()
                TextBox5.Text += Environment.NewLine
            End If
        Next
        If CheckBox6.Checked Then
            If Not failedfirstone Then
                mybmpboi6903 = ResizeImage(mybmpboi6903, New Point(mybmpboi6901.Width, mybmpboi6901.Height))
            End If
            If procezzsekundimgboizz Then
                If Not failedsekkundone Then
                    mybmpboi6904 = ResizeImage(mybmpboi6904, New Point(mybmpboi6902.Width, mybmpboi6902.Height))
                End If
            End If
        End If
    End Sub

    Public Sub ProcessDzImage02(ByRef dazzrezzultuzz69669969 As Bitmap, ByRef dazzerrorrzzuuzz699696966999 As Boolean)
        Dim mythread69 As New Thread(AddressOf ProcessDzImage)
        curresult03err = False
        mythread69.Start()
        While mythread69.ThreadState = ThreadState.Running
            ApplicationDoEvents()
        End While
        If Not curresult03err Then
            dazzrezzultuzz69669969 = curresult03
        End If
        dazzerrorrzzuuzz699696966999 = curresult03err
    End Sub

    Private Sub ApplicationDoEvents()
        mytimruzz.Reset()
        mytimruzz.Start()
        While Not mytimruzz.ElapsedMilliseconds > 200
        End While
        Application.DoEvents()
        mytimruzz.Stop()
    End Sub

    Public Sub ProcessDzImage()
        Try
            curresult03 = curfejzfapper.Process(cursrc01, cursrc02)
        Catch ex As Exception
            curresult03err = True
            WriteToBox(TextBox5, ex.StackTrace.ToString() + " " + ex.Message, True)
            TextBox5.BeginInvoke(Sub() TextBox5.SelectionStart = TextBox5.Text.Length)
            TextBox5.BeginInvoke(Sub() TextBox5.SelectionLength = 0)
        End Try
    End Sub

    Private Function AbsolutePath(mypattmtmtmtm As String) As String
        If mypattmtmtmtm.Contains(":") Then
            Return mypattmtmtmtm
        Else
            Return ProcessPath(Application.StartupPath) + "/" + mypattmtmtmtm
        End If
    End Function

    Private Function ProcessPath(mytxt6969696969696969 As String) As String
        Dim mydozztextuzz As String
        mydozztextuzz = mytxt6969696969696969.Replace("\", "/")
        While mydozztextuzz.EndsWith("/")
            mydozztextuzz = mydozztextuzz.Substring(0, mydozztextuzz.Length - 1)
        End While
        If Not mydozztextuzz.Contains(":") Then
            While mydozztextuzz.StartsWith("/")
                mydozztextuzz = mydozztextuzz.Substring(1, mydozztextuzz.Length - 1)
            End While
        End If
        Return mydozztextuzz
    End Function

    Private Function ReformatImage(mbtmp9191911991 As Bitmap, mahfurmatuzzzz As PixelFormat) As Bitmap
        Dim ngrtmtm As Graphics
        Dim bmooo66569 As Bitmap
        bmooo66569 = New Bitmap(mbtmp9191911991.Width, mbtmp9191911991.Height, mahfurmatuzzzz)
        ngrtmtm = Graphics.FromImage(bmooo66569)
        ngrtmtm.DrawImage(mbtmp9191911991, New Rectangle(0, 0, mbtmp9191911991.Width, mbtmp9191911991.Height), New Rectangle(0, 0, mbtmp9191911991.Width, mbtmp9191911991.Height), GraphicsUnit.Pixel)
        Return bmooo66569
    End Function

    Private Sub ProgrezzozČengddozz(curprogrezz As Integer, totalprogrezz As Integer)
        If Not TrackBar1.Maximum = totalprogrezz Then
            TrackBar1.BeginInvoke(Sub() TrackBar1.Maximum = totalprogrezz)
        End If
        TrackBar1.BeginInvoke(Sub() TrackBar1.Value = curprogrezz - 1)
    End Sub

    Public Delegate Sub nnoddrinvkrr96696969(myctl69 As Object, mynoncontt69 As String, mytyp As PFType, mydazzobjektuzz As Object)

    Private Function ParseExt(myext6969 As String) As String
        Return myext6969.ToLower().Replace(".", "")
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Shown
        faceswaperzz.Add(New ComputerVision_BootCamp())
        ListBox1.SelectedIndex = 0
        If File.Exists(Application.StartupPath + "/options") Then
            Dim myreader As New StreamReader("options")
            ReadString(myreader, TextBox1.Text)
            ReadString(myreader, TextBox2.Text)
            ReadString(myreader, TextBox3.Text)
            ReadString(myreader, TextBox4.Text)
            ReadBool(myreader, CheckBox1.Checked)
            ReadBool(myreader, CheckBox2.Checked)
            ReadBool(myreader, CheckBox3.Checked)
            ReadBool(myreader, CheckBox4.Checked)
            ReadBool(myreader, CheckBox5.Checked)
            ReadString(myreader, TextBox6.Text)
            ReadString(myreader, TextBox7.Text)
            ReadBool(myreader, CheckBox6.Checked)
            ReadString(myreader, TextBox8.Text)
            ReadString(myreader, TextBox9.Text)
            ReadBool(myreader, CheckBox7.Checked)
            ReadString(myreader, TextBox11.Text)
            ReadString(myreader, TextBox12.Text)
            ReadString(myreader, TextBox13.Text)
            ReadBool(myreader, CheckBox8.Checked)
            ReadBool(myreader, CheckBox9.Checked)
            ReadBool(myreader, CheckBox10.Checked)
            ReadBool(myreader, CheckBox11.Checked)
            ReadString(myreader, TextBox10.Text)
            ReadInteger(myreader, ComboBox1.SelectedIndex)
            While Not myreader.EndOfStream
                Dim mystr69696969 As String
                mystr69696969 = myreader.ReadLine()
                If mystr69696969.StartsWith("@") Then
                    Dim mystr911911 As String
                    mystr911911 = mystr69696969.Substring(1, mystr69696969.Length - 1)
                    Dim mystr42069 As String()
                    mystr42069 = mystr911911.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
                    Select Case mystr42069(0).Replace(" ", "")
                        Case "img"
                            imageexts2.Add(mystr42069(1).Replace(" ", ""))
                        Case "vid"
                            videoexts2.Add(mystr42069(1).Replace(" ", ""))
                    End Select
                End If
            End While
            myreader.Close()
        End If
        Dim mycontrols As New List(Of Control)
        mycontrols = GetControls(Me)
        For Each mycont In mycontrols
            If mycont Is GetType(TextBox) AndAlso DirectCast(mycont, TextBox).Multiline Then
                AddHandler mycont.KeyDown, AddressOf txteventz
            End If
        Next
    End Sub

    Private Sub ReadInteger(myrdr6991 As StreamReader, ByRef myvallzz As Integer)
        If Not myrdr6991.EndOfStream Then
            myvallzz = myrdr6991.ReadLine()
        End If
    End Sub

    Private Sub ReadBool(myrdr6991 As StreamReader, ByRef chkd As Boolean)
        If Not myrdr6991.EndOfStream Then
            chkd = myrdr6991.ReadLine()
        End If
    End Sub

    Private Sub TextBox1_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox4.DragEnter, TextBox3.DragEnter, TextBox2.DragEnter, TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub TextBox1_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox4.DragDrop, TextBox3.DragDrop, TextBox2.DragDrop, TextBox1.DragDrop
        Dim filezz As String() = e.Data.GetData(DataFormats.FileDrop)
        If filezz.Length = 1 Then
            DirectCast(sender, TextBox).Text = filezz(0)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Clipboard.SetText(TextBox5.Text)
    End Sub

    Private Sub txteventz(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            DirectCast(sender, TextBox).SelectionStart = 0
            DirectCast(sender, TextBox).SelectionLength = DirectCast(sender, TextBox).Text.Length
        End If
    End Sub

    Private Function GetControls(myctl As Control) As List(Of Control)
        Dim myctls As New List(Of Control)
        For Each mycon In myctl.Controls
            myctls.AddRange(GetControls(mycon))
            myctls.Add(mycon)
        Next
        Return myctls
    End Function

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        TextBox6.ReadOnly = Not CheckBox4.Checked
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        TextBox7.ReadOnly = Not CheckBox5.Checked
    End Sub

    Private Function ResizeImage(ByVal bmpmtmt As Bitmap, ByVal sztmtm As Point) As Bitmap
        Dim fnlsz As Point

        If sztmtm.X <= 0 Then
            fnlsz = New Point(Math.Floor(Double.Parse(sztmtm.Y) * Double.Parse(bmpmtmt.Width) / Double.Parse(bmpmtmt.Height)), sztmtm.Y)
        Else

            If sztmtm.Y <= 0 Then
                fnlsz = New Point(sztmtm.X, Math.Floor(Double.Parse(sztmtm.X) * Double.Parse(bmpmtmt.Height) / Double.Parse(bmpmtmt.Width)))
            Else
                fnlsz = sztmtm
            End If
        End If

        Dim ngrtmtm As Graphics
        Dim bmooo66569 As Bitmap
        bmooo66569 = New Bitmap(fnlsz.X, fnlsz.Y, bmpmtmt.PixelFormat)
        ngrtmtm = Graphics.FromImage(bmooo66569)
        ngrtmtm.DrawImage(bmpmtmt, New Rectangle(0, 0, fnlsz.X, fnlsz.Y), New Rectangle(0, 0, bmpmtmt.Width, bmpmtmt.Height), GraphicsUnit.Pixel)
        Return bmooo66569
    End Function

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        TextBox11.ReadOnly = Not CheckBox8.Checked
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        TextBox12.ReadOnly = Not CheckBox9.Checked
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged
        TextBox13.ReadOnly = Not CheckBox10.Checked
    End Sub
End Class

Public Enum PFType
    Field
    Properti
End Enum
