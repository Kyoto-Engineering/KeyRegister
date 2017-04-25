﻿using System;
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
    public partial class MainUI : Form
    {
        public string userTypeM;
        public MainUI()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                    this.Hide();
            CompanyEntry frm =new CompanyEntry();
                    frm.Show();
        }

        private void buttonChiefOOS_Click(object sender, EventArgs e)
        {
                this.Hide();
            COO  frm=new COO();
                frm.Show();
        }

        private void buttonTerrytoryCreation_Click(object sender, EventArgs e)
        {
                        this.Hide();
            TerritoryEntry frm=new TerritoryEntry();
                       frm.Show();
        }

        private void buttonLocationCreation_Click(object sender, EventArgs e)
        {
                       this.Hide();
            LocationEntry frm=new LocationEntry();
                      frm.Show();
        }

        private void buttonLocationInCharge_Click(object sender, EventArgs e)
        {
                              this.Hide();
            LocationInchargeEntry frm=new LocationInchargeEntry();
                              frm.Show();
        }

        private void buttonKeyHolderStation_Click(object sender, EventArgs e)
        {
                       this.Hide();
            KeyHolderEntry frm=new KeyHolderEntry();
                       frm.Show();
        }

        private void buttonLockCreation_Click(object sender, EventArgs e)
        {
                  this.Hide();
            LockEntry frm=new LockEntry();
                  frm.Show();
        }

        private void buttonPropertyCreation_Click(object sender, EventArgs e)
        {
            this.Hide();
            PropertyEntry frm = new PropertyEntry();
            frm.Show();
        }

        private void buttonKeyCreation_Click(object sender, EventArgs e)
        {
                 this.Hide();
            KeyEntry frm = new KeyEntry();
                  frm.Show();
        }

        private void buttonKeyAllocation_Click(object sender, EventArgs e)
        {
                         this.Hide();
            KeyAllocationEntry frm = new KeyAllocationEntry();
                          frm.Show();
        }

        private void userManagementButton_Click(object sender, EventArgs e)
        {
                        this.Hide();
            UserManagementUI frm = new UserManagementUI();
                       frm.Show();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            userTypeM = frmLogin.userType;
        }
    }
}
