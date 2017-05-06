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
  public  class  LocationInChargeGateway: ConnectionGateway
  {
      private SqlConnection con;
      private SqlCommand cmd;
      private SqlDataReader rdr;
      ConnectionString cs=new ConnectionString();
        public  int  SaveLocationInCharge(LocationInCharges aLocationInCharges)
        {
            con=new SqlConnection(cs.DBConn);
            con.Open();
            string q = "select FullName,UserId, UserName  from  Users where Statuss='Active'";
            string query = "INSERT INTO  LocationIncharge(UserId,LocationId,AssignDate,Assignedby) VALUES(@d1,@d2,@d3,@d4)";
            cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@d1", aLocationInCharges.LUserId);
            cmd.Parameters.AddWithValue("@d2", aLocationInCharges.LocationId);
            cmd.Parameters.AddWithValue("@d3", aLocationInCharges.AssignDate);
            cmd.Parameters.AddWithValue("@d4", aLocationInCharges.AssignedBy);
           int affectedRows= cmd.ExecuteNonQuery();
           con.Close();
            return affectedRows;
           


        }

        public List<Users> GetUserName()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string q = "select FullName,UserId, UserName  from  Users where Statuss='Active'";
          //  string query = "SELECT  Users.FullName,Users.UserId,Users.UserName  FROM  LocationIncharge INNER JOIN Users ON LocationIncharge.UserId = Users.UserId";
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandText = q;
            List<Users> users = new List<Users>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                string fName = reader[0].ToString();
                string userId = reader[1].ToString();
                string userName = reader[2].ToString();

                Users user = new Users();
                user.FullName = fName;
                user.UserId = Convert.ToInt16(userId);
                user.UserName = userName;
                users.Add(user);
            }
            con.Close();
            return users;
        }
  }
}
