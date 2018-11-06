using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.LIS.App.DataJson
{
    [DataContract]
    public class ListBenhNhans
    {
        [DataMember(Name = "status")]
        public int status { get; set; }

        [DataMember(Name = "message")]
        public string message { get; set; }

        [DataMember(Name = "datas")]
        public List<BenhNhanInfo> datas { get; set; }
    }
}
