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
  public   class  KeyHolderGateway
    {
      ConnectionString cs=new ConnectionString();
        private SqlConnection con;
        private SqlDataReader rdr;
        private SqlCommand cmd;


      public  int SaveKeyHolder(KeyHolder aKeyHolder)
      {
          con=new SqlConnection(cs.DBConn);
          con.Open();
          string query = "INSERT INTO LocationUser(LocationId,UserId) VALUES(@d1,@d2)";
          cmd=new SqlCommand(query,con);
          cmd.Parameters.AddWithValue("@d1", aKeyHolder.LocationId);
          cmd.Parameters.AddWithValue("@d2", aKeyHolder.UKeyHolderId);
          cmd.ExecuteReader();
          int affectedRows = cmd.ExecuteNonQuery();
          con.Close();
          return affectedRows;

      }
    }
}
