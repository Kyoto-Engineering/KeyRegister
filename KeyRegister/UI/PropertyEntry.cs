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
using PropertyManager = KeyRegister.Manager.PropertyManager;

namespace KeyRegister.UI
{
    public partial class PropertyEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int  locationInChargeId,locationId;
        public PropertyEntry()
        {
            InitializeComponent();
        }

        private void SaveProperty()
        {
            if (string.IsNullOrEmpty(cmbLocationInChargeName.Text))
            {
                MessageBox.Show("Please Select LocationInCharge Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return;
            }
            if (string.IsNullOrEmpty(cmbLocationName.Text))
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
                    MessageBox.Show("This Property Name Already Exists,Please Input another one", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;

                }

                int pt = 0;
                PropertyManager aManager = new PropertyManager();
                Property aProperty = new Property();
                aProperty.LocationInChargeId = locationInChargeId;
                aProperty.LocationId = locationId;
                aProperty.PropertyName = txtPropertyName.Text;
                pt = aManager.SaveProperty(aProperty);
                MessageBox.Show("Successfully Saved", "record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetProperty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetProperty()
        {
            cmbLocationName.SelectedIndex = -1;
            cmbLocationInChargeName.SelectedIndex = -1;
            txtPropertyName.Clear();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveProperty();
        }

        private void PropertyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                 frm.Show();
        }
        private void GetLocationInChargeName()
        {
            UserGateway aUserGatewate = new UserGateway();
            List<Users> users = aUserGatewate.GetUserName();
            cmbLocationInChargeName.DataSource = users;
            cmbLocationInChargeName.DisplayMember = "FullName";
            cmbLocationInChargeName.ValueMember = "UserId";
        }

        private void GetLocationName()
        {
            LocationGateway aGateway=new LocationGateway();
            List<Locations> aLocationses = aGateway.GetLocationName();
            cmbLocationName.DataSource = aLocationses;
            cmbLocationName.DisplayMember = "LocationName";
            cmbLocationName.ValueMember = "LocationId";
        }
        private void PropertyEntry_Load(object sender, EventArgs e)
        {
            GetLocationInChargeName();
            GetLocationName();
        }
    }
}
