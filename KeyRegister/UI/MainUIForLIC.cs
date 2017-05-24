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
    public partial class MainUIForLIC : Form
    {
        public MainUIForLIC()
        {
            InitializeComponent();
        }

        private void userManagementButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserManagementUI frm = new UserManagementUI();
            frm.Show();
        }

        private void buttonKeyAllocation_Click(object sender, EventArgs e)
        {
            this.Hide();
            KeyAllocationEntry frm = new KeyAllocationEntry();
            frm.Show();
        }

        private void buttonKeyHolderStation_Click(object sender, EventArgs e)
        {
           
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
    }
}
