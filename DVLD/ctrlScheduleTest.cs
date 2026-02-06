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
        int _TestAppointmentID = -1;

        enum enCrationMode { FirstTimeShedule=0,RetakeTestShedule=1};
        enCrationMode crationMode;
        public ctrlScheduleTest()
        {
            InitializeComponent();
           
        }
        public void LoadData(int LocalDrivingLicenseApplicationID,int AppointmentID=-1)
        {
            if(AppointmentID==-1)
                Mode = enMode.AddNew;
            else
                Mode = enMode.Update;

            _TestAppointmentID = AppointmentID;
                _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application Founded !!!");
                btnSave.Enabled = false;
                return;
            }
            TestType = clsTestTypes.Find(TestTypeID);
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_LocalDrivingLicenseApplicationID, TestTypeID))
                crationMode = enCrationMode.RetakeTestShedule;
            else
                crationMode = enCrationMode.FirstTimeShedule;

            if (crationMode == enCrationMode.RetakeTestShedule)
            {
                gbRetakeTestInfo.Enabled = true;
                lblretakeTestappFees.Text=clsManageApplications.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                lblRetakeTest.Text = "Schedule RetakeTest";
                lblRetakeTestAppointmentID.Text = "0";


            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblretakeTestappFees.Text = "0";
                lblRetakeTest.Text = "Schedule Test";
                lblRetakeTestAppointmentID.Text = "N/A";
            }

            lblDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicensApplicationID.ToString();
            lblAppliedForLicense.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblApplicant.Text = _LocalDrivingLicenseApplication.FullName;

            //this will show the trials for this test before  
           


            _ShowApplicationInfo();
            lblTrail.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(TestTypeID).ToString();
            if(Mode==enMode.AddNew)
            {
                lblFees.Text = clsTestTypes.Find(TestTypeID).Fees.ToString();
                dateTimePicker1.MinDate=DateTime.Now;
                lblRetakeTestAppointmentID.Text= "N/A";
                Appointment=new clsTestAppointment();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblretakeTestappFees.Text)).ToString();


            //if (!_HandleActiveTestAppointmentConstraint())
            //    return;

            //if (!_HandleAppointmentLockedConstraint())
            //    return;

            //if (!_HandlePrviousTestConstraint())
                return;



        }
        //private bool _HandleActiveTestAppointmentConstraint()
        //{
        //    if (Mode == enMode.AddNew && clsLDLApplication.(_LocalDrivingLicenseApplicationID, _TestTypeID))
        //    {
        //        lblUserMessage.Text = "Person Already have an active appointment for this test";
        //        btnSave.Enabled = false;
        //        dtpTestDate.Enabled = false;
        //        return false;
        //    }

        //    return true;
        //}
        //private bool _LoadTestAppointmentData()
        //{
        //    _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

        //    if (_TestAppointment == null)
        //    {
        //        MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
        //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        btnSave.Enabled = false;
        //        return false;
        //    }

        //    lblFees.Text = _TestAppointment.PaidFees.ToString();

        //    //we compare the current date with the appointment date to set the min date.
        //    if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
        //        dtpTestDate.MinDate = DateTime.Now;
        //    else
        //        dtpTestDate.MinDate = _TestAppointment.AppointmentDate;

        //    dtpTestDate.Value = _TestAppointment.AppointmentDate;

        //    if (_TestAppointment.RetakeTestApplicationID == -1)
        //    {
        //        lblRetakeAppFees.Text = "0";
        //        lblRetakeTestAppID.Text = "N/A";
        //    }
        //    else
        //    {
        //        lblRetakeAppFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
        //        gbRetakeTestInfo.Enabled = true;
        //        lblTitle.Text = "Schedule Retake Test";
        //        lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

        //    }
        //    return true;
        //}
        //private bool _HandleAppointmentLockedConstraint()
        //{
        //    //if appointment is locked that means the person already sat for this test
        //    //we cannot update locked appointment
        //    if (_TestAppointment.IsLocked)
        //    {
        //        lblUserMessage.Visible = true;
        //        lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
        //        dtpTestDate.Enabled = false;
        //        btnSave.Enabled = false;
        //        return false;

        //    }
        //    else
        //        lblUserMessage.Visible = false;

        //    return true;
        //}
        //private bool _HandlePrviousTestConstraint()
        //{
        //    //we need to make sure that this person passed the prvious required test before apply to the new test.
        //    //person cannno apply for written test unless s/he passes the vision test.
        //    //person cannot apply for street test unless s/he passes the written test.

        //    switch (TestTypeID)
        //    {
        //        case clsTestType.enTestType.VisionTest:
        //            //in this case no required prvious test to pass.
        //            lblUserMessage.Visible = false;

        //            return true;

        //        case clsTestType.enTestType.WrittenTest:
        //            //Written Test, you cannot sechdule it before person passes the vision test.
        //            //we check if pass visiontest 1.
        //            if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
        //            {
        //                lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
        //                lblUserMessage.Visible = true;
        //                btnSave.Enabled = false;
        //                dtpTestDate.Enabled = false;
        //                return false;
        //            }
        //            else
        //            {
        //                lblUserMessage.Visible = false;
        //                btnSave.Enabled = true;
        //                dtpTestDate.Enabled = true;
        //            }


        //            return true;

        //        case clsTestType.enTestType.StreetTest:

        //            //Street Test, you cannot sechdule it before person passes the written test.
        //            //we check if pass Written 2.
        //            if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
        //            {
        //                lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
        //                lblUserMessage.Visible = true;
        //                btnSave.Enabled = false;
        //                dtpTestDate.Enabled = false;
        //                return false;
        //            }
        //            else
        //            {
        //                lblUserMessage.Visible = false;
        //                btnSave.Enabled = true;
        //                dtpTestDate.Enabled = true;
        //            }


        //            return true;

        //    }
        //    return true;

        //}
        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (Mode == enMode.AddNew && crationMode == enCrationMode.RetakeTestShedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplication Application = new clsApplication();

                Application.ApplicantPersonlID = _LocalDrivingLicenseApplication.ApplicantPersonlID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.ApplicationLastStatusDate = DateTime.Now;
                Application.PaidFees = clsManageApplications.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;
                Application.CreatedByUserID = ClsGloabalSettings.CurrentUser.UserID;

                if (!Application.Save())
                {
                   Appointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Appointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }
        
        private bool _LoadTestAppointmentData()
        {
            Appointment = clsTestAppointment.Find(_TestAppointmentID);
            if (Appointment == null)
            {
                MessageBox.Show("Error: No Test Appointment with ID = " + _TestAppointmentID);
                btnSave.Enabled = false;
                return false;
            }
            lblFees.Text=Appointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, Appointment.AppointmentDate) < 0)
            {
                dateTimePicker1.MinDate = DateTime.Now;

            }
            else
                dateTimePicker1.MinDate = Appointment.AppointmentDate;
            dateTimePicker1.Value=Appointment.AppointmentDate;

            if(Appointment.RetakeTestApplicationID==-1)
            {
                lblretakeTestappFees.Text = "0";
                lblRetakeTestAppointmentID.Text = "N/A";
            }
            else
            {
                gbRetakeTestInfo.Enabled = true;
                lblretakeTestappFees.Text = Appointment.RetakeTestAppInfo.PaidFees.ToString();
                lblRetakeTest.Text = "Schedule RetakeTest";
                lblRetakeTestAppointmentID.Text = Appointment.RetakeTestAppInfo.ApplicationID.ToString();
            }
            return true;
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
            

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            


            if (!_HandleRetakeApplication())
                return;

            Appointment.TestTypeID = TestTypeID;
            Appointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicensApplicationID;
            Appointment.AppointmentDate = dateTimePicker1.Value;
            Appointment.PaidFees = decimal.Parse(lblFees.Text);
            Appointment.CreatedByUserID =ClsGloabalSettings.CurrentUser.UserID;

            if (Appointment.Save())
            {
                Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {
              
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
