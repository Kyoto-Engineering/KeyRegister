using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
   public  class Countries
   {
       private  int countryId;
       private  string countryName;
       private string countryCode;

       public int CountryId
       {
           get { return countryId; }
           set { countryId = value; }
       }

       public string CountryName
       {
           get {return countryName; }
           set { countryName = value; }
       }

       public string CountryCode
       {
           get { return countryCode; }
           set { countryCode = value; }
       }
   }
}
