using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLib
{
    class ThongTinNguoiQuanHeBenhNhanHienNoan
    {
        public UInt64 Patient_ID { set; get; }
        public string Patient_Code { set; get; }

        public string FullName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string CMND_No { set; get; }
        public DateTime CMND_DateOfID { set; get; }
        public string CMND_AddressOfID { set; get; }
        public string CMND_Address { set; get; }
        public string PhoneNo { set; get; }
        public string Email { set; get; }
        public int NationID { set; get; }
        public int ClassID { set; get; }
        public string ProvinceCode { set; get; }
        public string DistrictCode { set; get; }

        public bool Status { set; get; }

        public ThongTinNguoiQuanHeBenhNhanHienNoan(UInt64 id, string code, string fullName)
        {
            this.Patient_ID = id;
            this.Patient_Code = code;
            this.FullName = fullName;
        }

        public ThongTinNguoiQuanHeBenhNhanHienNoan(XDocument xDoc)
        {
            var xTTNQHBNHN = xDoc.Element("TTNQHBNHN");
            this.Patient_ID = Convert.ToUInt64(xTTNQHBNHN.Attribute("id").Value);
            this.Patient_Code = xTTNQHBNHN.Attribute("code").Value;

            var xTTCB = xTTNQHBNHN.Element("BasicInfor");
            this.FullName = xTTCB.Element("fullName").Value;
            this.DateOfBirth = Convert.ToDateTime(xTTCB.Element("dateOfBirth").Value);
            this.PhoneNo = xTTCB.Element("phoneNumber").Value;
            this.Email = xTTCB.Element("email").Value;

            var xNationInfor = xTTCB.Element("nationalInfor");
            this.NationID = Convert.ToInt32(xNationInfor.Attribute("nationID").Value);
            this.ClassID = Convert.ToInt32(xNationInfor.Attribute("classID").Value);
            this.ProvinceCode = xNationInfor.Attribute("provinceCode").Value;
            this.DistrictCode = xNationInfor.Attribute("districtCode").Value;

            var xCMNDInfor = xTTCB.Element("CMNDInfor");
            this.CMND_No = xCMNDInfor.Attribute("noCMND").Value;
            this.CMND_DateOfID = Convert.ToDateTime(xCMNDInfor.Attribute("dateOfId").Value);
            this.CMND_Address = xCMNDInfor.Attribute("address").Value;
            this.CMND_AddressOfID = xCMNDInfor.Attribute("addressOfId").Value;

            this.Status = Convert.ToBoolean(xTTNQHBNHN.Element("status").Value);
        }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("TTNQHBNHN", new XAttribute("id", Patient_ID.ToString()), new XAttribute("code", Patient_Code),
                                new XElement("BasicInfor",
                                    new XElement("fullName", FullName),
                                    new XElement("dateOfBirth", DateOfBirth.ToString()),
                                    new XElement("phoneNumber", PhoneNo),
                                    new XElement("email", Email),
                                    new XElement("nationalInfor", new XAttribute("nationID", NationID), new XAttribute("classID", ClassID), new XAttribute("provinceCode", ProvinceCode), new XAttribute("districtCode", DistrictCode)),
                                    new XElement("CMNDInfor", new XAttribute("noCMND", CMND_No), new XAttribute("dateOfId", CMND_DateOfID.ToString()), new XAttribute("address", CMND_Address), new XAttribute("addressOfId", CMND_AddressOfID)),
                                new XElement("status", Status))));

            return xDoc;
        }
    }
}
