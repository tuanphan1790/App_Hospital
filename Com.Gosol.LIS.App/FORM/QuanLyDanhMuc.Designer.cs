namespace Com.Gosol.LIS.App.FORM
{
    partial class QuanLyDanhMuc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.superTabCM = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listViewThanhPho = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ThemChiMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.XoaChiMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX90 = new DevComponents.DotNetBar.LabelX();
            this.labelX91 = new DevComponents.DotNetBar.LabelX();
            this.HT_TabNguoiVanDongHT = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listViewDanToc = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelX92 = new DevComponents.DotNetBar.LabelX();
            this.labelX93 = new DevComponents.DotNetBar.LabelX();
            this.HT_TabLuuTruMau = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listViewTrinhDo = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.listViewTinh = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelX88 = new DevComponents.DotNetBar.LabelX();
            this.labelX89 = new DevComponents.DotNetBar.LabelX();
            this.HT_TabKetQuaXN = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabCM)).BeginInit();
            this.superTabCM.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.superTabControlPanel6.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabCM
            // 
            this.superTabCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabCM.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabCM.ControlBox.MenuBox.Name = "";
            this.superTabCM.ControlBox.Name = "";
            this.superTabCM.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabCM.ControlBox.MenuBox,
            this.superTabCM.ControlBox.CloseBox});
            this.superTabCM.Controls.Add(this.superTabControlPanel5);
            this.superTabCM.Controls.Add(this.superTabControlPanel4);
            this.superTabCM.Controls.Add(this.superTabControlPanel6);
            this.superTabCM.Controls.Add(this.superTabControlPanel1);
            this.superTabCM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabCM.ForeColor = System.Drawing.Color.Black;
            this.superTabCM.Location = new System.Drawing.Point(0, 0);
            this.superTabCM.Name = "superTabCM";
            this.superTabCM.ReorderTabsEnabled = true;
            this.superTabCM.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabCM.SelectedTabIndex = 0;
            this.superTabCM.Size = new System.Drawing.Size(994, 574);
            this.superTabCM.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabCM.TabIndex = 17;
            this.superTabCM.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.HT_TabKetQuaXN,
            this.HT_TabNguoiVanDongHT,
            this.HT_TabLuuTruMau,
            this.superTabItem1});
            this.superTabCM.Text = "CHỈ MỤC TỈNH ";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.listViewThanhPho);
            this.superTabControlPanel5.Controls.Add(this.labelX90);
            this.superTabControlPanel5.Controls.Add(this.labelX91);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 27);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(994, 547);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.HT_TabNguoiVanDongHT;
            // 
            // listViewThanhPho
            // 
            this.listViewThanhPho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listViewThanhPho.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewThanhPho.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewThanhPho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewThanhPho.ForeColor = System.Drawing.Color.Black;
            this.listViewThanhPho.Location = new System.Drawing.Point(0, 0);
            this.listViewThanhPho.Name = "listViewThanhPho";
            this.listViewThanhPho.Size = new System.Drawing.Size(994, 547);
            this.listViewThanhPho.TabIndex = 112;
            this.listViewThanhPho.UseCompatibleStateImageBehavior = false;
            this.listViewThanhPho.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "MÃ THÀNH PHỐ";
            this.columnHeader3.Width = 238;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "TÊN THÀNH PHỐ";
            this.columnHeader4.Width = 749;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThemChiMuc,
            this.XoaChiMuc});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 48);
            // 
            // ThemChiMuc
            // 
            this.ThemChiMuc.Name = "ThemChiMuc";
            this.ThemChiMuc.Size = new System.Drawing.Size(186, 22);
            this.ThemChiMuc.Text = "Thêm mới danh mục";
            this.ThemChiMuc.Click += new System.EventHandler(this.ThemChiMuc_Click);
            // 
            // XoaChiMuc
            // 
            this.XoaChiMuc.Name = "XoaChiMuc";
            this.XoaChiMuc.Size = new System.Drawing.Size(186, 22);
            this.XoaChiMuc.Text = "Xóa danh mục";
            this.XoaChiMuc.Click += new System.EventHandler(this.XoaChiMuc_Click);
            // 
            // labelX90
            // 
            this.labelX90.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX90.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX90.ForeColor = System.Drawing.Color.Black;
            this.labelX90.Location = new System.Drawing.Point(346, 585);
            this.labelX90.Name = "labelX90";
            this.labelX90.Size = new System.Drawing.Size(139, 23);
            this.labelX90.TabIndex = 111;
            this.labelX90.Text = "..............................................................";
            // 
            // labelX91
            // 
            this.labelX91.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX91.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX91.ForeColor = System.Drawing.Color.Black;
            this.labelX91.Location = new System.Drawing.Point(269, 585);
            this.labelX91.Name = "labelX91";
            this.labelX91.Size = new System.Drawing.Size(92, 23);
            this.labelX91.TabIndex = 110;
            this.labelX91.Text = "Người tạo";
            // 
            // HT_TabNguoiVanDongHT
            // 
            this.HT_TabNguoiVanDongHT.AttachedControl = this.superTabControlPanel5;
            this.HT_TabNguoiVanDongHT.GlobalItem = false;
            this.HT_TabNguoiVanDongHT.Name = "HT_TabNguoiVanDongHT";
            this.HT_TabNguoiVanDongHT.Text = "DANH MỤC THÀNH PHỐ";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.listViewDanToc);
            this.superTabControlPanel6.Controls.Add(this.labelX92);
            this.superTabControlPanel6.Controls.Add(this.labelX93);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(994, 574);
            this.superTabControlPanel6.TabIndex = 0;
            this.superTabControlPanel6.TabItem = this.HT_TabLuuTruMau;
            // 
            // listViewDanToc
            // 
            this.listViewDanToc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listViewDanToc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listViewDanToc.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewDanToc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDanToc.ForeColor = System.Drawing.Color.Black;
            this.listViewDanToc.Location = new System.Drawing.Point(0, 0);
            this.listViewDanToc.Name = "listViewDanToc";
            this.listViewDanToc.Size = new System.Drawing.Size(994, 574);
            this.listViewDanToc.TabIndex = 110;
            this.listViewDanToc.UseCompatibleStateImageBehavior = false;
            this.listViewDanToc.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 122;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "TÊN DÂN TỘC";
            this.columnHeader6.Width = 172;
            // 
            // labelX92
            // 
            this.labelX92.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX92.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX92.ForeColor = System.Drawing.Color.Black;
            this.labelX92.Location = new System.Drawing.Point(345, 585);
            this.labelX92.Name = "labelX92";
            this.labelX92.Size = new System.Drawing.Size(139, 23);
            this.labelX92.TabIndex = 109;
            this.labelX92.Text = "..............................................................";
            // 
            // labelX93
            // 
            this.labelX93.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX93.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX93.ForeColor = System.Drawing.Color.Black;
            this.labelX93.Location = new System.Drawing.Point(268, 585);
            this.labelX93.Name = "labelX93";
            this.labelX93.Size = new System.Drawing.Size(92, 23);
            this.labelX93.TabIndex = 108;
            this.labelX93.Text = "Người khám";
            // 
            // HT_TabLuuTruMau
            // 
            this.HT_TabLuuTruMau.AttachedControl = this.superTabControlPanel6;
            this.HT_TabLuuTruMau.GlobalItem = false;
            this.HT_TabLuuTruMau.Name = "HT_TabLuuTruMau";
            this.HT_TabLuuTruMau.Text = "DANH MỤC DÂN TỘC";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.listViewTrinhDo);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(994, 574);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // listViewTrinhDo
            // 
            this.listViewTrinhDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listViewTrinhDo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.listViewTrinhDo.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewTrinhDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTrinhDo.ForeColor = System.Drawing.Color.Black;
            this.listViewTrinhDo.Location = new System.Drawing.Point(0, 0);
            this.listViewTrinhDo.Name = "listViewTrinhDo";
            this.listViewTrinhDo.Size = new System.Drawing.Size(994, 574);
            this.listViewTrinhDo.TabIndex = 1;
            this.listViewTrinhDo.UseCompatibleStateImageBehavior = false;
            this.listViewTrinhDo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ID";
            this.columnHeader7.Width = 122;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "TÊN TRÌNH ĐỘ HỌC VẤN";
            this.columnHeader8.Width = 172;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "DANH MỤC TRÌNH ĐỘ HỌC VẤN";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.listViewTinh);
            this.superTabControlPanel4.Controls.Add(this.labelX88);
            this.superTabControlPanel4.Controls.Add(this.labelX89);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(994, 547);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.HT_TabKetQuaXN;
            // 
            // listViewTinh
            // 
            this.listViewTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listViewTinh.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewTinh.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTinh.ForeColor = System.Drawing.Color.Black;
            this.listViewTinh.Location = new System.Drawing.Point(0, 0);
            this.listViewTinh.Name = "listViewTinh";
            this.listViewTinh.Size = new System.Drawing.Size(994, 547);
            this.listViewTinh.TabIndex = 116;
            this.listViewTinh.UseCompatibleStateImageBehavior = false;
            this.listViewTinh.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MÃ TỈNH";
            this.columnHeader1.Width = 218;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TÊN TỈNH THÀNH";
            this.columnHeader2.Width = 772;
            // 
            // labelX88
            // 
            this.labelX88.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX88.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX88.ForeColor = System.Drawing.Color.Black;
            this.labelX88.Location = new System.Drawing.Point(344, 585);
            this.labelX88.Name = "labelX88";
            this.labelX88.Size = new System.Drawing.Size(139, 23);
            this.labelX88.TabIndex = 115;
            this.labelX88.Text = "..............................................................";
            // 
            // labelX89
            // 
            this.labelX89.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX89.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX89.ForeColor = System.Drawing.Color.Black;
            this.labelX89.Location = new System.Drawing.Point(267, 585);
            this.labelX89.Name = "labelX89";
            this.labelX89.Size = new System.Drawing.Size(92, 23);
            this.labelX89.TabIndex = 114;
            this.labelX89.Text = "Người khám";
            // 
            // HT_TabKetQuaXN
            // 
            this.HT_TabKetQuaXN.AttachedControl = this.superTabControlPanel4;
            this.HT_TabKetQuaXN.GlobalItem = false;
            this.HT_TabKetQuaXN.Name = "HT_TabKetQuaXN";
            this.HT_TabKetQuaXN.Text = "DANH MỤC TỈNH";
            // 
            // QuanLyDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.superTabCM);
            this.Name = "QuanLyDanhMuc";
            this.Size = new System.Drawing.Size(994, 574);
            ((System.ComponentModel.ISupportInitialize)(this.superTabCM)).EndInit();
            this.superTabCM.ResumeLayout(false);
            this.superTabControlPanel5.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.superTabControlPanel6.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabCM;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private System.Windows.Forms.ListView listViewTinh;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DevComponents.DotNetBar.LabelX labelX88;
        private DevComponents.DotNetBar.LabelX labelX89;
        private DevComponents.DotNetBar.SuperTabItem HT_TabKetQuaXN;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.ListView listViewTrinhDo;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private System.Windows.Forms.ListView listViewThanhPho;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private DevComponents.DotNetBar.LabelX labelX90;
        private DevComponents.DotNetBar.LabelX labelX91;
        private DevComponents.DotNetBar.SuperTabItem HT_TabNguoiVanDongHT;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel6;
        private System.Windows.Forms.ListView listViewDanToc;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private DevComponents.DotNetBar.LabelX labelX92;
        private DevComponents.DotNetBar.LabelX labelX93;
        private DevComponents.DotNetBar.SuperTabItem HT_TabLuuTruMau;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ThemChiMuc;
        private System.Windows.Forms.ToolStripMenuItem XoaChiMuc;
    }
}
