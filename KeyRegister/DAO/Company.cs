using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public  class Company
  {
      private int companyId;
      private string companyName;
      private DateTime createdDateTime;

      public int CompanyId
      {
          get { return companyId; }
          set { companyId = value; }
      }

      public string CompanyName
      {
          get { return companyName; }
          set { companyName = value; }
      }

      public DateTime CreatedDateTime
      {
          get { return createdDateTime; }
          set { createdDateTime = value; }
      }
  }
}
