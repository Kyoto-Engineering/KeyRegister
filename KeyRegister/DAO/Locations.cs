using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
 public  class Locations
    {
     public int  LocationId { set; get; }
     public string LocationName { set; get; }
     public int LUserId { set; get; }
     public DateTime CreateddateTime { set; get; }
     public int LTerritoryId { set; get; }

     public  void SaveLocation(Locations aLocation)
     {
         throw new NotImplementedException();
     }
    }
}
