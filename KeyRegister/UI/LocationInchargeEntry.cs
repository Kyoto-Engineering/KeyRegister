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
    public partial class LocationInchargeEntry : Form
    {
        public string lUserId;
        public LocationInchargeEntry()
        {
            InitializeComponent();
        }

        private void  SaveLocationInCharge()
        {
            int mgs;
            LocationInChargeManager aManager = new LocationInChargeManager();
            LocationInCharges aLocationInCharges = new LocationInCharges();
            aLocationInCharges.LIName = cmbLocationInCharge.Text;
            aLocationInCharges.LUserId = lUserId;
            aLocationInCharges.AssignDate = dateOfAssignDate.Text;
           mgs = aManager.SaveLocationInCharge(aLocationInCharges);
            


        }
        private void createButton_Click(object sender, EventArgs e)
        {
            SaveLocationInCharge();

        }

        private void LocationInchargeEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
