using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ScheduleTestfrm: Form
    {
        public ScheduleTestfrm(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            ctrlScheduleTest1.TestTypeID = TestTypeID;
            ctrlScheduleTest1.LoadData(LocalDrivingLicenseApplicationID);
           


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScheduleTestfrm_Load(object sender, EventArgs e)
        {
            
        }

        private void ctrlScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
