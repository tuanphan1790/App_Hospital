using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HT_LuuTruMau : BaseBenhNhan
    {
        public HT_LuuTruMau(string maBN) : base(maBN)
        {
        }

        public string MaMau { set; get; }
        public bool FlagUsed { set; get; }

        public string MatDo { set; get; }
        public string DiDong { set; get; }
        public string HinhDang { set; get; }
        public string ViTri { set; get; }
        public bool DuDieuKienLuuTru { set; get; }
        public string LyDoLuu { set; get; }
        public bool BenhDiTruyen { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public HT_LuuTruMau(XDocument xDoc)
        {
            var xTTLTM = xDoc.Element("HT_LTM");
            this.Id = Convert.ToInt32(xTTLTM.Attribute("Id").Value);
            this.MaBN = xTTLTM.Attribute("MaBN").Value;

            this.MaMau = xTTLTM.Element("MaMau").Value;
            this.FlagUsed = Convert.ToBoolean(xTTLTM.Element("FlagUsed").Value);
            this.MatDo = xTTLTM.Element("MatDo").Value;
            this.DiDong = xTTLTM.Element("DiDong").Value;
            this.HinhDang = xTTLTM.Element("HinhDang").Value;
            this.ViTri = xTTLTM.Element("ViTri").Value;
            this.DuDieuKienLuuTru = Convert.ToBoolean(xTTLTM.Element("DuDieuKienLuuTru").Value);
            this.LyDoLuu = xTTLTM.Element("LyDoLuu").Value;
            this.BenhDiTruyen = Convert.ToBoolean(xTTLTM.Element("BenhDiTruyen").Value);
            this.GhiChu = xTTLTM.Element("GhiChu").Value;

            this.NgayTao = DateTime.ParseExact(xTTLTM.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HT_LTM", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("MaMau", MaMau),
                    new XElement("FlagUsed", FlagUsed),
                    new XElement("MatDo", MatDo),
                    new XElement("DiDong", DiDong),
                    new XElement("HinhDang", HinhDang),
                    new XElement("ViTri", ViTri),
                    new XElement("DuDieuKienLuuTru", DuDieuKienLuuTru.ToString()),
                    new XElement("LyDoLuu", LyDoLuu),
                    new XElement("BenhDiTruyen", BenhDiTruyen.ToString()),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
