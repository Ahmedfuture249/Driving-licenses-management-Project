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
    public partial class ReplaceForLostOrDamgedfrm: Form
    {
        private int LicenseID;
        private clsLicense License;
        public ReplaceForLostOrDamgedfrm()
        {
            InitializeComponent();
            ctrlShowLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlShowLicenseInfoWithFilter1.OnLicenseSelected += CtrlShowLicenseInfoWithFilter1_OnLicenseSelected;
        }

        private void CtrlShowLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            LicenseID = obj;


            if (LicenseID == -1)
            {
                MessageBox.Show("Error: License Was Not Founded ");
                return;
            }
            int DefaultValidityLength = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValdityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();

           
           
            lblOldLicenseID.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();


            //check the license is not Expired.
            if (!ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReplaceLicense.Enabled = false;
                return;
            }



            btnReplaceLicense.Enabled = true;


        }

        private void gpApplicationInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ReplaceForLostOrDamgedfrm_Load(object sender, EventArgs e)
        {

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;
            

            lblExpirationDate.Text = "???";
            if(rbDamgedLicense.Checked==true)
            lblApplicationFees.Text = clsManageApplications.Find((int)clsApplication.enApplicationType.ReplaceDamgedDrivingLicense).Fees.ToString();
            else
                lblApplicationFees.Text = clsManageApplications.Find((int)clsApplication.enApplicationType.ReplacedLostDrivingLicense).Fees.ToString();
          
            
            lblCreatedByUser.Text = ClsGloabalSettings.CurrentUser.UserName;
        }

        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            clsLicense NewLicense = new clsLicense();
            License = clsLicense.Find(LicenseID);

            License.IsActive = false;
            License.Save();

            if(rbDamgedLicense.Checked ==true)
               NewLicense.LicenseID = License.ReplaceForDamgedOrLost(clsApplication.enApplicationType.ReplaceDamgedDrivingLicense);
            else
               NewLicense.LicenseID = License.ReplaceForDamgedOrLost(clsApplication.enApplicationType.ReplaceDamgedDrivingLicense);

            
            if (NewLicense.LicenseID == -1)
            {
                MessageBox.Show("the process was not completed succsufully !!!");
                return;
            }

            NewLicense = clsLicense.Find(NewLicense.LicenseID);

            MessageBox.Show("License With ID = " + License.LicenseID + "Replacement Succesfully the new licnense ID Is = " + NewLicense.LicenseID);
            lblExpirationDate.Text = NewLicense.ExpirationDate.ToString();
            lblIssueDate.Text = NewLicense.IssueDate.ToString();
            lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            
        }

        private void rbDamgedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsManageApplications.Find((int)clsApplication.enApplicationType.ReplaceDamgedDrivingLicense).Fees.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsManageApplications.Find((int)clsApplication.enApplicationType.ReplacedLostDrivingLicense).Fees.ToString();
        }
    }
}
