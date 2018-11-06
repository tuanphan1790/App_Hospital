using BVPS.App;
using BVPS.DB;
using BVPS.Model.ChiMuc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.Gosol.LIS.App.FORM
{
    public partial class TrungTamHTSSDlg : Form
    {
        AppsLIST app;
        ChiMucDB dbCM;

        public TrungTamHTSSDlg(AppsLIST app, ChiMucDB dbCM)
        {
            this.app = app;
            this.dbCM = dbCM;

            InitializeComponent();
            LoadData();

            if (!app.IsUserAdmin())
            {
                btnSua.Hide();
                txtMaTrungTam.Enabled = false;
                txtTenTrungTam.Enabled = false;
                txtEmailTrungTam.Enabled = false;
                txtDiaChiTrungTam.Enabled = false;
                txtSoDienThoaiTrungTam.Enabled = false;
                txtWebsiteTrungTam.Enabled = false;
            }
        }

        int IdTrungTam;
        public void LoadData()
        {
            TrungTamHTSS tthtss = app.GetTrungTamHTSS();
            if (tthtss != null)
            {
                IdTrungTam = tthtss.Id;
                txtMaTrungTam.Text = tthtss.MaTTHTSS;
                txtTenTrungTam.Text = tthtss.TenTrungTam;
                txtEmailTrungTam.Text = tthtss.Email;
                txtDiaChiTrungTam.Text = tthtss.DiaChi;
                txtSoDienThoaiTrungTam.Text = tthtss.SoDienThoai;
                txtWebsiteTrungTam.Text = tthtss.Website;
            }
            else
            {
                IdTrungTam = -1;
                btnSua.Text = "Tạo mới";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Regex phoneNumpattern = new Regex(@"^-*[0-9,\.?\-?\(?\)?\ ]+$");
            if (!phoneNumpattern.IsMatch(txtSoDienThoaiTrungTam.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IdTrungTam != -1)
            {
                TrungTamHTSS tthtss = new TrungTamHTSS();
                tthtss.MaTTHTSS = txtMaTrungTam.Text;
                tthtss.TenTrungTam = txtTenTrungTam.Text;
                tthtss.Email = txtEmailTrungTam.Text;
                tthtss.DiaChi = txtDiaChiTrungTam.Text;
                tthtss.SoDienThoai = txtSoDienThoaiTrungTam.Text;
                tthtss.Website = txtWebsiteTrungTam.Text;

                dbCM.EditTrungTamHTSS(IdTrungTam, tthtss);
            }
            else
            {
                TrungTamHTSS tthtss = new TrungTamHTSS();
                tthtss.MaTTHTSS = txtMaTrungTam.Text;
                tthtss.TenTrungTam = txtTenTrungTam.Text;
                tthtss.Email = txtEmailTrungTam.Text;
                tthtss.DiaChi = txtDiaChiTrungTam.Text;
                tthtss.SoDienThoai = txtSoDienThoaiTrungTam.Text;
                tthtss.Website = txtWebsiteTrungTam.Text;

                dbCM.SetTrungTamHTSS(tthtss);
            }

            MessageBox.Show("Bạn cần restart lại ứng dụng khi sửa thông tin của trung tâm hỗ trợ sinh sản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
