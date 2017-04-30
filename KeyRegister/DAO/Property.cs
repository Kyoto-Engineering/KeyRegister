using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
   public  class Property
    {
       public int PropertyId { set; get; }
       public string PropertyName { set; get; }
       public string LocationInChargeName { set; get; }
       public int LocationInChargeId { set; get; }
       public string LocationName { set; get; }
       public int LocationId { set; get; }
       public DateTime CreatedDateTime { set; get; }
    }
}
