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
using KeyRegister.LoginUI;
using PropertyManager = KeyRegister.Manager.PropertyManager;

namespace KeyRegister.UI
{
    public partial class PropertyEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int locationInChargeId, userIdForLoc, numOfTerritory, numOfLocation;
        public string nUserType, nUserId, territoryId, h, g, a, b, locationId;
        public PropertyEntry()
        {
            InitializeComponent();
        }       
        private void ResetProperty()
        {
            txtTerritoryId.Clear();
            txtTerritoryName.Clear();
            txtLocationId.Clear();
            txtLocationName.Clear();
            txtPropertyName.Clear();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTerritoryName.Text))
            {
                MessageBox.Show("Please Select Territory Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtLocationName.Text))
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
                aProperty.PropertyName = txtPropertyName.Text;
                aProperty.LocationId = Convert.ToInt32(txtLocationId.Text);
                aProperty.PUserId = Convert.ToInt32(nUserId);
                aProperty.CreatedDateTime = DateTime.Today;
                pt = aManager.SaveProperty(aProperty);
                MessageBox.Show("Successfully Saved", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                ResetProperty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PropertyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (nUserType == "COO")
            {
                this.Hide();
                MainUI frm = new MainUI();
                frm.Show();
            }
            if (nUserType == "TTM")
            {
                this.Hide();
                MainUIForTTM frm = new MainUIForTTM();
                frm.Show();
            }
            if (nUserType == "LIC")
            {
                this.Hide();
                MainUIForLIC frm = new MainUIForLIC();
                frm.Show();
            }
        }
        private void GetLocationInChargeName()
        {
            //UserGateway aUserGatewate = new UserGateway();
            //List<Users> users = aUserGatewate.GetUserName();
            //cmbLocationInChargeName.DataSource = users;
            //cmbLocationInChargeName.DisplayMember = "FullName";
            //cmbLocationInChargeName.ValueMember = "UserId";
        }

        private void GetLocationName()
        {
            //LocationGateway aGateway=new LocationGateway();
            //List<Locations> aLocationses = aGateway.GetLocationName();
            //cmbLocationName.DataSource = aLocationses;
            //cmbLocationName.DisplayMember = "LocationName";
            //cmbLocationName.ValueMember = "LocationId";
        }
       
        public void LoadTerritoryForCOO()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Territory.TerritoryId, Territory.TerritoryName,Users.FullName FROM  TerritoryManager INNER JOIN Territory ON TerritoryManager.TerritoryId = Territory.TerritoryId INNER JOIN Users ON TerritoryManager.UserId = Users.UserId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadTerritoryForTTM()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Territory.TerritoryId, Territory.TerritoryName, Users.FullName FROM  TerritoryManager INNER JOIN Territory ON TerritoryManager.TerritoryId = Territory.TerritoryId INNER JOIN Users ON TerritoryManager.UserId = Users.UserId where  TerritoryManager.UserId='" + nUserId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetCountTerritoryUnderTerritoryManager()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select count(TerritoryId) from TerritoryManager where  TerritoryManager.UserId='" + nUserId + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    numOfTerritory = (rdr.GetInt32(0));
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetCountLocationUnderLocationInCharge()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select count(LocationId) from LocationIncharge where  LocationIncharge.UserId='" + nUserId + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    numOfLocation = (rdr.GetInt32(0));
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadMultipleLocationUnderLocationInCharge()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Location.LocationId, Location.LocationName FROM  LocationIncharge INNER JOIN Location ON LocationIncharge.LocationId = Location.LocationId where LocationIncharge.UserId='" + nUserId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadLocationForSingleTerritory()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Location.LocationId,Location.LocationName FROM  Location INNER JOIN Territory ON Location.TerritoryId = Territory.TerritoryId where Location.TerritoryId='" + territoryId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadSingleLocationUnderLocationInCharge()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Location.LocationId,Location.LocationName FROM  Location INNER JOIN Territory ON Location.TerritoryId = Territory.TerritoryId where Location.TerritoryId='" + territoryId + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtLocationId.Text = (rdr.GetString(0));
                    txtLocationName.Text = (rdr.GetString(1));
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadLocation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Location.LocationId,Location.LocationName FROM  Location INNER JOIN Territory ON Location.TerritoryId = Territory.TerritoryId where Location.TerritoryId='" + territoryId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadPropertyOnSelectedLocation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Property.PropertyId, Users.FullName, Location.LocationName, Property.PropertyName FROM LocationIncharge INNER JOIN Location ON LocationIncharge.LocationId = Location.LocationId INNER JOIN Property ON Location.LocationId = Property.LocationId INNER JOIN Users ON LocationIncharge.UserId = Users.UserId where Location.LocationId='" + locationId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView3.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView3.Rows.Add(rdr[0], rdr[1],rdr[2],rdr[3]);
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
            nUserId = frmLogin.uId.ToString();
            nUserType = frmLogin.userType;
            if (nUserType == "COO")
            {
                LoadTerritoryForCOO();
            }
            else if (nUserType == "TTM")
            {
                GetCountTerritoryUnderTerritoryManager();
                if (numOfTerritory > 1)
                {
                    LoadTerritoryForTTM();
                }
                if (numOfTerritory == 1)
                {
                    dataGridView1.Visible = false;
                    LoadLocationForSingleTerritory();

                }
            }
            else if (nUserType == "LIC")
            {
                GetCountLocationUnderLocationInCharge();
                if (numOfLocation > 1)
                {
                    dataGridView1.Visible = false;
                    LoadMultipleLocationUnderLocationInCharge();
                }
                if (numOfLocation == 1)
                {
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    LoadSingleLocationUnderLocationInCharge();
                }
            }           
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                territoryId=txtTerritoryId.Text = dr.Cells[0].Value.ToString();
                txtTerritoryName.Text = dr.Cells[1].Value.ToString();
                LoadLocation();
                g = h;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr1 = dataGridView2.CurrentRow;
                locationId= txtLocationId.Text = dr1.Cells[0].Value.ToString();
                txtLocationName.Text = dr1.Cells[1].Value.ToString();
                LoadPropertyOnSelectedLocation();
                a= b;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
