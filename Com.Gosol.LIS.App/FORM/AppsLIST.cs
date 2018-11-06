using BVPS.DB;
using BVPS.Model;
using BVPS.Model.ChiMuc;
using BVPS.Model.UserPermissionInfor;
using Com.Gosol.LIS.App;
using Com.Gosol.LIS.App.DataJson;
using Com.Gosol.LIS.App.FORM;
using libzkfpcsharp;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BVPS.App
{
    public partial class AppsLIST : Form
    {
        public string connString;
        string UserNameLogIn;

        UserControlBN controlPatient;
        TrungTamHTSS tthtss;

        NLog.Logger logger;

        UserInforDB userDB;
        ChiMucDB danhmucDB;
        HisLogSystemDB hislogDB;

        List<PhanQuyen> listPermiss;
        public UrlTrungTam urlWebService;

        public static IntPtr mDevHandle = IntPtr.Zero;
        public static IntPtr mDBHandle = IntPtr.Zero;
        public static bool bIsTimeToDie = false;

        List<DMDanToc> listDMDanTocs;
        List<DMThanhPho> listDMThanhPhos;
        List<DMTinhThanh> listDMTinhThanhs;
        List<DMTrinhDoHocVan> listDMTrinhDoHocVans;

        int ret = zkfperrdef.ZKFP_ERR_OK;
        bool IsOK;
        bool isUserAdmin = false;

        public bool CheckPermissionView(int fun)
        {
            if (isUserAdmin)
                return true;

            foreach (var pq in listPermiss)
            {
                if (pq.FunctionID == fun)
                    return pq.View();
            }
            return false;
        }

        public bool CheckPermissionAdd(int fun)
        {
            if (isUserAdmin)
                return true;

            foreach (var pq in listPermiss)
            {
                if (pq.FunctionID == fun)
                    return pq.Add();
            }
            return false;
        }

        public bool CheckPermissionEdit(int fun)
        {
            if (isUserAdmin)
                return true;

            foreach (var pq in listPermiss)
            {
                if (pq.FunctionID == fun)
                    return pq.Edit();
            }
            return false;
        }

        public bool CheckPermissionDelete(int fun)
        {
            if (isUserAdmin)
                return true;

            foreach (var pq in listPermiss)
            {
                if (pq.FunctionID == fun)
                    return pq.Delete();
            }
            return false;
        }

        public List<DMDanToc> GetDMDanToc()
        {
            return listDMDanTocs;
        }
        public List<DMThanhPho> GetDMThanhPho(string maTinh)
        {
            List<DMThanhPho> dmtp = new List<DMThanhPho>();
            foreach(var tp in listDMThanhPhos)
            {
                if (tp.MaTinh == maTinh)
                    dmtp.Add(tp);
            }

            return dmtp;
        }
        public List<DMThanhPho> GetDMAllThanhPho()
        {
            return listDMThanhPhos;
        }
        public List<DMTinhThanh> GetDMTinhThanh()
        {
            return listDMTinhThanhs;
        }
        public List<DMTrinhDoHocVan> GetDMTrinhDoHocVan()
        {
            return listDMTrinhDoHocVans;
        }
        public TrungTamHTSS GetTrungTamHTSS()
        {
            return tthtss;
        }

        private bool BeginInit(string userName)
        {
            bool check = true;

            listDMDanTocs = danhmucDB.GetDMDanToc();
            if (listDMDanTocs.Count == 0)
                check = false;

            listDMThanhPhos = danhmucDB.GetDMThanhPho();
            if (listDMThanhPhos.Count == 0)
                check = false;

            listDMTinhThanhs = danhmucDB.GetDMTinhThanh();
            if (listDMTinhThanhs.Count == 0)
                check = false;

            listDMTrinhDoHocVans = danhmucDB.GetDMTrinhDoHocVan();
            if (listDMTrinhDoHocVans.Count == 0)
                check = false;

            tthtss = danhmucDB.GetTrungTamHTSS();
            if (tthtss == null)
                check = false;

            listPermiss = userDB.GetPermissionByUser(userName);

            return check;
        }

        public AppsLIST()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();

            var exepath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(exepath);
            XElement XSettingPath = XElement.Load(directory + "/setting.xml");
            var XConnString = XSettingPath.Element("connectionStringDB");
            connString = XConnString.Attribute("path").Value;

            logger.Info(exepath);
            logger.Info(directory);
            logger.Info(connString);

            listDMDanTocs = new List<DMDanToc>();
            listDMThanhPhos = new List<DMThanhPho>();
            listDMTinhThanhs = new List<DMTinhThanh>();
            listDMTrinhDoHocVans = new List<DMTrinhDoHocVan>();
            listPermiss = new List<PhanQuyen>();

            userDB = new UserInforDB(connString);
            hislogDB = new HisLogSystemDB(connString);

            LoginForm login = new LoginForm(userDB, hislogDB);
            login.ShowDialog();

            if (login.ISOK)
            {
                UserNameLogIn = login.GetUserLogin();

                NguoiSuDung nsd = userDB.GetUserInfor(UserNameLogIn);
                isUserAdmin = nsd.IsAdmin;
                danhmucDB = new ChiMucDB(connString);

                InitializeComponent();
                this.WindowState = FormWindowState.Maximized;

                ShowFormBegin();

                IsOK = BeginInit(login.GetUserLogin());
            }
        }

        public void ShowFormBegin()
        {
            panelControl2.Controls.Clear();
            BeginForm bg = new BeginForm();
            bg.Dock = DockStyle.Fill;
            panelControl2.Controls.Add(bg);
            bg.Show();
        }

        public bool IsUserAdmin()
        {
            return isUserAdmin;
        }

        ~AppsLIST()
        {
            zkfp2.Terminate();
        }

        private void duLieuNSDMenuItem_Click(object sender, EventArgs e)
        {
            if (IsOK)
            {
                panelControl2.Controls.Clear();
                UserPermission managerUser = new UserPermission(userDB, UserNameLogIn);
                managerUser.Dock = DockStyle.Fill;
                panelControl2.Controls.Add(managerUser);
                managerUser.Show();
            }
            else
            {
                MessageBox.Show("Bạn chưa có danh mục tham chiếu");
            }
        }

        private void ttHoTroSSMenuItem_Click(object sender, EventArgs e)
        {
            TrungTamHTSSDlg tt = new TrungTamHTSSDlg(this, danhmucDB);
            var ret = tt.ShowDialog();
            if (ret == DialogResult.OK)
            {

            }
        }

        private void cauHinhServerTTMenuItem_Click(object sender, EventArgs e)
        {
            ConnectDBTT con = new ConnectDBTT(this, danhmucDB);
            if (con.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Bạn cần phải reset lại ứng dụng");
            }
        }

        private void hsbnHienNoanMenuItem_Click(object sender, EventArgs e)
        {
            if (IsOK)
            {
                panelControl2.Controls.Clear();
                DanhSachBenhNhans ds = new DanhSachBenhNhans(TypeBN.BNHienNoan, this);
                ds.Dock = DockStyle.Fill;
                panelControl2.Controls.Add(ds);
                ds.Show();
            }
            else
            {
                MessageBox.Show("Bạn chưa có danh mục tham chiếu");
            }
        }

        private void hsbnHienTinhMenuItem_Click(object sender, EventArgs e)
        {
            if (IsOK)
            {
                panelControl2.Controls.Clear();
                DanhSachBenhNhans ds = new DanhSachBenhNhans(TypeBN.BNHienTinh, this);
                ds.Dock = DockStyle.Fill;
                panelControl2.Controls.Add(ds);
                ds.Show();
            }
            else
            {
                MessageBox.Show("Bạn chưa có danh mục tham chiếu");
            }
        }

        private void dsDanhMucMenuItem_Click(object sender, EventArgs e)
        {
            panelControl2.Controls.Clear();
            QuanLyDanhMuc qlcm = new QuanLyDanhMuc(this, danhmucDB);
            qlcm.Dock = DockStyle.Fill;
            panelControl2.Controls.Add(qlcm);
            qlcm.Show();
        }

        private void lichSuHDMenuItem_Click(object sender, EventArgs e)
        {
            if (IsOK)
            {
                panelControl2.Controls.Clear();
                LogHisSystem his = new LogHisSystem(connString);
                his.Dock = DockStyle.Fill;
                panelControl2.Controls.Add(his);
                his.Show();
            }
            else
            {
                MessageBox.Show("Bạn chưa có danh mục tham chiếu");
            }
        }

        private void ketNoiThietBiMenuItem_Click(object sender, EventArgs e)
        {
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                ketNoiThietBiMenuItem.Visible = false;
                toolStripStatusLabel1.Text = "Thiết bị đã được kết nối";
            }
            else
            {
                MessageBox.Show("Kết nối đến thiết bị lỗi");
            }
        }

        private void AppsLIST_Load(object sender, EventArgs e)
        {
            urlWebService = danhmucDB.GetUrlTrungTam();
            if (urlWebService == null)
            {
                MessageBox.Show("Bạn chưa cấu hình cho việc kiểm tra vân tay trên trung tâm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!IsUserAdmin())
            {
                cauHinhServerTTMenuItem.Visible = false;
            }

            if ((ret = zkfp2.Init()) != zkfperrdef.ZKFP_ERR_OK)
            {
                toolStripStatusLabel1.Text = "Thiết bị chưa được kết nối";
            }
            else
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount <= 0)
                {
                    zkfp2.Terminate();
                    MessageBox.Show("Không có thiết bị đọc vân tay đang kết nối!");
                    return;
                }

                if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(0)))
                {
                    MessageBox.Show("Mở thiết bị đọc vân tay lỗi");
                    return;
                }

                if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
                {
                    MessageBox.Show("Khởi tạo thuật toán vân tay lỗi");
                    zkfp2.CloseDevice(mDevHandle);
                    mDevHandle = IntPtr.Zero;
                    return;
                }

                toolStripStatusLabel1.Text = "Thiết bị đã được kết nối";
                quanLyTBMenuItem.Visible = false;
            }

            if (!isUserAdmin)
            {
                heThongMenuItem.Visible = false;

                if (!CheckPermissionView(Utilities.FUN_QuanLyChiMuc))
                    quanLyDMMenuItem.Visible = false;
            }
        }

        private void AppsLIST_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show(this, "Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                bIsTimeToDie = true;
                Thread.Sleep(200);

                zkfp2.CloseDevice(mDevHandle);
                zkfp2.Terminate();
            }
        }

        public void SetHisOperate(string noidung)
        {
            NguoiSuDung nsd = userDB.GetUserInfor(UserNameLogIn);

            HisLogInfor logInfor = new HisLogInfor();
            logInfor.NoiDung = noidung;
            logInfor.ThoiGian = DateTime.Now;
            logInfor.UserName = nsd.FullName;

            string mes = "";
            hislogDB.AddLog(logInfor, ref mes);
        }

        public void SendMessageFPs(UserControlBN control, string type)
        {
            if (urlWebService == null)
                return;

            this.controlPatient = control;

            var client = new RestClient("http://" + urlWebService.Url);
            var request = new RestRequest("/get-patients", Method.POST);

            request.AddParameter("matt", tthtss.MaTTHTSS);
            request.AddParameter("type", type);

            client.ExecuteAsync(request, response =>
            {
                try
                {
                    ListBenhNhans ds = new ListBenhNhans();
                    ds = JsonConvert.DeserializeObject<ListBenhNhans>(response.Content);
                    CheckFPTrungTam(ds.datas);
                }
                catch
                {
                    MessageBox.Show("Dữ liệu trả về từ server không hợp lệ");
                }
            });
        }

        private void CheckFPTrungTam(List<BenhNhanInfo> dsbn)
        {
            List<BenhNhanInfo> listBNDuplicateFPs = new List<BenhNhanInfo>();

            int intResult;
            byte[] bnNeedCheck;
            foreach (var bn in dsbn)
            {
                byte[] fpBlob = { };
                if (bn.FPNgonCaiPhai != null)
                    fpBlob = zkfp.Base64String2Blob(bn.FPNgonCaiPhai);

                bnNeedCheck = controlPatient.GetBlobNgonCaiPhai();
                intResult = zkfp2.DBMatch(AppsLIST.mDBHandle, bnNeedCheck, fpBlob);
                if (intResult > 80)
                {
                    listBNDuplicateFPs.Add(bn);
                    continue;
                }

                if (bn.FPNgonCaiTrai != null)
                    fpBlob = zkfp.Base64String2Blob(bn.FPNgonCaiTrai);

                bnNeedCheck = controlPatient.GetBlobNgonCaiTrai();
                intResult = zkfp2.DBMatch(AppsLIST.mDBHandle, bnNeedCheck, fpBlob);
                if (intResult > 80)
                {
                    listBNDuplicateFPs.Add(bn);
                    continue;
                }

                if (bn.FPNgonTroPhai != null)
                    fpBlob = zkfp.Base64String2Blob(bn.FPNgonTroPhai);

                bnNeedCheck = controlPatient.GetBlobNgonTroPhai();
                intResult = zkfp2.DBMatch(AppsLIST.mDBHandle, bnNeedCheck, fpBlob);
                if (intResult > 80)
                {
                    listBNDuplicateFPs.Add(bn);
                    continue;
                }

                if (bn.FPNgonTroTrai != null)
                    fpBlob = zkfp.Base64String2Blob(bn.FPNgonTroTrai);

                bnNeedCheck = controlPatient.GetBlobNgonTroTrai();
                intResult = zkfp2.DBMatch(AppsLIST.mDBHandle, bnNeedCheck, fpBlob);
                if (intResult > 80)
                {
                    listBNDuplicateFPs.Add(bn);
                    continue;
                }
            }

            InvokeFromDBServer(listBNDuplicateFPs);
        }

        public void SetControlBNHT(HT_ThongTinNguoiHienTinh bnht)
        {
            panelControl2.Controls.Clear();
            HoSoNguoiHienTinh bn;
            if (bnht == null)
            {
                bn = new HoSoNguoiHienTinh(this);
            }
            else
            {
                bn = new HoSoNguoiHienTinh(bnht, this);
            }

            bn.Dock = DockStyle.Fill;
            panelControl2.Controls.Add(bn);
            bn.Show();
        }

        public void SetControlBNHN(HN_ThongTinNguoiHienNoan bnhn)
        {
            panelControl2.Controls.Clear();
            HoSoNguoiHienNoan bn;
            if (bnhn == null)
            {
                bn = new HoSoNguoiHienNoan(this);
            }
            else
            {
                bn = new HoSoNguoiHienNoan(bnhn, this);
            }

            bn.Dock = DockStyle.Fill;
            panelControl2.Controls.Add(bn);
            bn.Show();
        }

        private void InvokeFromDBServer(List<BenhNhanInfo> infors)
        {
            if (infors.Count > 0)
            {
                bool allowCreate = true;
                foreach (var infor in infors)
                {
                    if (!infor.FlagAllowAddPattern)
                    {
                        allowCreate = false;
                        break;
                    }
                }

                this.Invoke(new Action(() =>
                {
                    DialogResult result;
                    if (allowCreate)
                    {
                        controlPatient.AllowCreateInfoAfterCheckTTCNTT = true;
                        result = MessageBox.Show(this, "Đã có hồ sơ của bệnh nhân ở trung tâm khác và mẫu đã dùng hết, có thể thiết lập bộ hồ sơ mới cho bệnh nhân" + "\n" + "Bạn có muốn xem thông tin người này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        result = MessageBox.Show(this, "Đã có hồ sơ của bệnh nhân ở trung tâm khác và mẫu chưa dùng hết hoặc không đủ điều kiện. Không cho phép tạo bộ hồ sơ mới" + "\n" + "Bạn có muốn xem thông tin người này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }

                    if (result == DialogResult.Yes)
                    {
                        controlPatient.SetPatientCode(infors[0].Patient_code);
                        controlPatient.SetFullName(infors[0].Fullname);
                        controlPatient.SetPhoneNumber(infors[0].Phone);
                        controlPatient.SetItentity(infors[0].Identify);
                    }
                }));
            }
            else
                this.Invoke(new Action(() =>
                {
                    controlPatient.AllowCreateInfoAfterCheckTTCNTT = true;
                    MessageBox.Show(this, "Không có vân tay trên trung tâm dữ liệu công nghệ thông tin", "Thông báo", MessageBoxButtons.OK);
                }));
        }

        private void tRỞVỀTRANGCHỦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelControl2.Controls.Clear();
            BeginForm beginForm = new BeginForm();
            beginForm.Dock = DockStyle.Fill;
            panelControl2.Controls.Add(beginForm);
            beginForm.Show();
        }

    }
}
