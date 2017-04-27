using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{

   public  class LocationManager
    {
       LocationGateway aGateway=new LocationGateway();



       public  int  SaveLocation(Locations aLocation)
       {
           aGateway=new LocationGateway();
           return aGateway.SaveLocation(aLocation);
       }
    }
}
