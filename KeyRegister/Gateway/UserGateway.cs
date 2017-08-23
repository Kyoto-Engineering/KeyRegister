using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.DAO;
using KeyRegister.DBGateway;

namespace KeyRegister.Gateway
{
    public class UserGateway : ConnectionGateway
    {
        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        EmailAddress eAddress;
        private Gender aGender;
        private Countries aCountries;
        private Designations aDesignations;
        private MaritalStatus aMaritalStatus;
        public int affectedRows1, affectedRows2, affectedRows3, affectedRows4, affectedRows5;

        public int SaveUserDetails(Users aUser)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string query = String.Format("insert into Users(UserName,Password,EmployeeId,FullName,NickName,FatherName,MotherName,CountryId,DesignationId,NationalId,PassportNumber,BirthCertificateNumber,GenderId,MaritalStatusId,DateOfBirth,Statuss) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)") + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@d1", aUser.UserName);
            cmd.Parameters.AddWithValue("@d2", aUser.Password);
            cmd.Parameters.AddWithValue("@d3", aUser.EmployeeId);
            cmd.Parameters.AddWithValue("@d4", aUser.FullName);
            cmd.Parameters.AddWithValue("@d5", string.IsNullOrWhiteSpace(aUser.NickName) ? (object)DBNull.Value : aUser.NickName);           
            cmd.Parameters.AddWithValue("@d6", aUser.FatherName);
            cmd.Parameters.AddWithValue("@d7", aUser.MotherName);          
            cmd.Parameters.AddWithValue("@d9", aUser.CountryId);
            cmd.Parameters.AddWithValue("@d10", aUser.DesignationId == null ? (int?)null : Convert.ToInt32(aUser.DesignationId));
           // cmd.Parameters.AddWithValue( "@d10",!int.Parse(aUser.DesignationId)? Convert.ToInt32(aUser.DesignationId) : DBNull.Value);
            //int value;
            //if (int.TryParse(aUser.DesignationId, out value))
            //{
            //    DR["CustomerID"] = value;
            //}
            //else
            //{
            //    DR["CustomerID"] = DBNull.Value;
            //}    
           // cmd.Parameters.AddWithValue("@d10",aUser.DesignationId == null ? (int?)null : Convert.ToInt32(aUser.DesignationId));
           // cmd.Parameters.AddWithValue("@@d10", aUser.DesignationId ?? DBNull.Value);
            //cmd.Parameters.AddWithValue("@d10",aUser.DesignationId.HasValue ? aUser.DesignationId.Value : DBNull.Value;)
            cmd.Parameters.AddWithValue("@d11", string.IsNullOrWhiteSpace(aUser.NationalId) ? (object)DBNull.Value : aUser.NationalId);            
            cmd.Parameters.AddWithValue("@d12", string.IsNullOrWhiteSpace(aUser.PassportNo) ? (object)DBNull.Value : aUser.PassportNo);            
            cmd.Parameters.AddWithValue("@d13", string.IsNullOrWhiteSpace(aUser.BirthCertificateNo) ? (object)DBNull.Value : aUser.BirthCertificateNo);
            cmd.Parameters.AddWithValue("@d14", aUser.GenderId);
            cmd.Parameters.AddWithValue("@d15", aUser.MaritalStatusId);          
            DateTime dt = DateTime.Now;
            DateTime dt1 = aUser.DateOfBirth.Value;
            string date = dt.ToShortDateString();
            string date1 = dt1.ToShortDateString();
            if (date == date1)
            {
                cmd.Parameters.AddWithValue("@d16", aUser.DateOfBirth).Value = DBNull.Value;

            }
            else
            {
                cmd.Parameters.AddWithValue("@d16", aUser.DateOfBirth).Value = aUser.DateOfBirth.Value;
            }
            cmd.Parameters.AddWithValue("@d17", aUser.EmpStatus);                     
            affectedRows1 = (int) cmd.ExecuteScalar();
            conn.Close();
            return affectedRows1;


        }

