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
    }
}
