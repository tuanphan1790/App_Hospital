using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBLib
{
    class ThongTinBenhNhanHienTinh
    {
        ThongTinDacTrungHienTinh ttdtnht;
        ThongTinKetQuaXetNghiem ttkqxn;
        ThongTinKetQuaXetNghiemTinhDichDo ttkqxntdd;
        ThongTinKhamNamKhoa ttknk;
        ThongTinLichSuBenhLayQuaDuongTinhDuc ttlsblqdtd;
        ThongTinNguoiVanDongHienTinh ttnvdht;
        ThongTinLuuTruMau ttltm;

        public ThongTinBenhNhanHienTinh(XDocument xDoc)
        {
            var xDLBNHT = xDoc.Element("TTBNHT");
            this.Patient_ID = Convert.ToUInt64(xDLBNHT.Attribute("id").Value);
            this.Patient_Code = xDLBNHT.Attribute("code").Value;

            var xTTCB = xDLBNHT.Element("BasicInfor");
            this.FullName = xTTCB.Element("fullName").Value;
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

            var xWifeInfor = xDLBNHT.Element("WifeInfors");
            this.WifeName = xWifeInfor.Attribute("wifeName").Value;
            this.WIdentify = xWifeInfor.Attribute("wIdentify").Value;
            this.WDateOfID = Convert.ToDateTime(xWifeInfor.Attribute("wDateOfId").Value);
            this.WAddress = xWifeInfor.Attribute("wAddress").Value;
            this.WPhone = xWifeInfor.Attribute("wPhone").Value;
            this.WEmail = xWifeInfor.Attribute("wEmail").Value;

            this.CreatedDate = Convert.ToDateTime(xDLBNHT.Element("createdDate").Value);
        }

        public ThongTinBenhNhanHienTinh(UInt64 id, string code)
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

        public string WifeName { set; get; }
        public string WIdentify { set; get; }
        public DateTime WDateOfID { set; get; }
        public string WAddress { set; get; }
        public string WPhone { set; get; }
        public string WEmail { set; get; }

        public DateTime CreatedDate { set; get; }


        public XDocument CreateFileDataXML()
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("TTBNHT", new XAttribute("id", Patient_ID.ToString()), new XAttribute("code", Patient_Code),
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
                                new XElement("WifeInfors", new XAttribute("wifeName", WifeName), new XAttribute("wIdentify", WIdentify), new XAttribute("wDateOfId", WDateOfID), new XAttribute("wAddress", WAddress), new XAttribute("wPhone", WPhone), new XAttribute("wEmail", WEmail)),
                                new XElement("createdDate", CreatedDate.ToString()))));

            return xDoc;
        }
    }
}
