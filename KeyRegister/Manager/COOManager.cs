using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
   public  class COOManager
    {
       COOGateway aCooGateway=new COOGateway();


       public  string SaveCOO(ModelCOO amCOO)
       {
           return aCooGateway.SaveCOO(amCOO);
       }
    }
}
