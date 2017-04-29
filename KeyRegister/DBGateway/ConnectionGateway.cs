using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KeyRegister.DBGateway
{
  public  class ConnectionGateway
    {
        protected  SqlConnection connection;
        string connectionString = @"server=tcp:KyotoServer,49172; Integrated Security = SSPI; database =KeyRegistar66;Connect Timeout=30";
       
            
        public ConnectionGateway()
        {
            string connectionString = ConfigurationManager.AppSettings["dbConnectionString"];
            connection = new SqlConnection(connectionString);
           
        }
      
    }
}
