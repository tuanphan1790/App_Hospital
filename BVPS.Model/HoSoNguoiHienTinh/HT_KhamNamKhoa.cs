using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HT_KhamNamKhoa : BaseBenhNhan
    {
        public HT_KhamNamKhoa(string maBN) : base(maBN)
        {
        }

        public string TTTrai { set; get; }
        public string TTPhai { set; get; }
        public string MaoTinh { set; get; }
        public string OngDanTinh { set; get; }
        public string Varicole { set; get; }
        public string DuongVat { set; get; }
        public string DacTinhSinhSan { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public HT_KhamNamKhoa(XDocument xDoc)
        {
            var xKNK = xDoc.Element("HT_KNK");
            this.Id = Convert.ToInt32(xKNK.Attribute("Id").Value);
            this.MaBN = xKNK.Attribute("MaBN").Value;

            this.TTTrai = xKNK.Element("TTTrai").Value;
            this.TTPhai = xKNK.Element("TTPhai").Value;
            this.MaoTinh = xKNK.Element("MaoTinh").Value;
            this.OngDanTinh = xKNK.Element("OngDanTinh").Value;
            this.Varicole = xKNK.Element("Varicole").Value;
            this.DuongVat = xKNK.Element("DuongVat").Value;
            this.DacTinhSinhSan = xKNK.Element("DacTinhSinhSan").Value;
            this.GhiChu = xKNK.Element("GhiChu").Value;

            this.NgayTao = DateTime.ParseExact(xKNK.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HT_KNK", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("TTTrai", TTTrai),
                    new XElement("TTPhai", TTPhai),
                    new XElement("MaoTinh", MaoTinh),
                    new XElement("OngDanTinh", OngDanTinh),
                    new XElement("Varicole", Varicole),
                    new XElement("DuongVat", DuongVat),
                    new XElement("DacTinhSinhSan", DacTinhSinhSan),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
