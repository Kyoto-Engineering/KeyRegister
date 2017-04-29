using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
  public   class TerritoryManagerManager
    {
      TerritoryManagerGateway aGateway=new TerritoryManagerGateway();


      public  int SaveTerritoryManagement(TerritoryManagers aManagers)
      {
          return aGateway.SaveTerritoryManagement(aManagers);
      }
    }
}
