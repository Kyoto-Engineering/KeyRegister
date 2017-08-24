using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.DAO;
using KeyRegister.DBGateway;
using KeyRegister.Gateway;

namespace KeyRegister.LoginUI
{
    public partial class ResetPassword : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string readyPassword;
        public ResetPassword()
        {
            InitializeComponent();
        }
        
        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUserName.Text))
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }          
            try
            {
                string clearText = txtPassword.Text.Trim();
                string password = clearText;
                byte[] bytes = Encoding.Unicode.GetBytes(password);
                byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                string readyPassword1 = Convert.ToBase64String(inArray);
                readyPassword = readyPassword1;

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update Registration set Password=@d1 where UserName='" + cmbUserName.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", readyPassword);
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Reset Password", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUserName.SelectedIndex = -1;
                txtPassword.Clear();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            UserManagementUI frm = new UserManagementUI();
            frm.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void GetUsername()
        {
            COOGateway aCooGateway = new COOGateway();
            List<Users> users = aCooGateway.GetUserName();
            cmbUserName.DataSource = users;
            cmbUserName.DisplayMember = "FullName";
            cmbUserName.ValueMember = "FullName";
        }
        private void ResetPassword_Load(object sender, EventArgs e)
        {
            GetUsername();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            createButton_Click(this, new EventArgs());
        }
    }
}
