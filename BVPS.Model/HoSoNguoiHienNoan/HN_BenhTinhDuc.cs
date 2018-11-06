using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model.HoSoNguoiHienNoan
{
    public class HN_BenhTinhDuc: BaseBenhNhan
    {
        public HN_BenhTinhDuc(string maBN) : base(maBN)
        {
        }

        public string Lau { set; get; }
        public string GiangMai { set; get; }
        public string Chlamydia { set; get; }
        public string BenhKhac { set; get; }
        public string GhiChu { set; get; }
        public DateTime NgayTao { set; get; }

        public HN_BenhTinhDuc(XDocument xDoc)
        {
            var xBTD = xDoc.Element("HN_BTD");
            this.Id = Convert.ToInt32(xBTD.Attribute("Id").Value);
            this.MaBN = xBTD.Attribute("MaBN").Value;

            this.Lau = xBTD.Element("Lau").Value;
            this.GiangMai = xBTD.Element("GiangMai").Value;
            this.Chlamydia = xBTD.Element("Chlamydia").Value;
            this.BenhKhac = xBTD.Element("BenhKhac").Value;
            this.GhiChu = xBTD.Element("GhiChu").Value;

            this.NgayTao = DateTime.ParseExact(xBTD.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HN_BTD", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("Lau", Lau),
                    new XElement("GiangMai", GiangMai),
                    new XElement("Chlamydia", Chlamydia),
                    new XElement("BenhKhac", BenhKhac),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
