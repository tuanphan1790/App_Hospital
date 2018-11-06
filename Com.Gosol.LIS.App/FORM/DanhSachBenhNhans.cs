using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVPS.DB;
using BVPS.Model.ChiMuc;
using BVPS.App;
using DevComponents.DotNetBar.SuperGrid;
using BVPS.Model;

namespace Com.Gosol.LIS.App.FORM
{
    public enum TypeBN
    {
        BNHienTinh,
        BNHienNoan
    }

    public partial class DanhSachBenhNhans : UserControl
    {
        TypeBN type;

        BenhNhanHienTinhDB dbHT;
        BenhNhanHienNoanDB dbHN;

        AppsLIST appList;
        public DanhSachBenhNhans(TypeBN type, AppsLIST app)
        {
            this.type = type;
            this.appList = app;

            InitializeComponent();

            dbHN = new BenhNhanHienNoanDB(app.connString);
            dbHT = new BenhNhanHienTinhDB(app.connString);

            LoadChiMuc();

            switch (type)
            {
                case TypeBN.BNHienTinh:
                    {
                        LoadDataBNHT();
                        break;
                    }
                case TypeBN.BNHienNoan:
                    {
                        LoadDataBNHN();
                        break;
                    }
            }
        }

        List<DMTinhThanh> dmtt;
        List<DMThanhPho> dmtp;

        private void LoadChiMuc()
        {
            dmtt = appList.GetDMTinhThanh();
            cboTinhThanh.DataSource = dmtt;
            cboTinhThanh.Text = "";

            dmtp = appList.GetDMAllThanhPho();
        }

        private void LoadDataBNHT()
        {
            GridPanel panel = dsbn.PrimaryGrid;
            panel.Rows.Clear();
            dsbn.BeginUpdate();
            List<HT_ThongTinNguoiHienTinh> nhts = dbHT.GetAllNguoiHienTinh();
            foreach (var bn in nhts)
            {
                object[] ob1 = new object[]
                    {
                    bn.MaBN,bn.HoVaTen,RTTenTinh(bn.Tinh_ThanhPho),bn.SoCMND,bn.NgaySinh.ToString("dd-MM-yyyy"),bn.SoDienThoai, bn.FlagApprove
                    };

                panel.Rows.Add(new GridRow(ob1));
            }

            dsbn.EndUpdate();
        }

        private void LoadDataBNHN()
        {
            GridPanel panel = dsbn.PrimaryGrid;
            panel.Rows.Clear();
            dsbn.BeginUpdate();
            List<HN_ThongTinNguoiHienNoan> nhts = dbHN.GetAllNguoiHienNoan();
            foreach (var bn in nhts)
            {
                object[] ob1 = new object[]
                    {
                    bn.MaBN,bn.HoVaTen,RTTenTinh(bn.Tinh_ThanhPho),bn.SoCMND,bn.NgaySinh.ToString("dd-MM-yyyy"),bn.SoDienThoai, bn.FlagApprove
                    };

                panel.Rows.Add(new GridRow(ob1));
            }

            dsbn.EndUpdate();
        }

        private string GetMaBenhNhan()
        {
            int rowIndex = dsbn.ActiveRow.RowIndex;
            GridCell gridCell = dsbn.GetCell(rowIndex, 0);
            if (gridCell == null)
                return null;

            return gridCell.Value.ToString();
        }

