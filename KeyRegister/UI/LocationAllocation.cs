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
using KeyRegister.LoginUI;
using KeyRegister.Manager;

namespace KeyRegister.UI
{
    public partial class LocationAllocation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        private SqlDataAdapter sda;
        private DataTable dt;
        public string locationId, locationInChargeId, h, g, nUserType, nUserId,territoryId,a,b;
        public int kUserId, numOfTerritory, numOfLocation, dbLocationId, dbUserId;
        public LocationAllocation()
        {
            InitializeComponent();
        }
        public void LoadUserList()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  UserId, FullName, EmployeeId FROM  Users where  Users.Statuss='Active' and UserId not in (Select UserId  from COO where COO.ResignationDate is null) and UserId not in (Select UserId  from TerritoryManager where TerritoryManager.OffDutydate is null) and  UserId not in (Select UserId  from LocationIncharge where  LocationIncharge.RetractDate is null) and UserId not in (Select UserId  from KeyRgisterk where  KeyRgisterk.Assignedto is null)", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView3.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView3.Rows.Add(rdr[0], rdr[1],rdr[2]);
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
        public void LoadLocation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Location.LocationId,Location.LocationName FROM  Location INNER JOIN Territory ON Location.TerritoryId = Territory.TerritoryId where Location.TerritoryId='"+territoryId+"'", con);
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
                    dataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2]);
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
        private void SetLocationByUserList()
        {
            listView1.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string qry = "Select LocationUser.LocationId,LocationUser.UserId  from LocationUser  where LocationUser.LocationId=4 and RetractDate is null";
            sda = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            sda.Fill(dt);

            for (int b = 0; b < dt.Rows.Count; b++)
            {
                DataRow dr = dt.Rows[b];
                //ListViewItem listitem1 = new ListViewItem(dr[0].ToString());
                ListViewItem listitem1 = new ListViewItem();
                listitem1.SubItems.Add(dr[0].ToString());
                listitem1.SubItems.Add(dr[1].ToString());
                listView1.Items.Add(listitem1);
            }
        }
        private void GetCountTerritoryUnderTerritoryManager()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select count(TerritoryId) from TerritoryManager where  TerritoryManager.UserId='"+nUserId+"'";
                cmd=new SqlCommand(query,con);
                rdr=cmd.ExecuteReader();
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
        private void LocationAllocation_Load(object sender, EventArgs e)
        {
            nUserId = frmLogin.uId.ToString();
            nUserType = frmLogin.userType;
            if (nUserType == "COO")
            {
                LoadTerritoryForCOO();
            }
            else if(nUserType=="TTM")
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
            else if(nUserType=="LIC")
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

            SetLocationByUserList();
            LoadUserList();
        }

        private void Reset()
        {
            txtLocationId.Clear();
            txtLocationName.Clear();
            txtUserId.Clear();
            txtUserName.Clear();
            txtEmpId.Clear();
        }

        private void SaveLocationForUser()
        {
            int lmg = 0;
            LocationAllocationManager amManager = new LocationAllocationManager();
            LocationAllocations allocation = new LocationAllocations();
            allocation.LocationId = Convert.ToInt32(locationId);
            allocation.LocationInChargeId = Convert.ToInt32(txtUserId.Text);
            allocation.AddedDate = DateTime.UtcNow.ToLocalTime();
            lmg = amManager.SaveLocationAllocation(allocation);
            MessageBox.Show("Successfully Saved", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reset();
            dataGridView2.Rows.Clear();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLocationId.Text))
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

                if (listView1.Items.Count == 0)
                {
                    SaveLocationForUser();
                }
                else
                {
                    for (int i = 1; i <= listView1.Items.Count - 1; i++)
                    {
                        int xk = Convert.ToInt32(txtUserId.Text);
                        int y = Convert.ToInt32(Convert.ToInt32(listView1.Items[i].SubItems[2].Text));
                        if (xk == y)
                        {
                            MessageBox.Show("This Location has already allocated  for this User.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                            Reset();
                            dataGridView2.Rows.Clear();
                            return;
                        }

                    }
                    SaveLocationForUser();
                }
                

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
                locationId=txtLocationId.Text = dr.Cells[0].Value.ToString();
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
        }

        private void LocationAllocation_FormClosed(object sender, FormClosedEventArgs e)
        {
                          this.Hide();
                          LocationManagementUI frm = new LocationManagementUI();
                           frm.Show();
        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                territoryId = dr.Cells[0].Value.ToString();
                LoadLocation();
                g = h;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (dataGridView3.SelectedRows.Count > 0)
            //    {
            //        DataGridViewRow dr = dataGridView3.SelectedRows[0];
            //        kUserId = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());

            //        if (listView1.Items.Count > 0)
            //        {
            //            int x = listView1.Items.Count - 1;
            //            for (int i = 0; i <= x; i++)
            //            {
            //                if (kUserId == Convert.ToInt32(listView1.Items[i].SubItems[0].Text))
            //                {
            //                    MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }


            //            }
            //            ListViewItem lst1 = new ListViewItem();
            //            lst1.Text = dr.Cells[0].Value.ToString();
            //            lst1.SubItems.Add(dr.Cells[1].Value.ToString());
            //            lst1.SubItems.Add(dr.Cells[2].Value.ToString());
            //            listView1.Items.Add(lst1);
                     
            //        }

            //        if (listView1.Items.Count == 0)
            //        {

            //            ListViewItem lst = new ListViewItem();
            //            lst.Text = dr.Cells[0].Value.ToString(); 
            //            lst.SubItems.Add(dr.Cells[1].Value.ToString());
            //            lst.SubItems.Add(dr.Cells[2].Value.ToString());
            //            listView1.Items.Add(lst);
                      
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("There is not any row selected, please select row and Click Add Button!");

            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr1 = dataGridView3.CurrentRow;
                txtUserId.Text = dr1.Cells[0].Value.ToString();
                txtUserName.Text = dr1.Cells[1].Value.ToString();
                txtEmpId.Text = dr1.Cells[2].Value.ToString();
                a = b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
