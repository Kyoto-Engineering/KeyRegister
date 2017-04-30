using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
  public   class PropertyManager
    {
      PropertyGateway aGateway=new PropertyGateway();

        public  int SaveProperty(Property aProperty)
        {
            return aGateway.SaveProperty(aProperty);
        }
    }
}
