using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public   class KeyAllocation
    {
      public int KeyAllocationId { set; get; }
      public int PropertyId { set; get; }
      public int TerritoryId { set; get; }
      public int LocationId { set; get; }
      public int KAUserId { set; get; }
      public DateTime DateTimeCreated { set; get; }

    }
}
