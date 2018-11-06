namespace Com.Gosol.LIS.App.FORM
{
    partial class LogHisSystem
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.hisLog = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.SuspendLayout();
            // 
            // hisLog
            // 
            this.hisLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hisLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hisLog.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.hisLog.ForeColor = System.Drawing.Color.Black;
            this.hisLog.Location = new System.Drawing.Point(0, 0);
            this.hisLog.Name = "hisLog";
            this.hisLog.PrimaryGrid.AutoHideDeletedRows = false;
            this.hisLog.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None;
            gridColumn1.HeaderText = "NGÀY";
            gridColumn1.Name = "thoigian";
            gridColumn2.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn2.HeaderText = "THAO TÁC";
            gridColumn2.Name = "noidung";
            gridColumn3.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            gridColumn3.HeaderText = "NGƯỜI DÙNG";
            gridColumn3.Name = "nguoitao";
            this.hisLog.PrimaryGrid.Columns.Add(gridColumn1);
            this.hisLog.PrimaryGrid.Columns.Add(gridColumn2);
            this.hisLog.PrimaryGrid.Columns.Add(gridColumn3);
            this.hisLog.PrimaryGrid.Header.Text = "";
            this.hisLog.PrimaryGrid.NoRowsText = "Select a DataSource from the list to the right to populate the grid.";
            this.hisLog.PrimaryGrid.ShowRowGridIndex = true;
            this.hisLog.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.hisLog.Size = new System.Drawing.Size(653, 493);
            this.hisLog.TabIndex = 19;
            this.hisLog.Text = "superGridControl1";
            // 
            // LogHisSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hisLog);
            this.Name = "LogHisSystem";
            this.Size = new System.Drawing.Size(653, 493);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl hisLog;
    }
}
