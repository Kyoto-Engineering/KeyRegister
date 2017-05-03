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
    public partial class KeyEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int keyTypeId, propertyId, lockId,nUserId;
        public KeyEntry()
        {
            InitializeComponent();
        }
        private void GetKeyType()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select KeyTypeName from KeyType";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbKeyType.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbKeyType.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void KeyEntry_Load(object sender, EventArgs e)
        {
            nUserId = frmLogin.uId;
            GetPropertyName();
            GetKeyType();
            GetLockName();
        }

        private void GetLockName()
        {
            LockGateway aGateway=new LockGateway();
            List<Lock> locks = aGateway.GetLockName(aGateway);
            cmbLockName.DataSource = locks;
            cmbLockName.DisplayMember = "LockName";
            cmbLockName.ValueMember = "LockId";

        }
        private void GetPropertyName()
        {
            PropertyGateway aGateway=new PropertyGateway();
            List<Property> properties = aGateway.GetPropertyName();
            cmbPropertyName.DataSource = properties;
            cmbPropertyName.DisplayMember = "PropertyName";
            cmbPropertyName.ValueMember = "PropertyId";


        }

        private void Reset()
        {
            cmbPropertyName.SelectedIndex = -1;
            cmbLockName.SelectedIndex = -1;
            cmbKeyType.SelectedIndex = -1;
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPropertyName.Text))
            {
                MessageBox.Show("Please Select Property Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbLockName.Text))
            {
                MessageBox.Show("Please enter Lock Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbKeyType.Text))
            {
                MessageBox.Show("Please Select Lock Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int ig = 0;
                KeyManager aManager = new KeyManager();
                Key aKey = new Key();                              
                aKey.PropertyId = propertyId;
                aKey.KLockId = lockId;
                aKey.KeyTypeId = keyTypeId;
                aKey.KUserId = nUserId;
                aKey.CreateddateTime=DateTime.Today;
                ig = aManager.SaveKey(aKey);
                MessageBox.Show("Suucessfully Saved", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KeyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                  frm.Show();

        }

        private void cmbKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyType.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input KeyType  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbKeyType.SelectedIndex = -1;
                }

                else
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select KeyTypeName from KeyType where KeyTypeName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This KeyType  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbKeyType.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into  KeyType(KeyTypeName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbKeyType.Items.Clear();
                            GetKeyType();
                            cmbKeyType.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT KeyTypeId from KeyType WHERE KeyTypeName= '" + cmbKeyType.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        keyTypeId = rdr.GetInt32(0);
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
        }

        private void cmbPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT PropertyId from Property WHERE PropertyName= '" + cmbPropertyName.Text + "'";

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
    }
}
