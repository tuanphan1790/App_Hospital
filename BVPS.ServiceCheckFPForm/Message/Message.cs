using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.ServiceCheckFPForm.Message
{
    public abstract class Message
    {
        public Message()
        { }

        public abstract void Serialize(System.IO.Stream stream);
    }
}
