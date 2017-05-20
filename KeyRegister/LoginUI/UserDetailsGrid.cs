using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.DBGateway;

namespace KeyRegister.LoginUI
{
    public partial class UserDetailsGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        private SqlDataAdapter sda;
        public UserDetailsGrid()
        {
            InitializeComponent();
        }
        private void InquiryClientDetailsGrid()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            sda = new SqlDataAdapter("Select FirstSet.Name RM,FirstSet.IClientId ClientId,FirstSet.ClientName ClientName,FirstSet.ClientType  ClientType,FirstSet.ClientNature NatureOfClient,FirstSet.Email EmailId,FirstSet.IndustryCategory ,FirstSet.EndUser,thirdq.ContactPersonName,thirdq.Designation, thirdq.CellNumber,thirdq.Email,FirstSet.CFlatNo,FirstSet.CHouseNo,FirstSet.CRoadNo,FirstSet.CBlock,FirstSet.CArea,FirstSet.CContactNo,FirstSet.Division CDivition,FirstSet.District CDistrict,FirstSet.Thana CPoliceStation,FirstSet.PostOfficeName CPostOfficeName,FirstSet.PostCode CPostCode,QUERYTWO.TFlatNo,QUERYTWO.THouseNo,QUERYTWO.TRoadNo,QUERYTWO.TBlock,QUERYTWO.TArea,QUERYTWO.TContactNo,QUERYTWO.Division TDivision,QUERYTWO.District TDistrict,QUERYTWO.Thana TThana,QUERYTWO.PostOfficeName TPostOfficeName,QUERYTWO.PostCode TPostCode from (SELECT Registration.Name,InquieryClient.IClientId,InquieryClient.ClientName,ClientTypes.ClientType,NatureOfClients.ClientNature,EmailBank.Email,IndustryCategorys.IndustryCategory,InquieryClient.EndUser,CorporateAddresses.CFlatNo,CorporateAddresses.CHouseNo,CorporateAddresses.CRoadNo,CorporateAddresses.CBlock,CorporateAddresses.CArea,CorporateAddresses.CContactNo,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  InquieryClient  INNER JOIN  Registration ON InquieryClient.SuperviserId = Registration.UserId INNER JOIN ClientTypes ON InquieryClient.ClientTypeId = ClientTypes.ClientTypeId  INNER JOIN NatureOfClients ON InquieryClient.NatureOfClientId = NatureOfClients.NatureOfClientId   INNER JOIN IndustryCategorys ON InquieryClient.IndustryCategoryId = IndustryCategorys.IndustryCategoryId INNER JOIN CorporateAddresses ON InquieryClient.IClientId = CorporateAddresses.IClientId  INNER JOIN PostOffice ON CorporateAddresses.PostOfficeId = PostOffice.PostOfficeId  INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID   INNER JOIN  Divisions ON Districts.Division_ID = Divisions.Division_ID   Left Join EmailBank ON InquieryClient.EmailBankId= EmailBank.EmailBankId)  AS FirstSet  lEFT jOIN (SELECT InquieryClient.IClientId,TraddingAddresses.TFlatNo,TraddingAddresses.THouseNo,TraddingAddresses.TRoadNo,TraddingAddresses.TBlock,TraddingAddresses.TArea,TraddingAddresses.TContactNo,Divisions.Division,Districts.District,Thanas.Thana,PostOffice.PostOfficeName,PostOffice.PostCode  FROM  InquieryClient   INNER JOIN TraddingAddresses ON InquieryClient.IClientId = TraddingAddresses.IClientId INNER JOIN PostOffice ON TraddingAddresses.PostOfficeId = PostOffice.PostOfficeId  INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN  Divisions ON Districts.Division_ID = Divisions.Division_ID) aS QUERYTWO ON FirstSet.IClientId =  QUERYTWO.IClientId left join (SELECT InquieryClient.IClientId,ContactPersonDetails.ContactPersonName,ContactPersonDetails.Designation,ContactPersonDetails.CellNumber,EmailBank.Email  FROM  InquieryClient  INNER JOIN ContactPersonDetails ON InquieryClient.IClientId = ContactPersonDetails.IClientId left join EmailBank on ContactPersonDetails.EmailBankId=EmailBank.EmailBankId) as thirdq on FirstSet.IClientId  = thirdq.IClientId", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void GetListOfUser()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT Users.FullName, Users.NickName, Users.FatherName, Users.MotherName, EmailBank.Email, Countries.CountryName, Designations.Designation, Users.NationalId, Users.BirthCertificateNumber,Users.PassportNumber, Gender.GenderName, MaritalStatuss.MaritalStatus FROM  Users INNER JOIN EmailBank ON Users.EmailBankId = EmailBank.EmailBankId INNER JOIN Countries ON Users.CountryId = Countries.CountryId INNER JOIN Designations ON Users.DesignationId = Designations.DesignationId INNER JOIN   Gender ON Users.GenderId = Gender.GenderId INNER JOIN MaritalStatuss ON Users.MaritalStatusId = MaritalStatuss.MaritalStatusId";
                sda=new SqlDataAdapter(query,con);
                DataTable dt=new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UserDetailsGrid_Load(object sender, EventArgs e)
        {
            GetListOfUser();
        }
    }
}
