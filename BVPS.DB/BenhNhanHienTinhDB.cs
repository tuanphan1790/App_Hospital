using BVPS.DB.DBContext;
using BVPS.Model;
using BVPS.Model.HoSoNguoiHienTinh;
using libzkfpcsharp;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.DB
{
    public class BenhNhanHienTinhDB : BaseBenhNhan
    {
        ThongTinBenhNhanHienTinhDataContext db;

        public BenhNhanHienTinhDB() : base()
        {
            db = new ThongTinBenhNhanHienTinhDataContext();
        }

        public BenhNhanHienTinhDB(string con) : base(con)
        {
            db = new ThongTinBenhNhanHienTinhDataContext(con);
        }

        #region Thong Tin Benh Nhan Hien Tinh
        public List<HT_ThongTinNguoiHienTinh> GetAllNguoiHienTinh()
        {
            List<HT_ThongTinNguoiHienTinh> listRTs = new List<HT_ThongTinNguoiHienTinh>();

            List<dtb_sperm_send> listNHTs = (from s in db.dtb_sperm_sends select s).ToList();
            foreach (var nh in listNHTs)
            {
                HT_ThongTinNguoiHienTinh n = GetInformationPatient(nh.patient_code);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public HT_ThongTinNguoiHienTinh CheckDuplicateNoCMND(string noCMND)
        {
            foreach (var bn in GetAllNguoiHienTinh())
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

                List<dtb_sperm_send> listBNHTs = (from s in db.dtb_sperm_sends select s).ToList();
                foreach (var bnht in listBNHTs)
                {
                    string blobEncode = "";

                    switch (typeFP)
                    {
                        case BaseThongTinBenhNhan.FPType.NgonCaiPhai:
                            blobEncode = bnht.fp_ngon_cai_phai;
                            break;
                        case BaseThongTinBenhNhan.FPType.NgonCaiTrai:
                            blobEncode = bnht.fp_ngon_cai_trai;
                            break;
                        case BaseThongTinBenhNhan.FPType.NgonTroPhai:
                            blobEncode = bnht.fp_ngon_tro_phai;
                            break;
                        case BaseThongTinBenhNhan.FPType.NgonTroTrai:
                            blobEncode = bnht.fp_ngon_tro_trai;
                            break;
                    }

                    dicBlobs.Add(bnht.patient_code, blobEncode);
                }

                return dicBlobs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HT_ThongTinNguoiHienTinh GetInformationPatient(string patienCode)
        {
            try
            {
                List<dtb_sperm_send> listBNHTs = (from s in db.dtb_sperm_sends select s).ToList();

                foreach (var bnht in listBNHTs)
                {
                    if (bnht.patient_code == patienCode)
                    {
                        HT_ThongTinNguoiHienTinh bn = new HT_ThongTinNguoiHienTinh(patienCode);
                        bn.HoVaTen = bnht.fullname;
                        bn.NgaySinh = Convert.ToDateTime(bnht.date_of_birth);
                        bn.SoDienThoai = bnht.phone;
                        bn.Email = bnht.email;
                        bn.SoCMND = bnht.identifier;
                        bn.NgayCap = Convert.ToDateTime(bnht.date_of_id);
                        bn.DiaChiNoiCap = bnht.address_of_id;
                        bn.NguyenQuan = bnht.address;
                        bn.DanToc = Convert.ToInt32(bnht.class_id);
                        bn.CongViec = bnht.job;
                        bn.TrinhDoHocVan = Convert.ToInt32(bnht.level_id);
                        bn.Tinh_ThanhPho = bnht.province_code;
                        bn.Quan_Huyen = bnht.district_code;
                        bn.DaLapGiaDinh = Convert.ToBoolean(bnht.maried);
                        bn.DaCoCon = Convert.ToBoolean(bnht.has_child);
                        bn.SoCon = Convert.ToInt32(bnht.num_of_child);
                        bn.TuoiCoConGanNhat = Convert.ToInt32(bnht.year_of_child_last);
                        bn.ThoiDiemVoMangThai = Convert.ToInt32(bnht.day_of_have_baby);
                        bn.TrangThaiSucKhoe = bnht.heath_status;
                        bn.TieuSuBenh = bnht.history_of_patient;
                        bn.TieuSuBenhGiaDinh = bnht.history_of_family;
                        bn.MaTrungTamHTSS = bnht.ma_tt;

                        bn.VT_CaiPhai = bnht.fp_ngon_cai_phai;
                        bn.VT_CaiTrai = bnht.fp_ngon_cai_trai;
                        bn.VT_TroPhai = bnht.fp_ngon_tro_phai;
                        bn.VT_TroTrai = bnht.fp_ngon_tro_trai;

                        bn.VT_CaiPhai_HinhAnh = bnht.fp_base64_ngon_cai_phai;
                        bn.VT_CaiTrai_HinhAnh = bnht.fp_base64_ngon_cai_trai;
                        bn.VT_TroPhai_HinhAnh = bnht.fp_base64_ngon_tro_phai;
                        bn.VT_TroTrai_HinhAnh = bnht.fp_base64_ngon_tro_trai;

                        bn.FlagNeedSync = Convert.ToBoolean(bnht.flag_need_sync);
                        bn.FlagApprove = Convert.ToBoolean(bnht.flag_approve);

                        bn.FlagAllowAddPattern = Convert.ToBoolean(bnht.flag_allow_add_pattern);
                        bn.NgayTao = Convert.ToDateTime(bnht.created_date);

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

        private dtb_sperm_send GetInformationPatientDB(string patienCode)
        {
            List<dtb_sperm_send> listBNHTs = (from s in db.dtb_sperm_sends select s).ToList();

            foreach (var bnht in listBNHTs)
                if (bnht.patient_code == patienCode)
                    return bnht;

            return null;
        }

        public bool AddNewPatient(HT_ThongTinNguoiHienTinh bnht)
        {
            try
            {
                dtb_sperm_send bn = new dtb_sperm_send();
                bn.patient_code = bnht.MaBN;
                bn.fullname = bnht.HoVaTen;
                bn.date_of_birth = bnht.NgaySinh;
                bn.identifier = bnht.SoCMND;
                bn.date_of_id = bnht.NgayCap;
                bn.address_of_id = bnht.DiaChiNoiCap;
                bn.address = bnht.NguyenQuan;
                bn.class_id = bnht.DanToc;
                bn.job = bnht.CongViec;
                bn.level_id = bnht.TrinhDoHocVan;
                bn.nation_id = bnht.QuocTichID;
                bn.province_code = bnht.Tinh_ThanhPho;
                bn.district_code = bnht.Quan_Huyen;
                bn.phone = bnht.SoDienThoai;
                bn.email = bnht.Email;

                bn.maried = bnht.DaLapGiaDinh;
                bn.has_child = bnht.DaCoCon;
                bn.num_of_child = bnht.SoCon;
                bn.year_of_child_last = bnht.TuoiCoConGanNhat;
                bn.day_of_have_baby = bnht.ThoiDiemVoMangThai;
                bn.heath_status = bnht.TrangThaiSucKhoe;
                bn.history_of_patient = bnht.TieuSuBenh;
                bn.history_of_family = bnht.TieuSuBenhGiaDinh;

                bn.fp_ngon_cai_phai = bnht.VT_CaiPhai;
                bn.fp_ngon_cai_trai = bnht.VT_CaiTrai;
                bn.fp_ngon_tro_phai = bnht.VT_TroPhai;
                bn.fp_ngon_tro_trai = bnht.VT_TroTrai;

                bn.fp_base64_ngon_cai_phai = bnht.VT_CaiPhai_HinhAnh;
                bn.fp_base64_ngon_cai_trai = bnht.VT_CaiTrai_HinhAnh;
                bn.fp_base64_ngon_tro_phai = bnht.VT_TroPhai_HinhAnh;
                bn.fp_base64_ngon_tro_trai = bnht.VT_TroTrai_HinhAnh;
                bn.ma_tt = bnht.MaTrungTamHTSS;

                bn.flag_allow_add_pattern = bnht.FlagAllowAddPattern;
                bn.created_date = bnht.NgayTao;
                bn.flag_need_sync = true;
                bn.flag_approve = false;

                db.dtb_sperm_sends.InsertOnSubmit(bn);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditInformationPatient(string patienCode, HT_ThongTinNguoiHienTinh bnht)
        {
            try
            {
                dtb_sperm_send bn = GetInformationPatientDB(patienCode);

                if (bn == null)
                    return false;

                bn.fullname = bnht.HoVaTen;
                bn.date_of_birth = bnht.NgaySinh;
                bn.identifier = bnht.SoCMND;
                bn.date_of_id = bnht.NgayCap;
                bn.address_of_id = bnht.DiaChiNoiCap;
                bn.address = bnht.NguyenQuan;
                bn.class_id = bnht.DanToc;
                bn.job = bnht.CongViec;
                bn.province_code = bnht.Tinh_ThanhPho;
                bn.district_code = bnht.Quan_Huyen;
                bn.level_id = bnht.TrinhDoHocVan;
                bn.phone = bnht.SoDienThoai;
                bn.email = bnht.Email;

                bn.maried = bnht.DaLapGiaDinh;
                bn.has_child = bnht.DaCoCon;
                bn.num_of_child = bnht.SoCon;
                bn.year_of_child_last = bnht.TuoiCoConGanNhat;
                bn.day_of_have_baby = bnht.ThoiDiemVoMangThai;
                bn.heath_status = bnht.TrangThaiSucKhoe;
                bn.history_of_patient = bnht.TieuSuBenh;
                bn.history_of_family = bnht.TieuSuBenhGiaDinh;

                bn.fp_ngon_cai_phai = bnht.VT_CaiPhai;
                bn.fp_ngon_cai_trai = bnht.VT_CaiTrai;
                bn.fp_ngon_tro_phai = bnht.VT_TroPhai;
                bn.fp_ngon_tro_trai = bnht.VT_TroTrai;

                bn.fp_base64_ngon_cai_phai = bnht.VT_CaiPhai_HinhAnh;
                bn.fp_base64_ngon_cai_trai = bnht.VT_CaiTrai_HinhAnh;
                bn.fp_base64_ngon_tro_phai = bnht.VT_TroPhai_HinhAnh;
                bn.fp_base64_ngon_tro_trai = bnht.VT_TroTrai_HinhAnh;
                bn.ma_tt = bnht.MaTrungTamHTSS;

                bn.flag_allow_add_pattern = bnht.FlagAllowAddPattern;
                bn.created_date = bnht.NgayTao;
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
                dtb_sperm_send bn = GetInformationPatientDB(patienCode);

                if (bn == null)
                    return false;

                db.dtb_sperm_sends.DeleteOnSubmit(bn);

                List<HT_ThongTinNguoiQuanHeBN> listVBNs = GetVoBNByPatient(patienCode);
                foreach (var x in listVBNs)
                {
                    DeleteVoBN(x.Id);
                }

                List<HT_KhamNamKhoa> listKNKs = GetKhamNamKhoaByPatient(patienCode);
                foreach (var x in listKNKs)
                {
                    DeleteKhamNamKhoa(x.Id);
                }

                List<HT_KetQuaXetNghiem> listKQXNs = GetKetQuaXetNghiemByPatient(patienCode);
                foreach (var x in listKQXNs)
                {
                    DeleteKetQuaXetNghiem(x.Id);
                }

                List<HT_LuuTruMau> listLTMs = GetLuuTruMauByPatient(patienCode);
                foreach (var x in listLTMs)
                {
                    DeleteLuuTruMau(x.Id);
                }

                List<HT_TinhDichDo> listTDDs = GetTinhDichDoByPatient(patienCode);
                foreach (var x in listTDDs)
                {
                    DeleteTinhDichDo(x.Id);
                }

                List<HT_NguoiVanDong> listNVDs = GetNguoivanDongPatient(patienCode);
                foreach (var x in listNVDs)
                {
                    DeleteNguoiVanDong(x.Id);
                }

                List<HT_DacTrungNguoiHien> listDTs = GetDacTrungByPatient(patienCode);
                foreach (var x in listDTs)
                {
                    DeleteDacTrung(x.Id);
                }

                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_ThongTinBN(string patienCode)
        {
            dtb_sperm_send bnhn = GetInformationPatientDB(patienCode);
            bnhn.flag_need_sync = false;
            db.SubmitChanges();
        }

        public bool CheckPatientApprove(string mabn)
        {
            dtb_sperm_send bn = GetInformationPatientDB(mabn);
            if (bn != null)
            {
                return Convert.ToBoolean(bn.flag_approve);
            }
            return false;
        }

        public void ApprovePatient(string mabn, bool isApprove)
        {
            dtb_sperm_send bn = GetInformationPatientDB(mabn);
            if (bn != null)
            {
                bn.flag_approve = isApprove;
                db.SubmitChanges(); ;
            }
        }

        #endregion

        #region Vo nguoi hien tinh
        public List<HT_ThongTinNguoiQuanHeBN> GetAllNguoiQuanHeBN()
        {
            List<HT_ThongTinNguoiQuanHeBN> listRTs = new List<HT_ThongTinNguoiQuanHeBN>();

            List<dtb_sperm_relation> listNQHs = (from s in db.dtb_sperm_relations select s).ToList();
            foreach (var bn in listNQHs)
            {
                HT_ThongTinNguoiQuanHeBN n = GetVoBNByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HT_ThongTinNguoiQuanHeBN> GetVoBNByPatient(string patienCode)
        {
            List<HT_ThongTinNguoiQuanHeBN> listRets = new List<HT_ThongTinNguoiQuanHeBN>();

            List<dtb_sperm_relation> listVBNs = (from s in db.dtb_sperm_relations select s).ToList();

            foreach (var bn in listVBNs)
                if (bn.patient_code == patienCode)
                {
                    HT_ThongTinNguoiQuanHeBN nqh = GetVoBNByID(bn.id);
                    listRets.Add(nqh);
                }

            return listRets;
        }

        public HT_ThongTinNguoiQuanHeBN GetVoBNByID(int Id)
        {
            List<dtb_sperm_relation> listVBNs = (from s in db.dtb_sperm_relations select s).ToList();

            foreach (var bn in listVBNs)
                if (bn.id == Id)
                {
                    HT_ThongTinNguoiQuanHeBN nqh = new HT_ThongTinNguoiQuanHeBN(bn.patient_code);
                    nqh.Id = bn.id;
                    nqh.HoVaTen = bn.fullname;
                    nqh.SoCMND = bn.identify;
                    nqh.NgayCap = Convert.ToDateTime(bn.date_of_id);
                    nqh.DiaChiNoiCap = bn.address_of_id;
                    nqh.NguyenQuan = bn.address;
                    nqh.NgaySinh = Convert.ToDateTime(bn.date_of_birth);
                    nqh.SoDienThoai = bn.phone;
                    nqh.Email = bn.email;
                    nqh.GhiChu = bn.ghi_chu;
                    nqh.NgayTao = Convert.ToDateTime(bn.created_date);

                    nqh.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return nqh;
                }

            return null;
        }

        public int AddVoBN(string maBN, HT_ThongTinNguoiQuanHeBN nqh)
        {
            try
            {
                dtb_sperm_relation bn = new dtb_sperm_relation();
                bn.patient_code = nqh.MaBN;
                bn.fullname = nqh.HoVaTen;
                bn.identify = nqh.SoCMND;
                bn.date_of_id = nqh.NgayCap;
                bn.address_of_id = nqh.DiaChiNoiCap;
                bn.address = nqh.NguyenQuan;
                bn.date_of_birth = nqh.NgaySinh;
                bn.phone = nqh.SoDienThoai;
                bn.email = nqh.Email;
                bn.ghi_chu = nqh.GhiChu;
                bn.created_date = nqh.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_sperm_relations.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditVoBN(int id, HT_ThongTinNguoiQuanHeBN nqh)
        {
            try
            {
                List<dtb_sperm_relation> listVBNs = (from s in db.dtb_sperm_relations select s).ToList();
                foreach (var bn in listVBNs)
                {
                    if (bn.id == id)
                    {
                        bn.fullname = nqh.HoVaTen;
                        bn.identify = nqh.SoCMND;
                        bn.date_of_id = nqh.NgayCap;
                        bn.address_of_id = nqh.DiaChiNoiCap;
                        bn.address = nqh.NguyenQuan;
                        bn.date_of_birth = nqh.NgaySinh;
                        bn.phone = nqh.SoDienThoai;
                        bn.email = nqh.Email;
                        bn.ghi_chu = nqh.GhiChu;
                        bn.created_date = nqh.NgayTao;

                        bn.flag_need_sync = true;

                        db.SubmitChanges();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteVoBN(int id)
        {
            try
            {
                List<dtb_sperm_relation> listVBNs = (from s in db.dtb_sperm_relations select s).ToList();
                foreach (var bn in listVBNs)
                {
                    if (bn.id == id)
                    {
                        db.dtb_sperm_relations.DeleteOnSubmit(bn);
                        db.SubmitChanges();
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetInforSync_VoBN(int Id)
        {
            List<dtb_sperm_relation> listVBNs = (from s in db.dtb_sperm_relations select s).ToList();

            foreach (var bn in listVBNs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Kham Nam Khoa
        public List<HT_KhamNamKhoa> GetAllKhamNamKhoa()
        {
            List<HT_KhamNamKhoa> listRTs = new List<HT_KhamNamKhoa>();

            List<dtb_male_facuty> listKNKs = (from s in db.dtb_male_facuties select s).ToList();
            foreach (var bn in listKNKs)
            {
                HT_KhamNamKhoa n = GetKhamNamKhoaByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HT_KhamNamKhoa> GetKhamNamKhoaByPatient(string patienCode)
        {
            List<HT_KhamNamKhoa> listRets = new List<HT_KhamNamKhoa>();

            List<dtb_male_facuty> listKNKs = (from s in db.dtb_male_facuties select s).ToList();

            foreach (var bn in listKNKs)
                if (bn.patient_code == patienCode)
                {
                    HT_KhamNamKhoa knk = GetKhamNamKhoaByID(bn.id);
                    listRets.Add(knk);
                }

            return listRets;
        }

        public HT_KhamNamKhoa GetKhamNamKhoaByID(int Id)
        {
            List<dtb_male_facuty> listKNKs = (from s in db.dtb_male_facuties select s).ToList();
            foreach (var bn in listKNKs)
                if (bn.id == Id)
                {
                    HT_KhamNamKhoa knk = new HT_KhamNamKhoa(bn.patient_code);
                    knk.Id = Id;
                    knk.TTTrai = bn.tt_left;
                    knk.TTPhai = bn.tt_right;
                    knk.MaoTinh = bn.mao_tinh;
                    knk.OngDanTinh = bn.ong_dan_tinh;
                    knk.Varicole = bn.varicole;
                    knk.DuongVat = bn.duong_vat;
                    knk.DacTinhSinhSan = bn.dac_tinh_sinh_san;
                    knk.GhiChu = bn.ghi_chu;
                    knk.NgayTao = Convert.ToDateTime(bn.created_date);

                    knk.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return knk;
                }

            return null;
        }

        public int AddKhamNamKhoa(HT_KhamNamKhoa knk)
        {
            try
            {
                dtb_male_facuty bn = new dtb_male_facuty();
                bn.patient_code = knk.MaBN;
                bn.tt_left = knk.TTTrai;
                bn.tt_right = knk.TTPhai;
                bn.mao_tinh = knk.MaoTinh;
                bn.ong_dan_tinh = knk.OngDanTinh;
                bn.varicole = knk.Varicole;
                bn.duong_vat = knk.DuongVat;
                bn.dac_tinh_sinh_san = knk.DacTinhSinhSan;
                bn.created_date = knk.NgayTao;
                bn.ghi_chu = knk.GhiChu;

                bn.flag_need_sync = true;

                db.dtb_male_facuties.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditKhamNamKhoa(int id, HT_KhamNamKhoa knk)
        {
            try
            {
                List<dtb_male_facuty> listKNKs = (from s in db.dtb_male_facuties select s).ToList();

                foreach (var bn in listKNKs)
                    if (bn.id == id)
                    {
                        bn.patient_code = knk.MaBN;
                        bn.tt_left = knk.TTTrai;
                        bn.tt_right = knk.TTPhai;
                        bn.mao_tinh = knk.MaoTinh;
                        bn.ong_dan_tinh = knk.OngDanTinh;
                        bn.varicole = knk.Varicole;
                        bn.duong_vat = knk.DuongVat;
                        bn.dac_tinh_sinh_san = knk.DacTinhSinhSan;
                        bn.created_date = knk.NgayTao;
                        bn.ghi_chu = knk.GhiChu;

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

        public bool DeleteKhamNamKhoa(int id)
        {
            try
            {
                List<dtb_male_facuty> listKNKs = (from s in db.dtb_male_facuties select s).ToList();

                foreach (var bn in listKNKs)
                    if (bn.id == id)
                    {
                        db.dtb_male_facuties.DeleteOnSubmit(bn);
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

        public void ResetInforSync_KhamNamKhoa(int Id)
        {
            List<dtb_male_facuty> listKNKs = (from s in db.dtb_male_facuties select s).ToList();
            foreach (var bn in listKNKs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Ket Qua Xet Nghiem
        public List<HT_KetQuaXetNghiem> GetAllKetQuaXetNghiem()
        {
            List<HT_KetQuaXetNghiem> listRTs = new List<HT_KetQuaXetNghiem>();

            List<dtb_lab_result> listXNs = (from s in db.dtb_lab_results select s).ToList();
            foreach (var bn in listXNs)
            {
                HT_KetQuaXetNghiem n = GetKetQuaXetNghiemByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HT_KetQuaXetNghiem> GetKetQuaXetNghiemByPatient(string patienCode)
        {
            List<HT_KetQuaXetNghiem> listRets = new List<HT_KetQuaXetNghiem>();

            List<dtb_lab_result> listKQXNs = (from s in db.dtb_lab_results select s).ToList();
            foreach (var bn in listKQXNs)
            {
                if (bn.patient_code == patienCode)
                {
                    HT_KetQuaXetNghiem kqxn = GetKetQuaXetNghiemByID(bn.id);
                    listRets.Add(kqxn);
                }
            }

            return listRets;
        }

        public HT_KetQuaXetNghiem GetKetQuaXetNghiemByID(int Id)
        {
            List<dtb_lab_result> listKQXNs = (from s in db.dtb_lab_results select s).ToList();
            foreach (var bn in listKQXNs)
                if (bn.id == Id)
                {
                    HT_KetQuaXetNghiem kqxn = new HT_KetQuaXetNghiem(bn.patient_code);
                    kqxn.Id = Id;
                    kqxn.NhomMau = bn.group_blood;
                    kqxn.HIV = bn.hiv;
                    kqxn.BW = bn.bw;
                    kqxn.HBsAg = bn.hbsag;
                    kqxn.HIV = bn.antihcv;
                    kqxn.SoLanKiemTra = Convert.ToInt32(bn.num_of_check);
                    kqxn.GhiChu = bn.ghi_chu;
                    kqxn.NgayTao = Convert.ToDateTime(bn.created_date);

                    kqxn.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return kqxn;
                }

            return null;
        }

        public int AddKetQuaXetNghiem(HT_KetQuaXetNghiem kqxn)
        {
            try
            {
                dtb_lab_result bn = new dtb_lab_result();
                bn.patient_code = kqxn.MaBN;
                bn.group_blood = kqxn.NhomMau;
                bn.hiv = kqxn.HIV;
                bn.bw = kqxn.BW;
                bn.hbsag = kqxn.HBsAg;
                bn.antihcv = kqxn.HIV;
                bn.num_of_check = kqxn.SoLanKiemTra;
                bn.ghi_chu = kqxn.GhiChu;
                bn.created_date = kqxn.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_lab_results.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditKetQuaXetNghiem(int id, HT_KetQuaXetNghiem kqxn)
        {
            try
            {
                List<dtb_lab_result> listKQXNs = (from s in db.dtb_lab_results select s).ToList();

                foreach (var bn in listKQXNs)
                    if (bn.id == id)
                    {
                        bn.group_blood = kqxn.NhomMau;
                        bn.hiv = kqxn.HIV;
                        bn.bw = kqxn.BW;
                        bn.hbsag = kqxn.HBsAg;
                        bn.antihcv = kqxn.HIV;
                        bn.num_of_check = kqxn.SoLanKiemTra;
                        bn.ghi_chu = kqxn.GhiChu;
                        bn.created_date = kqxn.NgayTao;

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

        public bool DeleteKetQuaXetNghiem(int id)
        {
            try
            {
                List<dtb_lab_result> listKQXNs = (from s in db.dtb_lab_results select s).ToList();

                foreach (var bn in listKQXNs)
                    if (bn.id == id)
                    {
                        db.dtb_lab_results.DeleteOnSubmit(bn);
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
            List<dtb_lab_result> listKQXNs = (from s in db.dtb_lab_results select s).ToList();
            foreach (var bn in listKQXNs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Luu Tru Mau
        public List<HT_LuuTruMau> GetAllLuuTruMau()
        {
            List<HT_LuuTruMau> listRTs = new List<HT_LuuTruMau>();

            List<dtb_pattern_storage> listKNKs = (from s in db.dtb_pattern_storages select s).ToList();
            foreach (var bn in listKNKs)
            {
                HT_LuuTruMau n = GetLuuTruMauByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HT_LuuTruMau> GetLuuTruMauByPatient(string patienCode)
        {
            List<HT_LuuTruMau> listRets = new List<HT_LuuTruMau>();

            List<dtb_pattern_storage> listLTMs = (from s in db.dtb_pattern_storages select s).ToList();

            foreach (var bn in listLTMs)
                if (bn.patient_code == patienCode)
                {
                    HT_LuuTruMau ltm = GetLuuTruMauByID(bn.id);
                    listRets.Add(ltm);
                }

            return listRets;
        }

        public HT_LuuTruMau GetLuuTruMauByID(int Id)
        {
            List<dtb_pattern_storage> listLTMs = (from s in db.dtb_pattern_storages select s).ToList();
            foreach (var bn in listLTMs)
                if (bn.id == Id)
                {
                    HT_LuuTruMau ltm = new HT_LuuTruMau(bn.patient_code);
                    ltm.Id = bn.id;
                    ltm.MaMau = bn.pattern_code;
                    ltm.FlagUsed = Convert.ToBoolean(bn.flag_used);
                    ltm.MatDo = bn.mat_do;
                    ltm.DiDong = bn.di_dong;
                    ltm.HinhDang = bn.hinh_dang;
                    ltm.ViTri = bn.vi_tri;
                    ltm.DuDieuKienLuuTru = Convert.ToBoolean(bn.has_condition);
                    ltm.LyDoLuu = bn.reason;
                    ltm.BenhDiTruyen = Convert.ToBoolean(bn.has_gennetic);
                    ltm.GhiChu = bn.ghi_chu;
                    ltm.NgayTao = Convert.ToDateTime(bn.created_date);

                    ltm.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return ltm;
                }

            return null;
        }

        public int AddLuuTruMau(HT_LuuTruMau ltm)
        {
            try
            {
                dtb_pattern_storage bn = new dtb_pattern_storage();
                bn.patient_code = ltm.MaBN;
                bn.pattern_code = ltm.MaMau;
                bn.flag_used = ltm.FlagUsed;
                bn.mat_do = ltm.MatDo;
                bn.di_dong = ltm.DiDong;
                bn.hinh_dang = ltm.HinhDang;
                bn.vi_tri = ltm.ViTri;
                bn.has_condition = ltm.DuDieuKienLuuTru;
                bn.reason = ltm.LyDoLuu;
                bn.has_gennetic = ltm.BenhDiTruyen;
                bn.ghi_chu = ltm.GhiChu;
                bn.created_date = ltm.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_pattern_storages.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditLuuTruMau(int id, HT_LuuTruMau ltm)
        {
            try
            {
                List<dtb_pattern_storage> listLTMs = (from s in db.dtb_pattern_storages select s).ToList();

                foreach (var bn in listLTMs)
                    if (bn.id == id)
                    {
                        bn.pattern_code = ltm.MaMau;
                        bn.flag_used = ltm.FlagUsed;
                        bn.mat_do = ltm.MatDo;
                        bn.di_dong = ltm.DiDong;
                        bn.hinh_dang = ltm.HinhDang;
                        bn.vi_tri = ltm.ViTri;
                        bn.has_condition = ltm.DuDieuKienLuuTru;
                        bn.reason = ltm.LyDoLuu;
                        bn.has_gennetic = ltm.BenhDiTruyen;
                        bn.ghi_chu = ltm.GhiChu;
                        bn.created_date = ltm.NgayTao;

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

        public bool DeleteLuuTruMau(int id)
        {
            try
            {
                List<dtb_pattern_storage> listLTMs = (from s in db.dtb_pattern_storages select s).ToList();
                foreach (var bn in listLTMs)
                    if (bn.id == id)
                    {
                        db.dtb_pattern_storages.DeleteOnSubmit(bn);
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

        public bool AllowAddPattern(string maBN)
        {
            List<HT_LuuTruMau> listLTM = GetLuuTruMauByPatient(maBN);
            foreach (var ltm in listLTM)
            {
                if (!ltm.FlagUsed)
                    return false;
            }

            return true;
        }

        public void ResetInforSync_LuuTruMau(int Id)
        {
            List<dtb_pattern_storage> listLTMs = (from s in db.dtb_pattern_storages select s).ToList();
            foreach (var bn in listLTMs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Tinh Dich Do
        public List<HT_TinhDichDo> GetAllTinhDichDo()
        {
            List<HT_TinhDichDo> listRTs = new List<HT_TinhDichDo>();

            List<dtb_ttd_result> listTDDs = (from s in db.dtb_ttd_results select s).ToList();
            foreach (var bn in listTDDs)
            {
                HT_TinhDichDo n = GetTinhDichDoByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HT_TinhDichDo> GetTinhDichDoByPatient(string patienCode)
        {
            List<HT_TinhDichDo> listRets = new List<HT_TinhDichDo>();

            List<dtb_ttd_result> listTDDs = (from s in db.dtb_ttd_results select s).ToList();

            foreach (var bn in listTDDs)
                if (bn.patient_code == patienCode)
                {
                    HT_TinhDichDo tdd = GetTinhDichDoByID(bn.id);
                    listRets.Add(tdd);
                }

            return listRets;
        }

        public HT_TinhDichDo GetTinhDichDoByID(int Id)
        {
            List<dtb_ttd_result> listTDDs = (from s in db.dtb_ttd_results select s).ToList();
            foreach (var bn in listTDDs)
                if (bn.id == Id)
                {
                    HT_TinhDichDo tdd = new HT_TinhDichDo(bn.patient_code);
                    tdd.Id = bn.id;

                    tdd.MauSac = bn.mau_sac;
                    tdd.TheTich = bn.the_tich;
                    tdd.LyGiai = bn.ly_giai;
                    tdd.PH = bn.PH;
                    tdd.MatDo = Convert.ToInt32(bn.mat_do);
                    tdd.TongSoTinhTrung = Convert.ToInt32(bn.tong_so_tinh_trung);
                    tdd.TiLeTinhTrungSong = Convert.ToInt32(bn.ty_le_tinh_trung_song);
                    tdd.DiDongTienToi = Convert.ToInt32(bn.di_dong_tien_toi);
                    tdd.DiDongKhongTienToi = Convert.ToInt32(bn.di_dong_khong_tien_toi);
                    tdd.BatDong = Convert.ToInt32(bn.bat_dong);
                    tdd.HinhThaiBinhThuong = Convert.ToInt32(bn.hinh_thai_binh_thuong);
                    tdd.HinhThaiBatThuong_Dau = Convert.ToInt32(bn.hinh_thai_bat_thuong_dau);
                    tdd.HinhThaiBatThuong_Co = Convert.ToInt32(bn.hinh_thai_bat_thuong_co);
                    tdd.HinhThaiBatThuong_Duoi = Convert.ToInt32(bn.hinh_thai_bat_thuong_duoi);
                    tdd.TeBaoHinhTron = bn.te_bao_hinh_tron;

                    tdd.GhiChu = bn.ghi_chu;
                    tdd.NgayTao = Convert.ToDateTime(bn.created_date);
                    tdd.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return tdd;
                }

            return null;
        }

        public int AddTinhDichDo(HT_TinhDichDo tdd)
        {
            try
            {
                dtb_ttd_result bn = new dtb_ttd_result();
                bn.patient_code = tdd.MaBN;

                bn.mau_sac = tdd.MauSac;
                bn.the_tich = tdd.TheTich;
                bn.ly_giai = tdd.LyGiai;
                bn.PH = tdd.PH;
                bn.mat_do = tdd.MatDo;
                bn.tong_so_tinh_trung = tdd.TongSoTinhTrung;
                bn.ty_le_tinh_trung_song = tdd.TiLeTinhTrungSong;
                bn.di_dong_tien_toi = tdd.DiDongTienToi;
                bn.di_dong_khong_tien_toi = tdd.DiDongKhongTienToi;
                bn.bat_dong = tdd.BatDong;
                bn.hinh_thai_binh_thuong = tdd.HinhThaiBinhThuong;
                bn.hinh_thai_bat_thuong_dau = tdd.HinhThaiBatThuong_Dau;
                bn.hinh_thai_bat_thuong_co = tdd.HinhThaiBatThuong_Co;
                bn.hinh_thai_bat_thuong_duoi = tdd.HinhThaiBatThuong_Duoi;
                bn.te_bao_hinh_tron = tdd.TeBaoHinhTron;

                bn.ghi_chu = tdd.GhiChu;
                bn.created_date = tdd.NgayTao;
                bn.flag_need_sync = true;

                db.dtb_ttd_results.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditTinhDichDo(int id, HT_TinhDichDo tdd)
        {
            try
            {
                List<dtb_ttd_result> listTDDs = (from s in db.dtb_ttd_results select s).ToList();
                foreach (var bn in listTDDs)
                    if (bn.id == id)
                    {
                        bn.mau_sac = tdd.MauSac;
                        bn.the_tich = tdd.TheTich;
                        bn.ly_giai = tdd.LyGiai;
                        bn.PH = tdd.PH;
                        bn.mat_do = tdd.MatDo;
                        bn.tong_so_tinh_trung = tdd.TongSoTinhTrung;
                        bn.ty_le_tinh_trung_song = tdd.TiLeTinhTrungSong;
                        bn.di_dong_tien_toi = tdd.DiDongTienToi;
                        bn.di_dong_khong_tien_toi = tdd.DiDongKhongTienToi;
                        bn.bat_dong = tdd.BatDong;
                        bn.hinh_thai_binh_thuong = tdd.HinhThaiBinhThuong;
                        bn.hinh_thai_bat_thuong_dau = tdd.HinhThaiBatThuong_Dau;
                        bn.hinh_thai_bat_thuong_co = tdd.HinhThaiBatThuong_Co;
                        bn.hinh_thai_bat_thuong_duoi = tdd.HinhThaiBatThuong_Duoi;
                        bn.te_bao_hinh_tron = tdd.TeBaoHinhTron;

                        bn.ghi_chu = tdd.GhiChu;
                        bn.created_date = tdd.NgayTao;
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

        public bool DeleteTinhDichDo(int id)
        {
            try
            {
                List<dtb_ttd_result> listTDDs = (from s in db.dtb_ttd_results select s).ToList();
                foreach (var bn in listTDDs)
                    if (bn.id == id)
                    {
                        db.dtb_ttd_results.DeleteOnSubmit(bn);
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

        public void ResetInforSync_TinhDichDo(int Id)
        {
            List<dtb_ttd_result> listTDDs = (from s in db.dtb_ttd_results select s).ToList();
            foreach (var bn in listTDDs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion

        #region Nguoi Van Dong
        public List<HT_NguoiVanDong> GetAllNguoiVanDong()
        {
            List<HT_NguoiVanDong> listRTs = new List<HT_NguoiVanDong>();

            List<dtb_male_relation> listNVDs = (from s in db.dtb_male_relations select s).ToList();
            foreach (var bn in listNVDs)
            {
                HT_NguoiVanDong n = GetNguoiVanDongByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HT_NguoiVanDong> GetNguoivanDongPatient(string patienCode)
        {
            List<HT_NguoiVanDong> listRets = new List<HT_NguoiVanDong>();

            List<dtb_male_relation> listNVDs = (from s in db.dtb_male_relations select s).ToList();

            foreach (var bn in listNVDs)
                if (bn.patient_code == patienCode)
                {
                    HT_NguoiVanDong nvd = GetNguoiVanDongByID(bn.id);
                    listRets.Add(nvd);
                }

            return listRets;
        }

        public HT_NguoiVanDong GetNguoiVanDongByID(int Id)
        {
            List<dtb_male_relation> listNVDs = (from s in db.dtb_male_relations select s).ToList();
            foreach (var bn in listNVDs)
                if (bn.id == Id)
                {
                    HT_NguoiVanDong nvd = new HT_NguoiVanDong(bn.patient_code);
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

        public int AddNguoiVanDong(HT_NguoiVanDong nvd)
        {
            try
            {
                dtb_male_relation bn = new dtb_male_relation();
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

                db.dtb_male_relations.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditNguoiVanDong(int id, HT_NguoiVanDong nvd)
        {
            try
            {
                List<dtb_male_relation> listNVDs = (from s in db.dtb_male_relations select s).ToList();
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
                List<dtb_male_relation> listNVDs = (from s in db.dtb_male_relations select s).ToList();
                foreach (var bn in listNVDs)
                    if (bn.id == id)
                    {
                        db.dtb_male_relations.DeleteOnSubmit(bn);
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

        public void ResetInforSync_NVD(int Id)
        {
            List<dtb_male_relation> listNVDs = (from s in db.dtb_male_relations select s).ToList();
            foreach (var bn in listNVDs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                }
        }
        #endregion

        #region Dac Trung Nguoi Hien
        public List<HT_DacTrungNguoiHien> GetAllDacTrung()
        {
            List<HT_DacTrungNguoiHien> listRTs = new List<HT_DacTrungNguoiHien>();

            List<dtb_sperm_spec> listDTs = (from s in db.dtb_sperm_specs select s).ToList();
            foreach (var bn in listDTs)
            {
                HT_DacTrungNguoiHien n = GetDacTrungByID(bn.id);
                listRTs.Add(n);
            }

            return listRTs;
        }

        public List<HT_DacTrungNguoiHien> GetDacTrungByPatient(string patienCode)
        {
            List<HT_DacTrungNguoiHien> listRets = new List<HT_DacTrungNguoiHien>();

            List<dtb_sperm_spec> listDTs = (from s in db.dtb_sperm_specs select s).ToList();
            foreach (var bn in listDTs)
                if (bn.patient_code == patienCode)
                {
                    HT_DacTrungNguoiHien dt = GetDacTrungByID(bn.id);
                    listRets.Add(dt);
                }

            return listRets;
        }

        public HT_DacTrungNguoiHien GetDacTrungByID(int Id)
        {
            List<dtb_sperm_spec> listDTs = (from s in db.dtb_sperm_specs select s).ToList();
            foreach (var bn in listDTs)
                if (bn.id == Id)
                {
                    HT_DacTrungNguoiHien dt = new HT_DacTrungNguoiHien(bn.patient_code);
                    dt.Id = bn.id;
                    dt.ChieuCao = bn.height;
                    dt.CanNang = bn.weight;
                    dt.MauMat = bn.eye_color;
                    dt.KieuToc = bn.hair_style;
                    dt.MauToc = bn.hair_color;
                    dt.MauDa = bn.color;
                    dt.GhiChu = bn.ghi_chu;
                    dt.NgayTao = Convert.ToDateTime(bn.created_date);

                    dt.FlagNeedSync = Convert.ToBoolean(bn.flag_need_sync);

                    return dt;
                }

            return null;
        }

        public int AddDacTrung(HT_DacTrungNguoiHien dt)
        {
            try
            {
                dtb_sperm_spec bn = new dtb_sperm_spec();
                bn.patient_code = dt.MaBN;
                bn.height = dt.ChieuCao;
                bn.weight = dt.CanNang;
                bn.eye_color = dt.MauMat;
                bn.hair_style = dt.KieuToc;
                bn.hair_color = dt.MauToc;
                bn.color = dt.MauDa;
                bn.ghi_chu = dt.GhiChu;
                bn.created_date = dt.NgayTao;

                bn.flag_need_sync = true;

                db.dtb_sperm_specs.InsertOnSubmit(bn);
                db.SubmitChanges();

                return bn.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditDacTrung(int id, HT_DacTrungNguoiHien dt)
        {
            try
            {
                List<dtb_sperm_spec> listDTs = (from s in db.dtb_sperm_specs select s).ToList();
                foreach (var bn in listDTs)
                    if (bn.id == id)
                    {
                        bn.height = dt.ChieuCao;
                        bn.weight = dt.CanNang;
                        bn.eye_color = dt.MauMat;
                        bn.hair_style = dt.KieuToc;
                        bn.hair_color = dt.MauToc;
                        bn.color = dt.MauDa;
                        bn.ghi_chu = dt.GhiChu;
                        bn.created_date = dt.NgayTao;

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

        public bool DeleteDacTrung(int id)
        {
            try
            {
                List<dtb_sperm_spec> listDTs = (from s in db.dtb_sperm_specs select s).ToList();
                foreach (var bn in listDTs)
                    if (bn.id == id)
                    {
                        db.dtb_sperm_specs.DeleteOnSubmit(bn);
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

        public void ResetInforSync_DacTrung(int Id)
        {
            List<dtb_sperm_spec> listDTs = (from s in db.dtb_sperm_specs select s).ToList();
            foreach (var bn in listDTs)
                if (bn.id == Id)
                {
                    bn.flag_need_sync = false;
                    db.SubmitChanges();
                }
        }
        #endregion        
    }
}
