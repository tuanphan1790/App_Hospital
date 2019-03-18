namespace ServiceCenter
{
    partial class MailTTCNTT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailTTCNTT));
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkEnableSecurity = new System.Windows.Forms.CheckBox();
            this.txtIntervalTimer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPOPServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMailServerAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCAPath = new System.Windows.Forms.Button();
            this.txtCAPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkUseGmail = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbtCheckSyncTTHTSS = new System.Windows.Forms.RadioButton();
            this.rbtAlwayAllowSyncTTHTSS = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(403, 441);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(313, 441);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkEnableSecurity
            // 
            this.chkEnableSecurity.AutoSize = true;
            this.chkEnableSecurity.Location = new System.Drawing.Point(14, 21);
            this.chkEnableSecurity.Name = "chkEnableSecurity";
            this.chkEnableSecurity.Size = new System.Drawing.Size(163, 17);
            this.chkEnableSecurity.TabIndex = 22;
            this.chkEnableSecurity.Text = "Cho phép truyền thư bảo mật";
            this.chkEnableSecurity.UseVisualStyleBackColor = true;
            this.chkEnableSecurity.CheckedChanged += new System.EventHandler(this.chkEnableSecurity_CheckedChanged);
            // 
            // txtIntervalTimer
            // 
            this.txtIntervalTimer.Location = new System.Drawing.Point(141, 25);
            this.txtIntervalTimer.Name = "txtIntervalTimer";
            this.txtIntervalTimer.Size = new System.Drawing.Size(136, 20);
            this.txtIntervalTimer.TabIndex = 15;
            this.txtIntervalTimer.Text = "5000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Thời gian nhận thư";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(378, 38);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(124, 20);
            this.txtPassword.TabIndex = 20;
            this.txtPassword.Text = "bvpstw123456";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Mật khẩu";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(119, 40);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(161, 20);
            this.txtUser.TabIndex = 18;
            this.txtUser.Text = "bvps.server@gmail.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tên mail đăng nhập";
            // 
            // txtPOPServerPort
            // 
            this.txtPOPServerPort.Location = new System.Drawing.Point(378, 12);
            this.txtPOPServerPort.Name = "txtPOPServerPort";
            this.txtPOPServerPort.Size = new System.Drawing.Size(124, 20);
            this.txtPOPServerPort.TabIndex = 16;
            this.txtPOPServerPort.Text = "995";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "POP3 Port";
            // 
            // txtMailServerAddress
            // 
            this.txtMailServerAddress.Location = new System.Drawing.Point(119, 12);
            this.txtMailServerAddress.Name = "txtMailServerAddress";
            this.txtMailServerAddress.Size = new System.Drawing.Size(161, 20);
            this.txtMailServerAddress.TabIndex = 14;
            this.txtMailServerAddress.Text = "192.168.203.31";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Địa chỉ mail server";
            // 
            // btnCAPath
            // 
            this.btnCAPath.Enabled = false;
            this.btnCAPath.Location = new System.Drawing.Point(725, 43);
            this.btnCAPath.Name = "btnCAPath";
            this.btnCAPath.Size = new System.Drawing.Size(43, 21);
            this.btnCAPath.TabIndex = 27;
            this.btnCAPath.Text = "...";
            this.btnCAPath.UseVisualStyleBackColor = true;
            this.btnCAPath.Click += new System.EventHandler(this.btnCAPath_Click);
            // 
            // txtCAPath
            // 
            this.txtCAPath.Enabled = false;
            this.txtCAPath.Location = new System.Drawing.Point(141, 44);
            this.txtCAPath.Name = "txtCAPath";
            this.txtCAPath.Size = new System.Drawing.Size(578, 20);
            this.txtCAPath.TabIndex = 26;
            this.txtCAPath.Text = "D:\\Work\\C++\\Library\\openssl\\bin\\Release\\New folder\\rootCA.cer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Đường dẫn chứng chỉ số";
            // 
            // txtConnString
            // 
            this.txtConnString.Location = new System.Drawing.Point(102, 26);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(666, 20);
            this.txtConnString.TabIndex = 29;
            this.txtConnString.Text = "Data Source=DESKTOP-7NOQEV1\\SQLEXPRESS; Initial Catalog=htssServer; User id=sa; P" +
    "assword=01071990;";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Chuỗi kết nối DB";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkUseGmail);
            this.groupBox4.Controls.Add(this.txtCAPath);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnCAPath);
            this.groupBox4.Controls.Add(this.chkEnableSecurity);
            this.groupBox4.Location = new System.Drawing.Point(17, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(774, 109);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cho phép truyền thư bảo mật";
            // 
            // chkUseGmail
            // 
            this.chkUseGmail.AutoSize = true;
            this.chkUseGmail.Location = new System.Drawing.Point(14, 80);
            this.chkUseGmail.Name = "chkUseGmail";
            this.chkUseGmail.Size = new System.Drawing.Size(93, 17);
            this.chkUseGmail.TabIndex = 28;
            this.chkUseGmail.Text = "Sử dụng gmail";
            this.chkUseGmail.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtIntervalTimer);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(16, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(774, 59);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cấu hình POP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.rbtCheckSyncTTHTSS);
            this.groupBox2.Controls.Add(this.rbtAlwayAllowSyncTTHTSS);
            this.groupBox2.Location = new System.Drawing.Point(17, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(774, 99);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình đồng bộ dữ liệu từ trung tâm CNTT về trung tâm HTSS";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 68);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(565, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Cho phép những trung tâm HTSS trong danh sách không bị kiểm duyệt khi có yêu cầu " +
    "đồng bộ dữ liệu bệnh nhân";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbtCheckSyncTTHTSS
            // 
            this.rbtCheckSyncTTHTSS.AutoSize = true;
            this.rbtCheckSyncTTHTSS.Location = new System.Drawing.Point(22, 45);
            this.rbtCheckSyncTTHTSS.Name = "rbtCheckSyncTTHTSS";
            this.rbtCheckSyncTTHTSS.Size = new System.Drawing.Size(379, 17);
            this.rbtCheckSyncTTHTSS.TabIndex = 1;
            this.rbtCheckSyncTTHTSS.TabStop = true;
            this.rbtCheckSyncTTHTSS.Text = "Kiểm duyệt tất cả các trung tâm khi có yêu cầu đồng bộ dữ liệu bệnh nhân";
            this.rbtCheckSyncTTHTSS.UseVisualStyleBackColor = true;
            // 
            // rbtAlwayAllowSyncTTHTSS
            // 
            this.rbtAlwayAllowSyncTTHTSS.AutoSize = true;
            this.rbtAlwayAllowSyncTTHTSS.Location = new System.Drawing.Point(22, 22);
            this.rbtAlwayAllowSyncTTHTSS.Name = "rbtAlwayAllowSyncTTHTSS";
            this.rbtAlwayAllowSyncTTHTSS.Size = new System.Drawing.Size(384, 17);
            this.rbtAlwayAllowSyncTTHTSS.TabIndex = 0;
            this.rbtAlwayAllowSyncTTHTSS.TabStop = true;
            this.rbtAlwayAllowSyncTTHTSS.Text = "Luôn cho phép đồng bộ dữ liệu bệnh nhân về các trung tâm khi có yêu cầu";
            this.rbtAlwayAllowSyncTTHTSS.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtConnString);
            this.groupBox5.Location = new System.Drawing.Point(17, 72);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(774, 61);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cấu hình DB";
            // 
            // MailTTCNTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 474);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPOPServerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMailServerAddress);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MailTTCNTT";
            this.Text = "PHẦN MỀM ĐỒNG BỘ DỮ LIỆU TRUNG TÂM CNTT";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkEnableSecurity;
        private System.Windows.Forms.TextBox txtIntervalTimer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPOPServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMailServerAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCAPath;
        private System.Windows.Forms.TextBox txtCAPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbtCheckSyncTTHTSS;
        private System.Windows.Forms.RadioButton rbtAlwayAllowSyncTTHTSS;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox chkUseGmail;
    }
}

