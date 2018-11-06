using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVPS.App;
using BVPS.Model.ChiMuc;
using Com.Gosol.LIS.App.FORM.ChiMuc;
using BVPS.DB;

namespace Com.Gosol.LIS.App.FORM
{
    public partial class QuanLyDanhMuc : UserControl
    {
        AppsLIST app;
        ChiMucDB cmDB;

        public QuanLyDanhMuc(AppsLIST app, ChiMucDB cmDB)
        {
            this.app = app;
            this.cmDB = cmDB;

            InitializeComponent();
            FillDataToForm();
        }
        
        private void AlertUser()
        {
            MessageBox.Show("Bạn vừa mới cập nhật danh sách danh mục, Bạn cần phải restart lại ứng dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AddLVTinh(string maT, string tenT)
        {
            ListViewItem maTinh = new ListViewItem(maT);
            ListViewItem.ListViewSubItem tenTinh = new ListViewItem.ListViewSubItem(maTinh, tenT);
            maTinh.SubItems.Add(tenTinh);
            listViewTinh.Items.Add(maTinh);
        }
        private void AddLVThanhPho(string matp, string tentp)
        {
            ListViewItem maTP = new ListViewItem(matp);
            ListViewItem.ListViewSubItem tenTP = new ListViewItem.ListViewSubItem(maTP, tentp);
            maTP.SubItems.Add(tenTP);
            listViewThanhPho.Items.Add(maTP);
        }
        private void AddLVDanToc(int id, string tendt)
        {
            ListViewItem idDT = new ListViewItem(id.ToString());
            ListViewItem.ListViewSubItem tenDT = new ListViewItem.ListViewSubItem(idDT, tendt);
            idDT.SubItems.Add(tenDT);
            listViewDanToc.Items.Add(idDT);
        }
        private void AddLVTrinhDo(int id, string tentd)
        {
            ListViewItem idTD = new ListViewItem(id.ToString());
            ListViewItem.ListViewSubItem tenTD = new ListViewItem.ListViewSubItem(idTD, tentd);
            idTD.SubItems.Add(tenTD);
            listViewTrinhDo.Items.Add(idTD);
        }

        private void FillDataToForm()
        {
            foreach (var tt in app.GetDMTinhThanh())
            {
                AddLVTinh(tt.MaTinh, tt.TenTinh);
            }

            foreach (var tp in app.GetDMAllThanhPho())
            {
                AddLVThanhPho(tp.MaThanhPho, tp.TenThanhPho);
            }

            foreach (var dt in app.GetDMDanToc())
            {
                AddLVDanToc(dt.Id, dt.TenDanToc);
            }

            foreach (var td in app.GetDMTrinhDoHocVan())
            {
                AddLVTrinhDo(td.Id, td.TrinhDo);
            }
        }

        private void ThemChiMuc_Click(object sender, EventArgs e)
        {
            if (app.CheckPermissionAdd(Utilities.FUN_QuanLyChiMuc))
            {
                if (superTabCM.SelectedTab.Text == "DANH MỤC TỈNH")
                {
                    CMTinhThanh cmtt = new CMTinhThanh();
                    if (cmtt.ShowDialog() == DialogResult.OK)
                    {
                        cmDB.AddChiMucTinh(cmtt.GetMaTinh(), cmtt.GetTenTinhThanh());
                        AddLVTinh(cmtt.GetMaTinh(), cmtt.GetTenTinhThanh());

                        AlertUser();
                    }
                }
                else if (superTabCM.SelectedTab.Text == "DANH MỤC THÀNH PHỐ")
                {
                    CMThanhPho cmtp = new CMThanhPho();
                    if (cmtp.ShowDialog() == DialogResult.OK)
                    {
                        cmDB.AddChiMucThanhPho(cmtp.GetMaThanhPho(), cmtp.GetTenThanhPho());
                        AddLVThanhPho(cmtp.GetMaThanhPho(), cmtp.GetTenThanhPho());

                        AlertUser();
                    }
                }
                else if (superTabCM.SelectedTab.Text == "DANH MỤC DÂN TỘC")
                {
                    CMDanToc cmdt = new CMDanToc();
                    if (cmdt.ShowDialog() == DialogResult.OK)
                    {
                        int id = cmDB.AddChiMucDanToc(cmdt.GetTenDanToc());
                        AddLVDanToc(id, cmdt.GetTenDanToc());

                        AlertUser();
                    }
                }
                else if (superTabCM.SelectedTab.Text == "DANH MỤC TRÌNH ĐỘ HỌC VẤN")
                {
                    CMTrinhDo cmtd = new CMTrinhDo();
                    if (cmtd.ShowDialog() == DialogResult.OK)
                    {
                        int id = cmDB.AddChiMucTrinhDo(cmtd.GetTrinhDo());
                        AddLVTrinhDo(id, cmtd.GetTrinhDo());

                        AlertUser();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền với chức năng này");
            }
        }

        private void XoaChiMuc_Click(object sender, EventArgs e)
        {
            if (app.CheckPermissionDelete(Utilities.FUN_QuanLyChiMuc))
            {
                if (superTabCM.SelectedTab.Text == "DANH MỤC TỈNH")
                {
                    if (listViewTinh.SelectedItems.Count > 0)
                    {
                        var item = listViewTinh.SelectedItems[0];
                        cmDB.DeleteChiMucTinh(item.Text);
                        listViewTinh.Items.Remove(item);

                        AlertUser();
                    }
                }
                else if (superTabCM.SelectedTab.Text == "DANH MỤC THÀNH PHỐ")
                {
                    if (listViewThanhPho.SelectedItems.Count > 0)
                    {
                        var item = listViewThanhPho.SelectedItems[0];
                        cmDB.DeleteChiMucThanhPho(item.Text);
                        listViewThanhPho.Items.Remove(item);

                        AlertUser();
                    }
                }
                else if (superTabCM.SelectedTab.Text == "DANH MỤC DÂN TỘC")
                {
                    if (listViewDanToc.SelectedItems.Count > 0)
                    {
                        var item = listViewDanToc.SelectedItems[0];
                        cmDB.DeleteChiMucDanToc(Convert.ToInt32(item.Text));
                        listViewDanToc.Items.Remove(item);

                        AlertUser();
                    }
                }
                else if (superTabCM.SelectedTab.Text == "DANH MỤC TRÌNH ĐỘ HỌC VẤN")
                {
                    if (listViewTrinhDo.SelectedItems.Count > 0)
                    {
                        var item = listViewTrinhDo.SelectedItems[0];
                        cmDB.DeleteChiMucTrinhDo(Convert.ToInt32(item.Text));
                        listViewTrinhDo.Items.Remove(item);

                        AlertUser();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền với chức năng này");
            }
        }
    }
}
