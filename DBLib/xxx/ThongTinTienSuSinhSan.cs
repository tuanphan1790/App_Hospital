using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLib
{
    class ThongTinTienSuSinhSan
    {
        public UInt64 Patient_ID { set; get; }
        public string Patient_Code { set; get; }

        public int SoLanCoThai { set; get; }
        public int SoLuongDeConSong { set; get; }
        public int NaoHut { set; get; }
        public int ThaiLuu { set; get; }
        public int ChuaNgoaiDaCon { set; get; }
        public string ChuaTrung { set; get; }

        public DateTime CreatedDate { set; get; }

        public ThongTinTienSuSinhSan(UInt64 id, string code)
        {
            this.Patient_ID = id;
            this.Patient_Code = code;
        }

        public ThongTinTienSuSinhSan(XDocument xDoc)
        {
            var xTTTSSS = xDoc.Element("TTTSSS");
            this.Patient_ID = Convert.ToUInt64(xTTTSSS.Attribute("id").Value);
            this.Patient_Code = xTTTSSS.Attribute("code").Value;

            this.SoLanCoThai = Convert.ToInt32(xTTTSSS.Element("SoLanCoThai").Value);
            this.SoLuongDeConSong = Convert.ToInt32(xTTTSSS.Element("SoLuongDeConSong").Value);
            this.NaoHut = Convert.ToInt32(xTTTSSS.Element("NaoHut").Value);
            this.ThaiLuu = Convert.ToInt32(xTTTSSS.Element("ThaiLuu").Value);
            this.ChuaNgoaiDaCon = Convert.ToInt32(xTTTSSS.Element("ChuaNgoaiDaCon").Value);
            this.ChuaTrung = xTTTSSS.Element("ChuaTrung").Value;

            this.CreatedDate = Convert.ToDateTime(xTTTSSS.Element("createdDate").Value);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("TTTSKN", new XAttribute("id", Patient_ID.ToString()), new XAttribute("code", Patient_Code),
                    new XElement("SoLanCoThai", SoLanCoThai),
                    new XElement("SoLuongDeConSong", SoLuongDeConSong),
                    new XElement("NaoHut", NaoHut),
                    new XElement("ThaiLuu", ThaiLuu),
                    new XElement("ChuaNgoaiDaCon", ChuaNgoaiDaCon),
                    new XElement("ChuaTrung", ChuaTrung),
                    new XElement("createdDate", CreatedDate.ToString()))
                );

            return xDoc;
        }
    }
}
