using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.DAO;
using KeyRegister.DBGateway;
using KeyRegister.Gateway;
using KeyRegister.Manager;

namespace KeyRegister.LoginUI
{
    public partial class registrationByAdmin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int emailBankId, nationalityId, countryId, departmentId, designationId, genderId, maritalStatusId;

        public string countryCode, nUserId, divisionIdPA, divisionIdPer, postofficeIdPA, postofficeIdPer, districtIdPA, districtIdPer, thanaIdPA, thanaIdPer;
        public int instantUserId;

        public registrationByAdmin()
        {
            InitializeComponent();
        }

        private void GetMaxUserId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  MAX(UserId) from Users ";
                cmd = new SqlCommand(ctk,con);                              
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    instantUserId = (rdr.GetInt32(0));

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
        private void SaveOverSeasAddress()
        {
            int fr = 0;
            UserManager amanager = new UserManager();
            try
            {
                OverSeasAddress ovAddress = new OverSeasAddress
                {
                    Street = txtStreetName.Text,
                    State = txtState.Text,
                    PostalCode = txtPostalCode.Text,
                    OUserId = instantUserId.ToString()
                };
                fr = amanager.SaveOverSeasAddress(ovAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePermanantAddress()
        {
            int pr = 0;
            UserManager amanager = new UserManager();
            try
            {
                PerManantAddress aperAddress = new PerManantAddress
                {
                    PerFlatNo = PerAFlatNoText.Text,
                    PerHouseNo = PerAHouseNoText.Text,
                    PerRoadNo = PerARoadNoText.Text,
                    PerBlock = PerABlockText.Text,
                    PerArea = PerAareaText.Text,
                    PerPostOfficeId = Convert.ToInt32(postofficeIdPer),
                    PerUserId = instantUserId.ToString()
                    
                };
                pr = amanager.SavePermanantAddress(aperAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SavePresentAddress()
        {
            int pa = 0;
            UserManager amanager = new UserManager();
            try
            {
                PresentAddress apresentAddress = new PresentAddress
                {
                    PreFlatNo = PAFlatNoText.Text,
                    PreHouseNo = PAHouseNoText.Text,
                    PreRoadNo = PARoadNoText.Text,
                    PreBlock = PABlockText.Text,
                    PreArea = PAareaText.Text,
                    PrePostOfficeId = Convert.ToInt32(postofficeIdPA),
                    UserId=instantUserId.ToString()
                };
                pa = amanager.SavePresentAddress(apresentAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveUserInformation()
        {
            UserGateway aGateway = new UserGateway();
            int ig = 0;
            UserManager auManager = new UserManager();
            try
            {

                Users aUser = new Users
                {
                    EmployeeId = Convert.ToInt32(txtEmployeeId.Text),
                    UserName = txtUserName.Text,
                    FullName = txtFullName.Text,
                    NickName = txtNickName.Text,
                    FatherName = txtFatherName.Text,
                    MotherName = txtMotherName.Text,

                    EmailBankId = emailBankId,
                    NationalId = cmbNationality.Text,
                    CountryId = countryId,
                    PassportNo = txtPassportNo.Text,
                    BirthCertificateNo = txtBirthCertificatNo.Text,
                    DesignationId = designationId,
                    GenderId = genderId,
                    MaritalStatusId = maritalStatusId,
                    DateOfBirth = Convert.ToDateTime(dateOfBirth.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat),
                    Password = txtPassword.Text,
                };
                ig = auManager.SaveUserDetail(aUser);
                GetMaxUserId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SaveContactNo()
        {
            try
            {
                for (int i = 0; i <= listView1.Items.Count-1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into ContactNumbers(CountryCode,ContactNo,UserId) VALUES (@d1,@d2,@d3)";
                    cmd = new SqlCommand(cb, con);
                    cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("@d2",listView1.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("@d3",instantUserId);
                    cmd.ExecuteReader();
                    con.Close();
                }                                                                                            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PermanantSameAsPreentAddress()
        {
            try
            {
                int sag = 0;
                UserManager amanager = new UserManager();
                try
                {
                    PerManantAddress aperAddress = new PerManantAddress
                    {
                       PerFlatNo  = PAFlatNoText.Text,
                        PerHouseNo = PAHouseNoText.Text,
                        PerRoadNo = PARoadNoText.Text,
                        PerBlock = PABlockText.Text,
                        PerArea = PAareaText.Text,
                        PerPostOfficeId = Convert.ToInt32(postofficeIdPA),
                        PerUserId = instantUserId.ToString()
                    };
                    sag = amanager.PerManantSameAsPresentAddress(aperAddress);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            
        }
        private void createUserButton_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == "")
            {
                MessageBox.Show("Please enter employee Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return;
            }
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return;
            }
            if (txtFullName.Text == "")
            {
                MessageBox.Show("Please enter full  Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }
            if (txtNickName.Text == "")
            {
                MessageBox.Show("Please enter nick Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtFatherName.Text == "")
            {
                MessageBox.Show("Please enter father Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }
           
            if (txtMotherName.Text == "")
            {
                MessageBox.Show("Please enter mother Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please add Contact No to Chart,", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            if (string.IsNullOrWhiteSpace(PADivisionCombo.Text))
            {
                MessageBox.Show("Please select Present Address division", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(PADistrictCombo.Text))
            {
                MessageBox.Show("Please Select Present Address district", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(PAThanaCombo.Text))
            {
                MessageBox.Show("Please select Present Address Thana", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(PAPostOfficeCombo.Text))
            {
                MessageBox.Show("Please Select Present Address Post Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(PAPostCodeText.Text))
            {
                MessageBox.Show("Please select Present Address Post Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ( SameAsPACheckBox.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(PerADivisionCombo.Text))
                {
                    MessageBox.Show("Please select Permanant Address division", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(PerADistrictCombo.Text))
                {
                    MessageBox.Show("Please Select Permanant Address district", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(PerAThanaCombo.Text))
                {
                    MessageBox.Show("Please select Permanant Address Thana", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(PerAPostOfficeCombo.Text))
                {
                    MessageBox.Show("Please Select Permanant Address Post Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(PerApostCodeText.Text))
                {
                    MessageBox.Show("Please select Permanant Address Post Code", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            try
            {
                if (SameAsPACheckBox.Checked == true)
                {
                    SaveUserInformation();
                    SavePresentAddress();
                    PermanantSameAsPreentAddress();
                    SaveContactNo();
                }
                else
                {
                    SaveUserInformation();
                    SavePresentAddress();
                    SavePermanantAddress();
                    SaveContactNo();
                }               
                if (cmbNationality.Text != "Bangladeshi")
                {
                    SaveOverSeasAddress();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void NationalityLoad()
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
                    cmbNationality.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbNationality.Items.Add("Not In The List");
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
        private void LoadCountryCode()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select CountryCode from Countries";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCountryCode.Items.Add(rdr.GetValue(0).ToString());
                }              
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
        private void registrationByAdmin_Load(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            FillPresentDivisionCombo();
            FillPermanantDivisionCombo();
            nUserId = frmLogin.uId.ToString();
            LoadCountryCode();
            CountryLoad();
            EmailAddress();
            //NationalityLoad();
            DesignationLoad();
            MaritalStatusLoad();
            GetGender();
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

        private void cmbEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmailAddress.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Mode Of Conduct  Here","Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbEmailAddress.SelectedIndex = -1;
                }

                else
                {
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        string emailId = input.Trim();
                        Regex mRegxExpression;
                        mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                        if (!mRegxExpression.IsMatch(emailId))
                        {
                            MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                    }

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Email from EmailBank where Email='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Email  Already Exists,Please Select From List", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbEmailAddress.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into EmailBank (Email,UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbEmailAddress.Items.Clear();
                            EmailAddress();
                            cmbEmailAddress.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT EmailBankId from EmailBank WHERE Email= '" + cmbEmailAddress.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        emailBankId = rdr.GetInt32(0);
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
        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGender.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Gender Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbGender.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select GenderName from Gender where GenderName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Gender  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbGender.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into  Gender(GenderName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbGender.Items.Clear();
                            GetGender();
                            cmbGender.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
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
        }

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDesignation.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input designation Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbDesignation.SelectedIndex = -1;
                }

                else
                {                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Designation from Designations where Designation='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Designation  Already Exists,Please Select From List", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbDesignation.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Designations(Designation) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);                           
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbDesignation.Items.Clear();
                            DesignationLoad();
                            cmbDesignation.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
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
        }

        private void cmbNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNationality.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Nationality Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbNationality.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Nationality from Nationalitys where Nationality='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Nationality  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbNationality.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Nationalitys (Nationality) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbNationality.Items.Clear();
                            NationalityLoad();
                            cmbNationality.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT NationalityId from Nationalitys WHERE Nationality= '" + cmbNationality.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        nationalityId = rdr.GetInt32(0);
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaritalStatus.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input MaritalStatus Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbMaritalStatus.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select MaritalStatus from MaritalStatuss where MaritalStatus='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This MaritalStatus  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbMaritalStatus.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into MaritalStatuss (MaritalStatus) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbMaritalStatus.Items.Clear();
                            MaritalStatusLoad();
                            cmbMaritalStatus.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT MaritalStatusId from MaritalStatuss WHERE MaritalStatus= '" + cmbNationality.Text + "'";

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
        }

        private void registrationByAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            UserManagementUI frm=new UserManagementUI();
               frm.Show();
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
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdPA+ "' order by PostOffice.T_ID desc";
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
                string ctk ="SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
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

        private void PerADivisionCombo_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void PerAThanaCombo_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void PerADistrictCombo_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void PerAPostOfficeCombo_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void addButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                ListViewItem list = new ListViewItem();
                list.SubItems.Add(cmbCountryCode.Text);
                list.SubItems.Add(txtContactNo.Text);
               
                listView1.Items.Add(list);                
                txtContactNo.Clear();
                cmbCountryCode.SelectedIndex = -1;
                return;
            }
            
            ListViewItem list1 = new ListViewItem();
            list1.SubItems.Add(cmbCountryCode.Text);
            list1.SubItems.Add(txtContactNo.Text);

            listView1.Items.Add(list1);
            txtContactNo.Clear();
            cmbCountryCode.SelectedIndex = -1;
            return;            
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry.Text =="Bangladesh")
            {
                groupBox4.Visible = false;
            }
            else
            {
                groupBox4.Visible = true;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Countries.CountryId),RTRIM(Countries.CountryCode) from Countries WHERE Countries.CountryName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "CountryName"));
                cmd.Parameters["@find"].Value = cmbCountry.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    countryId = (rdr.GetInt32(0));
                    cmbCountryCode.Text = (rdr.GetString(1));
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

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
