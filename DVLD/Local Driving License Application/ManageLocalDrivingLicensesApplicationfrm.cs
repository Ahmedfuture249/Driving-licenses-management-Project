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

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueLicense frm = new IssueLicense((int)dgvGetAllApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvGetAllApplications.CurrentRow.Cells[0].Value;
            clsLDLApplication LocalDrivingLicenseApplication =
                    clsLDLApplication.FindLocalDrivingLicenseApplication
                                                    (LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvGetAllApplications.CurrentRow.Cells[5].Value;

            //  bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3);// && !LicenseExists;

          //  showLicenseToolStripMenuItem.Enabled = LicenseExists;
          // editToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
          // ScheduleTestsMenue.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            //  CancelApplicaitonToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            //  DeleteApplicationToolStripMenuItem.Enabled =
            // (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);



            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = clsLDLApplication.DoesPassTestType(LocalDrivingLicenseApplicationID, 1); ;
            bool PassedWrittenTest = clsLDLApplication.DoesPassTestType(LocalDrivingLicenseApplicationID, 2);
            bool PassedStreetTest = clsLDLApplication.DoesPassTestType(LocalDrivingLicenseApplicationID, 3);

            //  ScheduleTestsMenue.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //if (ScheduleTestsMenue.Enabled)
            //{
            //To Allow Schdule vision test, Person must not passed the same test before.
            visionTestToolStripMenuItem.Enabled = !PassedVisionTest;

            //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
            writtenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

            //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
            streetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            //}


        }
    }
}
