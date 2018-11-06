using libzkfpcsharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.App
{
    public class Utilities
    {
        public const int FUN_BNHT_KhamNamKhoa = 1;
        public const int FUN_BNHT_DanhSachVoBN = 2;
        public const int FUN_BNHT_DacTrungBenhNhan = 3;
        public const int FUN_BNHT_TinhDichDo = 4;
        public const int FUN_BNHT_KetQuaXetNghiem = 5;
        public const int FUN_BNHT_NguoiVanDong = 6;
        public const int FUN_BNHT_LuuTruMau = 7;
        public const int FUN_HNHT_QuanLyThongTinChungBNHT = 16;

        public const int FUN_BNHN_TienSuSinhSan = 8;
        public const int FUN_BNHN_KetQuaXetNghiem = 9;
        public const int FUN_BNHN_TieuSuKinhNguyet = 10;
        public const int FUN_BNHN_KhamBenh = 11;
        public const int FUN_BNHN_NguoiVanDong = 12;
        public const int FUN_BNHN_BenhToanThan = 13;
        public const int FUN_BNHN_BenhTinhDuc = 14;
        public const int FUN_BNHN_HoiBenh = 20; //Moi Add
        public const int FUN_HNHN_QuanLyThongTinChungBNHN = 15;

        public const int FUN_HSBN_PheDuyetHoSo = 17;
        public const int FUN_QuanLyChiMuc = 18;       

        public static string BitmapToBase64String(Bitmap bmp, ImageFormat imageFormat)
        {
            string base64String = string.Empty;

            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            base64String = Convert.ToBase64String(byteBuffer);
            byteBuffer = null;


            return base64String;
        }

        public static Bitmap Base64StringToBitmap(string base64String)
        {
            if (base64String == null)
                return null;

            Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }

        public static string FileToBase64String(string inputFile)
        {
            if (!string.IsNullOrEmpty(inputFile))
            {
                FileStream fs = new FileStream(inputFile,
                                               FileMode.Open,
                                               FileAccess.Read);
                byte[] filebytes = new byte[fs.Length];
                fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                return Convert.ToBase64String(filebytes, Base64FormattingOptions.InsertLineBreaks);
            }

            return "";
        }

        public static void FileToBase64String(string outputFile, string strEncoded)
        {
            if (!string.IsNullOrEmpty(outputFile))
            {
                byte[] filebytes = Convert.FromBase64String(strEncoded);
                FileStream fs = new FileStream(outputFile,
                                               FileMode.CreateNew,
                                               FileAccess.Write,
                                               FileShare.None);
                fs.Write(filebytes, 0, filebytes.Length);
                fs.Close();
            }
        }

        public static string GenMaUnixTime(string codeTTHTSS)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return (unixTimestamp.ToString() + codeTTHTSS);
        }

        public static Dictionary<string, byte[]> ConvertDic(Dictionary<string, string> listDecodes)
        {
            Dictionary<string, byte[]> dicRTs = new Dictionary<string, byte[]>();
            foreach (var x in listDecodes)
            {
                if (x.Value != null)
                {
                    byte[] y = zkfp.Base64String2Blob(x.Value);
                    dicRTs.Add(x.Key, y);
                }
            }

            return dicRTs;
        }
    }
}
