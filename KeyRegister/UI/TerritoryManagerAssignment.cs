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
    public partial class TerritoryManagerAssignment : Form
    {
        private SqlCommand cmd;
        private SqlConnection con;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int territoryId, userIdAsTM,checkTMUserId;
        public string userId,h,k,userType;
        public TerritoryManagerAssignment()
        {
            InitializeComponent();
        }
        //private void GetTerritoryName()
        //{
        //    TerritoryGateway aGateway = new TerritoryGateway();
        //    List<Territory> territories = aGateway.GetTerritoryName();
        //    cmbTerritoryName.DataSource = territories;
        //    cmbTerritoryName.DisplayMember = "TerritoryName";
        //    cmbTerritoryName.ValueMember = "TerritoryId";
        //}
        //private void GetTerritoryManagerName()
        //{
        //    TerritoryManagerGateway aUserGatewate = new TerritoryManagerGateway();
        //    List<Users> users = aUserGatewate.GetUserName();
        //    cmbTerritoryManagerName.DataSource = users;
        //    cmbTerritoryManagerName.DisplayMember = "FullName";
        //    cmbTerritoryManagerName.ValueMember = "UserId";
        //}
        public void LoadUserList()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  UserId, FullName, EmployeeId FROM  Users  where  Users.Statuss='Active' and  UserId not in (Select UserId  from COO) and UserId not in (Select UserId  from LocationUser)", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2]);
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
                cmd = new SqlCommand("SELECT  TerritoryId,TerritoryName FROM Territory", con);
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
        public void LoadUserName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  UserId, FullName, EmployeeId FROM   Users where Statuss='Active' and UserId not in (SELECT  UserId FROM   Location) and UserId not in(SELECT  UserId FROM  COO) and  UserId not in (SELECT  UserId FROM   KeyRgisterk)  and  UserId not in (SELECT  UserId FROM   LocationUser where  RetractDate is null)", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TerritoryManagerAssignment_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            userType = frmLogin.userType;
           // GetTerritoryManagerName();
           // GetTerritoryName();
            LoadUserName();
            LoadTerritory();
            //LoadUserList();
        }

        private void Reset()
        {            
            txtTerritoryManager.Clear();
            txtEmployeeId.Clear();
            txtUserId.Clear();
            txtTerritoryName.Clear();
            txtAssignedDate.Value=DateTime.Today;
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTerritoryManager.Text))
            {
                MessageBox.Show("Please Select Territory Manager Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTerritoryName.Text))
            {
                MessageBox.Show("Please Select Territory Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select TerritoryManager.UserId  from TerritoryManager where  TerritoryManager.UserId='" + userIdAsTM + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {

                    checkTMUserId = (rdr.GetInt32(0));
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "Select TerritoryManager.TerritoryId  from TerritoryManager where  TerritoryManager.UserId='" + checkTMUserId + "'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Territory is Already Under  this Territory Manager,Please assign another territory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;
                }
                int tm = 0;
                TerritoryManagerManager aManager = new TerritoryManagerManager();
                TerritoryManagers aManagers = new TerritoryManagers();
                aManagers.TMUserId = userIdAsTM.ToString();
                aManagers.TerritoryId = territoryId.ToString();
                aManagers.OnDutyFrom = txtAssignedDate.Value;
                aManagers.AssignedBy = userId;
                tm = aManager.SaveTerritoryManagement(aManagers);
                MessageBox.Show("Successfully Created", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //LoadTerritoryManager();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void TerritoryManagerAssignment_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                 frm.Show();
        }

        private void txtTerritoryName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select TerritoryId from Territory where  Territory.TerritoryName='" + txtTerritoryName.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    territoryId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;                                      
                txtTerritoryName.Text = dr.Cells[1].Value.ToString();                
                h=k;
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
                txtUserId.Text = dr.Cells[0].Value.ToString();
                txtTerritoryManager.Text = dr.Cells[1].Value.ToString();
                txtEmployeeId.Text = dr.Cells[2].Value.ToString();
                h = k;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTerritoryManager_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select UserId from Users where  Users.FullName='" + txtTerritoryManager.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    userIdAsTM = (rdr.GetInt32(0));
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
