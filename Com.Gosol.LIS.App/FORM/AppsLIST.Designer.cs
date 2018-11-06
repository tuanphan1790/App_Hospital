namespace BVPS.App
{
    partial class AppsLIST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppsLIST));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.heThongMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duLieuNSDMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttHoTroSSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cauHinhServerTTMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRỞVỀTRANGCHỦToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bnHienNoanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hsbnHienNoanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bnHienTinMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hsbnHienTinhMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyDMMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsDanhMucMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lichSuHDMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyTBMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ketNoiThietBiMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl2 = new DevComponents.DotNetBar.PanelEx();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "TuanPA";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(145, 17);
            this.toolStripStatusLabel1.Text = "Thiết bị chưa được kết nối";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Quản trị hệ thống";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 28);
            this.panel2.TabIndex = 15;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heThongMenuItem,
            this.bnHienNoanMenuItem,
            this.bnHienTinMenuItem,
            this.quanLyDMMenuItem,
            this.lichSuHDMenuItem,
            this.quanLyTBMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1024, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // heThongMenuItem
            // 
            this.heThongMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duLieuNSDMenuItem,
            this.ttHoTroSSMenuItem,
            this.cauHinhServerTTMenuItem,
            this.tRỞVỀTRANGCHỦToolStripMenuItem});
            this.heThongMenuItem.Name = "heThongMenuItem";
            this.heThongMenuItem.Size = new System.Drawing.Size(90, 24);
            this.heThongMenuItem.Text = "HỆ THỐNG";
            // 
            // duLieuNSDMenuItem
            // 
            this.duLieuNSDMenuItem.Name = "duLieuNSDMenuItem";
            this.duLieuNSDMenuItem.Size = new System.Drawing.Size(275, 24);
            this.duLieuNSDMenuItem.Text = "DỮ LIỆU NGƯỜI DÙNG";
            this.duLieuNSDMenuItem.Click += new System.EventHandler(this.duLieuNSDMenuItem_Click);
            // 
            // ttHoTroSSMenuItem
            // 
            this.ttHoTroSSMenuItem.Name = "ttHoTroSSMenuItem";
            this.ttHoTroSSMenuItem.Size = new System.Drawing.Size(275, 24);
            this.ttHoTroSSMenuItem.Text = "TRUNG TÂM HỖ TRỢ SINH SẢN";
            this.ttHoTroSSMenuItem.Click += new System.EventHandler(this.ttHoTroSSMenuItem_Click);
            // 
            // cauHinhServerTTMenuItem
            // 
            this.cauHinhServerTTMenuItem.Name = "cauHinhServerTTMenuItem";
            this.cauHinhServerTTMenuItem.Size = new System.Drawing.Size(275, 24);
            this.cauHinhServerTTMenuItem.Text = "CẤU HÌNH SERVER TRUNG TÂM";
            this.cauHinhServerTTMenuItem.Click += new System.EventHandler(this.cauHinhServerTTMenuItem_Click);
            // 
            // tRỞVỀTRANGCHỦToolStripMenuItem
            // 
            this.tRỞVỀTRANGCHỦToolStripMenuItem.Name = "tRỞVỀTRANGCHỦToolStripMenuItem";
            this.tRỞVỀTRANGCHỦToolStripMenuItem.Size = new System.Drawing.Size(275, 24);
            this.tRỞVỀTRANGCHỦToolStripMenuItem.Text = "TRỞ VỀ TRANG CHỦ";
            this.tRỞVỀTRANGCHỦToolStripMenuItem.Click += new System.EventHandler(this.tRỞVỀTRANGCHỦToolStripMenuItem_Click);
            // 
            // bnHienNoanMenuItem
            // 
            this.bnHienNoanMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hsbnHienNoanMenuItem});
            this.bnHienNoanMenuItem.Name = "bnHienNoanMenuItem";
            this.bnHienNoanMenuItem.Size = new System.Drawing.Size(178, 24);
            this.bnHienNoanMenuItem.Text = "BỆNH NHÂN HIẾN NOÃN";
            // 
            // hsbnHienNoanMenuItem
            // 
            this.hsbnHienNoanMenuItem.Name = "hsbnHienNoanMenuItem";
            this.hsbnHienNoanMenuItem.Size = new System.Drawing.Size(203, 24);
            this.hsbnHienNoanMenuItem.Text = "HỒ SƠ BỆNH NHÂN";
            this.hsbnHienNoanMenuItem.Click += new System.EventHandler(this.hsbnHienNoanMenuItem_Click);
            // 
            // bnHienTinMenuItem
            // 
            this.bnHienTinMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hsbnHienTinhMenuItem});
            this.bnHienTinMenuItem.Name = "bnHienTinMenuItem";
            this.bnHienTinMenuItem.Size = new System.Drawing.Size(169, 24);
            this.bnHienTinMenuItem.Text = "BỆNH NHÂN HIẾN TINH";
            // 
            // hsbnHienTinhMenuItem
            // 
            this.hsbnHienTinhMenuItem.Name = "hsbnHienTinhMenuItem";
            this.hsbnHienTinhMenuItem.Size = new System.Drawing.Size(203, 24);
            this.hsbnHienTinhMenuItem.Text = "HỒ SƠ BỆNH NHÂN";
            this.hsbnHienTinhMenuItem.Click += new System.EventHandler(this.hsbnHienTinhMenuItem_Click);
            // 
            // quanLyDMMenuItem
            // 
            this.quanLyDMMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dsDanhMucMenuItem});
            this.quanLyDMMenuItem.Name = "quanLyDMMenuItem";
            this.quanLyDMMenuItem.Size = new System.Drawing.Size(158, 24);
            this.quanLyDMMenuItem.Text = "QUẢN LÝ DANH MỤC";
            // 
            // dsDanhMucMenuItem
            // 
            this.dsDanhMucMenuItem.Name = "dsDanhMucMenuItem";
            this.dsDanhMucMenuItem.Size = new System.Drawing.Size(235, 24);
            this.dsDanhMucMenuItem.Text = "DANH SÁCH DANH MỤC";
            this.dsDanhMucMenuItem.Click += new System.EventHandler(this.dsDanhMucMenuItem_Click);
            // 
            // lichSuHDMenuItem
            // 
            this.lichSuHDMenuItem.Name = "lichSuHDMenuItem";
            this.lichSuHDMenuItem.Size = new System.Drawing.Size(158, 24);
            this.lichSuHDMenuItem.Text = "LỊCH SỬ HOẠT ĐỘNG";
            this.lichSuHDMenuItem.Click += new System.EventHandler(this.lichSuHDMenuItem_Click);
            // 
            // quanLyTBMenuItem
            // 
            this.quanLyTBMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ketNoiThietBiMenuItem});
            this.quanLyTBMenuItem.Name = "quanLyTBMenuItem";
            this.quanLyTBMenuItem.Size = new System.Drawing.Size(134, 24);
            this.quanLyTBMenuItem.Text = "QUẢN LÝ THIẾT BỊ";
            // 
            // ketNoiThietBiMenuItem
            // 
            this.ketNoiThietBiMenuItem.Name = "ketNoiThietBiMenuItem";
            this.ketNoiThietBiMenuItem.Size = new System.Drawing.Size(184, 24);
            this.ketNoiThietBiMenuItem.Text = "KẾT NỐI THIẾT BỊ";
            this.ketNoiThietBiMenuItem.Click += new System.EventHandler(this.ketNoiThietBiMenuItem_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelControl2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 28);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1024, 565);
            this.panelControl2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelControl2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelControl2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelControl2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelControl2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelControl2.Style.GradientAngle = 90;
            this.panelControl2.TabIndex = 15;
            // 
            // AppsLIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1024, 615);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppsLIST";
            this.Text = "HỆ THỐNG QUẢN LÝ THÔNG TIN BỆNH NHÂN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppsLIST_FormClosing);
            this.Load += new System.EventHandler(this.AppsLIST_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem heThongMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duLieuNSDMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ttHoTroSSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cauHinhServerTTMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bnHienNoanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hsbnHienNoanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bnHienTinMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hsbnHienTinhMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyDMMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dsDanhMucMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lichSuHDMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyTBMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ketNoiThietBiMenuItem;
        private DevComponents.DotNetBar.PanelEx panelControl2;
        private System.Windows.Forms.ToolStripMenuItem tRỞVỀTRANGCHỦToolStripMenuItem;
    }
}