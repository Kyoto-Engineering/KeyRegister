using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DAO;
using KeyRegister.DBGateway;

namespace KeyRegister.Gateway
{
  public   class CompanyGateway:ConnectionGateway
    {
        public string SaveCompany(Company aCompany)
        {
            connection.Open();
            string connstring = string.Format("INSERT INTO Company(CompanyName,CreatedDateTime) VALUES('{0}','{1}')", aCompany.CompanyName,aCompany.CreatedDateTime);
            SqlCommand cmd=new SqlCommand(connstring,connection);
            int affectedRows = cmd.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                return "Successfully Saved";
            }
            else
            {
                return "Data is Null";
            }


        }
    }
}
