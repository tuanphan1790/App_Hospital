using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HN_KhamBenh : BaseBenhNhan
    {
        public HN_KhamBenh(string maBN) : base(maBN)
        {
        }

        public string Height { set; get; }
        public string Weight { set; get; }
        public string HuyetAp { set; get; }
        public string Mach { set; get; }
        public string NhietDo { set; get; }

        public string SinhDucNgoai { set; get; }
        public string AmHo { set; get; }
        public string AmDao { set; get; }
        public string ViemLoTuyenCoTuCung { set; get; }
        public string SuiCoTuCung { set; get; }
        public string PolypCoTuCung { set; get; }
        public string HaiCTCCoTuCung { set; get; }
        public string CoTuCungBinhThuong { set; get; }
        public string TuTheTuCung { set; get; }
        public string TheTichTuCung { set; get; }
        public string MatDoTuCung { set; get; }
        public string DiDongTuCung { set; get; }
        public string HaiPhanPhu { set; get; }
        public string GhiChu { set; get; }
        public DateTime NgayTao { set; get; }


        public HN_KhamBenh(XDocument xDoc)
        {
            var xKHC = xDoc.Element("HN_KHXC");
            this.Id = Convert.ToInt32(xKHC.Attribute("Id").Value);
            this.MaBN = xKHC.Attribute("MaBN").Value;

            this.Height = xKHC.Element("Height").Value;
            this.Weight = xKHC.Element("Weight").Value;
            this.HuyetAp = xKHC.Element("HuyetAp").Value;
            this.Mach = xKHC.Element("Mach").Value;
            this.NhietDo = xKHC.Element("NhietDo").Value; 

            this.SinhDucNgoai = xKHC.Element("SinhDucNgoai").Value;
            this.AmHo = xKHC.Element("AmHo").Value;
            this.AmDao = xKHC.Element("AmDao").Value;
            this.ViemLoTuyenCoTuCung = xKHC.Element("ViemLoTuyenCoTuCung").Value;
            this.SuiCoTuCung = xKHC.Element("SuiCoTuCung").Value;
            this.PolypCoTuCung = xKHC.Element("PolypCoTuCung").Value;
            this.HaiCTCCoTuCung = xKHC.Element("HaiCTCCoTuCung").Value;
            this.CoTuCungBinhThuong = xKHC.Element("CoTuCungBinhThuong").Value;
            this.TuTheTuCung = xKHC.Element("TuTheTuCung").Value;
            this.TheTichTuCung = xKHC.Element("TheTichTuCung").Value;
            this.MatDoTuCung = xKHC.Element("MatDoTuCung").Value;
            this.DiDongTuCung = xKHC.Element("DiDongTuCung").Value;
            this.HaiPhanPhu = xKHC.Element("HaiPhanPhu").Value;
            this.GhiChu = xKHC.Element("GhiChu").Value;

            this.NgayTao = DateTime.ParseExact(xKHC.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HN_KHXC", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("Height", Height),
                    new XElement("Weight", Weight),
                    new XElement("HuyetAp", HuyetAp),
                    new XElement("Mach", Mach),
                    new XElement("NhietDo", NhietDo),
                    new XElement("SinhDucNgoai", SinhDucNgoai),
                    new XElement("AmHo", AmHo),
                    new XElement("AmDao", AmDao),
                    new XElement("ViemLoTuyenCoTuCung", ViemLoTuyenCoTuCung),
                    new XElement("SuiCoTuCung", SuiCoTuCung),
                    new XElement("PolypCoTuCung", PolypCoTuCung),
                    new XElement("HaiCTCCoTuCung", HaiCTCCoTuCung),
                    new XElement("CoTuCungBinhThuong", CoTuCungBinhThuong),
                    new XElement("TuTheTuCung", TuTheTuCung),
                    new XElement("TheTichTuCung", TheTichTuCung),
                    new XElement("MatDoTuCung", MatDoTuCung),
                    new XElement("DiDongTuCung", DiDongTuCung),
                    new XElement("HaiPhanPhu", HaiPhanPhu),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
