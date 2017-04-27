using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyRegister.DBGateway;

namespace KeyRegister.Gateway
{
  public  class LocationGateway:ConnectionGateway
  {
      private SqlCommand cmd;
      private SqlDataReader rdr;

        public  int  SaveLocation(DAO.Locations aLocation)
        {
           connection.Open();
           string query = "INSERT INTO Location(LocationName,UserId,CreatedDateTime,TerritoryId) VALUES(@d1,@d2,@d3,@d4)";
            cmd=new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@d1", aLocation.LocationName);
            cmd.Parameters.AddWithValue("@d2", aLocation.LUserId);
            cmd.Parameters.AddWithValue("@d3", aLocation.CreateddateTime);
            cmd.Parameters.AddWithValue("@d4", aLocation.LTerritoryId);
            int affectedRows = cmd.ExecuteNonQuery();
            connection.Close();
            return affectedRows;

        }
    }
}
