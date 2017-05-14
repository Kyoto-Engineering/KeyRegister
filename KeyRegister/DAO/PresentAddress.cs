using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public   class  PresentAddress
  {
      private int presentAddressId;
      private int prePostOfficeId;
      private string preFlatNo;
      private string preHouseNo;
      private string preRoadNo;
      private string preBlockNo;
      private string preArea;
      private string preDistrict;
      private string preDivision;
      private string preThana;
      private string prePostOffice;
      private string prePostcode;
      
      public int PresentAddressId
      {
          get { return presentAddressId; }
          set { presentAddressId = value; }
      }

      public int PrePostOfficeId
      {
          get { return prePostOfficeId; }
          set { prePostOfficeId = value; }

      }

      public string PreFlatNo
      {
          get { return preFlatNo; }
          set { preFlatNo = value; }
      }

      public string PreHouseNo
      {
          get { return preHouseNo; }
          set { preHouseNo = value; }

      }

      public string PreRoadNo
      {
          get { return preRoadNo; }
          set { preRoadNo = value; }
      }

      public string PreBlock
      {
          get { return preBlockNo; }
          set { preBlockNo = value; }
      }

      public string PreArea
      {
          get { return preArea; }
          set { preArea = value; }
      }

      public string PreDivision
      {
          get { return preDivision; }
          set { preDivision = value; }
      }

      public string PreDistrict
      {
          get { return preDistrict; }
          set { preDistrict = value; }
      }

      public string PreThana
      {
          get { return preThana; }
          set { preThana = value; }
      }

      public string PrePostCode
      {
          get { return prePostcode; }
          set { prePostcode = value; }
      }

      public int  UserId { set; get; }
      public string PostOfficeName { set; get; }

  }
}
