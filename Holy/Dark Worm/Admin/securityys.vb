Imports Guna.UI2.WinForms
Imports System.IO

Public Class securityys
    Private Sub Guna2CirclePictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox2.Click
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
            Guna2CirclePictureBox2.Image = Image.FromFile(caminhoNovoArquivo)
        End If
        MessageBox.Show("Done!", "Eclipse")
        Application.Exit()
    End Sub

    Private Sub securityys_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class