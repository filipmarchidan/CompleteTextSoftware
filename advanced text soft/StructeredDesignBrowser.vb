Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Public Class StructeredDesignBrowser

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

    Private Sub StructeredDesignBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each di As DriveInfo In DriveInfo.GetDrives()
            driveList.Items.Add(di)
        Next
    End Sub

    Private Sub FileManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub driveList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles driveList.SelectedIndexChanged
        folderList.Items.Clear()
        fileList.Items.Clear()
        Try
            Dim drive As DriveInfo = DirectCast(driveList.SelectedItem, DriveInfo)
            For Each dirInfo As DirectoryInfo In drive.RootDirectory.GetDirectories()
                folderList.Items.Add(dirInfo)

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub fileList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fileList.SelectedIndexChanged
    End Sub

    Private Sub folderList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles folderList.SelectedIndexChanged
        Try
            Dim drive As DriveInfo = DirectCast(driveList.SelectedItem, DriveInfo)
            Dim path1 As String

            subfolderList.Items.Clear()
            fileList.Items.Clear()
            Dim dir As DirectoryInfo = DirectCast(folderList.SelectedItem, DirectoryInfo)
            For Each dirInfo2 As DirectoryInfo In dir.GetDirectories()
                subfolderList.Items.Add(dirInfo2)
                path1 = driveList.SelectedItem.ToString + folderList.SelectedItem.ToString
                linkshower.Text = My.Computer.FileSystem.CombinePath(drive.ToString, dir.ToString).ToString
            Next
            For Each fi As FileInfo In dir.GetFiles()
                fileList.Items.Add(fi)
                linkshower.Text = My.Computer.FileSystem.GetParentPath(fi.ToString)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub subfolderList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subfolderList.SelectedIndexChanged
        Try
            fileList.Items.Clear()
            folderList.Items.Clear()
            Dim dir As DirectoryInfo = DirectCast(subfolderList.SelectedItem, DirectoryInfo)
            linkshower.Text = My.Computer.FileSystem.GetParentPath(dir.ToString)
            folderList.Items.Add(dir)
            subfolderList.Items.Clear()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub OpenFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFileToolStripMenuItem.Click
        Try
            Process.Start(linkshower.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Renamefolder.Show()

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Process.Start(linkshower.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RenameFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameFileToolStripMenuItem.Click
        Dim n As String
        Dim filetype As FileInfo = DirectCast(fileList.SelectedItem, FileInfo)

        n = InputBox("Type the name you like")
        My.Computer.FileSystem.RenameFile(linkshower.Text, n + filetype.Extension)


    End Sub
End Class