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
   public  class TerritoryManagerGateway
   {
       private SqlConnection con;
       ConnectionString cs=new ConnectionString();
       public int SaveTerritoryManagement(TerritoryManagers aManagers)
       {
           con=new SqlConnection(cs.DBConn);
           con.Open();
           string query = "INSERT INTO  TerritoryManager(UserId,TerritoryId,OndutyForm,AssginedBy) VALUES(@d1,@d2,@d3,@d4)";
           SqlCommand cmd = new SqlCommand(query, con);
           cmd.Parameters.AddWithValue("@d1", aManagers.TMUserId);
           cmd.Parameters.AddWithValue("@d2", aManagers.TerritoryId);
           cmd.Parameters.AddWithValue("@d3", aManagers.OnDutyFrom);
           cmd.Parameters.AddWithValue("@d4", aManagers.AssignedBy);
           int affectedRows = cmd.ExecuteNonQuery();
           con.Close();
           return affectedRows;
       }
        
    }
}
