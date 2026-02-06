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
    public partial class TakeTestfrm: Form
    {
        clsTest Test;
        static public int TestAppointmentID;
        clsTestAppointment TestAppointment=clsTestAppointment.Find(TestAppointmentID);
        public TakeTestfrm(int TestAppointmentid)
        {
            InitializeComponent();
            TestAppointmentID = TestAppointmentid;
            ctrlTakeTest1.LoadData(TestAppointmentID);
        }

        private void TakeTestfrm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Test = new clsTest();
            if (rbyes.Checked)
                Test.TestResult = true;
            if (rbNo.Checked)
            {
                Test.TestResult = false;
             
                
            }

            Test.Notes = txtNotes.Text;
            Test.CreatedByUserID = ClsGloabalSettings.CurrentUser.UserID;
            Test.TestAppointmentID = TestAppointmentID;
            TestAppointment.IsLocked = true;
            if (Test.TakeTest())
            {
                MessageBox.Show("Data Saved Successfuly ");
                TestAppointment.IsLocked = true;
                TestAppointment.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show("Data Was Not Saved Successfuly ");
            }

        }
    }
}
