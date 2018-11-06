using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HN_TieuSuKinhNguyet : BaseBenhNhan
    {
        public HN_TieuSuKinhNguyet(string maBN) : base(maBN)
        {
        }

        public int TuoiCoKinhLanDau { set; get; }
        public int ChuKyKinh { set; get; }
        public int SoNgayCoKinh { set; get; }
        public string SoLuong { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public HN_TieuSuKinhNguyet(XDocument xDoc)
        {
            var xTSKN = xDoc.Element("HN_TSKN");
            this.Id = Convert.ToInt32(xTSKN.Attribute("Id").Value);
            this.MaBN = xTSKN.Attribute("MaBN").Value;

            this.TuoiCoKinhLanDau = Convert.ToInt32(xTSKN.Element("TuoiCoKinhLanDau").Value);
            this.ChuKyKinh = Convert.ToInt32(xTSKN.Element("ChuKyKinh").Value);
            this.SoNgayCoKinh = Convert.ToInt32(xTSKN.Element("SoNgayCoKinh").Value);
            this.SoLuong = xTSKN.Element("SoLuong").Value;
            this.GhiChu = xTSKN.Element("GhiChu").Value;

            this.NgayTao = DateTime.ParseExact(xTSKN.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HN_TSKN", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("TuoiCoKinhLanDau", TuoiCoKinhLanDau),
                    new XElement("ChuKyKinh", ChuKyKinh),
                    new XElement("SoNgayCoKinh", SoNgayCoKinh),
                    new XElement("SoLuong", SoLuong),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
