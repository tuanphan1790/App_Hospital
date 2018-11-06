using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HN_TienSuSinhSan : BaseBenhNhan
    {
        public HN_TienSuSinhSan(string maBN) : base(maBN)
        {
        }

        public int SoLanCoThai { set; get; }
        public int SoLuongDeConSong { set; get; }
        public int NaoHut { set; get; }
        public int ThaiLuu { set; get; }
        public int ChuaNgoaiDaCon { set; get; }
        public string ChuaTrung { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public HN_TienSuSinhSan(XDocument xDoc)
        {
            var xTSSS = xDoc.Element("HN_TSSS");
            this.Id = Convert.ToInt32(xTSSS.Attribute("Id").Value);
            this.MaBN = xTSSS.Attribute("MaBN").Value;

            this.SoLanCoThai = Convert.ToInt32(xTSSS.Element("SoLanCoThai").Value);
            this.SoLuongDeConSong = Convert.ToInt32(xTSSS.Element("SoLuongDeConSong").Value);
            this.NaoHut = Convert.ToInt32(xTSSS.Element("NaoHut").Value);
            this.ThaiLuu = Convert.ToInt32(xTSSS.Element("ThaiLuu").Value);
            this.ChuaNgoaiDaCon = Convert.ToInt32(xTSSS.Element("ChuaNgoaiDaCon").Value);
            this.ChuaTrung = xTSSS.Element("ChuaTrung").Value;
            this.GhiChu = xTSSS.Element("GhiChu").Value;

            this.NgayTao = DateTime.ParseExact(xTSSS.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HN_TSSS", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("SoLanCoThai", SoLanCoThai),
                    new XElement("SoLuongDeConSong", SoLuongDeConSong),
                    new XElement("NaoHut", NaoHut),
                    new XElement("ThaiLuu", ThaiLuu),
                    new XElement("NaoHut", NaoHut),
                    new XElement("ChuaNgoaiDaCon", ChuaNgoaiDaCon),
                    new XElement("ChuaTrung", ChuaTrung),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
