namespace SyncMailClient
{
    partial class FormTTHTSS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTTHTSS));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMailServerAddress = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimerInterval = new System.Windows.Forms.TextBox();
            this.txtMailTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkEnableSecurity = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCAPath = new System.Windows.Forms.TextBox();
            this.btnCAPath = new System.Windows.Forms.Button();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtIntervalTimer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkUseGmail = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEnableGetDataServer = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMaTT = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSMTPServerPort = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ mail server";
            // 
            // txtMailServerAddress
            // 
            this.txtMailServerAddress.Location = new System.Drawing.Point(124, 9);
            this.txtMailServerAddress.Name = "txtMailServerAddress";
            this.txtMailServerAddress.Size = new System.Drawing.Size(161, 20);
            this.txtMailServerAddress.TabIndex = 1;
            this.txtMailServerAddress.Text = "192.168.203.31";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(372, 38);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(124, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "bvpstw123456";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mật khẩu";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(124, 40);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(161, 20);
            this.txtUser.TabIndex = 6;
            this.txtUser.Text = "bvps.client.1@gmail.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên mail đăng nhập";
            // 
            // txtTimerInterval
            // 
            this.txtTimerInterval.Location = new System.Drawing.Point(113, 50);
            this.txtTimerInterval.Name = "txtTimerInterval";
            this.txtTimerInterval.Size = new System.Drawing.Size(124, 20);
            this.txtTimerInterval.TabIndex = 15;
            this.txtTimerInterval.Text = "5000";
            // 
            // txtMailTo
            // 
            this.txtMailTo.Location = new System.Drawing.Point(113, 24);
            this.txtMailTo.Name = "txtMailTo";
            this.txtMailTo.Size = new System.Drawing.Size(304, 20);
            this.txtMailTo.TabIndex = 13;
            this.txtMailTo.Text = "bvps.server@gmail.com";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Thời gian đọc DB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Địa chỉ gửi thư";
            // 
            // chkEnableSecurity
            // 
            this.chkEnableSecurity.AutoSize = true;
            this.chkEnableSecurity.Location = new System.Drawing.Point(18, 19);
            this.chkEnableSecurity.Name = "chkEnableSecurity";
            this.chkEnableSecurity.Size = new System.Drawing.Size(163, 17);
            this.chkEnableSecurity.TabIndex = 10;
            this.chkEnableSecurity.Text = "Cho phép truyền thư bảo mật";
            this.chkEnableSecurity.UseVisualStyleBackColor = true;
            this.chkEnableSecurity.CheckedChanged += new System.EventHandler(this.chkEnableSecurity_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(353, 489);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(443, 489);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Đường dẫn chứng chỉ số:";
            // 
            // txtCAPath
            // 
            this.txtCAPath.Enabled = false;
            this.txtCAPath.Location = new System.Drawing.Point(139, 43);
            this.txtCAPath.Name = "txtCAPath";
            this.txtCAPath.Size = new System.Drawing.Size(674, 20);
            this.txtCAPath.TabIndex = 14;
            this.txtCAPath.Text = "D:\\Work\\C++\\Library\\openssl\\bin\\Release\\New folder\\rootCA.cer";
            // 
            // btnCAPath
            // 
            this.btnCAPath.Enabled = false;
            this.btnCAPath.Location = new System.Drawing.Point(819, 42);
            this.btnCAPath.Name = "btnCAPath";
            this.btnCAPath.Size = new System.Drawing.Size(43, 21);
            this.btnCAPath.TabIndex = 15;
            this.btnCAPath.Text = "...";
            this.btnCAPath.UseVisualStyleBackColor = true;
            this.btnCAPath.Click += new System.EventHandler(this.btnCAPath_Click);
            // 
            // txtConnString
            // 
            this.txtConnString.Location = new System.Drawing.Point(113, 24);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(710, 20);
            this.txtConnString.TabIndex = 31;
            this.txtConnString.Text = "Data Source=DESKTOP-7NOQEV1\\SQLEXPRESS; Initial Catalog=htss; User id=sa; Passwor" +
    "d=01071990;";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Chuỗi kết nối DB";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChooseFile);
            this.groupBox2.Controls.Add(this.txtTimerInterval);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMailTo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(11, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(866, 79);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cấu hình SMTP";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(423, 22);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(150, 23);
            this.btnChooseFile.TabIndex = 39;
            this.btnChooseFile.Text = "Chọn loại hồ sơ upload";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtIntervalTimer);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(11, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(866, 59);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cấu hình POP";
            // 
            // txtIntervalTimer
            // 
            this.txtIntervalTimer.Location = new System.Drawing.Point(113, 24);
            this.txtIntervalTimer.Name = "txtIntervalTimer";
            this.txtIntervalTimer.Size = new System.Drawing.Size(124, 20);
            this.txtIntervalTimer.TabIndex = 38;
            this.txtIntervalTimer.Text = "3000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Thời gian nhận thư";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkUseGmail);
            this.groupBox4.Controls.Add(this.chkEnableSecurity);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtCAPath);
            this.groupBox4.Controls.Add(this.btnCAPath);
            this.groupBox4.Location = new System.Drawing.Point(11, 375);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(866, 108);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cấu hình truyền thư bảo mật";
            // 
            // chkUseGmail
            // 
            this.chkUseGmail.AutoSize = true;
            this.chkUseGmail.Location = new System.Drawing.Point(18, 75);
            this.chkUseGmail.Name = "chkUseGmail";
            this.chkUseGmail.Size = new System.Drawing.Size(93, 17);
            this.chkUseGmail.TabIndex = 29;
            this.chkUseGmail.Text = "Sử dụng gmail";
            this.chkUseGmail.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtConnString);
            this.groupBox1.Location = new System.Drawing.Point(11, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 61);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình DB";
            // 
            // chkEnableGetDataServer
            // 
            this.chkEnableGetDataServer.AutoSize = true;
            this.chkEnableGetDataServer.Location = new System.Drawing.Point(21, 25);
            this.chkEnableGetDataServer.Name = "chkEnableGetDataServer";
            this.chkEnableGetDataServer.Size = new System.Drawing.Size(343, 17);
            this.chkEnableGetDataServer.TabIndex = 16;
            this.chkEnableGetDataServer.Text = "Cho phép lấy dữ liệu của trung tâm về trước khi đồng bộ dữ liệu lên";
            this.chkEnableGetDataServer.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtMaTT);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.chkEnableGetDataServer);
            this.groupBox5.Location = new System.Drawing.Point(12, 74);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(865, 79);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cấu hình việc lấy dữ liệu ở trung tâm CNTT về trước khi đồng bộ lên";
            // 
            // txtMaTT
            // 
            this.txtMaTT.Location = new System.Drawing.Point(112, 48);
            this.txtMaTT.Name = "txtMaTT";
            this.txtMaTT.Size = new System.Drawing.Size(147, 20);
            this.txtMaTT.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Mã trung tâm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SMTP Port";
            // 
            // txtSMTPServerPort
            // 
            this.txtSMTPServerPort.Location = new System.Drawing.Point(372, 9);
            this.txtSMTPServerPort.Name = "txtSMTPServerPort";
            this.txtSMTPServerPort.Size = new System.Drawing.Size(124, 20);
            this.txtSMTPServerPort.TabIndex = 3;
            this.txtSMTPServerPort.Text = "25";
            // 
            // FormTTHTSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 515);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSMTPServerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMailServerAddress);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTTHTSS";
            this.Text = "PHẦN MỀM ĐỒNG BỘ DỮ LIỆU TRUNG TÂM HTSS";
            this.Load += new System.EventHandler(this.FormTTHTSS_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMailServerAddress;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMailTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkEnableSecurity;
        private System.Windows.Forms.TextBox txtTimerInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCAPath;
        private System.Windows.Forms.Button btnCAPath;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIntervalTimer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEnableGetDataServer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtMaTT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSMTPServerPort;
        private System.Windows.Forms.CheckBox chkUseGmail;
    }
}

