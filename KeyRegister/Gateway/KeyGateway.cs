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
  public   class KeyGateway
  {
      private SqlConnection con;
      private SqlCommand cmd;
      private SqlDataReader rdr;
         ConnectionString cs=new ConnectionString();

         public  int SaveKey(Key aKey)
         {
            con=new SqlConnection(cs.DBConn);
             con.Open();
             string query = "INSERT INTO  Key(KeyName,KeyTypeId,LockId,UserId,CreatedDateTime) VALUES(@d1,@d2,@d3,@d4,@d5)";
             cmd=new SqlCommand(query,con);
             cmd.Parameters.AddWithValue("@d1", aKey.PropertyId);
             cmd.Parameters.AddWithValue("@d2", aKey.KLockId);
             cmd.Parameters.AddWithValue("@d3", aKey.KeyTypeId);
             cmd.Parameters.AddWithValue("@d4", aKey.KUserId);
             cmd.Parameters.AddWithValue("@d5", aKey.CreateddateTime);
             
             ;
             int affectedRows = cmd.ExecuteNonQuery();
             con.Close();
             return affectedRows;
         }
    }
}
