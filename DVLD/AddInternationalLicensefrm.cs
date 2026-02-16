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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class AddInternationalLicensefrm: Form
    {
        private int _LicenseID;
        private clsLicense _License;
        private clsInternationalLicenses _InternationalLicenses=new clsInternationalLicenses();
        private clsDriver Driver;
       
        public AddInternationalLicensefrm()
        {
            InitializeComponent();
            ctrlShowLicenseInfoWithFilter1.OnLicenseSelected += CtrlShowLicenseInfoWithFilter1_OnLicenseSelected;
            ctrlShowLicenseInfoWithFilter1.FilterEnabled = true;
        }

        private void CtrlShowLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
           _LicenseID = obj;
            _License=clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("License Was Not Founded !!");
                return;
            }
            btnIssueInternationalLicense.Enabled = true;

            Driver = clsDriver.Find(_License.DriverID);
            lblLocalLicenseID.Text = _LicenseID.ToString();
            lblFees.Text = clsManageApplications.Find((int)clsApplication.enApplicationType.NewInternationalLicens).Fees.ToString();
            lblCreatedByUser.Text=ClsGloabalSettings.CurrentUser.UserName;  


        }

        private void ctrlShowLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            if(_License.LicenseClassID!=3)
            {
                MessageBox.Show("You Must Have An Ordinary License First To issue International License!!");
                return;
            }

   

            _InternationalLicenses.DriverID = _License.DriverID;
            _InternationalLicenses.IssuedUsingLocalLicenseID = _LicenseID;
            _InternationalLicenses.License = _License;
            _InternationalLicenses.IssueDate= DateTime.Now;
            _InternationalLicenses.ExpirationDate = DateTime.Now.AddYears(10);
            _InternationalLicenses.IsActive= true;
            _InternationalLicenses.CreatedByUserID = ClsGloabalSettings.CurrentUser.UserID;
            if(! _InternationalLicenses.IssueInternatonalLicense())
            {
                MessageBox.Show("License was not issued");
                return;

            }
            _InternationalLicenses = clsInternationalLicenses.Find(_InternationalLicenses.InternationalLicenseID);
            MessageBox.Show("New International License Issued Successguly The ID Is " + _InternationalLicenses.InternationalLicenseID);
           lblApplicationDate.Text=_InternationalLicenses.Application.ApplicationDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicenses.ApplicationID.ToString();
            lblExpirationDate.Text=_InternationalLicenses.ExpirationDate.ToShortDateString();
            lblInternationalLicenseID.Text=_InternationalLicenses.InternationalLicenseID.ToString();
            lblIssueDate.Text=_InternationalLicenses.IssueDate.ToShortDateString(); 
            

        }
    }
}
