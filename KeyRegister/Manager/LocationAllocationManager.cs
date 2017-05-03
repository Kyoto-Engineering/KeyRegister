using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
  public   class LocationAllocationManager
    {
      LocationAllocationGateway  agGateway=new LocationAllocationGateway();



      public  int SaveLocationAllocation(LocationAllocations allocation)
      {
          return agGateway.SaveLocationAllocation(allocation);
      }
    }
}
