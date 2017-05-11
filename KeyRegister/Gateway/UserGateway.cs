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
    public class UserGateway:ConnectionGateway
    {
        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
         EmailAddress eAddress;
        private Gender aGender;
        private Countries aCountries;
        private Designations aDesignations;
        private MaritalStatus aMaritalStatus;
        public int affectedRows1, affectedRows2, affectedRows3, affectedRows4, affectedRows5;
        public  int  SaveUserDetails(Users aUser)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string query = String.Format("insert into Users(UserName,Password,EmployeeId,FullName,NickName,FatherName,MotherName,EmailBankId,CountryId,DesignationId,NationalId,PassportNumber,BirthCertificateNumber,GenderId,MaritalStatusId,DateOfBirth) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)") + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd=new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@d1", aUser.UserName);
            cmd.Parameters.AddWithValue("@d2", aUser.EmployeeId);
            cmd.Parameters.AddWithValue("@d3", aUser.Password);
            cmd.Parameters.AddWithValue("@d4", aUser.FullName);
            cmd.Parameters.AddWithValue("@d5", aUser.NickName);
            cmd.Parameters.AddWithValue("@d6", aUser.FatherName);
            cmd.Parameters.AddWithValue("@d7", aUser.MotherName);

            cmd.Parameters.AddWithValue("@d8", aUser.EmailBankId);
            cmd.Parameters.AddWithValue("@d9", aUser.CountryId);
            cmd.Parameters.AddWithValue("@d10", aUser.DesignationId);
            cmd.Parameters.AddWithValue("@d11", aUser.NationalId);
            cmd.Parameters.AddWithValue("@d12", aUser.PassportNo);
            cmd.Parameters.AddWithValue("@d13", aUser.BirthCertificateNo);
            cmd.Parameters.AddWithValue("@d14", aUser.GenderId);           
            cmd.Parameters.AddWithValue("@d15", aUser.MaritalStatusId);
            cmd.Parameters.AddWithValue("@d16", aUser.DateOfBirth);           
            affectedRows1 = (int)cmd.ExecuteScalar();
            conn.Close();
            return affectedRows1;


        }

        public  int SavePresentAddress(PresentAddress apresentAddress)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string qry2 = "insert into PresentAddresses(PrFlatNo,PrHouseNo,PrRoadNo,PrBlock,PrArea,PostOfficeId,UserId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            cmd=new SqlCommand(qry2,conn);
            cmd.Parameters.AddWithValue("@d1", apresentAddress.PreFlatNo);
            cmd.Parameters.AddWithValue("@d2", apresentAddress.PreHouseNo);
            cmd.Parameters.AddWithValue("@d3", apresentAddress.PreRoadNo);
            cmd.Parameters.AddWithValue("@d4", apresentAddress.PreBlock);
            cmd.Parameters.AddWithValue("@d5", apresentAddress.PreArea);
            cmd.Parameters.AddWithValue("@d6", apresentAddress.PrePostOfficeId);
            cmd.Parameters.AddWithValue("@d7", apresentAddress.UserId);        
            affectedRows2 = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows2;

        }

        public  int SavePermanantAddress(PerManantAddress aperAddress)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string qry22 = "insert into ParmanentAddresses(PaFlatNo,PaHouseNo,PaRoadNo,PaBlock,PaArea,PostOfficeId,UserId) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            cmd=new SqlCommand(qry22,conn);

            cmd.Parameters.AddWithValue("@d1", aperAddress.PerFlatNo);
            cmd.Parameters.AddWithValue("@d2", aperAddress.PerHouseNo);
            cmd.Parameters.AddWithValue("@d3", aperAddress.PerRoadNo);
            cmd.Parameters.AddWithValue("@d4", aperAddress.PerBlock);
            cmd.Parameters.AddWithValue("@d5", aperAddress.PerArea);
            cmd.Parameters.AddWithValue("@d6", aperAddress.PerPostOfficeId);
            cmd.Parameters.AddWithValue("@d7", aperAddress.PerUserId);
            affectedRows3 = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows3;
        }

        public  int SaveOverSeasAddress(OverSeasAddress ovAddress)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string qry = "insert into ForeignAddress(Street,State,PostalCode,UserId) Values(@d1,@d2,@d3,@d4)";
            cmd=new SqlCommand(qry,conn);
            cmd.Parameters.AddWithValue("@d1", ovAddress.Street);
            cmd.Parameters.AddWithValue("@d2", ovAddress.State);
            cmd.Parameters.AddWithValue("@d3", ovAddress.PostalCode);
            cmd.Parameters.AddWithValue("@d4", ovAddress.OUserId);
            affectedRows4 = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows4;

        }

        public List<Users> GetUserName()
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();                   
            string query = "SELECT  Users.FullName,Users.UserId,Users.UserName  FROM  LocationIncharge INNER JOIN Users ON LocationIncharge.UserId = Users.UserId";
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = query;          
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
            conn.Close();
            return users;
        }
        public  int PerManantSameAsPresentAddress(PerManantAddress aperAddress)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string qry22 = "insert into ParmanentAddresses(PaFlatNo,PaHouseNo,PaRoadNo,PaBlock,PaArea,PostOfficeId,UserId) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            cmd = new SqlCommand(qry22, conn);
            cmd.Parameters.AddWithValue("@d1", aperAddress.PerFlatNo);
            cmd.Parameters.AddWithValue("@d2", aperAddress.PerHouseNo);
            cmd.Parameters.AddWithValue("@d3", aperAddress.PerRoadNo);
            cmd.Parameters.AddWithValue("@d4", aperAddress.PerBlock);
            cmd.Parameters.AddWithValue("@d5", aperAddress.PerArea);
            cmd.Parameters.AddWithValue("@d6", aperAddress.PerPostOfficeId);
            cmd.Parameters.AddWithValue("@d7", aperAddress.PerUserId);
            affectedRows5 = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows3;
        }

        public  Users GetUserDetails(string   employeeId)
        {
            eAddress=new EmailAddress();
            aCountries=new Countries();
            aDesignations=new Designations();
            aMaritalStatus=new MaritalStatus();
            aGender=new Gender();
           conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string query = string.Format("SELECT Users.FullName, Users.NickName, Users.FatherName, Users.MotherName, EmailBank.Email, Countries.CountryName, Designations.Designation, Users.NationalId, Users.BirthCertificateNumber,Users.PassportNumber, Gender.GenderName, MaritalStatuss.MaritalStatus FROM  Users INNER JOIN EmailBank ON Users.EmailBankId = EmailBank.EmailBankId INNER JOIN Countries ON Users.CountryId = Countries.CountryId INNER JOIN Designations ON Users.DesignationId = Designations.DesignationId INNER JOIN   Gender ON Users.GenderId = Gender.GenderId INNER JOIN MaritalStatuss ON Users.MaritalStatusId = MaritalStatuss.MaritalStatusId where Users.EmployeeId='{0}'", employeeId);
            cmd=new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Users  nUsers=new Users();
            while (reader.Read())
            {
                nUsers.FullName = reader[0].ToString();
                nUsers.NickName = reader[1].ToString();
                nUsers.FatherName = reader[2].ToString();
                nUsers.MotherName = reader[3].ToString();
                nUsers.EmailAdd = reader[4].ToString();
                nUsers.CountryName = reader[5].ToString();
                nUsers.DesignationName = reader[6].ToString();
                nUsers.NationalId = reader[7].ToString();
                nUsers.BirthCertificateNo = reader[8].ToString();
                nUsers.passportNumber = reader[9].ToString();
                
                nUsers.Genders = reader[10].ToString();
                nUsers.MaritalStatusss = reader[11].ToString();

            }

            reader.Close();
            conn.Close();
            return nUsers;
        }
    }
}
