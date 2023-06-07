Imports System.IO
Imports System.Management
Imports System.Threading
Imports System.Threading.Tasks
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Guna.UI2.WinForms

Public Class loading
    Private fcon As New FirebaseConfig() With
        {
        .BasePath = "use firebase for auth",
        .AuthSecret = ""
        }
    Private client As IFirebaseClient
    Public Shared clientIsRegistered As Boolean
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2PictureBox1.Image = My.Resources.bglqgirapporra
        Timer1.Start()
        Await Task.Delay(5000)
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Login", Nothing) = Nothing Then
            Label1.Visible = False

            Txt_login.Text = ""
        Else
            Txt_login.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Login", Nothing)
            Label1.Visible = True

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
            minilogin.Show()
            Me.Hide()
        Else
            p_firsttime.Show()
            Me.Hide()
        End If





    End Sub
    Private Sub VerificarArquivo()
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim eclipseDataPath As String = Path.Combine(appDataPath, "EclipseData")
        Dim clientBinPath As String = Path.Combine(eclipseDataPath, "client.bin")
        ' executar função se o arquivo existe
        minilogin.Show()
        Me.Hide()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Static angle As Integer = 0
        angle += 5
        If angle >= 360 Then angle = 0
        Dim rotatedImage As Bitmap = RotateImage(My.Resources.bglqgirapporra, angle)
        Guna2PictureBox1.Image = rotatedImage
    End Sub

    Private Function RotateImage(ByVal image As Image, ByVal angle As Integer) As Bitmap
        Dim rotatedImage As Bitmap = New Bitmap(image.Width, image.Height)
        rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution)
        Using g As Graphics = Graphics.FromImage(rotatedImage)
            g.TranslateTransform(image.Width / 2, image.Height / 2)
            g.RotateTransform(angle)
            g.TranslateTransform(-image.Width / 2, -image.Height / 2)
            g.DrawImage(image, New Point(0, 0))
        End Using
        Return rotatedImage
    End Function
End Class