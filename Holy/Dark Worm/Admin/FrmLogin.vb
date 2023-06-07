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

Public Class FrmLogin
    Private fcon As New FirebaseConfig() With
        {
        .BasePath = "use firebase for auth",
        .AuthSecret = ""
        }
    Private client As IFirebaseClient

    Private Async Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Eclipselogin.Visible = False
        next_photo.Enabled = False





        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Login", Nothing) = Nothing Then
            Label1.Visible = False
            Label2.Visible = False
            Txt_login.Text = ""
        Else
            Txt_login.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Login", Nothing)
            Label1.Visible = True
            Label2.Text = Txt_login.Text
            Label2.Visible = True
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Password", Nothing) = Nothing Then
            Txt_Password.Text = ""
        Else
            Txt_Password.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Password", Nothing)
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
            Guna2TextBox1.Text = hwid
        Next
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
    Private IsPasswordMasked As Boolean = True
    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs)
        Application.ExitThread()
    End Sub
    Dim respostadiretauser As String
    Dim respostadiretaserver As String
    Private Sub Btn_Login_Click(sender As Object, e As EventArgs)
#Region "verificação"
        If (String.IsNullOrWhiteSpace(Txt_login.Text)) AndAlso (String.IsNullOrWhiteSpace(Txt_Password.Text)) Then
            MessageBox.Show("Invalid Username or Password")
            Return
        End If
#End Region
        Dim resposta_client = client.Get("Users/" + Txt_login.Text)
        Dim resposta_servidor = resposta_client.ResultAs(Of UsersInfo)
        Dim list_clientes As New UsersInfo() With
            {
            .Username = Txt_login.Text,
            .Password = Txt_Password.Text,
            .UUID = Guna2TextBox1.Text,
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
"Login", Txt_login.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Password", Txt_Password.Text)
    End Sub
    Public Function login()

        Dim resposta_client = client.Get("Users/" + minilogin.login.Text)
        Dim resposta_servidor = resposta_client.ResultAs(Of UsersInfo)
        Dim list_clientes As New UsersInfo() With
            {
            .Username = minilogin.login.Text,
            .Password = minilogin.pass.Text,
            .UUID = minilogin.hwid.Text,
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
"Login", Txt_login.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Password", Txt_Password.Text)
    End Function
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Dim register_Form As New FrmRegister()
        register_Form.ShowDialog()
    End Sub

    Private Sub Txt_login_TextChanged(sender As Object, e As EventArgs) Handles Txt_login.TextChanged

    End Sub

    Private Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt_Password_TextChanged(sender As Object, e As EventArgs) Handles Txt_Password.TextChanged

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        IsPasswordMasked = Not IsPasswordMasked
        If IsPasswordMasked Then
            Txt_Password.PasswordChar = "*"
        Else
            Txt_Password.PasswordChar = ""
        End If
    End Sub

    Private Sub Label_Username_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        Label1.Visible = False
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Label2.Visible = False
    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel_Menu_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2Panel1_Paint_1(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click
        next_photo.Enabled = True
        ' Crie uma nova caixa de diálogo de seleção de arquivo
        Dim openFileDialog As New OpenFileDialog()

        ' Defina o filtro de arquivos para exibir apenas arquivos de imagem
        openFileDialog.Filter = "Imagens (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp"

        ' Exiba a caixa de diálogo e aguarde o usuário selecionar um arquivo
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Obtenha o caminho completo do arquivo selecionado
            Dim caminhoCompletoArquivo As String = openFileDialog.FileName

            ' Obtenha o caminho completo do diretório de dados do usuário
            Dim caminhoAppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

            ' Defina o novo caminho do arquivo com o nome "photo_eclipse" na pasta "EclipseData"
            Dim nomeArquivo As String = "photo_eclipse" + Path.GetExtension(caminhoCompletoArquivo)
            Dim caminhoNovaPasta As String = Path.Combine(caminhoAppData, "EclipseData")
            Dim caminhoNovoArquivo As String = Path.Combine(caminhoNovaPasta, nomeArquivo)

            ' Crie a nova pasta, se ela não existir ainda
            If Not Directory.Exists(caminhoNovaPasta) Then
                Directory.CreateDirectory(caminhoNovaPasta)
            End If

            ' Copie o arquivo para a nova pasta com o novo nome
            File.Copy(caminhoCompletoArquivo, caminhoNovoArquivo, True)

            ' Carregue a imagem do arquivo na CirclePictureBox
            Guna2CirclePictureBox1.Image = Image.FromFile(caminhoNovoArquivo)
        End If
    End Sub
    Private Sub CriarArquivo()
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim eclipseDataPath As String = Path.Combine(appDataPath, "EclipseData")
        Dim clientBinPath As String = Path.Combine(eclipseDataPath, "client.bin")

        If Not Directory.Exists(eclipseDataPath) Then
            Directory.CreateDirectory(eclipseDataPath)
        End If

        If Not File.Exists(clientBinPath) Then
            File.Create(clientBinPath).Dispose()
            ' escreve os dados do arquivo aqui
            ' por exemplo, se você quiser escrever "Hello, World!" no arquivo:
            Dim bytes As Byte() = New UTF8Encoding(True).GetBytes("EclipseRAT BETA")
            File.WriteAllBytes(clientBinPath, bytes)
            Console.WriteLine("Arquivo client.bin criado na pasta EclipseData")
        Else
            Console.WriteLine("O arquivo client.bin já existe na pasta EclipseData")
        End If
    End Sub
    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles btn_login.Click
#Region "verificação"
        If (String.IsNullOrWhiteSpace(Txt_login.Text)) AndAlso (String.IsNullOrWhiteSpace(Txt_Password.Text)) Then
            MessageBox.Show("Invalid Username or Password")
            Return
        End If
#End Region
        Dim resposta_client = client.Get("Users/" + Txt_login.Text)
        Dim resposta_servidor = resposta_client.ResultAs(Of UsersInfo)
        Dim list_clientes As New UsersInfo() With
            {
            .Username = Txt_login.Text,
            .Password = Txt_Password.Text,
            .UUID = Guna2TextBox1.Text,
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
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "HaveJoined", "True")
            CriarArquivo()
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
"Login", Txt_login.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Password", Txt_Password.Text)
    End Sub

    Private Sub next_photo_Click(sender As Object, e As EventArgs) Handles next_photo.Click
        bolabranca1.Visible = True
        bolaazul1.Visible = False
        bolaazul2.Visible = True
        bolabranca2.Visible = False
        Guna2Transition1.Hide(Eclipsephoto)

        Guna2Transition1.ShowSync(Eclipselogin)
        Eclipsephoto.Visible = False
        Eclipselogin.Visible = True
    End Sub

    Private Sub Eclipselogin_Paint(sender As Object, e As PaintEventArgs) Handles Eclipselogin.Paint

    End Sub

    Private Sub Guna2ControlBox3_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox3.Click

    End Sub
End Class