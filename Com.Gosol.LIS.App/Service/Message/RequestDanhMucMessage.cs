using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.LIS.App.Service.Message
{
    [ProtoContract]
    class RequestDanhMucMessage : Message
    {
        private static Header header = new Header(MessageCodes.RequestDanhMuc);

        [ProtoMember(1)]
        public string MaTT { set; get; }

        public override void Serialize(System.IO.Stream stream)
        {
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, header, PrefixStyle.Base128);
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, this, PrefixStyle.Base128);
        }
    }
}
