using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.LIS.App.Service.Message
{
    [ProtoContract]
    public class PingMessage : Message
    {
        private static Header header = new Header(MessageCodes.Ping);

        public PingMessage()
        { }

        public override void Serialize(System.IO.Stream stream)
        {
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, header, PrefixStyle.Base128);
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, this, PrefixStyle.Base128);
        }
    }
}
