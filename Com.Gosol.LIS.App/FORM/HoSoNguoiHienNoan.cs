using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BVPS.App;
using BVPS.Model;
using BVPS.DB;
using libzkfpcsharp;
using System.Drawing.Imaging;
using System.Threading;
using DevComponents.DotNetBar.SuperGrid;
using BVPS.Model.HoSoNguoiHienNoan;
using BVPS.Model.ChiMuc;
using Xceed.Words.NET;
using System.Text.RegularExpressions;

namespace Com.Gosol.LIS.App.FORM
{
    public partial class HoSoNguoiHienNoan : UserControlBN
    {
        HN_ThongTinNguoiHienNoan bn;
        BenhNhanHienNoanDB dbBN;

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);

                        if (HN_rbNgonCaiPhai.Checked)
                        {
                            base64ImageStringNgonCaiPhai = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                            zkfp.Blob2Base64String(CapTmp, cbCapTmp, ref FPBlobNgonCaiPhai);
                            this.HN_picNgonCaiPhai.Image = bmp;
                        }
                        else if (HN_rbNgonCaiTrai.Checked)
                        {
                            base64ImageStringNgonCaiTrai = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                            zkfp.Blob2Base64String(CapTmp, cbCapTmp, ref FPBlobNgonCaiTrai);
                            this.HN_picNgonCaiTrai.Image = bmp;
                        }
                        else if (HN_rbNgonTroPhai.Checked)
                        {
                            base64ImageStringNgonTroPhai = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                            zkfp.Blob2Base64String(CapTmp, cbCapTmp, ref FPBlobNgonTroPhai);
                            this.HN_picNgonTroPhai.Image = bmp;
                        }
                        else if (HN_rbNgonTroTrai.Checked)
                        {
                            base64ImageStringNgonTroTrai = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                            zkfp.Blob2Base64String(CapTmp, cbCapTmp, ref FPBlobNgonTroTrai);
                            this.HN_picNgonTroTrai.Image = bmp;
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

        public HoSoNguoiHienNoan(HN_ThongTinNguoiHienNoan bnhn, AppsLIST app) : base(app)
        {
            InitializeComponent();

            dbBN = new BenhNhanHienNoanDB(app.connString);

            HN_dtNgayTao.Value = DateTime.Now;
            this.bn = bnhn;
            IsHoSoDaDuocTao = true;

            if (bnhn.FlagApprove)
            {
                HN_btnTaoHoSoBN.Visible = false;
                HN_btnHuyBo.Visible = false;
                //HN_btnApprove.Visible = false;

                lblApprove.Visible = true;
            }

            LoadChiMuc();
            CheckPermissionViewBegin();
            FillDataToForm();

            HN_btnTaoHoSoBN.Text = "SỬA HỒ SƠ";
        }

        public HoSoNguoiHienNoan(AppsLIST app) : base(app)
        {
            InitializeComponent();

            dbBN = new BenhNhanHienNoanDB(app.connString);

            HN_dtNgayTao.Value = DateTime.Now;
            IsHoSoDaDuocTao = false;

            LoadChiMuc();
            CheckPermissionViewBegin();

            HN_lbMaBN.Text = Utilities.GenMaUnixTime(app.GetTrungTamHTSS().MaTTHTSS);
        }

        private void CheckPermissionViewBegin()
        {
            if (!app.CheckPermissionView(Utilities.FUN_BNHN_BenhTinhDuc))
                HN_TabBenhTinhDuc.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHN_BenhToanThan))
                HN_TabBenhToanThan.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHN_KetQuaXetNghiem))
                HN_TabKQXN.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHN_KhamBenh))
                HN_TabKhamHongXuongChau.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHN_NguoiVanDong))
                HN_TabNVD.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHN_TienSuSinhSan))
                HN_TabTienSuSinhSan.Visible = false;
            if (!app.CheckPermissionView(Utilities.FUN_BNHN_TieuSuKinhNguyet))
                HN_TabTieuSuKinhNguyet.Visible = false;
        }

        private void LoadChiMuc()
        {
            HN_cboTinhThanh.DataSource = app.GetDMTinhThanh();
            HN_cboTinhThanhNVD.DataSource = app.GetDMTinhThanh();

            HN_cboQuanHuyen.DataSource = app.GetDMAllThanhPho();
            HN_cboQuanHuyenNVD.DataSource = app.GetDMAllThanhPho();

            HN_cboDanToc.DataSource = app.GetDMDanToc();
        }

        private void FillDataToForm()
        {
            HN_lbMaBN.Text = bn.MaBN;
            HN_txtHoVaTen.Text = bn.HoVaTen;
            HN_dtNgaySinh.Value = bn.NgaySinh;
            HN_txtSoDienThoai.Text = bn.SoDienThoai;
            HN_txtEmail.Text = bn.Email;
            HN_cboTinhThanh.SelectedValue = bn.Tinh_ThanhPho;
            HN_cboQuanHuyenNVD.SelectedValue = bn.Quan_Huyen;
            HN_cboDanToc.SelectedValue = bn.DanToc;
            HN_txtSoCMND.Text = bn.SoCMND;
            HN_dtNgayCap.Value = bn.NgayCap;
            HN_txtNguyenQuan.Text = bn.NguyenQuan;
            HN_txtDiaChiNoiCap.Text = bn.DiaChiNoiCap;
            HN_dtNgayTao.Value = bn.NgayTao;

            FPBlobNgonCaiPhai = bn.VT_CaiPhai;
            FPBlobNgonCaiTrai = bn.VT_CaiTrai;
            FPBlobNgonTroPhai = bn.VT_TroPhai;
            FPBlobNgonTroTrai = bn.VT_TroTrai;

            HN_picNgonCaiPhai.Image = Utilities.Base64StringToBitmap(bn.VT_CaiPhai_HinhAnh);
            HN_picNgonCaiTrai.Image = Utilities.Base64StringToBitmap(bn.VT_CaiTrai_HinhAnh);
            HN_picNgonTroPhai.Image = Utilities.Base64StringToBitmap(bn.VT_TroPhai_HinhAnh);
            HN_picNgonTroTrai.Image = Utilities.Base64StringToBitmap(bn.VT_TroTrai_HinhAnh);
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


        private int GetIDItemTienSuSinhSan()
        {
            int rowIndex = HN_sgTienSuSS.ActiveRow.RowIndex;
            GridCell gridCell = HN_sgTienSuSS.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDItemKetQuaXN()
        {
            int rowIndex = HN_sgKQXN.ActiveRow.RowIndex;
            GridCell gridCell = HN_sgKQXN.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDItemTieuSuKN()
        {
            int rowIndex = HN_sgTieuSuKinhNguyet.ActiveRow.RowIndex;
            GridCell gridCell = HN_sgTieuSuKinhNguyet.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDItemKhamHongXuongChau()
        {
            int rowIndex = HN_sgKhamHongXuongChau.ActiveRow.RowIndex;
            GridCell gridCell = HN_sgKhamHongXuongChau.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDItemNVD()
        {
            int rowIndex = HN_sgNguoiVanDong.ActiveRow.RowIndex;
            GridCell gridCell = HN_sgNguoiVanDong.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDBenhToanThan()
        {
            int rowIndex = HN_sgBenhToanThan.ActiveRow.RowIndex;
            GridCell gridCell = HN_sgBenhToanThan.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDBenhTinhDuc()
        {
            int rowIndex = HN_sgBenhTinhDuc.ActiveRow.RowIndex;
            GridCell gridCell = HN_sgBenhTinhDuc.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private int GetIDHoiBenh()
        {
            int rowIndex = HN_sgHoiBenh.ActiveRow.RowIndex;
            GridCell gridCell = HN_sgHoiBenh.GetCell(rowIndex, 0);
            if (gridCell == null)
                return -1;

            return (int)gridCell.Value;
        }

        private void HoSoNguoiHienNoan_Load(object sender, EventArgs e)
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

        int IdTienSuSS = 0;
        int IdKetQuaXN = 0;
        int IdTieuSuKN = 0;
        int IdKhamBenh = 0;
        int IdNguoiVanDong = 0;
        int IdBenhToanThan = 0;
        int IdBenhTinhDuc = 0;
        int IdHoiBenh = 0;

        bool CheckPatientApprove()
        {
            if (dbBN.CheckPatientApprove(HN_lbMaBN.Text))
            {
                MessageBox.Show("Bệnh nhân đã được phê duyệt nên không thay đổi được hồ sơ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void HN_btnTMTSSS_Click(object sender, EventArgs e)
        {
            IdTienSuSS = 0;
            HN_txtSoLanCoThai.ResetText();
            HN_txtSoLuongDeConSong.ResetText();
            HN_txtNaoHut.ResetText();
            HN_txtThaiLuu.ResetText();
            HN_txtChuaNgoaiDaCon.ResetText();
            HN_txtChuaTrung.ResetText();
            HN_rtbGhiChuTSSS.Clear();
            HN_dtNgayTaoTTSS.ResetText();
        }

        private void HN_btnLuuTSSS_Click(object sender, EventArgs e)
        {
            if (HN_txtSoLanCoThai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HN_TienSuSinhSan tsss = new HN_TienSuSinhSan(HN_lbMaBN.Text);
            tsss.SoLanCoThai = Convert.ToInt32(HN_txtSoLanCoThai.Text);
            tsss.SoLuongDeConSong = Convert.ToInt32(HN_txtSoLuongDeConSong.Text);
            tsss.NaoHut = Convert.ToInt32(HN_txtNaoHut.Text);
            tsss.ThaiLuu = Convert.ToInt32(HN_txtThaiLuu.Text);
            tsss.ChuaNgoaiDaCon = Convert.ToInt32(HN_txtChuaNgoaiDaCon.Text);
            tsss.ChuaTrung = HN_txtChuaTrung.Text;
            tsss.GhiChu = HN_rtbGhiChuTSSS.Text;
            tsss.NgayTao = DateTime.Now; //HN_dtNgayTaoTTSS.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HN_sgTienSuSS.PrimaryGrid;
            if (IdTienSuSS == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHN_TienSuSinhSan))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ tiền sử sinh sản");

                int id = dbBN.AddTienSuSinhSan(tsss);
                HN_sgTienSuSS.BeginUpdate();
                object[] ob1 = new object[]
                        {
                    id, tsss.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HN_sgTienSuSS.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHN_TienSuSinhSan))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ tiền sử sinh sản ID = " + IdTienSuSS.ToString());

                dbBN.EditTienSuSinhSan(IdTienSuSS, tsss);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdTienSuSS)
                    {
                        r[1].Value = tsss.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HN_btnTMKQXN_Click(object sender, EventArgs e)
        {
            IdKetQuaXN = 0;
            HN_txtNhomMau.Clear();
            HN_txtHIV.Clear();
            HN_txtBW.Clear();
            HN_txtHBsAg.Clear();
            HN_txtAntiHCV.Clear();
            HN_txtSoLanKiemTra.ResetText();
            HN_rtbGhiChuKQXN.Clear();
            HN_dtNgayTaoKQXN.ResetText();
        }

        private void HN_btnLuuKQXN_Click(object sender, EventArgs e)
        {
            if (HN_txtNhomMau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HN_KetQuaXetNghiem kqxn = new HN_KetQuaXetNghiem(HN_lbMaBN.Text);
            kqxn.NhomMau = HN_txtNhomMau.Text;
            kqxn.HIV = HN_txtHIV.Text;
            kqxn.BW = HN_txtBW.Text;
            kqxn.HBsAg = HN_txtHBsAg.Text;
            kqxn.AntiHCV = HN_txtAntiHCV.Text;
            kqxn.SoLanKiemTra = Convert.ToInt32(HN_txtSoLanKiemTra.Text);
            kqxn.GhiChu = HN_rtbGhiChuKQXN.Text;
            kqxn.NgayTao = HN_dtNgayTaoKQXN.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HN_sgKQXN.PrimaryGrid;
            if (IdKetQuaXN == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHN_KetQuaXetNghiem))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ kết quả xét nghiệm");

                int id = dbBN.AddXetNghiem(kqxn);
                HN_sgKQXN.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, kqxn.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HN_sgKQXN.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHN_KetQuaXetNghiem))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ kết quả xét nghiệm ID = " + IdKetQuaXN.ToString());

                dbBN.EditXetNghiem(IdKetQuaXN, kqxn);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdKetQuaXN)
                    {
                        r[1].Value = kqxn.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HN_btnTMTieuSuKN_Click(object sender, EventArgs e)
        {
            IdTieuSuKN = 0;
            HN_txtTuoiCoKinhLanDau.ResetText();
            HN_txtChuKyKinh.ResetText();
            HN_txtSoNgayCoKinh.ResetText();
            HN_txtSoLuong.Clear();
            HN_rtbGhiChuTSKN.Clear();
            HN_dtNgayTaoTSKN.ResetText();
        }

        private void HN_btnLuuTieuSuKN_Click(object sender, EventArgs e)
        {
            if (HN_txtTuoiCoKinhLanDau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HN_TieuSuKinhNguyet tskn = new HN_TieuSuKinhNguyet(HN_lbMaBN.Text);
            tskn.TuoiCoKinhLanDau = Convert.ToInt32(HN_txtTuoiCoKinhLanDau.Text);
            tskn.ChuKyKinh = Convert.ToInt32(HN_txtChuKyKinh.Text);
            tskn.SoNgayCoKinh = Convert.ToInt32(HN_txtSoNgayCoKinh.Text);
            tskn.SoLuong = HN_txtSoLuong.Text;
            tskn.GhiChu = HN_rtbGhiChuTSKN.Text;
            tskn.NgayTao = HN_dtNgayTao.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HN_sgTieuSuKinhNguyet.PrimaryGrid;

            if (IdTieuSuKN == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHN_TieuSuKinhNguyet))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ tiểu sử kinh nguyệt");

                int id = dbBN.AddKinhNguyet(tskn);
                HN_sgTieuSuKinhNguyet.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, tskn.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HN_sgTieuSuKinhNguyet.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHN_TieuSuKinhNguyet))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ tiểu sử kinh nguyệt ID = " + IdTieuSuKN.ToString());

                dbBN.EditKinhNguyet(IdTieuSuKN, tskn);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdTieuSuKN)
                    {
                        r[1].Value = tskn.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HN_btnTMKhamCH_Click(object sender, EventArgs e)
        {
            IdKhamBenh = 0;
            HN_txtChieuCao.Clear();
            HN_txtCanNang.Clear();
            HN_txtHuyetAp.Clear();
            HN_txtMach.Clear();
            HN_txtNhietDo.Clear();
            HN_txtSinhDucNgoai.Clear();
            HN_txtAmHo.Clear();
            HN_txtAmDao.Clear();
            HN_txtViemLoTuyenCoTuCung.Clear();
            HN_txtSuiCoTuCung.Clear();
            HN_txtPolypCoTuCung.Clear();
            HN_txtHaiCTCCoTuCung.Clear();
            HN_txtCoTuCungBT.Clear();
            HN_txtTuTheTuCung.Clear();
            HN_txtTheTichTuCung.Clear();
            HN_txtMatDoTuCung.Clear();
            HN_txtDiDongTuCung.Clear();
            HN_txtHaiPhanPhu.Clear();
            HN_rtbGhiChuHongVaXuongChau.Clear();
            HN_dtNgayTaoHongVaXuongChau.ResetText();
        }

        private void HN_btnLuuCH_Click(object sender, EventArgs e)
        {
            HN_KhamBenh ch = new HN_KhamBenh(HN_lbMaBN.Text);
            ch.Height = HN_txtChieuCao.Text;
            ch.Weight = HN_txtCanNang.Text;
            ch.HuyetAp = HN_txtHuyetAp.Text;
            ch.Mach = HN_txtMach.Text;
            ch.NhietDo = HN_txtNhietDo.Text;
            ch.SinhDucNgoai = HN_txtSinhDucNgoai.Text;
            ch.AmHo = HN_txtAmHo.Text;
            ch.AmDao = HN_txtAmDao.Text;
            ch.ViemLoTuyenCoTuCung = HN_txtViemLoTuyenCoTuCung.Text;
            ch.SuiCoTuCung = HN_txtSuiCoTuCung.Text;
            ch.PolypCoTuCung = HN_txtPolypCoTuCung.Text;
            ch.HaiCTCCoTuCung = HN_txtHaiCTCCoTuCung.Text;
            ch.CoTuCungBinhThuong = HN_txtCoTuCungBT.Text;
            ch.TuTheTuCung = HN_txtTuTheTuCung.Text;
            ch.TheTichTuCung = HN_txtTheTichTuCung.Text;
            ch.MatDoTuCung = HN_txtMatDoTuCung.Text;
            ch.DiDongTuCung = HN_txtDiDongTuCung.Text;
            ch.HaiPhanPhu = HN_txtHaiPhanPhu.Text;
            ch.GhiChu = HN_rtbGhiChuHongVaXuongChau.Text;
            ch.NgayTao = HN_dtNgayTaoHongVaXuongChau.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HN_sgKhamHongXuongChau.PrimaryGrid;
            if (IdKhamBenh == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHN_KhamBenh))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ khám bệnh");

                int id = dbBN.AddChauHong(ch);
                HN_sgKhamHongXuongChau.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, ch.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HN_sgKhamHongXuongChau.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHN_KhamBenh))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ khám bệnh ID = " + IdKhamBenh.ToString());

                dbBN.EditChauHong(IdKhamBenh, ch);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdKhamBenh)
                    {
                        r[1].Value = ch.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HN_btnTMNVD_Click(object sender, EventArgs e)
        {
            IdNguoiVanDong = 0;
            HN_txtHoTenNVD.Clear();
            HN_txtEmailNVD.Clear();
            HN_txtSoDienThoaiNVD.Clear();
            HN_txtSoCMNDNVD.Clear();
            HN_dtNgayCapNVD.ResetText();
            HN_txtNguyenQuanNVD.Clear();
            HN_txtDiaChiNoiCapNVD.Clear();
            HN_cboTinhThanhNVD.TabIndex = 0;
            HN_cboQuanHuyenNVD.TabIndex = 0;
            HN_txtQuanHeVoiNH.Clear();
            HN_rtbGhiChuNVD.Clear();
            HN_dtNgayTaoNVD.ResetText();
        }

        private void HN_btnLuuNVD_Click(object sender, EventArgs e)
        {
            if (HN_txtHoTenNVD.Text == "" | HN_txtSoCMNDNVD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex phoneNumpattern = new Regex(@"^-*[0-9,\.?\-?\(?\)?\ ]+$");
            if (!phoneNumpattern.IsMatch(HN_txtSoDienThoaiNVD.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HN_NguoiVanDong nvd = new HN_NguoiVanDong(HN_lbMaBN.Text);
            nvd.HoVaTen = HN_txtHoTenNVD.Text;
            nvd.Email = HN_txtEmailNVD.Text;
            nvd.SoDienThoai = HN_txtSoDienThoaiNVD.Text;
            nvd.SoCMND = HN_txtSoCMNDNVD.Text;
            nvd.NgayCap = HN_dtNgayCapNVD.Value;
            nvd.NguyenQuan = HN_txtNguyenQuanNVD.Text;
            nvd.DiaChiNoiCap = HN_txtDiaChiNoiCapNVD.Text;
            nvd.Tinh_ThanhPho = HN_cboTinhThanhNVD.SelectedValue.ToString();
            nvd.Quan_Huyen = HN_cboQuanHuyenNVD.SelectedValue.ToString();
            nvd.QuanHeVoiNguoiHien = HN_txtQuanHeVoiNH.Text;
            nvd.GhiChu = HN_rtbGhiChuNVD.Text;
            nvd.NgayTao = HN_dtNgayTaoNVD.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HN_sgNguoiVanDong.PrimaryGrid;

            if (IdNguoiVanDong == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHN_NguoiVanDong))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ người vận động hiến noãn");

                int id = dbBN.AddNguoiVanDong(nvd);
                HN_sgNguoiVanDong.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, nvd.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HN_sgNguoiVanDong.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHN_NguoiVanDong))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ người vận động hiến noãn ID = " + IdNguoiVanDong.ToString());

                dbBN.EditNguoiVanDong(IdNguoiVanDong, nvd);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdNguoiVanDong)
                    {
                        r[1].Value = nvd.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HN_btnTMBenhToanThan_Click(object sender, EventArgs e)
        {
            IdBenhToanThan = 0;
            HN_txtTieuDuong.Clear();
            HN_txtLao.Clear();
            HN_txtBenhKhac.Clear();
            HN_txtDieuTriNoiKhoa.Clear();
            HN_txtTienSuPhauThuat.Clear();
            HN_txtNhiemTrungTietNieu.Clear();
            HN_rtbGhiChuBTT.Clear();
            HN_dtNgayTaoBTT.ResetText();
        }

        private void HN_btnLuuBenhToanThan_Click(object sender, EventArgs e)
        {
            HN_BenhToanThan btt = new HN_BenhToanThan(HN_lbMaBN.Text);
            btt.TieuDuong = HN_txtTieuDuong.Text;
            btt.Lao = HN_txtLao.Text;
            btt.BenhKhac = HN_txtBenhKhac.Text;
            btt.DieuTriNoiKhoa = HN_txtDieuTriNoiKhoa.Text;
            btt.TienSuPhauThuat = HN_txtTienSuPhauThuat.Text;
            btt.NhiemTrungTietLieu = HN_txtNhiemTrungTietNieu.Text;
            btt.GhiChu = HN_rtbGhiChuBTT.Text;
            btt.NgayTao = HN_dtNgayTaoBTT.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HN_sgBenhToanThan.PrimaryGrid;
            if (IdBenhToanThan == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHN_BenhToanThan))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ bệnh toàn thân");

                int id = dbBN.AddBenhToanThan(btt);
                HN_sgBenhToanThan.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, btt.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HN_sgBenhToanThan.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHN_BenhToanThan))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ bệnh toàn thân ID = " + IdBenhToanThan.ToString());

                dbBN.EditBenhToanThan(IdBenhToanThan, btt);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdBenhToanThan)
                    {
                        r[1].Value = btt.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HN_btnTMBenhTD_Click(object sender, EventArgs e)
        {
            IdBenhTinhDuc = 0;
            HN_txtLauBTD.Clear();
            HN_txtGiangMaiBTD.Clear();
            HN_txtChlamdiaBTD.Clear();
            HN_txtBenhKhac.Clear();
            HN_rtbGhiChuBTD.Clear();
            HN_dtNgayTaoBTD.ResetText();
        }

        private void HN_btnLuuBenhTD_Click(object sender, EventArgs e)
        {
            HN_BenhTinhDuc btd = new HN_BenhTinhDuc(HN_lbMaBN.Text);
            btd.Lau = HN_txtLauBTD.Text;
            btd.GiangMai = HN_txtGiangMaiBTD.Text;
            btd.Chlamydia = HN_txtChlamdiaBTD.Text;
            btd.BenhKhac = HN_txtBenhKhacBTD.Text;
            btd.GhiChu = HN_rtbGhiChuBTD.Text;
            btd.NgayTao = DateTime.Now; //HN_dtNgayTaoBTD.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HN_sgBenhTinhDuc.PrimaryGrid;

            if (IdBenhTinhDuc == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHN_BenhTinhDuc))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ bệnh tình dục");

                int id = dbBN.AddBenhTinhDuc(btd);
                HN_sgBenhTinhDuc.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, btd.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HN_sgBenhTinhDuc.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHN_BenhTinhDuc))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ bệnh tình dục ID = " + IdBenhTinhDuc.ToString());

                dbBN.EditBenhTinhDuc(IdBenhTinhDuc, btd);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdBenhTinhDuc)
                    {
                        r[1].Value = btd.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void HN_btnTMHoiBenh_Click(object sender, EventArgs e)
        {
            HN_rtbTSNKChiTiet.Clear();
            HN_rtbTSNGKChiTiet.Clear();
        }

        private void HN_btnLuuHoiBenh_Click(object sender, EventArgs e)
        {
            HN_HoiBenh hb = new HN_HoiBenh(HN_lbMaBN.Text);
            hb.HaveData_TienSuNoiKhoa = HN_rbTSNKCo.Checked;
            hb.DetailData_TienSuNoiKhoa = HN_rtbTSNKChiTiet.Text;
            hb.HaveData_TienSuNgoaiKhoa = HN_rbTSNGKCo.Checked;
            hb.DetailData_TienSuNgoaiKhoa = HN_rtbTSNGKChiTiet.Text;
            hb.NgayTao = DateTime.Now; //HN_dtNgayTaoBTD.Value;

            if (!IsCreatedPatient())
                return;

            GridPanel panel = HN_sgHoiBenh.PrimaryGrid;

            if (IdHoiBenh == 0)
            {
                if (!CheckPermissionAdd(Utilities.FUN_BNHN_HoiBenh))
                    return;

                app.SetHisOperate("Người dùng thêm mới hồ sơ hỏi bệnh");

                int id = dbBN.AddHoiBenh(hb);
                HN_sgHoiBenh.BeginUpdate();

                object[] ob1 = new object[]
                        {
                    id, hb.NgayTao.ToString("dd-MM-yyyy")
                        };

                panel.Rows.Add(new GridRow(ob1));
                HN_sgHoiBenh.EndUpdate();

                MessageSaveSuccess();
            }
            else
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionEdit(Utilities.FUN_BNHN_HoiBenh))
                    return;

                app.SetHisOperate("Người dùng sửa hồ sơ hỏi bệnh ID = " + IdHoiBenh.ToString());

                dbBN.EditHoiBenh(IdHoiBenh, hb);
                var IRows = panel.Rows.GetEnumerator();
                while (IRows.MoveNext())
                {
                    GridRow r = (GridRow)IRows.Current;
                    if ((int)r[0].Value == IdHoiBenh)
                    {
                        r[1].Value = hb.NgayTao.ToString("dd-MM-yyyy");
                    }
                }

                MessageSaveSuccess();
            }
        }

        private void XemChiTiet_Click(object sender, EventArgs e)
        {
            if (HN_superTab.SelectedTab.Text == "TIỀN SỬ SINH SẢN")
            {
                int id = GetIDItemTienSuSinhSan();
                if (id != -1)
                {
                    IdTienSuSS = id;
                    HN_TienSuSinhSan tsss = dbBN.GetTienSuSinhSanByID(id);
                    HN_txtSoLanCoThai.Text = tsss.SoLanCoThai.ToString();
                    HN_txtSoLuongDeConSong.Text = tsss.SoLuongDeConSong.ToString();
                    HN_txtNaoHut.Text = tsss.NaoHut.ToString();
                    HN_txtThaiLuu.Text = tsss.ThaiLuu.ToString();
                    HN_txtChuaNgoaiDaCon.Text = tsss.ChuaNgoaiDaCon.ToString();
                    HN_txtChuaTrung.Text = tsss.ChuaTrung;
                    HN_rtbGhiChuTSSS.Text = tsss.GhiChu;
                    HN_dtNgayTaoTTSS.Value = tsss.NgayTao;
                }
            }
            else if (HN_superTab.SelectedTab.Text == "KẾT QUẢ XÉT NGHIỆM")
            {
                int id = GetIDItemKetQuaXN();
                if (id != -1)
                {
                    IdKetQuaXN = id;
                    HN_KetQuaXetNghiem kqxn = dbBN.GetXetNghiemByID(id);
                    HN_txtNhomMau.Text = kqxn.NhomMau;
                    HN_txtHIV.Text = kqxn.HIV;
                    HN_txtBW.Text = kqxn.BW;
                    HN_txtHBsAg.Text = kqxn.HBsAg;
                    HN_txtAntiHCV.Text = kqxn.AntiHCV;
                    HN_txtSoLanKiemTra.Text = kqxn.SoLanKiemTra.ToString();
                    HN_rtbGhiChuKQXN.Text = kqxn.GhiChu;
                    HN_dtNgayTaoKQXN.Value = kqxn.NgayTao;
                }
            }
            else if (HN_superTab.SelectedTab.Text == "TIỂU SỬ KINH NGUYỆT")
            {
                int id = GetIDItemTieuSuKN();
                if (id != -1)
                {
                    IdTieuSuKN = id;
                    HN_TieuSuKinhNguyet tskn = dbBN.GetKinhNguyetByID(id);
                    HN_txtTuoiCoKinhLanDau.Text = tskn.TuoiCoKinhLanDau.ToString();
                    HN_txtChuKyKinh.Text = tskn.ChuKyKinh.ToString();
                    HN_txtSoNgayCoKinh.Text = tskn.SoNgayCoKinh.ToString();
                    HN_txtSoLuong.Text = tskn.SoLuong;
                    HN_rtbGhiChuTSKN.Text = tskn.GhiChu;
                    HN_dtNgayTaoTSKN.Value = tskn.NgayTao;
                }
            }
            else if (HN_superTab.SelectedTab.Text == "KHÁM BỆNH")
            {
                int id = GetIDItemKhamHongXuongChau();
                if (id != -1)
                {
                    IdKhamBenh = id;
                    HN_KhamBenh ch = dbBN.GetChauHongByID(id);
                    HN_txtChieuCao.Text = ch.Height;
                    HN_txtCanNang.Text = ch.Weight;
                    HN_txtHuyetAp.Text = ch.HuyetAp;
                    HN_txtMach.Text = ch.Mach;
                    HN_txtNhietDo.Text = ch.NhietDo;
                    HN_txtSinhDucNgoai.Text = ch.SinhDucNgoai;
                    HN_txtAmHo.Text = ch.AmHo;
                    HN_txtAmDao.Text = ch.AmDao;
                    HN_txtViemLoTuyenCoTuCung.Text = ch.ViemLoTuyenCoTuCung;
                    HN_txtSuiCoTuCung.Text = ch.SuiCoTuCung;
                    HN_txtPolypCoTuCung.Text = ch.PolypCoTuCung;
                    HN_txtHaiCTCCoTuCung.Text = ch.HaiCTCCoTuCung;
                    HN_txtCoTuCungBT.Text = ch.CoTuCungBinhThuong;
                    HN_txtTuTheTuCung.Text = ch.TuTheTuCung;
                    HN_txtTheTichTuCung.Text = ch.TheTichTuCung;
                    HN_txtMatDoTuCung.Text = ch.MatDoTuCung;
                    HN_txtDiDongTuCung.Text = ch.DiDongTuCung;
                    HN_txtHaiPhanPhu.Text = ch.HaiPhanPhu;
                    HN_rtbGhiChuHongVaXuongChau.Text = ch.GhiChu;
                    HN_dtNgayTaoHongVaXuongChau.Value = ch.NgayTao;
                }
            }
            else if (HN_superTab.SelectedTab.Text == "THÔNG TIN NGƯỜI VẬN ĐỘNG")
            {
                int id = GetIDItemNVD();
                if (id != -1)
                {
                    IdNguoiVanDong = id;
                    HN_NguoiVanDong nvd = dbBN.GetNguoiVanDongByID(id);
                    HN_txtHoTenNVD.Text = nvd.HoVaTen;
                    HN_txtEmailNVD.Text = nvd.Email;
                    HN_txtSoDienThoaiNVD.Text = nvd.SoDienThoai;
                    HN_txtSoCMNDNVD.Text = nvd.SoCMND;
                    HN_dtNgayCapNVD.Value = nvd.NgayCap;
                    HN_txtNguyenQuanNVD.Text = nvd.NguyenQuan;
                    HN_txtDiaChiNoiCapNVD.Text = nvd.DiaChiNoiCap;
                    HN_cboTinhThanhNVD.SelectedValue = nvd.Tinh_ThanhPho;
                    HN_cboQuanHuyenNVD.SelectedValue = nvd.Quan_Huyen;
                    HN_txtQuanHeVoiNH.Text = nvd.QuanHeVoiNguoiHien;
                    HN_rtbGhiChuNVD.Text = nvd.GhiChu;
                    HN_dtNgayTaoNVD.Value = nvd.NgayTao;
                }
            }
            else if (HN_superTab.SelectedTab.Text == "BỆNH TOÀN THÂN")
            {
                int id = GetIDBenhToanThan();
                if (id != -1)
                {
                    IdBenhToanThan = id;
                    HN_BenhToanThan btt = dbBN.GetBenhToanThanByID(id);
                    HN_txtTieuDuong.Text = btt.TieuDuong;
                    HN_txtLao.Text = btt.Lao;
                    HN_txtBenhKhac.Text = btt.BenhKhac;
                    HN_txtDieuTriNoiKhoa.Text = btt.DieuTriNoiKhoa;
                    HN_txtTienSuPhauThuat.Text = btt.TienSuPhauThuat;
                    HN_txtNhiemTrungTietNieu.Text = btt.NhiemTrungTietLieu;
                    HN_rtbGhiChuBTT.Text = btt.GhiChu;
                    HN_dtNgayTaoBTT.Value = btt.NgayTao;
                }
            }
            else if (HN_superTab.SelectedTab.Text == "BỆNH TÌNH DỤC")
            {
                int id = GetIDBenhTinhDuc();
                if (id != -1)
                {
                    IdBenhTinhDuc = id;
                    HN_BenhTinhDuc btd = dbBN.GetBenhTinhDucByID(id);
                    HN_txtLauBTD.Text = btd.Lau;
                    HN_txtGiangMaiBTD.Text = btd.GiangMai;
                    HN_txtChlamdiaBTD.Text = btd.Chlamydia;
                    HN_txtBenhKhacBTD.Text = btd.BenhKhac;
                    HN_rtbGhiChuBTD.Text = btd.GhiChu;
                    HN_dtNgayTaoBTD.Value = btd.NgayTao;
                }
            }
            else if (HN_superTab.SelectedTab.Text == "HỎI BỆNH")
            {
                int id = GetIDHoiBenh();
                if (id != -1)
                {
                    IdHoiBenh = id;
                    HN_HoiBenh hb = dbBN.GetHoiBenhByID(id);
                    if (hb.HaveData_TienSuNoiKhoa)
                        HN_rbTSNKCo.Checked = true;
                    else
                        HN_rbTSNKKhong.Checked = true;

                    if (hb.HaveData_TienSuNgoaiKhoa)
                        HN_rbTSNGKCo.Checked = true;
                    else
                        HN_rbTSNGKKhong.Checked = true;

                    HN_rtbTSNKChiTiet.Text = hb.DetailData_TienSuNoiKhoa;
                    HN_rtbTSNGKChiTiet.Text = hb.DetailData_TienSuNgoaiKhoa;
                }
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            GridPanel panel = new GridPanel();
            int id = -1;

            if (HN_superTab.SelectedTab.Text == "TIỀN SỬ SINH SẢN")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHN_TienSuSinhSan))
                    return;

                id = GetIDItemTienSuSinhSan();
                panel = HN_sgTienSuSS.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ tiền sử sinh sản ID = " + id.ToString());
                    dbBN.DeleteTienSuSinhSan(id);
                }
            }
            else if (HN_superTab.SelectedTab.Text == "KẾT QUẢ XÉT NGHIỆM")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHN_KetQuaXetNghiem))
                    return;

                id = GetIDItemKetQuaXN();
                panel = HN_sgKQXN.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ kết quả xét nghiệm BNHN ID = " + id.ToString());
                    dbBN.DeleteXetNghiem(id);
                }
            }
            else if (HN_superTab.SelectedTab.Text == "TIỂU SỬ KINH NGUYỆT")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHN_TieuSuKinhNguyet))
                    return;

                id = GetIDItemTieuSuKN();
                panel = HN_sgTieuSuKinhNguyet.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ tiểu sử kinh nguyệt ID = " + id.ToString());
                    dbBN.DeleteKinhNguyet(id);
                }
            }
            else if (HN_superTab.SelectedTab.Text == "KHÁM BỆNH")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHN_KhamBenh))
                    return;

                id = GetIDItemKhamHongXuongChau();
                panel = HN_sgKhamHongXuongChau.PrimaryGrid;
                if (id != -1)
                {
                    dbBN.DeleteChauHong(id);
                }
            }
            else if (HN_superTab.SelectedTab.Text == "THÔNG TIN NGƯỜI VẬN ĐỘNG")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHN_NguoiVanDong))
                    return;

                id = GetIDItemNVD();
                panel = HN_sgNguoiVanDong.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ người vận động hiến noãn ID = " + id.ToString());
                    dbBN.DeleteNguoiVanDong(id);
                }
            }
            else if (HN_superTab.SelectedTab.Text == "BỆNH TOÀN THÂN")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHN_BenhToanThan))
                    return;

                id = GetIDBenhToanThan();
                panel = HN_sgBenhToanThan.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ bệnh toàn thân ID = " + id.ToString());
                    dbBN.DeleteBenhToanThan(id);
                }
            }
            else if (HN_superTab.SelectedTab.Text == "BỆNH TÌNH DỤC")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHN_BenhTinhDuc))
                    return;

                id = GetIDBenhTinhDuc();
                panel = HN_sgBenhTinhDuc.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ bệnh tình dục ID = " + id.ToString());
                    dbBN.DeleteBenhTinhDuc(id);
                }
            }

            else if (HN_superTab.SelectedTab.Text == "HỎI BỆNH")
            {
                if (CheckPatientApprove())
                    return;

                if (!CheckPermissionDelete(Utilities.FUN_BNHN_HoiBenh))
                    return;

                id = GetIDHoiBenh();
                panel = HN_sgHoiBenh.PrimaryGrid;
                if (id != -1)
                {
                    app.SetHisOperate("Người dùng xóa hồ sơ hỏi bệnh ID = " + id.ToString());
                    dbBN.DeleteHoiBenh(id);
                }
            }

            if (id != -1)
            {
                panel.SetDeleted(panel.ActiveRow, true);
                MessageSaveSuccess();
            }
        }

        private void HN_btnTaoHoSoBN_Click(object sender, EventArgs e)
        {
            if (HN_txtHoVaTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ và tên bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (HN_dtNgaySinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (HN_txtSoCMND.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số CMND bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex phoneNumpattern = new Regex(@"^-*[0-9,\.?\-?\(?\)?\ ]+$");
            if (!phoneNumpattern.IsMatch(HN_txtSoDienThoai.Text))
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

                if (!CheckPermissionAdd(Utilities.FUN_HNHN_QuanLyThongTinChungBNHN))
                    return;

                HN_ThongTinNguoiHienNoan bn = new HN_ThongTinNguoiHienNoan(HN_lbMaBN.Text);
                bn.HoVaTen = HN_txtHoVaTen.Text;
                bn.NgaySinh = HN_dtNgaySinh.Value;
                bn.SoDienThoai = HN_txtSoDienThoai.Text;
                bn.Email = HN_txtEmail.Text;
                bn.Tinh_ThanhPho = HN_cboTinhThanh.SelectedValue.ToString();
                bn.Quan_Huyen = HN_cboQuanHuyen.SelectedValue.ToString();
                bn.QuocTichID = 84;
                bn.DanToc = Convert.ToInt32(HN_cboDanToc.SelectedValue);
                bn.SoCMND = HN_txtSoCMND.Text;
                bn.NgayCap = HN_dtNgayCap.Value;
                bn.NguyenQuan = HN_txtNguyenQuan.Text;
                bn.DiaChiNoiCap = HN_txtDiaChiNoiCap.Text;

                Bitmap bmp;
                if (HN_picNgonCaiPhai.Image != null)
                {
                    bmp = new Bitmap(HN_picNgonCaiPhai.Image);
                    bn.VT_CaiPhai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HN_picNgonCaiTrai.Image != null)
                {
                    bmp = new Bitmap(HN_picNgonCaiTrai.Image);
                    bn.VT_CaiTrai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HN_picNgonTroPhai.Image != null)
                {
                    bmp = new Bitmap(HN_picNgonTroPhai.Image);
                    bn.VT_TroPhai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HN_picNgonTroTrai.Image != null)
                {
                    bmp = new Bitmap(HN_picNgonTroTrai.Image);
                    bn.VT_TroTrai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                bn.MaTrungTamHTSS = app.GetTrungTamHTSS().MaTTHTSS;

                var checkCMND = dbBN.CheckDuplicateNoCMND(HN_txtSoCMND.Text);
                if (checkCMND != null)
                {
                    MessageBox.Show("Số chứng minh nhân dân " + HN_txtSoCMND.Text + " đã bị trùng với bệnh nhân " + checkCMND.HoVaTen, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    bn.NgayTao = HN_dtNgayTao.Value;

                    app.SetHisOperate("Tạo mới bộ hồ sơ bệnh nhân hiến noãn");

                    dbBN.AddNewPatient(bn);

                    IsHoSoDaDuocTao = true;
                    HN_btnTaoHoSoBN.Text = "SỬA HỒ SƠ";

                    MessageBox.Show("Đã tạo hồ sơ thành công trên hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HN_ThongTinNguoiHienNoan oldBN = dbBN.GetInformationPatient(maBN);
                    MessageBox.Show("Thông tin vân tay này đã bị trùng với bệnh nhân " + oldBN.HoVaTen + " với số CMND " + oldBN.SoCMND, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!CheckPermissionEdit(Utilities.FUN_HNHN_QuanLyThongTinChungBNHN))
                    return;

                HN_ThongTinNguoiHienNoan bn = new HN_ThongTinNguoiHienNoan(HN_lbMaBN.Text);
                bn.HoVaTen = HN_txtHoVaTen.Text;
                bn.NgaySinh = HN_dtNgaySinh.Value;
                bn.SoDienThoai = HN_txtSoDienThoai.Text;
                bn.Email = HN_txtEmail.Text;
                bn.Tinh_ThanhPho = HN_cboTinhThanh.SelectedValue.ToString();
                bn.Quan_Huyen = HN_cboQuanHuyen.SelectedValue.ToString();
                bn.QuocTichID = 84;
                bn.DanToc = Convert.ToInt32(HN_cboDanToc.SelectedValue);
                bn.SoCMND = HN_txtSoCMND.Text;
                bn.NgayCap = HN_dtNgayCap.Value;
                bn.NguyenQuan = HN_txtNguyenQuan.Text;
                bn.DiaChiNoiCap = HN_txtDiaChiNoiCap.Text;

                Bitmap bmp;
                if (HN_picNgonCaiPhai.Image != null)
                {
                    bmp = new Bitmap(HN_picNgonCaiPhai.Image);
                    bn.VT_CaiPhai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HN_picNgonCaiTrai.Image != null)
                {
                    bmp = new Bitmap(HN_picNgonCaiTrai.Image);
                    bn.VT_CaiTrai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HN_picNgonTroPhai.Image != null)
                {
                    bmp = new Bitmap(HN_picNgonTroPhai.Image);
                    bn.VT_TroPhai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                if (HN_picNgonTroPhai.Image != null)
                {
                    bmp = new Bitmap(HN_picNgonTroTrai.Image);
                    bn.VT_TroTrai_HinhAnh = Utilities.BitmapToBase64String(bmp, ImageFormat.Png);
                }

                bn.VT_CaiPhai = FPBlobNgonCaiPhai;
                bn.VT_CaiTrai = FPBlobNgonCaiTrai;
                bn.VT_TroPhai = FPBlobNgonTroPhai;
                bn.VT_TroTrai = FPBlobNgonTroTrai;

                bn.NgayTao = HN_dtNgayTao.Value;

                app.SetHisOperate("Sửa bộ hồ sơ bệnh nhân hiến noãn với mã bệnh nhân " + bn.MaBN);

                dbBN.EditInformationPatient(bn.MaBN, bn);

                MessageSaveSuccess();
            }
        }

        private void HN_btnHuyBo_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ chỉnh sửa trên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                app.ShowFormBegin();
            }
        }


        private void HN_TabTienSuSinhSan_Click(object sender, EventArgs e)
        {
            List<HN_TienSuSinhSan> tsss = dbBN.GetTienSuSinhSanByPatient(HN_lbMaBN.Text);
            GridPanel panel = HN_sgTienSuSS.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgTienSuSS.BeginUpdate();
            foreach (var bn in tsss)
            {
                object[] ob1 = new object[]
                    {
                    bn.Id, bn.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgTienSuSS.EndUpdate();

            HN_dtNgayTaoTTSS.Value = DateTime.Now;
        }

        private void HN_TabKQXN_Click(object sender, EventArgs e)
        {
            List<HN_KetQuaXetNghiem> kqxn = dbBN.GetXetNghiemPatient(HN_lbMaBN.Text);
            GridPanel panel = HN_sgKQXN.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgKQXN.BeginUpdate();
            foreach (var bn in kqxn)
            {
                object[] ob1 = new object[]
                    {
                    bn.Id, bn.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgKQXN.EndUpdate();

            HN_dtNgayTaoKQXN.Value = DateTime.Now;
        }

        private void HN_TabTieuSuKinhNguyet_Click(object sender, EventArgs e)
        {
            List<HN_TieuSuKinhNguyet> tskn = dbBN.GetKinhNguyetByPatient(HN_lbMaBN.Text);
            GridPanel panel = HN_sgTieuSuKinhNguyet.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgTieuSuKinhNguyet.BeginUpdate();
            foreach (var bn in tskn)
            {
                object[] ob1 = new object[]
                    {
                    bn.Id, bn.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgTieuSuKinhNguyet.EndUpdate();

            HN_dtNgayTaoTSKN.Value = DateTime.Now;
        }

        private void HN_TabKhamHongXuongChau_Click(object sender, EventArgs e)
        {
            List<HN_KhamBenh> tskn = dbBN.GetChauHongByPatient(HN_lbMaBN.Text);
            GridPanel panel = HN_sgKhamHongXuongChau.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgKhamHongXuongChau.BeginUpdate();
            foreach (var bn in tskn)
            {
                object[] ob1 = new object[]
                    {
                    bn.Id, bn.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgKhamHongXuongChau.EndUpdate();

            HN_dtNgayTaoHongVaXuongChau.Value = DateTime.Now;
        }

        private void HN_TabNVD_Click(object sender, EventArgs e)
        {
            List<HN_NguoiVanDong> nvd = dbBN.GetNguoivanDongPatient(HN_lbMaBN.Text);
            GridPanel panel = HN_sgNguoiVanDong.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgNguoiVanDong.BeginUpdate();
            foreach (var bn in nvd)
            {
                object[] ob1 = new object[]
                    {
                    bn.Id, bn.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgNguoiVanDong.EndUpdate();

            HN_dtNgayTaoNVD.Value = DateTime.Now;
        }

        private void HN_TabBenhToanThan_Click(object sender, EventArgs e)
        {
            List<HN_BenhToanThan> btt = dbBN.GetBenhToanThanByPatient(HN_lbMaBN.Text);
            GridPanel panel = HN_sgBenhToanThan.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgBenhToanThan.BeginUpdate();
            foreach (var bn in btt)
            {
                object[] ob1 = new object[]
                    {
                    bn.Id, bn.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgBenhToanThan.EndUpdate();

            HN_dtNgayTaoBTT.Value = DateTime.Now;
        }

        private void HN_TabBenhTinhDuc_Click(object sender, EventArgs e)
        {
            List<HN_BenhTinhDuc> btt = dbBN.GetBenhTinhDucByPatient(HN_lbMaBN.Text);
            GridPanel panel = HN_sgBenhTinhDuc.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgBenhTinhDuc.BeginUpdate();
            foreach (var bn in btt)
            {
                object[] ob1 = new object[]
                    {
                    bn.Id, bn.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgBenhTinhDuc.EndUpdate();

            HN_dtNgayTaoBTD.Value = DateTime.Now;
        }

        private void HN_tabHoiBenh_Click(object sender, EventArgs e)
        {
            List<HN_HoiBenh> btt = dbBN.GetHoiBenhPatient(HN_lbMaBN.Text);
            GridPanel panel = HN_sgHoiBenh.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgHoiBenh.BeginUpdate();
            foreach (var bn in btt)
            {
                object[] ob1 = new object[]
                    {
                    bn.Id, bn.NgayTao.ToString("dd-MM-yyyy")
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgHoiBenh.EndUpdate();
        }


        private void superTabItem1_Click(object sender, EventArgs e)
        {

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
                MaBNBookmark.SetText(HN_lbMaBN.Text);
            }

            var TenTTBookmark = temp.Bookmarks["TenBVPSTW"];
            if (TenTTBookmark != null)
            {
                TenTTBookmark.SetText(tt.TenTrungTam);
            }

            var TenBN = temp.Bookmarks["TenBN"];
            if (TenBN != null)
            {
                TenBN.SetText(HN_txtHoVaTen.Text);
            }

            var DiachiBN = temp.Bookmarks["DiachiBN"];
            if (DiachiBN != null)
            {
                DiachiBN.SetText(HN_txtNguyenQuan.Text);
            }

            var SoDienThoaiBN = temp.Bookmarks["SoDienThoaiBN"];
            if (SoDienThoaiBN != null)
            {
                SoDienThoaiBN.SetText(HN_txtSoDienThoai.Text);
            }

            return temp;
        }

        private void HN_btnXuatBenhTinhDuc_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_benh_tinh_duc.docx");
                DocX doc = CreateReportCommon(g_document);

                var Lau = doc.Bookmarks["Lau"];
                if (Lau != null)
                {
                    Lau.SetText(HN_txtLauBTD.Text);
                }

                var GiangMai = doc.Bookmarks["GiangMai"];
                if (GiangMai != null)
                {
                    GiangMai.SetText(HN_txtGiangMaiBTD.Text);
                }

                var Chlamydia = doc.Bookmarks["Chlamydia"];
                if (Chlamydia != null)
                {
                    Chlamydia.SetText(HN_txtChlamdiaBTD.Text);
                }

                var BenhKhac = doc.Bookmarks["BenhKhac"];
                if (BenhKhac != null)
                {
                    BenhKhac.SetText(HN_txtBenhKhacBTD.Text);
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HN_rtbGhiChuBTD.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HN_dtNgayTaoBTD.Value.ToString("dd-MM-yyyy"));
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HN_btnXuatBenhToanThan_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_benh_toan_than.docx");
                DocX doc = CreateReportCommon(g_document);

                var TieuDuong = doc.Bookmarks["TieuDuong"];
                if (TieuDuong != null)
                {
                    TieuDuong.SetText(HN_txtTieuDuong.Text);
                }

                var Lao = doc.Bookmarks["Lao"];
                if (Lao != null)
                {
                    Lao.SetText(HN_txtLao.Text);
                }

                var BenhKhac = doc.Bookmarks["BenhKhac"];
                if (BenhKhac != null)
                {
                    BenhKhac.SetText(HN_txtBenhKhac.Text);
                }

                var TienSuPhauThuat = doc.Bookmarks["TienSuPhauThuat"];
                if (TienSuPhauThuat != null)
                {
                    TienSuPhauThuat.SetText(HN_txtTienSuPhauThuat.Text);
                }

                var NhiemTrungTietNieu = doc.Bookmarks["NhiemTrungTietNieu"];
                if (NhiemTrungTietNieu != null)
                {
                    NhiemTrungTietNieu.SetText(HN_txtNhiemTrungTietNieu.Text);
                }

                var GhiChu = doc.Bookmarks["NhiemTrungTietNieu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HN_rtbGhiChuBTT.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HN_dtNgayTaoBTT.Value.ToString("dd-MM-yyyy"));
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HN_btnXuatChauHong_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_kham_chau_hong.docx");
                DocX doc = CreateReportCommon(g_document);

                var SinhDucNgoai = doc.Bookmarks["SinhDucNgoai"];
                if (SinhDucNgoai != null)
                {
                    SinhDucNgoai.SetText(HN_txtSinhDucNgoai.Text);
                }

                var AmHo = doc.Bookmarks["AmHo"];
                if (AmHo != null)
                {
                    AmHo.SetText(HN_txtAmHo.Text);
                }

                var AmDao = doc.Bookmarks["AmDao"];
                if (AmDao != null)
                {
                    AmDao.SetText(HN_txtAmDao.Text);
                }

                var ViemLoTuyenCoTuCung = doc.Bookmarks["ViemLoTuyenCoTuCung"];
                if (ViemLoTuyenCoTuCung != null)
                {
                    ViemLoTuyenCoTuCung.SetText(HN_txtViemLoTuyenCoTuCung.Text);
                }

                var SuiCoTuCung = doc.Bookmarks["SuiCoTuCung"];
                if (SuiCoTuCung != null)
                {
                    SuiCoTuCung.SetText(HN_txtSuiCoTuCung.Text);
                }

                var PolypCoTuCung = doc.Bookmarks["PolypCoTuCung"];
                if (PolypCoTuCung != null)
                {
                    PolypCoTuCung.SetText(HN_txtPolypCoTuCung.Text);
                }

                var HaiCTCCoTuCung = doc.Bookmarks["HaiCTCCoTuCung"];
                if (HaiCTCCoTuCung != null)
                {
                    HaiCTCCoTuCung.SetText(HN_txtHaiCTCCoTuCung.Text);
                }

                var CoTuCungBT = doc.Bookmarks["CoTuCungBT"];
                if (CoTuCungBT != null)
                {
                    CoTuCungBT.SetText(HN_txtCoTuCungBT.Text);
                }

                var TuTheTuCung = doc.Bookmarks["TuTheTuCung"];
                if (TuTheTuCung != null)
                {
                    TuTheTuCung.SetText(HN_txtTuTheTuCung.Text);
                }

                var TheTichTuCung = doc.Bookmarks["TheTichTuCung"];
                if (TheTichTuCung != null)
                {
                    TheTichTuCung.SetText(HN_txtTheTichTuCung.Text);
                }

                var MatDoTuCung = doc.Bookmarks["MatDoTuCung"];
                if (MatDoTuCung != null)
                {
                    MatDoTuCung.SetText(HN_txtMatDoTuCung.Text);
                }

                var DiDongTuCung = doc.Bookmarks["DiDongTuCung"];
                if (DiDongTuCung != null)
                {
                    DiDongTuCung.SetText(HN_txtDiDongTuCung.Text);
                }

                var HaiPhanPhu = doc.Bookmarks["HaiPhanPhu"];
                if (HaiPhanPhu != null)
                {
                    HaiPhanPhu.SetText(HN_txtHaiPhanPhu.Text);
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HN_rtbGhiChuHongVaXuongChau.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HN_dtNgayTaoHongVaXuongChau.Value.ToString("dd-MM-yyyy"));
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HN_btnXuatTieuSuKN_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_tieu_su_kinh_nguyet.docx");
                DocX doc = CreateReportCommon(g_document);

                var TuoiCoKinhLanDau = doc.Bookmarks["TuoiCoKinhLanDau"];
                if (TuoiCoKinhLanDau != null)
                {
                    TuoiCoKinhLanDau.SetText(HN_txtTuoiCoKinhLanDau.Text);
                }

                var ChuKyKinh = doc.Bookmarks["ChuKyKinh"];
                if (ChuKyKinh != null)
                {
                    ChuKyKinh.SetText(HN_txtChuKyKinh.Text);
                }

                var SoNgayCoKinh = doc.Bookmarks["SoNgayCoKinh"];
                if (SoNgayCoKinh != null)
                {
                    SoNgayCoKinh.SetText(HN_txtSoNgayCoKinh.Text);
                }

                var SoLuong = doc.Bookmarks["SoLuong"];
                if (SoLuong != null)
                {
                    SoLuong.SetText(HN_txtSoLuong.Text);
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HN_rtbGhiChuTSKN.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HN_dtNgayTaoTSKN.Value.ToString("dd-MM-yyyy"));
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HN_btnXuatKQXN_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_xet_nghiem.docx");
                DocX doc = CreateReportCommon(g_document);

                var NhomMau = doc.Bookmarks["NhomMau"];
                if (NhomMau != null)
                {
                    NhomMau.SetText(HN_txtNhomMau.Text);
                }

                var HIV = doc.Bookmarks["HIV"];
                if (HIV != null)
                {
                    HIV.SetText(HN_txtHIV.Text);
                }

                var BW = doc.Bookmarks["BW"];
                if (BW != null)
                {
                    BW.SetText(HN_txtBW.Text);
                }

                var Hbsag = doc.Bookmarks["Hbsag"];
                if (Hbsag != null)
                {
                    Hbsag.SetText(HN_txtHBsAg.Text);
                }

                var AntiHCV = doc.Bookmarks["AntiHCV"];
                if (AntiHCV != null)
                {
                    AntiHCV.SetText(HN_txtAntiHCV.Text);
                }

                var GioiTinh = doc.Bookmarks["GioiTinh"];
                if (GioiTinh != null)
                {
                    GioiTinh.SetText("Nữ");
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HN_rtbGhiChuKQXN.Text);
                }

                var SoLanKiemTra = doc.Bookmarks["SoLanKiemTra"];
                if (SoLanKiemTra != null)
                {
                    SoLanKiemTra.SetText(HN_txtSoLanKiemTra.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HN_dtNgayTaoKQXN.Value.ToString("dd-MM-yyyy"));
                }

                SaveFile(doc);
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xuất file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HN_btnXuatTienSuSS_Click(object sender, EventArgs e)
        {
            try
            {
                DocX g_document = DocX.Load(@"ket_qua_tien_su_sinh_san.docx");
                DocX doc = CreateReportCommon(g_document);

                var SoLanCoThai = doc.Bookmarks["SoLanCoThai"];
                if (SoLanCoThai != null)
                {
                    SoLanCoThai.SetText(HN_txtSoLanCoThai.Text);
                }

                var SoLuongDeConSong = doc.Bookmarks["SoLuongDeConSong"];
                if (SoLuongDeConSong != null)
                {
                    SoLuongDeConSong.SetText(HN_txtSoLuongDeConSong.Text);
                }

                var NaoHut = doc.Bookmarks["NaoHut"];
                if (NaoHut != null)
                {
                    NaoHut.SetText(HN_txtNaoHut.Text);
                }

                var ThaiLuu = doc.Bookmarks["ThaiLuu"];
                if (ThaiLuu != null)
                {
                    ThaiLuu.SetText(HN_txtThaiLuu.Text);
                }

                var ChuaNgoaiDaCon = doc.Bookmarks["ChuaNgoaiDaCon"];
                if (ChuaNgoaiDaCon != null)
                {
                    ChuaNgoaiDaCon.SetText(HN_txtChuaNgoaiDaCon.Text);
                }

                var ChuaTrung = doc.Bookmarks["ChuaTrung"];
                if (ChuaTrung != null)
                {
                    ChuaTrung.SetText(HN_txtChuaTrung.Text);
                }

                var GhiChu = doc.Bookmarks["GhiChu"];
                if (GhiChu != null)
                {
                    GhiChu.SetText(HN_rtbGhiChuTSSS.Text);
                }

                var NgayXetNghiem = doc.Bookmarks["NgayXetNghiem"];
                if (NgayXetNghiem != null)
                {
                    NgayXetNghiem.SetText(HN_dtNgayTaoTTSS.Value.ToString("dd-MM-yyyy"));
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
            app.SendMessageFPs(this, "HN");
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

        public override void SetPatientCode(string code) { HN_lbMaBN.Text = code; }
        public override void SetFullName(string fullName) { HN_txtHoVaTen.Text = fullName; }
        public override void SetPhoneNumber(string phoneNo) { HN_txtSoDienThoai.Text = phoneNo; }
        public override void SetItentity(string identity) { HN_txtSoCMND.Text = identity; }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn phê duyệt hồ sơ bệnh nhân này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.OK)
            {
                dbBN.ApprovePatient(HN_lbMaBN.Text, true);
                HN_btnTaoHoSoBN.Visible = false;
                HN_btnHuyBo.Visible = false;
                //HN_btnApprove.Visible = false;

                lblApprove.Visible = true;
            }
        }

        private void HN_sgLuuTruHoSo_CellClick(object sender, GridCellClickEventArgs e)
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
                        if (!dbBN.AddNewFile(fileID, dlg.SafeFileName, HN_lbMaBN.Text))
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

        private void DisplayLuuTruHoSo()
        {
            Dictionary<int, LoaiHoSo> hosos = dbBN.GetAllTenHoSo(false);

            GridPanel panel = HN_sgLuuTruHoSo.PrimaryGrid;
            panel.Rows.Clear();
            HN_sgLuuTruHoSo.BeginUpdate();
            foreach (var hs in hosos)
            {
                int num = SoHoSoBN(hs.Key);
                object[] ob1 = new object[]
                    {
                    hs.Key, hs.Value.TenHoSo, num, "Thêm mới"
                    };
                panel.Rows.Add(new GridRow(ob1));
            }
            HN_sgLuuTruHoSo.EndUpdate();
        }

        private int SoHoSoBN(int fileId)
        {
            int num = 0;
            List<HoSoLuuTru> hosos = dbBN.GetHoSoLuuTru(HN_lbMaBN.Text);
            foreach (var hs in hosos)
            {
                if (hs.FileId == fileId)
                    num++;
            }

            return num;
        }

        private void superTabItem2_Click(object sender, EventArgs e)
        {
            DisplayLuuTruHoSo();
        }

        private void HN_cboQuanHuyen_MouseClick(object sender, MouseEventArgs e)
        {
            var value = HN_cboTinhThanh.SelectedValue;
            if (value == null)
                return;

            HN_cboQuanHuyen.DataSource = app.GetDMThanhPho(value.ToString());
        }

        private void HN_cboQuanHuyen_MouseUp(object sender, MouseEventArgs e)
        {
            var value = HN_cboTinhThanh.SelectedValue;
            if (value == null)
                return;

            HN_cboQuanHuyen.DataSource = app.GetDMThanhPho(value.ToString());
        }

        private void HN_cboQuanHuyen_MouseDown(object sender, MouseEventArgs e)
        {
            var value = HN_cboTinhThanh.SelectedValue;
            if (value == null)
                return;

            HN_cboQuanHuyen.DataSource = app.GetDMThanhPho(value.ToString());
        }
    }
}
