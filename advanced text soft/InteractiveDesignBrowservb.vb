Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Class InteractiveDesignBrowservb
    Dim mDriveNode As New TreeNode
    Dim Loc As New Point(0, 0)
    Dim Cur As New Point(0, 0)
    Dim copielink As String
    Private Sub ConfigSize()
        Loc = Location
        Cur = Cursor.Position

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private mRootPath As String = "C:\"
    Property RootPath As String
        Get
            Return mRootPath
        End Get
        Set(ByVal value As String)
            mRootPath = value
        End Set
    End Property

    Private Sub InteractiveDesignBrowservb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each mDrive As IO.DriveInfo In DriveInfo.GetDrives()
            Dim mDriveNode As New TreeNode
            mDriveNode.Tag = mDrive.Name
            mDriveNode.Text = mDrive.Name
            mDriveNode.Nodes.Add("*DUMMY*")
            TreeView1.Nodes.Add(mDriveNode)
            mDriveNode.ImageKey = CacheShellIcon(mDriveNode.ToString)
            mDriveNode.SelectedImageKey = mDriveNode.ImageKey
        Next
    End Sub
    Private Sub TreeView1_BeforeCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeCollapse
        ' clear the node that is being collapsed
        e.Node.Nodes.Clear()
        ' add a dummy TreeNode to the node being collapsed so it is expandable
        e.Node.Nodes.Add("*DUMMY*")
    End Sub
    Dim mFile As IO.FileInfo

    Dim mNodeDirectory As IO.DirectoryInfo

    Private Sub TreeView1_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        linkshower.Clear()
        ' clear the expanding node so we can re-populate it, or else we end up with duplicate nodes
        e.Node.Nodes.Clear()
        ' get the directory representing this node
        '  Dim mNodeDrive As IO.DriveInfo
        ' mNodeDrive = New IO.DriveInfo(e.Node.Tag.ToString)
        ' For Each mDrive As IO.DriveInfo In mNodeDrive.GetDrives()
        ' Dim mDriveNode As New TreeNode
        ' mDriveNode.Tag = mDrive.Name
        '  mDriveNode.Text = mDrive.Name
        '  mDriveNode.Nodes.Add("*DUMMY*")
        '  e.Node.Nodes.Add(mDriveNode)
        linkshower.Text = e.Node.Tag.ToString

        mNodeDirectory = New IO.DirectoryInfo(e.Node.Tag.ToString)

        ' add each subdirectory from the file system to the expanding node as a child node
        For Each mDirectory As IO.DirectoryInfo In mNodeDirectory.GetDirectories
            Dim mDirectoryNode As New TreeNode
            ' declare a child TreeNode for the next subdirectory

            ' store the full path to this directory in the child TreeNode's Tag property
            mDirectoryNode.Tag = mDirectory.FullName
            ' set the child TreeNodes's display text
            mDirectoryNode.Text = mDirectory.Name
            ' add a dummy TreeNode to this child TreeNode to make it expandable
            mDirectoryNode.Nodes.Add("*DUMMY*")
            ' add this child TreeNode to the expanding TreeNode
            e.Node.Nodes.Add(mDirectoryNode)
            mDirectoryNode.ImageKey = CacheShellIcon(mDirectory.FullName)
            mDirectoryNode.SelectedImageKey = mDirectoryNode.ImageKey

            For Each mFile In mNodeDirectory.GetFiles
                ' declare a TreeNode for this file
                Dim mFileNode As New TreeNode
                ' store the full path to this file in the file TreeNode's Tag property
                mFileNode.Tag = mFile.FullName
                ' set the file TreeNodes's display text
                mFileNode.Text = mFile.Name
                mFileNode.ImageKey = CacheShellIcon(mFile.FullName)
                mFileNode.SelectedImageKey = mFileNode.ImageKey & "-open"
                ' add this file TreeNode to the TreeNode that is being populated
                e.Node.Nodes.Add(mFileNode)

            Next
        Next
        '  Next

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        e.Node.ForeColor = Color.Navy
    End Sub
    Function CacheShellIcon(ByVal argPath As String) As String

        Dim mKey As String = Nothing
        ' determine the icon key for the file/folder specified in argPath
        If IO.Directory.Exists(argPath) = True Then
            mKey = "folder"
        ElseIf IO.File.Exists(argPath) = True Then
            mKey = IO.Path.GetExtension(argPath)
        End If
        ' check if an icon for this key has already been added to the collection
        If ImageList1.Images.ContainsKey(mKey) = False Then
            ImageList1.Images.Add(mKey, GetShellIconAsImage(argPath))
            ImageList1.Images.Add(mKey & "-open", GetShellOpenIconAsImage(argPath))
        End If

        Return mKey
    End Function
    Private Sub TreeView1_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        ' only proceed if the node represents a file
        If e.Node.ImageKey = "folder" Then Exit Sub
        If e.Node.Tag = "" Then Exit Sub
        ' try to open the file
        Try
            Process.Start(e.Node.Tag)
        Catch ex As Exception
            MessageBox.Show("Error opening file: " & ex.Message)
        End Try
    End Sub

    Private Sub TreeView1_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
    End Sub

    Private Sub TreeView1_NodeMouseHover(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseHoverEventArgs) Handles TreeView1.NodeMouseHover

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Process.Start(linkshower.Text)
    End Sub

    Private Sub TreeView1_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        linkshower.Clear()
        linkshower.Text = e.Node.Tag.ToString
    End Sub
    Dim filetype As FileInfo = DirectCast(mFile, FileInfo)
    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
            My.Computer.FileSystem.DeleteFile(linkshower.Text, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin)
    End Sub

    Private Sub NewFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFolderToolStripMenuItem.Click
        Dim n As String
        n = InputBox("Introduce the name of the folder")
        My.Computer.FileSystem.CreateDirectory(linkshower.Text + n)
        TreeView1.Update()
    End Sub

    Private Sub NewTextFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTextFileToolStripMenuItem.Click
        Dim n As String
        n = InputBox("Introduce the name of the file")
        Dim fs As FileStream = File.Create(linkshower.Text + n + ".txt")
        TreeView1.Update()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UseThePathToSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseThePathToSearchToolStripMenuItem.Click
        Form1.linkshower.Text = linkshower.Text
    End Sub

    Private Sub DeleteFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteFolderToolStripMenuItem.Click
        My.Computer.FileSystem.DeleteDirectory(linkshower.Text, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
          Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin)
    End Sub

    Private Sub SearchInFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchInFolderToolStripMenuItem.Click
        Form1.Show()
        Form1.linkshower.Text = linkshower.Text
        Form1.CheckBox2.Checked = True
        Form1.searchEngine.Enabled = True
        Form1.searchEngine.Select()

    End Sub

    Private Sub TreeView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseClick
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditsToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoToolStripMenuItem.Click
        MessageBox.Show("This program has been created for helping the all windows users")
    End Sub
End Class