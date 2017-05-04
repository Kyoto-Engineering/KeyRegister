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
using KeyRegister.Manager;

namespace KeyRegister.UI
{
    public partial class KeyHolderEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int locationId,userAsKeyHolderId;
        public KeyHolderEntry()
        {
            InitializeComponent();
        }

       

        private void GetUserName()
        {
            UserGateway aGateway=new UserGateway();
            List<Users> aUsers = aGateway.GetUserName();
            cmbKeyHolderName.DataSource = aUsers;
            cmbKeyHolderName.DisplayMember = "FullName";
            cmbKeyHolderName.ValueMember = "UserId";
        }
        private void GetLocationName()
        {
            LocationGateway aGateway=new LocationGateway();
            List<Locations> alocation = aGateway.GetLocationName();
            cmbLocationName.DataSource = alocation;
            cmbLocationName.DisplayMember = "LocationName";
            cmbLocationName.ValueMember = "LocationId";
            //string locationId = cmbLocationName.SelectedText.ToString();
        }
        private void KeyHolderEntry_Load(object sender, EventArgs e)
        {
            GetLocationName();
            GetUserName();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbKeyHolderName.Text))
            {
                MessageBox.Show("Please Select KeyHolder Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbLocationName.Text))
            {
                MessageBox.Show("Please Select Location Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int kh = 0;
                KeyHolderManager aManager = new KeyHolderManager();
                KeyHolder aKeyHolder = new KeyHolder();
                aKeyHolder.LocationId = locationId;
                aKeyHolder.UKeyHolderId = userAsKeyHolderId;
                kh = aManager.SaveKeyHolder(aKeyHolder);
                MessageBox.Show("Successfully Saved", "record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }



        }

        private void cmbLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT LocationId from Location WHERE LocationName= '" + cmbLocationName.Text + "'";
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

        private void cmbKeyHolderName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT UserId from Users WHERE FullName= '" + cmbKeyHolderName.Text + "'";

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    userAsKeyHolderId = rdr.GetInt32(0);
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

        private void KeyHolderEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
              this.Hide();
            MainUI  frm=new MainUI();
              frm.Show();
        }
    }
}
