Imports FireSharp.Interfaces
Imports FireSharp.Config
Imports FireSharp.Response
Imports FireSharp.Exceptions
Imports FireSharp
Imports FastColoredTextBoxNS
Imports Microsoft.VisualBasic.Devices
Imports System.Management
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Threading
Imports System.IO
Imports System.Text
Imports Guna.UI2.WinForms

Public Class minilogin
    Private fcon As New FirebaseConfig() With
        {
        .BasePath = "use firebase for auth",
        .AuthSecret = ""
        }
    Private client As IFirebaseClient
    Private Sub minilogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Login", Nothing) = Nothing Then

            login.Text = ""
        Else
            login.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Login", Nothing)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Password", Nothing) = Nothing Then
            pass.Text = ""
        Else
            pass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Password", Nothing)
        End If
        Try
            client = New FireSharp.FirebaseClient(fcon)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        ' Crie uma instância da classe ManagementClass para acessar as informações do sistema
        Dim mc As New ManagementClass("Win32_ComputerSystemProduct")

        ' Obtenha a coleção de objetos com as informações do sistema
        Dim moc As ManagementObjectCollection = mc.GetInstances()

        ' Itere pelos objetos e exiba o valor do HWID em um Guna2TextBox
        For Each mo As ManagementObject In moc
            Dim hwid As String = mo("UUID").ToString()
            Me.hwid.Text = hwid
        Next
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Login", Nothing) = Nothing Then

            login.Text = ""
        Else

        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Password", Nothing) = Nothing Then
            pass.Text = ""
        Else

        End If
    End Sub
    Dim respostadiretauser As String
    Dim respostadiretaserver As String
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
#Region "verificação"
        If (String.IsNullOrWhiteSpace(login.Text)) AndAlso (String.IsNullOrWhiteSpace(pass.Text)) Then
            MessageBox.Show("Invalid Username or Password")
            Return
        End If
#End Region
        Dim resposta_client = client.Get("Users/" + login.Text)
        Dim resposta_servidor = resposta_client.ResultAs(Of UsersInfo)
        Dim list_clientes As New UsersInfo() With
            {
            .Username = login.Text,
            .Password = pass.Text,
            .UUID = hwid.Text,
            .ClientIsRegistered = False,
            .WDBypass = False,
            .BAN = False
            }
        If (UsersInfo.isEqual(resposta_servidor, list_clientes)) Then
            Dim Form_Ports As New FrmPort
            Form_Ports.username_label_servidor = resposta_servidor.Username
            Form_Ports.username_server = resposta_servidor.Username
            Form_Ports.password_server = resposta_servidor.Password
            Form_Ports.uuid_server = resposta_servidor.UUID
            Form_Ports.clientIsRegistered = resposta_servidor.ClientIsRegistered
            Me.Hide()
            Form_Ports.Show()
        End If
        If (UsersInfo.isEqual(resposta_servidor, list_clientes)) Then
            Dim Frm1 As New AuthForm
            Frm1.username_server = resposta_servidor.Username
            Frm1.password_server = resposta_servidor.Password
            Frm1.uuid_server = resposta_servidor.UUID
            Frm1.clientIsRegistered = resposta_servidor.ClientIsRegistered
            Frm1.WDBypass = resposta_servidor.WDBypass
            Frm1.BAN = resposta_servidor.BAN
        End If
        If (UsersInfo.isEqual(resposta_servidor, list_clientes)) Then
            Dim Mngr As New Controlpanel
            Mngr.username_server = resposta_servidor.Username
        End If
        If (UsersInfo.isEqual(resposta_servidor, list_clientes)) Then
            Dim Mn2gr As New Client_Menager
            Mn2gr.username_server = resposta_servidor.Username
        End If
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Login", login.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Password", pass.Text)

    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs)
        FrmRegister.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        securityys.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox2.Click

    End Sub
End Class