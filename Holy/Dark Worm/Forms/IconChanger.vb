Public Class IconChanger
    Private Sub IconChanger_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OfD As New OpenFileDialog
        With OfD
            .Title = "Select Exe File"
            .Filter = "(*.exe|*.exe"
            If OfD.ShowDialog() = DialogResult.OK Then
                exe_texticon.Text = OfD.FileName
            Else
                exe_texticon.Text = "..."
            End If
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OfD As New OpenFileDialog
        With OfD
            .Title = "Select Icon"
            .Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico"
            .InitialDirectory = Application.StartupPath & "\Icons"
            If OfD.ShowDialog() = DialogResult.OK Then
                If OfD.FileName.EndsWith(".exe") Then
                    ico_texticon.Text = EXEICO.GetIcon(OfD.FileName)
                    PictureBox1.ImageLocation = (ico_texticon.Text)
                    GC.Collect()
                Else
                    ico_texticon.Text = OfD.FileName
                    PictureBox1.ImageLocation = (ico_texticon.Text)
                End If
            Else
                ico_texticon.Text = "..."
                PictureBox1.Image = Nothing
            End If

        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If exe_texticon.Text = Nothing Or ico_texticon.Text = Nothing Or exe_texticon.Text = "..." Or ico_texticon.Text = "..." Then
            Else
                IconInjector.InjectIcon(exe_texticon.Text, ico_texticon.Text)
                MessageBox.Show(exe_texticon.Text, "DONE!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Guna2CircleButton2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub exe_texticon_TextChanged(sender As Object, e As EventArgs) Handles exe_texticon.TextChanged

    End Sub
End Class