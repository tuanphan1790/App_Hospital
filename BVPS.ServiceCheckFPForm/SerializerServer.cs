using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProtoBuf;
using BVPS.ServiceCheckFPForm.Message;
using LZ4;

namespace BVPS.ServiceCheckFPForm
{
    class SerializerServer
    {
        private List<Message.Message> messages;

        DBModel dbModel;

        Thread streamThread;
        Thread sendThread;

        Stream streamRead;
        Stream streamWrite;

        AutoResetEvent autoResetEvent;

        Socket socket;

        private bool closed;

        Form1 form;
        public SerializerServer(DBModel dbModel, Socket socket, Form1 form)
        {
            this.socket = socket;
            this.dbModel = dbModel;
            this.form = form;

            messages = new List<Message.Message>();

            var nwStream = new NetworkStream(socket);
            streamWrite = new LZ4Stream(nwStream, System.IO.Compression.CompressionMode.Compress);
            streamRead = new LZ4Stream(nwStream, System.IO.Compression.CompressionMode.Decompress);

            //streamWrite = new NetworkStream(socket);
            //streamRead = new NetworkStream(socket);

            this.closed = false;
            this.autoResetEvent = new AutoResetEvent(false);

            this.streamThread = new Thread(new ParameterizedThreadStart(this.StreamWorker));
            this.streamThread.IsBackground = true;
            this.streamThread.Start();

            this.sendThread = new Thread(new ParameterizedThreadStart(this.SendWorker));
            this.sendThread.IsBackground = true;
            this.sendThread.Start();
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

                foreach(var mes in tempMessages)
                {
                    mes.Serialize(this.streamWrite);
                }

                this.streamWrite.Flush();
            }
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
                        form.AppendTextBox("Connection was closed");
                        return;
                    }

                    switch (header.MessageCode)
                    {
                        case MessageCodes.RequestDanhMuc:
                            this.StreamWorker_RequestDanhMuc();
                            break;

                        case MessageCodes.RequestFP:
                            this.StreamWorker_RequestFP();
                            break;

                        case MessageCodes.Ping:
                            this.StreamWorker_Ping();
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

        private void StreamWorker_RequestDanhMuc()
        {
            try
            {
                RequestDanhMucMessage rq = ProtoBuf.Serializer.DeserializeWithLengthPrefix<Message.RequestDanhMucMessage>(this.streamRead, ProtoBuf.PrefixStyle.Base128);

                lock (this.socket)
                {
                    UpdateDanhMucMessage dm = new UpdateDanhMucMessage();
                    dm.MaTT = rq.MaTT;

                    foreach (var x in dbModel.GetDMTinhThanh())
                    {
                        dm.DMTinh[x.MaTinh] = x.TenTinh;
                    }
                    foreach (var x in dbModel.GetDMThanhPho())
                    {
                        dm.DMThanhPho[x.MaThanhPho] = x.TenThanhPho;
                    }
                    foreach (var x in dbModel.GetDMDanToc())
                    {
                        dm.DMDanToc[x.Id] = x.TenDanToc;
                    }
                    foreach (var x in dbModel.GetDMTrinhDoHocVan())
                    {
                        dm.DMTrinhDo[x.Id] = x.TrinhDo;
                    }
                    messages.Add(dm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void StreamWorker_RequestFP()
        {
            try
            {
                form.AppendTextBox("Request Finger Print Message");

                RequestFPMessage rq = ProtoBuf.Serializer.DeserializeWithLengthPrefix<Message.RequestFPMessage>(this.streamRead, ProtoBuf.PrefixStyle.Base128);
                List<string> fps = dbModel.FPDecodeBlobs();

                lock (this.socket)
                {
                    ReturnFPMessage mes = new ReturnFPMessage();
                    mes.MaTT = rq.MaTT;
                    mes.FingerPrints = fps;

                    messages.Add(mes);
                    this.autoResetEvent.Set();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void StreamWorker_Ping()
        {
            try
            {
                form.AppendTextBox("Ping Message");
                PingMessage rq = ProtoBuf.Serializer.DeserializeWithLengthPrefix<Message.PingMessage>(this.streamRead, ProtoBuf.PrefixStyle.Base128);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
