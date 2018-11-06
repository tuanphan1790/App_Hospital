﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.ServiceCheckFPForm.Message
{
    [ProtoContract]
    class RequestFPMessage : Message
    {
        private static Header header = new Header(MessageCodes.RequestFP);

        [ProtoMember(1)]
        public string MaTT { set; get; }

        public override void Serialize(System.IO.Stream stream)
        {
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, header, PrefixStyle.Base128);
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, this, PrefixStyle.Base128);
        }
    }
}