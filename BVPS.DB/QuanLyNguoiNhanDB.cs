using BVPS.DB.DBContext;
using BVPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.DB
{
    public class QuanLyNguoiNhanDB
    {
        QuanLyNguoiNhanMauDataContext db;

        public QuanLyNguoiNhanDB()
        {
            db = new QuanLyNguoiNhanMauDataContext();
        }

        public QuanLyNguoiNhanDB(string con)
        {
            db = new QuanLyNguoiNhanMauDataContext(con);
        }

        public List<QuanLyNguoiNhanMau> GetAllNguoiNhanMau()
        {
            List<QuanLyNguoiNhanMau> listQLM = new List<QuanLyNguoiNhanMau>();
            foreach (var bn in db.dtb_quanlymaus)
            {
                QuanLyNguoiNhanMau x = new QuanLyNguoiNhanMau();
                x.Id = bn.id;
                x.MaMau = bn.ma_nguoi_hien;
                x.PheDuyet = Convert.ToBoolean(bn.is_approve);
                x.NgayLuuTru = Convert.ToDateTime(bn.ngay_luu_tru);
                x.NgaySuDung = Convert.ToDateTime(bn.ngay_su_dung);
                x.MaNguoiNhan = bn.ma_nguoi_nhan;
                x.KetQuaSuDung = bn.ket_qua_su_dung;
                x.HuyMau = Convert.ToBoolean(bn.huy_mau);
                x.NgayHuyMau = Convert.ToDateTime(bn.ngay_huy_mau);
                x.GhiChu = bn.ghi_chu;

                listQLM.Add(x);
            }

            return listQLM;
        }

        public void AddNguoiNhanMau(QuanLyNguoiNhanMau bn)
        {
            dtb_quanlymau qlm = new dtb_quanlymau();
            qlm.ma_nguoi_hien = bn.MaMau;
            qlm.is_approve = bn.PheDuyet;
            qlm.ngay_luu_tru = bn.NgayLuuTru;
            qlm.ngay_su_dung = bn.NgaySuDung;
            qlm.ma_nguoi_nhan = bn.MaNguoiNhan;
            qlm.ket_qua_su_dung = bn.KetQuaSuDung;
            qlm.huy_mau = bn.HuyMau;
            qlm.ngay_huy_mau = bn.NgayHuyMau;
            qlm.ghi_chu = bn.GhiChu;

            db.dtb_quanlymaus.InsertOnSubmit(qlm);
            db.SubmitChanges();
        }

        public QuanLyNguoiNhanMau GetNguoiNhanById(int id)
        {
            QuanLyNguoiNhanMau qlm = new QuanLyNguoiNhanMau();
            foreach (var bn in db.dtb_quanlymaus)
            {
                if (bn.id == id)
                {
                    QuanLyNguoiNhanMau x = new QuanLyNguoiNhanMau();
                    x.Id = bn.id;
                    x.MaMau = bn.ma_nguoi_hien;
                    x.PheDuyet = Convert.ToBoolean(bn.is_approve);
                    x.NgayLuuTru = Convert.ToDateTime(bn.ngay_luu_tru);
                    x.NgaySuDung = Convert.ToDateTime(bn.ngay_su_dung);
                    x.MaNguoiNhan = bn.ma_nguoi_nhan;
                    x.KetQuaSuDung = bn.ket_qua_su_dung;
                    x.HuyMau = Convert.ToBoolean(bn.huy_mau);
                    x.NgayHuyMau = Convert.ToDateTime(bn.ngay_huy_mau);
                    x.GhiChu = bn.ghi_chu;

                    return x;
                }
            }
            return null;
        }

        public void EditNguoiNhanMau(int id, QuanLyNguoiNhanMau bn)
        {
            List<dtb_quanlymau> listQLMs = (from s in db.dtb_quanlymaus select s).ToList();

            foreach (var qlm in listQLMs)
                if (qlm.id == id)
                {
                    qlm.ma_nguoi_hien = bn.MaMau;
                    qlm.is_approve = bn.PheDuyet;
                    qlm.ngay_luu_tru = bn.NgayLuuTru;
                    qlm.ngay_su_dung = bn.NgaySuDung;
                    qlm.ma_nguoi_nhan = bn.MaNguoiNhan;
                    qlm.ket_qua_su_dung = bn.KetQuaSuDung;
                    qlm.huy_mau = bn.HuyMau;
                    qlm.ngay_huy_mau = bn.NgayHuyMau;
                    qlm.ghi_chu = bn.GhiChu;

                    db.SubmitChanges();
                }
        }

        public void DeleteNguoiNhanMau(int id)
        {
            List<dtb_quanlymau> listQLMs = (from s in db.dtb_quanlymaus select s).ToList();

            foreach (var bn in listQLMs)
                if (bn.id == id)
                {
                    db.dtb_quanlymaus.DeleteOnSubmit(bn);
                    db.SubmitChanges();
                }
        }
    }
}
