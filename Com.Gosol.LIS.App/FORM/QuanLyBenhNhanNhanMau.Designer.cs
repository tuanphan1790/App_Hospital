namespace Com.Gosol.LIS.App.FORM
{
    partial class QuanLyBenhNhanNhanMau
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
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridRow gridRow1 = new DevComponents.DotNetBar.SuperGrid.GridRow();
            this.QL_sgQuanLyNguoiNhan = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QL_sgQuanLyNguoiNhan
            // 
            this.QL_sgQuanLyNguoiNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.QL_sgQuanLyNguoiNhan.ContextMenuStrip = this.contextMenuStrip1;
            this.QL_sgQuanLyNguoiNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QL_sgQuanLyNguoiNhan.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.QL_sgQuanLyNguoiNhan.ForeColor = System.Drawing.Color.Black;
            this.QL_sgQuanLyNguoiNhan.Location = new System.Drawing.Point(0, 0);
            this.QL_sgQuanLyNguoiNhan.Name = "QL_sgQuanLyNguoiNhan";
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.AllowRowInsert = true;
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.AutoHideDeletedRows = false;
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.CellStyles.Empty.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.DataPropertyName = "Id";
            gridColumn1.HeaderText = "ID";
            gridColumn1.Name = "Id";
            gridColumn1.Visible = false;
            gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn2.DataPropertyName = "MaMau";
            gridColumn2.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            gridColumn2.HeaderText = "MÃ MẪU LƯU TRỮ";
            gridColumn2.Name = "MaMau";
            gridColumn3.AllowEdit = false;
            gridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.CellStyles.Empty.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.DataPropertyName = "PheDuyet";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn3.HeaderText = "PHÊ DUYỆT";
            gridColumn3.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn3.Name = "PheDuyet";
            gridColumn3.ReadOnly = true;
            gridColumn4.AllowEdit = false;
            gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn4.DataPropertyName = "NgayLuuTru";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl);
            gridColumn4.HeaderText = "NGÀY LƯU TRỮ";
            gridColumn4.Name = "NgayLuuTru";
            gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn5.DataPropertyName = "NgaySuDung";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl);
            gridColumn5.HeaderText = "NGÀY SỬ DỤNG";
            gridColumn5.Name = "NgaySuDung";
            gridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn6.DataPropertyName = "MaNguoiNhan";
            gridColumn6.HeaderText = "MÃ NGƯỜI NHẬN";
            gridColumn6.Name = "MaNguoiNhan";
            gridColumn7.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn7.DataPropertyName = "KetQuaSuDung";
            gridColumn7.HeaderText = "KẾT QUẢ SỬ DỤNG";
            gridColumn7.Name = "KetQuaSuDung";
            gridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.CellStyles.Empty.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.DataPropertyName = "HuyMau";
            gridColumn8.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn8.HeaderText = "HỦY MẪU";
            gridColumn8.Name = "HuyMau";
            gridColumn9.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn9.DataPropertyName = "NgayHuyMau";
            gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl);
            gridColumn9.HeaderText = "NGÀY HỦY MẪU";
            gridColumn9.Name = "NgayHuyMau";
            gridColumn9.Width = 20;
            gridColumn10.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn10.DataPropertyName = "GhiChu";
            gridColumn10.HeaderText = "GHI CHÚ";
            gridColumn10.Name = "GhiChu";
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn1);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn2);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn3);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn4);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn5);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn6);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn7);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn8);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn9);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Columns.Add(gridColumn10);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Header.Text = "";
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.NoRowsText = "Select a DataSource from the list to the right to populate the grid.";
            gridRow1.Expanded = true;
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Rows.Add(gridRow1);
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.ShowInsertRow = true;
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.ShowRowGridIndex = true;
            this.QL_sgQuanLyNguoiNhan.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.QL_sgQuanLyNguoiNhan.Size = new System.Drawing.Size(1363, 574);
            this.QL_sgQuanLyNguoiNhan.TabIndex = 21;
            this.QL_sgQuanLyNguoiNhan.Text = "superGridControl1";
            this.QL_sgQuanLyNguoiNhan.CellValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs>(this.QL_sgQuanLyNguoiNhan_CellValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaThôngTinToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 26);
            // 
            // xóaThôngTinToolStripMenuItem
            // 
            this.xóaThôngTinToolStripMenuItem.Name = "xóaThôngTinToolStripMenuItem";
            this.xóaThôngTinToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.xóaThôngTinToolStripMenuItem.Text = "Xóa thông tin";
            this.xóaThôngTinToolStripMenuItem.Click += new System.EventHandler(this.xóaThôngTinToolStripMenuItem_Click);
            // 
            // QuanLyBenhNhanNhanMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 574);
            this.Controls.Add(this.QL_sgQuanLyNguoiNhan);
            this.Name = "QuanLyBenhNhanNhanMau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ BỆNH NHÂN NHẬN MẪU";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl QL_sgQuanLyNguoiNhan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaThôngTinToolStripMenuItem;
    }
}