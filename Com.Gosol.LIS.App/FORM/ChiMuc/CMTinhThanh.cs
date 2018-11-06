using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.Gosol.LIS.App.FORM.ChiMuc
{
    public partial class CMTinhThanh : Form
    {
        public CMTinhThanh()
        {
            InitializeComponent();
        }

        public string GetTenTinhThanh()
        {
            return txtTenTinh.Text;
        }

        public string GetMaTinh()
        {
            return txtMaTinh.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
