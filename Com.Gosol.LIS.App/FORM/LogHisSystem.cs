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
using DevComponents.DotNetBar.SuperGrid;
using BVPS.Model;

namespace Com.Gosol.LIS.App.FORM
{
    public partial class LogHisSystem : UserControl
    {
        HisLogSystemDB db;

        public LogHisSystem(string conn)
        {
            db = new HisLogSystemDB(conn);
            InitializeComponent();

            LoadHisDB();
        }

        private void LoadHisDB()
        {
            GridPanel panel = hisLog.PrimaryGrid;
            panel.Rows.Clear();
            hisLog.BeginUpdate();
            List<HisLogInfor> hisLogs = db.GetListLog();
            foreach (var log in hisLogs)
            {
                object[] ob1 = new object[]
                    {
                    log.ThoiGian.ToString("dd-MM-yyyy"),log.NoiDung, log.UserName
                    };

                panel.Rows.Add(new GridRow(ob1));
            }

            hisLog.EndUpdate();
        }
    }
}
