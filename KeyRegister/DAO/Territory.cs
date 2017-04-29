using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public   class Territory
    {
        public int TerritoryId { set; get; }
        public string TerritoryName { set; get; }
        public int TUserId { set; get; }
        public DateTime CreatedDateTime { set; get; }
        public int CompanyId { set; get; }
    }
}
