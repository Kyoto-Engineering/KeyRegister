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
      private SqlCommand cmd;
      private SqlDataReader rdr;

        public  int  SaveLocationInCharge(LocationInCharges aLocationInCharges)
        {
            connection.Open();
            string query = "INSERT INTO  LocationIncharge(UserId,LocationId,AssignDate,Assignedby) VALUES(@d1,@d2,@d3,@d4)";
            cmd=new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@d1", aLocationInCharges.LUserId);
            cmd.Parameters.AddWithValue("@d2", aLocationInCharges.LocationId);
            cmd.Parameters.AddWithValue("@d3", aLocationInCharges.AssignDate);
            cmd.Parameters.AddWithValue("@d4", aLocationInCharges.AssignedBy);
           int affectedRows= cmd.ExecuteNonQuery();
           connection.Close();
            return affectedRows;
           


        }
    }
}
