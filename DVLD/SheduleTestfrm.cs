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
    public partial class ManageTestAppointmentsfrm: Form
    {
        int LocalDrivingLicenseApplicationID;
        public ManageTestAppointmentsfrm(int ID)
        {
            InitializeComponent();
            LocalDrivingLicenseApplicationID=ctrlDrivingLicenseApplicationInfocs1.LocalDrivingLicenseApplicationID = ID;
            ctrlDrivingLicenseApplicationInfocs1._LoadApplicationInfo(LocalDrivingLicenseApplicationID);
        }
        private void _RefreshList()
        {
            dgvGetAllAppointments.DataSource = clsTestAppointment.ListTestAppointments(LocalDrivingLicenseApplicationID);
        }
       
        private void ManageTestAppointmentsfrm_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }
    }
}
