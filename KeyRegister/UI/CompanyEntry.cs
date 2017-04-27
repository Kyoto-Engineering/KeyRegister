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
using KeyRegister.LoginUI;

namespace KeyRegister.UI
{
    public partial class CompanyEntry : Form
    {
        public string userId;
        public CompanyEntry()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                MessageBox.Show("Please enter Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyName.Focus();
                return;
            }
            try
            {
                CompanyGateway aComGateway = new CompanyGateway();
                Company aCompany = new Company();
                aCompany.CompanyName = txtCompanyName.Text;
                aCompany.CreatedDateTime=DateTime.UtcNow;
                string msg = aComGateway.SaveCompany(aCompany);
                MessageBox.Show(msg);
                txtCompanyName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void CompanyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                 frm.Show();
        }

        private void CompanyEntry_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
        }
    }
}
