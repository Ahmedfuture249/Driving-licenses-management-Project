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
    public partial class RenewDrivingLicensefrm: Form
    {
       public int LicenseID=-1;
       public clsLicense License;
        clsApplication Application;
        
     
        public RenewDrivingLicensefrm()
        {
            InitializeComponent();
            ctrlShowLicenseInfoWithFilter1.FilterEnabled = true;
            ctrlShowLicenseInfoWithFilter1.OnLicenseSelected += ctrlShowLicenseInfoWithFilter1_OnLicenseSelected;

        }
        private void ctrlShowLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            LicenseID = obj;
            

            if (LicenseID==-1)
            {
                MessageBox.Show("Error: License Was Not Founded ");
                return;
            }
            int DefaultValidityLength = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValdityLength;
            lblExpirationDate.Text =DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();

            lblLicenseFees.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;
            lblOldLicenseID.Text = ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();

            if (!ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + (ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate).ToShortDateString()
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }

            //check the license is not Expired.
            if (!ctrlShowLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }



            btnRenewLicense.Enabled = true;


        }



        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void ctrlShowLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

            


        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            clsLicense NewLicense=new clsLicense();
            License = clsLicense.Find(LicenseID);
         NewLicense.LicenseID= License.RenewLicense(txtNotes.Text,ClsGloabalSettings.CurrentUser.UserID);
            if (NewLicense.LicenseID == -1)
            {
                MessageBox.Show("the process was not completed succsufully !!!");
                return;
            }

            NewLicense=clsLicense.Find(NewLicense.LicenseID);

            MessageBox.Show("License With ID = " + License.LicenseID +"Renewed Succesfully the new licnense ID Is = " + NewLicense.LicenseID);
            lblExpirationDate.Text= NewLicense.ExpirationDate.ToString();
            lblIssueDate.Text=NewLicense.IssueDate.ToString();
            lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            

        }

        private void RenewDrivingLicensefrm_Load(object sender, EventArgs e)
        {

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsManageApplications.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedByUser.Text = ClsGloabalSettings.CurrentUser.UserName;
        }
    }
}
