using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncMailClient
{
    public partial class ChooseFileUpload : Form
    {
        public ChooseFileUpload()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public bool Get_HT_ThongTinCoBan() { return HT_ThongTinBN.Checked; }
        public bool Get_HT_ThongTinVoBN() { return HT_ThongTinVoBN.Checked; }
        public bool Get_HT_ThongTinNVD() { return HT_ThongTinNVD.Checked; }
        public bool Get_HT_KhamNamKhoa() { return HT_KhamNamKhoa.Checked; }
        public bool Get_HT_TinhDichDo() { return HT_TinhDichDo.Checked; }
        public bool Get_HT_KetQuaXN() { return HT_KetQuaXN.Checked; }
        public bool Get_HT_DacTrungNH() { return HT_DacTrungNguoiHien.Checked; }
        public bool Get_HT_LuuTruMau() { return HT_LuuTruMau.Checked; }

        public bool Get_HN_ThongTinCoBan() { return HN_ThongTinBN.Checked; }
        public bool Get_HN_ThongTinNVD() { return HN_ThongTinNVD.Checked; }
        public bool Get_HN_KhamHongXuongChau() { return HN_KhamBenh.Checked; }
        public bool Get_HN_KhamTienSuSinhSan() { return HN_TienSuSS.Checked; }
        public bool Get_HN_KhamTieuSuKN() { return HN_TieuSuKN.Checked; }
        public bool Get_HN_KetQuaXN() { return HN_KetQuaXN.Checked; }
        public bool Get_HN_BenhToanThan() { return HN_BenhToanThan.Checked; }
        public bool Get_HN_BenhTinhDuc() { return HN_BenhTinhDuc.Checked; }
        public bool Get_HN_HoiBenh() { return HN_HoiBenh.Checked; }
    }
}
