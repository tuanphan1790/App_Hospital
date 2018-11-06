using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BVPS.Model
{
    public class HT_TinhDichDo : BaseBenhNhan
    {
        public HT_TinhDichDo(string maBN) : base(maBN)
        {
        }

        public string GhiChu { set; get; }
        public DateTime NgayTao { set; get; }

        public string MauSac { set; get; }
        public string TheTich { set; get; }
        public string LyGiai { set; get; }
        public string PH { set; get; }
        public int MatDo { set; get; }
        public int TongSoTinhTrung { set; get; }
        public int TiLeTinhTrungSong { set; get; }
        public int DiDongTienToi { set; get; }
        public int DiDongKhongTienToi { set; get; }
        public int BatDong { set; get; }
        public int HinhThaiBinhThuong { set; get; }
        public int HinhThaiBatThuong_Dau { set; get; }
        public int HinhThaiBatThuong_Co { set; get; }
        public int HinhThaiBatThuong_Duoi { set; get; }
        public string TeBaoHinhTron { set; get; }

        public HT_TinhDichDo(XDocument xDoc)
        {
            var xTDD = xDoc.Element("HT_TDD");
            this.Id = Convert.ToInt32(xTDD.Attribute("Id").Value);
            this.MaBN = xTDD.Attribute("MaBN").Value;

            this.MauSac = xTDD.Element("MauSac").Value;
            this.TheTich = xTDD.Element("TheTich").Value;
            this.LyGiai = xTDD.Element("LyGiai").Value;
            this.PH = xTDD.Element("PH").Value;
            this.MatDo = Convert.ToInt32(xTDD.Element("MatDo").Value);
            this.TongSoTinhTrung = Convert.ToInt32(xTDD.Element("TongSoTinhTrung").Value);
            this.TiLeTinhTrungSong = Convert.ToInt32(xTDD.Element("TiLeTinhTrungSong").Value);
            this.DiDongTienToi = Convert.ToInt32(xTDD.Element("DiDongTienToi").Value);
            this.DiDongKhongTienToi = Convert.ToInt32(xTDD.Element("DiDongKhongTienToi").Value);
            this.BatDong = Convert.ToInt32(xTDD.Element("BatDong").Value);
            this.HinhThaiBinhThuong = Convert.ToInt32(xTDD.Element("HinhThatBinhThuong").Value);
            this.HinhThaiBatThuong_Dau = Convert.ToInt32(xTDD.Element("HinhThaiBatThuong_Dau").Value);
            this.HinhThaiBatThuong_Co = Convert.ToInt32(xTDD.Element("HinhThaiBatThuong_Co").Value);
            this.HinhThaiBatThuong_Duoi = Convert.ToInt32(xTDD.Element("HinhThaiBatThuong_Duoi").Value);
            this.TeBaoHinhTron = xTDD.Element("TeBaoHinhTron").Value;

            this.GhiChu = xTDD.Element("GhiChu").Value;
            this.NgayTao = DateTime.ParseExact(xTDD.Element("NgayTao").Value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("HT_TDD", new XAttribute("Id", Id.ToString()), new XAttribute("MaBN", MaBN),
                    new XElement("MauSac", MauSac),
                    new XElement("TheTich", TheTich),
                    new XElement("LyGiai", LyGiai),
                    new XElement("PH", PH),
                    new XElement("MatDo", MatDo),
                    new XElement("TongSoTinhTrung", TongSoTinhTrung),
                    new XElement("TiLeTinhTrungSong", TiLeTinhTrungSong),
                    new XElement("DiDongTienToi", DiDongTienToi),
                    new XElement("DiDongKhongTienToi", DiDongKhongTienToi),
                    new XElement("BatDong", BatDong),
                    new XElement("HinhThatBinhThuong", HinhThaiBinhThuong),
                    new XElement("HinhThaiBatThuong_Dau", HinhThaiBatThuong_Dau),
                    new XElement("HinhThaiBatThuong_Co", HinhThaiBatThuong_Co),
                    new XElement("HinhThaiBatThuong_Duoi", HinhThaiBatThuong_Duoi),
                    new XElement("TeBaoHinhTron", TeBaoHinhTron),
                    new XElement("GhiChu", GhiChu),
                    new XElement("NgayTao", NgayTao.ToString("dd-MM-yyyy"))
                ));

            return xDoc;
        }
    }
}
