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
    public partial class frmAddNewUser: Form
    {
        clsUsers _User;
        clsPeople _person;
        int _PersonID;
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;
        public frmAddNewUser()
        {
            InitializeComponent();
          
            Mode = enMode.AddNew;
            if (Mode == enMode.AddNew)
            {
                _User = new clsUsers();
            }
            _PersonID = userControl22.personID;
            _person = clsPeople.Find(_PersonID);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _PersonID = userControl22.personID;
            _person = clsPeople.Find(_PersonID);

            _User.UserName = txtUserName.Text;
            _User.UserPassword = txtPassword.Text;
            if(checkBoxIsActive.Checked==true)
            {
                _User.IsActive = true;
            }
            else
            {
                _User.IsActive =false;
            }
            if(_person!=null)
            {
                _User.PersonID = _PersonID;
            }
           if( _User.Save())
            {
                MessageBox.Show("new user with ID = " + _User.UserID + "Added");
            }
           else
            {
                MessageBox.Show("SOMTHING WRONG HAPPEND");
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "user name must have value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password must have value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text!=txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "The password confirmation does not match");
            }
           
        }
    }
}
