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
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int emailBankId, nationalityId, countryId, departmentId, designationId, genderId, maritalStatusId;

        public string nUserId, divisionIdPA, divisionIdPer, postofficeIdPA, postofficeIdPer, districtIdPA, districtIdPer, thanaIdPA, thanaIdPer;
        public int instantUserId;
        public UserUpdateForm()
        {
            InitializeComponent();
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {

            //auser.FullName = txtFullName.Text;
            //auser.FatherName = txtFatherName.Text;
            //auser.MotherName = txtMotherName.Text;
            //auser.NickName = txtNickName.Text;
            //auser.Countries.CountryName = cmbCountry.Text;
            //auser.EmailAdd.EmailAddressId = cmbEmailAddress.Text;
            //auser.passportNumber = txtPassportNo.Text;
            //auser.BirthCertificateNo = txtBirthCertificatNo.Text;
            //auser.Genders.GenderName = cmbGender.Text;
            //auser.MaritalStatusss.MaritalStatuss = cmbMaritalStatus.Text;
            //auser.DateOfBirth = dateOfBirth.Value;
            //i = aManager.GetUserDetails(auser);
        }
        public void GetEmployeeId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT EmployeeId FROM Users where Statuss='Active'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbEmployeeId.Items.Add(rdr[0]);
                }
                con.Close();
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
                //cmbCountry.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EmailAddress()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select Email from EmailBank";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbEmailAddress.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbEmailAddress.Items.Add("Not In The List");
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

        private void UserUpdateForm_Load(object sender, EventArgs e)
        {
            GetEmployeeId();
            FillPresentDivisionCombo();
            FillPermanantDivisionCombo();
            CountryLoad();
            EmailAddress();
            DesignationLoad();
            GetGender();
            MaritalStatusLoad();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmployeeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            UserGateway aGateway = new UserGateway();
            Countries aCountries = new Countries();
            EmailAddress aEAddress = new EmailAddress();
            string employeeId = cmbEmployeeId.Text;
            auser = aGateway.GetUserDetails(employeeId);

            txtFullName.Text = auser.FullName;
            txtNickName.Text = auser.NickName;
            txtFatherName.Text = auser.FatherName;
            txtMotherName.Text = auser.MotherName;
            cmbEmailAddress.Text = auser.EmailAdd;
            cmbCountry.Text = auser.CountryName;
            cmbDesignation.Text = auser.DesignationName;
            txtNationalId.Text = auser.NationalId;
            txtBirthCertificatNo.Text = auser.BirthCertificateNo;
            txtPassportNo.Text = auser.PassportNo;
           
            cmbGender.Text = auser.Genders;
            cmbMaritalStatus.Text = auser.MaritalStatusss;



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
                PAPostOfficeCombo.SelectedIndex = -1;
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
                PAThanaCombo.Items.Clear();
                PAThanaCombo.Text = "";
                PAPostOfficeCombo.SelectedIndex = -1;
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
                    postofficeIdPA = (rdr.GetString(0));
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
                PerAPostOfficeCombo.SelectedIndex = -1;
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
                PerAPostOfficeCombo.Items.Clear();
                PerAPostOfficeCombo.SelectedIndex = -1;
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
        public void ResetPermanantAddress()
        {
            PerAFlatNoText.Clear();
            PerAHouseNoText.Clear();
            PerARoadNoText.Clear();
            PerABlockText.Clear();
            PerAareaText.Clear();

            PerApostCodeText.Clear();
            PerAPostOfficeCombo.SelectedIndex = -1;
            PerAThanaCombo.SelectedIndex = -1;
            PerADistrictCombo.SelectedIndex = -1;
            PerADivisionCombo.SelectedIndex = -1;



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
            if (cmbCountry.Text == "Bangladesh")
            {
                groupBox4.Visible = false;
            }
            else
            {
                groupBox4.Visible = true;
            }
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ctk = "SELECT  RTRIM(Countries.CountryId),RTRIM(Countries.CountryCode) from Countries WHERE Countries.CountryName=@find";
            //    cmd = new SqlCommand(ctk);
            //    cmd.Connection = con;
            //    cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "CountryName"));
            //    cmd.Parameters["@find"].Value = cmbCountry.Text;
            //    rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        countryId = (rdr.GetInt32(0));
            //        cmbCountryCode.Text = (rdr.GetString(1));
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
    }
}
