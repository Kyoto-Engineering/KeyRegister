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
using KeyRegister.Manager;

namespace KeyRegister.UI
{
    public partial class COO : Form
    {
        public int companyId;
        public string userId;
        public COO()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            COOManager  aManager=new COOManager();
            ModelCOO amCOO=new ModelCOO();
            amCOO.COOName = cmbUserName.Text;
            amCOO.CompanyId = companyId;
            amCOO.JoiningDate = Convert.ToDateTime(txtJoiningDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
            amCOO.CreationDate=DateTime.UtcNow;
            amCOO.UserId = userId;
            string msg = aManager.SaveCOO(amCOO);
            MessageBox.Show(msg);

        }
        private void GetUsername()
        {
            COOGateway aCooGateway = new COOGateway();
            List<User> users = aCooGateway.GetUserName();
            cmbUserName.DataSource = users;
            cmbUserName.DisplayMember = "FullName";
            cmbUserName.ValueMember = "FullName";
        }
        private void COO_Load(object sender, EventArgs e)
        {
            GetUsername();
        }
    }
}
