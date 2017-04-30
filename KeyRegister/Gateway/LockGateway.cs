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
   public  class LockGateway
   {
       private SqlConnection con;
       private SqlCommand cmd;
       private SqlDataReader rdr;
       ConnectionString cs=new ConnectionString();


       public  int SaveLock(Lock aLock)
       {
           con=new SqlConnection(cs.DBConn);
           con.Open();
           string query = "INSERT INTO Lock(PropertyId,LockName,LockTypeId,UserId,CreatedDateTime) VALUES(@d1,@d2,@d3,@d4,@d5)";
           cmd=new SqlCommand(query,con);
           cmd.Parameters.AddWithValue("@d1", aLock.PropertyId);
           cmd.Parameters.AddWithValue("@d2", aLock.LockName);
           cmd.Parameters.AddWithValue("@d3", aLock.LockTypeId);
           cmd.Parameters.AddWithValue("@d4", aLock.LUserId);
           cmd.Parameters.AddWithValue("@d5", aLock.CreatedDateTime); 
           int affectedrows= cmd.ExecuteNonQuery();
           con.Close();
           return affectedrows;
       }
    }
}
