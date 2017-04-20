using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DBGateway
{
  public  class ConnectionGateway
    {
        protected  SqlConnection connection;
        string connectionString = @"server=tcp:KyotoServer,49172; Integrated Security = SSPI; database =NewProductList1;Connect Timeout=30";
    }
}
