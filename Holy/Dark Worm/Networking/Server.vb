Imports System.Net.Sockets
Imports System.Net
Public Class Server
    Public S As Socket
    Public allDone As New Threading.ManualResetEvent(False)

    Sub Start(ByVal Port As Integer)
        Try
            S = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim IpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, Port)

            S.ReceiveBufferSize = 50 * 1024
            S.SendBufferSize = 50 * 1024


            S.Bind(IpEndPoint)
            S.Listen(500)

            S.BeginAccept(New AsyncCallback(AddressOf EndAccept), Nothing)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Environment.Exit(0)
        End Try
    End Sub

    Sub EndAccept(ByVal ar As IAsyncResult)
        Try
            Dim C As Client = New Client(S.EndAccept(ar))
        Catch ex As Exception
            Debug.WriteLine("EndAccept " + ex.Message)
        Finally
            S.BeginAccept(New AsyncCallback(AddressOf EndAccept), Nothing)
        End Try
    End Sub

End Class
