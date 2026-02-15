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
using DVLD.Properties;

namespace DVLD
{
    public partial class ctrlShowLicenseInof: UserControl
    {
        private static int _LocalDrivingLicenseApplicationID;
        private static clsLDLApplication _LocalDrivingLicenseApplication;
        clsDetainedLicenses DetainedLicense;

        public clsLicense License { set; get; }
        public int LicenseID { get; private set; }
        public ctrlShowLicenseInof()
        {
            
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        public void LoadData(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);
         
            License = clsLicense.FindByApplicationID(_LocalDrivingLicenseApplication.ApplicationID);
            LicenseID=License.LicenseID;
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: Application Was Not Founded ");
                return;
            }
            if (License == null)
            {
                MessageBox.Show("Error: License Was Not Founded ");
                return;
            }

            lblclass.Text = License.LicenseClassInfo.ClassName;
            lblname.Text = _LocalDrivingLicenseApplication.FullName;
            lbllicenseid.Text = License.LicenseID.ToString();
            lblnationalno.Text = _LocalDrivingLicenseApplication.personInfo.NationalNo;
            lblgendor.Text = _LocalDrivingLicenseApplication.personInfo.Gendor == 0 ? "male" : "female";
            //pictureBoxPerosnimage.Image = _LocalDrivingLicenseApplication.personInfo.ImagePath != null ? Image.FromStream(new System.IO.MemoryStream(_LocalDrivingLicenseApplication.personInfo.PersonImage)) : null;
            lblissuedate.Text = License.IssueDate.ToShortDateString();
            lblissuereason.Text = License.IssueReason.ToString();
            lblnotes.Text = License.Notes;
            lblexpirationdate.Text = License.ExpirationDate.ToShortDateString();
            lblisactive.Text = License.IsActive ? "Active" : "Not Active";
            lbldateofbirth.Text = _LocalDrivingLicenseApplication.personInfo.DateOfBirth.ToShortDateString();
            lbldriverID.Text = License.DriverID.ToString();
            if(_LocalDrivingLicenseApplication.personInfo.Gendor==0)
            {
                pictureBoxPerosnimage.Image= Resources.Male_512;
            }
            else
                pictureBoxPerosnimage.Image = Resources.Female_512;
            //lblisdetained.Text = _LocalDrivingLicenseApplication.IsDetained ? "Yes" : "No";

        }
        public void LoadDataByLicenseID(int LicenseID)
        {
            
            License = clsLicense.Find(LicenseID);
            this.LicenseID = LicenseID;
            
            if (License == null)
            {
                MessageBox.Show("Error: License Was Not Founded ");
                return;
            }

            lblclass.Text = License.LicenseClassInfo.ClassName;
            lblname.Text = License.LDLApplication.personInfo.FullName;
            lbllicenseid.Text = License.LicenseID.ToString();
            lblnationalno.Text = License.LDLApplication.personInfo.NationalNo;
            lblgendor.Text = License.LDLApplication.personInfo.Gendor == 0 ? "male" : "female";
            //pictureBoxPerosnimage.Image = _LocalDrivingLicenseApplication.personInfo.ImagePath != null ? Image.FromStream(new System.IO.MemoryStream(_LocalDrivingLicenseApplication.personInfo.PersonImage)) : null;
            lblissuedate.Text = License.IssueDate.ToShortDateString();
            lblissuereason.Text = License.IssueReason.ToString();
            lblnotes.Text = License.Notes;
            lblexpirationdate.Text = License.ExpirationDate.ToShortDateString();
            lblisactive.Text = License.IsActive ? "Active" : "Not Active";
            lbldateofbirth.Text = License.LDLApplication.personInfo.DateOfBirth.ToShortDateString();
            lbldriverID.Text = License.DriverID.ToString();
            if (License.LDLApplication.personInfo.Gendor == 0)
            {
                pictureBoxPerosnimage.Image = Resources.Male_512;
            }
            else
                pictureBoxPerosnimage.Image = Resources.Female_512;


            DetainedLicense = clsDetainedLicenses.Find(LicenseID);
           
           
            lblisdetained.Text = DetainedLicense.IsReleased == false ? "yes" : "NO";

        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void ctrlShowLicenseInof_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
