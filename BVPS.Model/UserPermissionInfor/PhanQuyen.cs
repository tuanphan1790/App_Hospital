using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.Model.UserPermissionInfor
{
    public class PhanQuyen
    {
        private int PermissDelete = 0x8;
        private int PermissEdit = 0x4;
        private int PermissAdd = 0x2;
        private int PermissView = 0x1;

        public int Id { set; get; }
        public int FunctionID { set; get; }
        public string UserName { set; get; }
        public int Permission { set; get; }

        public bool View()
        {
            return (Permission & PermissView) == PermissView;
        }
        public bool Add()
        {
            return (Permission & PermissAdd) == PermissAdd;
        }
        public bool Edit()
        {
            return (Permission & PermissEdit) == PermissEdit;
        }
        public bool Delete()
        {
            return (Permission & PermissDelete) == PermissDelete;
        }
    }
}
