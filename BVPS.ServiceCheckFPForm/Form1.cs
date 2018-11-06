using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BVPS.ServiceCheckFPForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tcpServer = new TcpListener(IPAddress.Any, Convert.ToInt32(txtPort.Text));
        }

        TcpListener tcpServer;
        Socket socket;
        DBModel dbModel;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            dbModel = new DBModel(txtConnectionString.Text);

            tcpServer.Start();

            tcpServer.BeginAcceptSocket(this.DoAcceptSocketCallback, tcpServer);

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            rtbLog.AppendText(value + "\r\n");
        }

        public void DoAcceptSocketCallback(IAsyncResult ar)
        {
            TcpListener listener = (TcpListener)ar.AsyncState;
            socket = listener.EndAcceptSocket(ar);

            SerializerServer ser = new SerializerServer(dbModel, socket, this); 
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            socket.Dispose();
            tcpServer.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }
    }
}
