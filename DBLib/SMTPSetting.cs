using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib
{
    public class SMTPSetting
    {
        public SMTPSetting(string smtpServer, int smtpPort, string userAddress, string password, bool enableSSL, bool useGmail)
        {
            this.SmtpServer = smtpServer;
            this.SmtpPort = smtpPort;
            this.UserAddress = userAddress;
            this.Password = password;
            this.EnableSSL = enableSSL;
            this.UseGmail = useGmail;
        }

        public bool UseGmail { get; }

        public string CAPath { set; get; }

        public string SmtpServer { get; }
        public int SmtpPort { get; }

        public string UserAddress { get; }
        public string Password { get; }

        public bool EnableSSL { get; }

        public string MailAddressSend { set; get; }
        public string MailAddressReceive { set; get; }
    }
}
