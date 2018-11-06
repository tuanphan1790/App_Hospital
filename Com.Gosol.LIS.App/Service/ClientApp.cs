using BVPS.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.Gosol.LIS.App.Service
{
    public class ClientApp
    {
        TcpClient tcpClient;
        System.Timers.Timer reconnectTimer;
        SerializerClient clientMachine;

        string address;
        int port;

        AppsLIST app;

        public ClientApp(string address, int port, AppsLIST app)
        {
            this.app = app;

            this.address = address;
            this.port = port;

            this.reconnectTimer = new System.Timers.Timer();
            this.reconnectTimer.Interval = 5000;
            this.reconnectTimer.AutoReset = false;
            this.reconnectTimer.Elapsed += ReconnectTimer_Elapsed;

            this.ConnectToServer();
        }

        public void AddMessage(Message.Message message)
        {
            clientMachine.AddMessage(message);
        }

        private void ReconnectTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                this.tcpClient = new TcpClient();
                this.tcpClient.BeginConnect(address, this.port, this.ConnectCallback, tcpClient.Client);
            }
            catch (Exception ex)
            {
                this.reconnectTimer.Start();
            }
        }

        public void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;
                clientSocket.EndConnect(ar);

                clientMachine = new SerializerClient(clientSocket, app);
            }
            catch(Exception ex)
            {
                this.reconnectTimer.Start();
            }
        }
    }
}
