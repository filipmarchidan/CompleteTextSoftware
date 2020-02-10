Imports Microsoft.Office.Interop
Public Class Form4

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Plain Text|*.txt|Word Document|*.docx|PDF|*.pdf|Excel Document|*.xls|PowerPoint Presentation|*.pptx"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Word Document|*.docx|PDF|*.pdf|Excel Document|*.xls|PowerPoint Presentation|*.pptx|Plain Text|*.txt"
        SaveFileDialog1.Title = "Save File"
        If SaveFileDialog1.FileName = Nothing Then
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then

                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text, True)
            End If
        Else
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text, True)
        End If

    End Sub

    Private Sub ChooseWorkspaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChooseWorkspaceToolStripMenuItem.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Dim sr As New System.IO.StringReader(FolderBrowserDialog1.SelectedPath)
            Dim ss As New TextBox
            ss.Text = sr.ReadToEnd()
            SaveFileDialog1.FileName = ss.Text
        End If
    End Sub

    Private Sub InteractiveDesignToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InteractiveDesignToolStripMenuItem.Click
        InteractiveDesignBrowservb.Show()
    End Sub

    Private Sub StructuredDesignToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StructuredDesignToolStripMenuItem.Click
        StructeredDesignBrowser.Show()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Plain Text|*.txt|Word Document|*.docx|PDF|*.pdf|Excel Document|*.xls|PowerPoint Presentation|*.pptx"
        SaveFileDialog1.Title = "Save File"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then

            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text, True)
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoToolStripMenuItem.Click
        MessageBox.Show("This program has been created for helping the all windows users")
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditsToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        If FontDialog1.ShowDialog = DialogResult.OK Then
            RichTextBox1.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub ColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            RichTextBox1.ForeColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub BackgroundColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackgroundColorToolStripMenuItem.Click
        If ColorDialog2.ShowDialog = DialogResult.OK Then
            RichTextBox1.BackColor = ColorDialog2.Color
        End If
    End Sub

    Private Sub BiggerTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BiggerTextToolStripMenuItem.Click

        RichTextBox1.SelectedText = RichTextBox1.Font.SizeInPoints + 1

    End Sub

    Private Sub SmallerTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmallerTextToolStripMenuItem.Click

        RichTextBox1.SelectedText = RichTextBox1.Font.SizeInPoints - 1

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            RichTextBox1.SelectedText = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Calibri;}} \i" + RichTextBox1.SelectedText = "\i0 \par}"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RichTextBox1.SelectedText = True Then
            RichTextBox1.SelectedText = RichTextBox1.Font.Italic
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RichTextBox1.SelectedText = True Then
            RichTextBox1.SelectedText = RichTextBox1.Font.Underline
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim index As Integer = 0
        Dim temp As String = RichTextBox1.Text
        RichTextBox1.Text = ""
        RichTextBox1.Text = temp

        While index < RichTextBox1.Text.LastIndexOf(TextBox1.Text)
            RichTextBox1.Find(TextBox1.Text, index, RichTextBox1.TextLength, RichTextBoxFinds.None)
            RichTextBox1.SelectionBackColor = Color.IndianRed
            index = RichTextBox1.Text.IndexOf(TextBox1.Text, index) + 1
            results.Text = index
        End While

    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        RichTextBox1.Redo()
    End Sub

    Private Sub ShowLocalTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLocalTimeToolStripMenuItem.Click
        Timer1.Start()
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label2.Text = Format(Now, "HH:mm:ss")
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub ShowLinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowLinesToolStripMenuItem.Click
        Dim theText() As String
        theText = RichTextBox1.Lines
        RichTextBox2.Clear()
        For tt As Integer = 1 To theText.Length
            RichTextBox2.AppendText(tt.ToString.PadRight(3, " "c) & Environment.NewLine)
        Next
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click

        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(RichTextBox1.Text, RichTextBox1.Font, Brushes.Black, 100, 100)
    End Sub

    Private Sub RichTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox2.TextChanged

    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class