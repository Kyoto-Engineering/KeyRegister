using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public  class PostOffices
    {
        public int PostOfficeId { set; get; }
        public string PostOffice { set; get; }
        public string PostCode { set; get; }
        public Thanas Thana { set; get; }
    }
}
