using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
  public   class KeyHolderManager
    {
      KeyHolderGateway  aGateway=new KeyHolderGateway();
        public  int SaveKeyHolder(KeyHolder aKeyHolder)
        {
            return aGateway.SaveKeyHolder(aKeyHolder);
        }
    }
}
