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
  public   class KeyGateway
  {
      private SqlConnection con;
      private SqlCommand cmd;
      private SqlDataReader rdr;
         ConnectionString cs=new ConnectionString();

         public  int SaveKey(Key aKey)
         {
             con=new SqlConnection(cs.DBConn);
             con.Open();
             string query = "INSERT INTO  Keys(KeyNo,KeyTypeId,LockId,KeyIsId,UserId,CreatedDateTime) VALUES(@d1,@d2,@d3,@d4,@d5,@d6)";
             cmd=new SqlCommand(query,con);
             cmd.Parameters.AddWithValue("@d1", aKey.KeyNo);
             cmd.Parameters.AddWithValue("@d2", aKey.KeyTypeId);
             cmd.Parameters.AddWithValue("@d3", aKey.KLockId);
             cmd.Parameters.AddWithValue("@d4", aKey.KeyIsId);
             cmd.Parameters.AddWithValue("@d5", aKey.KUserId);
             cmd.Parameters.AddWithValue("@d6", aKey.CreateddateTime);                         
             int affectedRows = cmd.ExecuteNonQuery();
             con.Close();
             return affectedRows;
         }

         public  List<KeyIss> GetKeyIss()
         {
             con=new SqlConnection(cs.DBConn);
             con.Open();
             string query = "Select RTRIM(KeyIs.KeyIsId),RTRIM(KeyIs.KeyIs) from KeyIs order by KeyIs.KeyIsId desc";
             cmd=new SqlCommand(query,con);

             List<KeyIss>  aKeyIsses=new List<KeyIss>();

             SqlDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
             {
                 string keyIsId = (rdr[0].ToString());
                 string keyIses = (rdr[1].ToString());
                 KeyIss  aKeyIsss=new KeyIss();
                 aKeyIsss.KeyIsId = Convert.ToInt32(keyIsId);
                 aKeyIsss.KeyIs = keyIses;
                 aKeyIsses.Add(aKeyIsss);
             }
             rdr.Close();
             con.Close();
             return aKeyIsses;


         }

         public  List<KeyTypes> GetKeyType()
         {
             con=new SqlConnection(cs.DBConn);
             con.Open();
             string query = "Select RTRIM(KeyType.KeyTypeId),RTRIM(KeyType.KeyTypeName) from  KeyType order by KeyType.KeyTypeId desc";
             cmd=new SqlCommand(query,con);
             List<KeyTypes> aKeyTypeses=new List<KeyTypes>();
             SqlDataReader rdr = cmd.ExecuteReader();
             while (rdr.Read())
             {
                 string keyTypeId = rdr[0].ToString();
                 string keyTypeName = rdr[1].ToString();
                 KeyTypes  aKeyTypes=new KeyTypes();
                 aKeyTypes.KeyTypeId = Convert.ToInt32(keyTypeId);
                 aKeyTypes.KeyType = keyTypeName;
                 aKeyTypeses.Add(aKeyTypes);
             }
             rdr.Close();
             con.Close();
             return aKeyTypeses;
         }
  }
}
