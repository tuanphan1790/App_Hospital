using DBLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncMailClient
{
    public partial class FormTTHTSS : Form
    {
        public FormTTHTSS()
        {
            InitializeComponent();
        }

        Thread processReadMail;
        DBLib.DBClientApi dbLibClient;

        Thread processWriteMail;
        DBLib.DBServerApi dbLibServer;

        void BeginPushData(SettingChooseFile setting)
        {
            string connectionString = txtConnString.Text;

            DBLib.SMTPSetting smtpSetting = new DBLib.SMTPSetting(txtMailServerAddress.Text, Convert.ToInt32(txtSMTPServerPort.Text), txtUser.Text, txtPassword.Text, chkEnableSecurity.Checked);
            smtpSetting.MailAddressSend = txtUser.Text;
            smtpSetting.MailAddressReceive = txtMailTo.Text;

            if (chkEnableSecurity.Checked)
                smtpSetting.CAPath = txtCAPath.Text;

            dbLibClient = new DBLib.DBClientApi("TT_A", smtpSetting, setting);
            dbLibClient.LoginMailServer();

            dbLibClient.intervalRequest = Convert.ToDouble(txtTimerInterval.Text);
            dbLibClient.connectionString = connectionString;

            processReadMail = new Thread(MethodSendMail);
            processReadMail.Start(dbLibClient);
        }

        void BeginPullData()
        {
            if (!chkEnableGetDataServer.Checked)
                return;

            string connectionString = txtConnString.Text;

            DBLib.SMTPSetting smtpSetting = new DBLib.SMTPSetting(txtMailServerAddress.Text, Convert.ToInt32(txtPOPServerPort.Text), txtUser.Text, txtPassword.Text, chkEnableSecurity.Checked);
            dbLibServer = new DBLib.DBServerApi(smtpSetting);
            if (chkEnableSecurity.Checked)
                smtpSetting.CAPath = txtCAPath.Text;

            dbLibServer.LoginPopServerMail(chkEnableSecurity.Checked);

            dbLibServer.intervalRequest = Convert.ToDouble(txtIntervalTimer.Text);
            dbLibServer.connectionString = connectionString;

            //processWriteMail = new Thread(MethodReceiveMail);
            //processWriteMail.Start(dbLibServer);
        }

        void MethodReceiveMail(object obj)
        {
            //DBLib.DBServerApi _dbLib = (DBLib.DBServerApi)obj;
            //_dbLib.StartTimerReadEmail();
        }

        void MethodSendMail(object obj)
        {
            DBLib.DBClientApi _dbLib = (DBLib.DBClientApi)obj;
            _dbLib.StartConnectDB();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //BeginPullData();

            if (settingChooseFile == null)
            {
                MessageBox.Show("Bạn cần phải chọn các file được upload lên server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BeginPushData(settingChooseFile);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            dbLibClient.StopConnectDB();
            processReadMail.Abort();
        }

        private void chkEnableSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEnableSecurity.Checked)
            {
                txtCAPath.Enabled = true;
                btnCAPath.Enabled = true;
            }
            else
            {
                txtCAPath.Enabled = false;
                btnCAPath.Enabled = false;
            }
        }

        private void btnCAPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open CA File";
            dlg.InitialDirectory = @"C:\";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtCAPath.Text = dlg.FileName.ToString();
            }
        }

        private void FormTTHTSS_Load(object sender, EventArgs e)
        {
        }

        SettingChooseFile settingChooseFile;
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            ChooseFileUpload dlg = new ChooseFileUpload();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                settingChooseFile = new SettingChooseFile();
                settingChooseFile.HT_ThongTinBN = dlg.Get_HT_ThongTinCoBan();
                settingChooseFile.HT_ThongTinVoBN = dlg.Get_HT_ThongTinVoBN();
                settingChooseFile.HT_ThongTinNVD = dlg.Get_HT_ThongTinNVD();
                settingChooseFile.HT_ThongTinDacTrungNH = dlg.Get_HT_DacTrungNH();
                settingChooseFile.HT_ThongTinKhamNamKhoa = dlg.Get_HT_KhamNamKhoa();
                settingChooseFile.HT_ThongTinLuuTruMau = dlg.Get_HT_LuuTruMau();
                settingChooseFile.HT_ThongTinTinhDichDo = dlg.Get_HT_TinhDichDo();
                settingChooseFile.HT_ThongTinKQXN = dlg.Get_HT_KetQuaXN();

                settingChooseFile.HN_ThongTinBN = dlg.Get_HN_ThongTinCoBan();
                settingChooseFile.HN_ThongTinNVD = dlg.Get_HN_ThongTinNVD();
                settingChooseFile.HN_ThongTinTienSuSS = dlg.Get_HN_KhamTienSuSinhSan();
                settingChooseFile.HN_ThongTinTieuSuKN = dlg.Get_HN_KhamTieuSuKN();
                settingChooseFile.HN_ThongTinBenhTinhDuc = dlg.Get_HN_BenhTinhDuc();
                settingChooseFile.HN_ThongTinBenhToanThan = dlg.Get_HN_BenhToanThan();
                settingChooseFile.HN_ThongTinKhamHongVaXuongChau = dlg.Get_HN_KhamHongXuongChau();
                settingChooseFile.HN_ThongTinKQXN = dlg.Get_HN_KetQuaXN();
                settingChooseFile.HN_ThongTinHoiBenh = dlg.Get_HN_HoiBenh();

                btnChooseFile.Enabled = false;
            }
        }
    }
}
