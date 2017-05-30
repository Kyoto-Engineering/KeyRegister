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
    public partial class LocationEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string userId,lTerriToryId,userType,h,k;
        public LocationEntry()
        {
            InitializeComponent();
        }

        private void ClearText()
        {
            txtLocation.Clear();
            txtTerritoriId.Clear();
            txtTerritoriName.Clear();
            
        }
       
        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLocation.Text))
            {
                MessageBox.Show("Please enter Location Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select Location.LocationName from Location where  Location.LocationName='" + txtLocation.Text + "' and  Location.TerritoryId='"+lTerriToryId+"'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Location Name Already Exists for this Territory,Please Input another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    ClearText();
                    dataGridView2.Rows.Clear();
                    return;

                }
                int mgs;
                LocationManager aManager = new LocationManager();
                Locations aLocation = new Locations();
                aLocation.LocationName = txtLocation.Text;
                aLocation.LUserId = Convert.ToInt32(userId);
                aLocation.CreateddateTime = DateTime.Today;
                 aLocation.LTerritoryId = Convert.ToInt32(txtTerritoriId.Text);
                mgs = aManager.SaveLocation(aLocation);
                MessageBox.Show("Successfully Submited", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearText();
                dataGridView2.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadLocationForSelectedTerritory()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  LocationId, LocationName FROM  Location where Location.TerritoryId ='"+txtTerritoriId.Text+"'", con);
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
        public void LoadTerritoryForCOO()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Territory.TerritoryId, Territory.TerritoryName, Users.FullName FROM  TerritoryManager INNER JOIN Territory ON TerritoryManager.TerritoryId = Territory.TerritoryId INNER JOIN Users ON TerritoryManager.UserId = Users.UserId", con);
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
                cmd = new SqlCommand("SELECT Territory.TerritoryId, Territory.TerritoryName, Users.FullName FROM  TerritoryManager INNER JOIN Territory ON TerritoryManager.TerritoryId = Territory.TerritoryId INNER JOIN Users ON TerritoryManager.UserId = Users.UserId where TerritoryManager.TMId  in (Select TerritoryManager.TMId from TerritoryManager where TerritoryManager.UserId ='"+userId+"')", con);
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
        private void LocationEntry_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
           
            //LoadLocation();
            userType = frmLogin.userType;
            if (userType == "COO")
            {
                LoadTerritoryForCOO();
            }
            else
            {
                LoadTerritory();
            }


        }

        private void LocationEntry_FormClosed(object sender, FormClosedEventArgs e)
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

             lTerriToryId=  txtTerritoriId .Text = dr.Cells[0].Value.ToString();
                txtTerritoriName.Text = dr.Cells[1].Value.ToString();
                h = k;
                LoadLocationForSelectedTerritory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTerritoriId_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
