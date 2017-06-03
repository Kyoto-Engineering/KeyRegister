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
using KeyRegister.DAO;
using KeyRegister.DBGateway;
using KeyRegister.Gateway;
using KeyRegister.Manager;

namespace KeyRegister.LoginUI
{
    public partial class UserUpdateForm : Form
    {
        private Users auser;
        private PerManantAddress aAddress;
        private PresentAddress presentAddress;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string hk;
        public int emailBankId, nationalityId, departmentId, designationId, genderId, maritalStatusId, userHostIdForSecondaryEmail1, userHostIdForPrimaryEmail;

        public string nUserId, divisionIdPA, divisionIdPer, postofficeIdPr, postofficeIdPer, districtIdPA, districtIdPer, thanaIdPA, thanaIdPer, selectedUserId;
        public int instantUserId, selectedUserId1, gUserId;
        public string countryId,hostPart,domainPart,primaryEmailForCheck;

        public UserUpdateForm()
        {
            InitializeComponent();
        }

        private void UpdatePresentAddress()
        {
            UserGateway aGateway=new UserGateway();
            PresentAddress akAddress=new PresentAddress();
            akAddress.PreFlatNo = txtPreFlatNo.Text;
            akAddress.PreHouseNo = txtPreHouseNo.Text;
            akAddress.PreRoadNo = txtPreRoadNo.Text;
            akAddress.PreBlock = txtPreBlock.Text;
            akAddress.PreArea = txtPreArea.Text;
            akAddress.PreLandmark = txtPreLandMark.Text;
            akAddress.PreRoadName = txtPreRoadName.Text;
            akAddress.PreBuilding = txtPreBuildingName.Text;
            akAddress.PrePostOfficeId = Convert.ToInt32(postofficeIdPr);
            akAddress.UserId = Convert.ToInt32(gUserId);
            aGateway.UpdatePresentAddress(akAddress);
        }
        private void UpdatePerManantAddress()
        {
            UserGateway  apGateway=new UserGateway();
            PerManantAddress apAddress=new PerManantAddress();

            apAddress.PerFlatNo = txtPerFlatNo.Text;
            apAddress.PerHouseNo = txtPerHouseNo.Text;
            apAddress.PerRoadNo = txtPerRoadNo.Text;
            apAddress.PerBlock = txtPerBlock.Text;
            apAddress.PerArea = txtPerArea.Text;
            apAddress.PerLandmark = txtPerLandMark.Text;
            apAddress.PerRoadName = txtPerRoadName.Text;
            apAddress.PerBuilding = txtPerBuilding.Text;
            apAddress.PerPostOfficeId = Convert.ToInt32(postofficeIdPer);
            apAddress.PerUserId = Convert.ToInt32(gUserId);
            apGateway.UpdatePermanantAddress(apAddress);
        }
        private void ResetPresentAddress()
        {
            txtPreFlatNo.Clear();
            txtPreHouseNo.Clear();
            txtPreRoadNo.Clear();
            txtPreBlock.Clear();
            txtPreArea.Clear();
            txtPreBuildingName.Clear();
            txtPreRoadName.Clear();
            txtPreLandMark.Clear();
            PerApostCodeText.Clear();
            PerAPostOfficeCombo.SelectedIndex = -1;
            PerAThanaCombo.SelectedIndex = -1;
            PerADistrictCombo.SelectedIndex = -1;
            PerADivisionCombo.SelectedIndex = -1;
        }
        public void ResetPermanantAddress()
        {
            txtPerFlatNo.Clear();
            txtPerHouseNo.Clear();
            txtPerRoadNo.Clear();
            txtPerBlock.Clear();
            txtPerArea.Clear();
            txtPerLandMark.Clear();
            txtPerBuilding.Clear();
            txtPerRoadName.Clear();

            PerApostCodeText.Clear();
            PerAPostOfficeCombo.Items.Clear();
            PerAPostOfficeCombo.SelectedIndex = -1;
            PerAThanaCombo.Items.Clear();
            PerAThanaCombo.SelectedIndex = -1;
            PerADistrictCombo.Items.Clear();
            PerADistrictCombo.SelectedIndex = -1;
            PerADivisionCombo.Items.Clear();
            PerADivisionCombo.SelectedIndex = -1;

            SameAsPACheckBox.CheckedChanged -= SameAsPACheckBox_CheckedChanged;
            SameAsPACheckBox.Checked = false;
            SameAsPACheckBox.CheckedChanged += SameAsPACheckBox_CheckedChanged;
        }
       
