Imports System.IO
Imports System.Threading
Imports FastColoredTextBoxNS
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Microsoft.Win32
Imports NAudio
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FrmPort
    Private fcon As New FirebaseConfig() With
        {
        .BasePath = "use firebase for auth",
        .AuthSecret = ""
        }
    Private client As IFirebaseClient
    Public Shared username_server As String
    Public Shared password_server As String
    Public Shared uuid_server As String
    Public Shared username_label_servidor As String
    Public Shared CreationDate As String
    Public Shared clientIsRegistered As Boolean
    Public Shared WDBypass As Boolean
    Public Shared BAN As Boolean
    Public Shared ban_server As String

    Private Sub Guna2GroupBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Port_Fomulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VerificarLinha()
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
        Try
            client = New FireSharp.FirebaseClient(fcon)
        Catch ex As Exception
        End Try
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "PortSaved", Nothing) = Nothing Then
            txt_Port.Text = ""
        Else
            txt_Port.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "PortSaved", Nothing)
        End If
        Label_Username.Text = username_label_servidor
        Label1.Text = CreationDate
    End Sub


    Public Sub Iniciar()
        If Not String.IsNullOrEmpty(Me.txt_Port.Text) Then
            Settings.Port = txt_Port.Text
            Settings.KEY = Guna2TextBox1.Text
            Settings.Blocked = New List(Of String)


            Try
                Messages.F = AuthForm
                Helper.aes_function()
                Pending.Req_In = New List(Of Incoming_Requests)
                Dim Req_In As New Thread(New ThreadStart(AddressOf Pending.Incoming))
                Req_In.IsBackground = True
                Req_In.Start()

                Pending.Req_Out = New List(Of Outcoming_Requests)
                Dim Req_Out As New Thread(New ThreadStart(AddressOf Pending.OutComing))
                Req_Out.IsBackground = True
                Req_Out.Start()

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

            Try
                connect()
                AuthForm.Timer_Status.Start()

                AuthForm.username_server = username_server
                AuthForm.password_server = password_server
                AuthForm.clientIsRegistered = clientIsRegistered
                Me.Hide()
                AuthForm.Show()
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"PortSaved", txt_Port.Text)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Features", key2.Text)
        Else
            MessageBox.Show("You forgot to put your listening port.")
        End If
    End Sub
    Public Async Sub connect()
        Try
            Await Task.Delay(2000)
            AuthForm.S = New Server
            Dim listener As New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf AuthForm.S.Start))
            listener.Start(Settings.Port)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_Port.TextChanged

    End Sub

    Private Sub Label_Username_Click(sender As Object, e As EventArgs) Handles Label_Username.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged

    End Sub

    Private Sub Guna2TextBox2_TextChanged(sender As Object, e As EventArgs) Handles key2.TextChanged

    End Sub

    Private Sub Guna2GroupBox1_Click(sender As Object, e As EventArgs) Handles Guna2GroupBox1.Click

    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Guna2PictureBox3_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox3.Click

    End Sub

    Private Sub Guna2PictureBox5_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox5.Click

    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        If termsofservice.Checked Then
            Iniciar()
            AdicionarLinha()
        Else
            MessageBox.Show("You need to accept terms of service.")
        End If
    End Sub
    Private Sub AdicionarLinha()
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim eclipseDataPath As String = Path.Combine(appDataPath, "EclipseData")
        Dim clientBinPath As String = Path.Combine(eclipseDataPath, "client.bin")

        If Not Directory.Exists(eclipseDataPath) Then
            Directory.CreateDirectory(eclipseDataPath)
        End If

        Dim lines As List(Of String) = File.ReadAllLines(clientBinPath).ToList()
        lines.Add("TOS")
        File.WriteAllLines(clientBinPath, lines.ToArray())
        Console.WriteLine("Linha adicionada no arquivo client.bin")
    End Sub
    Private Function VerificarLinha() As Boolean
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim eclipseDataPath As String = Path.Combine(appDataPath, "EclipseData")
        Dim clientBinPath As String = Path.Combine(eclipseDataPath, "client.bin")

        If Not Directory.Exists(eclipseDataPath) Then
            Directory.CreateDirectory(eclipseDataPath)
        End If

        If File.Exists(clientBinPath) Then
            For Each line As String In File.ReadLines(clientBinPath)
                If line.Contains("TOS") Then
                    termsofservice.Checked = True
                    Return True
                End If
            Next
            termsofservice.Checked = False
            Return False
        Else
            Console.WriteLine("O arquivo client.bin não existe na pasta EclipseData")
            Return False
        End If
    End Function

    Private Sub Guna2CirclePictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox2.Click

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Changelog.Show()
    End Sub
End Class