using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using BVPS.Model;
using BVPS.Model.ChiMuc;
using System.Drawing.Imaging;
using BVPS.DB;
using System.Runtime.InteropServices;
using libzkfpcsharp;
using System.IO;
using System.Threading;
using BVPS.Model.HoSoNguoiHienTinh;
using DevComponents.DotNetBar.SuperGrid;
using BVPS.App;
using Xceed.Words.NET;
using System.Net;
using System.Text.RegularExpressions;

namespace Com.Gosol.LIS.App.FORM
{
    public partial class HoSoNguoiHienTinh : UserControlBN
    {
        HT_ThongTinNguoiHienTinh bn;
        BenhNhanHienTinhDB dbBN;

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);

                        if (HT_rbNgonCaiPhai.Checked)
                        {
                            base64ImageStringNgonCaiPhai = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                            zkfp.Blob2Base64String(CapTmp, cbCapTmp, ref FPBlobNgonCaiPhai);
                            this.HT_picNgonCaiPhai.Image = bmp;
                        }
                        else if (HT_rbNgonCaiTrai.Checked)
                        {
                            base64ImageStringNgonCaiTrai = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                            zkfp.Blob2Base64String(CapTmp, cbCapTmp, ref FPBlobNgonCaiTrai);
                            this.HT_picNgonCaiTrai.Image = bmp;
                        }
                        else if (HT_rbNgonTroPhai.Checked)
                        {
                            base64ImageStringNgonTroPhai = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                            zkfp.Blob2Base64String(CapTmp, cbCapTmp, ref FPBlobNgonTroPhai);
                            this.HT_picNgonTroPhai.Image = bmp;
                        }
                        else if (HT_rbNgonTroTrai.Checked)
                        {
                            base64ImageStringNgonTroTrai = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                            zkfp.Blob2Base64String(CapTmp, cbCapTmp, ref FPBlobNgonTroTrai);
                            this.HT_picNgonTroTrai.Image = bmp;
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void DoCapture()
        {
            while (!AppsLIST.bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(AppsLIST.mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }

                Thread.Sleep(200);
            }
        }

        public HoSoNguoiHienTinh(HT_ThongTinNguoiHienTinh bnht, AppsLIST app) : base(app)
        {
            InitializeComponent();

            dbBN = new BenhNhanHienTinhDB(app.connString);

            HT_dTNgayTao.Value = DateTime.Now;
            this.bn = bnht;
            IsHoSoDaDuocTao = true;

            if (bnht.FlagApprove)
            {
                HT_btnTaoHoSoMoi.Visible = false;
                HT_btnHuyHoSo.Visible = false;
                //HT_btnApprove.Visible = false;

                lblApprove.Visible = true;
            }

            if (!app.CheckPermissionAdd(Utilities.FUN_HSBN_PheDuyetHoSo))
            {
                //HT_btnApprove.Visible = false;
            }

            LoadChiMuc();
            CheckPermissionViewBegin();
            FillDataToForm();

            HT_btnTaoHoSoMoi.Text = "SỬA HỒ SƠ";
        }

        public HoSoNguoiHienTinh(AppsLIST app) : base(app)
        {
            InitializeComponent();

            dbBN = new BenhNhanHienTinhDB(app.connString);

            HT_dTNgayTao.Value = DateTime.Now;
            IsHoSoDaDuocTao = false;

            LoadChiMuc();
            CheckPermissionViewBegin();

            HT_lbMaBN.Text = Utilities.GenMaUnixTime(app.GetTrungTamHTSS().MaTTHTSS);
        }

        private void CheckPermissionViewBegin()
        {
            if (!app.CheckPermissionView(Utilities.FUN_BNHT_DacTrungBenhNhan))
                HT_TabDacTrung.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHT_DanhSachVoBN))
                HT_TabThongTinVoNH.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHT_KetQuaXetNghiem))
                HT_TabKetQuaXN.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHT_KhamNamKhoa))
                HT_TabKhamNamKhoa.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHT_LuuTruMau))
                HT_TabLuuTruMau.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHT_NguoiVanDong))
                HT_TabNguoiVanDongHT.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHT_TinhDichDo))
                HT_TabTinhDichDo.Visible = false;
        }

        private void LoadChiMuc()
        {
            HT_cboTrinhDo.DataSource = app.GetDMTrinhDoHocVan();

            HT_cboTinhThanh.DataSource = app.GetDMTinhThanh();
            HT_cboTinhThanhNVD.DataSource = app.GetDMTinhThanh();

            HT_cboQuanHuyen.DataSource = app.GetDMAllThanhPho();
            HT_cboQuanHuyenNVD.DataSource = app.GetDMAllThanhPho();

            HT_cboDanToc.DataSource = app.GetDMDanToc();
        }

        private void FillDataToForm()
        {
            HT_lbMaBN.Text = bn.MaBN;
            HT_txtHoVaTen.Text = bn.HoVaTen;
            HT_dTNgaySinh.Value = bn.NgaySinh;
            HT_txtSoDienThoai.Text = bn.SoDienThoai;
            HT_txtEmail.Text = bn.Email;
            HT_cboTrinhDo.SelectedValue = bn.TrinhDoHocVan;
            HT_txtCongViec.Text = bn.CongViec;
            HT_cboTinhThanh.SelectedValue = bn.Tinh_ThanhPho;
            HT_cboQuanHuyen.SelectedValue = bn.Quan_Huyen;
            HT_cboDanToc.SelectedValue = bn.DanToc;
            HT_txtSoCMND.Text = bn.SoCMND;
            HT_dTNgayCap.Value = bn.NgayCap;
            HT_txtNguyenQuan.Text = bn.NguyenQuan;
            HT_txtDiaChiNoiCap.Text = bn.DiaChiNoiCap;
            if (bn.DaLapGiaDinh)
                HT_chkDaLapGiaDinh.CheckState = CheckState.Checked;
            else
                HT_chkDaLapGiaDinh.CheckState = CheckState.Unchecked;

            if (bn.DaCoCon)
                HT_chkCoCon.CheckState = CheckState.Checked;
            else
                HT_chkCoCon.CheckState = CheckState.Unchecked;

            HT_txtSoCon.Text = bn.SoCon.ToString();
            HT_txtTuoiCoConGanNhat.Text = bn.TuoiCoConGanNhat.ToString();
            Ht_txtThoiDiemVoMangThai.Text = bn.ThoiDiemVoMangThai.ToString();
            HT_txtTrangThaiSucKhoe.Text = bn.TrangThaiSucKhoe;
            HT_txtTieuSuBenh.Text = bn.TieuSuBenh;
            HT_txtTieuSuBenhGiaDinh.Text = bn.TieuSuBenhGiaDinh;
            HT_dTNgayTao.Value = bn.NgayTao;

            HT_picNgonCaiPhai.Image = Utilities.Base64StringToBitmap(bn.VT_CaiPhai_HinhAnh);
            HT_picNgonCaiTrai.Image = Utilities.Base64StringToBitmap(bn.VT_CaiTrai_HinhAnh);
            HT_picNgonTroPhai.Image = Utilities.Base64StringToBitmap(bn.VT_TroPhai_HinhAnh);
            HT_picNgonTroTrai.Image = Utilities.Base64StringToBitmap(bn.VT_TroTrai_HinhAnh);

        }

        private bool CheckFP(ref string MaBN)
        {
            int intResult;
            Dictionary<string, byte[]> fpNgonCaiPhais = Utilities.ConvertDic(dbBN.GetListBlobBytes(BaseThongTinBenhNhan.FPType.NgonCaiPhai));
            Dictionary<string, byte[]> fpNgonCaiTrais = Utilities.ConvertDic(dbBN.GetListBlobBytes(BaseThongTinBenhNhan.FPType.NgonCaiTrai));
            Dictionary<string, byte[]> fpNgonTroPhais = Utilities.ConvertDic(dbBN.GetListBlobBytes(BaseThongTinBenhNhan.FPType.NgonTroPhai));
            Dictionary<string, byte[]> fpNgonTroTrais = Utilities.ConvertDic(dbBN.GetListBlobBytes(BaseThongTinBenhNhan.FPType.NgonTroTrai));

            byte[] blobNew = { };
            foreach (var fp in fpNgonCaiPhais)
            {
                if (FPBlobNgonCaiPhai == null)
                    break;

                blobNew = zkfp.Base64String2Blob(FPBlobNgonCaiPhai);
                intResult = zkfp2.DBMatch(AppsLIST.mDBHandle, blobNew, fp.Value);
                if (intResult > 80)
                {
                    MaBN = fp.Key;
                    return false;
                }
            }

            foreach (var fp in fpNgonCaiTrais)
            {
                if (FPBlobNgonCaiTrai == null)
                    break;

                blobNew = zkfp.Base64String2Blob(FPBlobNgonCaiTrai);
                intResult = zkfp2.DBMatch(AppsLIST.mDBHandle, blobNew, fp.Value);
                if (intResult > 80)
                {
                    MaBN = fp.Key;
                    return false;
                }
            }

            foreach (var fp in fpNgonTroPhais)
            {
                if (FPBlobNgonTroPhai == null)
                    break;

                blobNew = zkfp.Base64String2Blob(FPBlobNgonTroPhai);
                intResult = zkfp2.DBMatch(AppsLIST.mDBHandle, blobNew, fp.Value);
                if (intResult > 80)
                {
                    MaBN = fp.Key;
                    return false;
                }
            }

            foreach (var fp in fpNgonTroTrais)
            {
                if (FPBlobNgonTroTrai == null)
                    break;

                blobNew = zkfp.Base64String2Blob(FPBlobNgonTroTrai);
                intResult = zkfp2.DBMatch(AppsLIST.mDBHandle, blobNew, fp.Value);
                if (intResult > 80)
                {
                    MaBN = fp.Key;
                    return false;
                }
            }

            return true;
        }


        private int GetIDItemThongTinVoNguoiHien()
        {
            int rowIndex = HT_sgThongTinVoNH.ActiveRow.RowIndex;
            GridCell gridCell = HT_sgThongTinVoNH.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDItemKhamNamKhoa()
        {
            int rowIndex = HT_sgKhamNamKhoa.ActiveRow.RowIndex;
            GridCell gridCell = HT_sgKhamNamKhoa.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDItemDacTrungNH()
        {
            int rowIndex = HT_sgDacTrungNH.ActiveRow.RowIndex;
            GridCell gridCell = HT_sgDacTrungNH.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDItemTinhDichDo()
        {
            int rowIndex = HT_sgTinhDichDo.ActiveRow.RowIndex;
            GridCell gridCell = HT_sgTinhDichDo.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDItemKQXN()
        {
            int rowIndex = HT_sgKetQuaXN.ActiveRow.RowIndex;
            GridCell gridCell = HT_sgKetQuaXN.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDNguoiVanDong()
        {
            int rowIndex = HT_sgNguoiVanDong.ActiveRow.RowIndex;
            GridCell gridCell = HT_sgNguoiVanDong.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDLuuTruMau()
        {
            int rowIndex = HT_sgLuuTruMau.ActiveRow.RowIndex;
            GridCell gridCell = HT_sgLuuTruMau.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }


        int IdThongTinVoNH = 0;
        int IdKhamNamKhoa = 0;
        int IdDacTrungNH = 0;
        int IdTinhDichDo = 0;
        int IdKetQuaXN = 0;
        int IdNguoiVnDong = 0;
        int IdLuuTruMau = 0;

        bool CheckPatientApprove()
        {
            if (dbBN.CheckPatientApprove(HT_lbMaBN.Text))
            {
                MessageBox.Show("Bệnh nhân đã được phê duyệt nên không thay đổi được hồ sơ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void HT_btnTMLuuTruMau_Click(object sender, EventArgs e)
        {
            IdLuuTruMau = 0;
            HT_txtMatDoLTM.Clear();
            HT_txtDiDongLTM.Clear();
            HT_txtHinhDangLTM.Clear();
            HT_txtViTriLTM.Clear();
            HT_chkDuDieuKienLuuTru.Checked = false;
            HT_txtLyDoLuu.Clear();
            HT_chkBenhDiTruyen.Checked = false;
            HT_rtbGhiChuLTM.Clear();
            HT_dtNgayTaoLTM.ResetText();
        }

        private void HT_btnLuuLuuTruMau_Click(object sender, EventArgs e)
        {
            if (HT_txtViTriLTM.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var maMau = Utilities.GenMaUnixTime(app.GetTrungTamHTSS().MaTTHTSS);

            HT_LuuTruMau ltm = new HT_LuuTruMau(HT_lbMaBN.Text);
            ltm.MaMau = maMau;
            ltm.FlagUsed = false;
            ltm.MatDo = HT_txtMatDoLTM.Text;
            ltm.DiDong = HT_txtDiDongLTM.Text;
            ltm.HinhDang = HT_txtHinhDangLTM.Text;
            ltm.ViTri = HT_txtViTriLTM.Text;
            ltm.DuDieuKienLuuTru = HT_chkDuDieuKienLuuTru.Checked;
            ltm.LyDoLuu = HT_txtLyDoLuu.Text;
            ltm.BenhDiTruyen = HT_chkBenhDiTruyen.Checked;
            ltm.GhiChu = HT_rtbGhiChuLTM.Text;
            ltm.NgayTao = HT_dtNgayTaoLTM.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HT_sgLuuTruMau.PrimaryGrid;
            if (IdLuuTruMau == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHT_LuuTruMau))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ lưu trữ mẫu");

                int id = dbBN.AddLuuTruMau(ltm);

                HT_sgLuuTruMau.BeginUpdate();
                object[] ob1 = new object[]
                        {
                            id, ltm.MaMau, ltm.FlagUsed, ltm.NgayTao.ToString("dd-MM-yyyy")
                        };
                panel.Rows.Add(new GridRow(ob1));
                HT_sgLuuTruMau.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHT_LuuTruMau))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ lưu trữ mẫu ID = " + IdLuuTruMau.ToString());

                HT_LuuTruMau ltmEdit = dbBN.GetLuuTruMauByID(IdLuuTruMau);
                if (ltmEdit.FlagUsed)
                {
                    MessageBox.Show("Mẫu đã được sử dụng nên không được phép sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ltm.MaMau = ltmEdit.MaMau;
                dbBN.EditLuuTruMau(IdLuuTruMau, ltm);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdLuuTruMau)
                    {
                        r[1].Value = ltm.MaMau;
                        r[2].Value = ltm.FlagUsed;
                        r[3].Value = ltm.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HT_btnTM_ThongTinVoNH_Click(object sender, EventArgs e)
        {
            IdThongTinVoNH = 0;
            HT_txtHoVaTenVo.Clear();
            HT_txtSoCMNDVo.Clear();
            HT_dtNgayCapVo.ResetText();
            HT_txtNguyenQuanVo.Clear();
            HT_txtDiaChiNoiCapVo.Clear();
            HT_txtSoDienThoaiVo.Clear();
            HT_rtbGhiChuVo.Clear();
            HT_txtEmailVo.Clear();
        }

        private void HT_btnLuuThongTinVoNH_Click(object sender, EventArgs e)
        {
            if (HT_txtHoVaTenVo.Text == "" | HT_txtSoCMNDVo.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex phoneNumpattern = new Regex(@"^-*[0-9,\.?\-?\(?\)?\ ]+$");
            if (!phoneNumpattern.IsMatch(HT_txtSoDienThoaiVo.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HT_ThongTinNguoiQuanHeBN vo = new HT_ThongTinNguoiQuanHeBN(HT_lbMaBN.Text);
            vo.HoVaTen = HT_txtHoVaTenVo.Text;
            vo.SoCMND = HT_txtSoCMNDVo.Text;
            vo.NgayCap = HT_dtNgayCapVo.Value;
            vo.NguyenQuan = HT_txtNguyenQuanVo.Text;
            vo.DiaChiNoiCap = HT_txtDiaChiNoiCapVo.Text;
            vo.SoDienThoai = HT_txtSoDienThoaiVo.Text;
            vo.Email = HT_txtEmailVo.Text;
            vo.GhiChu = HT_rtbGhiChuVo.Text;
            vo.NgayTao = HT_dtNgayTaoVNH.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HT_sgThongTinVoNH.PrimaryGrid;
            if (IdThongTinVoNH == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHT_DanhSachVoBN))
                    return;

                app.SetHisOperate("Người dùng thêm mới danh sách người quan hệ bệnh nhân");
                int id = dbBN.AddVoBN(HT_lbMaBN.Text, vo);
                HT_sgThongTinVoNH.BeginUpdate();
                object[] ob1 = new object[]
                        {
                    id, vo.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HT_sgThongTinVoNH.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHT_DanhSachVoBN))
                    return;

                app.SetHisOperate("Người dùng sửa thông tin danh sách người quan hệ bệnh nhân ID = " + IdThongTinVoNH.ToString());

                dbBN.EditVoBN(IdThongTinVoNH, vo);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdThongTinVoNH)
                    {
                        r[1].Value = vo.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HT_btnTMKhamNamKhoa_Click(object sender, EventArgs e)
        {

            IdKhamNamKhoa = 0;
            HT_txtTTPhai.Clear();
            HT_txtTTTrai.Clear();
            HT_txtMaoTinh.Clear();
            HT_txtOngDanTinh.Clear();
            HT_txtVaricole.Clear();
            HT_txtDuongVat.Clear();
            HT_txtDacTinhSS.Clear();
            HT_rtbGhiChuKNK.Clear();
            HT_dtNgayTaoKNK.ResetText();
        }

        private void HT_btnLuuKhamNamKhoa_Click(object sender, EventArgs e)
        {
            HT_KhamNamKhoa knk = new HT_KhamNamKhoa(HT_lbMaBN.Text);
            knk.TTTrai = HT_txtTTTrai.Text;
            knk.TTPhai = HT_txtTTPhai.Text;
            knk.MaoTinh = HT_txtMaoTinh.Text;
            knk.OngDanTinh = HT_txtOngDanTinh.Text;
            knk.Varicole = HT_txtVaricole.Text;
            knk.DuongVat = HT_txtDuongVat.Text;
            knk.DacTinhSinhSan = HT_txtDacTinhSS.Text;
            knk.GhiChu = HT_rtbGhiChuKNK.Text;
            knk.NgayTao = HT_dtNgayTaoKNK.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HT_sgKhamNamKhoa.PrimaryGrid;

            if (IdKhamNamKhoa == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHT_KhamNamKhoa))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ khám nam khoa");

                int id = dbBN.AddKhamNamKhoa(knk);
                HT_sgKhamNamKhoa.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, knk.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HT_sgKhamNamKhoa.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHT_KhamNamKhoa))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ khám nam khoa ID = " + IdKhamNamKhoa.ToString());

                dbBN.EditKhamNamKhoa(IdKhamNamKhoa, knk);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdKhamNamKhoa)
                    {
                        r[1].Value = knk.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HT_btnTMDacTrungNH_Click(object sender, EventArgs e)
        {
            IdDacTrungNH = 0;
            HT_txtChieuCao.Clear();
            HT_txtCanNang.Clear();
            HT_txtMauMat.Clear();
            HT_txtMauToc.Clear();
            HT_txtKieuToc.Clear();
            HT_txtMauDa.Clear();
            HT_rtbGhiChuDT.Clear();
            HT_dtNgayTaoDT.ResetText();
        }

        private void HT_btnLuuDacTrungNH_Click(object sender, EventArgs e)
        {
            if (HT_txtChieuCao.Text == "" | HT_txtCanNang.Text == "" | HT_txtMauMat.Text == "" | HT_txtMauDa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HT_DacTrungNguoiHien dt = new HT_DacTrungNguoiHien(HT_lbMaBN.Text);
            dt.ChieuCao = HT_txtChieuCao.Text;
            dt.CanNang = HT_txtCanNang.Text;
            dt.MauMat = HT_txtMauMat.Text;
            dt.MauToc = HT_txtMauToc.Text;
            dt.KieuToc = HT_txtKieuToc.Text;
            dt.MauDa = HT_txtMauDa.Text;
            dt.GhiChu = HT_rtbGhiChuDT.Text;
            dt.NgayTao = HT_dtNgayTaoDT.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HT_sgDacTrungNH.PrimaryGrid;

            if (IdDacTrungNH == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHT_DacTrungBenhNhan))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ đặc trưng bệnh nhân");

                int id = dbBN.AddDacTrung(dt);
                HT_sgDacTrungNH.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, dt.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HT_sgDacTrungNH.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHT_DacTrungBenhNhan))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ đặc trưng bệnh nhân ID = " + IdDacTrungNH.ToString());

                dbBN.EditDacTrung(IdDacTrungNH, dt);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdDacTrungNH)
                    {
                        r[1].Value = dt.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HT_btnTMTinhDichDo_Click(object sender, EventArgs e)
        {
            IdTinhDichDo = 0;
            HT_txtMauSac.Clear();
            HT_txtTheTich.Clear();
            HT_txtLyGiai.Clear();
            HT_txtPH.Clear();
            HT_numMatDo.ResetText();
            HT_numTongSoTinhTrung.ResetText();
            HT_numTiLeTinhTrungSong.ResetText();
            HT_numDiDongTienToi.ResetText();
            HT_numDiDongKhongTienToi.ResetText();
            HT_numBatDong.ResetText();
            HT_numHinhThaiBinhThuong.ResetText();
            HT_numHinhThaiBatThuongDau.ResetText();
            HT_NumHinhThaiBatThuongCo.ResetText();
            HT_numHinhThaiBatThuongDuoi.ResetText();
            HT_txtTeBaoHinhTron.Clear();
            HT_rtbGhiChuTTD.Clear();
            HT_dtNgayTaoTDD.ResetText();
        }

        private void HT_btnLuuTinhDichDo_Click(object sender, EventArgs e)
        {
            HT_TinhDichDo tdd = new HT_TinhDichDo(HT_lbMaBN.Text);

            tdd.MauSac = HT_txtMauSac.Text;
            tdd.TheTich = HT_txtTheTich.Text;
            tdd.LyGiai = HT_txtLyGiai.Text;
            tdd.PH = HT_txtPH.Text;
            tdd.MatDo = Convert.ToInt32(HT_numMatDo.Text);
            tdd.TongSoTinhTrung = Convert.ToInt32(HT_numTongSoTinhTrung.Text);
            tdd.TiLeTinhTrungSong = Convert.ToInt32(HT_numTiLeTinhTrungSong.Text);
            tdd.DiDongTienToi = Convert.ToInt32(HT_numDiDongTienToi.Text);
            tdd.DiDongKhongTienToi = Convert.ToInt32(HT_numDiDongKhongTienToi.Text);
            tdd.BatDong = Convert.ToInt32(HT_numBatDong.Text);
            tdd.HinhThaiBinhThuong = Convert.ToInt32(HT_numHinhThaiBinhThuong.Text);
            tdd.HinhThaiBatThuong_Dau = Convert.ToInt32(HT_numHinhThaiBatThuongDau.Text);
            tdd.HinhThaiBatThuong_Co = Convert.ToInt32(HT_NumHinhThaiBatThuongCo.Text);
            tdd.HinhThaiBatThuong_Duoi = Convert.ToInt32(HT_numHinhThaiBatThuongDuoi.Text);
            tdd.TeBaoHinhTron = HT_txtTeBaoHinhTron.Text;

            tdd.GhiChu = HT_rtbGhiChuTTD.Text;
            tdd.NgayTao = HT_dtNgayTaoDT.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HT_sgTinhDichDo.PrimaryGrid;
            if (IdTinhDichDo == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHT_TinhDichDo))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ tinh dịch đồ");

                int id = dbBN.AddTinhDichDo(tdd);
                HT_sgTinhDichDo.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, tdd.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HT_sgTinhDichDo.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHT_TinhDichDo))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ tinh dịch đồ ID = " + IdTinhDichDo.ToString());

                dbBN.EditTinhDichDo(IdTinhDichDo, tdd);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdTinhDichDo)
                    {
                        r[1].Value = tdd.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HT_btnTMKetQuaXetNghiem_Click(object sender, EventArgs e)
        {
            IdKetQuaXN = 0;
            HT_txtNhomMau.Clear();
            HT_txtHIV.Clear();
            HT_txtBW.Clear();
            HT_txtHBsAg.Clear();
            HT_txtAntiHCV.Clear();
            HT_txtSoLanKiemTraKQXN.ResetText();
            HT_rtbGhiChuKQXN.Clear();
            HT_dtNgayTaoKQXN.ResetText();
        }

        private void HT_btnLuuKetQuaXetNghiem_Click(object sender, EventArgs e)
        {
            if (HT_txtNhomMau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HT_KetQuaXetNghiem kq = new HT_KetQuaXetNghiem(HT_lbMaBN.Text);
            kq.NhomMau = HT_txtNhomMau.Text;
            kq.HIV = HT_txtHIV.Text;
            kq.BW = HT_txtBW.Text;
            kq.HBsAg = HT_txtHBsAg.Text;
            kq.AntiHCV = HT_txtAntiHCV.Text;
            kq.SoLanKiemTra = Convert.ToInt32(HT_txtSoLanKiemTraKQXN.Text);
            kq.GhiChu = HT_rtbGhiChuKQXN.Text;
            kq.NgayTao = HT_dtNgayTaoKQXN.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HT_sgKetQuaXN.PrimaryGrid;
            if (IdKetQuaXN == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHT_KetQuaXetNghiem))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ kết quả xét nghiệm");

                int id = dbBN.AddKetQuaXetNghiem(kq);
                HT_sgKetQuaXN.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, kq.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HT_sgKetQuaXN.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHT_KetQuaXetNghiem))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ kết quả xét nghiệm ID = " + IdKetQuaXN.ToString());

                dbBN.EditKetQuaXetNghiem(IdKetQuaXN, kq);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdKetQuaXN)
                    {
                        r[1].Value = kq.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HT_btnTMNguoiVanDong_Click(object sender, EventArgs e)
        {
            IdNguoiVnDong = 0;
            HT_txtHoTenNVD.Clear();
            HT_txtEmailNVD.Clear();
            HT_txtSoDienThoaiNVD.Clear();
            HT_txtSoCMNDNVD.Clear();
            HT_dtNgayCapNVD.ResetText();
            HT_txtNguyenQuanNVD.Clear();
            HT_txtDiaChiNoiCap.Clear();
            HT_cboTinhThanhNVD.SelectedIndex = 0;
            HT_cboQuanHuyenNVD.SelectedIndex = 0;
            HT_txtQuanHeNguoiHien.Clear();
            HT_rtbGhiChuNVD.Clear();
            HT_dtNgayTaoNVD.ResetText();
        }

        private void HT_btnLuuNguoiVanDong_Click(object sender, EventArgs e)
        {
            if (HT_txtHoTenNVD.Text == "" | HT_txtSoCMNDNVD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex phoneNumpattern = new Regex(@"^-*[0-9,\.?\-?\(?\)?\ ]+$");
            if (!phoneNumpattern.IsMatch(HT_txtSoDienThoaiNVD.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HT_NguoiVanDong nvd = new HT_NguoiVanDong(HT_lbMaBN.Text);
            nvd.HoVaTen = HT_txtHoTenNVD.Text;
            nvd.Email = HT_txtEmailNVD.Text;
            nvd.SoDienThoai = HT_txtSoDienThoaiNVD.Text;
            nvd.SoCMND = HT_txtSoCMNDNVD.Text;
            nvd.NgayCap = HT_dtNgayCapNVD.Value;
            nvd.NguyenQuan = HT_txtNguyenQuanNVD.Text;
            nvd.DiaChiNoiCap = HT_txtDiaChiNoiCap.Text;
            nvd.Tinh_ThanhPho = HT_cboTinhThanhNVD.SelectedValue.ToString();
            nvd.Quan_Huyen = HT_cboQuanHuyenNVD.SelectedValue.ToString();
            nvd.QuanHeVoiNguoiHien = HT_txtQuanHeNguoiHien.Text;
            nvd.GhiChu = HT_rtbGhiChuNVD.Text;
            nvd.NgayTao = HT_dtNgayTaoNVD.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HT_sgNguoiVanDong.PrimaryGrid;

            if (IdNguoiVnDong == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHT_NguoiVanDong))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ người vận động");

                int id = dbBN.AddNguoiVanDong(nvd);
                HT_sgNguoiVanDong.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, nvd.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HT_sgNguoiVanDong.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHT_NguoiVanDong))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ người vận động ID = " + IdNguoiVnDong.ToString());

                dbBN.EditNguoiVanDong(IdNguoiVnDong, nvd);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdNguoiVnDong)
                    {
                        r[1].Value = nvd.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }


        private void HT_TabThongTinVoNH_Click(object sender, EventArgs e)
        {
            List<HT_ThongTinNguoiQuanHeBN> ttnqhs = dbBN.GetVoBNByPatient(HT_lbMaBN.Text);
            GridPanel panel = HT_sgThongTinVoNH.PrimaryGrid;
            panel.Rows.Clear();
            HT_sgThongTinVoNH.BeginUpdate();
            foreach (var ttnqh in ttnqhs)
            {
                object[] ob1 = new object[]
                    {
                    ttnqh.Id, ttnqh.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HT_sgThongTinVoNH.EndUpdate();

            HT_dtNgayTaoVNH.Value = DateTime.Now;
        }

        private void HT_TabKhamNamKhoa_Click(object sender, EventArgs e)
        {
            List<HT_KhamNamKhoa> knks = dbBN.GetKhamNamKhoaByPatient(HT_lbMaBN.Text);
            GridPanel panel = HT_sgKhamNamKhoa.PrimaryGrid;
            panel.Rows.Clear();
            HT_sgKhamNamKhoa.BeginUpdate();
            foreach (var knk in knks)
            {
                object[] ob1 = new object[]
                    {
                    knk.Id, knk.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HT_sgKhamNamKhoa.EndUpdate();

            HT_dtNgayTaoKNK.Value = DateTime.Now;
        }

        private void HT_TabDacTrung_Click(object sender, EventArgs e)
        {
            List<HT_DacTrungNguoiHien> dtnhs = dbBN.GetDacTrungByPatient(HT_lbMaBN.Text);
            GridPanel panel = HT_sgDacTrungNH.PrimaryGrid;
            panel.Rows.Clear();
            HT_sgDacTrungNH.BeginUpdate();
            foreach (var dt in dtnhs)
            {
                object[] ob1 = new object[]
                    {
                    dt.Id, dt.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HT_sgDacTrungNH.EndUpdate();

            HT_dtNgayTaoDT.Value = DateTime.Now;
        }

        private void HT_TabTinhDichDo_Click(object sender, EventArgs e)
        {
            List<HT_TinhDichDo> tdds = dbBN.GetTinhDichDoByPatient(HT_lbMaBN.Text);
            GridPanel panel = HT_sgTinhDichDo.PrimaryGrid;
            panel.Rows.Clear();
            HT_sgTinhDichDo.BeginUpdate();
            foreach (var tdd in tdds)
            {
                object[] ob1 = new object[]
                    {
                    tdd.Id, tdd.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HT_sgTinhDichDo.EndUpdate();

            HT_dtNgayTaoTDD.Value = DateTime.Now;
        }

        private void HT_TabKetQuaXN_Click(object sender, EventArgs e)
        {
            List<HT_KetQuaXetNghiem> kqxns = dbBN.GetKetQuaXetNghiemByPatient(HT_lbMaBN.Text);
            GridPanel panel = HT_sgKetQuaXN.PrimaryGrid;
            panel.Rows.Clear();
            HT_sgKetQuaXN.BeginUpdate();
            foreach (var kq in kqxns)
            {
                object[] ob1 = new object[]
                    {
                    kq.Id, kq.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HT_sgKetQuaXN.EndUpdate();

            HT_dtNgayTaoKQXN.Value = DateTime.Now;
        }

        private void HT_TabNguoiVanDongHT_Click(object sender, EventArgs e)
        {
            List<HT_NguoiVanDong> nvds = dbBN.GetNguoivanDongPatient(HT_lbMaBN.Text);
            GridPanel panel = HT_sgNguoiVanDong.PrimaryGrid;
            panel.Rows.Clear();
            HT_sgNguoiVanDong.BeginUpdate();
            foreach (var nvd in nvds)
            {
                object[] ob1 = new object[]
                    {
                    nvd.Id, nvd.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HT_sgNguoiVanDong.EndUpdate();

            HT_dtNgayTaoNVD.Value = DateTime.Now;
        }

        private void HT_TabLuuTruMau_Click(object sender, EventArgs e)
        {
            List<HT_LuuTruMau> ltms = dbBN.GetLuuTruMauByPatient(HT_lbMaBN.Text);
            GridPanel panel = HT_sgLuuTruMau.PrimaryGrid;
            panel.Rows.Clear();
            HT_sgLuuTruMau.BeginUpdate();
            foreach (var ltm in ltms)
            {
                object[] ob1 = new object[]
                    {
                    ltm.Id, ltm.MaMau, ltm.FlagUsed, ltm.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HT_sgLuuTruMau.EndUpdate();

            HT_dtNgayTaoLTM.Value = DateTime.Now;
        }


        private void XemChiTiet_Click(object sender, EventArgs e)
        {
            if (HT_superTab.SelectedTab.Text == "THÔNG TIN VỢ NGƯỜI HIẾN")
            {
                int id = GetIDItemThongTinVoNguoiHien();
                if (id != -1)
                {
                    IdThongTinVoNH = id;
                    HT_ThongTinNguoiQuanHeBN vo = dbBN.GetVoBNByID(id);
                    HT_txtHoVaTenVo.Text = vo.HoVaTen;
                    HT_txtSoCMNDVo.Text = vo.SoCMND;
                    HT_dtNgayCapVo.Value = vo.NgayCap;
                    HT_txtNguyenQuanVo.Text = vo.NguyenQuan;
                    HT_txtDiaChiNoiCapVo.Text = vo.DiaChiNoiCap;
                    HT_txtSoDienThoaiVo.Text = vo.SoDienThoai;
                    HT_txtEmailVo.Text = vo.Email;
                    HT_rtbGhiChuVo.Text = vo.GhiChu;
                    HT_dtNgayTaoVNH.Value = vo.NgayTao;
                }
            }
            else if (HT_superTab.SelectedTab.Text == "KHÁM NAM KHOA")
            {
                int id = GetIDItemKhamNamKhoa();
                if (id != -1)
                {
                    IdKhamNamKhoa = id;
                    HT_KhamNamKhoa knk = dbBN.GetKhamNamKhoaByID(id);
                    HT_txtTTTrai.Text = knk.TTTrai;
                    HT_txtTTPhai.Text = knk.TTPhai;
                    HT_txtMaoTinh.Text = knk.MaoTinh;
                    HT_txtOngDanTinh.Text = knk.OngDanTinh;
                    HT_txtVaricole.Text = knk.Varicole;
                    HT_txtDuongVat.Text = knk.DuongVat;
                    HT_txtDacTinhSS.Text = knk.DacTinhSinhSan;
                    HT_rtbGhiChuKNK.Text = knk.GhiChu;
                    HT_dtNgayTaoKNK.Value = knk.NgayTao;
                }
            }
            else if (HT_superTab.SelectedTab.Text == "ĐẶC TRƯNG NGƯỜI HIẾN")
            {
                int id = GetIDItemDacTrungNH();
                if (id != -1)
                {
                    IdDacTrungNH = id;
                    HT_DacTrungNguoiHien dt = dbBN.GetDacTrungByID(id);
                    HT_txtChieuCao.Text = dt.ChieuCao;
                    HT_txtCanNang.Text = dt.CanNang;
                    HT_txtMauMat.Text = dt.MauMat;
                    HT_txtMauToc.Text = dt.MauToc;
                    HT_txtKieuToc.Text = dt.KieuToc;
                    HT_txtMauDa.Text = dt.MauDa;
                    HT_rtbGhiChuDT.Text = dt.GhiChu;
                    HT_dtNgayTaoKNK.Value = dt.NgayTao;
                }
            }
            else if (HT_superTab.SelectedTab.Text == "TINH DỊCH ĐỒ")
            {
                int id = GetIDItemTinhDichDo();
                if (id != -1)
                {
                    IdTinhDichDo = id;
                    HT_TinhDichDo tdd = dbBN.GetTinhDichDoByID(id);
                    HT_txtMauSac.Text = tdd.MauSac;
                    HT_txtTheTich.Text = tdd.TheTich;
                    HT_txtLyGiai.Text = tdd.LyGiai;
                    HT_txtPH.Text = tdd.PH;
                    HT_numMatDo.Value = tdd.MatDo;
                    HT_numTongSoTinhTrung.Value = tdd.TongSoTinhTrung;
                    HT_numTiLeTinhTrungSong.Value = tdd.TiLeTinhTrungSong;
                    HT_numDiDongTienToi.Value = tdd.DiDongTienToi;
                    HT_numDiDongKhongTienToi.Value = tdd.DiDongKhongTienToi;
                    HT_numBatDong.Value = tdd.BatDong;
                    HT_numHinhThaiBinhThuong.Value = tdd.HinhThaiBinhThuong;
                    HT_numHinhThaiBatThuongDau.Value = tdd.HinhThaiBatThuong_Dau;
                    HT_NumHinhThaiBatThuongCo.Value = tdd.HinhThaiBatThuong_Co;
                    HT_numHinhThaiBatThuongDuoi.Value = tdd.HinhThaiBatThuong_Duoi;
                    HT_txtTeBaoHinhTron.Text = tdd.TeBaoHinhTron;

                    HT_rtbGhiChuTTD.Text = tdd.GhiChu;
                    HT_dtNgayTaoTDD.Value = tdd.NgayTao;
                }
            }
            else if (HT_superTab.SelectedTab.Text == "KẾT QUẢ XÉT NGHIỆM")
            {
                int id = GetIDItemKQXN();
                if (id != -1)
                {
                    IdKetQuaXN = id;
                    HT_KetQuaXetNghiem kq = dbBN.GetKetQuaXetNghiemByID(id);
                    HT_txtNhomMau.Text = kq.NhomMau;
                    HT_txtHIV.Text = kq.HIV;
                    HT_txtBW.Text = kq.BW;
                    HT_txtHBsAg.Text = kq.HBsAg;
                    HT_txtAntiHCV.Text = kq.AntiHCV;
                    HT_txtSoLanKiemTraKQXN.Text = kq.SoLanKiemTra.ToString(); ;
                    HT_rtbGhiChuKQXN.Text = kq.GhiChu;
                    HT_dtNgayTaoKQXN.Value = kq.NgayTao;
                }
            }
            else if (HT_superTab.SelectedTab.Text == "THÔNG TIN NGƯỜI VẬN ĐỘNG")
            {
                int id = GetIDNguoiVanDong();
                if (id != -1)
                {
                    IdNguoiVnDong = id;
                    HT_NguoiVanDong nvd = dbBN.GetNguoiVanDongByID(id);
                    HT_txtHoTenNVD.Text = nvd.HoVaTen;
                    HT_txtEmailNVD.Text = nvd.Email;
                    HT_txtSoDienThoaiNVD.Text = nvd.SoDienThoai;
                    HT_txtSoCMNDNVD.Text = nvd.SoCMND;
                    HT_dtNgayCapNVD.Value = nvd.NgayCap;
                    HT_txtNguyenQuanNVD.Text = nvd.NguyenQuan;
                    HT_txtDiaChiNoiCapNVD.Text = nvd.DiaChiNoiCap;
                    HT_cboTinhThanhNVD.SelectedValue = nvd.Tinh_ThanhPho;
                    HT_cboQuanHuyenNVD.SelectedValue = nvd.Quan_Huyen;
                    HT_txtQuanHeNguoiHien.Text = nvd.QuanHeVoiNguoiHien;
                    HT_rtbGhiChuNVD.Text = nvd.GhiChu;
                    HT_dtNgayTaoNVD.Value = nvd.NgayTao;
                }
            }
            else if (HT_superTab.SelectedTab.Text == "LƯU TRỮ MẪU")
            {
                int id = GetIDLuuTruMau();
                if (id != -1)
                {
                    IdLuuTruMau = id;
                    HT_LuuTruMau ltm = dbBN.GetLuuTruMauByID(id);
                    HT_txtMatDoLTM.Text = ltm.MatDo;
                    HT_txtDiDongLTM.Text = ltm.DiDong;
                    HT_txtHinhDangLTM.Text = ltm.HinhDang;
                    HT_txtViTriLTM.Text = ltm.ViTri;
                    HT_chkDuDieuKienLuuTru.Checked = ltm.DuDieuKienLuuTru;
                    HT_txtLyDoLuu.Text = ltm.LyDoLuu;
                    HT_chkBenhDiTruyen.Checked = ltm.BenhDiTruyen;
                    HT_rtbGhiChuLTM.Text = ltm.GhiChu;
                    HT_dtNgayTaoLTM.Value = ltm.NgayTao;
                }
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            GridPanel panel = new GridPanel();
            int id = -1;

            if (HT_superTab.SelectedTab.Text == "THÔNG TIN VỢ NGƯỜI HIẾN")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHT_DanhSachVoBN))
                    return;

                id = GetIDItemThongTinVoNguoiHien();
                panel = HT_sgThongTinVoNH.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ thông tin người quan hệ với BNHT ID = " + id.ToString());
                    dbBN.DeleteVoBN(id);
                }
            }
            else if (HT_superTab.SelectedTab.Text == "KHÁM NAM KHOA")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHT_KhamNamKhoa))
                    return;

                id = GetIDItemKhamNamKhoa();
                panel = HT_sgKhamNamKhoa.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ khám nam khoa ID = " + id.ToString());
                    dbBN.DeleteKhamNamKhoa(id);
                }
            }
            else if (HT_superTab.SelectedTab.Text == "ĐẶC TRƯNG NGƯỜI HIẾN")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHT_DacTrungBenhNhan))
                    return;

                id = GetIDItemDacTrungNH();
                panel = HT_sgDacTrungNH.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ đặc trưng BNHT ID = " + id.ToString());
                    dbBN.DeleteDacTrung(id);
                }
            }
            else if (HT_superTab.SelectedTab.Text == "TINH DỊCH ĐỒ")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHT_TinhDichDo))
                    return;

                id = GetIDItemTinhDichDo();
                panel = HT_sgTinhDichDo.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ tinh dịch đồ ID = " + id.ToString());
                    dbBN.DeleteTinhDichDo(id);
                }
            }
            else if (HT_superTab.SelectedTab.Text == "KẾT QUẢ XÉT NGHIỆM")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHT_KetQuaXetNghiem))
                    return;

                id = GetIDItemKQXN();
                panel = HT_sgKetQuaXN.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ kết quả xét nghiệm BNHT ID = " + id.ToString());
                    dbBN.DeleteKetQuaXetNghiem(id);
                }
            }
            else if (HT_superTab.SelectedTab.Text == "THÔNG TIN NGƯỜI VẬN ĐỘNG")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHT_NguoiVanDong))
                    return;

                id = GetIDNguoiVanDong();
                panel = HT_sgNguoiVanDong.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ người vận động hiến tinh ID = " + id.ToString());
                    dbBN.DeleteNguoiVanDong(id);
                }
            }
            else if (HT_superTab.SelectedTab.Text == "LƯU TRỮ MẪU")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHT_LuuTruMau))
                    return;

                id = GetIDLuuTruMau();
                panel = HT_sgLuuTruMau.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ lưu trữ mẫu ID = " + id.ToString());
                    dbBN.DeleteLuuTruMau(id);
                }
            }

            if (id != -1)
            {
                panel.SetDeleted(panel.ActiveRow, true);
                MessageSaveSuccess();
            }
        }


        private void HoSoNguoiHienTinh_Load(object sender, EventArgs e)
        {
            AppsLIST.bIsTimeToDie = true;

            FormHandle = this.Handle;

            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(AppsLIST.mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(AppsLIST.mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            Thread captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            AppsLIST.bIsTimeToDie = false;
        }

        private void HT_btnTaoHoSoMoi_Click(object sender, EventArgs e)
        {
            if (HT_txtHoVaTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ và tên bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (HT_dTNgaySinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (HT_txtSoCMND.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số CMND bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex phoneNumpattern = new Regex(@"^-*[0-9,\.?\-?\(?\)?\ ]+$");
            if (!phoneNumpattern.IsMatch(HT_txtSoDienThoai.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsHoSoDaDuocTao)
            {
                if (!AllowCreateInfoAfterCheckTTCNTT)
                {
                    var ret = MessageBox.Show("Bạn chưa kiểm tra dữ liệu vân tay có trên trung tâm CNTT hoặc hồ sơ không đủ điều kiện để tạo. Bạn vẫn muốn tạo hồ sơ bệnh nhân mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.No)
                        return;
                }

                if (!CheckPermissionAdd(Utilities.FUN_HNHT_QuanLyThongTinChungBNHT))
                    return;

                HT_ThongTinNguoiHienTinh bn = new HT_ThongTinNguoiHienTinh(HT_lbMaBN.Text);
                bn.HoVaTen = HT_txtHoVaTen.Text;
                bn.NgaySinh = HT_dTNgaySinh.Value;
                bn.SoDienThoai = HT_txtSoDienThoai.Text;
                bn.Email = HT_txtEmail.Text;
                bn.TrinhDoHocVan = Convert.ToInt32(HT_cboTrinhDo.SelectedValue.ToString());
                bn.CongViec = HT_txtCongViec.Text;
                bn.QuocTichID = 84;
                bn.Tinh_ThanhPho = HT_cboTinhThanh.SelectedValue.ToString();
                bn.Quan_Huyen = HT_cboQuanHuyen.SelectedValue.ToString();
                bn.DanToc = Convert.ToInt32(HT_cboDanToc.SelectedValue);
                bn.SoCMND = HT_txtSoCMND.Text;
                bn.NgayCap = HT_dTNgayCap.Value;
                bn.NguyenQuan = HT_txtNguyenQuan.Text;
                bn.DiaChiNoiCap = HT_txtDiaChiNoiCap.Text;
                bn.DaLapGiaDinh = HT_chkDaLapGiaDinh.Checked;
                bn.DaCoCon = HT_chkCoCon.Checked;

                bn.SoCon = Convert.ToInt32(HT_txtSoCon.Text);
                bn.TuoiCoConGanNhat = Convert.ToInt32(HT_txtTuoiCoConGanNhat.Text);
                bn.ThoiDiemVoMangThai = Convert.ToInt32(Ht_txtThoiDiemVoMangThai.Text);
                bn.TrangThaiSucKhoe = HT_txtTrangThaiSucKhoe.Text;
                bn.TieuSuBenh = HT_txtTieuSuBenh.Text;
                bn.TieuSuBenhGiaDinh = HT_txtTieuSuBenhGiaDinh.Text;

                Bitmap bmp;
                if (HT_picNgonCaiPhai.Image != null)
                {
                    bmp = new Bitmap(HT_picNgonCaiPhai.Image);
                    bn.VT_CaiPhai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HT_picNgonCaiTrai.Image != null)
                {
                    bmp = new Bitmap(HT_picNgonCaiTrai.Image);
                    bn.VT_CaiTrai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HT_picNgonTroPhai.Image != null)
                {
                    bmp = new Bitmap(HT_picNgonTroPhai.Image);
                    bn.VT_TroPhai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HT_picNgonTroTrai.Image != null)
                {
                    bmp = new Bitmap(HT_picNgonTroTrai.Image);
                    bn.VT_TroTrai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                bn.MaTrungTamHTSS = app.GetTrungTamHTSS().MaTTHTSS;

                var checkCMND = dbBN.CheckDuplicateNoCMND(HT_txtSoCMND.Text);
                if (checkCMND != null)
                {
                    MessageBox.Show("Số chứng minh nhân dân " + HT_txtSoCMND.Text + " đã bị trùng với bệnh nhân "+ checkCMND.HoVaTen, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maBN = "";
                bool check = CheckFP(ref maBN);
                if (check)
                {
                    bn.VT_CaiPhai = FPBlobNgonCaiPhai;
                    bn.VT_CaiTrai = FPBlobNgonCaiTrai;
                    bn.VT_TroPhai = FPBlobNgonTroPhai;
                    bn.VT_TroTrai = FPBlobNgonTroTrai;

                    bn.FlagAllowAddPattern = false;
                    bn.NgayTao = HT_dTNgayTao.Value;

                    app.SetHisOperate("Tạo mới bộ hồ sơ bệnh nhân hiến tinh");

                    dbBN.AddNewPatient(bn);

                    IsHoSoDaDuocTao = true;
                    HT_btnTaoHoSoMoi.Text = "SỬA HỒ SƠ";

                    MessageBox.Show("Đã tạo hồ sơ thành công trên hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HT_ThongTinNguoiHienTinh oldBN = dbBN.GetInformationPatient(maBN);
                    MessageBox.Show("Thông tin vân tay này đã bị trùng với bệnh nhân " + oldBN.HoVaTen + " với số CMND " + oldBN.SoCMND, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!CheckPermissionEdit(Utilities.FUN_HNHT_QuanLyThongTinChungBNHT))
                    return;

                HT_ThongTinNguoiHienTinh bn = new HT_ThongTinNguoiHienTinh(HT_lbMaBN.Text);
                bn.HoVaTen = HT_txtHoVaTen.Text;
                bn.NgaySinh = HT_dTNgaySinh.Value;
                bn.SoDienThoai = HT_txtSoDienThoai.Text;
                bn.Email = HT_txtEmail.Text;
                bn.TrinhDoHocVan = Convert.ToInt32(HT_cboTrinhDo.SelectedValue.ToString());
                bn.CongViec = HT_txtCongViec.Text;
                bn.QuocTichID = 84;
                bn.Tinh_ThanhPho = HT_cboTinhThanh.SelectedValue.ToString();
                bn.Quan_Huyen = HT_cboQuanHuyen.SelectedValue.ToString();
                bn.DanToc = Convert.ToInt32(HT_cboDanToc.SelectedValue);
                bn.SoCMND = HT_txtSoCMND.Text;
                bn.NgayCap = HT_dTNgayCap.Value;
                bn.NguyenQuan = HT_txtNguyenQuan.Text;
                bn.DiaChiNoiCap = HT_txtDiaChiNoiCap.Text;
                bn.DaLapGiaDinh = HT_chkDaLapGiaDinh.Checked;
                bn.DaCoCon = HT_chkCoCon.Checked;

                bn.SoCon = Convert.ToInt32(HT_txtSoCon.Text);
                bn.TuoiCoConGanNhat = Convert.ToInt32(HT_txtTuoiCoConGanNhat.Text);
                bn.ThoiDiemVoMangThai = Convert.ToInt32(Ht_txtThoiDiemVoMangThai.Text);
                bn.TrangThaiSucKhoe = HT_txtTrangThaiSucKhoe.Text;
                bn.TieuSuBenh = HT_txtTieuSuBenh.Text;
                bn.TieuSuBenhGiaDinh = HT_txtTieuSuBenhGiaDinh.Text;

                bn.MaTrungTamHTSS = app.GetTrungTamHTSS().MaTTHTSS;

                Bitmap bmp;
                if (HT_picNgonCaiPhai.Image != null)
                {
                    bmp = new Bitmap(HT_picNgonCaiPhai.Image);
                    bn.VT_CaiPhai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HT_picNgonCaiTrai.Image != null)
                {
                    bmp = new Bitmap(HT_picNgonCaiTrai.Image);
                    bn.VT_CaiTrai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HT_picNgonTroPhai.Image != null)
                {
                    bmp = new Bitmap(HT_picNgonTroPhai.Image);
                    bn.VT_TroPhai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HT_picNgonTroTrai.Image != null)
                {
                    bmp = new Bitmap(HT_picNgonTroTrai.Image);
                    bn.VT_TroTrai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                bn.VT_CaiPhai = FPBlobNgonCaiPhai;
                bn.VT_CaiTrai = FPBlobNgonCaiTrai;
                bn.VT_TroPhai = FPBlobNgonTroPhai;
                bn.VT_TroTrai = FPBlobNgonTroTrai;

                HT_ThongTinNguoiHienTinh editPatient = dbBN.GetInformationPatient(HT_lbMaBN.Text);
                bn.FlagAllowAddPattern = editPatient.FlagAllowAddPattern;
                bn.NgayTao = HT_dTNgayTao.Value;

                app.SetHisOperate("Sửa bộ hồ sơ bệnh nhân hiến tinh với mã bệnh nhân " + bn.MaBN);

                dbBN.EditInformationPatient(bn.MaBN, bn);

                MessageSaveSuccess();
            }
        }

        private void HT_btnHuyHoSo_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ chỉnh sửa trên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                app.ShowFormBegin();
            }
        }

        private void SaveFile(DocX doc)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.DefaultExt = ".docx";
                saveFileDialog1.Filter = "Docx files (*.docx)|*.doc|All files (*.*)|*.*";
                doc.SaveAs(saveFileDialog1.FileName);
            }
        }

        private DocX CreateReportCommon(DocX temp)
        {
            TrungTamHTSS tt = app.GetTrungTamHTSS();

            var MaBNBookmark = temp.Bookmarks["MaBN"];
            if (MaBNBookmark != null)
            {
                MaBNBookmark.SetText(HT_lbMaBN.Text);
            }

            var TenTTBookmark = temp.Bookmarks["TenBVPSTW"];
            if (TenTTBookmark != null)
            {
                TenTTBookmark.SetText(tt.TenTrungTam);
            }

            var TenBN = temp.Bookmarks["TenBN"];
            if (TenBN != null)
            {
                TenBN.SetText(HT_txtHoVaTen.Text);
            }

            var DiachiBN = temp.Bookmarks["DiachiBN"];
            if (DiachiBN != null)
            {
                DiachiBN.SetText(HT_txtNguyenQuan.Text);
            }

            var SoDienThoaiBN = temp.Bookmarks["SoDienThoaiBN"];
            if (SoDienThoaiBN != null)
            {
                SoDienThoaiBN.SetText(HT_txtSoDienThoai.Text);
            }

            return temp;
        }

        private void HT_btnXuatLuuTruMau_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_luu_tru_mau.docx");
                DocX doc = CreateReportCommon(g_document);

                var MatDo = doc.Bookmarks["MatDo"];
                if (MatDo != null)
                {
                    MatDo.SetText(HT_txtMatDoLTM.Text);
                }

                var DiDong = doc.Bookmarks["DiDong"];
                if (DiDong != null)
                {
                    DiDong.SetText(HT_txtDiDongLTM.Text);
                }

                var HinhDang = doc.Bookmarks["HinhDang"];
                if (HinhDang != null)
                {
                    HinhDang.SetText(HT_txtHinhDangLTM.Text);
                }

                var ViTri = doc.Bookmarks["ViTri"];
                if (ViTri != null)
                {
                    ViTri.SetText(HT_txtViTriLTM.Text);
                }

                string bdt = "Không";
                if (HT_chkBenhDiTruyen.Checked)
                    bdt = "Có";

                var BenhDiTruyen = doc.Bookmarks["BenhDiTruyen"];
                if (BenhDiTruyen != null)
                {
                    BenhDiTruyen.SetText(bdt);
                }

                string dudkLuu = "Không";
                if (HT_chkDuDieuKienLuuTru.Checked)
                    dudkLuu = "Có";
                var DuDieuKienLuuTru = doc.Bookmarks["DuDieuKienLuuTru"];
                if (DuDieuKienLuuTru != null)
                {
                    DuDieuKienLuuTru.SetText(dudkLuu);
                }

                var LyDoLuu = doc.Bookmarks["LyDoLuuTru"];
                if (LyDoLuu != null)
                {
                    LyDoLuu.SetText(HT_txtLyDoLuu.Text);
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HT_rtbGhiChuLTM.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HT_dtNgayTaoLTM.Value.ToString("dd-MM-yyyy"));
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HT_btnXuatKQXN_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_xet_nghiem.docx");
                DocX doc = CreateReportCommon(g_document);

                var NhomMau = doc.Bookmarks["NhomMau"];
                if (NhomMau != null)
                {
                    NhomMau.SetText(HT_txtNhomMau.Text);
                }

                var HIV = doc.Bookmarks["HIV"];
                if (HIV != null)
                {
                    HIV.SetText(HT_txtHIV.Text);
                }

                var BW = doc.Bookmarks["BW"];
                if (BW != null)
                {
                    BW.SetText(HT_txtBW.Text);
                }

                var Hbsag = doc.Bookmarks["Hbsag"];
                if (Hbsag != null)
                {
                    Hbsag.SetText(HT_txtHBsAg.Text);
                }

                var AntiHCV = doc.Bookmarks["AntiHCV"];
                if (AntiHCV != null)
                {
                    AntiHCV.SetText(HT_txtAntiHCV.Text);
                }

                var GioiTinh = doc.Bookmarks["GioiTinh"];
                if (GioiTinh != null)
                {
                    GioiTinh.SetText("Nam");
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HT_rtbGhiChuKQXN.Text);
                }

                var SoLanKiemTra = doc.Bookmarks["SoLanKiemTra"];
                if (SoLanKiemTra != null)
                {
                    SoLanKiemTra.SetText(HT_txtSoLanKiemTraKQXN.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HT_dtNgayTaoKQXN.Value.ToString("dd-MM-yyyy"));
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HT_btnXuatTinhDichDo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DocX g_document = DocX.Load(@"ket_qua_tinh_dich_do.docx");
            //    DocX doc = CreateReportCommon(g_document);

            //    var MatDo = doc.Bookmarks["MatDo"];
            //    if (MatDo != null)
            //    {
            //        MatDo.SetText(HT_txtMatDo.Text);
            //    }

            //    var DiDong = doc.Bookmarks["DiDong"];
            //    if (DiDong != null)
            //    {
            //        DiDong.SetText(HT_txtDiDong.Text);
            //    }

            //    var HinhDang = doc.Bookmarks["HinhDang"];
            //    if (HinhDang != null)
            //    {
            //        HinhDang.SetText(HT_txtHinhDang.Text);
            //    }

            //    var Cfs = doc.Bookmarks["Cfs"];
            //    if (Cfs != null)
            //    {
            //        Cfs.SetText(HT_txtCFS.Text);
            //    }

            //    var Hbcg = doc.Bookmarks["Hbcg"];
            //    if (Hbcg != null)
            //    {
            //        Hbcg.SetText(HT_txtHbcg.Text);
            //    }

            //    var GhiChu = doc.Bookmarks["GhiChu"];
            //    if (GhiChu != null)
            //    {
            //        GhiChu.SetText(HT_rtbGhiChuTTD.Text);
            //    }

            //    var SoLanKiemTra = doc.Bookmarks["SoLanKiemTra"];
            //    if (SoLanKiemTra != null)
            //    {
            //        SoLanKiemTra.SetText(HT_txtSoLanKiemTra.Text);
            //    }

            //    var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
            //    if (NgayXetNghiem != null)
            //    {
            //        NgayXetNghiem.SetText(HT_dtNgayTaoTDD.Value.ToString("dd-MM-yyyy"));
            //    }

            //    SaveFile(doc);
            //}
            //catch
            //{
            //    MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void HT_btnXuatDacTrung_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"dac_trung_nguoi_hien_tinh.docx");
                DocX doc = CreateReportCommon(g_document);

                var ChieuCao = doc.Bookmarks["ChieuCao"];
                if (ChieuCao != null)
                {
                    ChieuCao.SetText(HT_txtChieuCao.Text);
                }

                var CanNang = doc.Bookmarks["CanNang"];
                if (CanNang != null)
                {
                    CanNang.SetText(HT_txtCanNang.Text);
                }

                var MauMat = doc.Bookmarks["MauMat"];
                if (MauMat != null)
                {
                    MauMat.SetText(HT_txtMauMat.Text);
                }

                var MauToc = doc.Bookmarks["MauToc"];
                if (MauToc != null)
                {
                    MauToc.SetText(HT_txtMauToc.Text);
                }

                var KieuToc = doc.Bookmarks["KieuToc"];
                if (KieuToc != null)
                {
                    KieuToc.SetText(HT_txtKieuToc.Text);
                }

                var MauDa = doc.Bookmarks["MauDa"];
                if (MauDa != null)
                {
                    MauDa.SetText(HT_txtMauDa.Text);
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HT_rtbGhiChuDT.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HT_dtNgayTaoDT.Value.ToString("dd-MM-yyyy"));
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HT_btnXuatKNK_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_kham_nam_khoa.docx");
                DocX doc = CreateReportCommon(g_document);

                var TinhTrungTrai = doc.Bookmarks["TinhTrungTrai"];
                if (TinhTrungTrai != null)
                {
                    TinhTrungTrai.SetText(HT_txtTTTrai.Text);
                }

                var TinhTrungPhai = doc.Bookmarks["TinhTrungPhai"];
                if (TinhTrungPhai != null)
                {
                    TinhTrungPhai.SetText(HT_txtTTPhai.Text);
                }

                var MaoTinh = doc.Bookmarks["MaoTinh"];
                if (MaoTinh != null)
                {
                    MaoTinh.SetText(HT_txtMaoTinh.Text);
                }

                var OngDanTinh = doc.Bookmarks["OngDanTinh"];
                if (OngDanTinh != null)
                {
                    OngDanTinh.SetText(HT_txtOngDanTinh.Text);
                }

                var Varicole = doc.Bookmarks["Varicole"];
                if (Varicole != null)
                {
                    Varicole.SetText(HT_txtVaricole.Text);
                }

                var DuongVat = doc.Bookmarks["DuongVat"];
                if (DuongVat != null)
                {
                    DuongVat.SetText(HT_txtDuongVat.Text);
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HT_rtbGhiChuKNK.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HT_dtNgayTaoKNK.Value.ToString("dd-MM-yyyy"));
                }

                var DacTinhSS = doc.Bookmarks["DacTinhSinhSan"];
                if (DacTinhSS != null)
                {
                    DacTinhSS.SetText(HT_txtDacTinhSS.Text);
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CheckDBServer_Click(object sender, EventArgs e)
        {
            app.SendMessageFPs(this, "HT");
        }

        public override byte[] GetBlobNgonCaiPhai()
        {
            byte[] rt = { };
            if (FPBlobNgonCaiPhai == null)
                return rt;

            return zkfp.Base64String2Blob(FPBlobNgonCaiPhai);
        }
        public override byte[] GetBlobNgonCaiTrai()
        {
            byte[] rt = { };
            if (FPBlobNgonCaiTrai == null)
                return rt;

            return zkfp.Base64String2Blob(FPBlobNgonCaiTrai);
        }
        public override byte[] GetBlobNgonTroPhai()
        {
            byte[] rt = { };
            if (FPBlobNgonTroPhai == null)
                return rt;

            return zkfp.Base64String2Blob(FPBlobNgonTroPhai);
        }
        public override byte[] GetBlobNgonTroTrai()
        {
            byte[] rt = { };
            if (FPBlobNgonTroTrai == null)
                return rt;

            return zkfp.Base64String2Blob(FPBlobNgonTroTrai);
        }

        public override void SetPatientCode(string code) { HT_lbMaBN.Text = code; }
        public override void SetFullName(string fullName) { HT_txtHoVaTen.Text = fullName; }
        public override void SetPhoneNumber(string phoneNo) { HT_txtSoDienThoai.Text = phoneNo; }
        public override void SetItentity(string identity) { HT_txtSoCMND.Text = identity; }

        private void HT_btnApprove_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn phê duyệt hồ sơ bệnh nhân này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.OK)
            {
                dbBN.ApprovePatient(HT_lbMaBN.Text, true);
                HT_btnTaoHoSoMoi.Visible = false;
                HT_btnHuyHoSo.Visible = false;
                //HT_btnApprove.Visible = false;

                lblApprove.Visible = true;
            }
        }

        private void HT_TabLuuTruHoSo_Click(object sender, EventArgs e)
        {
            DisplayLuuTruHoSo();
        }

        private void DisplayLuuTruHoSo()
        {
            Dictionary<int, LoaiHoSo> hosos = dbBN.GetAllTenHoSo(true);

            GridPanel panel = HT_sgLuuTruHoSo.PrimaryGrid;
            panel.Rows.Clear();
            HT_sgLuuTruHoSo.BeginUpdate();
            foreach (var hs in hosos)
            {
                int num = SoHoSoBN(hs.Key);
                object[] ob1 = new object[]
                    {
                    hs.Key, hs.Value.TenHoSo, num, "Thêm mới"
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HT_sgLuuTruHoSo.EndUpdate();
        }

        private int SoHoSoBN(int fileId)
        {
            int num = 0;
            List<HoSoLuuTru> hosos = dbBN.GetHoSoLuuTru(HT_lbMaBN.Text);
            foreach (var hs in hosos)
            {
                if (hs.FileId == fileId)
                    num++;
            }

            return num;
        }

        private void HT_sgLuuTruHoSo_CellClick(object sender, GridCellClickEventArgs e)
        {
            if (!IsCreatedPatient())
                return;

            if (e.GridCell.GridRow["ID"].Value.ToString() != null)
            {
                if (e.GridCell.GridColumn.ColumnIndex == 3)
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string pathFile = dlg.FileName;
                        int fileID = (int)e.GridCell.GridRow["ID"].Value;

                        UploadFileToWebServer(pathFile);
                        if (!dbBN.AddNewFile(fileID, dlg.SafeFileName, HT_lbMaBN.Text))
                        {
                            MessageBox.Show("File tải lên bị trùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DisplayLuuTruHoSo();
                        }
                    }
                }
            }
        }

        private void HT_cboQuanHuyen_MouseClick(object sender, MouseEventArgs e)
        {
            var value = HT_cboTinhThanh.SelectedValue;
            if (value == null)
                return;

            HT_cboQuanHuyen.DataSource = app.GetDMThanhPho(value.ToString());
        }

        private void HT_cboQuanHuyenNVD_MouseClick(object sender, MouseEventArgs e)
        {
            var value = HT_cboTinhThanhNVD.SelectedValue;
            if (value == null)
                return;

            HT_cboQuanHuyenNVD.DataSource = app.GetDMThanhPho(value.ToString());
        }
    }
}
