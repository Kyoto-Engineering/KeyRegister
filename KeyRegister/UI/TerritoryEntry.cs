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
using KeyRegister.LoginUI;
using KeyRegister.Manager;

namespace KeyRegister.UI
{
    public partial class TerritoryEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string userId;
        public int companyId=1;
        public TerritoryEntry()
        {
            InitializeComponent();
        }
        private void GetTerritoryList()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "SELECT TerritoryId,TerritoryName FROM   Territory";
                cmd = new SqlCommand(qry, con);
                rdr = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    dataGridView1.Rows.Add(rdr[0],rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TerritoryEntry_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
             GetTerritoryList();
        }

       

        private void ResetTerritory()
        {
          //  cmbCompany.SelectedIndex = -1;
            txtTerritoryName.Clear();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(cmbCompany.Text))
            //{
            //    MessageBox.Show("Please Select Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (string.IsNullOrEmpty(txtTerritoryName.Text))
            {
                MessageBox.Show("Please enter Territory Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select Territory.TerritoryName  from Territory where  Territory.TerritoryName='" + txtTerritoryName.Text + "'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Territory Name Already Exists,Please Input another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;

                }


                int tg = 0;
                TerritoryManager aManager = new TerritoryManager();
                Territory aTerritory = new Territory();
                aTerritory.TerritoryName = txtTerritoryName.Text;
                aTerritory.CreatedDateTime = DateTime.Today;
                aTerritory.TUserId = Convert.ToInt32(userId);
                aTerritory.CompanyId = Convert.ToInt32(companyId);
                tg = aManager.SaveTerritory(aTerritory);
                MessageBox.Show("Successfully Created", "record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetTerritory();
                GetTerritoryList();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TerritoryEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
            frm.Show();
        }

        private void txtTerritoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            createButton_Click(this, new EventArgs());
        }
    }
}
