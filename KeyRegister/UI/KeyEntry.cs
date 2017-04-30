using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyRegister.DAO;
using KeyRegister.Gateway;

namespace KeyRegister.UI
{
    public partial class KeyEntry : Form
    {

        public KeyEntry()
        {
            InitializeComponent();
        }

        private void KeyEntry_Load(object sender, EventArgs e)
        {
            GetPropertyName();
        }

        private void GetPropertyName()
        {
            PropertyGateway aGateway=new PropertyGateway();
            List<Property> properties = aGateway.GetPropertyName();
            cmbPropertyName.DataSource = properties;
            cmbPropertyName.DisplayMember = "PropertyName";
            cmbPropertyName.ValueMember = "PropertyId";


        }
        private void createButton_Click(object sender, EventArgs e)
        {

        }

        private void KeyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                  frm.Show();

        }
    }
}
