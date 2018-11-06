using BVPS.App;
using BVPS.DB;
using BVPS.Model.ChiMuc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.Gosol.LIS.App.FORM
{
    public partial class ConnectDBTT : Form
    {
        AppsLIST app;
        UrlTrungTam trungtam;
        ChiMucDB db;

        public ConnectDBTT(AppsLIST app, ChiMucDB db)
        {
            this.app = app;
            this.db = db;
            InitializeComponent();

            UrlTrungTam tt = db.GetUrlTrungTam();
            if (tt != null)
            {
                this.trungtam = tt;
                LoadDataDB();
            }
        }

        private void LoadDataDB()
        {
            txtURL.Text = trungtam.Url;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.trungtam != null)
                db.EditUrlWebService(txtURL.Text);
            else
                db.AddUrlWebService(txtURL.Text);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
