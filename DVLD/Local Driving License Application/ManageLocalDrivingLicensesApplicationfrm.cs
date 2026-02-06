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
    public partial class ManageLocalDrivingLicensesApplicationfrm: Form
    {
        public ManageLocalDrivingLicensesApplicationfrm()
        {
            InitializeComponent();


            
        }
        private void _RefreshList()
        {
            dgvGetAllApplications.DataSource = clsLDLApplication.ListApplications();
        }

        private void dgvGetAllPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageLocalDrivingLicensesApplicationfrm_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLoacalDrivingLicensesApplicationfrm frm = new AddLoacalDrivingLicensesApplicationfrm((int)dgvGetAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }

        private void deleteApplicatonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvGetAllApplications.CurrentRow.Cells[0].Value;
            
            clsLDLApplication.DeleteLocalDrivingLicenseApplication(ID);
            _RefreshList();  
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ID = (int)dgvGetAllApplications.CurrentRow.Cells[0].Value;
            clsLDLApplication Application = clsLDLApplication.FindLocalDrivingLicenseApplication(ID);
            ID = Application.ApplicationID;
            clsLDLApplication.Cancel(ID);
            _RefreshList();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddLoacalDrivingLicensesApplicationfrm frm = new AddLoacalDrivingLicensesApplicationfrm();
            frm.ShowDialog();
            _RefreshList();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void showApplicationDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvGetAllApplications.CurrentRow.Cells[0].Value;
            ShowApplicationInfofrm frm = new ShowApplicationInfofrm(ID);
            frm.ShowDialog();
        }

        private void sheduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int ID = (int)dgvGetAllApplications.CurrentRow.Cells[0].Value;
            //ManageTestAppointmentsfrm frm = new ManageTestAppointmentsfrm(ID);
            //frm.ShowDialog();
        }
        private void toolStripMenuItemVisionTest_Click(object sender, EventArgs e)
        {
            //AddLoacalDrivingLicensesApplicationfrm frm = new AddLoacalDrivingLicensesApplicationfrm();
            //frm.ShowDialog();
            //_RefreshList();
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestAppointmentsfrm frm =new  ManageTestAppointmentsfrm(1, (int)dgvGetAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
      
       

        private void shduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestAppointmentsfrm frm = new ManageTestAppointmentsfrm(2, (int)dgvGetAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestAppointmentsfrm frm = new ManageTestAppointmentsfrm(3, (int)dgvGetAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
