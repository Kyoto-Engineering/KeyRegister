using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
  public  class KeyAllocationManager
    {
      KeyAllocationGateway  agGateway=new KeyAllocationGateway();

        public  int SaveKeyAllocation(KeyAllocation allocation)
        {
            return agGateway.SaveKeyAllocation(allocation);
        }
    }
}
