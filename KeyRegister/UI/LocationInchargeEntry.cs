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
using Microsoft.SqlServer.Server;

namespace KeyRegister.UI
{
    public partial class LocationInchargeEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string lUserId, nUserType, h, k, locationId;
        public int locationInChargeId;
        public LocationInchargeEntry()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            txtTerritoryId.Clear();
            txtTerritoryName.Clear();
            
            txtLocationId.Clear();
            txtLocationName.Clear();
            
            dateOfAssignDate.Value=DateTime.Today;           
            txtEmployeeId.Clear();
            txtUserFullName.Clear();
           
            
           
        }
       
        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTerritoryName.Text))
            {
                MessageBox.Show("Please select territory Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtLocationName.Text))
            {
                MessageBox.Show("Please select Location Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtUserFullName.Text))
            {
                MessageBox.Show("Please select User as Location In Charge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select LocationIncharge.LocationId  from LocationIncharge where  LocationIncharge.LocationId='" + locationId + "' and LocationIncharge.RetractDate is null";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Location has already under one Location InCharge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    Reset();
                    return;

                }

                int mgs;
                LocationInChargeManager aManager = new LocationInChargeManager();
                LocationInCharges aLocationInCharges = new LocationInCharges();
                aLocationInCharges.LocationId = locationId;
                aLocationInCharges.LUserId = locationInChargeId.ToString();
                aLocationInCharges.AssignDate = dateOfAssignDate.Text;
                aLocationInCharges.AssignedBy = lUserId;
                mgs = aManager.SaveLocationInCharge(aLocationInCharges);
                MessageBox.Show("Successfully Saved", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                Reset();
                dataGridView2.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

       
        public void LoadLocationInCharge()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT LocationIncharge.LcationInchargeId, Users.FullName, Location.LocationName FROM  LocationIncharge INNER JOIN Users ON LocationIncharge.UserId = Users.UserId INNER JOIN Location ON LocationIncharge.LocationId = Location.LocationId", con);
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

        public void LoadTerritory()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Territory.TerritoryId, Territory.TerritoryName, Users.FullName FROM  TerritoryManager INNER JOIN Territory ON TerritoryManager.TerritoryId = Territory.TerritoryId INNER JOIN Users ON TerritoryManager.UserId = Users.UserId", con);
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
        public void LoadLocationForSelectedTerritory()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  LocationId, LocationName FROM  Location where Location.TerritoryId ='" + txtTerritoryId.Text + "'", con);
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
        public void LoadUserList()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  UserId, FullName, EmployeeId FROM  Users where  Users.Statuss='Active' and  UserId not in (Select UserId  from COO where COO.ResignationDate is null) and  UserId not in (Select UserId  from TerritoryManager where TerritoryManager.OffDutydate is null) and UserId not in (Select UserId  from LocationUser where  LocationUser.RetractDate is null)", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView3.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView3.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LocationInchargeEntry_Load(object sender, EventArgs e)
        {
            lUserId = frmLogin.uId.ToString();
            //GetLocationInChargeName();
           // GetLocationName();
           // LoadLocationInCharge();
            LoadTerritory();
            LoadUserList();
        }

        private void LocationInchargeEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
           
          
                this.Hide();
                LocationManagementUI frm = new LocationManagementUI();
                frm.Show();
           
        }            
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;

                txtTerritoryId.Text = dr.Cells[0].Value.ToString();
                txtTerritoryName.Text = dr.Cells[1].Value.ToString();
                h = k;
                LoadLocationForSelectedTerritory();
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
                DataGridViewRow dr = dataGridView2.CurrentRow;
               locationId= txtLocationId.Text = dr.Cells[0].Value.ToString();
                txtLocationName.Text = dr.Cells[1].Value.ToString();
                h = k;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView3.CurrentRow;
                txtEmployeeId.Text = dr.Cells[2].Value.ToString();
                txtUserFullName.Text = dr.Cells[1].Value.ToString();
                h = k;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserFullName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select UserId from Users where  Users.FullName='" + txtUserFullName.Text + "'";
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
    }
}