        public int SavePresentAddress(PresentAddress apresentAddress)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string qry2 = "insert into PresentAddresses(PrFlatNo,PrHouseNo,PrRoadNo,PrBlock,PrArea,PrLandMark,PrRoadName,PrBuilding,PostOfficeId,UserId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
            cmd = new SqlCommand(qry2, conn);                     
            cmd.Parameters.AddWithValue("@d1",string.IsNullOrEmpty(apresentAddress.PreFlatNo) ? (object) DBNull.Value : apresentAddress.PreFlatNo);            
            cmd.Parameters.AddWithValue("@d2", string.IsNullOrWhiteSpace(apresentAddress.PreHouseNo)?(object)DBNull.Value:apresentAddress.PreHouseNo);
            cmd.Parameters.AddWithValue("@d3", string.IsNullOrWhiteSpace(apresentAddress.PreRoadNo) ? (object)DBNull.Value : apresentAddress.PreRoadNo);
            cmd.Parameters.AddWithValue("@d4", string.IsNullOrWhiteSpace(apresentAddress.PreBlock) ? (object)DBNull.Value : apresentAddress.PreBlock);
            cmd.Parameters.AddWithValue("@d5", string.IsNullOrWhiteSpace(apresentAddress.PreArea) ? (object)DBNull.Value : apresentAddress.PreArea);
            cmd.Parameters.AddWithValue("@d6", string.IsNullOrWhiteSpace(apresentAddress.PreLandmark) ? (object)DBNull.Value : apresentAddress.PreLandmark);
            cmd.Parameters.AddWithValue("@d7", string.IsNullOrWhiteSpace(apresentAddress.PreRoadName) ? (object)DBNull.Value : apresentAddress.PreRoadName);
            cmd.Parameters.AddWithValue("@d8", string.IsNullOrWhiteSpace(apresentAddress.PreBuilding) ? (object)DBNull.Value : apresentAddress.PreBuilding);          
            cmd.Parameters.AddWithValue("@d9", apresentAddress.PrePostOfficeId);
            cmd.Parameters.AddWithValue("@d10", apresentAddress.UserId);
            affectedRows2 = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows2;
           
