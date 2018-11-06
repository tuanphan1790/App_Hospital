using BVPS.App;
using BVPS.DB;
using BVPS.Model;
using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.Gosol.LIS.App.FORM
{
    public partial class QuanLyBenhNhanNhanMau : Form
    {
        AppsLIST app;
        QuanLyNguoiNhanDB dbQL;

        List<HT_ThongTinNguoiHienTinh> listNHTs;
        List<HN_ThongTinNguoiHienNoan> listNHNs;
        GridPanel panel;

        public QuanLyBenhNhanNhanMau(AppsLIST app)
        {
            InitializeComponent();

            this.app = app;
            listNHTs = new List<HT_ThongTinNguoiHienTinh>();
            listNHNs = new List<HN_ThongTinNguoiHienNoan>();

            panel = QL_sgQuanLyNguoiNhan.PrimaryGrid;

            LoadItemSelect();

            dbQL = new QuanLyNguoiNhanDB();

            FillData();
        }

        private void FillData()
        {
            List<QuanLyNguoiNhanMau> hosos = dbQL.GetAllNguoiNhanMau();
            panel.Rows.Clear();
            panel.DataSource = hosos;
        }

        private void xóaThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = QL_sgQuanLyNguoiNhan.ActiveRow.RowIndex;
            GridCell gridCell = QL_sgQuanLyNguoiNhan.GetCell(rowIndex, 0);

            if (gridCell == null | Convert.ToInt32(gridCell.Value) == 0)
                return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hồ sơ này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                dbQL.DeleteNguoiNhanMau(Convert.ToInt32(gridCell.Value));
                FillData();
            }
        }

        private void LoadItemSelect()
        {
            BenhNhanHienNoanDB dbhn = new BenhNhanHienNoanDB();
            listNHNs = dbhn.GetAllNguoiHienNoan();

            BenhNhanHienTinhDB dbht = new BenhNhanHienTinhDB();
            listNHTs = dbht.GetAllNguoiHienTinh();

            var cboMaBN = (GridComboBoxExEditControl)panel.Columns[1].EditControl;

            foreach (var bn in listNHTs)
            {
                cboMaBN.Items.Add(bn.MaBN);
            }
        }

        private void QL_sgQuanLyNguoiNhan_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            if (e.GridCell.GridRow["PheDuyet"].Value != null | e.GridCell.GridRow["NgayLuuTru"].Value != null)
            {
                if (!e.GridCell.GridColumn.AllowEdit)
                    return;
            }

            var maBN = e.GridCell.GridRow["MaMau"].Value;
            if (maBN == null)
            {
                MessageBox.Show("Bạn cần nhập mã bệnh nhân hiến trước khi làm tiếp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                foreach (var bn in listNHTs)
                {
                    if ((string)maBN == bn.MaBN)
                    {
                        e.GridCell.GridRow["PheDuyet"].Value = bn.FlagApprove;
                        e.GridCell.GridRow["NgayLuuTru"].Value = bn.NgayTao;
                    }
                }

                var id = e.GridCell.GridRow["Id"].Value;
                if (id == null | Convert.ToInt32(id) == 0)
                {
                    QuanLyNguoiNhanMau bn = new QuanLyNguoiNhanMau();
                    bn.MaMau = Convert.ToString(maBN);

                    var pheduyet = e.GridCell.GridRow["PheDuyet"].Value;
                    bn.PheDuyet = Convert.ToBoolean(pheduyet);

                    var ngayluutru = e.GridCell.GridRow["NgayLuuTru"].Value;
                    bn.NgayLuuTru = Convert.ToDateTime(ngayluutru);

                    var ngaysudung = e.GridCell.GridRow["NgaySuDung"].Value;
                    bn.NgaySuDung = Convert.ToDateTime(ngaysudung);

                    var manguoinhan = e.GridCell.GridRow["MaNguoiNhan"].Value;
                    bn.MaNguoiNhan = Convert.ToString(manguoinhan);

                    var ketqua = e.GridCell.GridRow["KetQuaSuDung"].Value;
                    bn.KetQuaSuDung = Convert.ToString(ketqua);

                    var huymau = e.GridCell.GridRow["HuyMau"].Value;
                    bn.HuyMau = Convert.ToBoolean(huymau);

                    var ngayhuymau = e.GridCell.GridRow["NgayHuyMau"].Value;
                    bn.NgayHuyMau = Convert.ToDateTime(ngayhuymau);

                    var ghichu = e.GridCell.GridRow["GhiChu"].Value;
                    bn.GhiChu = Convert.ToString(ghichu);

                    dbQL.AddNguoiNhanMau(bn);
                    FillData();
                }
                else
                {
                    QuanLyNguoiNhanMau bn = dbQL.GetNguoiNhanById(Convert.ToInt32(id));
                    bn.MaMau = Convert.ToString(maBN);

                    var pheduyet = e.GridCell.GridRow["PheDuyet"].Value;
                    bn.PheDuyet = Convert.ToBoolean(pheduyet);

                    var ngayluutru = e.GridCell.GridRow["NgayLuuTru"].Value;
                    bn.NgayLuuTru = Convert.ToDateTime(ngayluutru);

                    var ngaysudung = e.GridCell.GridRow["NgaySuDung"].Value;
                    bn.NgaySuDung = Convert.ToDateTime(ngaysudung);

                    var manguoinhan = e.GridCell.GridRow["MaNguoiNhan"].Value;
                    bn.MaNguoiNhan = Convert.ToString(manguoinhan);

                    var ketqua = e.GridCell.GridRow["KetQuaSuDung"].Value;
                    bn.KetQuaSuDung = Convert.ToString(ketqua);

                    var huymau = e.GridCell.GridRow["HuyMau"].Value;
                    bn.HuyMau = Convert.ToBoolean(huymau);

                    var ngayhuymau = e.GridCell.GridRow["NgayHuyMau"].Value;
                    bn.NgayHuyMau = Convert.ToDateTime(ngayhuymau);

                    var ghichu = e.GridCell.GridRow["GhiChu"].Value;
                    bn.GhiChu = Convert.ToString(ghichu);

                    dbQL.EditNguoiNhanMau(Convert.ToInt32(id), bn);
                    FillData();
                }
            }
        }
    }
}
