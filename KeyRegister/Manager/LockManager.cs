using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
  public   class LockManager
    {
      LockGateway aGateway=new LockGateway();
        public  int SaveLock(Lock aLock)
        {
           return aGateway.SaveLock(aLock);
        }
    }
}
