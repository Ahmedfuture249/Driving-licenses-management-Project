using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;

namespace DVLD
{
    public partial class ctrlScheduleTest: UserControl
    {
       clsLDLApplication  _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID;
        clsTestAppointment Appointment;
        public enum enMode { AddNew=0,Update=1};
        enMode Mode = enMode.AddNew;
        public int TestTypeID { set; get; }
        public clsTestTypes TestType;
        public ctrlScheduleTest()
        {
            InitializeComponent();
           
        }
        public void LoadData(int ID)
        {
            _LocalDrivingLicenseApplicationID = ID;
            _LocalDrivingLicenseApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application Founded !!!");
                return;
            }
            TestType = clsTestTypes.Find(TestTypeID);
           


            _ShowApplicationInfo();
        }
        private void _ShowApplicationInfo()
        {
            switch (TestTypeID)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    lbltitle.Text = "Vision Test Appointment ";

                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.Written_Test_512;
                    lbltitle.Text = "Written Test Appointment ";
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.driving_test_512;
                    lbltitle.Text = "Driving Test Appointment ";
                    break;
                default:
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    break;

            }
            lblApplicant.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblAppliedForLicense.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblDLApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblFees.Text = TestType.Fees.ToString();

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            Appointment = new clsTestAppointment();



            Appointment.AppointmentDate = dateTimePicker1.Value;
            Appointment.CreatedByUserID = ClsGloabalSettings.CurrentUser.UserID;
            Appointment.PaidFees = TestType.Fees;
            Appointment.LocalDrivingLicenseApplicationID = int.Parse(lblDLApplicationID.Text);
            Appointment.TestTypeID = TestTypeID;
            Appointment.IsLocked = false;

            if(Appointment.Save())
            {
                MessageBox.Show("Appointment Saved Succesfuly!!");

            }
            else
            {
                MessageBox.Show("Error Data Was Not Saved!!");
            }

        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {

        }
    }
}
