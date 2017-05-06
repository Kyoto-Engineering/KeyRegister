using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.DAO;
using KeyRegister.DBGateway;
using KeyRegister.Gateway;
using PropertyManager = KeyRegister.Manager.PropertyManager;

namespace KeyRegister.UI
{
    public partial class PropertyEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int  locationInChargeId,locationId,userIdForLoc;
        public PropertyEntry()
        {
            InitializeComponent();
        }       
        private void ResetProperty()
        {
            cmbLocationName.SelectedIndex = -1;
            cmbLocationInChargeName.SelectedIndex = -1;
            txtPropertyName.Clear();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbLocationInChargeName.Text))
            {
                MessageBox.Show("Please Select LocationInCharge Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbLocationName.Text))
            {
                MessageBox.Show("Please Select Location Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPropertyName.Text))
            {
                MessageBox.Show("Please enter Property Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select Property.PropertyName from Property where  Property.PropertyName='" + txtPropertyName.Text + "'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Property Name Already Exists,Please Input another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;

                }

                int pt = 0;
                PropertyManager aManager = new PropertyManager();
                Property aProperty = new Property();
                aProperty.LocationInChargeId = locationInChargeId;
                aProperty.LocationId = locationId;
                aProperty.PropertyName = txtPropertyName.Text;
                aProperty.CreatedDateTime = DateTime.Today;
                pt = aManager.SaveProperty(aProperty);
                MessageBox.Show("Successfully Saved", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPropertyGrid();
                ResetProperty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PropertyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                 frm.Show();
        }
        private void GetLocationInChargeName()
        {
            UserGateway aUserGatewate = new UserGateway();
            List<Users> users = aUserGatewate.GetUserName();
            cmbLocationInChargeName.DataSource = users;
            cmbLocationInChargeName.DisplayMember = "FullName";
            cmbLocationInChargeName.ValueMember = "UserId";
        }

        private void GetLocationName()
        {
            LocationGateway aGateway=new LocationGateway();
            List<Locations> aLocationses = aGateway.GetLocationName();
            cmbLocationName.DataSource = aLocationses;
            cmbLocationName.DisplayMember = "LocationName";
            cmbLocationName.ValueMember = "LocationId";
        }
        public void LoadPropertyGrid()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Property.PropertyId,Users.FullName,Location.LocationName, Property.PropertyName FROM  LocationIncharge INNER JOIN Users ON LocationIncharge.UserId = Users.UserId INNER JOIN Location ON LocationIncharge.LocationId = Location.LocationId INNER JOIN Property ON Users.UserId = Property.UserId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PropertyEntry_Load(object sender, EventArgs e)
        {
            GetLocationInChargeName();
            GetLocationName();
            LoadPropertyGrid();
        }

        private void cmbLocationInChargeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  Users.UserId  from  Users  where  Users.FullName='" + cmbLocationInChargeName.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    userIdForLoc = (rdr.GetInt32(0));
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query1 = "SELECT  LocationIncharge.UserId FROM  LocationIncharge INNER JOIN Users ON LocationIncharge.UserId = Users.UserId where LocationIncharge.UserId='" + userIdForLoc + "'";
                cmd = new SqlCommand(query1, con);
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
                string query1 = "SELECT  LocationId FROM  Location  where LocationName='" + cmbLocationName.Text + "'";
                cmd = new SqlCommand(query1, con);
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
