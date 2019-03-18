using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using BVPS.DB;
using BVPS.Model;
using BVPS.Model.HoSoNguoiHienTinh;
using BVPS.Model.HoSoNguoiHienNoan;

namespace DBLib
{
    public class DBClientApi
    {
        string tthtssName;

        BenhNhanHienNoanDB bnhnDB;
        BenhNhanHienTinhDB bnhtDB;

        System.Timers.Timer TimerReadDB;

        SMTPSetting smtpSetting;
        SmtpClient mailClient;

        SettingChooseFile setting;

        public DBClientApi(string tthtssName, SMTPSetting smtpSetting, SettingChooseFile setting)
        {
            this.setting = setting;

            this.tthtssName = tthtssName;
            this.smtpSetting = smtpSetting;
        }

        public double intervalRequest { set; get; }
        public string connectionString { set; get; }

        public void LoginMailServer()
        {
            #region example
            /*try
            //{
            //    // Create instance of message
            //    MailMessage message = new MailMessage();

            //    // Add receiver
            //    message.To.Add("tuanpa.bkhn@gmail.com");

            //    // Set sender
            //    // In this case the same as the username
            //    message.From = new MailAddress("tuangerrard@gmail.com");

            //    // Set subject
            //    message.Subject = "Test";

            //    // Set body of message
            //    message.Body = "En test besked";

            //    // Send the message
            //    mailClient.Send(message);

            //    // Clean up
            //    message = null;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Could not send e-mail. Exception caught: " + e);
            //} */
            #endregion

            //Smtp with gmail
            if (smtpSetting.EnableSSL && smtpSetting.UseGmail)
            {
                mailClient = new SmtpClient("smtp.gmail.com", 587);
                mailClient.EnableSsl = true;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = new NetworkCredential(smtpSetting.UserAddress, smtpSetting.Password);

                return;
            }

            //Smtp with Mercury
            if (smtpSetting.EnableSSL && !smtpSetting.UseGmail)
            {
                mailClient = new SmtpClient(smtpSetting.SmtpServer, smtpSetting.SmtpPort) // port 25 is no security
                {
                    Credentials = new NetworkCredential(smtpSetting.UserAddress, smtpSetting.Password),
                    EnableSsl = smtpSetting.EnableSSL,
                };

                if (!smtpSetting.UseGmail)
                {
                    if (smtpSetting.EnableSSL)
                    {
                        X509Certificate2 cert = new X509Certificate2(smtpSetting.CAPath);

                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate,
                                    X509Chain chain, SslPolicyErrors sslPolicyErrors)
                        {
                            chain.Build(new X509Certificate2(certificate));

                            if (chain.ChainElements[chain.ChainElements.Count - 1].Certificate.Thumbprint == cert.Thumbprint)
                                return true;// success

                        return false;
                        };
                    }
                }
            }
        }

        public void StartConnectDB()
        {
            TimerReadDB = new System.Timers.Timer();
            TimerReadDB.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            TimerReadDB.Interval = intervalRequest;
            TimerReadDB.AutoReset = false;
            TimerReadDB.Start();
        }

        public void StopConnectDB()
        {
            TimerReadDB.Stop();
        }

        void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            TimerReadDB.Stop();

            bnhnDB = new BenhNhanHienNoanDB(connectionString);
            bnhtDB = new BenhNhanHienTinhDB(connectionString);

            RequestToDB_HT_ThongTinBenhNhan();
            //RequestToDB_NeedAddPattern();
            RequestToDB_HT_DacTrungNH();
            RequestToDB_HT_KQXN();
            RequestToDB_HT_KhamNamKhoa();
            RequestToDB_HT_LuuTruMau();
            RequestToDB_HT_NguoiVanDong();
            RequestToDB_HT_ThongTinNguoiQuanHeBN();
            RequestToDB_HT_TinhDichDo();

            RequestToDB_HN_ThongTinBenhNhan();
            RequestToDB_HN_BenhTinhDuc();
            RequestToDB_HN_BenhToanThan();
            RequestToDB_HN_KQXN();
            RequestToDB_HN_KhamHongVaXuongChau();
            RequestToDB_HN_NguoiVanDong();
            RequestToDB_HN_TienSuSinhSan();
            RequestToDB_HN_TieuSuKinhNguyet();
            RequestToDB_HN_HoiBenh();

