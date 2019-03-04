using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using OpenPop.Pop3;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using BVPS.DB;
using BVPS.Model;
using BVPS.Model.HoSoNguoiHienTinh;
using BVPS.Model.HoSoNguoiHienNoan;
using System.IO;

namespace DBLib
{
    public class DBServerApi
    {
        System.Timers.Timer TimerReadMail;
        SMTPSetting smtpSetting;
        Pop3Client popClient;

        BenhNhanHienTinhDB dbht;
        BenhNhanHienNoanDB dbhn;

        public DBServerApi(SMTPSetting smtpSetting)
        {
            this.smtpSetting = smtpSetting;
            popClient = new Pop3Client();
        }

        public double intervalRequest { set; get; }
        public string connectionString { set; get; }

        bool checkPopClientConnected = false;
        bool enableSSL;
        public void LoginPopServerMail()
        {
            if (!checkPopClientConnected)
            {
                this.enableSSL = smtpSetting.EnableSSL;
                if (!enableSSL)
                    popClient.Connect(smtpSetting.SmtpServer, smtpSetting.SmtpPort, enableSSL); //For no SSL     
                else
                {
                    if (smtpSetting.UseGmail)
                    {
                        // Doi voi Gmail mail ()
                        popClient.Connect("pop.gmail.com", 995, true);
                    }
                    else
                    {
                        // Doi voi Mercury mail ()
                        popClient.Connect(smtpSetting.SmtpServer, smtpSetting.SmtpPort, enableSSL, 3000, 3000, new RemoteCertificateValidationCallback(ValidateServerCertificate)); //For SSL 
                    }
                }

                popClient.Authenticate(smtpSetting.UserAddress, smtpSetting.Password, AuthenticationMethod.UsernameAndPassword);
                checkPopClientConnected = true;
            }
        }

        public bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            X509Certificate2 cert = new X509Certificate2(smtpSetting.CAPath);

            chain.Build(new X509Certificate2(certificate));

            if (chain.ChainElements[chain.ChainElements.Count - 1].Certificate.Thumbprint == cert.Thumbprint)
                return true;// success?

            return false;
        }

        public void StartTimerReadEmail()
        {
            dbht = new BenhNhanHienTinhDB(connectionString);
            dbhn = new BenhNhanHienNoanDB(connectionString);

            TimerReadMail = new System.Timers.Timer();
            TimerReadMail.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            TimerReadMail.Interval = intervalRequest;
            TimerReadMail.AutoReset = false;
            TimerReadMail.Start();
        }

        public void StopTimerReadMail()
        {
            DeleteAllMail();
            TimerReadMail.Stop();
        }

        void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            TimerReadMail.Stop();

            ReadMailFromPopServer();
            LoginPopServerMail();

