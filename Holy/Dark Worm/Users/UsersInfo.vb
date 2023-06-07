Public Class UsersInfo
    Public Property Username() As String
    Public Property Password() As String
    Public Property UUID() As String
    Public Property ClientIsRegistered() As Boolean
    Public Property WDBypass() As Boolean
    Public Property BAN() As Boolean

    Public Property CreationDate() As String

    Public Shared Function isEqual(user1 As UsersInfo, user2 As UsersInfo)
        If (user1 Is Nothing Or user2 Is Nothing) Then

            Return False
        End If
        If (user1.Username <> user2.Username) Then

            Return False
        ElseIf (user1.Password <> user2.Password) Then

            Return False
        End If
        Return True
    End Function
End Class
