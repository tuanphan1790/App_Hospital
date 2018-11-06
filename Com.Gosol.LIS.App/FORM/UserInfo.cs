using BVPS.Model.UserPermissionInfor;
using DevComponents.DotNetBar;
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

namespace BVPS.App
{
    public partial class UserInfo : DevComponents.DotNetBar.Metro.MetroForm
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        public UserInfo(NguoiSuDung nsd)
        {
            InitializeComponent();
            FillDataToForm(nsd);
        }

        private void FillDataToForm(NguoiSuDung nsd)
        {
            txtFullName.Text = nsd.FullName;
            txtUserName.Text = nsd.UserName;
            txtPassword.Text = nsd.Password;
            txtEmail.Text = nsd.Email;
            txtPhone.Text = nsd.SoDienThoai;
            dtNgaySinh.Value = nsd.NgaySinh;
            txtGioiTinh.Text = nsd.GioiTinh;
            txtDiaChi.Text = nsd.DiaChi;
            txtChucVu.Text = nsd.ChucVu;

            this.btnOK.Hide();
            this.btnCancel.Hide();
        }

        public string FullName()
        {
            return txtFullName.Text;
        }
        public string UserLogon()
        {
            return txtUserName.Text;
        }
        public string Password()
        {
            return txtPassword.Text;
        }
        public string Email()
        {
            return txtEmail.Text;
        }
        public string Phone()
        {
            return txtPhone.Text;
        }
        public DateTime NgaySinh()
        {
            return dtNgaySinh.Value;
        }
        public string GioiTinh()
        {
            return txtGioiTinh.Text;
        }
        public string DiaChi()
        {
            return txtDiaChi.Text;
        }
        public string ChucVu()
        {
            return txtChucVu.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" | txtUserName.Text =="" | txtPassword.Text =="" | txtEmail.Text =="" | txtPhone.Text =="" | dtNgaySinh.Text =="" | txtGioiTinh.Text =="" | txtDiaChi.Text =="" | txtChucVu.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập một số trường thông tin bắt buộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex phoneNumpattern = new Regex(@"^-*[0-9,\.?\-?\(?\)?\ ]+$");
            if (!phoneNumpattern.IsMatch(txtPhone.Text))
            {
                MessageBox.Show("Bạn chưa nhập đúng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
