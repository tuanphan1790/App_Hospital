namespace Com.Gosol.LIS.App.FORM
{
    partial class UserPermission
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
            this.sgdmPermission = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.advTreeNSD = new DevComponents.AdvTree.AdvTree();
            this.Uname = new DevComponents.AdvTree.ColumnHeader();
            this.Fname = new DevComponents.AdvTree.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ThemMoi = new System.Windows.Forms.ToolStripMenuItem();
            this.XemChiTiet = new System.Windows.Forms.ToolStripMenuItem();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeNSD)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sgdmPermission
            // 
            this.sgdmPermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sgdmPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgdmPermission.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.sgdmPermission.ForeColor = System.Drawing.Color.Black;
            this.sgdmPermission.Location = new System.Drawing.Point(327, 0);
            this.sgdmPermission.Name = "sgdmPermission";
            this.sgdmPermission.PrimaryGrid.AutoHideDeletedRows = false;
            this.sgdmPermission.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.HeaderText = "ID";
            gridColumn1.Name = "ID";
            gridColumn1.Visible = false;
            gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells;
            gridColumn2.HeaderText = "TÊN CHỨC NĂNG";
            gridColumn2.Name = "TenChucNang";
            gridColumn2.Width = 200;
            gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn3.HeaderText = "XEM";
            gridColumn3.Name = "Xem";
            gridColumn4.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn4.HeaderText = "THÊM MỚI";
            gridColumn4.Name = "ThemMoi";
            gridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn5.HeaderText = "SỬA";
            gridColumn5.Name = "Sua";
            gridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn6.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn6.HeaderText = "XÓA";
            gridColumn6.Name = "Xoa";
            this.sgdmPermission.PrimaryGrid.Columns.Add(gridColumn1);
            this.sgdmPermission.PrimaryGrid.Columns.Add(gridColumn2);
            this.sgdmPermission.PrimaryGrid.Columns.Add(gridColumn3);
            this.sgdmPermission.PrimaryGrid.Columns.Add(gridColumn4);
            this.sgdmPermission.PrimaryGrid.Columns.Add(gridColumn5);
            this.sgdmPermission.PrimaryGrid.Columns.Add(gridColumn6);
            this.sgdmPermission.PrimaryGrid.Header.Text = "";
            this.sgdmPermission.PrimaryGrid.NoRowsText = "Select a DataSource from the list to the right to populate the grid.";
            this.sgdmPermission.PrimaryGrid.ShowRowGridIndex = true;
            this.sgdmPermission.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.sgdmPermission.Size = new System.Drawing.Size(694, 738);
            this.sgdmPermission.TabIndex = 18;
            this.sgdmPermission.Text = "superGridControl1";
            this.sgdmPermission.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.sgdmPermission_CellClick);
            // 
            // advTreeNSD
            // 
            this.advTreeNSD.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeNSD.AllowDrop = true;
            this.advTreeNSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.advTreeNSD.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeNSD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeNSD.Columns.Add(this.Uname);
            this.advTreeNSD.Columns.Add(this.Fname);
            this.advTreeNSD.ContextMenuStrip = this.contextMenuStrip1;
            this.advTreeNSD.Dock = System.Windows.Forms.DockStyle.Left;
            this.advTreeNSD.DragDropEnabled = false;
            this.advTreeNSD.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.advTreeNSD.ForeColor = System.Drawing.Color.Black;
            this.advTreeNSD.GridColumnLines = false;
            this.advTreeNSD.HotTracking = true;
            this.advTreeNSD.Location = new System.Drawing.Point(0, 0);
            this.advTreeNSD.Name = "advTreeNSD";
            this.advTreeNSD.NodeStyle = this.elementStyle5;
            this.advTreeNSD.PathSeparator = ";";
            this.advTreeNSD.Size = new System.Drawing.Size(327, 738);
            this.advTreeNSD.Styles.Add(this.elementStyle5);
            this.advTreeNSD.Styles.Add(this.elementStyle2);
            this.advTreeNSD.TabIndex = 17;
            this.advTreeNSD.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTreeNSD_NodeClick);
            // 
            // Uname
            // 
            this.Uname.Name = "Uname";
            this.Uname.Text = "USER NAME";
            this.Uname.Width.Absolute = 180;
            // 
            // Fname
            // 
            this.Fname.Name = "Fname";
            this.Fname.Text = "FULL NAME";
            this.Fname.Width.Absolute = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThemMoi,
            this.XemChiTiet});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 48);
            // 
            // ThemMoi
            // 
            this.ThemMoi.Name = "ThemMoi";
            this.ThemMoi.Size = new System.Drawing.Size(137, 22);
            this.ThemMoi.Text = "Thêm mới";
            this.ThemMoi.Click += new System.EventHandler(this.ThemMoi_Click);
            // 
            // XemChiTiet
            // 
            this.XemChiTiet.Name = "XemChiTiet";
            this.XemChiTiet.Size = new System.Drawing.Size(137, 22);
            this.XemChiTiet.Text = "Xem chi tiết";
            this.XemChiTiet.Click += new System.EventHandler(this.XemChiTiet_Click);
            // 
            // elementStyle5
            // 
            this.elementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(213)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.elementStyle2.BackColorGradientAngle = 90;
            this.elementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderBottomWidth = 1;
            this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderLeftWidth = 1;
            this.elementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderRightWidth = 1;
            this.elementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderTopWidth = 1;
            this.elementStyle2.CornerDiameter = 4;
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Description = "Yellow";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 1;
            this.elementStyle2.PaddingLeft = 1;
            this.elementStyle2.PaddingRight = 1;
            this.elementStyle2.PaddingTop = 1;
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // UserPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sgdmPermission);
            this.Controls.Add(this.advTreeNSD);
            this.Name = "UserPermission";
            this.Size = new System.Drawing.Size(1021, 738);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeNSD)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl sgdmPermission;
        private DevComponents.AdvTree.AdvTree advTreeNSD;
        private DevComponents.AdvTree.ColumnHeader Uname;
        private DevComponents.AdvTree.ColumnHeader Fname;
        private DevComponents.DotNetBar.ElementStyle elementStyle5;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ThemMoi;
        private System.Windows.Forms.ToolStripMenuItem XemChiTiet;
    }
}
