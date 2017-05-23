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
   public  class LockGateway
   {
       private SqlConnection con;
       private SqlCommand cmd;
       private SqlDataReader rdr;
       ConnectionString cs=new ConnectionString();


       public  int SaveLock(Lock aLock)
       {
           con=new SqlConnection(cs.DBConn);
           con.Open();
           string query = "INSERT INTO Lock(PropertyId,LockNo,LockTypeId,UserId,CreatedDateTime) VALUES(@d1,@d2,@d3,@d4,@d5)";
           cmd=new SqlCommand(query,con);
           cmd.Parameters.AddWithValue("@d1", aLock.PropertyId);
           cmd.Parameters.AddWithValue("@d2", aLock.LockNo);
           cmd.Parameters.AddWithValue("@d3", aLock.LockTypeId);
           cmd.Parameters.AddWithValue("@d4", aLock.LUserId);
           cmd.Parameters.AddWithValue("@d5", aLock.CreatedDateTime); 
           int affectedrows= cmd.ExecuteNonQuery();
           con.Close();
           return affectedrows;
       }

       public  List<Lock> GetLockNumber(LockGateway aGateway)
       {
           con=new SqlConnection(cs.DBConn);
           con.Open();
           string query = "Select LockId,LockNo from Lock  order by LockId desc";
           cmd=new SqlCommand(query,con);
          
           List<Lock> locks=new List<Lock>();
           SqlDataReader reader = cmd.ExecuteReader();
           while (reader.Read())
           {
               string lockId = reader[0].ToString();
               string lockNo = reader[1].ToString();
               Lock aLock=new Lock();
               aLock.LockId = Convert.ToInt32(lockId);
               aLock.LockNo = lockNo;
               locks.Add(aLock);
           }
           con.Close();
           return locks;
       }
   }
}
