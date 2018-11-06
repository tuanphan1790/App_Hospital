using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.Model.UserPermissionInfor
{
    public class NguoiSuDung
    {
        public bool IsAdmin { set; get; }

        public string UserName { set; get; }
        public string Password { set; get; }
        public string FullName { set; get; }
        public string ViTri { set; get; }
        public DateTime NgaySinh { set; get; }
        public string Email { set; get; }
        public string GioiTinh { set; get; }
        public string SoDienThoai { set; get; }
        public string DiaChi { set; get; }
        public string ChucVu { set; get; }
    }
}
