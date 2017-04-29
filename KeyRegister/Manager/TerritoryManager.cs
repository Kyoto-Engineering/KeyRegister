using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
  public   class TerritoryManager
    {

        TerritoryGateway aGateway = new TerritoryGateway();





        public int SaveTerritory(Territory aTerritory)
        {
            return aGateway.SaveTerritory(aTerritory);
        }
    }
}
