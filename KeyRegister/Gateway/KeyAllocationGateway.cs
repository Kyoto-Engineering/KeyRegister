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
            string query = "INSERT INTO KeyRgisterk(UserId,KeyId,AssignedForm,AssginedBy,AsginedDate) VALUES(@d1,@d2,@d3,@d4,@d5)";
            cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@d1", allocation.KeyHolderId);
            cmd.Parameters.AddWithValue("@d2", allocation.KeyId);
            cmd.Parameters.AddWithValue("@d3", allocation.AssignedFrom);
            cmd.Parameters.AddWithValue("@d4", allocation.KAUserId);
            cmd.Parameters.AddWithValue("@d5", allocation.AssignDate);
            int affectedRows=  cmd.ExecuteNonQuery();
            con.Close();
            return affectedRows;
        }
    }
}
