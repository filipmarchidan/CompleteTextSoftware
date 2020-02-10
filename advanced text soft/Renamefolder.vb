Public Class Renamefolder

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            My.Computer.FileSystem.RenameFile(Form1.linkshower.Text, TextBox1.Text)
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class