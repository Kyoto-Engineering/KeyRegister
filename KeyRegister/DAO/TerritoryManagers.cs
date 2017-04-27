using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
   public  class TerritoryManagers
    {
       public int TerritoryManagerId { set; get; }
       public string TerritoryManager { set; get; }
       public string TMUserId { set; get; }
       public string TerritoryId { set; get; }
       public DateTime OnDutyFrom { set; get; }
       public DateTime OffDutyTo { set; get; }
       public string AssignedBy { set; get; }
       public DateTime AssignedDate { set; get; }
       public User Users { set; get; }
    }
}
