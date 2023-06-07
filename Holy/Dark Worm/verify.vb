Imports System.Net

Public Class verify
    Private Sub verify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Password.Visible = False
        Dim p As New WebClient

        Password.Text = p.DownloadString("https://pastebin.com/raw/Z7RmhSP8")
        If Password.Text = TextBox1.Text Then

        Else
            MessageBox.Show("The servers are blocked by the administrator.", "Eclipse")
            Application.Exit()
        End If
    End Sub
End Class