using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.DBGateway;
using System.Security.Cryptography;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.LoginUI
{
    public partial class UploadUserImage : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int userId;
        public UploadUserImage()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;
                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;               
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    profilePicture.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "UPDATE Users Set UserImage=@d1 where  UserId='" + userId + "'";
                cmd = new SqlCommand(qry, con);
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(profilePicture.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d1", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Uploaded", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetUserName()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Select  FullName from  User  order  by  User.UserId desc ";
                cmd=new SqlCommand(qry,con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbUserName.Items.Add(rdr[0]);
                }
                con.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetUsername()
        {
            UserGateway aUserGatewate = new UserGateway();
            List<User> users = aUserGatewate.GetUserName();
            cmbUserName.DataSource = users;
            cmbUserName.DisplayMember = "FullName";
            cmbUserName.ValueMember = "UserId";
        }
        private void UploadUserImage_Load(object sender, EventArgs e)
        {
            GetUsername();
        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT UserId from Users WHERE FullName= '" + cmbUserName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    userId = rdr.GetInt32(0);
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
