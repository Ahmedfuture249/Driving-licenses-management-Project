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
    public partial class IssueLicense : Form
    {
        private int _LDLApplicationID;
        private clsLDLApplication LDLApplication;

        public IssueLicense(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            LDLApplication = clsLDLApplication.FindLocalDrivingLicenseApplication(_LDLApplicationID);
            if (LDLApplication == null)
            {
                MessageBox.Show("Error: Application Was Not Founded ");
                return;
            }
            ctrlDrivingLicenseApplicationInfocs1._LoadApplicationInfo(LDLApplicationID);

        }

        private void ctrlDrivingLicenseApplicationInfocs1_Load(object sender, EventArgs e)
        {

        }

        private void IssueLicense_Load(object sender, EventArgs e)
        {

        }

        private void btnissue_Click(object sender, EventArgs e)
        {
            

            


            int LicenseID = LDLApplication.IssueLicenseForTheFirtTime(txtNotes.Text.Trim(), ClsGloabalSettings.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
    }

