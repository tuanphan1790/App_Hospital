using BVPS.DB.DBContext;
using BVPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.DB
{
    public class BaseBenhNhan
    {
        QuanLyFileDataContext dbFile;

        public BaseBenhNhan()
        {
            dbFile = new QuanLyFileDataContext();
        }

        public BaseBenhNhan(string con)
        {
            dbFile = new QuanLyFileDataContext(con);
        }

        public bool AddNewFile(int fileId, string fileName, string maBN)
        {
            List<dtb_patient_document> listFiles = (from s in dbFile.dtb_patient_documents select s).ToList();
            foreach (var x in listFiles)
            {
                if (x.file_name == fileName)
                    return false;
            }

            dtb_patient_document file = new dtb_patient_document();
            file.doc_id = fileId;
            file.file_name = fileName;
            file.patient_code = maBN;

            dbFile.dtb_patient_documents.InsertOnSubmit(file);
            dbFile.SubmitChanges();

            return true;
        }

        public void DeleteFile(string nameFile)
        {
            List<dtb_patient_document> listFiles = (from s in dbFile.dtb_patient_documents select s).ToList();
            foreach (var file in listFiles)
            {
                if (file.file_name == nameFile)
                {
                    dbFile.dtb_patient_documents.DeleteOnSubmit(file);
                    dbFile.SubmitChanges();
                }
            }
        }

        public List<HoSoLuuTru> GetHoSoLuuTru(string maBN)
        {
            List<HoSoLuuTru> hslts = new List<HoSoLuuTru>();

            List<dtb_patient_document> listFiles = (from s in dbFile.dtb_patient_documents select s).ToList();
            foreach (var file in listFiles)
            {
                if (file.patient_code == maBN)
                {
                    HoSoLuuTru hs = new HoSoLuuTru();
                    hs.Id = file.id;
                    hs.FileId = Convert.ToInt32(file.doc_id);
                    hs.FileName = file.file_name;
                    hs.MaBN = file.patient_code;

                    hslts.Add(hs);
                }
            }

            return hslts;
        }

        public Dictionary<int, LoaiHoSo> GetAllTenHoSo(bool isSperm)
        {
            Dictionary<int, LoaiHoSo> listHS = new Dictionary<int, LoaiHoSo>();
            foreach (var hs in (from s in dbFile.dtb_doc_types select s).ToList())
            {
                LoaiHoSo x = new LoaiHoSo();
                x.FileId = hs.id;
                x.TenHoSo = hs.doc_name;

                if (isSperm && (hs.doc_type == 1 | hs.doc_type == 2))
                {
                    listHS[Convert.ToInt32(hs.id)] = x;
                }
                else if (!isSperm && (hs.doc_type == 1 | hs.doc_type == 3))
                {
                    listHS[Convert.ToInt32(hs.id)] = x;
                }
            }

            return listHS;
        }
    }
}
