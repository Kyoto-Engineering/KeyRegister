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
using KeyRegister.Gateway;
using KeyRegister.LoginUI;
using KeyRegister.Manager;

namespace KeyRegister.UI
{
    public partial class KeyEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int keyTypeId,  numOfTerritory, numOfLocation;
        public string nUserId, nUserType, h, g, territoryId, a, b, locationId, propertyId, keyIsId, lockId;
        public KeyEntry()
        {
            InitializeComponent();
        }
        private void GetKeyType1()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select KeyTypeName from KeyType";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbKeyType.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbKeyType.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadKeyList()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Keys.KeyId,Property.PropertyName,Lock.LockNo,KeyType.KeyTypeName FROM  Keys INNER JOIN KeyType ON Keys.KeyTypeId = KeyType.KeyTypeId  INNER JOIN Lock ON Keys.LockId = Lock.LockId  INNER JOIN Property ON Lock.PropertyId = Property.PropertyId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3],rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetCountTerritoryUnderTerritoryManager()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select count(TerritoryId) from TerritoryManager where  TerritoryManager.UserId='" + nUserId + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    numOfTerritory = (rdr.GetInt32(0));
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetCountLocationUnderLocationInCharge()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select count(LocationId) from LocationIncharge where  LocationIncharge.UserId='" + nUserId + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    numOfLocation = (rdr.GetInt32(0));
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadMultipleLocationUnderLocationInCharge()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Location.LocationId, Location.LocationName FROM  LocationIncharge INNER JOIN Location ON LocationIncharge.LocationId = Location.LocationId where LocationIncharge.UserId='" + nUserId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadLocationForSingleTerritory()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Location.LocationId,Location.LocationName FROM  Location INNER JOIN Territory ON Location.TerritoryId = Territory.TerritoryId where Location.TerritoryId='" + territoryId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadSingleLocationUnderLocationInCharge()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Location.LocationId,Location.LocationName FROM  Location INNER JOIN Territory ON Location.TerritoryId = Territory.TerritoryId where Location.TerritoryId='" + territoryId + "'", con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtLocationId.Text = (rdr.GetString(0));
                    txtLocationName.Text = (rdr.GetString(1));
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadTerritoryForTTM()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Territory.TerritoryId, Territory.TerritoryName, Users.FullName FROM  TerritoryManager INNER JOIN Territory ON TerritoryManager.TerritoryId = Territory.TerritoryId INNER JOIN Users ON TerritoryManager.UserId = Users.UserId where  TerritoryManager.UserId='" + nUserId + "'", con);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void KeyEntry_Load(object sender, EventArgs e)
        {
            GetKeyIs();
            GetKeyType1();
            nUserId = frmLogin.uId.ToString();
            nUserType = frmLogin.userType;
            if (nUserType == "COO")
            {
                LoadTerritoryForCOO();
            }
            else if (nUserType == "TTM")
            {
                GetCountTerritoryUnderTerritoryManager();
                if (numOfTerritory > 1)
                {
                    LoadTerritoryForTTM();
                }
                if (numOfTerritory == 1)
                {
                    dataGridView1.Visible = false;
                    LoadLocationForSingleTerritory();

                }
            }
            else if (nUserType == "LIC")
            {
                GetCountLocationUnderLocationInCharge();
                if (numOfLocation > 1)
                {
                    dataGridView1.Visible = false;
                    LoadMultipleLocationUnderLocationInCharge();
                }
                if (numOfLocation == 1)
                {
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    LoadSingleLocationUnderLocationInCharge();
                }
            }
                
          
            }

        private void GetLockNumber()
        {
            LockGateway aGateway = new LockGateway();
            List<Lock> locks = aGateway.GetLockNumber(aGateway);
            //cmbLockNo.DataSource = locks;
            //cmbLockNo.DisplayMember = "LockNo";
            //cmbLockNo.ValueMember = "LockId";

        }
        private void GetPropertyName()
        {
            //PropertyGateway aGateway=new PropertyGateway();
            //List<Property> properties = aGateway.GetPropertyName();
            //cmbPropertyName.DataSource = properties;
            //cmbPropertyName.DisplayMember = "PropertyName";
            //cmbPropertyName.ValueMember = "PropertyId";


        }
       
        private void GetKeyType()
        {
            KeyGateway aGateway=new KeyGateway();
            List<KeyTypes> aKeyTypeses = aGateway.GetKeyType();
            cmbKeyType.DataSource = aKeyTypeses;
            cmbKeyType.DisplayMember = "KeyTypeName";
            cmbKeyType.ValueMember = "KeyTypeId";
        }
        private void GetKeyIs()
        {
            KeyGateway aGateway=new KeyGateway();
            List<KeyIss> keyIsses = aGateway.GetKeyIss();
            cmbKeyIs.DataSource = keyIsses;
            cmbKeyIs.DisplayMember = "KeyIs";
            cmbKeyIs.ValueMember = "KeyIsId";
        }
       
