using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLib
{
    class ThongTinKhamHongVaXuongChau
    {
        public UInt64 Patient_ID { set; get; }
        public string Patient_Code { set; get; }

        public string SinhDucNgoai { set; get; }
        public string AmHo { set; get; }
        public string AmDao { set; get; }
        public string ViemLoTuyenCoTuCung { set; get; }
        public string SuiCotuCung { set; get; }
        public string PoLypCoTuCung { set; get; }
        public string HaiCtcCoTuCung { set; get; }
        public string CoTuCungBinhThuong { set; get; }
        public string TuTheTuCung { set; get; }
        public string TheTichTuCung { set; get; }
        public string MatDoTuCung { set; get; }
        public string DiDongTuCung { set; get; }
        public string HaiPhanPhu { set; get; }

        public DateTime CreatedDate { set; get; }

        public ThongTinKhamHongVaXuongChau(UInt64 id, string code)
        {
            this.Patient_ID = id;
            this.Patient_Code = code;
        }

        public ThongTinKhamHongVaXuongChau(XDocument xDoc)
        {
            var xTTKHVXC = xDoc.Element("TTKHVXC");
            this.Patient_ID = Convert.ToUInt64(xTTKHVXC.Attribute("id").Value);
            this.Patient_Code = xTTKHVXC.Attribute("code").Value;

            this.SinhDucNgoai = xTTKHVXC.Element("SinhDucNgoai").Value;
            this.AmHo = xTTKHVXC.Element("AmHo").Value;
            this.AmDao = xTTKHVXC.Element("AmDao").Value;
            this.ViemLoTuyenCoTuCung = xTTKHVXC.Element("ViemLoTuyenCoTuCung").Value;
            this.SuiCotuCung = xTTKHVXC.Element("SuiCotuCung").Value;
            this.PoLypCoTuCung = xTTKHVXC.Element("PoLypCoTuCung").Value;
            this.HaiCtcCoTuCung = xTTKHVXC.Element("HaiCtcCoTuCung").Value;
            this.CoTuCungBinhThuong = xTTKHVXC.Element("CoTuCungBinhThuong").Value;
            this.TuTheTuCung = xTTKHVXC.Element("TuTheTuCung").Value;
            this.TheTichTuCung = xTTKHVXC.Element("TheTichTuCung").Value;
            this.MatDoTuCung = xTTKHVXC.Element("MatDoTuCung").Value;
            this.DiDongTuCung = xTTKHVXC.Element("DiDongTuCung").Value;
            this.HaiPhanPhu = xTTKHVXC.Element("HaiPhanPhu").Value;

            this.CreatedDate = Convert.ToDateTime(xTTKHVXC.Element("createdDate").Value);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("TTKHVXC", new XAttribute("id", Patient_ID.ToString()), new XAttribute("code", Patient_Code),
                    new XElement("SinhDucNgoai", SinhDucNgoai),
                    new XElement("AmHo", AmHo),
                    new XElement("AmDao", AmDao),
                    new XElement("ViemLoTuyenCoTuCung", ViemLoTuyenCoTuCung),
                    new XElement("SuiCotuCung", SuiCotuCung),
                    new XElement("PoLypCoTuCung", PoLypCoTuCung),
                    new XElement("HaiCtcCoTuCung", HaiCtcCoTuCung),
                    new XElement("CoTuCungBinhThuong", CoTuCungBinhThuong),
                    new XElement("TuTheTuCung", TuTheTuCung),
                    new XElement("TheTichTuCung", TheTichTuCung),
                    new XElement("MatDoTuCung", MatDoTuCung),
                    new XElement("DiDongTuCung", DiDongTuCung),
                    new XElement("HaiPhanPhu", HaiPhanPhu),
                    new XElement("createdDate", CreatedDate.ToString()))
                );

            return xDoc;
        }
    }
}
