using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public   class PerManantAddress
    {
        private int permanantAddressId;
        private int perPostOfficeId;
        private string perFlatNo;
        private string perHouseNo;
        private string perRoadNo;
        private string perBlockNo;
        private string perArea;
        private string perDistrict;
        private string perDivision;
        private string perThana;
        private string perPostOffice;
        private string perPostcode;
        private int  perUserId;
        public int PersmanantAddressId
        {
            get { return permanantAddressId; }
            set { permanantAddressId = value; }
        }

        public int PerPostOfficeId
        {
            get { return perPostOfficeId; }
            set { perPostOfficeId = value; }

        }

        public string PerFlatNo
        {
            get { return perFlatNo; }
            set { perFlatNo = value; }
        }

        public string PerHouseNo
        {
            get { return perHouseNo; }
            set { perHouseNo = value; }

        }

        public string PerRoadNo
        {
            get { return perRoadNo; }
            set { perRoadNo = value; }
        }

        public string PerBlock
        {
            get { return perBlockNo; }
            set { perBlockNo = value; }
        }

        public string PerArea
        {
            get { return perArea; }
            set { perArea = value; }
        }

        public string PerDivision
        {
            get { return perDivision; }
            set { perDivision = value; }
        }

        public string PerDistrict
        {
            get { return perDistrict; }
            set { perDistrict = value; }
        }

        public string PerThana
        {
            get { return perThana; }
            set { perThana = value; }
        }

        public string PerPostCode
        {
            get { return perPostcode; }
            set { perPostcode = value; }
        }

        public int  PerUserId
        {
            get { return perUserId; }
            set { perUserId = value; }
        }
        public string PostOfficeName { set; get; }
    }
}
