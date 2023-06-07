Imports System.IO
Imports System.Management
Imports System.Text
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports GMap.NET
Imports Guna.UI2.WinForms


Public Class FrmRegister



    Private fcon As New FirebaseConfig() With
        {
        .BasePath = "use firebase for auth",
        .AuthSecret = ""
        }
    Private client As IFirebaseClient
    Private r As Integer = 255, g As Integer = 0, b As Integer = 0
    Private Sub FrmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        p_recognize.Visible = False
        p_register.Visible = False
        p_thanks.Visible = False

        text_date.Text = Date.Today.ToString("dd/MM/yyyy")
        bolabranca1.Visible = False
        bolaazul1.Visible = True
        bolaazul2.Visible = False
        bolaazul3.Visible = False
        Timer1.Start()
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

    Private Sub Btn_Login_Click(sender As Object, e As EventArgs)
#Region "verificação"
        If (String.IsNullOrWhiteSpace(txt_login.Text)) AndAlso (Txt_Password.Text) Then
            MessageBox.Show("Invalid Username or Password")
        End If
#End Region
        Dim list_users As New UsersInfo() With
            {
            .Username = txt_login.Text,
            .Password = Txt_Password.Text,
            .UUID = Guna2TextBox1.Text,
            .ClientIsRegistered = False,
            .WDBypass = False,
            .BAN = False,
            .CreationDate = text_date.Text
            }

        client.Set("Users/" + txt_login.Text, list_users)
        p_welcome.Visible = False
        p_thanks.Visible = True
        p_recognize.Visible = False
        Guna2Transition1.Hide(p_register)
        Guna2Transition1.ShowSync(p_thanks)
        bolabranca1.Visible = False
        bolabranca2.Visible = False
        bolabranca3.Visible = False
        bolaazul1.Visible = True
        bolaazul2.Visible = True
        bolaazul3.Visible = True

        Dim valor As String = txt_login.Text
        user_text.Text = valor
        Dim valor2 As String = Txt_Password.Text ' pega o valor da TextBox  
        pass_text.Text = valor2
        Dim valor3 As String = text_date.Text ' pega o valor da TextBox  
        date2_text.Text = valor3


        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim imagePath As String = ""

        ' Procura todos os arquivos na pasta EclipseData
        Dim files() As String = Directory.GetFiles(Path.Combine(appDataPath, "EclipseData"))

        ' Percorre cada arquivo e procura por um com a extensão correta
        For Each file As String In files
            Dim extension As String = Path.GetExtension(file)
            If extension = ".png" OrElse extension = ".jpg" OrElse extension = ".jpeg" Then
                imagePath = file
                Exit For ' Encerra o loop assim que encontrar um arquivo válido
            End If
        Next

        ' Se encontrou uma imagem válida, carrega ela na circlepicturebox
        If Not String.IsNullOrEmpty(imagePath) Then
            Guna2CirclePictureBox2.Image = Image.FromFile(imagePath)
        End If
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        Me.Close()
    End Sub




    Private Sub txt_login_TextChanged(sender As Object, e As EventArgs) Handles txt_login.TextChanged

    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged

    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel_Menu_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles bolabranca1.Click

    End Sub

    Private Sub Guna2PictureBox6_Click(sender As Object, e As EventArgs) Handles bolaazul2.Click

    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click

        Guna2CirclePictureBox1.Enabled = False
        Label7.Visible = False
        Guna2GradientButton3.Enabled = True
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

    Private Sub Txt_Password_TextChanged(sender As Object, e As EventArgs) Handles Txt_Password.TextChanged

    End Sub

    Private Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click
        p_welcome.Visible = False
        p_thanks.Visible = False
        Guna2Transition1.Hide(p_recognize)
        Guna2Transition1.ShowSync(p_register)
        bolaazul1.Visible = False
        bolabranca1.Visible = True
        bolaazul2.Visible = False
        bolabranca2.Visible = True
        bolaazul3.Visible = True
        bolabranca3.Visible = False
    End Sub

    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2CirclePictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox2.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles user_text.Click

    End Sub

    Private Sub p_thanks_Paint(sender As Object, e As PaintEventArgs) Handles p_thanks.Paint

    End Sub

    Private Sub Guna2PictureBox2_Click_1(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click

    End Sub

    Private Sub btn_login_Click_1(sender As Object, e As EventArgs) Handles btn_login.Click
#Region "verificação"
        If (String.IsNullOrWhiteSpace(txt_login.Text)) AndAlso (Txt_Password.Text) Then
            MessageBox.Show("Invalid Username or Password")
        End If
#End Region
        Dim list_users As New UsersInfo() With
            {
            .Username = txt_login.Text,
            .Password = Txt_Password.Text,
            .UUID = Guna2TextBox1.Text,
            .ClientIsRegistered = False,
            .WDBypass = False,
            .BAN = False,
            .CreationDate = text_date.Text
            }

        client.Set("Users/" + txt_login.Text, list_users)
        p_welcome.Visible = False
        p_thanks.Visible = True
        p_recognize.Visible = False
        Guna2Transition1.Hide(p_register)
        Guna2Transition1.ShowSync(p_thanks)
        bolabranca1.Visible = False
        bolabranca2.Visible = False
        bolabranca3.Visible = False
        bolaazul1.Visible = True
        bolaazul2.Visible = True
        bolaazul3.Visible = True

        Dim valor As String = txt_login.Text
        user_text.Text = valor
        Dim valor2 As String = Txt_Password.Text ' pega o valor da TextBox  
        pass_text.Text = valor2
        Dim valor3 As String = text_date.Text ' pega o valor da TextBox  
        date2_text.Text = valor3
        CriarArquivo()
        Guna2GradientButton2.Enabled = True
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim imagePath As String = ""

        ' Procura todos os arquivos na pasta EclipseData
        Dim files() As String = Directory.GetFiles(Path.Combine(appDataPath, "EclipseData"))

        ' Percorre cada arquivo e procura por um com a extensão correta
        For Each file As String In files
            Dim extension As String = Path.GetExtension(file)
            If extension = ".png" OrElse extension = ".jpg" OrElse extension = ".jpeg" Then
                imagePath = file
                Exit For ' Encerra o loop assim que encontrar um arquivo válido
            End If
        Next

        ' Se encontrou uma imagem válida, carrega ela na circlepicturebox
        If Not String.IsNullOrEmpty(imagePath) Then
            Guna2CirclePictureBox2.Image = Image.FromFile(imagePath)
        End If
    End Sub

    Private Sub Guna2GradientButton2_Click_1(sender As Object, e As EventArgs) Handles Guna2GradientButton2.Click
        Me.Hide()
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        p_thanks.Visible = False
        bolaazul1.Visible = False
        bolabranca1.Visible = True
        bolabranca2.Visible = False
        bolaazul2.Visible = True
        Guna2Transition1.Hide(p_welcome)
        Guna2Transition1.ShowSync(p_recognize)


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
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub


End Class