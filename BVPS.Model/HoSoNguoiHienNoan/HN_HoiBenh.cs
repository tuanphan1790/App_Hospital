using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model.HoSoNguoiHienNoan
{
    public class HN_HoiBenh : BaseBenhNhan
    {
        public HN_HoiBenh(string maBN) : base(maBN)
        {
        }

        public bool HaveData_TienSuNoiKhoa { set; get; }
        public string DetailData_TienSuNoiKhoa { set; get; }

        public bool HaveData_TienSuNgoaiKhoa { set; get; }
        public string DetailData_TienSuNgoaiKhoa { set; get; }

        public DateTime NgayTao { set; get; }

        public HN_HoiBenh(XDocument xDoc)
        {
            var xBTD = xDoc.Element("HN_HB");
            this.Id = Convert.ToInt32(xBTD.Attribute("Id").Value);
            this.MaBN = xBTD.Attribute("MaBN").Value;

            this.HaveData_TienSuNoiKhoa = Convert.ToBoolean(xBTD.Element("HaveData_TienSuNoiKhoa").Value);
            this.DetailData_TienSuNoiKhoa = xBTD.Element("DetailData_TienSuNoiKhoa").Value;
            this.HaveData_TienSuNgoaiKhoa = Convert.ToBoolean(xBTD.Element("HaveData_TienSuNgoaiKhoa").Value);
            this.DetailData_TienSuNgoaiKhoa = xBTD.Element("DetailData_TienSuNgoaiKhoa").Value;

            this.NgayTao = DateTime.ParseExact(xBTD.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HN_HB", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("HaveData_TienSuNoiKhoa", HaveData_TienSuNoiKhoa),
                    new XElement("DetailData_TienSuNoiKhoa", DetailData_TienSuNoiKhoa),
                    new XElement("HaveData_TienSuNgoaiKhoa", HaveData_TienSuNgoaiKhoa),
                    new XElement("DetailData_TienSuNgoaiKhoa", DetailData_TienSuNgoaiKhoa),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
