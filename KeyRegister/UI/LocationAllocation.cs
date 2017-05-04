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
using KeyRegister.Manager;

namespace KeyRegister.UI
{
    public partial class LocationAllocation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string locationId, locationInChargeId,h,g;
        public LocationAllocation()
        {
            InitializeComponent();
        }
        public void LoadLocation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  LocationId, LocationName FROM   Location", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
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
        public void LoadLocationInChargeName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  LocationIncharge.LcationInchargeId, Users.FullName FROM  LocationIncharge INNER JOIN Users ON LocationIncharge.UserId = Users.UserId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LocationAllocation_Load(object sender, EventArgs e)
        {
            LoadLocation();
            LoadLocationInChargeName();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLocationInCharge.Text))
            {
                MessageBox.Show("Please Select User Name as Location In Charge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtLocationName.Text))
            {
                MessageBox.Show("Please Select Location Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int lmg = 0;
                LocationAllocationManager amManager = new LocationAllocationManager();
                LocationAllocations allocation = new LocationAllocations();
                allocation.LocationId = Convert.ToInt32(locationId);
                allocation.LocationInChargeId = Convert.ToInt32(locationInChargeId);
                lmg = amManager.SaveLocationAllocation(allocation);
                MessageBox.Show("Successfully Saved", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                locationId = dr.Cells[0].Value.ToString();
                txtLocationName.Text = dr.Cells[1].Value.ToString();
                      h = g;
       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                locationInChargeId = dr.Cells[0].Value.ToString();
                txtLocationInCharge.Text = dr.Cells[1].Value.ToString();
                g = h;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocationAllocation_FormClosed(object sender, FormClosedEventArgs e)
        {
                          this.Hide();
                          LocationManagementUI frm = new LocationManagementUI();
                           frm.Show();
        }
    }
}