        private void Reset()
        {
            txtTerritoryId.Clear();
            txtTerritoryName.Clear();
            txtLocationId.Clear();
            txtLocationName.Clear();
            txtPropertyId.Clear();
            txtPropertyName.Clear();
            txtLockId.Clear();
            txtLockNo.Clear();
            cmbKeyType.SelectedIndex = -1;
            cmbKeyIs.SelectedIndex = -1;
            txtKeyNo.Clear();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPropertyName.Text))
            {
                MessageBox.Show("Please Select Property Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtLockNo.Text))
            {
                MessageBox.Show("Please enter Lock Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbKeyType.Text))
            {
                MessageBox.Show("Please Select Lock Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int ig = 0;
                KeyManager aManager = new KeyManager();
                Key aKey = new Key();
                aKey.KeyNo = Convert.ToInt32(txtKeyNo.Text);
                aKey.KeyTypeId = keyTypeId;
                aKey.KLockId = Convert.ToInt32(txtLockId.Text);
                aKey.KeyIsId = Convert.ToInt32(keyIsId);
                aKey.KUserId = Convert.ToInt32(nUserId);
                aKey.CreateddateTime=DateTime.Today;
                ig = aManager.SaveKey(aKey);
                MessageBox.Show("Suucessfully Saved", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // LoadKeyList();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KeyEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (nUserType == "COO")
            {
                this.Hide();
                MainUI frm = new MainUI();
                frm.Show();
            }
            if (nUserType == "TTM")
            {
                this.Hide();
                MainUIForTTM frm = new MainUIForTTM();
                frm.Show();
            }
            if (nUserType == "LIC")
            {
                this.Hide();
                MainUIForLIC frm = new MainUIForLIC();
                frm.Show();
            }

        }

        private void cmbKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKeyType.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input KeyType  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbKeyType.SelectedIndex = -1;
                }

                else
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select KeyTypeName from KeyType where KeyTypeName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This KeyType  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbKeyType.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into  KeyType(KeyTypeName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbKeyType.Items.Clear();
                            GetKeyType();
                            cmbKeyType.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT KeyTypeId from KeyType WHERE KeyTypeName= '" + cmbKeyType.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        keyTypeId = rdr.GetInt32(0);
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

        public void LoadLockOnSelectedProperty()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT Lock.LockId, Lock.LockNo, Property.PropertyName FROM  Lock INNER JOIN Property ON Lock.PropertyId = Property.PropertyId where Lock.PropertyId='" + propertyId + "'";
                cmd=new SqlCommand(query,con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView4.Rows.Clear();
                while (rdr.Read()==true)
                {
                    dataGridView4.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadPropertyOnSelectedLocation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Property.PropertyId, Users.FullName, Location.LocationName, Property.PropertyName FROM LocationIncharge INNER JOIN Location ON LocationIncharge.LocationId = Location.LocationId INNER JOIN Property ON Location.LocationId = Property.LocationId INNER JOIN Users ON LocationIncharge.UserId = Users.UserId where Location.LocationId='" + locationId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView3.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView3.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadLocation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Location.LocationId,Location.LocationName FROM  Location INNER JOIN Territory ON Location.TerritoryId = Territory.TerritoryId where Location.TerritoryId='" + territoryId + "'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
               territoryId=  txtTerritoryId.Text = dr.Cells[0].Value.ToString();
                txtTerritoryName.Text = dr.Cells[1].Value.ToString();
                LoadLocation();
                h = g;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView2.CurrentRow;
                locationId=  txtLocationId.Text = dr.Cells[0].Value.ToString();
                txtLocationName.Text = dr.Cells[1].Value.ToString();
                LoadPropertyOnSelectedLocation();
                a = b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView3.CurrentRow;
                propertyId=txtPropertyId.Text = dr.Cells[0].Value.ToString();
                txtPropertyName.Text = dr.Cells[1].Value.ToString();
                LoadLockOnSelectedProperty();
                h = g;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKeysOnSelectedLock()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT  Keys.KeyId, Property.PropertyName, Lock.LockNo, KeyType.KeyTypeName FROM  Keys INNER JOIN KeyType ON Keys.KeyTypeId = KeyType.KeyTypeId INNER JOIN Lock ON Keys.LockId = Lock.LockId INNER JOIN Property ON Lock.PropertyId = Property.PropertyId where Keys.LockId='" + lockId + "' ";
                cmd = new SqlCommand(query,con);
                rdr = cmd.ExecuteReader();
                dataGridView5.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView5.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView4.CurrentRow;
                 lockId= txtLockId.Text = dr.Cells[0].Value.ToString();
                txtLockNo.Text = dr.Cells[1].Value.ToString();
                LoadKeysOnSelectedLock();
                h = g;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbKeyIs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select RTRIM(KeyIs.KeyIsId) from KeyIs where  KeyIs.KeyIs='"+cmbKeyIs.Text+"'";
                cmd=new SqlCommand(query,con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    keyIsId = (rdr.GetString(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}
