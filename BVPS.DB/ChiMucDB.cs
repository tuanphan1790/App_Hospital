using BVPS.DB.DBContext;
using BVPS.Model.ChiMuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.DB
{
    public class ChiMucDB
    {
        ChiMucDataContext db;

        public ChiMucDB()
        {
            db = new ChiMucDataContext();
        }

        public ChiMucDB(string conn)
        {
            db = new ChiMucDataContext(conn);
        }

        public void AddChiMucTinh(string provinceCode, string provinceName)
        {
            dtb_province x = new dtb_province();
            x.province_code = provinceCode;
            x.province_name = provinceName;

            db.dtb_provinces.InsertOnSubmit(x);
            db.SubmitChanges();
        }

        public List<DMTinhThanh> GetDMTinhThanh()
        {
            List<DMTinhThanh> dm = new List<DMTinhThanh>();
            List<dtb_province> listDMs = (from s in db.dtb_provinces select s).ToList();

            foreach (var d in listDMs)
            {
                DMTinhThanh x = new DMTinhThanh();
                x.Id = d.id;
                x.MaTinh = d.province_code;
                x.TenTinh = d.province_name;
                dm.Add(x);
            }

            return dm;
        }

        public void DeleteChiMucTinh(string provideCode)
        {
            dtb_province f = db.dtb_provinces.Where(s => s.province_code == provideCode).Single();
            if (f == null)
                return;

            db.dtb_provinces.DeleteOnSubmit(f);
            db.SubmitChanges();
        }

        public void AddChiMucThanhPho(string districtCode, string districtName)
        {
            dtb_district x = new dtb_district();
            x.district_code = districtCode;
            x.district_name = districtName;

            db.dtb_districts.InsertOnSubmit(x);
            db.SubmitChanges();
        }

        public List<DMThanhPho> GetDMThanhPho()
        {
            List<DMThanhPho> dm = new List<DMThanhPho>();
            List<dtb_district> listDMs = (from s in db.dtb_districts select s).ToList();

            foreach (var d in listDMs)
            {
                DMThanhPho x = new DMThanhPho();
                x.Id = d.id;
                x.MaThanhPho = d.district_code;
                x.TenThanhPho = d.district_name;
                x.MaTinh = d.province_code;
                dm.Add(x);
            }

            return dm;
        }

        public void DeleteChiMucThanhPho(string districtCode)
        {
            dtb_district f = db.dtb_districts.Where(s => s.district_code == districtCode).Single();
            if (f == null)
                return;

            db.dtb_districts.DeleteOnSubmit(f);
            db.SubmitChanges();
        }

        public int AddChiMucDanToc(string className)
        {
            dtb_class x = new dtb_class();
            x.name = className;

            db.dtb_classes.InsertOnSubmit(x);
            db.SubmitChanges();

            return x.id;
        }

        public List<DMDanToc> GetDMDanToc()
        {
            List<DMDanToc> dm = new List<DMDanToc>();
            List<dtb_class> listDMs = (from s in db.dtb_classes select s).ToList();

            foreach (var d in listDMs)
            {
                DMDanToc x = new DMDanToc();
                x.Id = d.id;
                x.TenDanToc = d.name;
                dm.Add(x);
            }

            return dm;
        }

        public void DeleteChiMucDanToc(int id)
        {
            dtb_class f = db.dtb_classes.Where(s => s.id == id).Single();
            if (f == null)
                return;

            db.dtb_classes.DeleteOnSubmit(f);
            db.SubmitChanges();
        }

        public int AddChiMucTrinhDo(string levelName)
        {
            dtb_level x = new dtb_level();
            x.name = levelName;

            db.dtb_levels.InsertOnSubmit(x);
            db.SubmitChanges();

            return x.id;
        }

        public List<DMTrinhDoHocVan> GetDMTrinhDoHocVan()
        {
            List<DMTrinhDoHocVan> dm = new List<DMTrinhDoHocVan>();
            List<dtb_level> listDMs = (from s in db.dtb_levels select s).ToList();

            foreach (var d in listDMs)
            {
                DMTrinhDoHocVan x = new DMTrinhDoHocVan();
                x.Id = d.id;
                x.TrinhDo = d.name;
                dm.Add(x);
            }

            return dm;
        }

        public void DeleteChiMucTrinhDo(int id)
        {
            dtb_level f = db.dtb_levels.Where(s => s.id == id).Single();
            if (f == null)
                return;

            db.dtb_levels.DeleteOnSubmit(f);
            db.SubmitChanges();
        }

        public void SetTrungTamHTSS(TrungTamHTSS tthtss)
        {
            dtb_profile tt = new dtb_profile();
            tt.name = tthtss.TenTrungTam;
            tt.email = tthtss.Email;
            tt.address = tthtss.DiaChi;
            tt.phone = tthtss.SoDienThoai;
            tt.website = tthtss.Website;
            tt.code = tthtss.MaTTHTSS;

            db.dtb_profiles.InsertOnSubmit(tt);
            db.SubmitChanges();
        }

        public TrungTamHTSS GetTrungTamHTSS()
        {
            if (db.dtb_profiles.Any())
            {
                dtb_profile tt = (from s in db.dtb_profiles select s).ToList()[0];
                TrungTamHTSS tthtss = new TrungTamHTSS();
                tthtss.Id = tt.id;
                tthtss.TenTrungTam = tt.name;
                tthtss.Email = tt.email;
                tthtss.DiaChi = tt.address;
                tthtss.SoDienThoai = tt.phone;
                tthtss.Website = tt.website;
                tthtss.MaTTHTSS = tt.code;

                return tthtss;
            }
            else
            {
                return null;
            }
        }

        public void EditTrungTamHTSS(int id, TrungTamHTSS tthtss)
        {
            List<dtb_profile> listTTs = (from s in db.dtb_profiles select s).ToList();
            foreach (var tt in listTTs)
            {
                if (tt.id == id)
                {
                    tt.name = tthtss.TenTrungTam;
                    tt.email = tthtss.Email;
                    tt.address = tthtss.DiaChi;
                    tt.phone = tthtss.SoDienThoai;
                    tt.website = tthtss.Website;
                    tt.code = tthtss.MaTTHTSS;

                    db.SubmitChanges();
                }
            }
        }

        public void AddUrlWebService(string url)
        {
            dtb_url_web_service x = new dtb_url_web_service();
            x.url = url;

            db.dtb_url_web_services.InsertOnSubmit(x);
            db.SubmitChanges();
        }

        public void EditUrlWebService(string url)
        {
            dtb_url_web_service x = db.dtb_url_web_services.First();
            x.url = url;

            db.SubmitChanges();
        }

        public UrlTrungTam GetUrlTrungTam()
        {
            if (db.dtb_url_web_services.Any())
            {
                dtb_url_web_service tt = db.dtb_url_web_services.First();
                UrlTrungTam x = new UrlTrungTam();
                x.Id = tt.id;
                x.Url = tt.url;
                return x;
            }

            return null;
        }
    }
}
