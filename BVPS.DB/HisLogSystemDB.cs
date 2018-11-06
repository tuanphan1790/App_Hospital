using BVPS.DB.DBContext;
using BVPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.DB
{
    public class HisLogSystemDB
    {
        LogHisSystemDataContext db;

        public HisLogSystemDB()
        {
            db = new LogHisSystemDataContext();
        }

        public HisLogSystemDB(string conn)
        {
            db = new LogHisSystemDataContext(conn);
        }

        public List<HisLogInfor> GetListLog()
        {
            List<HisLogInfor> hisLogs = new List<HisLogInfor>();

            var lists = (from s in db.dtb_logs select s).ToList();
            foreach(var h in lists)
            {
                HisLogInfor x = new HisLogInfor();
                x.Id = h.id;
                x.ThoiGian = Convert.ToDateTime(h.create_date);
                x.NoiDung = h.action;
                x.UserName = h.username;
                hisLogs.Add(x);
            }

            return hisLogs;
        }

        public bool AddLog(HisLogInfor log, ref string mes)
        {
            try
            {
                dtb_log _log = new dtb_log();
                _log.username = log.UserName;
                _log.action = log.NoiDung;
                _log.create_date = log.ThoiGian;

                db.dtb_logs.InsertOnSubmit(_log);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                return false;
            }
        }

    }
}
