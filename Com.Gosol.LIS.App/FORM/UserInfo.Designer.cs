namespace BVPS.App
{
    partial class UserInfo
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtFullName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.txtPhone = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtGioiTinh = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDiaChi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtChucVu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtNgaySinh = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgaySinh)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(22, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Họ và tên (*)";
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.ForeColor = System.Drawing.Color.Black;
            this.txtFullName.Location = new System.Drawing.Point(116, 10);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(243, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(101, 293);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(22, 36);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(90, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Tên đăng nhập (*)";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(22, 64);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Mật khẩu (*)";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(116, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(243, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(209, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(116, 98);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(243, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(22, 95);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Email (*)";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(22, 126);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(82, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Số điện thoại (*)";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(22, 190);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "Giới tính (*)";
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(22, 157);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "Ngày sinh (*)";
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.ForeColor = System.Drawing.Color.Black;
            this.labelX8.Location = new System.Drawing.Point(22, 223);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "Địa chỉ (*)";
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.ForeColor = System.Drawing.Color.Black;
            this.labelX10.Location = new System.Drawing.Point(22, 255);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(75, 23);
            this.labelX10.TabIndex = 0;
            this.labelX10.Text = "Chức vụ (*)";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPhone.Border.Class = "TextBoxBorder";
            this.txtPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Location = new System.Drawing.Point(116, 129);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(243, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGioiTinh.Border.Class = "TextBoxBorder";
            this.txtGioiTinh.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGioiTinh.ForeColor = System.Drawing.Color.Black;
            this.txtGioiTinh.Location = new System.Drawing.Point(116, 193);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(95, 20);
            this.txtGioiTinh.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDiaChi.Border.Class = "TextBoxBorder";
            this.txtDiaChi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiaChi.ForeColor = System.Drawing.Color.Black;
            this.txtDiaChi.Location = new System.Drawing.Point(116, 226);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(243, 20);
            this.txtDiaChi.TabIndex = 3;
            // 
            // txtChucVu
            // 
            this.txtChucVu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtChucVu.Border.Class = "TextBoxBorder";
            this.txtChucVu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtChucVu.ForeColor = System.Drawing.Color.Black;
            this.txtChucVu.Location = new System.Drawing.Point(116, 258);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(243, 20);
            this.txtChucVu.TabIndex = 3;
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtNgaySinh.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtNgaySinh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgaySinh.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtNgaySinh.ButtonDropDown.Visible = true;
            this.dtNgaySinh.CustomFormat = "dd-MM-yyyy";
            this.dtNgaySinh.ForeColor = System.Drawing.Color.Black;
            this.dtNgaySinh.IsPopupCalendarOpen = false;
            this.dtNgaySinh.Location = new System.Drawing.Point(116, 160);
            // 
            // 
            // 
            this.dtNgaySinh.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtNgaySinh.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgaySinh.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtNgaySinh.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtNgaySinh.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgaySinh.MonthCalendar.DisplayMonth = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            this.dtNgaySinh.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtNgaySinh.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgaySinh.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtNgaySinh.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgaySinh.MonthCalendar.TodayButtonVisible = true;
            this.dtNgaySinh.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(123, 20);
            this.dtNgaySinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtNgaySinh.TabIndex = 142;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.Location = new System.Drawing.Point(116, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(243, 20);
            this.txtUserName.TabIndex = 143;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 320);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.dtNgaySinh);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtChucVu);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtGioiTinh);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÔNG TIN NGƯỜI SỬ DỤNG";
            ((System.ComponentModel.ISupportInitialize)(this.dtNgaySinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFullName;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmail;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPhone;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGioiTinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDiaChi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtChucVu;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtNgaySinh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
    }
}