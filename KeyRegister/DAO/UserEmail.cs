using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
   public  class UserEmail
    {
       public int UserEmailId { set; get; }
       public string UserPart { set; get; }
       public int HostEmailId { set; get; }
       //public int EmailHostId1 { set; get; }
       //public int EmailHostId2 { set; get; }
       public int UserId { set; get; }
       public bool IsPrimaryStatus { set; get; }

    }
}
