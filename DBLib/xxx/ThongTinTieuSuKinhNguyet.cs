using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLib
{
    class ThongTinTieuSuKinhNguyet
    {
        public UInt64 Patient_ID { set; get; }
        public string Patient_Code { set; get; }

        public int TuoiCoKinhLanDau { set; get; }
        public int ChuKyKinh { set; get; }
        public int SoNgayCoKinh { set; get; }
        public string SoLuong { set; get; }

        public DateTime CreatedDate { set; get; }

        public ThongTinTieuSuKinhNguyet(UInt64 id, string code)
        {
            this.Patient_ID = id;
            this.Patient_Code = code;
        }

        public ThongTinTieuSuKinhNguyet(XDocument xDoc)
        {
            var xTTTSKN = xDoc.Element("TTTSKN");
            this.Patient_ID = Convert.ToUInt64(xTTTSKN.Attribute("id").Value);
            this.Patient_Code = xTTTSKN.Attribute("code").Value;

            this.TuoiCoKinhLanDau = Convert.ToInt32(xTTTSKN.Element("TuoiCoKinhLanDau").Value);
            this.ChuKyKinh = Convert.ToInt32(xTTTSKN.Element("ChuKyKinh").Value);
            this.SoNgayCoKinh = Convert.ToInt32(xTTTSKN.Element("SoNgayCoKinh").Value);
            this.SoLuong = xTTTSKN.Element("SoLuong").Value;

            this.CreatedDate = Convert.ToDateTime(xTTTSKN.Element("createdDate").Value);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("TTTSKN", new XAttribute("id", Patient_ID.ToString()), new XAttribute("code", Patient_Code),
                    new XElement("TuoiCoKinhLanDau", TuoiCoKinhLanDau),
                    new XElement("ChuKyKinh", ChuKyKinh),
                    new XElement("SoNgayCoKinh", SoNgayCoKinh),
                    new XElement("SoLuong", SoLuong),
                    new XElement("createdDate", CreatedDate.ToString()))
                );

            return xDoc;
        }
    }
}
