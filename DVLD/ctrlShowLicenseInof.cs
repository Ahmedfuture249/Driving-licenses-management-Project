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
    public partial class ctrlShowLicenseInof: UserControl
    {
           private static int _LocalDrivingLicenseApplicationID;
        private static clsLDLApplication _LocalDrivingLicenseApplication;
         
        private static clsLicense License;
        public ctrlShowLicenseInof(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);
            License = clsLicense.FindByApplicationID(_LocalDrivingLicenseApplication.ApplicationID);
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        public static void LoadData()
        {
            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: Application Was Not Founded ");
                return;
            }
            if(License == null)
            {
                MessageBox.Show("Error: License Was Not Founded ");
                return;
            }
           

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
    }
}