        private void Reset()
        {
           
            txtFullName.Clear();
            txtNickName.Clear();
            txtFatherName.Clear();
            txtMotherName.Clear();
            cmbPrimaryEmail.SelectedIndex = -1;
            cmbSecondaryEmail.SelectedIndex = -1;
          
            cmbCountry.SelectedIndex = -1;
            cmbCountry.Items.Clear();
            cmbDesignation.SelectedIndex = -1;
            cmbDesignation.Items.Clear();

            cmbGender.SelectedIndex = -1;
            cmbMaritalStatus.SelectedIndex = -1;
            dateOfBirth.Value = DateTime.Today;


            txtNationalId.Clear();
            txtPassportNo.Clear();
            txtBirthCertificatNo.Clear();                                 
            ResetPresentAddress();
            ResetPermanantAddress();
            if (cmbCountry.Text != "Bangladesh")
            {
                txtStreetName.Clear();
                txtState.Clear();
                txtPostalCode.Clear();
            }
           
        }

        private void UpdateUserEmail(int userEmailHostId,int userId,Boolean statuss)
        {
            try
            {
                UserGateway aGateway=new UserGateway();
                UserEmail aUserEmail=new UserEmail();
                aUserEmail.HostEmailId = userEmailHostId;
                aUserEmail.UserId = userId;
                aUserEmail.IsPrimaryStatus = statuss;
                aGateway.UpdateUserEmail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckStatusForUpdateEmail()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "SELECT (UserEmail.UserPart+'@'+EmailHostBank.EmailHostName) As EmailAdd FROM  UserEmail INNER JOIN  EmailHostBank ON UserEmail.EmailHostId = EmailHostBank.EmailHostId INNER JOIN  Users ON UserEmail.UserId = Users.UserId where UserEmail.UserId='" + gUserId + "'";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    primaryEmailForCheck = (rdr.GetString(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void createUserButton_Click(object sender, EventArgs e)
        {
          
            try
            {
                UserGateway agGateway = new UserGateway();
                Users auser = new Users();
                auser.UserId = Convert.ToInt32(gUserId);
                auser.FullName = txtFullName.Text;
                auser.NickName = txtNickName.Text;
                auser.FatherName = txtFatherName.Text;
                auser.MotherName = txtMotherName.Text;                
                auser.CountryId = Convert.ToInt32(countryId);
                auser.DesignationId = designationId;              
                auser.NationalId = txtNationalId.Text;
                auser.PassportNo = txtPassportNo.Text;
                auser.BirthCertificateNo = txtBirthCertificatNo.Text;
                auser.GenderId = genderId;
                auser.MaritalStatusId = maritalStatusId;
                auser.DateOfBirth = Convert.ToDateTime(dateOfBirth.Value,System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);               
                agGateway.UpdateUserInfo(auser);
                UpdatePresentAddress();
                UpdatePerManantAddress();
                CheckStatusForUpdateEmail();
                if (primaryEmailForCheck != cmbPrimaryEmail.Text)
                {
                    UpdateUserEmail(userHostIdForPrimaryEmail, gUserId, true);
                    UpdateUserEmail(userHostIdForSecondaryEmail1, gUserId, false);
                }
                else
                {
                    UpdateUserEmail(userHostIdForPrimaryEmail, gUserId, false);
                    UpdateUserEmail(userHostIdForSecondaryEmail1, gUserId, true);
                }               
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        public void FillPermanantDivisionCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division_ID desc ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PerADivisionCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillPresentDivisionCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PADivisionCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CountryLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select CountryName from Countries";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCountry.Items.Add(rdr.GetValue(0).ToString());
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void DesignationLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select Designation from Designations";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbDesignation.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbDesignation.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetGender()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select GenderName from Gender";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbGender.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbGender.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MaritalStatusLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select MaritalStatus from MaritalStatuss";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbMaritalStatus.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbMaritalStatus.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadSecondaryEmail()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "SELECT (UserEmail.UserPart+'@'+EmailHostBank.EmailHostName) As EmailAdd FROM  UserEmail INNER JOIN  EmailHostBank ON UserEmail.EmailHostId = EmailHostBank.EmailHostId INNER JOIN  Users ON UserEmail.UserId = Users.UserId where UserEmail.UserId='" + gUserId + "'";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbSecondaryEmail.Items.Add(rdr.GetValue(0).ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPrimaryEmail()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "SELECT (UserEmail.UserPart+'@'+EmailHostBank.EmailHostName) As EmailAdd FROM  UserEmail INNER JOIN  EmailHostBank ON UserEmail.EmailHostId = EmailHostBank.EmailHostId INNER JOIN  Users ON UserEmail.UserId = Users.UserId where UserEmail.UserId='"+gUserId+"'";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbPrimaryEmail.Items.Add(rdr.GetValue(0).ToString());
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UserUpdateForm_Load(object sender, EventArgs e)
        {
            LoadSecondaryEmail();
            LoadPrimaryEmail();
            FillPresentDivisionCombo();
            FillPermanantDivisionCombo();
            CountryLoad();          
            DesignationLoad();
            GetGender();
            MaritalStatusLoad();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void GetUserIdByEmployeeId()
        {
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "select RTRIM(Users.UserId) from Users  Where Users.EmployeeId = '" + cmbEmployeeId.Text + "'";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;
            //    rdr = cmd.ExecuteReader();

            //    if (rdr.Read())
            //    {
            //        selectedUserId = (rdr.GetString(0));
            //        selectedUserId1 = Convert.ToInt32(selectedUserId);
            //    }
                
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void GetPresentAddress(int preUserId)
        {
            //int pg = 0;
            //UserGateway bGateway=new UserGateway();
            //int n1userId = preUserId;
            //presentAddress = bGateway.GetPresentAddress(n1userId);
            //PAFlatNoText.Text = presentAddress.PreFlatNo;
            //PAHouseNoText.Text = presentAddress.PreHouseNo;
            //PARoadNoText.Text = presentAddress.PreRoadNo;
            //PABlockText.Text = presentAddress.PreBlock;
            //PAareaText.Text = presentAddress.PreArea;
            //PADivisionCombo.Text = presentAddress.PreDivision;
            //PADistrictCombo.Text = presentAddress.PreDistrict;
            //PAThanaCombo.Text = presentAddress.PreThana;
            //PAPostOfficeCombo.Text = presentAddress.PostOfficeName;
            //PAPostCodeText.Text = presentAddress.PrePostCode;

        }
        private void GetPermanantAddress(int perUserId)
        {
            //int pi = 0;
            //UserGateway aGateway = new UserGateway();
            //int nUserId = perUserId;
            //aAddress = aGateway.GetPermanantAddress(nUserId);
            //PerAFlatNoText.Text = aAddress.PerFlatNo;
            //PerAHouseNoText.Text = aAddress.PerHouseNo;
            //PerARoadNoText.Text = aAddress.PerRoadNo;
            //PerABlockText.Text = aAddress.PerBlock;
            //PerAareaText.Text = aAddress.PerArea;
            //PerADivisionCombo.Text = aAddress.PerDivision;
            //PerADistrictCombo.Text = aAddress.PerDistrict;
            //PerAThanaCombo.Text = aAddress.PerThana;
            //PerAPostOfficeCombo.Text = aAddress.PostOfficeName;
            //PerApostCodeText.Text = aAddress.PerPostCode;

        }
        private void cmbEmployeeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            UserGateway aGateway = new UserGateway();
           
           // string employeeId = cmbEmployeeId.Text;
           // auser = aGateway.GetUserDetails(employeeId);

            txtFullName.Text = auser.FullName;
            txtNickName.Text = auser.NickName;
            txtFatherName.Text = auser.FatherName;
            txtMotherName.Text = auser.MotherName;
           // cmbEmailAddress.Text = auser.EmailAdd;
            cmbCountry.Text = auser.CountryName;
            cmbDesignation.Text = auser.DesignationName;
            txtNationalId.Text = auser.NationalId;
            txtBirthCertificatNo.Text = auser.BirthCertificateNo;
            txtPassportNo.Text = auser.PassportNo;
           
            cmbGender.Text = auser.Genders;
            cmbMaritalStatus.Text = auser.MaritalStatusss;
            GetUserIdByEmployeeId();
            GetPermanantAddress(selectedUserId1);
            GetPresentAddress(selectedUserId1);


        }

        private void PADivisionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = PADivisionCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdPA = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                PADivisionCombo.Text = PADivisionCombo.Text.Trim();
                PADistrictCombo.SelectedIndex = -1;
                PADistrictCombo.Items.Clear();
                PAThanaCombo.SelectedIndex = -1;
                PAThanaCombo.Items.Clear();
                PAPostOfficeCombo.SelectedIndex = -1;
                PAPostOfficeCombo.Items.Clear();
                PAPostCodeText.Clear();                
                PADistrictCombo.Enabled = true;
                PADistrictCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdPA + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PADistrictCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void PADistrictCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = PADistrictCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtIdPA = (rdr.GetString(0));

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                PADistrictCombo.Text = PADistrictCombo.Text.Trim();                
                PAThanaCombo.SelectedIndex = -1;
                PAThanaCombo.Items.Clear();
                PAPostOfficeCombo.SelectedIndex = -1;
                PAPostOfficeCombo.Items.Clear();
                PAPostCodeText.Clear();
                PAThanaCombo.Enabled = true;
                PAThanaCombo.Focus();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdPA + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PAThanaCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PAThanaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find and Thanas.D_ID=@d2 ";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "D_ID"));
                cmd.Parameters["@find"].Value = PAThanaCombo.Text;
                cmd.Parameters["@d2"].Value = districtIdPA;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdPA = (rdr.GetString(0));

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                PAThanaCombo.Text = PAThanaCombo.Text.Trim();
                PAPostOfficeCombo.SelectedIndex = -1;
                PAPostOfficeCombo.Items.Clear();
                PAPostCodeText.Clear();
                PAPostOfficeCombo.Enabled = true;
                PAPostOfficeCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdPA + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PAPostOfficeCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PAPostOfficeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = PAPostOfficeCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdPr = (rdr.GetString(0));
                    PAPostCodeText.Text = (rdr.GetString(1));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerADivisionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = PerADivisionCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdPer = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                PerADivisionCombo.Text = PerADivisionCombo.Text.Trim();

                PerADistrictCombo.SelectedIndex = -1;
                PerADistrictCombo.Items.Clear();
                PerAThanaCombo.SelectedIndex = -1;
                PerAThanaCombo.Items.Clear();
                PerAPostOfficeCombo.SelectedIndex = -1;
                PerAPostOfficeCombo.Items.Clear();
                PerApostCodeText.Clear();
                PerADistrictCombo.Enabled = true;
                PerADistrictCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdPer + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PerADistrictCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerADistrictCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = PerADistrictCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtIdPer = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                PerADistrictCombo.Text = PerADistrictCombo.Text.Trim();

                PerAThanaCombo.SelectedIndex = -1;
                PerAThanaCombo.Items.Clear();
                PerAPostOfficeCombo.SelectedIndex = -1;
                PerAPostOfficeCombo.Items.Clear();
                PerApostCodeText.Clear();
                PerAThanaCombo.Enabled = true;
                PerAThanaCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdPer + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PerAThanaCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerAThanaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find and  Thanas.D_ID=@d2";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "D_ID"));
                cmd.Parameters["@find"].Value = PerAThanaCombo.Text;
                cmd.Parameters["@d2"].Value = districtIdPer;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdPer = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                PerAThanaCombo.Text = PerAThanaCombo.Text.Trim();               
                PerAPostOfficeCombo.SelectedIndex = -1;
                PerAPostOfficeCombo.Items.Clear();
                PerApostCodeText.Clear();
                PerAPostOfficeCombo.Enabled = true;
                PerAPostOfficeCombo.Focus();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdPer + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PerAPostOfficeCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerAPostOfficeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = PerAPostOfficeCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdPer = (rdr.GetString(0));
                    PerApostCodeText.Text = (rdr.GetString(1));
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void SameAsPACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SameAsPACheckBox.Checked)
            {
                ResetPermanantAddress();
                groupBox5.Enabled = false;

            }
            else
            {
                groupBox5.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {
                if (cmbCountry.Text == "Bangladesh")
                {
                    groupBox4.Visible = false;
                }
                else
                {
                    groupBox4.Visible = true;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Countries.CountryId) from Countries WHERE Countries.CountryName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "CountryName"));
                cmd.Parameters["@find"].Value = cmbCountry.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    countryId = (rdr.GetString(0));                  
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
                      this.Hide();
            UserManagementUI  frm=new UserManagementUI();
                      frm.Show();
        }

        private void cmbEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    cmd = con.CreateCommand();
            //    cmd.CommandText = "SELECT EmailBankId from EmailBank WHERE Email= '" + cmbEmailAddress.Text + "'";
            //    rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        emailBankId = rdr.GetInt32(0);
            //    }
            //    if ((rdr != null))
            //    {
            //        rdr.Close();
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT DesignationId from Designations WHERE Designation= '" + cmbDesignation.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    designationId = rdr.GetInt32(0);
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT GenderId from Gender WHERE GenderName= '" + cmbGender.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    genderId = rdr.GetInt32(0);
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT MaritalStatusId from MaritalStatuss WHERE MaritalStatus= '" + cmbMaritalStatus.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    maritalStatusId = rdr.GetInt32(0);
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void cmbPrimaryEmail_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "SELECT (UserEmail.UserPart+'@'+EmailHostBank.EmailHostName) As EmailAdd FROM  UserEmail INNER JOIN  EmailHostBank ON UserEmail.EmailHostId = EmailHostBank.EmailHostId INNER JOIN  Users ON UserEmail.UserId = Users.UserId where UserEmail.UserId='"+gUserId+"' and UserEmail.IsPrimaryKey='false'";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cmbSecondaryEmail.Text = (rdr.GetString(0));
                }
                con.Close();
               
               con = new SqlConnection(cs.DBConn);
               con.Open();
               cmd = con.CreateCommand();
               cmd.CommandText = "SELECT UserEmail.EmailHostId from UserEmail WHERE UserEmail.UserId= '" + gUserId + "' and  UserEmail.IsPrimaryKey= 'false' ";
               rdr = cmd.ExecuteReader();
               if (rdr.Read())
               {
                   userHostIdForPrimaryEmail = rdr.GetInt32(0);
               }
               con.Close();
               con = new SqlConnection(cs.DBConn);
               con.Open();
               cmd = con.CreateCommand();
               cmd.CommandText = "SELECT UserEmail.EmailHostId from UserEmail WHERE UserEmail.UserId= '" + gUserId + "' and  UserEmail.IsPrimaryKey= 'true' ";
               rdr = cmd.ExecuteReader();
               if (rdr.Read())
               {
                   userHostIdForSecondaryEmail1 = rdr.GetInt32(0);
               }
               con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSecondaryEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT UserEmail.EmailHostId from UserEmail WHERE UserEmail.UserId= '" + gUserId + "' and  UserEmail.IsPrimaryKey= 'true' ";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    userHostIdForSecondaryEmail1 = rdr.GetInt32(0);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDetailsGrid frm=new UserDetailsGrid();
            frm.Show();
        }
    }
}
