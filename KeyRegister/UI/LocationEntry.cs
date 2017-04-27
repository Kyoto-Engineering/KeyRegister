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
using KeyRegister.Manager;

namespace KeyRegister.UI
{
    public partial class LocationEntry : Form
    {
        public string userId,lTerriToryId;
        public LocationEntry()
        {
            InitializeComponent();
        }

        private void   SaveLocation()
        {
            int mgs;
            LocationManager aManager=new LocationManager();
            Locations aLocation = new Locations();
            aLocation.LocationName = txtLocation.Text;
            aLocation.LUserId = Convert.ToInt32(userId);
            aLocation.CreateddateTime=DateTime.Today;
            aLocation.LTerritoryId = Convert.ToInt32(lTerriToryId);
            mgs= aManager.SaveLocation(aLocation);
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            SaveLocation();
        }

        private void LocationEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
