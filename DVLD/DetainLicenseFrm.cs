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
    public partial class DetainLicenseFrm: Form
    {
        int _LicenseID;
        public DetainLicenseFrm(int LicenseID)
        {
            _LicenseID= LicenseID;
            InitializeComponent();
            ctrlShowLicenseInfoWithFilter1.OnLicenseSelected += CtrlShowLicenseInfoWithFilter1_OnLicenseSelected;
        }

        private void CtrlShowLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
         _LicenseID= obj;
            if (_LicenseID == -1) 
            {
                MessageBox.Show("License Not Founded");
                return;
            }
            lblLicenseID.Text=_LicenseID.ToString();
            btnDetainLicense.Enabled = true;
           

            
        }

        private void gpApplicationInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlShowLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            
        }

        private void DetainLicenseFrm_Load(object sender, EventArgs e)
        {
            lblCreatedByUser.Text = ClsGloabalSettings.CurrentUser.UserName;
            if(_LicenseID== -1)
            {
                ctrlShowLicenseInfoWithFilter1.FilterEnabled = true;
                
            }

        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            clsDetainedLicenses detainedLicenses = new clsDetainedLicenses();
            detainedLicenses.LicenseID = _LicenseID;    
            detainedLicenses.DetainDate = DateTime.Now;
            detainedLicenses.ReleaseDate= DateTime.MaxValue;
            detainedLicenses.ReleasedByUserID = -1;
            detainedLicenses.ReleaseApplicationID = -1;
            detainedLicenses.CreatedByUserID = ClsGloabalSettings.CurrentUser.UserID;
            detainedLicenses.FineFees =decimal.Parse( textBox1.Text);
            detainedLicenses.IsReleased = false; 
            if(!detainedLicenses.DetainLicense())
            {
                MessageBox.Show("License Was Not Detained !!");
                return;
            }
            lblDetainDate.Text=detainedLicenses.DetainDate.ToShortDateString();
            lblDetainID.Text=detainedLicenses.DetainID.ToString();
            MessageBox.Show("Licese with ID " + _LicenseID + "Detained Succesfully The Detain ID " + detainedLicenses.DetainID);
            
                
        }
    }
}
