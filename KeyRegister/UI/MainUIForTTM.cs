using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.LoginUI;

namespace KeyRegister.UI
{
    public partial class MainUIForTTM : Form
    {
        public MainUIForTTM()
        {
            InitializeComponent();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
                   this.Hide();
                   frmLogin frm = new frmLogin();
                   frm.Show();
        }

        private void buttonKeyHolderStation_Click(object sender, EventArgs e)
        {
            this.Hide();
            KeyHolderEntry frm = new KeyHolderEntry();
            frm.Show();
        }

        private void buttonKeyCreation_Click(object sender, EventArgs e)
        {
            this.Hide();
            KeyEntry frm = new KeyEntry();
            frm.Show();
        }

        private void buttonLockCreation_Click(object sender, EventArgs e)
        {
            this.Hide();
            LockEntry frm = new LockEntry();
            frm.Show();
        }

        private void buttonPropertyCreation_Click(object sender, EventArgs e)
        {
            this.Hide();
            PropertyEntry frm = new PropertyEntry();
            frm.Show();
        }

        private void buttonLocationCreation_Click(object sender, EventArgs e)
        {
            this.Hide();
            LocationManagementUI frm = new LocationManagementUI();
            frm.Show();
        }
    }
}
