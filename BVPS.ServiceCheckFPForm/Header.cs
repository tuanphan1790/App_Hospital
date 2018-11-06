﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.ServiceCheckFPForm
{
    [ProtoContract]
    public class Header
    {
        [ProtoMember(1)]
        public MessageCodes MessageCode { get; set; }

        public Header() { }

        public Header(MessageCodes messageCode)
        {
            this.MessageCode = messageCode;
        }
    }
}