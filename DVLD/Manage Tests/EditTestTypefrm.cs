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
    public partial class EditTestTypefrm: Form
    {
        int TestTypeID;
        clsTestTypes TestType;
        public EditTestTypefrm(int ID)
        {
            InitializeComponent();
            TestTypeID = ID;
            TestType = clsTestTypes.Find(TestTypeID);
            if (TestType == null)
            {
                MessageBox.Show("this test type with ID =" + TestTypeID + "not founded!!");
                return;
            }
        }

        public void loadData()
        {
            lblID.Text = TestTypeID.ToString();
            txtTitle.Text = TestType.TestTitle;
            txtDescription.Text = TestType.TestDesctription;
            txtFees.Text = TestType.Fees.ToString();
        }
        private void EditTestTypefrm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TestType.TestTitle = txtTitle.Text;
            TestType.TestDesctription = txtDescription.Text;
            TestType.Fees =decimal.Parse(txtFees.Text);
            if (TestType.UpdatTestType())
            {
                MessageBox.Show("updated successfully !");
                loadData();
            }
            else
            {
                MessageBox.Show("somthing wrong Happend !");
            }
            


        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "this field is Should not be empty");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;
            if (!clsValdition.IsNumber(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid number");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "this field is Should not be empty");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
            ;
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "this field is Should not be empty");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
            ;
        }
    }
}
