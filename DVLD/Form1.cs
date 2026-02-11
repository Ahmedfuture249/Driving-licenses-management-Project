using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ManagePeoplefrm frm = new ManagePeoplefrm();
            //frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsersFrm frm = new ManageUsersFrm();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetailsfrm frm = new UserDetailsfrm(ClsGloabalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordfrm frm = new ChangePasswordfrm(ClsGloabalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGloabalSettings.CurrentUser = null;
            this.Close();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeoplefrm frm = new ManagePeoplefrm();
            frm.ShowDialog();
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationsTaypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypesfrm frm = new ManageApplicationTypesfrm();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypesfrm frm = new ManageTestTypesfrm();
            frm.ShowDialog();
        }

        private void newDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalDrivingLicensesApplicationfrm frm = new ManageLocalDrivingLicensesApplicationfrm();
            frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLoacalDrivingLicensesApplicationfrm frm = new AddLoacalDrivingLicensesApplicationfrm();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           RenewDrivingLicensefrm FRM = new RenewDrivingLicensefrm();
            FRM.ShowDialog();

        }
    }
}
