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
  public   class LocationAllocationGateway
  {
      private SqlConnection con;
      private SqlCommand cmd;
      private SqlDataReader rdr;
      ConnectionString cs=new ConnectionString();

        public  int SaveLocationAllocation(LocationAllocations allocation)
        {
            con=new SqlConnection(cs.DBConn);
            con.Open();
            string query = "INSERT INTO LocationUser(LocationId,UserId) VALUES(@d1,@d2)";
            cmd=new SqlCommand(cs.DBConn);
            cmd.Parameters.AddWithValue("@d1", allocation.LocationId);
            cmd.Parameters.AddWithValue("@d2", allocation.LocationInChargeId);
            int affectedRows = cmd.ExecuteNonQuery();
            con.Close();
            return affectedRows;

        }
    }
}
