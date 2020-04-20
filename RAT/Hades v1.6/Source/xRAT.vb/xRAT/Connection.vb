Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices

Namespace xRAT
    Public Class Connection
        ' Events
        Public Custom Event Disconnected As DisconnectedEventHandler
        Public Custom Event GotInfo As GotInfoEventHandler

        ' Methods
        Public Sub New(ByVal client As TcpClient)
            Class1.QaIGh5M7cuigS
            Me.tcpClient_0 = client
            client.GetStream.BeginRead(New Byte() { 0 }, 0, 0, New AsyncCallback(AddressOf Me.Read), Nothing)
            Me.string_0 = client.Client.RemoteEndPoint.ToString.Remove(client.Client.RemoteEndPoint.ToString.LastIndexOf(":"))
        End Sub

        Public Sub Read(ByVal ar As IAsyncResult)
            Try 
                Dim str As String = New StreamReader(Me.tcpClient_0.GetStream).ReadLine
                If Not str.StartsWith("REMOTEDESK") Then
                    str = Conversions.ToString(Class6.smethod_1("KeYaEs11", str))
                End If
                Dim handler As GotInfoEventHandler = Me.gotInfoEventHandler_0
                If (Not handler Is Nothing) Then
                    handler.Invoke(Me, str)
                End If
                Me.tcpClient_0.GetStream.BeginRead(New Byte() { 0 }, 0, 0, New AsyncCallback(AddressOf Me.Read), Nothing)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim handler2 As DisconnectedEventHandler = Me.disconnectedEventHandler_0
                If (Not handler2 Is Nothing) Then
                    handler2.Invoke(Me)
                End If
                ProjectData.ClearProjectError
            End Try
        End Sub

        Public Sub Send(ByVal Message As String)
            Try 
                Dim writer As New StreamWriter(Me.tcpClient_0.GetStream)
                Message = Conversions.ToString(Class6.smethod_0("KeYaEs11", Message))
                writer.WriteLine(Message)
                writer.Flush
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                Console.WriteLine(exception.Message)
                ProjectData.ClearProjectError
            End Try
        End Sub


        ' Properties
        Public ReadOnly Property Object_0 As Object
            Get
                Return Me.string_0
            End Get
        End Property


        ' Fields
        Private string_0 As String
        Private tcpClient_0 As TcpClient

        ' Nested Types
        Public Delegate Sub DisconnectedEventHandler(ByVal client As Connection)

        Public Delegate Sub GotInfoEventHandler(ByVal client As Connection, ByVal Message As String)
    End Class
End Namespace

