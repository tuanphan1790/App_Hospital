namespace Com.Gosol.LIS.App.FORM
{
    partial class DanhSachBenhNhans
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.XemChiTiet = new System.Windows.Forms.ToolStripMenuItem();
            this.Xoa = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTinhThanh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.txtSoCMND = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.dsbn = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XemChiTiet,
            this.Xoa});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 48);
            // 
            // XemChiTiet
            // 
            this.XemChiTiet.Name = "XemChiTiet";
            this.XemChiTiet.Size = new System.Drawing.Size(137, 22);
            this.XemChiTiet.Text = "Xem chi tiết";
            this.XemChiTiet.Click += new System.EventHandler(this.XemChiTiet_Click);
            // 
            // Xoa
            // 
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(137, 22);
            this.Xoa.Text = "Xóa";
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 570);
            this.panel1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboTinhThanh);
            this.groupBox1.Controls.Add(this.buttonX2);
            this.groupBox1.Controls.Add(this.txtSoCMND);
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 570);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CHỨC NĂNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(25, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Số CMND";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(25, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tỉnh thành";
            // 
            // cboTinhThanh
            // 
            this.cboTinhThanh.DisplayMember = "TenTinh";
            this.cboTinhThanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboTinhThanh.FormattingEnabled = true;
            this.cboTinhThanh.ItemHeight = 20;
            this.cboTinhThanh.Location = new System.Drawing.Point(29, 78);
            this.cboTinhThanh.Name = "cboTinhThanh";
            this.cboTinhThanh.Size = new System.Drawing.Size(194, 26);
            this.cboTinhThanh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTinhThanh.TabIndex = 16;
            this.cboTinhThanh.ValueMember = "MaTinh";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonX2.Location = new System.Drawing.Point(29, 185);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(194, 31);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.Symbol = "";
            this.buttonX2.TabIndex = 7;
            this.buttonX2.Text = "TÌM KIẾM";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // txtSoCMND
            // 
            this.txtSoCMND.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.txtSoCMND.Border.Class = "TextBoxBorder";
            this.txtSoCMND.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSoCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSoCMND.ForeColor = System.Drawing.Color.Black;
            this.txtSoCMND.Location = new System.Drawing.Point(29, 143);
            this.txtSoCMND.Name = "txtSoCMND";
            this.txtSoCMND.Size = new System.Drawing.Size(194, 26);
            this.txtSoCMND.TabIndex = 15;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.BackColor = System.Drawing.Color.Lime;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonX1.Location = new System.Drawing.Point(29, 275);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(194, 37);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "THÊM BỆNH NHÂN";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // dsbn
            // 
            this.dsbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dsbn.ContextMenuStrip = this.contextMenuStrip1;
            this.dsbn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsbn.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dsbn.ForeColor = System.Drawing.Color.Black;
            this.dsbn.Location = new System.Drawing.Point(3, 16);
            this.dsbn.Name = "dsbn";
            this.dsbn.PrimaryGrid.AutoHideDeletedRows = false;
            this.dsbn.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.AllowEdit = false;
            gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn1.HeaderText = "MÃ BỆNH NHÂN";
            gridColumn1.Name = "MaBN";
            gridColumn2.AllowEdit = false;
            gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn2.HeaderText = "TÊN BỆNH NHÂN";
            gridColumn2.Name = "TenBN";
            gridColumn3.AllowEdit = false;
            gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn3.HeaderText = "ĐỊA CHỈ";
            gridColumn3.Name = "DiaChi";
            gridColumn4.AllowEdit = false;
            gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn4.HeaderText = "SỐ CMND";
            gridColumn4.Name = "SoCMND";
            gridColumn5.AllowEdit = false;
            gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn5.HeaderText = "NGÀY SINH";
            gridColumn5.Name = "NgaySinh";
            gridColumn6.AllowEdit = false;
            gridColumn6.HeaderText = "SỐ ĐIỆN THOẠI";
            gridColumn6.Name = "SoDienThoai";
            gridColumn7.AllowEdit = false;
            gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn7.HeaderText = "PHÊ DUYỆT";
            gridColumn7.Name = "PheDuyet";
            gridColumn7.Width = 20;
            this.dsbn.PrimaryGrid.Columns.Add(gridColumn1);
            this.dsbn.PrimaryGrid.Columns.Add(gridColumn2);
            this.dsbn.PrimaryGrid.Columns.Add(gridColumn3);
            this.dsbn.PrimaryGrid.Columns.Add(gridColumn4);
            this.dsbn.PrimaryGrid.Columns.Add(gridColumn5);
            this.dsbn.PrimaryGrid.Columns.Add(gridColumn6);
            this.dsbn.PrimaryGrid.Columns.Add(gridColumn7);
            this.dsbn.PrimaryGrid.Header.Text = "";
            this.dsbn.PrimaryGrid.NoRowsText = "Select a DataSource from the list to the right to populate the grid.";
            this.dsbn.PrimaryGrid.ShowRowGridIndex = true;
            this.dsbn.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.dsbn.Size = new System.Drawing.Size(717, 551);
            this.dsbn.TabIndex = 19;
            this.dsbn.Text = "superGridControl1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dsbn);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(253, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(723, 570);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DANH SÁCH";
            // 
            // DanhSachBenhNhans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Name = "DanhSachBenhNhans";
            this.Size = new System.Drawing.Size(976, 570);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem XemChiTiet;
        private System.Windows.Forms.ToolStripMenuItem Xoa;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboTinhThanh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSoCMND;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dsbn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
