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
    
    
    public partial class ReleaseDetainedLicensefrm: Form
    {
        int LicenseID = -1; 
        clsLicense License;
        clsDetainedLicenses DetainedLicense;


        public ReleaseDetainedLicensefrm()

        {

           

            InitializeComponent();
            ctrlShowLicenseInfoWithFilter1.OnLicenseSelected += ctrlShowLicenseInfoWithFilter1_OnLicenseSelected;
            btnRelease.Enabled = true;
            ctrlShowLicenseInfoWithFilter1.FilterEnabled = true;

        }
        private void LoadData()
        {
            btnRelease.Enabled = true;
            
            lblLicenseID.Text = LicenseID.ToString();    
            lblDetainID.Text = DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = DetainedLicense.DetainDate.ToShortDateString();
            lblFineFees.Text = DetainedLicense.FineFees.ToString();
            lblCreatedByUser.Text =DetainedLicense.CreatedByUserID.ToString();
            lblApplicationFees.Text=clsManageApplications.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicens).Fees.ToString();
           


        }

        private void ctrlShowLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            LicenseID = obj;
           License= clsLicense.Find(LicenseID);
            if (License == null)
            {
                MessageBox.Show("License Was Not Founded");
                return;
            }
            if(!clsDetainedLicenses.IsLicenseDetained(LicenseID))
            {
                MessageBox.Show("Sorry License Is Not Detained !!");
                return;
            }
            DetainedLicense=clsDetainedLicenses.Find(LicenseID);
            LoadData();

        }

        private void ctrlShowLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
         if( ! DetainedLicense.ReleaseLicense())

            {
                MessageBox.Show("License  Was Not Released Successfully");
                return;
            }

            MessageBox.Show("License  Was Released Successfully");
            lblApplicationID.Text= DetainedLicense.ReleaseApplicationID.ToString();
            btnRelease.Enabled = false;
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString() ;
        }

        private void gpDetain_Enter(object sender, EventArgs e)
        {

        }
    }
}
