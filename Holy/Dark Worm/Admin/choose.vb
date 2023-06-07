Public Class choose
    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub choose_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fileName As String = "Eclipse-F.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The payload enhancement file was not found.", "Eclipse", MessageBoxButtons.OK)
        End If
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileName As String = "Eclipse-CPL.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The payload enhancement file was not found.", "Eclipse", MessageBoxButtons.OK)
        End If
        Me.Close()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fileName As String = "Eclipse Stub Enchancement.exe"
        Dim startFolder As String = Application.StartupPath ' Pasta inicial do aplicativo
        Dim filePath As String = FindFile(startFolder, fileName)

        If Not String.IsNullOrEmpty(filePath) Then ' Verifica se o arquivo foi encontrado
            System.Diagnostics.Process.Start(filePath) ' Inicia o arquivo
        Else
            MessageBox.Show("The payload enhancement file was not found.", "Eclipse", MessageBoxButtons.OK)
        End If
        Me.Close()
    End Sub
End Class