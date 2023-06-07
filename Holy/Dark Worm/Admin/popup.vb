Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip

Public Class popup


    Public Sub popup_Load() Handles MyBase.Load
        Me.Left = Screen.PrimaryScreen.Bounds.Width - Me.Width
        Me.Top = Screen.PrimaryScreen.Bounds.Height - Me.Height
        Timer1.Enabled = True

    End Sub

    Public Sub Teste(ByVal C As Client)

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub popup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class