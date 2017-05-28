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
        public string g,a,a1,b,b1,c,c1,d,d1,x,x1,y,y1;
        public string userId;
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
                string query = "SELECT FU.UserId, FU.FullName, FU.NickName, FU.FatherName, FU.MotherName, FU.CountryName, FU.Designation, FU.NationalId,FU.BirthCertificateNumber, FU.PassportNumber,FU.GenderName, FU.MaritalStatus, FU.ParFlatNo As ParFlatNo,FU.ParHouseNo As ParHouseNo, FU.ParRoadNo As ParRoadNo, FU.ParBlock as ParBlock, FU.ParArea As ParArea,FU.ParLandMark as  ParLandMark, FU.ParRoadName As ParRoadName, FU.ParBuilding As ParBuilding,FU.ParDivision as ParDivision,FU.ParDistrict,FU.ParThana,FU.ParPostOfficeName,FU.ParPostCode, Q2.PreFlatNo as PreFlatNo,Q2.PreHouseNo As PreHouseNo,Q2.PreRoadNo As PreRoadNo,Q2.PreBlock As PreBlock,Q2.PreArea As PreArea,Q2.PreLandMark As PreLandmark,Q2.PreRoadName As PreRoadName,Q2.PrBuilding As PreBuilding,Q2.Division As PreDivision,Q2.District PreDistrict,Q2.Thana PreThana,Q2.PostOfficeName PrePostOfficeName,Q2.PostCode PrePostCode  from (SELECT f1.UserId, f1.FullName, f1.NickName, f1.FatherName, f1.MotherName, Countries.CountryName, Designations.Designation,f1.NationalId, f1.BirthCertificateNumber, f1.PassportNumber,  Gender.GenderName, MaritalStatuss.MaritalStatus,ParmanentAddresses.PaFlatNo As ParFlatNo, ParmanentAddresses.PaHouseNo As ParHouseNo, ParmanentAddresses.PaRoadNo As ParRoadNo,ParmanentAddresses.PaBlock as ParBlock, ParmanentAddresses.PaArea As ParArea,ParmanentAddresses.PaLandMark as  ParLandMark,ParmanentAddresses.PaRoadName As ParRoadName, ParmanentAddresses.PaBuilding As ParBuilding,Divisions.Division As ParDivision,Districts.District as ParDistrict,Thanas.Thana As ParThana,PostOffice.PostOfficeName as ParPostOfficeName,PostOffice.PostCode as ParPostCode FROM  Users f1  INNER JOIN Countries ON f1.CountryId = Countries.CountryId  INNER JOIN Designations ON f1.DesignationId = Designations.DesignationId INNER JOIN Gender ON f1.GenderId = Gender.GenderId INNER JOIN MaritalStatuss ON f1.MaritalStatusId = MaritalStatuss.MaritalStatusId  INNER JOIN ParmanentAddresses ON f1.UserId = ParmanentAddresses.UserId INNER JOIN PostOffice ON ParmanentAddresses.PostOfficeId = PostOffice.PostOfficeId  INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN  Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID INNER JOIN  PresentAddresses ON f1.UserId = PresentAddresses.UserId)  AS FU  lEFT jOIN ( SELECT   Users.UserId,PresentAddresses.PrFlatNo As PreFlatNo, PresentAddresses.PrHouseNo As PreHouseNo, PresentAddresses.PrRoadNo As PreRoadNo, PresentAddresses.PrBlock As PreBlock,PresentAddresses.PrArea As PreArea, PresentAddresses.PrLandMark As PreLandMark, PresentAddresses.PrRoadName As PreRoadName,PresentAddresses.PrBuilding, Divisions.Division, Districts.District, Thanas.Thana, PostOffice.PostOfficeName, PostOffice.PostCode FROM   Users INNER JOIN PresentAddresses ON Users.UserId = PresentAddresses.UserId INNER JOIN  PostOffice ON PresentAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID INNER JOIN  Districts ON Thanas.D_ID = Districts.D_ID INNER JOIN  Divisions ON Districts.Division_ID = Divisions.Division_ID) aS Q2 ON FU.UserId =  Q2.UserId";
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string k,h;
                DataGridViewRow dr = dataGridView1.CurrentRow;
                this.Hide();
                UserUpdateForm frm=new UserUpdateForm();
                frm.gUserId = dr.Cells[0].Value.ToString();
                frm.txtFullName.Text = dr.Cells[1].Value.ToString();
                frm.txtNickName.Text = dr.Cells[2].Value.ToString();
                frm.txtFatherName.Text = dr.Cells[3].Value.ToString();
                frm.txtMotherName.Text = dr.Cells[4].Value.ToString();
               k= frm.cmbCountry.Text = dr.Cells[5].Value.ToString();
                frm.cmbDesignation.Text = dr.Cells[6].Value.ToString();
                frm.txtNationalId.Text = dr.Cells[7].Value.ToString();
                frm.txtPassportNo.Text = dr.Cells[8].Value.ToString();
                frm.txtBirthCertificatNo.Text = dr.Cells[9].Value.ToString();
                frm.cmbGender.Text = dr.Cells[10].Value.ToString();
                frm.cmbMaritalStatus.Text = dr.Cells[11].Value.ToString();
               // frm.dateOfBirth.Text = dr.Cells[12].Value.ToString();
               a= frm.txtPreFlatNo.Text = dr.Cells[12].Value.ToString();
               b= frm.txtPreHouseNo.Text = dr.Cells[13].Value.ToString();
               c= frm.txtPreRoadNo.Text = dr.Cells[14].Value.ToString();
               d= frm.txtPreBlock.Text = dr.Cells[15].Value.ToString();
                x=frm.txtPreArea.Text = dr.Cells[16].Value.ToString();
                frm.txtPreLandMark.Text = dr.Cells[17].Value.ToString();
                frm.txtPreRoadName.Text = dr.Cells[18].Value.ToString();
                frm.txtPreBuildingName.Text = dr.Cells[19].Value.ToString();
                frm.PADivisionCombo.Text = dr.Cells[20].Value.ToString();
                frm.PADistrictCombo.Text = dr.Cells[21].Value.ToString();
                frm.PAThanaCombo.Text = dr.Cells[22].Value.ToString();
                frm.PAPostOfficeCombo.Text = dr.Cells[23].Value.ToString();
               y= frm.PAPostCodeText.Text = dr.Cells[24].Value.ToString();

                a1=frm.txtPerFlatNo.Text = dr.Cells[25].Value.ToString();
               b1= frm.txtPerHouseNo.Text = dr.Cells[26].Value.ToString();
               c1= frm.txtPerRoadNo.Text = dr.Cells[27].Value.ToString();
               d1= frm.txtPerBlock.Text = dr.Cells[28].Value.ToString();
               x1= frm.txtPerArea.Text = dr.Cells[29].Value.ToString();
                frm.txtPerLandMark.Text = dr.Cells[30].Value.ToString();
                frm.txtPerRoadName.Text = dr.Cells[31].Value.ToString();
                frm.txtPerBuilding.Text = dr.Cells[32].Value.ToString();
                
                frm.PerADivisionCombo.Text = dr.Cells[33].Value.ToString();
                frm.PerADistrictCombo.Text = dr.Cells[34].Value.ToString();
                frm.PerAThanaCombo.Text = dr.Cells[35].Value.ToString();
                frm.PerAPostOfficeCombo.Text = dr.Cells[36].Value.ToString();
                y1=frm.PerApostCodeText.Text = dr.Cells[37].Value.ToString();
                if (a == a1 && b == b1 && c == c1 && d == d1 && x == x1 && y == y1)
                {
                    frm.SameAsPACheckBox.Checked = true;
                }
                else
                {
                    frm.SameAsPACheckBox.Checked = false;
                }

                frm.hk = g;
                if (k=="Bangladesh")
                {
                    frm.groupBox4.Visible = false;
                }
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserDetailsGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            UserManagementUI frm =new UserManagementUI();
            frm.Show();
        }
    }
}
