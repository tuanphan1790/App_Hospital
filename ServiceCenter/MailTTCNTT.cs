﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceCenter
{
    public partial class MailTTCNTT : Form
    {
        public MailTTCNTT()
        {
            InitializeComponent();
        }

        Thread processReadMail;
        DBLib.DBServerApi dbLibServer;

        Thread processWriteMail;
        DBLib.DBClientApi dbLibClient;

        private void btnStart_Click(object sender, EventArgs e)
        {
            BeginPullData();

            BeginPushData();
        }

        void MethodReceiveMail(object obj)
        {
            DBLib.DBServerApi _dbLib = (DBLib.DBServerApi)obj;
            _dbLib.StartTimerReadEmail();
        }

        void BeginPullData()
        {
            string connectionString = txtConnString.Text;

            DBLib.SMTPSetting smtpSetting = new DBLib.SMTPSetting(txtMailServerAddress.Text, Convert.ToInt32(txtPOPServerPort.Text), txtUser.Text, txtPassword.Text, chkEnableSecurity.Checked);
            dbLibServer = new DBLib.DBServerApi(smtpSetting);
            if (chkEnableSecurity.Checked)
                smtpSetting.CAPath = txtCAPath.Text;

            dbLibServer.LoginPopServerMail(chkEnableSecurity.Checked);

            dbLibServer.intervalRequest = Convert.ToDouble(txtIntervalTimer.Text);
            dbLibServer.connectionString = connectionString;

            processReadMail = new Thread(MethodReceiveMail);
            processReadMail.Start(dbLibServer);
        }

        void BeginPushData()
        {
            string connectionString = txtConnString.Text;

            DBLib.SMTPSetting smtpSetting = new DBLib.SMTPSetting(txtMailServerAddress.Text, Convert.ToInt32(txtSMTPServerPort.Text), txtUser.Text, txtPassword.Text, chkEnableSecurity.Checked);
            smtpSetting.MailAddressSend = txtUser.Text;
            //smtpSetting.MailAddressReceive = txtMailTo.Text;

            if (chkEnableSecurity.Checked)
                smtpSetting.CAPath = txtCAPath.Text;

            //dbLibClient = new DBLib.DBClientApi("TT_A", smtpSetting);
            //dbLibClient.LoginMailServer();

            //dbLibClient.intervalRequest = Convert.ToDouble(1000);
            //dbLibClient.connectionString = connectionString;

            //processWriteMail = new Thread(MethodSendMail);
            //processReadMail.Start(dbLibClient);

            if (rbtAlwayAllowSyncTTHTSS.Checked)
            {

            }
            else if(rbtCheckSyncTTHTSS.Checked)
            {

            }
        }

        void MethodSendMail(object obj)
        {
            //DBLib.DBClientApi _dbLib = (DBLib.DBClientApi)obj;
            //_dbLib.StartConnectDB();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            dbLibServer.StopTimerReadMail();
            processReadMail.Abort();
        }

        private void chkEnableSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEnableSecurity.Enabled)
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
    }
}