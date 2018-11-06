using BVPS.DB.DBContext;
using BVPS.Model.UserPermissionInfor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.DB
{
    public class UserInforDB
    {
        ThongTinNguoiDungDataContext db;

        public UserInforDB()
        {
            db = new ThongTinNguoiDungDataContext();
        }

        public UserInforDB(string conn)
        {
            db = new ThongTinNguoiDungDataContext(conn);
        }

        public bool CheckAccountLogin(string userName, string password)
        {
            try
            {
                var ret = db.dtb_members.Where(s => (s.username == userName && s.password == password)).Single();
                if (ret != null)
                    return true;

                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool AddNewUser(NguoiSuDung newMem, ref string mes)
        {
            try
            {
                List<dtb_member> listMembers = (from s in db.dtb_members select s).ToList();
                foreach (var mem in listMembers)
                {
                    if(mem.username == newMem.UserName)
                    {
                        mes = "Trùng tên đăng nhập";
                        return false;
                    }
                }

                dtb_member user = new dtb_member();
                user.fullname = newMem.FullName;
                user.username = newMem.UserName;
                user.password = newMem.Password;
                user.position = newMem.ChucVu;
                user.birthday = newMem.NgaySinh;
                user.email = newMem.Email;
                user.sex = newMem.GioiTinh;
                user.phone = newMem.SoDienThoai;
                user.address = newMem.DiaChi;
                user.is_admin = newMem.IsAdmin;

                db.dtb_members.InsertOnSubmit(user);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditUser(NguoiSuDung oldMem, ref string mes)
        {
            try
            {
                dtb_member user = db.dtb_members.Where(s => (s.username == oldMem.UserName)).Single();
                if (user == null)
                {
                    mes = "Không có người sử dụng";
                    return false;
                }

                user.fullname = oldMem.FullName;
                user.password = oldMem.Password;
                user.position = oldMem.ChucVu;
                user.birthday = oldMem.NgaySinh;
                user.email = oldMem.Email;
                user.sex = oldMem.GioiTinh;
                user.phone = oldMem.SoDienThoai;
                user.address = oldMem.DiaChi;
                user.is_admin = oldMem.IsAdmin;

                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                return false;
            }
        }

        public bool DeleteUser(NguoiSuDung oldMem, ref string mes)
        {
            try
            {
                dtb_member m = db.dtb_members.Where(s => (s.username == oldMem.UserName)).Single();
                if (m == null)
                    return false;

                db.dtb_members.DeleteOnSubmit(m);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                return false;
            }
        }

        public void AddNewFunction(ChucNang fun)
        {
            dtb_function newFun = new dtb_function();
            newFun.name = fun.FunctionName;
            newFun.type = fun.Type;

            db.dtb_functions.InsertOnSubmit(newFun);
            db.SubmitChanges();
        }

        public void DeleteFunction(ChucNang fun)
        {
            dtb_function f = db.dtb_functions.Where(s => s.type == fun.Type).Single();
            if (f == null)
                return;

            db.dtb_functions.DeleteOnSubmit(f);
            db.SubmitChanges();
        }

        public List<ChucNang> GetListFunctions()
        {
            List<ChucNang> listFunctions = new List<ChucNang>();
            foreach(var fun in db.dtb_functions)
            {
                ChucNang cn = new ChucNang();
                cn.Id = fun.id;
                cn.FunctionName = fun.name;
                listFunctions.Add(cn);
            }

            return listFunctions;
        }

        public void SetPermissionForUser(string userName, int functionID, int permission)
        {
            dtb_permission newPermis = new dtb_permission();
            newPermis.username = userName;
            newPermis.function_id = functionID;
            newPermis.permission = permission;

            db.dtb_permissions.InsertOnSubmit(newPermis);
            db.SubmitChanges();
        }

        public void EditPermissionForUser(string userName, int functionID, int permission)
        {
            if (db.dtb_permissions.Any(x => (x.function_id == functionID && x.username == userName)))
            {
                dtb_permission f = db.dtb_permissions.Where(s => (s.function_id == functionID && s.username == userName)).Single();
                if (f == null)
                    return;

                f.permission = permission;
                db.SubmitChanges();
            }
            else
            {
                SetPermissionForUser(userName, functionID, permission);
            }
        }

        public List<PhanQuyen> GetPermissionByUser(string userName)
        {
            List<PhanQuyen> listRTs = new List<PhanQuyen>();

            List<dtb_permission> listPMs = (from s in db.dtb_permissions select s).ToList();

            foreach (var pm in listPMs)
            {
                if (pm.username == userName)
                {
                    PhanQuyen p = new PhanQuyen();
                    p.UserName = userName;
                    p.Id = pm.id;
                    p.FunctionID = Convert.ToInt32(pm.function_id);
                    p.Permission = Convert.ToInt32(pm.permission);

                    listRTs.Add(p);
                }
            }

            return listRTs;
        }

        public NguoiSuDung GetUserInfor(string userName)
        {
            NguoiSuDung nsd = new NguoiSuDung();
            dtb_member mem = db.dtb_members.Where(s => (s.username == userName)).Single();

            if (mem == null)
                return null;

            nsd.IsAdmin = Convert.ToBoolean(mem.is_admin);
            nsd.UserName = userName;
            nsd.ViTri = mem.position;
            nsd.FullName = mem.fullname;
            nsd.NgaySinh = Convert.ToDateTime(mem.birthday);
            nsd.Email = mem.email;
            nsd.GioiTinh = mem.sex;
            nsd.SoDienThoai = mem.phone;
            nsd.DiaChi = mem.address;
            nsd.ChucVu = mem.position;

            return nsd;
        }

        public List<NguoiSuDung> GetListUserInfors()
        {
            List<NguoiSuDung> listNSDs = new List<NguoiSuDung>();

            List<dtb_member> listMembers = (from s in db.dtb_members select s).ToList();
            foreach(var mem in listMembers)
            {
                listNSDs.Add(GetUserInfor(mem.username));
            }

            return listNSDs;
        }
    }
}
