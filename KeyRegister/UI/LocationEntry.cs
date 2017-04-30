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
    public partial class LocationEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string userId,lTerriToryId;
        public LocationEntry()
        {
            InitializeComponent();
        }

        private void   SaveLocation()
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
                string ct3 = "select Location.LocationName from Location where  Location.LocationName='" + txtLocation.Text + "'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Location Name Already Exists,Please Input another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;

                }
                int mgs;
                LocationManager aManager = new LocationManager();
                Locations aLocation = new Locations();
                aLocation.LocationName = txtLocation.Text;
                aLocation.LUserId = Convert.ToInt32(userId);
                aLocation.CreateddateTime = DateTime.Today;
                // aLocation.LTerritoryId = Convert.ToInt32(lTerriToryId);
                mgs = aManager.SaveLocation(aLocation);
                MessageBox.Show("Successfully Submited", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLocation.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            SaveLocation();
        }

        private void LocationEntry_Load(object sender, EventArgs e)
        {
               
        }

        private void LocationEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }
    }
}
