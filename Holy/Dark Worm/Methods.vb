Imports System.IO
Imports System.Reflection
Imports System.Threading.Tasks
Imports Toolbelt.Drawing

Public Class Methods
    Public Shared Function BytesToString(ByVal byteCount As Long) As String
        Dim suf As String() = {"B", "KB", "MB", "GB", "TB", "PB", "EB"}
        If byteCount = 0 Then Return "0" & suf(0)
        Dim bytes As Long = Math.Abs(byteCount)
        Dim place As Integer = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)))
        Dim num As Double = Math.Round(bytes / Math.Pow(1024, place), 1)
        Return (Math.Sign(byteCount) * num).ToString() & suf(place)
    End Function

    Public Shared DoubleBytes As Double
    Public Shared Function GetFileSize(ByVal TheFile As String) As String
        If TheFile.Length = 0 Then Return ""
        If Not System.IO.File.Exists(TheFile) Then Return ""
        '---
        Dim TheSize As ULong = My.Computer.FileSystem.GetFileInfo(TheFile).Length
        Dim SizeType As String = ""
        '---

        Try
            Select Case TheSize
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
                    Return "T: " & FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(TheSize / 1073741824) 'GB
                    Return "G: " & FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(TheSize / 1048576) 'MB
                    Return "M: " & FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(TheSize / 1024) 'KB
                    Return "K: " & FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = TheSize ' bytes
                    Return "B: " & FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function
    Public Shared Function CheckNet(ByVal Path As String)
        Try
            Assembly.LoadFile(Path).EntryPoint.GetParameters()
            Return True
        Catch
            Return False
        End Try
    End Function
    Public Shared Function GetVersion(ByVal P As String) As String
        Try
            Return Assembly.LoadFile(P).ImageRuntimeVersion.Substring(0, 4).ToUpper
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function
    Public Shared Function CPU(File As String) As String
        Try
            Dim assembly As Assembly = Assembly.LoadFile(File)
            Dim peKind As PortableExecutableKinds
            Dim imageFileMachine As ImageFileMachine
            assembly.ManifestModule.GetPEKind(peKind, imageFileMachine)
            Dim VCPU As Integer = peKind
            Return VCPU.ToString.Replace("17", "anycpu").Replace("1", "anycpu").Replace("3", "x86").Replace("5", "x64")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function
    Public Shared Function GetIcon(ByVal path As String) As String
        Try
            Dim tempFile As String = IO.Path.GetTempFileName() & ".ico"

            Using fs As FileStream = New FileStream(tempFile, FileMode.Create)
                IconExtractor.Extract1stIconTo(path, fs)
            End Using

            Return tempFile
        Catch
        End Try

        Return ""
    End Function

    Public Shared Async Sub FadeInMain(ByVal o As Form, ByVal Optional interval As Integer = 80)

        While o.Opacity < 1.0
            Await Task.Delay(interval)
            o.Opacity += 0.05
        End While

        o.Opacity = 1

        AuthForm.trans = True
    End Sub

    Public Shared Async Sub FadeIn(ByVal o As Form, ByVal Optional interval As Integer = 80)

        While o.Opacity < 1.0
            Await Task.Delay(interval)
            o.Opacity += 0.05
        End While

        o.Opacity = 1
    End Sub

End Class

