using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
 public  class Key
    {
     public int KeyId { set; get; }
     public int KeyTypeId { set; get; }
     public string KeyName { set; get; }
     public int KeyNo { set; get; }
     public int KUserId { set; get; }
     public DateTime CreateddateTime { set; get; }
     public int KLockId { set; get; }
     public string KLockNo { set; get; }
     public int  KeyIsId { set; get; }
     public int PropertyId { set; get; }

    }
}
