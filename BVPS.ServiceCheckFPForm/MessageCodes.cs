﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.ServiceCheckFPForm
{
    public enum MessageCodes : byte
    {
        RequestFP =1,
        RequestDanhMuc = 2,
        UpdateDanhMuc = 3,
        ReturnFPMessage = 4,
        Ping = 5
    }
}