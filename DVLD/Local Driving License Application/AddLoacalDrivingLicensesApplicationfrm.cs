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
    public partial class AddLoacalDrivingLicensesApplicationfrm: Form
    {
        public enum enMode { AddNew=0,Update=1};
        enMode Mode = enMode.AddNew;
        int _SelectedPersonID;
        int _LocalDrivingLicenseApplicationID;
        clsLDLApplication _LocalDrivingLicenseApplication;
        
        public AddLoacalDrivingLicensesApplicationfrm()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            
        }
        public AddLoacalDrivingLicensesApplicationfrm(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;

        }
        private void _ResetDefaultValues()
        {
            _FillLicensClassesInComoboBox();
            if(Mode==enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving Licens Application";
                this.Text = "New Local Driving Licens Application";
                _LocalDrivingLicenseApplication = new clsLDLApplication();
                //tabApplicationInfo.Enabled = false;

                comboBoxLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsManageApplications.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToString();
                lblCreatedBy.Text = ClsGloabalSettings.CurrentUser.UserName.ToString();

            }
            else
            {

                lblTitle.Text = "Update Local Driving Licens Application";
                this.Text = "Update Loca lDriving Licens Application";
                tabApplicationInfo.Enabled = true;
            }
        }
        private void _FillLicensClassesInComoboBox()
        {
            DataTable dtLicensClasses = clsLicenseClasses.ListLicenseClasses();

            foreach (DataRow row in dtLicensClasses.Rows)
            {

                comboBoxLicenseClass.Items.Add(row["ClassName"]);

            }

        }
        private void _LoadData()
        {
            _LocalDrivingLicenseApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication==null)
            {
                MessageBox.Show("No Application With ID = " + _LocalDrivingLicenseApplicationID);
                this.Close();
                return;
            }
            userControl22.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonlID);
            lblDLApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToString();
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo.UserName;
           // comboBoxLicenseClass.SelectedIndex = clsLicenseClasses.Find(_LocalDrivingLicenseApplication.);

        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void lblMode_Click(object sender, EventArgs e)
        {

        }

        private void AddLoacalDrivingLicensesApplicationfrm_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
          if(Mode==enMode.Update)
            {
                _LoadData();
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClasses.Find(comboBoxLicenseClass.Text).LicenseClassID;
            int ActiveApplicationID = clsApplication.GetActiveApplicationForLicenseClass(_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);
            if(ActiveApplicationID!=-1)
            {
                MessageBox.Show("choose Another Licens Class");
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonlID = userControl22.personID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.CreatedByUserID = ClsGloabalSettings.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.PaidFees = decimal.Parse(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.LicenseClass = LicenseClassID;
            _LocalDrivingLicenseApplication.ApplicationLastStatusDate = DateTime.Now;

            if(_LocalDrivingLicenseApplication.Save())
            {
                lblDLApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();

                Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("data saved successfuly", "saved", MessageBoxButtons.OK);

            }
            else
                MessageBox.Show("Error: data was not saved successfuly", "error", MessageBoxButtons.OK);

        }

        private void userControl22_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void tabPagePersonInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}
