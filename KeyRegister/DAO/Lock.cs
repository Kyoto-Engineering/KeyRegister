using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public   class Lock
    {
      public int LockId { set; get; }
      public string LockName { set; get; }
      public string PropertyName { set; get; }
      public int PropertyId { set; get; }
      public int LockTypeId { set; get; }
      public string LockTypeName { set; get; }
      public string LUserId { set; get; }
      public DateTime CreatedDateTime { set; get; }
    }
}
