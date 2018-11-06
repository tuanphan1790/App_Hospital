using BVPS.Model.ChiMuc;
using BVPS.ServiceCheckFPForm.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.ServiceCheckFPForm
{
    class DBModel
    {
        InformationDataContext db;
        byte[] CapTmp = new byte[2048];

        IntPtr mDBHandle;

        public DBModel(string conn)
        {
            db = new InformationDataContext(conn);
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
                dm.Add(x);
            }

            return dm;
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

        public List<string> FPDecodeBlobs()
        {
            List<string> RTs = new List<string>();
            foreach (var fp in db.dtb_sperm_sends)
            {
                if (fp.FPNgonCaiPhai != null)
                    RTs.Add(fp.FPNgonCaiPhai);

                if (fp.FPNgonCaiTrai != null)
                    RTs.Add(fp.FPNgonCaiTrai);

                if (fp.FPNgonTroPhai != null)
                    RTs.Add(fp.FPNgonTroPhai);

                if (fp.FPNgonTroTrai != null)
                    RTs.Add(fp.FPNgonTroTrai);
            }

            foreach (var fp in db.dtb_patien_ovule_sends)
            {
                if (fp.FPNgonCaiPhai != null)
                    RTs.Add(fp.FPNgonCaiPhai);

                if (fp.FPNgonCaiTrai != null)
                    RTs.Add(fp.FPNgonCaiTrai);

                if (fp.FPNgonTroPhai != null)
                    RTs.Add(fp.FPNgonTroPhai);

                if (fp.FPNgonTroTrai != null)
                    RTs.Add(fp.FPNgonTroTrai);
            }

            return RTs;
        }
    }
}
