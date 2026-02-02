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
    public partial class ctrlDrivingLicenseApplicationInfocs: UserControl
    {
       int  _localDrivingLicenseApplicatinID=-1;
        clsLDLApplication _LocalDrivingLicenseApplicatin;
        public int LocalDrivingLicenseApplicationID { get { return _localDrivingLicenseApplicatinID; } 
        }
        int _LicenseID;

        public ctrlDrivingLicenseApplicationInfocs()
        {
            InitializeComponent();
        }
        public  void _LoadApplicationInfo(int ID)
        {
            _localDrivingLicenseApplicatinID = ID;
          _LocalDrivingLicenseApplicatin=  clsLDLApplication.FindLocalDrivingLicenseApplication(_localDrivingLicenseApplicatinID);
            if(_LocalDrivingLicenseApplicatin==null)
            {
                MessageBox.Show("No Application Founded !!!");
                return;
            }
            _ShowApplicationInfo();
        }
        private void _ShowApplicationInfo()
        {
            lbDLApplicationID.Text = _LocalDrivingLicenseApplicatin.LocalDrivingLicensApplicationID.ToString();
            lblApplicant.Text = _LocalDrivingLicenseApplicatin.ApplicantPersonlID.ToString();
            lblAppliedForLicense.Text = _LocalDrivingLicenseApplicatin.LicenseClassInfo.ClassName.ToString();
            lblCreatedBy.Text = _LocalDrivingLicenseApplicatin.CreatedByUserInfo.UserName;
            
            lblFees.Text = _LocalDrivingLicenseApplicatin.PaidFees.ToString();
            lblID.Text = _LocalDrivingLicenseApplicatin.ApplicationID.ToString();
            lblPassedTests.Text = "0";
            lblstatus.Text = _LocalDrivingLicenseApplicatin.StatusText();
            lblStatusDate.Text = _LocalDrivingLicenseApplicatin.ApplicationLastStatusDate.ToString();
            lblType.Text = _LocalDrivingLicenseApplicatin.ApplicationTypeInfo.Title.ToString();
            lblDate.Text = _LocalDrivingLicenseApplicatin.ApplicationDate.ToString();
           
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void ctrlDrivingLicenseApplicationInfocs_Load(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblviewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void lblCreatedBy_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void lblStatusDate_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click_1(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
