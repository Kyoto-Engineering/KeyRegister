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
    public partial class KeyAllocationEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int propertyId, locationId, territoryId, nUserId, createdDatetime, numOfTerritory, numOfLocation;
        public string h, g,propertyName,locationName,lockname,keyName,nUserType;
        public KeyAllocationEntry()
        {
            InitializeComponent();
        }
        public void LoadTerritory()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT TerritoryId,TerritoryName FROM  Territory", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0],rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadProperty()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT PropertyId,PropertyName FROM  Property  where  Property.PropertyName='"+propertyName+"'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView3.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView3.Rows.Add(rdr[0], rdr[1]);
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
                cmd = new SqlCommand("SELECT LocationId,LocationName FROM  Location", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0],rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTerritoryForCOO()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "";
                cmd=new SqlCommand(query,con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read()==true)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTerritoryForTTM()
        {
            
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
        private void KeyAllocationEntry_Load(object sender, EventArgs e)
        {


           // GetKeyIs();
           // GetKeyType1();
            nUserId = frmLogin.uId;
            nUserType = frmLogin.userType;
            if (nUserType == "COO")
            {
                LoadTerritoryForCOO();
            }
            else if (nUserType == "TTM")
            {
              //  GetCountTerritoryUnderTerritoryManager();
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
             
                if (numOfLocation > 1)
                {
                    dataGridView1.Visible = false;
                    //LoadMultipleLocationUnderLocationInCharge();
                }
                if (numOfLocation == 1)
                {
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                 
                }
            }

        }

        private void Reset()
        {
            txtTerritoryName.Clear();
            txtLocationName.Clear();
            txtPropertyName.Clear();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTerritoryName.Text))
            {
                MessageBox.Show("Please Select territory Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtLocationName.Text))
            {
                MessageBox.Show("Please Select Location Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPropertyName.Text))
            {
                MessageBox.Show("Please Select property  Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int ka = 0;
                KeyAllocationManager amManager = new KeyAllocationManager();
                KeyAllocation allocation = new KeyAllocation();
                allocation.PropertyId = propertyId;
                allocation.LocationId = locationId;
                allocation.TerritoryId = territoryId;
                allocation.KAUserId = nUserId;
                allocation.DateTimeCreated = DateTime.Today;
                ka = amManager.SaveKeyAllocation(allocation);
                MessageBox.Show("Successfully Saved", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView3.CurrentRow;
                propertyId = Convert.ToInt32(dr.Cells[0].Value.ToString());
                txtPropertyName.Text = dr.Cells[1].Value.ToString();
                h = g;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTerritoryName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT TerritoryId from Territory WHERE TerritoryName= '" + txtTerritoryName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    territoryId = rdr.GetInt32(0);
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

        private void txtPropertyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT PropertyId from Property WHERE PropertyName= '" + txtPropertyName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    propertyId = rdr.GetInt32(0);
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

        private void txtLocationName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT LocationId from Location WHERE LocationName= '" + txtLocationName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    locationId = rdr.GetInt32(0);
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

        private void KeyAllocationEntry_FormClosed(object sender, FormClosedEventArgs e)
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

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                propertyId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
               // propertyId = Convert.ToInt32((dr.Cells[0].ToString()));
                propertyName = (dr.Cells[1].Value.ToString());
                h = g;
                LoadProperty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
