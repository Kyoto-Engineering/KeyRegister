using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.UI;

namespace KeyRegister.LoginUI
{
    public partial class UserManagementUI : Form
    {
        public UserManagementUI()
        {
            InitializeComponent();
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
                           this.Hide();
            registrationByAdmin frm=new registrationByAdmin();
                           frm.Show();

        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        { 
                      this.Hide();
            ResetPassword frm = new ResetPassword();
                      frm.Show();
        }

        private void buttonUserProfile_Click(object sender, EventArgs e)
        {
                        this.Hide();
            UploadUserImage frm =new UploadUserImage();
                         frm.Show();
        }

        private void UserManagementUI_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
               frm.Show();
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDetailsGrid frm = new UserDetailsGrid();
            frm.Show();

            //this.Hide();
            //UserUpdateForm frm = new UserUpdateForm();
            //frm.Show();

        } 
    }
}
