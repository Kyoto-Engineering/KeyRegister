using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
   public  class LocationInChargeManager
   {
       private LocationInChargeGateway alGateway;
        public  int  SaveLocationInCharge(LocationInCharges aLocationInCharges)
        {
           alGateway=new LocationInChargeGateway();
            return alGateway.SaveLocationInCharge(aLocationInCharges);
        }
    }
}
