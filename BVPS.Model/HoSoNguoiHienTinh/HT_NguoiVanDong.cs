using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HT_NguoiVanDong : BaseBenhNhan
    {
        public HT_NguoiVanDong(string maBN) : base(maBN)
        {
        }

        public string HoVaTen { set; get; }
        public DateTime NgaySinh { set; get; }
        public string Email { set; get; }
        public string SoCMND { set; get; }
        public DateTime NgayCap { set; get; }
        public string NguyenQuan { set; get; }
        public string DiaChiNoiCap { set; get; }

        public string SoDienThoai { set; get; }
        public string Tinh_ThanhPho { set; get; }
        public string Quan_Huyen { set; get; }
        public string QuanHeVoiNguoiHien { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public HT_NguoiVanDong() { }

        public HT_NguoiVanDong(XDocument xDoc)
        {
            var xTTNVDHT = xDoc.Element("HT_NVD");
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
            this.Tinh_ThanhPho = xTTNVDHT.Element("Tinh_ThanhPho").Value;
            this.Quan_Huyen = xTTNVDHT.Element("Quan_Huyen").Value;
            this.QuanHeVoiNguoiHien = xTTNVDHT.Element("QuanHeVoiNguoiHien").Value;
            this.GhiChu = xTTNVDHT.Element("GhiChu").Value;
            this.NgayTao = DateTime.ParseExact(xTTNVDHT.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public virtual XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HT_NVD", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                                new XElement("HoVaTen", HoVaTen),
                                new XElement("NgaySinh", NgaySinh.ToString("dd-MM-yyyy")),
                                new XElement("Email", Email),
                                new XElement("SoCMND", SoCMND),
                                new XElement("NgayCap", NgayCap.ToString("dd-MM-yyyy")),
                                new XElement("NguyenQuan", NguyenQuan),
                                new XElement("DiaChiNoiCap", DiaChiNoiCap),
                                new XElement("SoDienThoai", SoDienThoai),
                                new XElement("Tinh_ThanhPho", Tinh_ThanhPho),
                                new XElement("Quan_Huyen", Quan_Huyen),
                                new XElement("QuanHeVoiNguoiHien", QuanHeVoiNguoiHien),
                                new XElement("GhiChu", GhiChu),
                                new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy"))));

            return xDoc;
        }
    }
}
