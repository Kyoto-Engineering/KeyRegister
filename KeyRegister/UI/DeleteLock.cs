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
using KeyRegister.DBGateway;
using KeyRegister.LoginUI;

namespace KeyRegister.UI
{
    public partial class DeleteLock : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string nUserId, nUserType;
        public DeleteLock()
        {
            InitializeComponent();
        }

        public void LoadTerritoryForCOO()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Territory.TerritoryId, Territory.TerritoryName,Users.FullName FROM  TerritoryManager INNER JOIN Territory ON TerritoryManager.TerritoryId = Territory.TerritoryId INNER JOIN Users ON TerritoryManager.UserId = Users.UserId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DeleteLock_Load(object sender, EventArgs e)
        {
            nUserId = frmLogin.uId.ToString();
            nUserType = frmLogin.userType;
            if (nUserType == "COO")
            {
                LoadTerritoryForCOO();
            }
            else if (nUserType == "TTM")
            {
                //GetCountTerritoryUnderTerritoryManager();
                //if (numOfTerritory > 1)
                //{
                //    LoadTerritoryForTTM();
                //}
                //if (numOfTerritory == 1)
                //{
                //    dataGridView1.Visible = false;
                //    LoadLocationForSingleTerritory();

                //}
            }
            else if (nUserType == "LIC")
            {
                //GetCountLocationUnderLocationInCharge();
                //if (numOfLocation > 1)
                //{
                //    dataGridView1.Visible = false;
                //    LoadMultipleLocationUnderLocationInCharge();
                //}
                //if (numOfLocation == 1)
                //{
                //    dataGridView1.Visible = false;
                //    dataGridView2.Visible = false;
                //    LoadSingleLocationUnderLocationInCharge();
                //}
            }
            //GetLockType();                 
        }
    }
}
