using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
  public   class ModelCOO
    {
        private int cOOId;
        private string  userId;
        private int companyId;
        private DateTime joiningDate;
        private DateTime resignationDate;
        private DateTime creationDate;

        public int COOId
        {
            get { return cOOId; }
            set { cOOId = value; }
        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }

        public DateTime JoiningDate
        {
            get { return joiningDate; }
            set { joiningDate = value; }
        }

        public DateTime ResignationDate
        {
            get { return resignationDate; }
            set { resignationDate = value; }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        public string COOName { set; get; }
        public string CompanyName { set; get; }


    }
}
