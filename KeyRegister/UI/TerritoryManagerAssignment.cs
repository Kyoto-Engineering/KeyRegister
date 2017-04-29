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
        public int territoryId, userIdAsTM;
        public string userId;
        public TerritoryManagerAssignment()
        {
            InitializeComponent();
        }
        private void GetTerritoryName()
        {
            TerritoryGateway aGateway = new TerritoryGateway();
            List<Territory> territories = aGateway.GetTerritoryName();
            cmbTerritoryName.DataSource = territories;
            cmbTerritoryName.DisplayMember = "TerritoryName";
            cmbTerritoryName.ValueMember = "TerritoryId";
        }
        private void GetTerritoryManagerName()
        {
            UserGateway aUserGatewate = new UserGateway();
            List<Users> users = aUserGatewate.GetUserName();
            cmbTerritoryManagerName.DataSource = users;
            cmbTerritoryManagerName.DisplayMember = "FullName";
            cmbTerritoryManagerName.ValueMember = "UserId";
        }
        private void TerritoryManagerAssignment_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            GetTerritoryManagerName();
            GetTerritoryName();
        }
        private void SaveTerritoryManagement()
        {
            try
            {
                int tm = 0;
                TerritoryManagerManager aManager = new TerritoryManagerManager();
                TerritoryManagers aManagers = new TerritoryManagers();
                aManagers.TMUserId = userIdAsTM.ToString();
                aManagers.TerritoryId = territoryId.ToString();
                aManagers.OnDutyFrom = txtAssignedDate.Value;
                aManagers.AssignedBy = userId;
                tm = aManager.SaveTerritoryManagement(aManagers);
                MessageBox.Show("Successfully Created", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveTerritoryManagement();
        }

        private void cmbTerritoryManagerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select UserId from Users where  Users.FullName='" + cmbTerritoryManagerName.Text + "'";
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

        private void cmbTerritoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select TerritoryId from Territory where  Territory.TerritoryName='" + cmbTerritoryName.Text + "'";
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
    }
}