        private void XemChiTiet_Click(object sender, EventArgs e)
        {
            string MBN = GetMaBenhNhan();
            if (MBN == null)
                return;

            switch (type)
            {
                case TypeBN.BNHienTinh:
                    {
                        if (appList.CheckPermissionView(Utilities.FUN_HNHT_QuanLyThongTinChungBNHT))
                        {
                            HT_ThongTinNguoiHienTinh nht = dbHT.GetInformationPatient(MBN);
                            appList.SetControlBNHT(nht);
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền xem thông tin bệnh nhân");
                        }
                        break;
                    }
                case TypeBN.BNHienNoan:
                    {
                        if (appList.CheckPermissionView(Utilities.FUN_HNHT_QuanLyThongTinChungBNHT))
                        {
                            HN_ThongTinNguoiHienNoan nhn = dbHN.GetInformationPatient(MBN);
                            appList.SetControlBNHN(nhn);
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền xem thông tin bệnh nhân");
                        }
                        break;
                    }
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            string MBN = GetMaBenhNhan();
            if (MBN == null)
                return;

            switch (type)
            {
                case TypeBN.BNHienTinh:
                    {
                        if (dbHT.CheckPatientApprove(MBN))
                        {
                            MessageBox.Show("Bệnh nhân đã được phê duyệt nên không được xóa hồ sơ");
                            return;
                        }

                        if (appList.CheckPermissionDelete(Utilities.FUN_HNHT_QuanLyThongTinChungBNHT))
                        {
                            DialogResult ret = MessageBox.Show("Bạn có chắc chắn muốn xóa bệnh nhân này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ret == DialogResult.Yes)
                            {
                                appList.SetHisOperate("Người dùng xóa hồ sơ bệnh nhân hiến tinh MBN = " + MBN);
                                dbHT.DeleteInformationPatient(MBN);
                                LoadDataBNHT();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền xóa thông tin bệnh nhân");
                        }
                        break;
                    }
                case TypeBN.BNHienNoan:
                    {
                        if (dbHN.CheckPatientApprove(MBN))
                        {
                            MessageBox.Show("Bệnh nhân đã được phê duyệt nên không được xóa hồ sơ");
                            return;
                        }

                        if (appList.CheckPermissionDelete(Utilities.FUN_HNHN_QuanLyThongTinChungBNHN))
                        {
                            DialogResult ret = MessageBox.Show("Bạn có chắc chắn muốn xóa bệnh nhân này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (ret == DialogResult.Yes)
                            {
                                appList.SetHisOperate("Người dùng xóa hồ sơ bệnh nhân hiến noãn MBN = " + MBN);
                                dbHN.DeleteInformationPatient(MBN);
                                LoadDataBNHN();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền xóa thông tin bệnh nhân");
                        }
                        break;
                    }
            }


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case TypeBN.BNHienTinh:
                    {
                        if (appList.CheckPermissionAdd(Utilities.FUN_HNHT_QuanLyThongTinChungBNHT))
                        {
                            appList.SetControlBNHT(null);
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền tạo hồ sơ bệnh nhân mới");
                        }
                        break;
                    }
                case TypeBN.BNHienNoan:
                    {
                        if (appList.CheckPermissionView(Utilities.FUN_HNHT_QuanLyThongTinChungBNHT))
                        {
                            appList.SetControlBNHN(null);
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền tạo hồ sơ bệnh nhân mới");
                        }
                        break;
                    }
            }
        }

        private string RTTenTinh(string maTinh)
        {
            string tinhThanh = "";
            foreach (var t in dmtt)
            {
                if (t.MaTinh == maTinh)
                    tinhThanh = t.TenTinh;
            }

            return tinhThanh;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            GridPanel panel = dsbn.PrimaryGrid;
            panel.Rows.Clear();

            switch (type)
            {
                case TypeBN.BNHienTinh:
                    {
                        List<HT_ThongTinNguoiHienTinh> nhts = dbHT.GetAllNguoiHienTinh();
                        List<HT_ThongTinNguoiHienTinh> nhtsBeforeFilters = GetPatientAfterFilter(nhts);

                        dsbn.BeginUpdate();
                        foreach (var bn in nhtsBeforeFilters)
                        {
                            object[] ob1 = new object[]
                                {
                                    bn.MaBN,bn.HoVaTen,RTTenTinh(bn.Tinh_ThanhPho),bn.SoCMND,bn.NgaySinh.ToString("dd-MM-yyyy"),bn.SoDienThoai
                                };

                            panel.Rows.Add(new GridRow(ob1));
                        }
                        dsbn.EndUpdate();

                        break;
                    }
                case TypeBN.BNHienNoan:
                    {
                        List<HN_ThongTinNguoiHienNoan> nhns = dbHN.GetAllNguoiHienNoan();
                        List<HN_ThongTinNguoiHienNoan> nhtsBeforeFilters = GetPatientAfterFilter(nhns);

                        dsbn.BeginUpdate();
                        foreach (var bn in nhtsBeforeFilters)
                        {
                            object[] ob1 = new object[]
                                {
                                    bn.MaBN,bn.HoVaTen,RTTenTinh(bn.Tinh_ThanhPho),bn.SoCMND,bn.NgaySinh.ToString("dd-MM-yyyy"),bn.SoDienThoai
                                };

                            panel.Rows.Add(new GridRow(ob1));
                        }
                        dsbn.EndUpdate();

                        break;
                    }
            }
        }

        private List<HT_ThongTinNguoiHienTinh> GetPatientAfterFilter(List<HT_ThongTinNguoiHienTinh> listBefore)
        {
            List<HT_ThongTinNguoiHienTinh> list = new List<HT_ThongTinNguoiHienTinh>();

            foreach (var bn in listBefore)
                if (cboTinhThanh.Text != "")
                {
                    if (txtSoCMND.Text != "")
                    {
                        if (bn.Tinh_ThanhPho == cboTinhThanh.SelectedValue.ToString() && bn.SoCMND == txtSoCMND.Text)
                            list.Add(bn);
                    }
                    else
                    {
                        if (bn.Tinh_ThanhPho == cboTinhThanh.SelectedValue.ToString())
                            list.Add(bn);
                    }
                }
                else
                {
                    if (txtSoCMND.Text != "")
                    {
                        if (bn.SoCMND == txtSoCMND.Text)
                            list.Add(bn);
                    }
                }

            return list;
        }

        private List<HN_ThongTinNguoiHienNoan> GetPatientAfterFilter(List<HN_ThongTinNguoiHienNoan> listBefore)
        {
            List<HN_ThongTinNguoiHienNoan> list = new List<HN_ThongTinNguoiHienNoan>();

            foreach (var bn in listBefore)
                if (cboTinhThanh.Text != "")
                {
                    if (txtSoCMND.Text != "")
                    {
                        if (bn.Tinh_ThanhPho == cboTinhThanh.SelectedValue.ToString() && bn.SoCMND == txtSoCMND.Text)
                            list.Add(bn);
                    }
                    else
                    {
                        if (bn.Tinh_ThanhPho == cboTinhThanh.SelectedValue.ToString())
                            list.Add(bn);
                    }
                }
                else
                {
                    if (txtSoCMND.Text != "")
                    {
                        if (bn.SoCMND == txtSoCMND.Text)
                            list.Add(bn);
                    }
                }

            return list;
        }
    }
}
