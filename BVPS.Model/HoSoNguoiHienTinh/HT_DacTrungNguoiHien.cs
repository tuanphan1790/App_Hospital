using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HT_DacTrungNguoiHien: BaseBenhNhan
    {
        public HT_DacTrungNguoiHien(string maBN) : base(maBN)
        {
        }

        public HT_DacTrungNguoiHien(XDocument xDoc)
        {
            var xTTDTHT = xDoc.Element("HT_TTDTNH");
            this.Id = Convert.ToInt32(xTTDTHT.Attribute("Id").Value);
            this.MaBN = xTTDTHT.Attribute("MaBN").Value;

            this.ChieuCao = xTTDTHT.Element("ChieuCao").Value;
            this.CanNang = xTTDTHT.Element("CanNang").Value;
            this.MauMat = xTTDTHT.Element("MauMat").Value;
            this.MauToc = xTTDTHT.Element("MauToc").Value;
            this.KieuToc = xTTDTHT.Element("KieuToc").Value;
            this.MauDa = xTTDTHT.Element("MauDa").Value;
            this.GhiChu = xTTDTHT.Element("GhiChu").Value;

            this.NgayTao = DateTime.ParseExact(xTTDTHT.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public string ChieuCao { set; get; }
        public string CanNang { set; get; }
        public string MauMat { set; get; }
        public string MauToc { set; get; }
        public string KieuToc { set; get; }
        public string MauDa { set; get; }
        public string GhiChu { set; get; }

        public DateTime NgayTao { set; get; }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HT_TTDTNH", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("ChieuCao", ChieuCao),
                    new XElement("CanNang", CanNang),
                    new XElement("MauMat", MauMat),
                    new XElement("MauToc", MauToc),
                    new XElement("KieuToc", KieuToc),
                    new XElement("MauDa", MauDa),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy")))
                );

            return xDoc;
        }
    }
}
