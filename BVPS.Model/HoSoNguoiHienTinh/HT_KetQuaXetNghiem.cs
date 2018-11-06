using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HT_KetQuaXetNghiem : BaseBenhNhan
    {
        public HT_KetQuaXetNghiem(string maBN) : base(maBN)
        {
        }

        public string NhomMau { set; get; }
        public string HIV { set; get; }
        public string BW { set; get; }
        public string HBsAg { set; get; }
        public string AntiHCV { set; get; }
        public int SoLanKiemTra { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public HT_KetQuaXetNghiem() { }

        public HT_KetQuaXetNghiem(XDocument xDoc)
        {
            var xTTKQXN = xDoc.Element("HT_KQXN");
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

        public virtual XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HT_KQXN", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("NhomMau", NhomMau),
                    new XElement("HIV", HIV),
                    new XElement("BW", BW),
                    new XElement("HBsAg", HBsAg),
                    new XElement("AntiHCV", AntiHCV),
                    new XElement("SoLanKiemTra", SoLanKiemTra),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy"))
                ));

            return xDoc;
        }
    }
}
