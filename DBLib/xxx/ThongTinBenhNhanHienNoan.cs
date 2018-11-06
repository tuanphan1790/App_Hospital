using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLib
{
    class ThongTinBenhNhanHienNoan
    {
        public ThongTinBenhNhanHienNoan(XDocument xDoc)
        {
            var xDLBNHT = xDoc.Element("TTBNHN");
            this.Patient_ID = Convert.ToUInt64(xDLBNHT.Attribute("id").Value);
            this.Patient_Code = xDLBNHT.Attribute("code").Value;

            var xTTCB = xDLBNHT.Element("BasicInfor");
            this.FullName = xTTCB.Element("fullname").Value;
            this.DateOfBirth = Convert.ToDateTime(xTTCB.Element("dateOfBirth").Value);
            this.PhoneNo = xTTCB.Element("phoneNumber").Value;
            this.Email = xTTCB.Element("email").Value;
            this.LevelID = Convert.ToInt16(xTTCB.Element("levelId").Value);
            this.Job = xTTCB.Element("job").Value;

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

            var xMarriageInformation = xDLBNHT.Element("marriageInformation");
            this.IsMarried = Convert.ToBoolean(xMarriageInformation.Attribute("isMarried").Value);
            this.HasChild = Convert.ToBoolean(xMarriageInformation.Attribute("hasChild").Value);
            this.NoOfChild = Convert.ToInt16(xMarriageInformation.Attribute("numberOfChild").Value);
            this.YearOfChildLast = Convert.ToInt16(xMarriageInformation.Attribute("yearOfChildLast").Value);
            this.DayOfHaveBaby = Convert.ToInt16(xMarriageInformation.Attribute("dayOfHaveBaby").Value);

            var xHeathStatus = xDLBNHT.Element("HeathStatus");
            this.HeathStatus = xHeathStatus.Attribute("heathStatus").Value;
            this.HistoryOfPatient = xHeathStatus.Attribute("historyOfPatient").Value;
            this.HistoryOfFamily = xHeathStatus.Attribute("historyOfFamily").Value;

            var xFP = xDLBNHT.Element("FP");
            this.FPRightThumb = xFP.Element("FPRightThumb").Value;
            this.FPLeftThumb = xFP.Element("FPLeftThumb").Value;
            this.FPRightIndex = xFP.Element("FPRightIndex").Value;
            this.FPLeftIndex = xFP.Element("FPLeftIndex").Value;

            var xHusbandInfor = xDLBNHT.Element("HusbandInfors");
            this.HusbandName = xHusbandInfor.Attribute("husbandName").Value;
            this.hIdentify = xHusbandInfor.Attribute("hIdentify").Value;
            this.hDateOfID = Convert.ToDateTime(xHusbandInfor.Attribute("hDateOfId").Value);
            this.hAddress = xHusbandInfor.Attribute("hAddress").Value;
            this.hPhone = xHusbandInfor.Attribute("hPhone").Value;
            this.hEmail = xHusbandInfor.Attribute("hEmail").Value;

            this.CreatedDate = Convert.ToDateTime(xDLBNHT.Element("createdDate").Value);
        }

        public ThongTinBenhNhanHienNoan(UInt64 id, string code)
        {
            this.Patient_ID = id;
            this.Patient_Code = code;
        }

        public UInt64 Patient_ID { set; get; }
        public string Patient_Code { set; get; }

        public string FullName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public int NationID { set; get; }
        public int ClassID { set; get; }
        public string ProvinceCode { set; get; }
        public string DistrictCode { set; get; }
        public string CMND_No { set; get; }
        public DateTime CMND_DateOfID { set; get; }
        public string CMND_AddressOfID { set; get; }
        public string CMND_Address { set; get; }
        public string PhoneNo { set; get; }
        public string Email { set; get; }
        public int LevelID { set; get; }
        public string Job { set; get; }
        public bool IsMarried { set; get; }
        public bool HasChild { set; get; }
        public int NoOfChild { set; get; }
        public int YearOfChildLast { set; get; }
        public int DayOfHaveBaby { set; get; }
        public string HeathStatus { set; get; }

        public string FPRightThumb { set; get; }
        public string FPLeftThumb { set; get; }
        public string FPRightIndex { set; get; }
        public string FPLeftIndex { set; get; }

        public string HistoryOfPatient { set; get; }
        public string HistoryOfFamily { set; get; }

        public string HusbandName { set; get; }
        public string hIdentify { set; get; }
        public DateTime hDateOfID { set; get; }
        public string hAddress { set; get; }
        public string hPhone { set; get; }
        public string hEmail { set; get; }

        public DateTime CreatedDate { set; get; }

        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("TTBNHN", new XAttribute("id", Patient_ID.ToString()), new XAttribute("code", Patient_Code),
                                new XElement("BasicInfor",
                                    new XElement("fullName", FullName),
                                    new XElement("dateOfBirth", DateOfBirth.ToString()),
                                    new XElement("phoneNumber", PhoneNo),
                                    new XElement("email", Email),
                                    new XElement("levelId", LevelID),
                                    new XElement("job", Job),
                                    new XElement("nationalInfor", new XAttribute("nationID", NationID), new XAttribute("classID", ClassID), new XAttribute("provinceCode", ProvinceCode), new XAttribute("districtCode", DistrictCode)),
                                    new XElement("CMNDInfor", new XAttribute("noCMND", CMND_No), new XAttribute("dateOfId", CMND_DateOfID.ToString()), new XAttribute("address", CMND_Address), new XAttribute("addressOfId", CMND_AddressOfID)),
                                    new XElement("marriageInformation", new XAttribute("isMarried", IsMarried), new XAttribute("hasChild", HasChild), new XAttribute("numberOfChild", NoOfChild), new XAttribute("yearOfChildLast", YearOfChildLast), new XAttribute("dayOfHaveBaby", DayOfHaveBaby)),
                                new XElement("HeathStatus", new XAttribute("heathStatus", HeathStatus), new XAttribute("historyOfPatient", HistoryOfPatient), new XAttribute("historyOfFamily", HistoryOfFamily)),
                                new XElement("FP",
                                    new XElement("FPRightThumb", FPRightThumb),
                                    new XElement("FPLeftThumb", FPLeftThumb),
                                    new XElement("FPRightIndex", FPRightIndex),
                                    new XElement("FPLeftIndex", FPLeftIndex)),
                                new XElement("HusbandInfors", new XAttribute("husbandName", HusbandName), new XAttribute("hIdentify", hIdentify), new XAttribute("hDateOfId", hDateOfID), new XAttribute("hAddress", hAddress), new XAttribute("hPhone", hPhone), new XAttribute("hEmail", hEmail)),
                                new XElement("createdDate", CreatedDate.ToString()))));

            return xDoc;
        }
    }
}
