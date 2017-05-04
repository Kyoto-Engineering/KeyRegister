using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.DAO;
using KeyRegister.DBGateway;

namespace KeyRegister.Gateway
{
  public   class KeyAllocationGateway
    {
      ConnectionString cs=new ConnectionString();
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;

        public  int SaveKeyAllocation(KeyAllocation allocation)
        {
            con=new SqlConnection(cs.DBConn);
            con.Open();
            string query = "INSERT INTO KeyAllocation(TerritoryId,PeropertyId,LocationId,UserId,CreatedDatetime) VALUES(@d1,@d2,@d3,@d4,@d5)";
            cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@d1", allocation.TerritoryId);
            cmd.Parameters.AddWithValue("@d2", allocation.PropertyId);
            cmd.Parameters.AddWithValue("@d3", allocation.LocationId);
            cmd.Parameters.AddWithValue("@d4", allocation.KAUserId);
            cmd.Parameters.AddWithValue("@d5", allocation.DateTimeCreated);
            int affectedRows=  cmd.ExecuteNonQuery();
            con.Close();
            return affectedRows;
        }
    }
}
