Imports KeyAuth_VB.KeyAuth
Public Class Form1
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        KeyAuthApp.init()
        Label2.Visible = False
    End Sub
    Private Shared name As String = "SMIKE" ' Application name, found in dashboard
    Private Shared ownerid As String = "mkl11iDzok" ' Ownerid, found in account settings of dashboard
    Private Shared secret As String = "cec3dde70f107bb856e98823c0868754e0a7084fc5610d2b0945a1f02081be1a" ' Application name, found in dashboard. It's the blurred text beneath application name
    Private Shared version As String = "1.0"
    Public Shared KeyAuthApp As KeyAuth.api = New KeyAuth.api(name, ownerid, secret, version)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If KeyAuthApp.login(Guna2TextBox1.Text, Guna2TextBox2.Text) Then
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Guna2TextBox1.Visible = False
            Guna2TextBox2.Visible = False
            Guna2TextBox3.Visible = False
            Label2.Visible = True
            minilogin.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If KeyAuthApp.register(Guna2TextBox1.Text, Guna2TextBox2.Text, Guna2TextBox3.Text) Then
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Guna2TextBox1.Visible = False
            Guna2TextBox2.Visible = False
            Guna2TextBox3.Visible = False
            Label2.Visible = True
            minilogin.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        KeyAuthApp.upgrade(Guna2TextBox1.Text, Guna2TextBox3.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If KeyAuthApp.license(Guna2TextBox3.Text) Then
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Guna2TextBox1.Visible = False
            Guna2TextBox2.Visible = False
            Guna2TextBox3.Visible = False
            Label2.Visible = True
        End If
    End Sub
End Class