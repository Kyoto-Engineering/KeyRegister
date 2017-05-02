using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
  public   class KeyManager
    {
      KeyGateway aGateway=new KeyGateway();
        public  int SaveKey(Key aKey)
        {
            return aGateway.SaveKey(aKey);
        }
    }
}
