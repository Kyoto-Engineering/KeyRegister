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
  public   class TerritoryGateway:ConnectionGateway
    {
        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int SaveTerritory(Territory aTerritory)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string query = "INSERT INTO Territory(TerritoryName,CompanyId,UserId,CreatedDateTime) VALUES(@d1,@d2,@d3,@d4)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@d1", aTerritory.TerritoryName);
            cmd.Parameters.AddWithValue("@d2", aTerritory.CompanyId);
            cmd.Parameters.AddWithValue("@d3", aTerritory.TUserId);
            cmd.Parameters.AddWithValue("@d4", aTerritory.CreatedDateTime);
            int affectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows;


        }

        public List<Territory> GetTerritoryName()
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string query = "Select TerritoryId,TerritoryName from Territory ";
            cmd = new SqlCommand(query, conn);


            List<Territory> aTerritories = new List<Territory>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string territoryId = reader[0].ToString();
                string territopryName = reader[1].ToString();
                Territory aterritory = new Territory();
                aterritory.TerritoryId = Convert.ToInt32(territoryId);
                aterritory.TerritoryName = territopryName;
                aTerritories.Add(aterritory);
            }
            conn.Close();
            return aTerritories;
        }
    }
}
