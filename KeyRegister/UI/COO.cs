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
    public partial class COO : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int companyId,mUserId;
        public string userId;
        public COO()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUserName.Text))
            {
                MessageBox.Show("Please Select user as COO Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbCompanyName.Text))
            {
                MessageBox.Show("Please enter Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                COOManager aManager = new COOManager();
                ModelCOO amCOO = new ModelCOO();
                amCOO.MUserId = mUserId;
                amCOO.CompanyId = companyId;
                amCOO.JoiningDate = Convert.ToDateTime(txtJoiningDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                amCOO.CreationDate = DateTime.UtcNow;
                amCOO.UserId = userId;
                string msg = aManager.SaveCOO(amCOO);
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void GetUsername()
        {
            COOGateway aCooGateway = new COOGateway();
            List<Users> users = aCooGateway.GetUserName();
            cmbUserName.DataSource = users;
            cmbUserName.DisplayMember = "FullName";
            cmbUserName.ValueMember = "FullName";
        }
        private void GetCompanyName()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Select  CompanyName from  Company  order  by  Company.CompanyId desc ";
                cmd = new SqlCommand(qry, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCompanyName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void COO_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            GetUsername();
            GetCompanyName();
        }

        private void COO_FormClosed(object sender, FormClosedEventArgs e)
        {
                  this.Hide();
            MainUI frm=new MainUI();
                  frm.Show();

        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select CompanyId from Company where  Company.CompanyName='" + cmbCompanyName.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyId = (rdr.GetInt32(0));
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select UserId from Users where  Users.FullName='" + cmbUserName.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    mUserId = (rdr.GetInt32(0));
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
