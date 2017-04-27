using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
   public  class LocationInCharges
    {
       public int  LocationInChargeId { set; get; }
       public string LIName { set; get; }
       public string LUserId { set; get; }
       public string LocationId { set; get; }
       public string AssignDate { set; get; }
       public string RetractDate { set; get; }
       public string AssignedBy { set; get; }
       public string RetractBy { set; get; }
    }
}
