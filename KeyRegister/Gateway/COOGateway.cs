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
  public  class COOGateway:ConnectionGateway
    {

        public  string SaveCOO(ModelCOO amCOO)
        {
           connection.Open();
           string qry = string.Format("INSERT  INTO COO(CompanyId,JoiningDate,CreationDate,UserId) VALUES(@d1,@d2,@d3,@d4)");
            SqlCommand cmd=new SqlCommand(qry,connection);
            cmd.Parameters.AddWithValue("@d1", amCOO.CompanyId);
            cmd.Parameters.AddWithValue("@d2", amCOO.JoiningDate);
            cmd.Parameters.AddWithValue("@d3", amCOO.CreationDate);
            cmd.Parameters.AddWithValue("@d4", amCOO.UserId);
           int affectedRows=  cmd.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                return "Suucessfully Saved";
            }
            else
            {
                return "Data is not in a Correct Format";
            }

        }


        public List<User> GetUserName()
        {
            connection.Open();
            string query = "select FullName,UserId, UserName  from  Users where Statuss='Active'";
            SqlCommand command = new SqlCommand(query,connection);
            List<User> users=new List<User>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string fName = reader[0].ToString();
                int userId = Convert.ToInt32(reader[1].ToString());
                string userName = reader[2].ToString();
                User  user=new User();
                user.FullName = fName;
                user.UserId = userId;
                user.UserName = userName;
                users.Add(user);
            }
            connection.Close();
            return users;


        }
    }
}
