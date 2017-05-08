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
using KeyRegister.DBGateway;
using KeyRegister.UI;

namespace KeyRegister.LoginUI
{
    public partial class frmLogin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr,rdr1,rdr2;
        ConnectionString cs=new ConnectionString();
        public string readyPassword, dbUserName, dbPassword;
        public static int uId;
        public static string userType;
        public string userId;
        public string userName, password;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void MaintainTTMAuthorization()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "SELECT TerritoryId FROM Territory WHERE (UserId = @UI) AND (DefunctDate IS NULL)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@UI", uId);
                rdr = cmd.ExecuteReader();
                con.Close();
                if (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        userType = "TMM";
                        this.Hide();
                        MainUI frm = new MainUI();
                        frm.Show();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MaintainCOOAuthorization()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "SELECT COOId FROM  COO WHERE  (UserId = @UI) AND (ResignationDate IS NULL)";
                cmd=new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@UI", userId);
                rdr = cmd.ExecuteReader();               
                if (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        userType = "COO";
                        this.Hide();
                        MainUI frm=new MainUI();
                        frm.Show();
                    }
                                
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaintainLocationInChargeAuthorization()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "SELECT COOId FROM  COO WHERE  (UserId = @UI) AND (ResignationDate IS NULL)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@UI", uId);
                rdr = cmd.ExecuteReader();
                con.Close();
                if (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        userType = "COO";
                        this.Hide();
                        MainUI frm = new MainUI();
                        frm.Show();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaintainLocalUserAuthorization()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "SELECT COOId FROM  COO WHERE  (UserId = @UI) AND (ResignationDate IS NULL)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@UI", uId);
                rdr = cmd.ExecuteReader();
                con.Close();
                if (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        userType = "COO";
                        this.Hide();
                        MainUI frm = new MainUI();
                        frm.Show();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
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
                string qry = "SELECT  RTRIM(Users.UserId),RTRIM(Users.UserName),RTRIM(Users.Password) FROM  Users  WHERE Users.UserName = '" + txtUserName.Text + "' AND  Users.Password = '" + readyPassword + "'";
                cmd = new SqlCommand();
                cmd.CommandText = qry;
                cmd.Connection = con;
                rdr1 = cmd.ExecuteReader();
                if (rdr1.Read())
                {
                        userId = (rdr1.GetString(0));
                        dbUserName = (rdr1.GetString(1));
                        dbPassword = (rdr1.GetString(2));
                        uId = Convert.ToInt32(userId);                                              
                }
                con.Close();

                con=new SqlConnection(cs.DBConn);
                con.Open();
                string qry1 = "Select RTRIM(Users.UserType)  from  Users WHERE Users.UserName = '" + dbUserName + "' AND  Users.Password = '" + dbPassword + "'";
                cmd=new SqlCommand(qry1,con);
                rdr2 = cmd.ExecuteReader();
                if (rdr2.Read())
                {
                    userType = (rdr2.GetString(0));
                    string caseSwitch = userType;
                    switch (caseSwitch)
                    {
                        case "COO":
                            MaintainCOOAuthorization();
                            break;
                        case "TTM":
                            MaintainTTMAuthorization();
                            break;
                        case "LIC":
                            MaintainLocationInChargeAuthorization();
                            break;
                        default:
                            MaintainLocalUserAuthorization();
                            break;
                    }
                }

                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtUserName.Focus();
                }                                                      
                }                
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
