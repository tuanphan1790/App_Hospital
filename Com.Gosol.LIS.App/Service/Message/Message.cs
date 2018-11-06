using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.LIS.App.Service.Message
{
    public abstract class Message
    {
        public Message() { }

        public abstract void Serialize(System.IO.Stream stream);
    }
}