            //  cmd.Parameters.AddWithValue("@d1", apresentAddress.PreFlatNo);
            //cmd.Parameters.AddWithValue("@d2", apresentAddress.PreHouseNo);
            // cmd.Parameters.AddWithValue("@d3", apresentAddress.PreRoadNo);
            //cmd.Parameters.AddWithValue("@d4", apresentAddress.PreBlock);
            //cmd.Parameters.AddWithValue("@d5", apresentAddress.PreArea);
            //cmd.Parameters.AddWithValue("@d6", apresentAddress.PreLandmark);
            //cmd.Parameters.AddWithValue("@d7", apresentAddress.PreRoadName);
            //cmd.Parameters.AddWithValue("@d8", apresentAddress.PreBuilding);
        }

        public int SavePermanantAddress(PerManantAddress aperAddress)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string qry22 = "insert into ParmanentAddresses(PaFlatNo,PaHouseNo,PaRoadNo,PaBlock,PaArea,PaLandMark,PaRoadName,PaBuilding,PostOfficeId,UserId) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
            cmd = new SqlCommand(qry22, conn);
            cmd.Parameters.AddWithValue("@d1", string.IsNullOrEmpty(aperAddress.PerFlatNo) ? (object)DBNull.Value : aperAddress.PerFlatNo);
            cmd.Parameters.AddWithValue("@d2", string.IsNullOrWhiteSpace(aperAddress.PerHouseNo) ? (object)DBNull.Value : aperAddress.PerHouseNo);
            cmd.Parameters.AddWithValue("@d3", string.IsNullOrWhiteSpace(aperAddress.PerRoadNo) ? (object)DBNull.Value : aperAddress.PerRoadNo);
            cmd.Parameters.AddWithValue("@d4", string.IsNullOrWhiteSpace(aperAddress.PerBlock) ? (object)DBNull.Value : aperAddress.PerBlock);
            cmd.Parameters.AddWithValue("@d5", string.IsNullOrWhiteSpace(aperAddress.PerArea) ? (object)DBNull.Value : aperAddress.PerArea);
            cmd.Parameters.AddWithValue("@d6", string.IsNullOrWhiteSpace(aperAddress.PerLandmark) ? (object)DBNull.Value : aperAddress.PerLandmark);
            cmd.Parameters.AddWithValue("@d7", string.IsNullOrWhiteSpace(aperAddress.PerRoadName) ? (object)DBNull.Value : aperAddress.PerRoadName);
            cmd.Parameters.AddWithValue("@d8", string.IsNullOrWhiteSpace(aperAddress.PerBuilding) ? (object)DBNull.Value : aperAddress.PerBuilding);                      
            cmd.Parameters.AddWithValue("@d9", aperAddress.PerPostOfficeId);
            cmd.Parameters.AddWithValue("@d10", aperAddress.PerUserId);
            affectedRows3 = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows3;


            //cmd.Parameters.AddWithValue("@d1", aperAddress.PerFlatNo);
            //cmd.Parameters.AddWithValue("@d2", aperAddress.PerHouseNo);
            //cmd.Parameters.AddWithValue("@d3", aperAddress.PerRoadNo);
            //cmd.Parameters.AddWithValue("@d4", aperAddress.PerBlock);
            //cmd.Parameters.AddWithValue("@d5", aperAddress.PerArea);
            //cmd.Parameters.AddWithValue("@d6", aperAddress.PerLandmark);
            //cmd.Parameters.AddWithValue("@d7", aperAddress.PerRoadName);
            //cmd.Parameters.AddWithValue("@d8", aperAddress.PerBuilding);
        }

        public int SaveOverSeasAddress(OverSeasAddress ovAddress)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string qry = "insert into ForeignAddress(Street,State,PostalCode,UserId) Values(@d1,@d2,@d3,@d4)";
            cmd = new SqlCommand(qry, conn);
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
            string query = "SELECT  FullName, UserId, UserName FROM   Users where Statuss='Active'";
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

        public int PerManantSameAsPresentAddress(PresentAddress apresentAddress)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string qry22 = "insert into ParmanentAddresses(PaFlatNo,PaHouseNo,PaRoadNo,PaBlock,PaArea,PaLandMark,PaRoadName,PaBuilding,PostOfficeId,UserId) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
            cmd = new SqlCommand(qry22, conn);
            cmd.Parameters.AddWithValue("@d1", string.IsNullOrEmpty(apresentAddress.PreFlatNo) ? (object)DBNull.Value : apresentAddress.PreFlatNo);
            cmd.Parameters.AddWithValue("@d2", string.IsNullOrWhiteSpace(apresentAddress.PreHouseNo) ? (object)DBNull.Value : apresentAddress.PreHouseNo);
            cmd.Parameters.AddWithValue("@d3", string.IsNullOrWhiteSpace(apresentAddress.PreRoadNo) ? (object)DBNull.Value : apresentAddress.PreRoadNo);
            cmd.Parameters.AddWithValue("@d4", string.IsNullOrWhiteSpace(apresentAddress.PreBlock) ? (object)DBNull.Value : apresentAddress.PreBlock);
            cmd.Parameters.AddWithValue("@d5", string.IsNullOrWhiteSpace(apresentAddress.PreArea) ? (object)DBNull.Value : apresentAddress.PreArea);
            cmd.Parameters.AddWithValue("@d6", string.IsNullOrWhiteSpace(apresentAddress.PreLandmark) ? (object)DBNull.Value : apresentAddress.PreLandmark);
            cmd.Parameters.AddWithValue("@d7", string.IsNullOrWhiteSpace(apresentAddress.PreRoadName) ? (object)DBNull.Value : apresentAddress.PreRoadName);
            cmd.Parameters.AddWithValue("@d8", string.IsNullOrWhiteSpace(apresentAddress.PreBuilding) ? (object)DBNull.Value : apresentAddress.PreBuilding);
            cmd.Parameters.AddWithValue("@d9", apresentAddress.PrePostOfficeId);
            cmd.Parameters.AddWithValue("@d10", apresentAddress.UserId);
            affectedRows5 = cmd.ExecuteNonQuery();
            conn.Close();
            return affectedRows3;
            //cmd.Parameters.AddWithValue("@d1", aperAddress.PerFlatNo);
            //cmd.Parameters.AddWithValue("@d2", aperAddress.PerHouseNo);
            //cmd.Parameters.AddWithValue("@d3", aperAddress.PerRoadNo);
            //cmd.Parameters.AddWithValue("@d4", aperAddress.PerBlock);
            //cmd.Parameters.AddWithValue("@d5", aperAddress.PerArea);
            //cmd.Parameters.AddWithValue("@d6", aperAddress.PerLandmark);
            //cmd.Parameters.AddWithValue("@d7", aperAddress.PerRoadName);
            //cmd.Parameters.AddWithValue("@d8", aperAddress.PerBuilding);
        }

        public Users GetUserDetails(string employeeId)
        {           
                conn = new SqlConnection(cs.DBConn);
                conn.Open();
                string query = string.Format("SELECT Users.FullName, Users.NickName, Users.FatherName, Users.MotherName, (Users.UserName+'@'+EmailHostBank.EmailHostName) as Email,Countries.CountryName,Designations.Designation, Users.NationalId, Users.BirthCertificateNumber,Users.PassportNumber, Gender.GenderName,MaritalStatuss.MaritalStatus FROM  Users INNER JOIN EmailHostBank ON Users.EmailHostId = EmailHostBank.EmailHostId INNER JOIN Countries ON Users.CountryId = Countries.CountryId INNER JOIN Designations ON Users.DesignationId = Designations.DesignationId  INNER JOIN   Gender ON Users.GenderId = Gender.GenderId  INNER JOIN MaritalStatuss ON Users.MaritalStatusId = MaritalStatuss.MaritalStatusId where Users.EmployeeId='{0}'", employeeId);
                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                Users nUsers = new Users();
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

        public int SaveEmailAddress(EmailAddress address)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string query = "INSERT INTO  EmailBank(Email) VALUES(@d1)";            
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@d1", address.EmailAddressId);
            int instantId = cmd.ExecuteNonQuery();           
            conn.Close();
            return instantId;

        }



        public PerManantAddress GetPermanantAddress(int nUserId)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string query = "SELECT  ParmanentAddresses.PaFlatNo, ParmanentAddresses.PaHouseNo, ParmanentAddresses.PaRoadNo, ParmanentAddresses.PaBlock, ParmanentAddresses.PaArea, Divisions.Division, Districts.District,Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM  ParmanentAddresses INNER JOIN  Users ON ParmanentAddresses.UserId = Users.UserId INNER JOIN PostOffice ON ParmanentAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where ParmanentAddresses.UserId='" + nUserId + "'";
            cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            PerManantAddress address = new PerManantAddress();
            while (reader.Read())
            {
                address.PerFlatNo = reader[0].ToString();
                address.PerHouseNo = reader[1].ToString();
                address.PerRoadNo = reader[2].ToString();
                address.PerBlock = reader[3].ToString();
                address.PerArea = reader[4].ToString();
                address.PerDivision = reader[5].ToString();
                address.PerDistrict = reader[6].ToString();
                address.PerThana = reader[7].ToString();
                address.PostOfficeName = reader[8].ToString();
                address.PerPostCode = reader[9].ToString();
            }
            reader.Close();
            conn.Close();
            return address;
        }

        public  PresentAddress GetPresentAddress(int n1userId)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string query = "SELECT PresentAddresses.PrFlatNo,PresentAddresses.PrHouseNo,PresentAddresses.PrRoadNo,PresentAddresses.PrBlock, PresentAddresses.PrArea, Divisions.Division, Districts.District, Thanas.Thana,PostOffice.PostOfficeName, PostOffice.PostCode FROM  PresentAddresses INNER JOIN PostOffice ON PresentAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID where PresentAddresses.UserId='"+n1userId+"'";
            cmd=new SqlCommand(query,conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            PresentAddress apAddress = new PresentAddress();
            while (rdr.Read())
            {
                apAddress.PreFlatNo = rdr[0].ToString();
                apAddress.PreHouseNo = rdr[1].ToString();
                apAddress.PreRoadNo = rdr[2].ToString();
                apAddress.PreBlock = rdr[3].ToString();
                apAddress.PreArea = rdr[4].ToString();
                apAddress.PreDivision = rdr[5].ToString();
                apAddress.PreDistrict = rdr[6].ToString();
                apAddress.PreThana = rdr[7].ToString();
                apAddress.PostOfficeName = rdr[8].ToString();
                apAddress.PrePostCode = rdr[9].ToString();

            }
            rdr.Close();
            conn.Close();
            return apAddress;
        }

        public  void UpdateUserInfo(Users auser)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string update = "Update  Users Set FullName=@d1,NickName=@d2,FatherName=@d3,MotherName=@d4,CountryId=@d5,DesignationId=@d6,NationalId=@d7,BirthCertificateNumber=@d8,PassportNumber=@d9,GenderId=@d10,MaritalStatusId=@d11,DateOfBirth=@d12  where Users.UserId='" + auser.UserId + "'";
            cmd=new SqlCommand(update,conn);
            cmd.Parameters.AddWithValue("@d1", auser.FullName);
            cmd.Parameters.AddWithValue("@d2", string.IsNullOrWhiteSpace(auser.NickName) ? (object)DBNull.Value : auser.NickName);                      
            cmd.Parameters.AddWithValue("@d3", auser.FatherName);
            cmd.Parameters.AddWithValue("@d4", auser.MotherName);          
            cmd.Parameters.AddWithValue("@d5", auser.CountryId);
            //cmd.Parameters.AddWithValue("@d6", auser.DesignationId);
            cmd.Parameters.AddWithValue("@d6", auser.DesignationId == null ? (int?)null : Convert.ToInt32(auser.DesignationId));
            cmd.Parameters.AddWithValue("@d7", string.IsNullOrWhiteSpace(auser.NationalId) ? (object)DBNull.Value : auser.NationalId);
            cmd.Parameters.AddWithValue("@d8", string.IsNullOrWhiteSpace(auser.PassportNo) ? (object)DBNull.Value : auser.PassportNo);
            cmd.Parameters.AddWithValue("@d9", string.IsNullOrWhiteSpace(auser.BirthCertificateNo) ? (object)DBNull.Value : auser.BirthCertificateNo);
            cmd.Parameters.AddWithValue("@d10", auser.GenderId);
            cmd.Parameters.AddWithValue("@d11", auser.MaritalStatusId);
            DateTime dt = DateTime.Now;
            DateTime dt1 = auser.DateOfBirth.Value;
            string date = dt.ToShortDateString();
            string date1 = dt1.ToShortDateString();
            if (date == date1)
            {
                cmd.Parameters.AddWithValue("@d12", auser.DateOfBirth).Value = DBNull.Value;

            }                     
            cmd.ExecuteReader();
            conn.Close();
        }

        public  void UpdatePermanantAddress(PerManantAddress apAddress)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string query = "Update ParmanentAddresses Set PaFlatNo=@d1,PaHouseNo=@d2,PaRoadNo=@d3,PaBlock=@d4,PaArea=@d5,PaLandMark=@d6,PaRoadName=@d7,PaBuilding=@d8,PostOfficeId=@d9 where ParmanentAddresses.UserId='" + apAddress.PerUserId + "'";
            cmd=new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@d1",string.IsNullOrEmpty(apAddress.PerFlatNo) ? (object)DBNull.Value : apAddress.PerFlatNo);
            cmd.Parameters.AddWithValue("@d2",string.IsNullOrWhiteSpace(apAddress.PerHouseNo) ? (object)DBNull.Value : apAddress.PerHouseNo);
            cmd.Parameters.AddWithValue("@d3",string.IsNullOrWhiteSpace(apAddress.PerRoadNo) ? (object)DBNull.Value : apAddress.PerRoadNo);
            cmd.Parameters.AddWithValue("@d4",string.IsNullOrWhiteSpace(apAddress.PerBlock) ? (object)DBNull.Value : apAddress.PerBlock);
            cmd.Parameters.AddWithValue("@d5",string.IsNullOrWhiteSpace(apAddress.PerArea) ? (object)DBNull.Value : apAddress.PerArea);
            cmd.Parameters.AddWithValue("@d6",string.IsNullOrWhiteSpace(apAddress.PerLandmark) ? (object)DBNull.Value : apAddress.PerLandmark);
            cmd.Parameters.AddWithValue("@d7",string.IsNullOrWhiteSpace(apAddress.PerRoadName) ? (object)DBNull.Value : apAddress.PerRoadName);
            cmd.Parameters.AddWithValue("@d8",string.IsNullOrWhiteSpace(apAddress.PerBuilding) ? (object)DBNull.Value : apAddress.PerBuilding);                                  
            cmd.Parameters.AddWithValue("@d9",apAddress.PerPostOfficeId);           
            cmd.ExecuteReader();
            conn.Close();

        }

        public  void UpdatePresentAddress(PresentAddress akAddress)
        {
            conn=new SqlConnection(cs.DBConn);
            conn.Open();
            string qry = "Update PresentAddresses Set PrFlatNo=@d1,PrHouseNo=@d2,PrRoadNo=@d3,PrBlock=@d4,PrArea=@d5,PrLandMark=@d6,PrRoadName=@d7,PrBuilding=@d8,PostOfficeId=@d9 where UserId='" + akAddress.UserId + "' ";           
            cmd=new SqlCommand(qry,conn);
            cmd.Parameters.AddWithValue("@d1", string.IsNullOrEmpty(akAddress.PreFlatNo) ? (object)DBNull.Value : akAddress.PreFlatNo);
            cmd.Parameters.AddWithValue("@d2", string.IsNullOrWhiteSpace(akAddress.PreHouseNo) ? (object)DBNull.Value : akAddress.PreHouseNo);
            cmd.Parameters.AddWithValue("@d3", string.IsNullOrWhiteSpace(akAddress.PreRoadNo) ? (object)DBNull.Value : akAddress.PreRoadNo);
            cmd.Parameters.AddWithValue("@d4", string.IsNullOrWhiteSpace(akAddress.PreBlock) ? (object)DBNull.Value : akAddress.PreBlock);
            cmd.Parameters.AddWithValue("@d5", string.IsNullOrWhiteSpace(akAddress.PreArea) ? (object)DBNull.Value : akAddress.PreArea);
            cmd.Parameters.AddWithValue("@d6", string.IsNullOrWhiteSpace(akAddress.PreLandmark) ? (object)DBNull.Value : akAddress.PreLandmark);
            cmd.Parameters.AddWithValue("@d7", string.IsNullOrWhiteSpace(akAddress.PreRoadName) ? (object)DBNull.Value : akAddress.PreRoadName);
            cmd.Parameters.AddWithValue("@d8", string.IsNullOrWhiteSpace(akAddress.PreBuilding) ? (object)DBNull.Value : akAddress.PreBuilding);          
            cmd.Parameters.AddWithValue("@d9", akAddress.PrePostOfficeId);
            cmd.ExecuteReader();
            conn.Close();
        }
        public  int  SaveUserEmail(UserEmail aEmail)
        {
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string query = "INSERT INTO UserEmail(UserPart,EmailHostId,UserId,IsPrimaryKey) VALUES(@d1,@d2,@d3,@d4)";
            cmd=new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@d1", aEmail.UserPart);
            cmd.Parameters.AddWithValue("@d2", aEmail.HostEmailId);
            cmd.Parameters.AddWithValue("@d3", aEmail.UserId);
            cmd.Parameters.AddWithValue("@d4", aEmail.IsPrimaryStatus);
            int affectedRows=cmd.ExecuteNonQuery();           
            conn.Close();
            return affectedRows;
        }




        public  void UpdateUserEmail()
        {
            UserEmail aEmail=new UserEmail();
            conn = new SqlConnection(cs.DBConn);
            conn.Open();
            string qry = "Update UserEmail Set EmailHostId=@d1 where UserEmail.UserId='" + aEmail.UserId + "' and UserEmail.IsPrimaryKey='"+aEmail.IsPrimaryStatus+"'";            
            cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@d1", aEmail.HostEmailId);                       
            cmd.ExecuteReader();
            conn.Close();
        }
    }
}
