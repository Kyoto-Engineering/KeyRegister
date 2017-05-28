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
      public int KeyHolderId { set; get; }
      public int KeyId { set; get; }
      public DateTime AssignedFrom { set; get; }
      public int KAUserId { set; get; }
      public DateTime AssignDate { set; get; }

    }
}
