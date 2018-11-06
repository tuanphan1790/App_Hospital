using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.Model
{
    public class BaseThongTinBenhNhan : BaseBenhNhan
    {
        public enum FPType
        {
            NgonCaiPhai = 0,
            NgonCaiTrai = 1,
            NgonTroPhai = 2,
            NgonTroTrai = 3
        }

        public BaseThongTinBenhNhan(string maBN) : base(maBN)
        {
        }

        public BaseThongTinBenhNhan()
        { }

        public string MaTrungTamHTSS { set; get; }

        public string HoVaTen { set; get; }
        public DateTime NgaySinh { set; get; }
        public string SoDienThoai { set; get; }
        public string Email { set; get; }

        public int QuocTichID { set; get; }
        public string Tinh_ThanhPho { set; get; }
        public string Quan_Huyen { set; get; }
        public int DanToc { set; get; }

        public string SoCMND { set; get; }
        public DateTime NgayCap { set; get; }
        public string NguyenQuan { set; get; }
        public string DiaChiNoiCap { set; get; }

        public string VT_CaiPhai { set; get; }
        public string VT_CaiTrai { set; get; }
        public string VT_TroPhai { set; get; }
        public string VT_TroTrai { set; get; }

        public string VT_CaiPhai_HinhAnh { set; get; }
        public string VT_CaiTrai_HinhAnh { set; get; }
        public string VT_TroPhai_HinhAnh { set; get; }
        public string VT_TroTrai_HinhAnh { set; get; }

        public bool FlagApprove { set; get; }
        public bool FlagAllowAddPattern { set; get; }
    }
}
