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
  public   class PropertyGateway
  {
      private SqlConnection con;
      private SqlCommand cmd;
      private SqlDataReader rdr;
      ConnectionString cs=new ConnectionString();
        public  int SaveProperty(Property aProperty)
        {
            con=new SqlConnection(cs.DBConn);
            con.Open();
            string query = "INSERT INTO Property(PropertyName,LocationId,UserId,CreatedDateTime) VALUES(@d1,@d2,@d3,@d4)";
            cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@d1", aProperty.PropertyName);
            cmd.Parameters.AddWithValue("@d2", aProperty.LocationId);
            cmd.Parameters.AddWithValue("@d3", aProperty.LocationInChargeId);
            cmd.Parameters.AddWithValue("@d4", aProperty.CreatedDateTime);
            int affectedRows = cmd.ExecuteNonQuery();
            con.Close();
            return affectedRows;

        }

        public  List<Property> GetPropertyName()
        {
            con=new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select PropertyId,PropertyName from Property ";
            cmd=new SqlCommand(query,con);
            List<Property> aProperties=new List<Property>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string propertyId = reader[0].ToString();
                string propertyName = reader[1].ToString();
                Property aProperty=new Property();
                aProperty.PropertyId = Convert.ToInt32(propertyId);
                aProperty.PropertyName = propertyName;
                aProperties.Add(aProperty);
            }
            con.Close();
            return aProperties;
        }
  }
}
