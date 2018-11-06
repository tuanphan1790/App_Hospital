using BVPS.App;
using libzkfpcsharp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.Gosol.LIS.App
{
    public abstract class UserControlBN : UserControl
    {
        protected const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        protected int ret = zkfperrdef.ZKFP_ERR_OK;
        protected byte[] CapTmp = new byte[2048];
        protected int cbCapTmp = 2048;
        protected byte[] FPBuffer;

        protected IntPtr FormHandle = IntPtr.Zero;

        protected int mfpWidth = 0;
        protected int mfpHeight = 0;

        protected string base64ImageStringNgonCaiPhai;
        protected string base64ImageStringNgonCaiTrai;
        protected string base64ImageStringNgonTroPhai;
        protected string base64ImageStringNgonTroTrai;

        protected string FPBlobNgonCaiPhai;
        protected string FPBlobNgonCaiTrai;
        protected string FPBlobNgonTroPhai;
        protected string FPBlobNgonTroTrai;

        protected MemoryStream ms = new MemoryStream();

        public bool AllowCreateInfoAfterCheckTTCNTT = false;

        public const int File_DonXinTuNguyenHien = 1;
        public const int File_GiayDangKyKetHon = 2;
        public const int File_GiayChungNhanDocThan = 3;
        public const int File_PhieuKetQuaXetNghiem = 4;
        public const int File_PhieuThongTinNguoiVanDong = 5;

        public const int File_PhieuLuuTruMau = 6;
        public const int File_BanCamKetHienTinhChoNganHang = 7;
        public const int File_PhieuXetNghiemKhamNamKhoa = 8;
        public const int File_PhieuThongTinNguoiQuanHeNguoiHienTinh = 9;
        public const int File_PhieuDacTrungNguoiHienTinh = 10;
        public const int File_PhieuXetNghiemTinhDichDo = 11;

        public const int File_PhieuKhamTienSuSinhSan = 12;
        public const int File_PhieuKhamTieuSuKinhNguyet = 13;
        public const int File_PhieuKhamHongVaXuongChau = 14;
        public const int File_PhieuKhamBenhToanThan = 15;
        public const int File_PhieuKhamBenhTinhDuc = 16;
        public const int File_BanCamKetHienTrungChoNganHang = 17;

        public abstract byte[] GetBlobNgonCaiPhai();
        public abstract byte[] GetBlobNgonCaiTrai();
        public abstract byte[] GetBlobNgonTroPhai();
        public abstract byte[] GetBlobNgonTroTrai();

        public abstract void SetPatientCode(string code);
        public abstract void SetFullName(string fullName);
        public abstract void SetPhoneNumber(string phoneNo);
        public abstract void SetItentity(string identity);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected AppsLIST app;

        protected bool IsHoSoDaDuocTao;

        protected bool IsCreatedPatient()
        {
            if (IsHoSoDaDuocTao)
                return true;
            else
            {
                MessageBox.Show("Hồ sơ bệnh nhân chưa được tạo trên hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected bool CheckPermissionAdd(int fun)
        {
            if (app.CheckPermissionAdd(fun))
                return true;
            else
            {
                MessageBox.Show("Bạn không có quyền với chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected bool CheckPermissionEdit(int fun)
        {
            if (app.CheckPermissionEdit(fun))
                return true;
            else
            {
                MessageBox.Show("Bạn không có quyền với chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected bool CheckPermissionDelete(int fun)
        {
            if (app.CheckPermissionDelete(fun))
                return true;
            else
            {
                MessageBox.Show("Bạn không có quyền với chức năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public UserControlBN(AppsLIST app)
        {
            this.app = app;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControlBN
            // 
            this.Name = "UserControlBN";
            this.Size = new System.Drawing.Size(358, 233);
            this.ResumeLayout(false);

        }

        protected void UploadFileToWebServer(string filePath)
        {
            try
            {
                if (filePath == null | filePath == "")
                    return;

                var client = new RestClient("http://" + app.urlWebService.Url);
                var request = new RestRequest("/upload", Method.POST);
                request.AddFile("fileUpload", filePath);

                client.ExecuteAsync(request, response =>
                {
                    var x = response.Content;
                });
            }
            catch
            {
                MessageBox.Show("Đường dẫn file "+ filePath + " không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void MessageSaveSuccess()
        {
            MessageBox.Show("Đã cập nhật hồ sơ thành công trên hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
