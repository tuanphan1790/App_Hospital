using BVPS.App;
using Com.Gosol.LIS.App.Service.Message;
using LZ4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.Gosol.LIS.App.Service
{
    class SerializerClient
    {
        AppsLIST app;

        private List<Message.Message> messages;

        Thread streamThread;
        Thread sendThread;

        Stream streamRead;
        Stream streamWrite;

        AutoResetEvent autoResetEvent;

        Socket socket;
        System.Timers.Timer keepAliveTimer;

        private bool closed;

        public SerializerClient(Socket socket, AppsLIST app)
        {
            this.app = app;

            this.socket = socket;

            messages = new List<Message.Message>();

            var nwStream = new NetworkStream(socket);
            streamWrite = new LZ4Stream(nwStream, System.IO.Compression.CompressionMode.Compress);
            streamRead = new LZ4Stream(nwStream, System.IO.Compression.CompressionMode.Decompress);

            //streamWrite = new NetworkStream(socket);
            //streamRead = new NetworkStream(socket);

            this.autoResetEvent = new AutoResetEvent(false);
            this.closed = false;

            this.streamThread = new Thread(new ParameterizedThreadStart(this.StreamWorker));
            this.streamThread.IsBackground = true;
            this.streamThread.Start();

            this.sendThread = new Thread(new ParameterizedThreadStart(this.SendWorker));
            this.sendThread.IsBackground = true;
            this.sendThread.Start();

            this.keepAliveTimer = new System.Timers.Timer();
            this.keepAliveTimer.Interval = 1000;
            this.keepAliveTimer.AutoReset = false;
            this.keepAliveTimer.Elapsed += KeepAliveTimer_Elapsed;

            //
            this.keepAliveTimer.Start();
        }

        private void KeepAliveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.closed)
                return;

            lock (this.socket)
            {
                messages.Add(new Message.PingMessage());
                this.autoResetEvent.Set();
            }

            this.keepAliveTimer.Start();
        }

        private void StreamWorker(object state)
        {
            Header header;

            try
            {
                while (true)
                {
                    header = ProtoBuf.Serializer.DeserializeWithLengthPrefix<Header>(this.streamRead, ProtoBuf.PrefixStyle.Base128);

                    if (header == null)
                    {
                        this.Close();
                        return;
                    }

                    switch (header.MessageCode)
                    {
                        case MessageCodes.UpdateDanhMuc:
                            this.StreamWorker_UpdateDanhMuc();
                            break;

                        case MessageCodes.ReturnFPMessage:
                            this.StreamWorker_ReturnCheckFP();
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Close();
            }
        }

        public void Close()
        {
            try { this.streamRead.Dispose(); }
            catch { }

            try { this.streamWrite.Dispose(); }
            catch { }

            try { this.socket.Dispose(); }
            catch { }

            lock (this.socket)
            {
                this.closed = true;
                this.autoResetEvent.Set();
            }
        }

        public void AddMessage(Message.Message message)
        {
            lock (this.socket)
            {
                this.messages.Add(message);
                this.autoResetEvent.Set();
            }
        }

        private void SendWorker(object state)
        {
            List<Message.Message> tempMessages = new List<Message.Message>();
            int count;

            while (true)
            {
                autoResetEvent.WaitOne();
                lock (this.socket)
                {
                    if (this.closed)
                        return;

                    count = this.messages.Count;
                    if (count == 0)
                        continue;

                    else
                    {
                        tempMessages = this.messages;
                        this.messages = new List<Message.Message>();
                    }
                }

                foreach (var mes in tempMessages)
                {
                    mes.Serialize(this.streamWrite);
                }

                this.streamWrite.Flush();
            }
        }

        private void StreamWorker_UpdateDanhMuc()
        {
            try
            {
                UpdateDanhMucMessage mes = ProtoBuf.Serializer.DeserializeWithLengthPrefix<UpdateDanhMucMessage>(this.streamRead, ProtoBuf.PrefixStyle.Base128);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void StreamWorker_ReturnCheckFP()
        {
            try
            {
                ReturnFPMessage mes = ProtoBuf.Serializer.DeserializeWithLengthPrefix<ReturnFPMessage>(this.streamRead, ProtoBuf.PrefixStyle.Base128);

                if (app.GetTrungTamHTSS().MaTTHTSS == mes.MaTT)
                {
                    //app.ReceiveMessageFP(mes.FingerPrints);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
