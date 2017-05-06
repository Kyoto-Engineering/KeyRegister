using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyRegister.UI
{
    public partial class LocationManagementUI : Form
    {
        public LocationManagementUI()
        {
            InitializeComponent();
        }

        private void locationCreationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LocationEntry frm = new LocationEntry();
            frm.Show();
        }

        private void buttonLocationInChargeCreation_Click(object sender, EventArgs e)
        {

            this.Hide();
            LocationInchargeEntry frm = new LocationInchargeEntry();
            frm.Show();
        }

        private void buttonLocationAllocation_Click(object sender, EventArgs e)
        {
                       this.Hide();
            LocationAllocation frm=new LocationAllocation();
                         frm.Show();
        }

        private void LocationManagementUI_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                 frm.Show();
        }

        private void LocationManagementUI_Load(object sender, EventArgs e)
        {

        }
    }
}
