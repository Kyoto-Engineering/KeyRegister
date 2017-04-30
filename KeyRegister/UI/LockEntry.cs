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
    public partial class LockEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int propertyId, lockTypeId;
        public string nUserId;
        public LockEntry()
        {
            InitializeComponent();
        }

        private void LockEntry_Load(object sender, EventArgs e)
        {
            nUserId = frmLogin.uId.ToString();
            GetLockType();
            GetPropertyName();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPropertyName.Text))
            {
                MessageBox.Show("Please Select Property Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtLockName.Text))
            {
                MessageBox.Show("Please enter Lock Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbLockType.Text))
            {
                MessageBox.Show("Please Select Lock Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int ig = 0;
                LockManager aManager=new LockManager();
                Lock aLock=new Lock();
                aLock.PropertyId = propertyId;
                aLock.LockName = txtLockName.Text;
                aLock.LockTypeId = lockTypeId;
                aLock.LUserId = nUserId;
                aLock.CreatedDateTime=DateTime.UtcNow;
                ig = aManager.SaveLock(aLock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select PropertyId from Property where  Property.PropertyName='" + cmbPropertyName.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    propertyId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetLockType()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select LockTypeName from LockType";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbLockType.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbLockType.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetPropertyName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select PropertyName from Property order by PropertyId desc ";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbPropertyName.Items.Add(rdr.GetValue(0).ToString());
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbLockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLockType.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input LockTypeName  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbLockType.SelectedIndex = -1;
                }

                else
                {
                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select LockTypeName from LockType where LockTypeName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This LockTypeName  Already Exists,Please Select From List", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbLockType.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into  LockType(LockTypeName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);                           
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbLockType.Items.Clear();
                            GetLockType();
                            cmbLockType.SelectedText = input;
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
                    cmd.CommandText = "SELECT LockTypeId from LockType WHERE LockTypeName= '" + cmbLockType.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        lockTypeId = rdr.GetInt32(0);
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

        private void LockEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
               this.Hide();
            MainUI frm=new MainUI();
                frm.Show();
        }
    }
}
