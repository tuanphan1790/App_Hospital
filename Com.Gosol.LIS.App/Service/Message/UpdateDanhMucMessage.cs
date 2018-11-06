﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.LIS.App.Service.Message
{
    [ProtoContract]
    class UpdateDanhMucMessage: Message
    {
        private static Header header = new Header(MessageCodes.UpdateDanhMuc);

        [ProtoMember(1)]
        public string MaTT { set; get; }

        [ProtoMember(2)]
        Dictionary<string, string> DMTinh { set; get; }

        [ProtoMember(3)]
        Dictionary<string, string> DMThanhPho { set; get; }

        [ProtoMember(4)]
        Dictionary<int, string> DMDanToc { set; get; }

        [ProtoMember(5)]
        Dictionary<int, string> DMTrinhDo { set; get; }

        public override void Serialize(System.IO.Stream stream)
        {
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, header, PrefixStyle.Base128);
            ProtoBuf.Serializer.SerializeWithLengthPrefix(stream, this, PrefixStyle.Base128);
        }
    }
}