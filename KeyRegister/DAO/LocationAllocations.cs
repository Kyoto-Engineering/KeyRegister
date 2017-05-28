using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public  class LocationAllocations
    {
      public int LocationAllocationId { set; get; }
      public int LocationInChargeId { set; get; }
      public int LocationId { set; get; }
      public DateTime AddedDate { set; get; }
    }
}
