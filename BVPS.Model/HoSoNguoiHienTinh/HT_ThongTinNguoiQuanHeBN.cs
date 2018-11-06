using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model.HoSoNguoiHienTinh
{
    public class HT_ThongTinNguoiQuanHeBN : BaseBenhNhan
    {
        public HT_ThongTinNguoiQuanHeBN(string maBN) : base(maBN)
        {
        }

        public string HoVaTen { set; get; }
        public DateTime NgaySinh { set; get; }
        public string SoCMND { set; get; }
        public DateTime NgayCap { set; get; }
        public string NguyenQuan { set; get; }
        public string DiaChiNoiCap { set; get; }
        public string SoDienThoai { set; get; }
        public string Email { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public HT_ThongTinNguoiQuanHeBN(XDocument xDoc)
        {
            var xTTNVDHT = xDoc.Element("HT_NQH");
            this.Id = Convert.ToInt32(xTTNVDHT.Attribute("Id").Value);
            this.MaBN = xTTNVDHT.Attribute("MaBN").Value;

            this.HoVaTen = xTTNVDHT.Element("HoVaTen").Value;
            this.NgaySinh = DateTime.ParseExact(xTTNVDHT.Element("NgaySinh").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            this.Email = xTTNVDHT.Element("Email").Value;
            this.SoCMND = xTTNVDHT.Element("SoCMND").Value;
            this.NgayCap = DateTime.ParseExact(xTTNVDHT.Element("NgayCap").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            this.NguyenQuan = xTTNVDHT.Element("NguyenQuan").Value;
            this.DiaChiNoiCap = xTTNVDHT.Element("DiaChiNoiCap").Value;
            this.SoDienThoai = xTTNVDHT.Element("SoDienThoai").Value;

            this.NgayTao = DateTime.ParseExact(xTTNVDHT.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HT_NQH", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                                new XElement("HoVaTen", HoVaTen),
                                new XElement("NgaySinh", NgaySinh.ToString("dd-MM-yyyy")),
                                new XElement("Email", Email),
                                new XElement("SoCMND", SoCMND),
                                new XElement("NgayCap", NgayCap.ToString("dd-MM-yyyy")),
                                new XElement("NguyenQuan", NguyenQuan),
                                new XElement("DiaChiNoiCap", DiaChiNoiCap),
                                new XElement("SoDienThoai", SoDienThoai),
                                new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy"))));

            return xDoc;
        }
    }
}
