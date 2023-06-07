Imports System.IO

Public Class TcpConnectionForm
    Public C As Client
    Private Sub TcpConnectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Start()
        Try
            Dim B As Byte() = SB("TCPG" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\TCPGET.dll")) & Settings.SPL & Nothing)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        Try
            Dim B As Byte() = SB("TCPG" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\TCPGET.dll")) & Settings.SPL & Nothing)
            Dim ClientReq As New Outcoming_Requests(C, B)
            Pending.Req_Out.Add(ClientReq)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Lv1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(10, 10, 10)), e.Bounds)
        e.DrawText()
    End Sub
    Private Sub Lv1_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles ListView1.DrawSubItem
        e.DrawBackground()
        e.DrawText()
    End Sub
    Private Sub pintobolabunda(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        For Each item As ListViewItem In ListView1.Items
            If item.Selected Then
                item.BackColor = Color.FromArgb(162, 64, 255)
                item.ForeColor = Color.White
                For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                    subItem.BackColor = Color.FromArgb(162, 64, 255)
                    subItem.ForeColor = Color.White
                Next
            Else
                item.BackColor = Color.FromArgb(10, 10, 10)
                item.ForeColor = Color.White
                For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                    subItem.BackColor = Color.FromArgb(10, 10, 10)
                    subItem.ForeColor = Color.White
                Next
            End If
        Next
    End Sub
    Private Sub bucetagrandedemais(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader
        Dim backBrush As New SolidBrush(Color.FromArgb(10, 10, 10))
        e.Graphics.FillRectangle(backBrush, e.Bounds)
        ' Definir a cor do texto para vermelho
        Dim textColor As Color = Color.White

        ' Desenhar o texto do cabeçalho de coluna com a cor personalizada
        Dim headerFont As New Font("Segoe UI", 10, FontStyle.Regular)
        Dim textBrush As New SolidBrush(textColor)
        e.Graphics.DrawString(e.Header.Text, headerFont, textBrush, e.Bounds)
    End Sub

    Private Sub KillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KillToolStripMenuItem.Click
        Dim pids As String
        pids = Nothing
        For Each LV As ListViewItem In ListView1.SelectedItems
            pids &= "|" & LV.SubItems(0).Text
        Next
        Try
            Dim B As Byte() = SB("TCPG" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\TCPGET.dll")) & Settings.SPL & pids)
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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            ToolStripStatusLabel1.Text = "Connections [" & ListView1.Items.Count & "]"
            ToolStripStatusLabel2.Text = "Selected [" & ListView1.SelectedItems.Count.ToString & "]"
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Guna2CircleButton2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class