            TimerReadMail.Start();
        }

        void ReadMailFromPopServer()
        {
            int messageCount = popClient.GetMessageCount();
            if (messageCount > 0)
            {
                for (int i = messageCount; i > 0; i--)
                {
                    string Sbj = popClient.GetMessage(i).Headers.Subject;
                    OpenPop.Mime.Message message = popClient.GetMessage(i);
                    //string message = message.FindFirstPlainTextVersion().GetBodyAsText();

                    if (Sbj == Utilities.Header_HT_ThongTinNguoiHien)
                    {
                        SaveMessageDB_HT_ThongTinBenhNhan(message);
                    }
                    else if (Sbj == Utilities.Header_HT_DacTrungNguoiHien)
                    {
                        SaveMessageDB_HT_DacTrungNH(message);
                    }
                    else if (Sbj == Utilities.Header_HT_KetQuaXetNghiem)
                    {
                        SaveMessageDB_HT_KQXN(message);
                    }
                    else if (Sbj == Utilities.Header_HT_KhamNamKhoa)
                    {
                        SaveMessageDB_HT_KhamNamKhoa(message);
                    }
                    else if (Sbj == Utilities.Header_HT_LuuTruMau)
                    {
                        SaveMessageDB_HT_LuuTruMau(message);
                    }
                    else if (Sbj == Utilities.Header_HT_NguoiQuanHe)
                    {
                        SaveMessageDB_HT_ThongTinNguoiQuanHeBN(message);
                    }
                    else if (Sbj == Utilities.Header_HT_NguoiVanDong)
                    {
                        SaveMessageDB_HT_NguoiVanDong(message);
                    }
                    else if (Sbj == Utilities.Header_HT_TinhDichDo)
                    {
                        SaveMessageDB_HT_TinhDichDo(message);
                    }



                    else if (Sbj == Utilities.Header_HN_ThongTinNguoiHien)
                    {
                        SaveMessageDB_HN_ThongTinBenhNhan(message);
                    }
                    else if (Sbj == Utilities.Header_HN_BenhTinhDuc)
                    {
                        SaveMessageDB_HN_BenhTinhDuc(message);
                    }
                    else if (Sbj == Utilities.Header_HN_BenhToanThan)
                    {
                        SaveMessageDB_HN_BenhToanThan(message);
                    }
                    else if (Sbj == Utilities.Header_HN_KetQuaXetNghiem)
                    {
                        SaveMessageDB_HN_KQXN(message);
                    }
                    else if (Sbj == Utilities.Header_HN_KhamHongVaXuongChau)
                    {
                        SaveMessageDB_HN_KhamHongVaXuongChau(message);
                    }
                    else if (Sbj == Utilities.Header_HN_NguoiVanDong)
                    {
                        SaveMessageDB_HN_NguoiVanDong(message);
                    }
                    else if (Sbj == Utilities.Header_HN_TienSuSinhSan)
                    {
                        SaveMessageDB_HN_TienSuSinhSan(message);
                    }
                    else if (Sbj == Utilities.Header_HN_TieuSuKinhNguyet)
                    {
                        SaveMessageDB_HN_TieuSuKinhNguyet(message);
                    }
                    else if (Sbj == Utilities.Header_HN_HoiBenh)
                    {
                        SaveMessageDB_HN_HoiBenh(message);
                    }
                }
            }

            DeleteAllMail();
        }

        void DeleteAllMail()
        {
            popClient.DeleteAllMessages();
            popClient.Disconnect();
            checkPopClientConnected = false;
        }

        void SaveFile(OpenPop.Mime.Message message)
        {
            foreach (var attachment in message.FindAllAttachments())
            {
                string filePath = Path.Combine(@"C:\Attachment", attachment.FileName);
                FileStream Stream = new FileStream(filePath, FileMode.Create);
                BinaryWriter BinaryStream = new BinaryWriter(Stream);
                BinaryStream.Write(attachment.Body);
                BinaryStream.Close();
            }
        }

        void SaveMessageDB_HT_ThongTinBenhNhan(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HT_ThongTinNguoiHienTinh bn = new HT_ThongTinNguoiHienTinh(xDoc);
                if (dbht.GetInformationPatient(bn.MaBN) == null)
                    dbht.AddNewPatient(bn);
                else
                    dbht.EditInformationPatient(bn.MaBN, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HT_DacTrungNH(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HT_DacTrungNguoiHien dt = new HT_DacTrungNguoiHien(xDoc);
                if (dbht.GetDacTrungByID(dt.Id) == null)
                    dbht.AddDacTrung(dt);
                else
                    dbht.EditDacTrung(dt.Id, dt);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HT_KQXN(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HT_KetQuaXetNghiem kq = new HT_KetQuaXetNghiem(xDoc);
                if (dbht.GetKetQuaXetNghiemByID(kq.Id) == null)
                    dbht.AddKetQuaXetNghiem(kq);
                else
                    dbht.EditKetQuaXetNghiem(kq.Id, kq);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HT_KhamNamKhoa(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HT_KhamNamKhoa knk = new HT_KhamNamKhoa(xDoc);
                if (dbht.GetKhamNamKhoaByID(knk.Id) == null)
                    dbht.AddKhamNamKhoa(knk);
                else
                    dbht.EditKhamNamKhoa(knk.Id, knk);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HT_LuuTruMau(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HT_LuuTruMau ltm = new HT_LuuTruMau(xDoc);
                if (dbht.GetLuuTruMauByID(ltm.Id) == null)
                    dbht.AddLuuTruMau(ltm);
                else
                    dbht.EditLuuTruMau(ltm.Id, ltm);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HT_NguoiVanDong(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HT_NguoiVanDong nvd = new HT_NguoiVanDong(xDoc);
                if (dbht.GetNguoiVanDongByID(nvd.Id) == null)
                    dbht.AddNguoiVanDong(nvd);
                else
                    dbht.EditNguoiVanDong(nvd.Id, nvd);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HT_ThongTinNguoiQuanHeBN(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HT_ThongTinNguoiQuanHeBN nqh = new HT_ThongTinNguoiQuanHeBN(xDoc);
                if (dbht.GetVoBNByID(nqh.Id) == null)
                    dbht.AddVoBN(nqh.MaBN, nqh);
                else
                    dbht.EditVoBN(nqh.Id, nqh);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HT_TinhDichDo(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HT_TinhDichDo tdd = new HT_TinhDichDo(xDoc);
                if (dbht.GetTinhDichDoByID(tdd.Id) == null)
                    dbht.AddTinhDichDo(tdd);
                else
                    dbht.EditTinhDichDo(tdd.Id, tdd);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void SaveMessageDB_HN_ThongTinBenhNhan(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_ThongTinNguoiHienNoan nh = new HN_ThongTinNguoiHienNoan(xDoc);
                if (dbhn.GetInformationPatient(nh.MaBN) == null)
                    dbhn.AddNewPatient(nh);
                else
                    dbhn.EditInformationPatient(nh.MaBN, nh);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HN_BenhTinhDuc(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_BenhTinhDuc bn = new HN_BenhTinhDuc(xDoc);
                if (dbhn.GetBenhTinhDucByID(bn.Id) == null)
                    dbhn.AddBenhTinhDuc(bn);
                else
                    dbhn.EditBenhTinhDuc(bn.Id, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HN_BenhToanThan(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_BenhToanThan bn = new HN_BenhToanThan(xDoc);
                if (dbhn.GetBenhToanThanByID(bn.Id) == null)
                    dbhn.AddBenhToanThan(bn);
                else
                    dbhn.EditBenhToanThan(bn.Id, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HN_KQXN(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_KetQuaXetNghiem bn = new HN_KetQuaXetNghiem(xDoc);
                if (dbhn.GetXetNghiemByID(bn.Id) == null)
                    dbhn.AddXetNghiem(bn);
                else
                    dbhn.EditXetNghiem(bn.Id, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HN_KhamHongVaXuongChau(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_KhamBenh bn = new HN_KhamBenh(xDoc);
                if (dbhn.GetChauHongByID(bn.Id) == null)
                    dbhn.AddChauHong(bn);
                else
                    dbhn.EditChauHong(bn.Id, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HN_NguoiVanDong(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_NguoiVanDong bn = new HN_NguoiVanDong(xDoc);
                if (dbhn.GetNguoiVanDongByID(bn.Id) == null)
                    dbhn.AddNguoiVanDong(bn);
                else
                    dbhn.EditNguoiVanDong(bn.Id, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HN_TienSuSinhSan(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_TienSuSinhSan bn = new HN_TienSuSinhSan(xDoc);
                if (dbhn.GetTienSuSinhSanByID(bn.Id) == null)
                    dbhn.AddTienSuSinhSan(bn);
                else
                    dbhn.EditTienSuSinhSan(bn.Id, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HN_TieuSuKinhNguyet(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_TieuSuKinhNguyet bn = new HN_TieuSuKinhNguyet(xDoc);
                if (dbhn.GetKinhNguyetByID(bn.Id) == null)
                    dbhn.AddKinhNguyet(bn);
                else
                    dbhn.EditKinhNguyet(bn.Id, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SaveMessageDB_HN_HoiBenh(OpenPop.Mime.Message message)
        {
            try
            {
                string mes = message.FindFirstPlainTextVersion().GetBodyAsText();

                XDocument xDoc = XDocument.Parse(mes);
                HN_HoiBenh bn = new HN_HoiBenh(xDoc);
                if (dbhn.GetHoiBenhByID(bn.Id) == null)
                    dbhn.AddHoiBenh(bn);
                else
                    dbhn.EditHoiBenh(bn.Id, bn);

                SaveFile(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
