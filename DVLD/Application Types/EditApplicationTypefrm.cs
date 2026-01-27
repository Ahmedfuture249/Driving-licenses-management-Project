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
    public partial class EditApplicationTypefrm: Form
    {
        int ApplicationTypeID;
        clsManageApplications _ApplicationType;
        public EditApplicationTypefrm(int ID)
        {
            InitializeComponent();
            ApplicationTypeID = ID;
            _ApplicationType = clsManageApplications.Find(ApplicationTypeID);
        }

        private void _LoadDate()
        {
            if (_ApplicationType == null)
            {
                MessageBox.Show("Application ID Not Founded");
                return;
            }
            lblID.Text = _ApplicationType.ID.ToString();
            txtFees.Text = _ApplicationType.Fees.ToString();
            txtTitle.Text = _ApplicationType.Title;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EditApplicationTypefrm_Load(object sender, EventArgs e)
        {
            _LoadDate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = decimal.Parse(txtFees.Text);

            if(_ApplicationType.UpdateApplicationType())
            {
                MessageBox.Show("Updated Succesfully !!");
            }
            else
                MessageBox.Show("Error !!");
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "this field is Should not be empty");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            };
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
    }
}
