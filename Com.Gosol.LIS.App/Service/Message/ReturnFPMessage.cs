using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.LIS.App.Service.Message
{
    [ProtoContract]
    class ReturnFPMessage: Message
    {
        private static Header header = new Header(MessageCodes.ReturnFPMessage);

        [ProtoMember(1)]
        public string MaTT { set; get; }

        [ProtoMember(2)]
        public List<string> FingerPrints { set; get; }

        public override void Serialize(System.IO.Stream stream)
        {
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, header, PrefixStyle.Base128);
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, this, PrefixStyle.Base128);
        }
    }
}
