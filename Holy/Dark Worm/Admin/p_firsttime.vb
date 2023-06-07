Public Class p_firsttime
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        FrmRegister.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        FrmLogin.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2ControlBox4_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox4.Click
        Application.Exit()
    End Sub

    Private Sub Guna2ControlBox3_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox3.Click

    End Sub
End Class