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
       public List<Users> GetUserName()
       {
           con=new SqlConnection(cs.DBConn);
           con.Open();
           string query = "select FullName,UserId, UserName  from  Users where Statuss='Active'";
           SqlCommand command = new SqlCommand(query, con);
           List<Users> users = new List<Users>();
           SqlDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               string fName = reader[0].ToString();
               int userId = Convert.ToInt32(reader[1].ToString());
               string userName = reader[2].ToString();
               Users user = new Users();
               user.FullName = fName;
               user.UserId = userId;
               user.UserName = userName;
               users.Add(user);
           }
           con.Close();
           return users;


       }

      
   }
}
