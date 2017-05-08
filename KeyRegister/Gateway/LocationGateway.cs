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
  public  class LocationGateway:ConnectionGateway
  {
      private SqlConnection con;
      private SqlCommand cmd;
      private SqlDataReader rdr;
      ConnectionString cs=new ConnectionString();

        public  int  SaveLocation(Locations aLocation)
        {
           con=new SqlConnection(cs.DBConn);
            con.Open();
            string query = "INSERT INTO Location(LocationName,UserId,CreatedDateTime,TerritoryId) VALUES(@d1,@d2,@d3,@d4)";
            cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@d1", aLocation.LocationName);
            cmd.Parameters.AddWithValue("@d2", aLocation.LUserId);
            cmd.Parameters.AddWithValue("@d3", aLocation.CreateddateTime);
            cmd.Parameters.AddWithValue("@d4", aLocation.LTerritoryId);
            int affectedRows = cmd.ExecuteNonQuery();
            con.Close();
            return affectedRows;

        }

        public  List<Locations> GetLocationName()
        {
           con=new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select LocationId,LocationName from Location";
            cmd=new SqlCommand(query,con);
            List<Locations>  aLocationses=new List<Locations>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string locationId = reader[0].ToString();
                string locationName = reader[1].ToString();
                Locations aLocations=new Locations();
                aLocations.LocationId = Convert.ToInt32(locationId);
                aLocations.LocationName = locationName;
                aLocationses.Add(aLocations);
            }
            con.Close();
            return aLocationses;
        }
  }
}
