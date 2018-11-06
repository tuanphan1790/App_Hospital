using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Security.Cryptography;
using BVPS.DB;
using BVPS.Model.UserPermissionInfor;
using BVPS.Model;

namespace BVPS.App
{
    public partial class LoginForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public bool ISOK { get; set; }
        UserInforDB userInforDB;
        HisLogSystemDB log;

        public LoginForm(UserInforDB userInforDB, HisLogSystemDB log)
        {
            this.userInforDB = userInforDB;
            this.log = log;

            InitializeComponent();
        }

        public string GetUserLogin()
        {
            return txtUsername.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TaskDialogInfo tResult = new TaskDialogInfo("THOÁT CHƯƠNG TRÌNH", eTaskDialogIcon.Information, "", "Bạn có đồng ý thoát khỏi chương trình này không?", eTaskDialogButton.Yes);
            eTaskDialogResult result = TaskDialog.Show(tResult);

            if (result == eTaskDialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                bool check = userInforDB.CheckAccountLogin(txtUsername.Text, txtPassword.Text);
                if (!check)
                {
                    MessageBox.Show("Bạn đã đăng nhập sai tên hoặc password!");
                    return;
                }

                ISOK = true;

                NguoiSuDung nsd = userInforDB.GetUserInfor(txtUsername.Text);
                HisLogInfor logInfor = new HisLogInfor();
                logInfor.NoiDung = nsd.FullName + " đã đăng nhập";
                logInfor.ThoiGian = DateTime.Now;
                logInfor.UserName = nsd.FullName;

                string mes = "";
                log.AddLog(logInfor, ref mes);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa điền tên hoặc password!");
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}