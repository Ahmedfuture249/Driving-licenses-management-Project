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
    public partial class ctrlTakeTest: UserControl
    {
        public static clsTestAppointment TestAppointment;
        public int TestAppointmentID;
        public ctrlTakeTest()
        {
            InitializeComponent();
        }
        public  void LoadData(int TestAppointmentID)
        {
            TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            if(TestAppointment==null)
            {
                MessageBox.Show("Appointment Was Not Founded !!");
                return;
            }


            _FillData();

        }
        private   void _FillData()
        {
            switch (TestAppointment.TestTypeID)
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
            lblApplicant.Text = TestAppointment.LocalDrivingLicenseApplication.ApplicantPersonlID.ToString();
            lblAppliedForLicense.Text = TestAppointment.LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblDLApplicationID.Text = TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblFees.Text = TestAppointment.TestType.Fees.ToString(); 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ctrlTakeTest_Load(object sender, EventArgs e)
        {

        }
    }
}
