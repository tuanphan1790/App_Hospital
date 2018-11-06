using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HN_ThongTinNguoiHienNoan : BaseThongTinBenhNhan
    {
        public HN_ThongTinNguoiHienNoan(string maBN): base(maBN)
        {
        }
        
        public DateTime NgayTao { set; get; }

        public HN_ThongTinNguoiHienNoan(XDocument xDoc)
        {
            var xDLBNHT = xDoc.Element("HN_TTBN");
            this.Id = Convert.ToInt32(xDLBNHT.Attribute("Id").Value);
            this.MaBN = xDLBNHT.Attribute("MaBN").Value;

            var xTTCB = xDLBNHT.Element("ThongTinCoBan");
            this.HoVaTen = xTTCB.Element("HoVaTen").Value;
            this.NgaySinh = DateTime.ParseExact(xTTCB.Element("NgaySinh").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            this.SoDienThoai = xTTCB.Element("SoDienThoai").Value;
            this.Email = xTTCB.Element("Email").Value;
            this.QuocTichID = Convert.ToInt32(xTTCB.Element("QuocTichID").Value);
            this.DanToc = Convert.ToInt32(xTTCB.Element("DanToc").Value);
            this.Tinh_ThanhPho = xTTCB.Element("Tinh_ThanhPho").Value;
            this.Quan_Huyen = xTTCB.Element("Quan_Huyen").Value;
            this.SoCMND = xTTCB.Element("SoCMND").Value;
            this.NgayCap = DateTime.ParseExact(xTTCB.Element("NgayCap").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            this.DiaChiNoiCap = xTTCB.Element("DiaChiNoiCap").Value;
            this.NguyenQuan = xTTCB.Element("NguyenQuan").Value;

            var xFPBlob = xDLBNHT.Element("FPBlob");
            this.VT_CaiPhai = xFPBlob.Element("VT_CaiPhai").Value;
            this.VT_CaiTrai = xFPBlob.Element("VT_CaiTrai").Value;
            this.VT_TroPhai = xFPBlob.Element("VT_TroPhai").Value;
            this.VT_TroTrai = xFPBlob.Element("VT_TroTrai").Value;

            var xFPIma = xDLBNHT.Element("FPIma");
            this.VT_CaiPhai_HinhAnh = xFPIma.Element("VT_CaiPhai_HinhAnh").Value;
            this.VT_CaiTrai_HinhAnh = xFPIma.Element("VT_CaiTrai_HinhAnh").Value;
            this.VT_TroPhai_HinhAnh = xFPIma.Element("VT_TroPhai_HinhAnh").Value;
            this.VT_TroTrai_HinhAnh = xFPIma.Element("VT_TroTrai_HinhAnh").Value;

            this.FlagAllowAddPattern = Convert.ToBoolean(xDLBNHT.Element("FlagAllowAddPattern").Value);
            this.NgayTao = DateTime.ParseExact(xDLBNHT.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HN_TTBN", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                                new XElement("ThongTinCoBan",
                                    new XElement("HoVaTen", HoVaTen),
                                    new XElement("NgaySinh", NgaySinh.ToString("dd-MM-yyyy")),
                                    new XElement("SoDienThoai", SoDienThoai),
                                    new XElement("Email", Email),
                                    new XElement("QuocTichID", QuocTichID),
                                    new XElement("DanToc", DanToc),
                                    new XElement("Tinh_ThanhPho", Tinh_ThanhPho),
                                    new XElement("Quan_Huyen", Quan_Huyen),
                                    new XElement("SoCMND", SoCMND),
                                    new XElement("NgayCap", NgayCap.ToString("dd-MM-yyyy")),
                                    new XElement("DiaChiNoiCap", DiaChiNoiCap),
                                    new XElement("NguyenQuan", NguyenQuan)),
                                new XElement("FPBlob",
                                    new XElement("VT_CaiPhai", VT_CaiPhai),
                                    new XElement("VT_CaiTrai", VT_CaiTrai),
                                    new XElement("VT_TroPhai", VT_TroPhai),
                                    new XElement("VT_TroTrai", VT_TroTrai)),
                                new XElement("FPIma",
                                    new XElement("VT_CaiPhai_HinhAnh", VT_CaiPhai_HinhAnh),
                                    new XElement("VT_CaiTrai_HinhAnh", VT_CaiTrai_HinhAnh),
                                    new XElement("VT_TroPhai_HinhAnh", VT_TroPhai_HinhAnh),
                                    new XElement("VT_TroTrai_HinhAnh", VT_TroTrai_HinhAnh)),
                                new XElement("FlagAllowAddPattern", FlagAllowAddPattern),
                                new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy"))
                                    ));
            return xDoc;
        }
    }
}
