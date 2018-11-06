using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.Model
{
    public class QuanLyNguoiNhanMau
    {
        public int Id { set; get; }
        public string MaMau { set; get; }
        public bool PheDuyet { set; get; }
        public DateTime NgayLuuTru { set; get; }
        public DateTime NgaySuDung { set; get; }
        public string MaNguoiNhan { set; get; }
        public string KetQuaSuDung { set; get; }
        public bool HuyMau { set; get; }
        public DateTime NgayHuyMau { set; get; }
        public string GhiChu { set; get; }
    }
}
