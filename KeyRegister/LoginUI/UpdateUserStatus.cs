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
using KeyRegister.DBGateway;

namespace KeyRegister.LoginUI
{
    public partial class UpdateUserStatus : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string userId;
        public UpdateUserStatus()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "UPDATE Users Set Statuss=@d1  where Users.UserId='"+userId+"'";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", cmbStatus.Text);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Updated", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            updateButton_Click(this, new EventArgs());
        }
    }
}