            TimerReadDB.Start();
        }

        void AttachmentFile(ref MailMessage mes, string fileName, string filePath)
        {
            System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
            contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
            contentType.Name = fileName;
            mes.Attachments.Add(new Attachment(filePath, contentType));
        }

        void RequestToDB_HT_ThongTinBenhNhan()
        {
            if (!setting.HT_ThongTinBN)
                return;

            try
            {
                List<HT_ThongTinNguoiHienTinh> ttnhts = bnhtDB.GetAllNguoiHienTinh();
                foreach (var ttnh in ttnhts)
                {
                    if (bnhtDB.CheckPatientApprove(ttnh.MaBN))
                    {
                        if (ttnh.FlagNeedSync)
                        {
                            var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_ThongTinNguoiHien, ttnh.CreateFileDataXML().ToString());
                            mailClient.Send(message);
                            bnhtDB.ResetInforSync_ThongTinBN(ttnh.MaBN);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool oldValue = false;
        void RequestToDB_NeedAddPattern()
        {
            if (!setting.HT_ThongTinBN)
                return;

            try
            {
                List<HT_ThongTinNguoiHienTinh> ttnhts = bnhtDB.GetAllNguoiHienTinh();
                foreach (var ttnh in ttnhts)
                {
                    bool allowAddPattern = bnhtDB.AllowAddPattern(ttnh.MaBN);

                    if (oldValue != allowAddPattern)
                    {
                        if (allowAddPattern)
                        {
                            ttnh.FlagAllowAddPattern = true;
                            oldValue = true;
                        }
                        else
                        {
                            ttnh.FlagAllowAddPattern = false;
                            oldValue = false;
                        }
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_ThongTinNguoiHien, ttnh.CreateFileDataXML().ToString());
                        mailClient.Send(message);
                        bnhtDB.ResetInforSync_ThongTinBN(ttnh.MaBN);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HT_DacTrungNH()
        {
            if (!setting.HT_ThongTinDacTrungNH)
                return;

            try
            {
                List<HT_DacTrungNguoiHien> dthts = bnhtDB.GetAllDacTrung();
                foreach (var dt in dthts)
                {
                    if (dt.FlagNeedSync && bnhtDB.CheckPatientApprove(dt.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_DacTrungNguoiHien, dt.CreateFileDataXML().ToString());
                        //if (dt.FilePath != null)
                        //    AttachmentFile(ref message, "Đặc trưng bệnh nhân " + dt.MaBN + " " + dt.NgayTao.ToString("dd-MM-yyyy"), dt.FilePath);

                        mailClient.Send(message);
                        bnhtDB.ResetInforSync_DacTrung(dt.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HT_KQXN()
        {
            if (!setting.HT_ThongTinKQXN)
                return;

            try
            {
                List<HT_KetQuaXetNghiem> kqxns = bnhtDB.GetAllKetQuaXetNghiem();
                foreach (var xn in kqxns)
                {
                    if (xn.FlagNeedSync && bnhtDB.CheckPatientApprove(xn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_KetQuaXetNghiem, xn.CreateFileDataXML().ToString());
                        //if (xn.FilePath != null)
                        //    AttachmentFile(ref message, "Kết quả xét nghiệm " + xn.MaBN + " " + xn.NgayTao.ToString("dd-MM-yyyy"), xn.FilePath);

                        mailClient.Send(message);
                        bnhtDB.ResetInforSync_KQXN(xn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HT_KhamNamKhoa()
        {
            if (!setting.HT_ThongTinKhamNamKhoa)
                return;

            try
            {
                List<HT_KhamNamKhoa> knks = bnhtDB.GetAllKhamNamKhoa();
                foreach (var bn in knks)
                {
                    if (bn.FlagNeedSync && bnhtDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_KhamNamKhoa, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Khám nam khoa " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhtDB.ResetInforSync_KhamNamKhoa(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HT_LuuTruMau()
        {
            if (!setting.HT_ThongTinLuuTruMau)
                return;

            try
            {
                List<HT_LuuTruMau> ltms = bnhtDB.GetAllLuuTruMau();
                foreach (var bn in ltms)
                {
                    if (bn.FlagNeedSync && bnhtDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_LuuTruMau, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Lưu trữ mẫu " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhtDB.ResetInforSync_LuuTruMau(bn.Id);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HT_NguoiVanDong()
        {
            if (!setting.HT_ThongTinNVD)
                return;

            try
            {
                List<HT_NguoiVanDong> nvds = bnhtDB.GetAllNguoiVanDong();
                foreach (var bn in nvds)
                {
                    if (bn.FlagNeedSync && bnhtDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_NguoiVanDong, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Người vận động " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhtDB.ResetInforSync_NVD(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HT_ThongTinNguoiQuanHeBN()
        {
            if (!setting.HT_ThongTinVoBN)
                return;

            try
            {
                List<HT_ThongTinNguoiQuanHeBN> nqhs = bnhtDB.GetAllNguoiQuanHeBN();
                foreach (var bn in nqhs)
                {
                    if (bn.FlagNeedSync && bnhtDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_NguoiQuanHe, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Người quan hệ bệnh nhân " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhtDB.ResetInforSync_VoBN(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HT_TinhDichDo()
        {
            if (!setting.HT_ThongTinTinhDichDo)
                return;

            try
            {
                List<HT_TinhDichDo> tdds = bnhtDB.GetAllTinhDichDo();
                foreach (var bn in tdds)
                {
                    if (bn.FlagNeedSync && bnhtDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HT_TinhDichDo, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Tinh dịch đồ " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhtDB.ResetInforSync_TinhDichDo(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void RequestToDB_HN_ThongTinBenhNhan()
        {
            if (!setting.HN_ThongTinBN)
                return;

            try
            {
                List<HN_ThongTinNguoiHienNoan> ttnhs = bnhnDB.GetAllNguoiHienNoan();
                foreach (var bn in ttnhs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_ThongTinNguoiHien, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Thông tin người hiến noãn " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_ThongTinBN(bn.MaBN);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HN_BenhTinhDuc()
        {
            if (!setting.HN_ThongTinBenhTinhDuc)
                return;

            try
            {
                List<HN_BenhTinhDuc> ttnhs = bnhnDB.GetAllBenhTinhDuc();
                foreach (var bn in ttnhs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_BenhTinhDuc, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Bệnh tình dục " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_BenhTinhDuc(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HN_BenhToanThan()
        {
            if (!setting.HN_ThongTinBenhToanThan)
                return;

            try
            {
                List<HN_BenhToanThan> ttnhs = bnhnDB.GetAllBenhToanThan();
                foreach (var bn in ttnhs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_BenhToanThan, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Bệnh toàn thân " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_BenhToanThan(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HN_KQXN()
        {
            if (!setting.HN_ThongTinKQXN)
                return;

            try
            {
                List<HN_KetQuaXetNghiem> ttnhs = bnhnDB.GetAllKetQuaXetNghiem();
                foreach (var bn in ttnhs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_KetQuaXetNghiem, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Kết quả xét nghiệm " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_KQXN(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HN_KhamHongVaXuongChau()
        {
            if (!setting.HN_ThongTinKhamHongVaXuongChau)
                return;

            try
            {
                List<HN_KhamBenh> ttnhs = bnhnDB.GetAllKhamHongVaXuongChau();
                foreach (var bn in ttnhs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_KhamHongVaXuongChau, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Khám hông và xương chậu " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_ChauHong(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HN_NguoiVanDong()
        {
            if (!setting.HN_ThongTinNVD)
                return;

            try
            {
                List<HN_NguoiVanDong> ttnhs = bnhnDB.GetAllNguoivanDong();
                foreach (var bn in ttnhs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_NguoiVanDong, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Người vận động " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_NguoiVanDong(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HN_TienSuSinhSan()
        {
            if (!setting.HN_ThongTinTienSuSS)
                return;

            try
            {
                List<HN_TienSuSinhSan> ttnhs = bnhnDB.GetAllTienSuSinhSan();
                foreach (var bn in ttnhs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_TienSuSinhSan, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Tiền sử sinh sản " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_TienSuSinhSan(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HN_TieuSuKinhNguyet()
        {
            if (!setting.HN_ThongTinTieuSuKN)
                return;

            try
            {
                List<HN_TieuSuKinhNguyet> ttnhs = bnhnDB.GetAllTieuSuKinhNguyet();
                foreach (var bn in ttnhs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_TieuSuKinhNguyet, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Tiểu sử kinh nguyệt " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_KinhNguyet(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void RequestToDB_HN_HoiBenh()
        {
            if (!setting.HN_ThongTinHoiBenh)
                return;

            try
            {
                List<HN_HoiBenh> hbs = bnhnDB.GetAllHoiBenh();
                foreach (var bn in hbs)
                {
                    if (bn.FlagNeedSync && bnhnDB.CheckPatientApprove(bn.MaBN))
                    {
                        var message = new MailMessage(smtpSetting.MailAddressSend, smtpSetting.MailAddressReceive, Utilities.Header_HN_HoiBenh, bn.CreateFileDataXML().ToString());
                        //if (bn.FilePath != null)
                        //    AttachmentFile(ref message, "Tiểu sử kinh nguyệt " + bn.MaBN + " " + bn.NgayTao.ToString("dd-MM-yyyy"), bn.FilePath);

                        mailClient.Send(message);
                        bnhnDB.ResetInforSync_HoiBenh(bn.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
