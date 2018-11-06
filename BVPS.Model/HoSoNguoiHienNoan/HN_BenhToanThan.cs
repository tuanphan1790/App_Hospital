using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model.HoSoNguoiHienNoan
{
    public class HN_BenhToanThan : BaseBenhNhan
    {
        public HN_BenhToanThan(string maBN): base(maBN)
        {
        }

        public string TieuDuong { set; get; }
        public string Lao { set; get; }
        public string BenhKhac { set; get; }
        public string DieuTriNoiKhoa { set; get; }
        public string TienSuPhauThuat { set; get; }
        public string NhiemTrungTietLieu { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public HN_BenhToanThan(XDocument xDoc)
        {
            var xBTT = xDoc.Element("HN_BTT");
            this.Id = Convert.ToInt32(xBTT.Attribute("Id").Value);
            this.MaBN = xBTT.Attribute("MaBN").Value;

            this.TieuDuong = xBTT.Element("TieuDuong").Value;
            this.Lao = xBTT.Element("Lao").Value;
            this.BenhKhac = xBTT.Element("BenhKhac").Value;
            this.DieuTriNoiKhoa = xBTT.Element("DieuTriNoiKhoa").Value;
            this.TienSuPhauThuat = xBTT.Element("TienSuPhauThuat").Value;
            this.NhiemTrungTietLieu = xBTT.Element("NhiemTrungTietLieu").Value;
            this.GhiChu = xBTT.Element("GhiChu").Value;

            this.NgayTao = DateTime.ParseExact(xBTT.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HN_BTT", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("TieuDuong", TieuDuong),
                    new XElement("Lao", Lao),
                    new XElement("BenhKhac", BenhKhac),
                    new XElement("DieuTriNoiKhoa", DieuTriNoiKhoa),
                    new XElement("TienSuPhauThuat", TienSuPhauThuat),
                    new XElement("NhiemTrungTietLieu", NhiemTrungTietLieu),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
