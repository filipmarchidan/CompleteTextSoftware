Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Public Class Form1
    Dim Loc As New Point(0, 0)
    Dim Cur As New Point(0, 0)
    Dim copielink As String
    Private Sub ConfigSize()
        Loc = Location
        Cur = Cursor.Position

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Location = Loc - Cur + Cursor.Position
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Timer1.Stop()
        ConfigSize()
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Timer1.Start()
        Timer1.Enabled = True
        ConfigSize()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer3.Start()
        Timer3.Enabled = True
        searchEngine.Enabled = False
        Me.TopMost = False
    End Sub

  

    Private Sub GraffitiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraffitiToolStripMenuItem.Click
        MessageBox.Show("coming soon")
        ' Timer2.Enabled = True
        'Timer2.Start()
        ' Me.BackgroundImage = My.Resources.QvB1b5a
        ' PictureBox1.BackColor = Color.Black
        '  Label2.BackColor = Color.Black
        '  Label2.ForeColor = Color.White
        '  Button1.BackColor = Color.Transparent
        '  Button2.BackColor = Color.Transparent
        ' Button1.ForeColor = Color.White
        ' Button2.ForeColor = Color.White
        ' MenuStrip1.ForeColor = Color.White

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browsebutton.Click
        CheckBox1.Checked = False
        CheckBox2.Checked = True
        If searchBrowser.ShowDialog = DialogResult.OK Then
            Dim sr As New System.IO.StringReader(searchBrowser.SelectedPath)
            linkshower.Text = sr.ReadToEnd()
            sr.Close()
            searchEngine.Enabled = True

        End If
        
    End Sub
    Dim Co As New Microsoft.VisualBasic.Collection
    Private Sub searchEngine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchEngine.TextChanged
        searchResults.Items.Clear()
        Dim i As Integer = 0
        If CheckBox1.Checked = True Then
            Try
                For Each di As DriveInfo In DriveInfo.GetDrives
                    Dim di2 As String = di.Name
                    If linkshower.Text = Nothing Then
                        linkshower.Text = "C:\Program Files"
                    End If
                    For Each foundfile As String In My.Computer.FileSystem.GetFiles(linkshower.Text,
                        FileIO.SearchOption.SearchAllSubDirectories, searchEngine.Text + "*")
                        searchResults.Items.Add(foundfile)
                    Next
                Next
            Catch ex As Exception

            End Try
        ElseIf CheckBox2.Checked = True Then
            Try
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                linkshower.Text,
                FileIO.SearchOption.SearchAllSubDirectories, searchEngine.Text + "*")
                    searchResults.Items.Add(foundFile)
                    Form3.ListView1.Items.Add("coming soon")
                    Form3.ListView1.Items(i).SubItems.Add(foundFile)
                    Form3.ListView1.Items(i).SubItems.Add("coming soon")
                    Form3.ListView1.Items(i).SubItems.Add("coming soon")
                    i += 1
                    If seachbytextfiles.Checked = True Then
                        For Each foundFiletext As String In My.Computer.FileSystem.GetFiles(linkshower.Text, File.ReadAllText(foundFile))
                            If foundFiletext.IndexOf(searchEngine.Text) Then
                                searchResults.Items.Add(foundFiletext)
                            End If
                        Next
                    End If
                Next
            Catch ex As Exception
            End Try


            If searchEngine.Text = Nothing Then
                searchResults.Items.Clear()
            End If
        End If

    End Sub

    Private Sub linkshower_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkshower.TextChanged

    End Sub
    Private Sub StructeredDesignToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StructeredDesignToolStripMenuItem.Click
        StructeredDesignBrowser.Show()
    End Sub

    Private Sub InteractiveDesignToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InteractiveDesignToolStripMenuItem.Click
        InteractiveDesignBrowservb.Show()
        InteractiveDesignBrowservb.TopMost = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            CheckBox2.Checked = True
        ElseIf CheckBox1.Checked = True And CheckBox2.Checked Then
            CheckBox2.Checked = False
        End If
        If CheckBox1.Checked = True Then
            searchEngine.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            CheckBox1.Checked = True
        ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
            CheckBox1.Checked = False
        End If
        If CheckBox1.Checked = True Then
            searchEngine.Enabled = True
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub InfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoToolStripMenuItem.Click
        MessageBox.Show("This program has been created for helping the all windows users")
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditsToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub AdvancedViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancedViewToolStripMenuItem.Click
        Form3.Show()
        Form3.TopMost = True
    End Sub

    Private Sub TextEditorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextEditorToolStripMenuItem1.Click
        Form4.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MatrixToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatrixToolStripMenuItem.Click
        CheckBox1.ForeColor = Color.Green
        CheckBox2.ForeColor = Color.Green
        Me.BackColor = Color.Black
        MenuStrip1.ForeColor = Color.Green
        MenuStrip1.BackColor = Color.Black
        searchEngine.ForeColor = Color.Green
        searchEngine.BackColor = Color.Black
        searchResults.BackColor = Color.Black
        searchEngine.ForeColor = Color.Green
        PictureBox1.BackColor = Color.Green
        Button1.ForeColor = Color.Green
        Button1.BackColor = Color.Black
        Button2.BackColor = Color.Black
        Button2.ForeColor = Color.Green
        linkshower.ForeColor = Color.Green
        linkshower.BackColor = Color.Black
        Button3.BackColor = Color.Black
        Button3.ForeColor = Color.Green
        browsebutton.BackColor = Color.Black
        browsebutton.ForeColor = Color.Green
        seachbytextfiles.ForeColor = Color.Green
        seachbytextfiles.BackColor = Color.Black
        CheckBox1.BackColor = Color.Black
        CheckBox1.BackColor = Color.Black
        Label2.BackColor = Color.Green
        Label2.ForeColor = Color.Black
    End Sub

    Private Sub NavyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavyToolStripMenuItem.Click
        CheckBox1.ForeColor = Color.Navy
        CheckBox2.ForeColor = Color.Navy
        Me.BackColor = Color.White
        MenuStrip1.ForeColor = Color.Navy
        MenuStrip1.BackColor = Color.White
        searchEngine.ForeColor = Color.Navy
        searchEngine.BackColor = Color.White
        searchResults.BackColor = Color.White
        searchEngine.ForeColor = Color.Navy
        PictureBox1.BackColor = Color.White
        Button1.ForeColor = Color.Navy
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button2.ForeColor = Color.Navy
        linkshower.ForeColor = Color.Navy
        linkshower.BackColor = Color.White
        Button3.BackColor = Color.White
        Button3.ForeColor = Color.Navy
        browsebutton.BackColor = Color.White
        browsebutton.ForeColor = Color.Navy
        seachbytextfiles.ForeColor = Color.Navy
        seachbytextfiles.BackColor = Color.White
        CheckBox1.BackColor = Color.White
        CheckBox1.BackColor = Color.White
        Label2.BackColor = Color.Navy
        Label2.ForeColor = Color.White
        PictureBox1.BackColor = Color.Navy
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If searchResults.Items.Count = 0 Then
            MessageBox.Show("you have to search something first before")
        Else
            Form3.Show()
        End If

    End Sub

    Private Sub OnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources.Untitled, AudioPlayMode.Background)
    End Sub

    Private Sub OffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OffToolStripMenuItem.Click
        My.Computer.Audio.Stop()
    End Sub

    Private Sub HideSpoilerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideSpoilerToolStripMenuItem.Click
        If spoiler.Visible = True Then
            spoiler.Visible = False
        Else
            spoiler.Visible = True
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        spoiler.Left -= 5
        If spoiler.Left <= -Width Then
            spoiler.Left = Width
        End If
    End Sub
End Class

