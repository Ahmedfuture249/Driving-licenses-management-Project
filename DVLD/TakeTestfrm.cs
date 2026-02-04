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
        public int TestAppointmentID;
        public TakeTestfrm(int TestAppointmentID)
        {
            InitializeComponent();
            this.TestAppointmentID = TestAppointmentID;
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
            else
                Test.TestResult = false;

            Test.Notes = txtNotes.Text;
            Test.CreatedByUserID = ClsGloabalSettings.CurrentUser.UserID;
            Test.TestAppointmentID = TestAppointmentID;

            if(Test.TakeTest())
            {
                MessageBox.Show("Data Saved Successfuly ");
            }
            else
            {
                MessageBox.Show("Data Was Not Saved Successfuly ");
            }

        }
    }
}
