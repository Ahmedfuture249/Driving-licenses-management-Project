using DVLDBusinessLayer;
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
    public partial class ChangePasswordfrm: Form
    {
        clsUsers _User;
        int _UserID; 
        public ChangePasswordfrm(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _User = clsUsers.Find(_UserID);
            if (_User == null)
                MessageBox.Show("user not founded");
            else
                ctrlUserInfo1._LoadUserInof(_UserID);
            
            
        }
        public void ChangePassword()
        {
            bool CurrentPassIsCorrect = (txtCurrentPassword.Text == _User.UserPassword);
            if (CurrentPassIsCorrect)
            {
                _User.UserPassword = txtPassword.Text.Trim();
                if(_User.Save())
                MessageBox.Show("password Changed successfuly ");
            }
            else
                MessageBox.Show("password dosn't change !! ");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangePassword();
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

        private void ctrlUserInfo1_Load(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "The password confirmation does not match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }

        }
    }
}
