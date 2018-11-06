using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gosol.LIS.App.DataJson
{
    [DataContract]
    public class BenhNhanInfo
    {
        [DataMember(Name = "patient_code")]
        public string Patient_code { get; set; }

        [DataMember(Name = "fullname")]
        public string Fullname { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "identifier")]
        public string Identify { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "fp_ngon_cai_phai")]
        public string FPNgonCaiPhai { get; set; }

        [DataMember(Name = "fp_ngon_cai_trai")]
        public string FPNgonCaiTrai { get; set; }

        [DataMember(Name = "fp_ngon_tro_phai")]
        public string FPNgonTroPhai { get; set; }

        [DataMember(Name = "fp_ngon_tro_trai")]
        public string FPNgonTroTrai { get; set; }

        [DataMember(Name = "flag_allow_add_pattern")]
        public bool FlagAllowAddPattern { get; set; }
    }
}
