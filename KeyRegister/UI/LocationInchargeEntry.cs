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
using KeyRegister.LoginUI;
using KeyRegister.Manager;

namespace KeyRegister.UI
{
    public partial class LocationInchargeEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string lUserId;
        public int locationInChargeId, locationId;
        public LocationInchargeEntry()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            cmbLocationName.SelectedIndex = -1;
            cmbLocationInCharge.SelectedIndex = -1;
            dateOfAssignDate.Value=DateTime.Today;
        }
        private void  SaveLocationInCharge()
        {
            if (string.IsNullOrEmpty(cmbLocationInCharge.Text))
            {
                MessageBox.Show("Please enter Location In Charge Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbLocationName.Text))
            {
                MessageBox.Show("Please enter Location Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select LocationIncharge.UserId  from LocationIncharge where  LocationIncharge.UserId='" + locationInChargeId + "'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Location InCharge Name Already Exists,Please Input another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;

                }

                int mgs;
                LocationInChargeManager aManager = new LocationInChargeManager();
                LocationInCharges aLocationInCharges = new LocationInCharges();
                aLocationInCharges.LocationId = locationId.ToString();
                aLocationInCharges.LUserId = locationInChargeId.ToString();
                aLocationInCharges.AssignDate = dateOfAssignDate.Text;
                aLocationInCharges.AssignedBy = lUserId;
                mgs = aManager.SaveLocationInCharge(aLocationInCharges);
                MessageBox.Show("Successfully Saved", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }
        private void createButton_Click(object sender, EventArgs e)
        {
            SaveLocationInCharge();

        }
        private void GetLocationManagerName()
        {
            UserGateway aUserGatewate = new UserGateway();
            List<Users> users = aUserGatewate.GetUserName();
            cmbLocationInCharge.DataSource = users;
            cmbLocationInCharge.DisplayMember = "FullName";
            cmbLocationInCharge.ValueMember = "UserId";
        }
        private void GetCompanyName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Select  LocationName from  Location  order  by  Location.LocationId desc ";
                cmd = new SqlCommand(qry, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbLocationName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LocationInchargeEntry_Load(object sender, EventArgs e)
        {
            lUserId = frmLogin.uId.ToString();
            GetLocationManagerName();
            GetCompanyName();
        }

        private void LocationInchargeEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void cmbLocationInCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select CompanyId from Company where  Company.CompanyName='" + cmbLocationInCharge.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    locationInChargeId = (rdr.GetInt32(0));
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select CompanyId from Company where  Company.CompanyName='" + cmbLocationName.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    locationId = (rdr.GetInt32(0));
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
