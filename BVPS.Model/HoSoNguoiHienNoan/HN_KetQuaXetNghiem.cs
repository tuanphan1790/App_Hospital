using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model.HoSoNguoiHienNoan
{
    public class HN_KetQuaXetNghiem : HT_KetQuaXetNghiem
    {
        public HN_KetQuaXetNghiem(string maBN) : base(maBN)
        {

        }

        public HN_KetQuaXetNghiem(XDocument xDoc)
        {
            var xTTKQXN = xDoc.Element("HN_KQXN");
            this.Id = Convert.ToInt32(xTTKQXN.Attribute("Id").Value);
            this.MaBN = xTTKQXN.Attribute("MaBN").Value;

            this.NhomMau = xTTKQXN.Element("NhomMau").Value;
            this.HIV = xTTKQXN.Element("HIV").Value;
            this.BW = xTTKQXN.Element("BW").Value;
            this.HBsAg = xTTKQXN.Element("HBsAg").Value;
            this.AntiHCV = xTTKQXN.Element("AntiHCV").Value;
            this.GhiChu = xTTKQXN.Element("GhiChu").Value;

            this.SoLanKiemTra = Convert.ToInt32(xTTKQXN.Element("SoLanKiemTra").Value);
            this.NgayTao = DateTime.ParseExact(xTTKQXN.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public override XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HN_KQXN", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("NhomMau", NhomMau),
                    new XElement("HIV", HIV),
                    new XElement("BW", BW),
                    new XElement("HBsAg", HBsAg),
                    new XElement("AntiHCV", AntiHCV),
                    new XElement("SoLanKiemTra", SoLanKiemTra),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
