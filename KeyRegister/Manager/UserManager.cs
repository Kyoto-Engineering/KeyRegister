using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.Manager
{
 public  class UserManager
 {
     public UserGateway aUserGateway;
        public  int  SaveUserDetail(Users aUser)
        {
          aUserGateway=new UserGateway();
            return aUserGateway.SaveUserDetails(aUser);
        }

        public  int SavePresentAddress(PresentAddress apresentAddress)
        {
            aUserGateway=new UserGateway();
            return aUserGateway.SavePresentAddress(apresentAddress);
        }

        public  int SavePermanantAddress(PerManantAddress aperAddress)
        {
            aUserGateway=new UserGateway();
            return aUserGateway.SavePermanantAddress(aperAddress);
        }

        public  int SaveOverSeasAddress(OverSeasAddress ovAddress)
        {
           aUserGateway=new UserGateway();
            return aUserGateway.SaveOverSeasAddress(ovAddress);
        }

        public  int PerManantSameAsPresentAddress(PerManantAddress aperAddress)
        {
            aUserGateway=new UserGateway();
            return aUserGateway.PerManantSameAsPresentAddress(aperAddress);
        }



        public  int SaveEmailAddress(EmailAddress address)
        {
            aUserGateway=new UserGateway();
            return aUserGateway.SaveEmailAddress(address);
        }
 }
}
