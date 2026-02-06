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
    public partial class ManageTestAppointmentsfrm: Form
    {
       static int LocalDrivingLicenseApplicationID;
        public int TestTypeID { set; get; }
        static clsTestAppointment appointment = clsTestAppointment.FindByLDLApp(LocalDrivingLicenseApplicationID);
       
        public ManageTestAppointmentsfrm(int TestTypeID, int ID)
        {
            InitializeComponent();
            LocalDrivingLicenseApplicationID=ctrlDrivingLicenseApplicationInfocs1.LocalDrivingLicenseApplicationID = ID;
            this.TestTypeID = TestTypeID;
            
            ctrlDrivingLicenseApplicationInfocs1._LoadApplicationInfo(LocalDrivingLicenseApplicationID);
            switch(this.TestTypeID)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    lblTitle.Text = "Vision Test Appointment ";
                    
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.Written_Test_512;
                    lblTitle.Text = "Written Test Appointment ";
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.driving_test_512;
                    lblTitle.Text = "Driving Test Appointment ";
                    break;
                default:
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    break;

            }
            
        }
        
        private void _RefreshList()
        {
            dgvGetAllAppointments.DataSource = clsTestAppointment.ListTestAppointments(LocalDrivingLicenseApplicationID,TestTypeID);
        }
       
        private void ManageTestAppointmentsfrm_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void btnAddNeAppointment_Click(object sender, EventArgs e)
        {
           if( clsTestAppointment.IsApplicantHasAnActiveAppointmentForThisTest(LocalDrivingLicenseApplicationID, TestTypeID))
            {
              
                MessageBox.Show("this person already sat for this test");
                return;
            }
           
            ScheduleTestfrm frm = new ScheduleTestfrm(TestTypeID, LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsTestAppointment.IsApplicantAlreadySatForThisTestAndPass(LocalDrivingLicenseApplicationID, TestTypeID))
            {
                MessageBox.Show("this peroson already Pass this test Move to the Next Test");
                return;
            }
           
            int i = (int)dgvGetAllAppointments.CurrentRow.Cells[0].Value;
            TakeTestfrm frm = new TakeTestfrm(i);
            frm.ShowDialog();
            _RefreshList();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
