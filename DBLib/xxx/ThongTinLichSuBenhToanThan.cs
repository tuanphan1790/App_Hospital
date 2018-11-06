using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLib
{
    class ThongTinLichSuBenhToanThan
    {
        public UInt64 Patient_ID { set; get; }
        public string Patient_Code { set; get; }

        public string TieuDuong { set; get; }
        public string Lao { set; get; }
        public string BenhKhac { set; get; }
        public string DieuTriNoiKhoa { set; get; }
        public string TienSuPhauThuat { set; get; }
        public string NhiemTrungTietLieu { set; get; }

        public DateTime CreatedDate { set; get; }

        public ThongTinLichSuBenhToanThan(UInt64 id, string code)
        {
            this.Patient_ID = id;
            this.Patient_Code = code;
        }

        public ThongTinLichSuBenhToanThan(XDocument xDoc)
        {
            var xTTLSBTT = xDoc.Element("TTLSBTT");
            this.Patient_ID = Convert.ToUInt64(xTTLSBTT.Attribute("id").Value);
            this.Patient_Code = xTTLSBTT.Attribute("code").Value;

            this.TieuDuong = xTTLSBTT.Element("TieuDuong").Value;
            this.Lao = xTTLSBTT.Element("Lao").Value;
            this.BenhKhac = xTTLSBTT.Element("BenhKhac").Value;
            this.DieuTriNoiKhoa = xTTLSBTT.Element("DieuTriNoiKhoa").Value;
            this.TienSuPhauThuat = xTTLSBTT.Element("TienSuPhauThuat").Value;
            this.NhiemTrungTietLieu = xTTLSBTT.Element("NhiemTrungTietLieu").Value;

            this.CreatedDate = Convert.ToDateTime(xTTLSBTT.Element("createdDate").Value);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("TTLSBTT", new XAttribute("id", Patient_ID.ToString()), new XAttribute("code", Patient_Code),
                    new XElement("TieuDuong", TieuDuong),
                    new XElement("Lao", Lao),
                    new XElement("BenhKhac", BenhKhac),
                    new XElement("DieuTriNoiKhoa", DieuTriNoiKhoa),
                    new XElement("TienSuPhauThuat", TienSuPhauThuat),
                    new XElement("NhiemTrungTietLieu", NhiemTrungTietLieu),
                    new XElement("createdDate", CreatedDate.ToString()))
                );

            return xDoc;
        }
    }
}
