using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BVPS.Model;
using BVPS.DB.DBContext;
using BVPS.Model.HoSoNguoiHienNoan;
using libzkfpcsharp;

namespace BVPS.DB
{
    public class BenhNhanHienNoanDB : BaseBenhNhan
    {
        ThongTinBenhNhanHienNoanDataContext db;

        public BenhNhanHienNoanDB() : base()
        {
            db = new ThongTinBenhNhanHienNoanDataContext();
        }

        public BenhNhanHienNoanDB(string con) : base(con)
        {
            db = new ThongTinBenhNhanHienNoanDataContext(con);
        }

        #region Thong Tin Benh Nhan Hien Noan
        public List<HN_ThongTinNguoiHienNoan> GetAllNguoiHienNoan()
        {
            List<HN_ThongTinNguoiHienNoan> listRTs = new List<HN_ThongTinNguoiHienNoan>();

            List<dtb_patient_ovule_send> listNHNs = (from s in db.dtb_patient_ovule_sends select s).ToList();

            foreach (var nh in listNHNs)
            {
                HN_ThongTinNguoiHienNoan n = GetInformationPatient(nh.patient_code);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public HN_ThongTinNguoiHienNoan CheckDuplicateNoCMND(string noCMND)
        {
            foreach(var bn in GetAllNguoiHienNoan())
            {
                if (bn.SoCMND == noCMND)
                    return bn;
            }

            return null;
        }

        public Dictionary<string, string> GetListBlobBytes(BaseThongTinBenhNhan.FPType typeFP)
        {
            try
            {
                Dictionary<string, string> dicBlobs = new Dictionary<string, string>();

                List<dtb_patient_ovule_send> listBNHNs = (from s in db.dtb_patient_ovule_sends select s).ToList();
                foreach (var bnhn in listBNHNs)
                {
                    string blobEncode = "";

                    switch (typeFP)
                    {
                        case BaseThongTinBenhNhan.FPType.NgonCaiPhai:
                            blobEncode = bnhn.fp_ngon_cai_phai;
                            break;
                        case BaseThongTinBenhNhan.FPType.NgonCaiTrai:
                            blobEncode = bnhn.fp_ngon_cai_trai;
                            break;
                        case BaseThongTinBenhNhan.FPType.NgonTroPhai:
                            blobEncode = bnhn.fp_ngon_tro_phai;
                            break;
                        case BaseThongTinBenhNhan.FPType.NgonTroTrai:
                            blobEncode = bnhn.fp_ngon_tro_trai;
                            break;
                    }

                    dicBlobs.Add(bnhn.patient_code, blobEncode);
                }

                return dicBlobs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HN_ThongTinNguoiHienNoan GetInformationPatient(string patienCode)
        {
            try
            {
                List<dtb_patient_ovule_send> listBNHNs = (from s in db.dtb_patient_ovule_sends select s).ToList();

                foreach (var bnhn in listBNHNs)
                {
                    if (bnhn.patient_code == patienCode)
                    {
                        HN_ThongTinNguoiHienNoan bn = new HN_ThongTinNguoiHienNoan(patienCode);
                        bn.HoVaTen = bnhn.fullname;
                        bn.NgaySinh = Convert.ToDateTime(bnhn.date_of_birth);
                        bn.SoDienThoai = bnhn.phone;
                        bn.Email = bnhn.email;
                        bn.SoCMND = bnhn.identify;
                        bn.NgayCap = Convert.ToDateTime(bnhn.date_of_id);
                        bn.DiaChiNoiCap = bnhn.address_of_id;
                        bn.DanToc = Convert.ToInt32(bnhn.class_id);
                        bn.NguyenQuan = bnhn.address;
                        bn.Tinh_ThanhPho = bnhn.province_code;
                        bn.Quan_Huyen = bnhn.district_code;

                        bn.VT_CaiPhai = bnhn.fp_ngon_cai_phai;
                        bn.VT_CaiTrai = bnhn.fp_ngon_cai_trai;
                        bn.VT_TroPhai = bnhn.fp_ngon_tro_phai;
                        bn.VT_TroTrai = bnhn.fp_ngon_tro_trai;

                        bn.VT_CaiPhai_HinhAnh = bnhn.fp_base64_ngon_cai_phai;
                        bn.VT_CaiTrai_HinhAnh = bnhn.fp_base64_ngon_cai_trai;
                        bn.VT_TroPhai_HinhAnh = bnhn.fp_base64_ngon_tro_phai;
                        bn.VT_TroTrai_HinhAnh = bnhn.fp_base64_ngon_tro_trai;

                        bn.MaTrungTamHTSS = bnhn.ma_tt;

                        bn.NgayTao = Convert.ToDateTime(bnhn.created_date);
                        bn.FlagAllowAddPattern = Convert.ToBoolean(bnhn.flag_allow_add_pattern);
                        bn.FlagNeedSync = Convert.ToBoolean(bnhn.flag_need_sync);
                        bn.FlagApprove = Convert.ToBoolean(bnhn.flag_approve);

                        return bn;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private dtb_patient_ovule_send GetInformationPatientDB(string patienCode)
        {
            List<dtb_patient_ovule_send> listBNHNs = (from s in db.dtb_patient_ovule_sends select s).ToList();

            foreach (var bnhn in listBNHNs)
                if (bnhn.patient_code == patienCode)
                    return bnhn;

            return null;
        }

        public bool AddNewPatient(HN_ThongTinNguoiHienNoan bnhn)
        {
            try
            {
                dtb_patient_ovule_send bn = new dtb_patient_ovule_send();
                bn.patient_code = bnhn.MaBN;
                bn.fullname = bnhn.HoVaTen;
                bn.date_of_birth = bnhn.NgaySinh;
                bn.identify = bnhn.SoCMND;
                bn.date_of_id = bnhn.NgayCap;
                bn.address_of_id = bnhn.DiaChiNoiCap;
                bn.address = bnhn.NguyenQuan;
                bn.class_id = bnhn.DanToc;
                bn.nation_id = bnhn.QuocTichID;
                bn.province_code = bnhn.Tinh_ThanhPho;
                bn.district_code = bnhn.Quan_Huyen;
                bn.phone = bnhn.SoDienThoai;
                bn.email = bnhn.Email;

                bn.fp_ngon_cai_phai = bnhn.VT_CaiPhai;
                bn.fp_ngon_cai_trai = bnhn.VT_CaiTrai;
                bn.fp_ngon_tro_phai = bnhn.VT_TroPhai;
                bn.fp_ngon_tro_trai = bnhn.VT_TroTrai;

                bn.fp_base64_ngon_cai_phai = bnhn.VT_CaiPhai_HinhAnh;
                bn.fp_base64_ngon_cai_trai = bnhn.VT_CaiTrai_HinhAnh;
                bn.fp_base64_ngon_tro_phai = bnhn.VT_TroPhai_HinhAnh;
                bn.fp_base64_ngon_tro_trai = bnhn.VT_TroTrai_HinhAnh;

                bn.ma_tt = bnhn.MaTrungTamHTSS;
                bn.created_date = bnhn.NgayTao;

                bn.flag_allow_add_pattern = bnhn.FlagAllowAddPattern;
                bn.flag_need_sync = true;
                bn.flag_approve = false;

                db.dtb_patient_ovule_sends.InsertOnSubmit(bn);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditInformationPatient(string patienCode, HN_ThongTinNguoiHienNoan bnhn)
        {
            try
            {
                dtb_patient_ovule_send bn = GetInformationPatientDB(patienCode);

                if (bn == null)
                    return false;

                bn.fullname = bnhn.HoVaTen;
                bn.date_of_birth = bnhn.NgaySinh;
                bn.identify = bnhn.SoCMND;
                bn.date_of_id = bnhn.NgayCap;
                bn.address_of_id = bnhn.DiaChiNoiCap;
                bn.address = bnhn.NguyenQuan;
                bn.class_id = bnhn.DanToc;
                bn.nation_id = bnhn.QuocTichID;
                bn.province_code = bnhn.Tinh_ThanhPho;
                bn.district_code = bnhn.Quan_Huyen;
                bn.phone = bnhn.SoDienThoai;
                bn.email = bnhn.Email;

                bn.fp_ngon_cai_phai = bnhn.VT_CaiPhai;
                bn.fp_ngon_cai_trai = bnhn.VT_CaiTrai;
                bn.fp_ngon_tro_phai = bnhn.VT_TroPhai;
                bn.fp_ngon_tro_trai = bnhn.VT_TroTrai;

                bn.fp_base64_ngon_cai_phai = bnhn.VT_CaiPhai_HinhAnh;
                bn.fp_base64_ngon_cai_trai = bnhn.VT_CaiTrai_HinhAnh;
                bn.fp_base64_ngon_tro_phai = bnhn.VT_TroPhai_HinhAnh;
                bn.fp_base64_ngon_tro_trai = bnhn.VT_TroTrai_HinhAnh;

                bn.flag_allow_add_pattern = bnhn.FlagAllowAddPattern;
                bn.ma_tt = bnhn.MaTrungTamHTSS;
                bn.created_date = bnhn.NgayTao;
                bn.flag_need_sync = true;

                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteInformationPatient(string patienCode)
        {
            try
            {
                dtb_patient_ovule_send bn = GetInformationPatientDB(patienCode);

                if (bn == null)
                    return false;

                db.dtb_patient_ovule_sends.DeleteOnSubmit(bn);
                db.SubmitChanges();

                List<HN_BenhToanThan> listBTTs = GetBenhToanThanByPatient(patienCode);
                foreach (var x in listBTTs)
                {
                    DeleteBenhToanThan(x.Id);
                }

                List<HN_KhamBenh> listKXCs = GetChauHongByPatient(patienCode);
                foreach (var x in listKXCs)
                {
                    DeleteChauHong(x.Id);
                }

                List<HN_BenhTinhDuc> listBTDs = GetBenhTinhDucByPatient(patienCode);
                foreach (var x in listBTDs)
                {
                    DeleteBenhTinhDuc(x.Id);
                }

                List<HN_TienSuSinhSan> listTSSSs = GetTienSuSinhSanByPatient(patienCode);
                foreach (var x in listTSSSs)
                {
                    DeleteTienSuSinhSan(x.Id);
                }

                List<HN_NguoiVanDong> listNVDs = GetNguoivanDongPatient(patienCode);
                foreach (var x in listNVDs)
                {
                    DeleteNguoiVanDong(x.Id);
                }

                List<HN_TieuSuKinhNguyet> listTSKNs = GetKinhNguyetByPatient(patienCode);
                foreach (var x in listTSKNs)
                {
                    DeleteKinhNguyet(x.Id);
                }

                List<HN_KetQuaXetNghiem> listKQXNs = GetXetNghiemPatient(patienCode);
                foreach (var x in listKQXNs)
                {
                    DeleteXetNghiem(x.Id);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_ThongTinBN(string patienCode)
        {
            dtb_patient_ovule_send bnhn = GetInformationPatientDB(patienCode);
            bnhn.flag_need_sync = false;
            db.SubmitChanges();
        }

        public bool CheckPatientApprove(string mabn)
        {
            dtb_patient_ovule_send bn = GetInformationPatientDB(mabn);
            if (bn != null)
            {
                return Convert.ToBoolean(bn.flag_approve);
            }
            return false;
        }

        public void ApprovePatient(string mabn, bool isApprove)
        {
            dtb_patient_ovule_send bn = GetInformationPatientDB(mabn);
            if (bn != null)
            {
                bn.flag_approve = isApprove;
                db.SubmitChanges(); ;
            }
        }

        #endregion

        #region Benh Toan Than
        public List<HN_BenhToanThan> GetAllBenhToanThan()
        {
            List<HN_BenhToanThan> listRTs = new List<HN_BenhToanThan>();

            List<dtb_ovule_benhtoanthan> listBTTs = (from s in db.dtb_ovule_benhtoanthans select s).ToList();
            foreach (var bn in listBTTs)
            {
                HN_BenhToanThan n = GetBenhToanThanByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HN_BenhToanThan> GetBenhToanThanByPatient(string patienCode)
        {
            List<HN_BenhToanThan> listRets = new List<HN_BenhToanThan>();

            List<dtb_ovule_benhtoanthan> listTTs = (from s in db.dtb_ovule_benhtoanthans select s).ToList();
            foreach (var bn in listTTs)
                if (bn.patient_code == patienCode)
                {
                    HN_BenhToanThan btt = GetBenhToanThanByID(bn.id);
                    listRets.Add(btt);
                }

            return listRets;
        }

        public HN_BenhToanThan GetBenhToanThanByID(int Id)
        {
            List<dtb_ovule_benhtoanthan> listBTTs = (from s in db.dtb_ovule_benhtoanthans select s).ToList();
            foreach (var bn in listBTTs)
                if (bn.id == Id)
                {
                    HN_BenhToanThan btt = new HN_BenhToanThan(bn.patient_code);
                    btt.Id = bn.id;
                    btt.TieuDuong = bn.tieu_duong;
                    btt.Lao = bn.lao;
                    btt.BenhKhac = bn.benh_khac;
                    btt.DieuTriNoiKhoa = bn.dieu_tri_noi_khoa;
                    btt.TienSuPhauThuat = bn.tien_su_phau_thuat;
                    btt.NhiemTrungTietLieu = bn.nhiem_trung_tiet_nieu;
                    btt.GhiChu = bn.ghi_chu;
                    btt.NgayTao = Convert.ToDateTime(bn.created_date);

                    btt.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return btt;
                }

            return null;
        }

        public int AddBenhToanThan(HN_BenhToanThan btt)
        {
            try
            {
                dtb_ovule_benhtoanthan bn = new dtb_ovule_benhtoanthan();
                bn.patient_code = btt.MaBN;
                bn.tieu_duong = btt.TieuDuong;
                bn.lao = btt.Lao;
                bn.benh_khac = btt.BenhKhac;
                bn.dieu_tri_noi_khoa = btt.DieuTriNoiKhoa;
                bn.tien_su_phau_thuat = btt.TienSuPhauThuat;
                bn.nhiem_trung_tiet_nieu = btt.NhiemTrungTietLieu;
                bn.ghi_chu = btt.GhiChu;
                bn.created_date = btt.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_ovule_benhtoanthans.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditBenhToanThan(int id, HN_BenhToanThan btt)
        {
            try
            {
                List<dtb_ovule_benhtoanthan> listBTTs = (from s in db.dtb_ovule_benhtoanthans select s).ToList();
                foreach (var bn in listBTTs)
                    if (bn.id == id)
                    {
                        bn.lao = btt.Lao;
                        bn.nhiem_trung_tiet_nieu = btt.NhiemTrungTietLieu;
                        bn.tien_su_phau_thuat = btt.TienSuPhauThuat;
                        bn.tieu_duong = btt.TieuDuong;
                        bn.benh_khac = btt.BenhKhac;
                        bn.ghi_chu = btt.GhiChu;
                        bn.created_date = btt.NgayTao;

                        bn.flag_need_sync = true;

                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteBenhToanThan(int id)
        {
            try
            {
                List<dtb_ovule_benhtoanthan> listBTTs = (from s in db.dtb_ovule_benhtoanthans select s).ToList();
                foreach (var bn in listBTTs)
                    if (bn.id == id)
                    {
                        db.dtb_ovule_benhtoanthans.DeleteOnSubmit(bn);
                        db.SubmitChanges();

                        return true;
                    }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_BenhToanThan(int id)
        {
            List<dtb_ovule_benhtoanthan> listBTTs = (from s in db.dtb_ovule_benhtoanthans select s).ToList();
            foreach (var bn in listBTTs)
                if (bn.id == id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Kham Hong va Xuong Chau
        public List<HN_KhamBenh> GetAllKhamHongVaXuongChau()
        {
            List<HN_KhamBenh> listRTs = new List<HN_KhamBenh>();

            List<dtb_ovule_khambenh> listCHs = (from s in db.dtb_ovule_khambenhs select s).ToList();
            foreach (var bn in listCHs)
            {
                HN_KhamBenh n = GetChauHongByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HN_KhamBenh> GetChauHongByPatient(string patienCode)
        {
            List<HN_KhamBenh> listRets = new List<HN_KhamBenh>();

            List<dtb_ovule_khambenh> listCHs = (from s in db.dtb_ovule_khambenhs select s).ToList();
            foreach (var bn in listCHs)
                if (bn.patient_code == patienCode)
                {
                    HN_KhamBenh ch = GetChauHongByID(bn.id);
                    listRets.Add(ch);
                }

            return listRets;
        }

        public HN_KhamBenh GetChauHongByID(int Id)
        {
            List<dtb_ovule_khambenh> listCHs = (from s in db.dtb_ovule_khambenhs select s).ToList();
            foreach (var bn in listCHs)
                if (bn.id == Id)
                {
                    HN_KhamBenh ch = new HN_KhamBenh(bn.patient_code);
                    ch.Id = bn.id;
                    ch.Height = bn.height;
                    ch.Weight = bn.weight;
                    ch.HuyetAp = bn.huyet_ap;
                    ch.Mach = bn.mach;
                    ch.NhietDo = bn.nhiet_do;
                    ch.SinhDucNgoai = bn.sinh_duc_ngoai;
                    ch.AmHo = bn.am_ho;
                    ch.AmDao = bn.am_dao;
                    ch.ViemLoTuyenCoTuCung = bn.cotucung_viemlotuyen;
                    ch.SuiCoTuCung = bn.cotucung_sui;
                    ch.PolypCoTuCung = bn.cotucung_polyp;
                    ch.HaiCTCCoTuCung = bn.cotucung_haictc;
                    ch.CoTuCungBinhThuong = bn.cotucung_binhthuong;
                    ch.TuTheTuCung = bn.tu_the_tu_cung;
                    ch.TheTichTuCung = bn.the_tich_tu_cung;
                    ch.MatDoTuCung = bn.mat_do_tu_cung;
                    ch.DiDongTuCung = bn.di_dong_tu_cung;
                    ch.HaiPhanPhu = bn.hai_phan_phu;
                    ch.GhiChu = bn.ghi_chu;
                    ch.NgayTao = Convert.ToDateTime(bn.created_date);

                    ch.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return ch;
                }

            return null;
        }

        public int AddChauHong(HN_KhamBenh ch)
        {
            try
            {
                dtb_ovule_khambenh bn = new dtb_ovule_khambenh();
                bn.patient_code = ch.MaBN;
                bn.height = ch.Height ;
                bn.weight = ch.Weight ;
                bn.huyet_ap = ch.HuyetAp ;
                bn.mach = ch.Mach ;
                bn.nhiet_do = ch.NhietDo;
                bn.sinh_duc_ngoai = ch.SinhDucNgoai;
                bn.am_ho = ch.AmHo;
                bn.am_dao = ch.AmDao;
                bn.cotucung_viemlotuyen = ch.ViemLoTuyenCoTuCung;
                bn.cotucung_sui = ch.SuiCoTuCung;
                bn.cotucung_polyp = ch.PolypCoTuCung;
                bn.cotucung_haictc = ch.HaiCTCCoTuCung;
                bn.cotucung_binhthuong = ch.CoTuCungBinhThuong;
                bn.tu_the_tu_cung = ch.TuTheTuCung;
                bn.the_tich_tu_cung = ch.TheTichTuCung;
                bn.mat_do_tu_cung = ch.MatDoTuCung;
                bn.di_dong_tu_cung = ch.DiDongTuCung;
                bn.hai_phan_phu = ch.HaiPhanPhu;
                bn.ghi_chu = ch.GhiChu;
                bn.created_date = ch.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_ovule_khambenhs.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditChauHong(int id, HN_KhamBenh ch)
        {
            try
            {
                List<dtb_ovule_khambenh> listCHs = (from s in db.dtb_ovule_khambenhs select s).ToList();
                foreach (var bn in listCHs)
                    if (bn.id == id)
                    {
                        bn.patient_code = ch.MaBN;
                        bn.height = ch.Height;
                        bn.weight = ch.Weight;
                        bn.huyet_ap = ch.HuyetAp;
                        bn.mach = ch.Mach;
                        bn.nhiet_do = ch.NhietDo;
                        bn.sinh_duc_ngoai = ch.SinhDucNgoai;
                        bn.am_ho = ch.AmHo;
                        bn.am_dao = ch.AmDao;
                        bn.cotucung_viemlotuyen = ch.ViemLoTuyenCoTuCung;
                        bn.cotucung_sui = ch.SuiCoTuCung;
                        bn.cotucung_polyp = ch.PolypCoTuCung;
                        bn.cotucung_haictc = ch.HaiCTCCoTuCung;
                        bn.cotucung_binhthuong = ch.CoTuCungBinhThuong;
                        bn.tu_the_tu_cung = ch.TuTheTuCung;
                        bn.the_tich_tu_cung = ch.TheTichTuCung;
                        bn.mat_do_tu_cung = ch.MatDoTuCung;
                        bn.di_dong_tu_cung = ch.DiDongTuCung;
                        bn.hai_phan_phu = ch.HaiPhanPhu;
                        bn.ghi_chu = ch.GhiChu;
                        bn.created_date = ch.NgayTao;

                        bn.flag_need_sync = true;

                        db.SubmitChanges();
                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteChauHong(int id)
        {
            try
            {
                List<dtb_ovule_khambenh> listCHs = (from s in db.dtb_ovule_khambenhs select s).ToList();
                foreach (var bn in listCHs)
                    if (bn.id == id)
                    {
                        db.dtb_ovule_khambenhs.DeleteOnSubmit(bn);
                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_ChauHong(int id)
        {
            List<dtb_ovule_khambenh> listCHs = (from s in db.dtb_ovule_khambenhs select s).ToList();
            foreach (var bn in listCHs)
                if (bn.id == id)
                {
                    bn.flag_need_sync = false;
                }
        }
        #endregion

        #region Ben Tinh Duc
        public List<HN_BenhTinhDuc> GetAllBenhTinhDuc()
        {
            List<HN_BenhTinhDuc> listRTs = new List<HN_BenhTinhDuc>();

            List<dtb_ovule_benhtinhduc> listCHs = (from s in db.dtb_ovule_benhtinhducs select s).ToList();
            foreach (var bn in listCHs)
            {
                HN_BenhTinhDuc n = GetBenhTinhDucByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HN_BenhTinhDuc> GetBenhTinhDucByPatient(string patienCode)
        {
            List<HN_BenhTinhDuc> listRets = new List<HN_BenhTinhDuc>();

            List<dtb_ovule_benhtinhduc> listBTDs = (from s in db.dtb_ovule_benhtinhducs select s).ToList();
            foreach (var bn in listBTDs)
                if (bn.patient_code == patienCode)
                {
                    HN_BenhTinhDuc btd = GetBenhTinhDucByID(bn.id);
                    listRets.Add(btd);
                }

            return listRets;
        }

        public HN_BenhTinhDuc GetBenhTinhDucByID(int Id)
        {
            List<dtb_ovule_benhtinhduc> listBTDs = (from s in db.dtb_ovule_benhtinhducs select s).ToList();
            foreach (var bn in listBTDs)
                if (bn.id == Id)
                {
                    HN_BenhTinhDuc btd = new HN_BenhTinhDuc(bn.patient_code);
                    btd.Id = bn.id;
                    btd.Lau = bn.lau;
                    btd.GiangMai = bn.giang_mai;
                    btd.Chlamydia = bn.chlamydia;
                    btd.BenhKhac = bn.benh_khac;
                    btd.GhiChu = bn.ghi_chu;
                    btd.NgayTao = Convert.ToDateTime(bn.created_date);

                    btd.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return btd;
                }

            return null;
        }

        public int AddBenhTinhDuc(HN_BenhTinhDuc btd)
        {
            try
            {
                dtb_ovule_benhtinhduc bn = new dtb_ovule_benhtinhduc();
                bn.patient_code = btd.MaBN;
                bn.lau = btd.Lau;
                bn.giang_mai = btd.GiangMai;
                bn.chlamydia = btd.Chlamydia;
                bn.benh_khac = btd.BenhKhac;
                bn.ghi_chu = btd.GhiChu;
                bn.created_date = btd.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_ovule_benhtinhducs.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditBenhTinhDuc(int id, HN_BenhTinhDuc btd)
        {
            try
            {
                List<dtb_ovule_benhtinhduc> listBTDs = (from s in db.dtb_ovule_benhtinhducs select s).ToList();
                foreach (var bn in listBTDs)
                    if (bn.id == id)
                    {
                        bn.lau = btd.Lau;
                        bn.giang_mai = btd.GiangMai;
                        bn.chlamydia = btd.Chlamydia;
                        bn.benh_khac = btd.BenhKhac;
                        bn.ghi_chu = btd.GhiChu;
                        bn.created_date = btd.NgayTao;

                        bn.flag_need_sync = true;

                        db.SubmitChanges();

                        return true;
                    }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteBenhTinhDuc(int id)
        {
            try
            {
                List<dtb_ovule_benhtinhduc> listBTDs = (from s in db.dtb_ovule_benhtinhducs select s).ToList();
                foreach (var bn in listBTDs)
                    if (bn.id == id)
                    {
                        db.dtb_ovule_benhtinhducs.DeleteOnSubmit(bn);
                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_BenhTinhDuc(int Id)
        {
            List<dtb_ovule_benhtinhduc> listBTDs = (from s in db.dtb_ovule_benhtinhducs select s).ToList();
            foreach (var bn in listBTDs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Tien Su Sinh San
        public List<HN_TienSuSinhSan> GetAllTienSuSinhSan()
        {
            List<HN_TienSuSinhSan> listRTs = new List<HN_TienSuSinhSan>();

            List<dtb_ovule_tiensusinhsan> listCHs = (from s in db.dtb_ovule_tiensusinhsans select s).ToList();
            foreach (var bn in listCHs)
            {
                HN_TienSuSinhSan n = GetTienSuSinhSanByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HN_TienSuSinhSan> GetTienSuSinhSanByPatient(string patienCode)
        {
            List<HN_TienSuSinhSan> listRets = new List<HN_TienSuSinhSan>();

            List<dtb_ovule_tiensusinhsan> listTSSSs = (from s in db.dtb_ovule_tiensusinhsans select s).ToList();
            foreach (var bn in listTSSSs)
                if (bn.patient_code == patienCode)
                {
                    HN_TienSuSinhSan tsss = GetTienSuSinhSanByID(bn.id);
                    listRets.Add(tsss);
                }

            return listRets;
        }

        public HN_TienSuSinhSan GetTienSuSinhSanByID(int Id)
        {
            List<dtb_ovule_tiensusinhsan> listTSSSs = (from s in db.dtb_ovule_tiensusinhsans select s).ToList();
            foreach (var bn in listTSSSs)
                if (bn.id == Id)
                {
                    HN_TienSuSinhSan tsss = new HN_TienSuSinhSan(bn.patient_code);
                    tsss.Id = bn.id;
                    tsss.SoLanCoThai = Convert.ToInt32(bn.so_lan_co_thai);
                    tsss.SoLuongDeConSong = Convert.ToInt32(bn.so_luong_de_con_song);
                    tsss.NaoHut = Convert.ToInt32(bn.nao_hut);
                    tsss.ThaiLuu = Convert.ToInt32(bn.thai_luu);
                    tsss.ChuaNgoaiDaCon = Convert.ToInt32(bn.chua_ngoai_da_con);
                    tsss.ChuaTrung = bn.chua_trung;
                    tsss.GhiChu = bn.ghi_chu;
                    tsss.NgayTao = Convert.ToDateTime(bn.created_date);

                    tsss.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return tsss;
                }

            return null;
        }

        public int AddTienSuSinhSan(HN_TienSuSinhSan tsss)
        {
            try
            {
                dtb_ovule_tiensusinhsan bn = new dtb_ovule_tiensusinhsan();
                bn.patient_code = tsss.MaBN;
                bn.so_lan_co_thai = tsss.SoLanCoThai;
                bn.so_luong_de_con_song = tsss.SoLuongDeConSong;
                bn.nao_hut = tsss.NaoHut;
                bn.thai_luu = tsss.ThaiLuu;
                bn.chua_ngoai_da_con = tsss.ChuaNgoaiDaCon;
                bn.chua_trung = tsss.ChuaTrung;
                bn.ghi_chu = tsss.GhiChu;
                bn.created_date = tsss.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_ovule_tiensusinhsans.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditTienSuSinhSan(int id, HN_TienSuSinhSan tsss)
        {
            try
            {
                List<dtb_ovule_tiensusinhsan> listTSSSs = (from s in db.dtb_ovule_tiensusinhsans select s).ToList();
                foreach (var bn in listTSSSs)
                    if (bn.id == id)
                    {
                        bn.so_lan_co_thai = tsss.SoLanCoThai;
                        bn.so_luong_de_con_song = tsss.SoLuongDeConSong;
                        bn.nao_hut = tsss.NaoHut;
                        bn.thai_luu = tsss.ThaiLuu;
                        bn.chua_ngoai_da_con = tsss.ChuaNgoaiDaCon;
                        bn.chua_trung = tsss.ChuaTrung;
                        bn.ghi_chu = tsss.GhiChu;
                        bn.created_date = tsss.NgayTao;

                        bn.flag_need_sync = true;

                        db.SubmitChanges();
                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteTienSuSinhSan(int id)
        {
            try
            {
                List<dtb_ovule_tiensusinhsan> listTSSSs = (from s in db.dtb_ovule_tiensusinhsans select s).ToList();
                foreach (var bn in listTSSSs)
                    if (bn.id == id)
                    {
                        db.dtb_ovule_tiensusinhsans.DeleteOnSubmit(bn);
                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_TienSuSinhSan(int Id)
        {
            List<dtb_ovule_tiensusinhsan> listTSSSs = (from s in db.dtb_ovule_tiensusinhsans select s).ToList();
            foreach (var bn in listTSSSs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Thong Tin Nguoi Van Dong
        public List<HN_NguoiVanDong> GetAllNguoivanDong()
        {
            List<HN_NguoiVanDong> listRTs = new List<HN_NguoiVanDong>();

            List<dtb_ovule_relation> listCHs = (from s in db.dtb_ovule_relations select s).ToList();
            foreach (var bn in listCHs)
            {
                HN_NguoiVanDong n = GetNguoiVanDongByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HN_NguoiVanDong> GetNguoivanDongPatient(string patienCode)
        {
            List<HN_NguoiVanDong> listRets = new List<HN_NguoiVanDong>();

            List<dtb_ovule_relation> listNVDs = (from s in db.dtb_ovule_relations select s).ToList();

            foreach (var bn in listNVDs)
                if (bn.patient_code == patienCode)
                {
                    HN_NguoiVanDong nvd = GetNguoiVanDongByID(bn.id);
                    listRets.Add(nvd);
                }

            return listRets;
        }

        public HN_NguoiVanDong GetNguoiVanDongByID(int Id)
        {
            List<dtb_ovule_relation> listNVDs = (from s in db.dtb_ovule_relations select s).ToList();
            foreach (var bn in listNVDs)
                if (bn.id == Id)
                {
                    HN_NguoiVanDong nvd = new HN_NguoiVanDong(bn.patient_code);
                    nvd.Id = bn.id;
                    nvd.HoVaTen = bn.fullname;
                    nvd.NgaySinh = Convert.ToDateTime(bn.date_of_birth);
                    nvd.SoCMND = bn.identify;
                    nvd.NgayCap = Convert.ToDateTime(bn.date_of_id);
                    nvd.DiaChiNoiCap = bn.address_of_id;
                    nvd.NguyenQuan = bn.address;
                    nvd.Email = bn.email;
                    nvd.SoDienThoai = bn.phone;
                    nvd.Tinh_ThanhPho = bn.province_code;
                    nvd.Quan_Huyen = bn.district_code;
                    nvd.GhiChu = bn.ghi_chu;
                    nvd.NgayTao = Convert.ToDateTime(bn.created_date);

                    nvd.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return nvd;
                }

            return null;
        }

        public int AddNguoiVanDong(HN_NguoiVanDong nvd)
        {
            try
            {
                dtb_ovule_relation bn = new dtb_ovule_relation();
                bn.patient_code = nvd.MaBN;
                bn.fullname = nvd.HoVaTen;
                bn.date_of_birth = nvd.NgaySinh;
                bn.identify = nvd.SoCMND;
                bn.date_of_id = nvd.NgayCap;
                bn.address_of_id = nvd.DiaChiNoiCap;
                bn.address = nvd.NguyenQuan;
                bn.email = nvd.Email;
                bn.phone = nvd.SoDienThoai;
                bn.province_code = nvd.Tinh_ThanhPho;
                bn.district_code = nvd.Quan_Huyen;
                bn.ghi_chu = nvd.GhiChu;
                bn.created_date = nvd.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_ovule_relations.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditNguoiVanDong(int id, HN_NguoiVanDong nvd)
        {
            try
            {
                List<dtb_ovule_relation> listNVDs = (from s in db.dtb_ovule_relations select s).ToList();
                foreach (var bn in listNVDs)
                    if (bn.id == id)
                    {
                        bn.fullname = nvd.HoVaTen;
                        bn.date_of_birth = nvd.NgaySinh;
                        bn.identify = nvd.SoCMND;
                        bn.date_of_id = nvd.NgayCap;
                        bn.address_of_id = nvd.DiaChiNoiCap;
                        bn.address = nvd.NguyenQuan;
                        bn.email = nvd.Email;
                        bn.phone = nvd.SoDienThoai;
                        bn.province_code = nvd.Tinh_ThanhPho;
                        bn.district_code = nvd.Quan_Huyen;
                        bn.ghi_chu = nvd.GhiChu;
                        bn.created_date = nvd.NgayTao;

                        bn.flag_need_sync = true;

                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteNguoiVanDong(int id)
        {
            try
            {
                List<dtb_ovule_relation> listNVDs = (from s in db.dtb_ovule_relations select s).ToList();
                foreach (var bn in listNVDs)
                    if (bn.id == id)
                    {
                        db.dtb_ovule_relations.DeleteOnSubmit(bn);
                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_NguoiVanDong(int Id)
        {
            List<dtb_ovule_relation> listNVDs = (from s in db.dtb_ovule_relations select s).ToList();
            foreach (var bn in listNVDs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Tieu Su Kinh Nguyet
        public List<HN_TieuSuKinhNguyet> GetAllTieuSuKinhNguyet()
        {
            List<HN_TieuSuKinhNguyet> listRTs = new List<HN_TieuSuKinhNguyet>();

            List<dtb_ovule_kinhnguyet> listCHs = (from s in db.dtb_ovule_kinhnguyets select s).ToList();
            foreach (var bn in listCHs)
            {
                HN_TieuSuKinhNguyet n = GetKinhNguyetByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HN_TieuSuKinhNguyet> GetKinhNguyetByPatient(string patienCode)
        {
            List<HN_TieuSuKinhNguyet> listRets = new List<HN_TieuSuKinhNguyet>();

            List<dtb_ovule_kinhnguyet> listKNs = (from s in db.dtb_ovule_kinhnguyets select s).ToList();

            foreach (var bn in listKNs)
                if (bn.patient_code == patienCode)
                {
                    HN_TieuSuKinhNguyet kn = GetKinhNguyetByID(bn.id);
                    listRets.Add(kn);
                }

            return listRets;
        }

        public HN_TieuSuKinhNguyet GetKinhNguyetByID(int Id)
        {
            List<dtb_ovule_kinhnguyet> listKNs = (from s in db.dtb_ovule_kinhnguyets select s).ToList();
            foreach (var bn in listKNs)
                if (bn.id == Id)
                {
                    HN_TieuSuKinhNguyet kn = new HN_TieuSuKinhNguyet(bn.patient_code);
                    kn.Id = bn.id;
                    kn.TuoiCoKinhLanDau = Convert.ToInt32(bn.tuoi_co_kinh_lan_dau);
                    kn.ChuKyKinh = Convert.ToInt32(bn.chu_ky_kinh);
                    kn.SoNgayCoKinh = Convert.ToInt32(bn.so_ngay_co_kinh);
                    kn.SoLuong = bn.so_luong;
                    kn.GhiChu = bn.ghi_chu;
                    kn.NgayTao = Convert.ToDateTime(bn.created_date);

                    kn.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return kn;
                }

            return null;
        }

        public int AddKinhNguyet(HN_TieuSuKinhNguyet kn)
        {
            try
            {
                dtb_ovule_kinhnguyet bn = new dtb_ovule_kinhnguyet();
                bn.patient_code = kn.MaBN;
                bn.tuoi_co_kinh_lan_dau = kn.TuoiCoKinhLanDau;
                bn.chu_ky_kinh = kn.ChuKyKinh;
                bn.so_ngay_co_kinh = kn.SoNgayCoKinh;
                bn.so_luong = kn.SoLuong;
                bn.ghi_chu = kn.GhiChu;
                bn.created_date = kn.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_ovule_kinhnguyets.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditKinhNguyet(int id, HN_TieuSuKinhNguyet kn)
        {
            try
            {
                List<dtb_ovule_kinhnguyet> listKNs = (from s in db.dtb_ovule_kinhnguyets select s).ToList();
                foreach (var bn in listKNs)
                    if (bn.id == id)
                    {
                        bn.tuoi_co_kinh_lan_dau = kn.TuoiCoKinhLanDau;
                        bn.chu_ky_kinh = kn.ChuKyKinh;
                        bn.so_ngay_co_kinh = kn.SoNgayCoKinh;
                        bn.so_luong = kn.SoLuong;
                        bn.ghi_chu = kn.GhiChu;
                        bn.created_date = kn.NgayTao;

                        bn.flag_need_sync = true;

                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteKinhNguyet(int id)
        {
            try
            {
                List<dtb_ovule_kinhnguyet> listKNs = (from s in db.dtb_ovule_kinhnguyets select s).ToList();
                foreach (var bn in listKNs)
                    if (bn.id == id)
                    {
                        db.dtb_ovule_kinhnguyets.DeleteOnSubmit(bn);
                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_KinhNguyet(int Id)
        {
            List<dtb_ovule_kinhnguyet> listKNs = (from s in db.dtb_ovule_kinhnguyets select s).ToList();
            foreach (var bn in listKNs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Ket Qua Xet Nghiem
        public List<HN_KetQuaXetNghiem> GetAllKetQuaXetNghiem()
        {
            List<HN_KetQuaXetNghiem> listRTs = new List<HN_KetQuaXetNghiem>();

            List<dtb_ovule_xetnghiem> listCHs = (from s in db.dtb_ovule_xetnghiems select s).ToList();
            foreach (var bn in listCHs)
            {
                HN_KetQuaXetNghiem n = GetXetNghiemByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HN_KetQuaXetNghiem> GetXetNghiemPatient(string patienCode)
        {
            List<HN_KetQuaXetNghiem> listRets = new List<HN_KetQuaXetNghiem>();

            List<dtb_ovule_xetnghiem> listXNs = (from s in db.dtb_ovule_xetnghiems select s).ToList();
            foreach (var bn in listXNs)
                if (bn.patient_code == patienCode)
                {
                    HN_KetQuaXetNghiem xn = GetXetNghiemByID(bn.id);
                    listRets.Add(xn);
                }

            return listRets;
        }

        public HN_KetQuaXetNghiem GetXetNghiemByID(int Id)
        {
            List<dtb_ovule_xetnghiem> listXNs = (from s in db.dtb_ovule_xetnghiems select s).ToList();
            foreach (var bn in listXNs)
                if (bn.id == Id)
                {
                    HN_KetQuaXetNghiem xn = new HN_KetQuaXetNghiem(bn.patient_code);
                    xn.Id = bn.id;
                    xn.NhomMau = bn.group_blood;
                    xn.HIV = bn.hiv;
                    xn.BW = bn.bw;
                    xn.HBsAg = bn.hbsag;
                    xn.AntiHCV = bn.antihcv;
                    xn.SoLanKiemTra = Convert.ToInt32(bn.num_of_check);
                    xn.GhiChu = bn.ghi_chu;
                    xn.NgayTao = Convert.ToDateTime(bn.created_date);

                    xn.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return xn;
                }

            return null;
        }

        public int AddXetNghiem(HN_KetQuaXetNghiem xn)
        {
            try
            {
                dtb_ovule_xetnghiem bn = new dtb_ovule_xetnghiem();
                bn.patient_code = xn.MaBN;
                bn.group_blood = xn.NhomMau;
                bn.hiv = xn.HIV;
                bn.bw = xn.BW;
                bn.hbsag = xn.HBsAg;
                bn.antihcv = xn.AntiHCV;
                bn.num_of_check = xn.SoLanKiemTra;
                bn.ghi_chu = xn.GhiChu;
                bn.created_date = xn.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_ovule_xetnghiems.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditXetNghiem(int id, HN_KetQuaXetNghiem xn)
        {
            try
            {
                List<dtb_ovule_xetnghiem> listXNs = (from s in db.dtb_ovule_xetnghiems select s).ToList();
                foreach (var bn in listXNs)
                    if (bn.id == id)
                    {
                        bn.group_blood = xn.NhomMau;
                        bn.hiv = xn.HIV;
                        bn.bw = xn.BW;
                        bn.hbsag = xn.HBsAg;
                        bn.antihcv = xn.AntiHCV;
                        bn.num_of_check = xn.SoLanKiemTra;
                        bn.ghi_chu = xn.GhiChu;
                        bn.created_date = xn.NgayTao;

                        bn.flag_need_sync = true;

                        db.SubmitChanges();
                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteXetNghiem(int id)
        {
            try
            {
                List<dtb_ovule_xetnghiem> listXNs = (from s in db.dtb_ovule_xetnghiems select s).ToList();
                foreach (var bn in listXNs)
                    if (bn.id == id)
                    {
                        db.dtb_ovule_xetnghiems.DeleteOnSubmit(bn);
                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_KQXN(int Id)
        {
            List<dtb_ovule_xetnghiem> listXNs = (from s in db.dtb_ovule_xetnghiems select s).ToList();
            foreach (var bn in listXNs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region HoiBenh
        public List<HN_HoiBenh> GetAllHoiBenh()
        {
            List<HN_HoiBenh> listRTs = new List<HN_HoiBenh>();

            List<dtb_ovule_hoibenh> listCHs = (from s in db.dtb_ovule_hoibenhs select s).ToList();
            foreach (var bn in listCHs)
            {
                HN_HoiBenh n = GetHoiBenhByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HN_HoiBenh> GetHoiBenhPatient(string patienCode)
        {
            List<HN_HoiBenh> listRets = new List<HN_HoiBenh>();

            List<dtb_ovule_hoibenh> listXNs = (from s in db.dtb_ovule_hoibenhs select s).ToList();
            foreach (var bn in listXNs)
                if (bn.patient_code == patienCode)
                {
                    HN_HoiBenh xn = GetHoiBenhByID(bn.id);
                    listRets.Add(xn);
                }

            return listRets;
        }

        public HN_HoiBenh GetHoiBenhByID(int Id)
        {
            List<dtb_ovule_hoibenh> listXNs = (from s in db.dtb_ovule_hoibenhs select s).ToList();
            foreach (var bn in listXNs)
                if (bn.id == Id)
                {
                    HN_HoiBenh tsngk = new HN_HoiBenh(bn.patient_code);
                    tsngk.Id = bn.id;
                    tsngk.HaveData_TienSuNoiKhoa = Convert.ToBoolean(bn.have_data_tiensunoikhoa);
                    tsngk.DetailData_TienSuNoiKhoa = bn.detail_data_tiensunoikhoa;
                    tsngk.HaveData_TienSuNgoaiKhoa = Convert.ToBoolean(bn.have_data_tiensungoaikhoa);
                    tsngk.DetailData_TienSuNgoaiKhoa = bn.detail_data_tiensungoaikhoa;
                    tsngk.NgayTao = Convert.ToDateTime(bn.created_date);

                    tsngk.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return tsngk;
                }

            return null;
        }

        public int AddHoiBenh(HN_HoiBenh xn)
        {
            try
            {
                dtb_ovule_hoibenh bn = new dtb_ovule_hoibenh();
                bn.patient_code = xn.MaBN;
                bn.have_data_tiensunoikhoa = xn.HaveData_TienSuNoiKhoa;
                bn.detail_data_tiensunoikhoa = xn.DetailData_TienSuNoiKhoa;
                bn.have_data_tiensungoaikhoa = xn.HaveData_TienSuNgoaiKhoa;
                bn.detail_data_tiensungoaikhoa = xn.DetailData_TienSuNgoaiKhoa;
                bn.created_date = xn.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_ovule_hoibenhs.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditHoiBenh(int id, HN_HoiBenh xn)
        {
            try
            {
                List<dtb_ovule_hoibenh> listXNs = (from s in db.dtb_ovule_hoibenhs select s).ToList();
                foreach (var bn in listXNs)
                    if (bn.id == id)
                    {
                        bn.have_data_tiensunoikhoa = xn.HaveData_TienSuNoiKhoa;
                        bn.detail_data_tiensunoikhoa = xn.DetailData_TienSuNoiKhoa;
                        bn.have_data_tiensungoaikhoa = xn.HaveData_TienSuNgoaiKhoa;
                        bn.detail_data_tiensungoaikhoa = xn.DetailData_TienSuNgoaiKhoa;

                        bn.created_date = xn.NgayTao;
                        bn.flag_need_sync = true;

                        db.SubmitChanges();
                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteHoiBenh(int id)
        {
            try
            {
                List<dtb_ovule_hoibenh> listXNs = (from s in db.dtb_ovule_hoibenhs select s).ToList();
                foreach (var bn in listXNs)
                    if (bn.id == id)
                    {
                        db.dtb_ovule_hoibenhs.DeleteOnSubmit(bn);
                        db.SubmitChanges();

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_HoiBenh(int Id)
        {
            List<dtb_ovule_hoibenh> listXNs = (from s in db.dtb_ovule_hoibenhs select s).ToList();
            foreach (var bn in listXNs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

       
    }
}