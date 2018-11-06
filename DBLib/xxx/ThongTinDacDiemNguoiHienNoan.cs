using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLib
{
    class ThongTinDacDiemNguoiHienNoan
    {
        public UInt64 Patient_ID { set; get; }
        public string Patient_Code { set; get; }

        public string ChieuCao { set; get; }
        public string CanNang { set; get; }
        public string HuyetAp { set; get; }
        public string PhatTrienVu { set; get; }
        public string TietSua { set; get; }
        public string VanDeKhac { set; get; }

        public DateTime CreatedDate { set; get; }

        public ThongTinDacDiemNguoiHienNoan(UInt64 id, string code)
        {
            this.Patient_ID = id;
            this.Patient_Code = code;
        }

        public ThongTinDacDiemNguoiHienNoan(XDocument xDoc)
        {
            var xTTDDNHN = xDoc.Element("TTDDNHN");
            this.Patient_ID = Convert.ToUInt64(xTTDDNHN.Attribute("id").Value);
            this.Patient_Code = xTTDDNHN.Attribute("code").Value;

            this.ChieuCao = xTTDDNHN.Element("ChieuCao").Value;
            this.CanNang = xTTDDNHN.Element("CanNang").Value;
            this.HuyetAp = xTTDDNHN.Element("HuyetAp").Value;
            this.PhatTrienVu = xTTDDNHN.Element("PhatTrienVu").Value;
            this.TietSua = xTTDDNHN.Element("TietSua").Value;
            this.VanDeKhac = xTTDDNHN.Element("VanDeKhac").Value;

            this.CreatedDate = Convert.ToDateTime(xTTDDNHN.Element("createdDate").Value);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("TTDDNHN", new XAttribute("id", Patient_ID.ToString()), new XAttribute("code", Patient_Code),
                    new XElement("ChieuCao", ChieuCao),
                    new XElement("CanNang", CanNang),
                    new XElement("HuyetAp", HuyetAp),
                    new XElement("PhatTrienVu", PhatTrienVu),
                    new XElement("TietSua", TietSua),
                    new XElement("VanDeKhac", VanDeKhac),
                    new XElement("createdDate", CreatedDate.ToString()))
                );

            return xDoc;
        }
    }
}
