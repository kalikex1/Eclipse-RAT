Imports System.Security.Cryptography

Public Class Bin

    Public Sub New()
        InitializeComponent()
        Me.Opacity = 0
        Methods.FadeIn(Me, 20)
    End Sub
    Private Sub Bin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Guna2TextBox2.Text = Bot()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
        Try
            Guna2TextBox1.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\H-Malware", "License", Nothing)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Public Shared Function Bot()
        Try
            Return UserName() & "_" & HWID()
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function UserName()
        Try
            Return Environment.UserName
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function HWID() As String
        Try
            Dim tohash As String = Identifier("Win32_Processor", "ProcessorId")
            tohash += "-" & Identifier("Win32_BIOS", "SerialNumber")
            tohash += "-" & Identifier("Win32_BaseBoard", "SerialNumber")
            tohash += "-" & Identifier("Win32_VideoController", "Name")
            Return MD5HASH(tohash)
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Private Shared Function Identifier(ByVal wmiClass As String, ByVal wmiProperty As String) As String
        Try
            Dim result As String = ""
            Dim mc As Management.ManagementClass = New Management.ManagementClass(wmiClass)
            Dim moc As Management.ManagementObjectCollection = mc.GetInstances()
            For Each mo As Management.ManagementObject In moc
                If result = "" Then
                    Try
                        result = mo(wmiProperty).ToString()
                        Exit For
                    Catch
                    End Try
                End If
            Next
            Return result
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Public Shared Function MD5HASH(ByVal input As String) As String
        Try
            Dim md5 As Security.Cryptography.MD5CryptoServiceProvider = New Security.Cryptography.MD5CryptoServiceProvider()
            Dim temp As Byte() = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input))
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            For i As Integer = 10 To temp.Length - 1
                sb.Append(temp(i).ToString("x2"))
            Next
            Return sb.ToString().ToUpper()
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Private Sub Guna2TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox2.TextChanged

    End Sub

    Private Sub Guna2TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles Guna2TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Guna2Button1.Enabled = True Then
                Guna2Button1.PerformClick()
            End If
        End If
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged

    End Sub

    Private Sub Guna2TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles Guna2TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If Guna2Button1.Enabled = True Then
                Guna2Button1.PerformClick()
            End If
        End If
    End Sub
    Public Shared Function AES_Encrypt(ByVal cc As String, ByVal idd As String) As Boolean
        Dim AES As New RijndaelManaged
        Dim Hash_AES As New MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(SB(idd.Split("_")(1) + idd.Split("_")(1) + "H-MalwareTool" + "V5" + "☣"))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = SB(idd)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            If encrypted = cc Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function SB(ByVal s As String) As Byte()
        Return System.Text.Encoding.UTF8.GetBytes(s)
    End Function

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If AES_Encrypt(Guna2TextBox1.Text, Guna2TextBox2.Text) Then
            Try
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\H-Malware", "License", Guna2TextBox1.Text)
                Me.Hide()
                Form1.Show()
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        Else
            MessageBox.Show("Contact Us :" + Environment.NewLine + Environment.NewLine + "Telegram : @XCoderTools", "Error >> Wrong Bin!")
            Process.Start("https://t.me/XCoderTools")
        End If
    End Sub
End Class